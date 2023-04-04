using AutoMapper;
using Concerns;
using EmployeeDirectory.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Mappings
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeConcern>();
            CreateMap<EmployeeConcern, Employee>().ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(o=>DateTime.Now))
                .ForMember(dest=>dest.LastModifiedDate,opt=>opt.MapFrom(o=>DateTime.Now));
        }
    }
}
