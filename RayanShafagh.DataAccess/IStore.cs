using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.DataAccess
{
    public interface IStore : IDisposable
    {
        void SaveChangesToStore();
        void SaveChangesToStoreAsync();

    }
}
