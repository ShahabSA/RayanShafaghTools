using RayanShafagh.Extensions;
using RayanShafagh.Windows.Forms.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RayanShafagh.Windows.Forms.Validation
{
    public class Validator
    {

        public Form CurrentForm { get; private set; }
        public ErrorProvider ErrPro { get; private set; }

        private List<ControlInfoPack> ControlsWithAttributes = new List<ControlInfoPack>();

        private Dictionary<string, List<RequiredControlPack>> RequiredControls = new Dictionary<string, List<RequiredControlPack>>();

        private Dictionary<string, List<RequiredControlPack>> SubControls = new Dictionary<string, List<RequiredControlPack>>();

        private Dictionary<Control, List<DefaultAttribute>> DefaultValuedControls = new Dictionary<Control, List<DefaultAttribute>>();

        private List<ControlCompletePack> ControlDetailedPack = new List<ControlCompletePack>();


        private List<Type> TypesToExclude = new List<Type>() 
                            { 
                                typeof(GroupBox), 
                                typeof(Panel), 
                                typeof(FlowLayoutPanel), 
                                typeof(TableLayoutPanel), 
                                typeof(SplitContainer), 
                                typeof(TabControl),
                                typeof(Label)
                            };

        /// <summary>
        /// Initializes a new Validator, sets Validation Event Handler for controls
        /// which has field level validation attribute...
        /// </summary>
        /// <param name="currentForm">current form which needs validation</param>
        /// <param name="errPro">error provider which is used for field level validation</param>
        public Validator(Form currentForm, ErrorProvider errPro)
        {
            this.CurrentForm = currentForm;
            this.ErrPro = errPro;
            Initialize();
        }

        private FieldInfo GetField(Control control)
        {
            var field = CurrentForm.GetType().GetFields().Where(a => control.Name == a.Name && a.FieldType == control.GetType()).FirstOrDefault();
            return field;
        }

        private void Initialize()
        {
            // step 1: extract all controls
            List<Control> source = Utility.GetAllControls(CurrentForm.Controls).ToList();
            //              exclude containers & other controls from initial control collection
            source = Utility.FilterControls(source, TypesToExclude).ToList();

            var fields = CurrentForm.GetType().GetFields()
                                    .Where(a => !TypesToExclude.Contains(a.FieldType)).ToList();


            var joinedDataQuery = source
                                  .Join(fields, a => a.Name, b => b.Name, (a, b) => new ControlInfoPack(a, b))
                                  .Where(a => a.ControlFieldInfo.CustomAttributes.Count() != 0).ToList();

            this.ControlsWithAttributes = joinedDataQuery.ToList();

            var requiredControls = ControlsWithAttributes
                //.Where(a => a.CustomAttribute.Where(at => at.AttributeType == typeof(RequiredAttribute)).Count() != 0)
                                    .Select(a => new
                                    {
                                        control = a.ControlObject,
                                        attr = a.ControlFieldInfo.GetCustomAttribute<RequiredAttribute>()
                                    })
                                    .Where(a => a.attr != null)
                                    .ToList();

            this.ControlDetailedPack = this.ControlsWithAttributes
                                      .Select(a => new ControlCompletePack(a.ControlObject,
                                                                           a.ControlFieldInfo.GetCustomAttribute<RequiredAttribute>(),
                                                                           a.ControlFieldInfo.GetCustomAttribute<RangeAttribute>(),
                                                                           a.ControlFieldInfo.GetCustomAttribute<DataTypeAttribute>(),
                                                                           a.ControlFieldInfo.GetCustomAttribute<StartPointControlAttribute>()))
                                       .ToList();

            #region Extract Required Controls with same GroupName



            var allGroupNames = requiredControls
                                    .Select(a => a.attr.GroupName)
                                    .Distinct()
                                    .ToList();



            foreach (var groupName in allGroupNames)
            {

                var controlsInGroup = requiredControls.Where(a => a.attr.GroupName == groupName)
                                        .Select(a => new RequiredControlPack(a.control, a.attr))
                                        .ToList();

                this.RequiredControls[groupName] = controlsInGroup;
            }

            #endregion

            #region Extract Required Control with same SubGroupName

            var allSubGroupNames = requiredControls
                                       .Where(a => !string.IsNullOrEmpty(a.attr.SubGroupName))
                                       .Select(a => a.attr.SubGroupName)
                                       .Distinct()
                                       .ToList();

            foreach (var subName in allSubGroupNames)
            {
                var controlInSubGroup = requiredControls
                                        .Where(a => a.attr.SubGroupName == subName)
                                        .Select(a => new RequiredControlPack(a.control, a.attr)).ToList();

                this.SubControls[subName] = controlInSubGroup.ToList();
            }

            #endregion

            #region Extract Controls with Default Attribute

            var defaultControlsQuery = joinedDataQuery
                                   .Where(a => a.ControlFieldInfo.CustomAttributes.Where(at => at.AttributeType == typeof(DefaultAttribute)).Count() != 0)
                                   .Select(a => new
                                   {
                                       control = a.ControlObject,
                                       att = a.ControlFieldInfo.GetCustomAttributes<DefaultAttribute>().ToList()
                                   });
            foreach (var item in defaultControlsQuery)
            {
                this.DefaultValuedControls[item.control] = item.att;
            }

            #endregion

            #region Set field level validation Handler

            var fieldLevelControls = requiredControls
                                     .Where(a => a.attr.Level == ValidationLevel.FieldLevel);
            foreach (var item in fieldLevelControls)
            {
                item.control.Validating += Control_Validating;
            }

            #endregion
        }

        public bool Validate(string controlGroupName, bool isSubGroup = false)
        {
            IEnumerable<ControlCompletePack> controlsInGroup;
            if (!isSubGroup)
            {
                controlsInGroup = this.ControlDetailedPack
                                      .Where(a => a.Required != null)
                                      .Where(a => a.Required.GroupName == controlGroupName);
            }
            else
            {
                controlsInGroup = this.ControlDetailedPack
                                      .Where(a => a.Required != null)
                                      .Where(a => a.Required.SubGroupName == controlGroupName);
            }

            bool anyError = false;

            foreach (var item in controlsInGroup)
            {
                if (this.IsControlInvalid(item.ControlObject, item.Required, item.Range, item.DataType))
                {
                    anyError = true;
                }
            }

            return !anyError;
        }

        public bool Validate()
        {
            bool anyError = false;

            foreach (var item in this.ControlDetailedPack)
            {
                if (this.IsControlInvalid(item.ControlObject, item.Required, item.Range, item.DataType))
                {
                    anyError = true;
                }
            }

            return !anyError;
        }

        public void SetDefaults()
        {
            foreach (var item in this.DefaultValuedControls)
            {
                var control = item.Key;

                if (item.Value.Count == 1)
                {
                    var singleDefaultAtt = item.Value.FirstOrDefault();
                    var targetField = control.GetType().GetField(singleDefaultAtt.TargetPropertyName);
                    targetField.SetValue(control, singleDefaultAtt.Value);
                }
                //TODO : write codes to set multiple values for multiple DefaultAttribute
            }
        }

        private void Control_Validating(object sender, CancelEventArgs e)
        {
            var cont = (Control)sender;
            var fld = GetField(cont);
            var reqAtt = fld.GetCustomAttribute<RequiredAttribute>();
            var rangeAtt = fld.GetCustomAttribute<RangeAttribute>();
            var typeAtt = fld.GetCustomAttribute<DataTypeAttribute>();

            bool error = IsControlInvalid(cont, reqAtt, rangeAtt, typeAtt, e);

            //if (error)
            //{
            //    if (reqAtt != null)
            //    {
            //        if (reqAtt.StickInControl)
            //        {
            //            e.Cancel = true;
            //        }
            //    }
            //    cont.Focus();
            //    return;
            //}

            // DONE!
        }

        private bool IsControlInvalid(Control cont, RequiredAttribute reqAtt, RangeAttribute rangeAtt, DataTypeAttribute typeAtt)
        {
            bool error = false;
            ErrPro.SetError(cont, "");

            #region Required Validation

            if (reqAtt != null)
            {
                if (!ValidateRequiredControl(cont))
                {
                    ErrPro.SetError(cont, reqAtt.ErrorMessage);
                    error = true;
                }
            }

            #endregion

            #region Data Type Validation

            if (typeAtt != null)
            {
                if (!CheckType(typeAtt.Type, cont.Text))
                {
                    ErrPro.SetError(cont, typeAtt.ErrorMessage);
                    error = true;
                }
            }

            #endregion

            #region Range Validation

            if (rangeAtt != null)
            {
                if (cont is TextBox)
                {
                    if (!CheckRange(rangeAtt.Min, rangeAtt.HasMin, rangeAtt.Max, rangeAtt.HasMax, cont.Text))
                    {
                        ErrPro.SetError(cont, rangeAtt.ErrorMessage);
                        error = true;
                    }
                }
                else if (cont is ListBox)
                {
                    if (!CheckRange(rangeAtt.Min, rangeAtt.HasMin, rangeAtt.Max, rangeAtt.HasMax, ((ListBox)cont).Items))
                    {
                        ErrPro.SetError(cont, rangeAtt.ErrorMessage);
                        error = true;
                    }

                }
                else if (cont is MonthCalendar)
                {
                    if (!CheckRange(rangeAtt.Min, rangeAtt.HasMin, rangeAtt.Max, rangeAtt.HasMax, ((MonthCalendar)cont).SelectionRange))
                    {
                        ErrPro.SetError(cont, rangeAtt.ErrorMessage);
                        error = true;
                    }

                }
            }

            #endregion

            return error;
        }

        private bool IsControlInvalid(Control cont, RequiredAttribute reqAtt, RangeAttribute rangeAtt, DataTypeAttribute typeAtt, CancelEventArgs e)
        {
            bool error = false;
            ErrPro.SetError(cont, "");

            #region Required Validation

            if (reqAtt != null)
            {
                if (!ValidateRequiredControl(cont))
                {
                    ErrPro.SetError(cont, reqAtt.ErrorMessage);
                    e.Cancel = reqAtt.StickInControl;
                    error = true;
                }
            }

            #endregion

            #region Data Type Validation

            if (typeAtt != null)
            {
                if (!CheckType(typeAtt.Type, cont.Text))
                {
                    ErrPro.SetError(cont, typeAtt.ErrorMessage);
                    e.Cancel = typeAtt.StickInControl;
                    error = true;
                }
            }

            #endregion

            #region Range Validation

            if (rangeAtt != null)
            {
                if (cont is TextBox)
                {
                    if (!CheckRange(rangeAtt.Min, rangeAtt.HasMin, rangeAtt.Max, rangeAtt.HasMax, cont.Text))
                    {
                        ErrPro.SetError(cont, rangeAtt.ErrorMessage);
                        error = true;
                    }
                }
                else if (cont is ListBox)
                {
                    if (!CheckRange(rangeAtt.Min, rangeAtt.HasMin, rangeAtt.Max, rangeAtt.HasMax, ((ListBox)cont).Items))
                    {
                        ErrPro.SetError(cont, rangeAtt.ErrorMessage);
                        error = true;
                    }

                }
                else if (cont is MonthCalendar)
                {
                    if (!CheckRange(rangeAtt.Min, rangeAtt.HasMin, rangeAtt.Max, rangeAtt.HasMax, ((MonthCalendar)cont).SelectionRange))
                    {
                        ErrPro.SetError(cont, rangeAtt.ErrorMessage);
                        error = true;
                    }

                }
                e.Cancel = rangeAtt.StickInControl && error;
            }

            #endregion

            if (error)
            {
                cont.Focus();
            }

            return error;
        }

        //here...
        private bool ValidateRequiredControl(Control cont)
        {

            if (cont is TextBox)
            {
                return !string.IsNullOrEmpty(cont.Text.Trim());
            }
            else if (cont is MaskedTextBox)
            {
                return !string.IsNullOrEmpty(cont.Text.Trim());
            }
            else if (cont is ComboBox)
            {
                return ((ComboBox)cont).SelectedIndex != -1;
            }
            else if (cont is ListBox)
            {
                return ((ListBox)cont).Items.Count != 0;
            }
            else if (cont is CheckedListBox)
            {
                return ((CheckedListBox)cont).CheckedIndices.Count != 0;
            }
            else if (cont is RichTextBox)
            {
                return !string.IsNullOrEmpty(cont.Text.Trim());
            }
            else if (cont is DataGridView)
            {
                return ((DataGridView)cont).SelectedRows.Count != 0;
            }
            
            return true;

        }

        private bool CheckType(DataType type, string value)
        {
            try
            {
                switch (type)
                {
                    case DataType.Byte:
                        return value.ToByte().HasValue;

                    case DataType.Int16:
                        return value.ToInt16().HasValue;

                    case DataType.Int32:
                        return value.ToInt32().HasValue;

                    case DataType.Int64:
                        return value.ToInt64().HasValue;

                    case DataType.Single:
                        return value.ToSingle().HasValue;

                    case DataType.Double:
                        return value.ToDouble().HasValue;

                    case DataType.Date:
                        return value.IsDate();

                    case DataType.Time:
                        return value.IsTime();

                    case DataType.DateTime:
                        return value.IsDateTime();

                    case DataType.DatePersian:
                        return value.IsDatePersian();

                    case DataType.Name:
                        return value.IsName();

                    case DataType.Digit:
                        return value.IsDigit();

                    case DataType.PhoneNumber:
                        return value.IsPhoneNumber();

                    case DataType.EmailAddress:
                        return value.IsEmail();

                    case DataType.URL:
                        return value.IsURL();

                    default:
                        return true;
                }

            }
            catch (Exception ex)
            {
                throw new ValidationException(ex.Message);
            }

        }

        private bool CheckRange(int min, bool hasMin, int max, bool hasMax, string value)
        {
            if (hasMin && hasMax)
            {
                if (value.Length >= min && value.Length <= max)
                {
                    return true;
                }
                return false;

            }
            else if (hasMin)
            {
                if (value.Length >= min)
                {
                    return true;
                }
                return false;
            }
            else if (hasMax)
            {
                if (value.Length <= max)
                {
                    return true;
                }
                return false;
            }

            return false;

        }

        private bool CheckRange(int min, bool hasMin, int max, bool hasMax, int value)
        {
            if (hasMin && hasMax)
            {
                if (value >= min && value <= max)
                {
                    return true;
                }
                return false;

            }
            else if (hasMin)
            {
                if (value >= min)
                {
                    return true;
                }
                return false;
            }
            else if (hasMax)
            {
                if (value <= max)
                {
                    return true;
                }
                return false;
            }

            return false;

        }

        private bool CheckRange(int min, bool hasMin, int max, bool hasMax, object[] value)
        {
            if (hasMin && hasMax)
            {
                if (value.Length >= min && value.Length <= max)
                {
                    return true;
                }
                return false;

            }
            else if (hasMin)
            {
                if (value.Length >= min)
                {
                    return true;
                }
                return false;
            }
            else if (hasMax)
            {
                if (value.Length <= max)
                {
                    return true;
                }
                return false;
            }

            return false;

        }

        private bool CheckRange(int min, bool hasMin, int max, bool hasMax, ListBox.ObjectCollection value)
        {
            if (hasMin && hasMax)
            {
                if (value.Count >= min && value.Count <= max)
                {
                    return true;
                }
                return false;

            }
            else if (hasMin)
            {
                if (value.Count >= min)
                {
                    return true;
                }
                return false;
            }
            else if (hasMax)
            {
                if (value.Count <= max)
                {
                    return true;
                }
                return false;
            }

            return false;

        }

        private bool CheckRange(int min, bool hasMin, int max, bool hasMax, SelectionRange value)
        {
            int range = Convert.ToInt32((value.End - value.Start).TotalDays);

            return CheckRange(min, hasMin, max, hasMax, range);
        }


    }
}
