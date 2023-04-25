using Concerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contracts
{
    public interface IEmployeeContract
    {
        Task<List<EmployeeConcern>> GetEmployees();

        Task<bool> AddEmployee(EmployeeConcern employee);

        Task<bool> UpdateEmployee(int empID,EmployeeConcern employee);
        Task<bool> DeleteEmployee(int empID);

    }
}
