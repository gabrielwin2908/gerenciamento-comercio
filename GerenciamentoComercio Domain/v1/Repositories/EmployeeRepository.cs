using GerenciamentoComercio_Domain.v1.Interfaces.Repositories;
using GerenciamentoComercio_Infra.Context;
using GerenciamentoComercio_Infra.Models;
using Incidentes.Business.Repository;
using System.Linq;

namespace GerenciamentoComercio_Domain.v1.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(GerenciamentoComercioContext context) : base(context)
        {
        }

        public Employee GetUserLogin(string access, string password)
        {
            return _context.Employees
                .FirstOrDefault(x => x.Access == access && x.Password == password);
        }
    }
}
