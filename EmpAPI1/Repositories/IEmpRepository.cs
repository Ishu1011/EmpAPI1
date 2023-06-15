
using EmpAPI1.Model;
using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace EmpAPI1.Repositories
{
    public interface IEmpRepository
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(int EmpId);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(int EmpId);
         

    }
}
