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
    public class DesignationProfile:Profile
    {
        public DesignationProfile()
        {
            CreateMap<DesignationConcern, Designation>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(s => DateTime.Now))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(s => DateTime.Now));
            CreateMap<Designation, DesignationConcern>();
        }
    }
}
