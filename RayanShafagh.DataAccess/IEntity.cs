using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayanShafagh.DataAccess
{
    public interface IEntity<TEntity,UKey> where TEntity:class
    {
  
        List<TEntity> Get();
        TEntity Find(UKey key);

        bool Delete(UKey key);
        bool Delete(TEntity item);

        bool Update(TEntity item);

        bool Add(TEntity item);
    }
}
