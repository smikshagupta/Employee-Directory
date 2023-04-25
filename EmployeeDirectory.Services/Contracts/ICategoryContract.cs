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
        Task<List<T>> GetDetails<T>();
        Task<T> GetDetailsByID<T>(int id);
        Task<bool> AddDetails<T>(T details);

        Task<bool> UpdateDetails<T>(int id, T details);
        Task<bool> DeleteDetails<T>(int id);
    }
}
