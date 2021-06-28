using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IDepartamentoService
    {
        Task<DBEntity> Create(Departamento entity);
        Task<DBEntity> Delete(Departamento entity);
        Task<IEnumerable<Departamento>> Get();
        Task<Departamento> GetById(Departamento entity);
        Task<DBEntity> Update(Departamento entity);

    }


   public  class DepartamentoService : IDepartamentoService
    {
        private readonly IDataAccess sql;

        public DepartamentoService(IDataAccess _sql)
        {
            sql = _sql;
        }


        public async Task<IEnumerable<Departamento>> Get()
        {

            try
            {
                var result = sql.QueryAsync<Departamento>("DepartamentoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Departamento> GetById(Departamento entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<Departamento>("DepartamentoObtener", new
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

        public async Task<DBEntity> Create(Departamento entity)
        {
            try
            {
                var result = sql.ExecuteAsync("DepartamentoInsertar", new
                {
                    entity.Descripcion,
                    entity.Ubicacion,
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

        public async Task<DBEntity> Update(Departamento entity)
        {
            try
            {
                var result = sql.ExecuteAsync("DepartamentoActualizar", new
                {
                    entity.ID,
                    entity.Descripcion,
                    entity.Ubicacion,
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

        public async Task<DBEntity> Delete(Departamento entity)
        {
            try
            {
                var result = sql.ExecuteAsync("DepartamentoEliminar", new
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
