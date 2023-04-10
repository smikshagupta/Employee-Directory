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
            
        bool AddEmployee(EmployeeConcern employee);

        bool UpdateEmployee(int empID,EmployeeConcern employee);
        bool DeleteEmployee(int empID);

    }
}
