using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AccesoDatosEntity
{
    public class Repositorios : IAccesodatosEntity, IDisposable
    {
        protected DbContext _contexto = null;

        public Repositorios(DbContext Contexto, bool Cambios = false, bool Proxi = false)
        {
            _contexto = Contexto;
            _contexto.Configuration.AutoDetectChangesEnabled = Cambios;
            _contexto.Configuration.ProxyCreationEnabled = Proxi;
        }

        public TEntity Create<TEntity>(TEntity NewEntitad) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = _contexto.Set<TEntity>().Add(NewEntitad);
                TrySaveChange();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Result;
        }

        protected virtual int TrySaveChange()
        {
            return _contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> FindEntity<TEntity>(Expression<Func<TEntity, bool>> Criterio) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = await _contexto.Set<TEntity>().FirstOrDefaultAsync(Criterio);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Result;
        }

        public async Task<IEnumerable<TEntity>> ReadData<TEntity>() where TEntity : class
        {
            List<TEntity> Result = null;
            try
            {
                var Entity = _contexto.Set<TEntity>();
                Result = await Entity.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Result;
        }

        public bool Update<TEntity>(TEntity ModefiedEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                _contexto.Set<TEntity>().Attach(ModefiedEntity);
                _contexto.Entry<TEntity>(ModefiedEntity).State = EntityState.Modified;
                Result = TrySaveChange() > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Result;
        }
    }
}
