using Concerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Contracts
{
    public  interface ICategoryContract
    {
        List<T> GetDetails<T>();
        T GetDetailsByID<T>(int id);
        bool AddDetails<T>(T details);

        bool UpdateDetails<T>(int id, T details);
        bool DeleteDetails<T>(int id);
    }
}
