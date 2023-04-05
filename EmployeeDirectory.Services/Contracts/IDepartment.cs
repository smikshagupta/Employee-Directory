using Concerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contracts
{
    public interface IDepartment
    {
        List<DepartmentConcern> GetDepartments();

        bool AddDepartment(DepartmentConcern department);

        bool UpdateDepartment(int depID, DepartmentConcern department);
        bool DeleteDepartment(int depID);
    }
}
