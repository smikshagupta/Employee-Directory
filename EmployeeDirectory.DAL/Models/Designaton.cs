﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.DAL.Models
{
    public class Designaton : EntityMetaData
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
