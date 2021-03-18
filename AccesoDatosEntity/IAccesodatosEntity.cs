using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosEntity
{
    public interface IAccesodatosEntity : IDisposable
    {
        TEntity Create<TEntity>(TEntity NewEntitad) where TEntity : class;

         Task<TEntity> FindEntity<TEntity>(Expression<Func<TEntity, bool>> Criterio) where TEntity : class;

         Task<IEnumerable<TEntity>> ReadData<TEntity>() where TEntity : class;

        bool Update<TEntity>(TEntity ModefiedEntity) where TEntity : class;

        
    }
}
