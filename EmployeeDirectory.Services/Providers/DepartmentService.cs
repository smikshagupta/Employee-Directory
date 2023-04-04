using AutoMapper;
using Concerns;
using EmployeeDirectory.DAL;
using EmployeeDirectory.DAL.Models;
using EmployeeDirectory.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Providers
{
    public class DepartmentService:IDepartment
    {
        private readonly EmployeeContext context;
        private readonly IMapper mapper;

        public DepartmentService(EmployeeContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<DepartmentConcern> GetDepartments()
        {
            return (mapper.Map<List<DepartmentConcern>>(context.Departments.ToList()));
        }

        public bool AddDepartment(DepartmentConcern department)
        {
            if(department != null)
            {
                context.Departments.Add(mapper.Map<Department>(department));
                context.SaveChanges();
                return true; 
            }
            return false;
        }

        public bool UpdateDepartment(int id,DepartmentConcern department)
        {
            Department updatedDepartment=mapper.Map<Department>(department);
            if(id==department.ID)
            {
                context.Entry<Department>(updatedDepartment).Property(dep=>dep.Name).IsModified=true;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteDepartment(int id)
        {
            var department = context.Departments.Find(id);
            if(department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
