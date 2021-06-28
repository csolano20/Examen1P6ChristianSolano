using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WBL
{
    public interface ITituloService
    {
        Task<DBEntity> Create(Titulo entity);
        Task<DBEntity> Delete(Titulo entity);
        Task<IEnumerable<Titulo>> Get();
        Task<Titulo> GetById(Titulo entity);
        Task<DBEntity> Update(Titulo entity);

    }

    public class TituloService : ITituloService
    {

        private readonly IDataAccess sql;

        public TituloService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<Titulo>> Get()
        {

            try
            {
                var result = sql.QueryAsync<Titulo>("TituloObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Titulo> GetById(Titulo entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<Titulo>("TituloObtener", new
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

        public async Task<DBEntity> Create(Titulo entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TituloInsertar", new
                {
                    entity.Descripcion,
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

        public async Task<DBEntity> Update(Titulo entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TituloActualizar", new
                {
                    entity.ID,
                    entity.Descripcion,
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

        public async Task<DBEntity> Delete(Titulo entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TituloEliminar", new
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