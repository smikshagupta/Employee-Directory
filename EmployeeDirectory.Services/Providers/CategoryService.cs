using AutoMapper;
using Concerns;
using EmployeeDirectory.DAL;
using EmployeeDirectory.DAL.Models;
using EmployeeDirectory.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Providers
{
    public class CategoryService:ICategory
    {
        private readonly EmployeeContext context;
        private readonly IMapper mapper;
        public CategoryService(EmployeeContext context,IMapper mapper) 
        { 
            this.context = context;
            this.mapper = mapper;
        }

        
        public List<T> GetDetails<T>()
        {
            var categoryType=typeof(T).Name;
            Department d = new Department();
            dynamic myType = Type.GetType(d);

            if (categoryType.Equals("OfficeConcern"))
            {
                return mapper.Map<List<T>>(context.Offices.ToList());
            }
            else if (categoryType.Equals("DesignationConcern"))
            {
                return mapper.Map<List<T>>(context.Designations.ToList());
            }

            else
            {
                return mapper.Map<List<T>>(context.Departments.ToList());
            }
            //return mapper.Map<List<T>>(context.Set<myType> ().ToList());
            //return mapper.Map<List<T>>(context.new Department().GetType().ToList());

        }

        public bool AddDetails<T>(T details)
        {
            if(details != null)
            {
                var categoryType = typeof(T).Name;
                if (categoryType.Equals("OfficeConcern"))
                {
                    context.Offices.Add(mapper.Map<Office>(details));
                }
                else if (categoryType.Equals("DesignationConcern"))
                {
                    context.Designations.Add(mapper.Map<Designation>(details));

                }
                else
                {
                    context.Departments.Add(mapper.Map<Department>(details));
                }
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateDetails<T>(int id, T details)
        {
            var categoryType= typeof(T).Name;
            if (categoryType.Equals("OfficeConcern"))
            {
                Office office=mapper.Map<Office>(details);
                if (id == office.ID)
                {
                    context.Entry<Office>(office).Property(d=>d.Name).IsModified=true;
                    context.SaveChanges();
                    return true;
                }
            }
            else if (categoryType.Equals("DesignationConcern"))
            {
                Designation designation = mapper.Map<Designation>(details);
                if (id == designation.ID)
                {
                    context.Entry<Designation>(designation).Property(d => d.Name).IsModified = true;
                    context.SaveChanges();
                    return true;
                }
            }
            else
            {
                Department department = mapper.Map<Department>(details);
                if (id == department.ID)
                {
                    context.Entry<Department>(department).Property(ofc => ofc.Name).IsModified = true;
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool DeleteDetails<T>(int id)
        {
            var categoryType=typeof(T).Name;
            if (categoryType.Equals("OfficeConcern"))
            {
                var details = context.Offices.Find(id);
                context.Offices.Remove(details);
                context.SaveChanges();
                return true;
            }
            else if (categoryType.Equals("DesignationConcern"))
            {
                var details = context.Designations.Find(id);
                context.Designations.Remove(details);
                context.SaveChanges();
                return true;
            }
            
            return false;
        }
    }
}
