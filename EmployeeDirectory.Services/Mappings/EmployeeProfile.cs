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
            CreateMap<Employee, EmployeeConcern>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designaton))
                .ForMember(dest => dest.Office, opt => opt.MapFrom(src => src.Office));

            CreateMap<EmployeeConcern, Employee>()
                .ForMember(dest=>dest.DepartmentID,opt=>opt.MapFrom(o=>o.Department.ID))
                .ForMember(dest=>dest.DesignationID,opt=>opt.MapFrom(src=>src.Designation.ID))
                .ForMember(dest=>dest.OfficeID,opt=>opt.MapFrom(src=>src.Office.ID))
                .ForMember(dest => dest.Department,opt=>opt.MapFrom(src=> src.Department.ID == 0 ?src.Department:null))
                .ForMember(dest => dest.Office, opt => opt.Ignore())
                .ForMember(dest => dest.Designaton, opt => opt.Ignore())
                .ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(o=>DateTime.Now))
                .ForMember(dest=>dest.LastModifiedDate,opt=>opt.MapFrom(o=>DateTime.Now));
        }

    }
}
