﻿using AutoMapper;
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
    public class DepartmentProvider : CategoryProvider<DepartmentConcern, Department>, IDepartmentContract
    {
        public DepartmentProvider(EmployeeContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override void UpdateEntries(EmployeeContext context, int id, Department entity)
        {
            context.Entry(entity).Property(e => e.Name).IsModified = true;
        }
    }
}