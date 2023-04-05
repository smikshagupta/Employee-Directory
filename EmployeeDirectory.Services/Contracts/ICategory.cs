using Concerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contracts
{
    public  interface ICategory
    {
        List<T> GetDetails<T>();

        bool AddDetails<T>(T details);

        bool UpdateDetails<T>(int id, T details);
        bool DeleteDetails<T>(int id);
    }
}
