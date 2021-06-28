using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IPuestoService
    {
        Task<DBEntity> Create(Puesto entity);
        Task<DBEntity> Delete(Puesto entity);
        Task<IEnumerable<Puesto>> Get();
        Task<Puesto> GetById(Puesto entity);
        Task<DBEntity> Update(Puesto entity);

    }

    public class PuestoService : IPuestoService
    {
        private readonly IDataAccess sql;

        public PuestoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<Puesto>> Get()
        {

            try
            {
                var result = sql.QueryAsync<Puesto>("PuestoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Puesto> GetById(Puesto entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<Puesto>("PuestoObtener", new
                {
                    entity.ID
                }
                );

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(Puesto entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestoInsertar", new
                {
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                }
                );

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Update(Puesto entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestoActualizar", new
                {
                    entity.ID,
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                }
                );

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Delete(Puesto entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestoEliminar", new
                {
                    entity.ID

                }
                );

                return await result;

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
