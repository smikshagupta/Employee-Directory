using AutoMapper;
using AutoMapper.Internal;
using Concerns;
using EmployeeDirectory.DAL;
using EmployeeDirectory.DAL.Models;
using EmployeeDirectory.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Providers
{
    public abstract class CategoryProvider<TConcern,TDataModel>:ICategoryContract where TConcern : class where TDataModel : class
    {
        private readonly EmployeeContext context;
        private readonly IMapper mapper;
        public CategoryProvider(EmployeeContext context,IMapper mapper) 
        { 
            this.context = context;
            this.mapper = mapper;
        }

        
        public List<TConcern> GetDetails<TConcern>()
        {
            return  mapper.Map<List<TConcern>>(context.Set<TDataModel>());

        }

        public TConcern GetDetailsByID<TConcern>(int id)
        {
            return mapper.Map<TConcern>(context.Set<TDataModel>().Find(id));
        }

        public bool AddDetails<TConcern>(TConcern details)
        {
            if (details != null)
            {
                context.Set<TDataModel>().Add(mapper.Map<TDataModel>(details));
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateDetails<TConcern>(int id, TConcern details)
        {
            TDataModel newDetails = mapper.Map<TDataModel>(details);
            if (id == (int)typeof(TDataModel).GetProperty("ID").GetValue(newDetails))
            {
                //context.Entry<TDataModel>(newDetails).Property(n => n.Name).IsModified=true;
                UpdateEntries(context, id, newDetails);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public abstract void UpdateEntries(EmployeeContext context, int id, TDataModel entity);

        public bool DeleteDetails<TConcern>(int id)
        {
            var details = context.Set<TDataModel>().Find(id);
            if (details != null)
            {
                context.Set<TDataModel>().Remove(details);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
