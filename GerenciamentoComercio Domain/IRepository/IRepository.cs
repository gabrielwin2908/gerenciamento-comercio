using System.Collections.Generic;
using System.Threading.Tasks;

namespace Incidentes.Business.Repository
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetMany();
        void AddNew(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
        void DeleteSeveral(IEnumerable<TEntity> objs);
    }
}
