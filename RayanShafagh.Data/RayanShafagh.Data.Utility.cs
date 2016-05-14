using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.Data
{
    public static class Utility
    {
        /// <summary>
        /// Copies specified members values from SourceObject to DestinationObject, it does not clone reference type values
        /// </summary>
        /// <typeparam name="T">should be class</typeparam>
        /// <typeparam name="Q">should be class</typeparam>
        /// <param name="SourceObject">source object of type T which it's member values need to be copied</param>
        /// <param name="DestinationObject">destinition object ot type Q which values from source should be copied into, it should not be null</param>
        /// <param name="CaseSensitive">inidcates if members name copmarison should be case sensitive or not, default is false</param>
        /// <param name="type">d\indicates member type which it's value should be copied</param>
        /// <returns></returns>
        public static Q Copy<T, Q>(T SourceObject, Q DestinationObject, bool CaseSensitive = false, MemberType type = MemberType.Both)
            where T : class
            where Q : class
        {
            #region Binding
            switch (type)
            {
                case MemberType.Field:
                    #region Binding Fields
                    //Binding Fields
                    CopyField<T, Q>(SourceObject, DestinationObject, CaseSensitive);
                    //End Binding Fields
                    #endregion
                    break;
                case MemberType.Property:
                    #region Binding Propertys
                    CopyProperty<T, Q>(SourceObject, DestinationObject, CaseSensitive);
                    #endregion
                    break;
                case MemberType.Both:
                    #region Binding Propertys
                    CopyProperty<T, Q>(SourceObject, DestinationObject, CaseSensitive);
                    #endregion
                    #region Binding Fields
                    //Binding Fields
                    CopyField<T, Q>(SourceObject, DestinationObject, CaseSensitive);
                    //End Binding Fields
                    #endregion
                    break;
                default:
                    break;
            }

            #endregion
            return DestinationObject;
        }

        internal static void CopyField<T, Q>(T SourceObject, Q DestinationObject, bool CaseSensitive)
            where T : class
            where Q : class
        {
            foreach (System.Reflection.FieldInfo SourceField in SourceObject.GetType().GetFields())
            {
                var EqualFields = DestinationObject.GetType().GetFields().Where(a =>
                    (!CaseSensitive) ? a.Name.Trim().ToLower() == SourceField.Name.Trim().ToLower() : a.Name.Trim() == SourceField.Name.Trim()
                    && a.FieldType == SourceField.FieldType);
                foreach (var field in EqualFields)
                {
                    field.SetValue(DestinationObject, SourceField.GetValue(SourceObject));
                }
            }
        }

        internal static void CopyProperty<T, Q>(T SourceObject, Q DestinationObject, bool CaseSensitive)
            where T : class
            where Q : class
        {
            //Binding Propertys
            foreach (System.Reflection.PropertyInfo SourceProp in SourceObject.GetType().GetProperties())
            {
                foreach (System.Reflection.PropertyInfo DestinationProp in DestinationObject.GetType().GetProperties())
                {
                    if (SourceProp.PropertyType == DestinationProp.PropertyType)
                    {
                        if (!CaseSensitive)
                        {
                            if (SourceProp.Name.Trim().ToLower() == DestinationProp.Name.Trim().ToLower())
                            {
                                if (DestinationProp.CanWrite == true && SourceProp.CanRead == true)
                                {
                                    DestinationProp.SetValue(DestinationObject, SourceProp.GetValue(SourceObject));
                                }
                            }
                        }
                        else
                        {
                            if (SourceProp.Name.Trim() == DestinationProp.Name.Trim())
                            {
                                if (DestinationProp.CanWrite == true && SourceProp.CanRead == true)
                                {
                                    DestinationProp.SetValue(DestinationObject, SourceProp.GetValue(SourceObject));
                                }
                            }
                        }
                    }
                }
            }
            //End Binding Propertys 
        }
    }
}
