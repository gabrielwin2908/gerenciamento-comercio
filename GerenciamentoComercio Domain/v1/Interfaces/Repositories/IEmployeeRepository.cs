using GerenciamentoComercio_Infra.Models;
using Incidentes.Business.Repository;

namespace GerenciamentoComercio_Domain.v1.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetUserLogin(string access, string password);
    }
}
