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

        
        public async Task<List<TConcern>> GetDetails<TConcern>()
        {
            return  mapper.Map<List<TConcern>>(await context.Set<TDataModel>().ToListAsync());

        }

        public async Task<TConcern> GetDetailsByID<TConcern>(int id)
        {
            return mapper.Map<TConcern>(await context.Set<TDataModel>().FindAsync(id));
        }

        public async Task<bool> AddDetails<TConcern>(TConcern details)
        {
            if (details != null)
            {
                await context.Set<TDataModel>().AddAsync(mapper.Map<TDataModel>(details));
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateDetails<TConcern>(int id, TConcern details)
        {
            TDataModel newDetails = mapper.Map<TDataModel>(details);
            if (id == (int)typeof(TDataModel).GetProperty("ID").GetValue(newDetails))
            {
                UpdateEntries(context, id, newDetails);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public abstract void UpdateEntries(EmployeeContext context, int id, TDataModel entity);

        public async Task<bool> DeleteDetails<TConcern>(int id)
        {
            var details = await context.Set<TDataModel>().FindAsync(id);
            if (details != null)
            {
                context.Set<TDataModel>().Remove(details);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
