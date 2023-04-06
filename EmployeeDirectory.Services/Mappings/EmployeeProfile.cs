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
            CreateMap<EmployeeConcern, Employee>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(o=>DateTime.Now))
                .ForMember(dest=>dest.LastModifiedDate,opt=>opt.MapFrom(o=>DateTime.Now));

            //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(o => o.FirstName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(o => o.LastName))
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(o => o.Email))
            //    .ForMember(dest => dest.DesignationID, opt => opt.MapFrom(o => o.DesignationID))
            //    .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(o => o.DepartmentID))
            //    .ForMember(dest => dest.OfficeID, opt => opt.MapFrom(o => o.OfficeID))
            //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(o => o.PhoneNumber))
            //    .ForMember(dest => dest.SkypeID, opt => opt.MapFrom(o => o.SkypeID))
            //    .ForMember(dest => dest.Image, opt => opt.MapFrom(o => o.Image))
        }

    }
}
