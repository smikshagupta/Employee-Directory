﻿using AutoMapper;
using Concerns;
using EmployeeDirectory.DAL;
using EmployeeDirectory.DAL.Models;
using EmployeeDirectory.Services.Contracts;
using System.Linq;

namespace EmployeeDirectory.Services.Providers
{
    public class EmployeeService:IEmployee
    {
        private EmployeeContext Context { get; set; }
        private readonly IMapper _mapper;
        public EmployeeService(EmployeeContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeConcern>> GetEmployees()
        {
            return _mapper.Map<List<EmployeeConcern>>(Context.Employees.ToList());
        }

        public bool AddEmployee(EmployeeConcern employee)
        {
            if(employee != null)
                {
                Context.Employees.Add(_mapper.Map<Employee>(employee));
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateEmployee(int empID, EmployeeConcern emp)
        {
            Employee updatedEmployee=_mapper.Map<Employee>(emp);
            if(emp.ID == empID)
            {
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.FirstName).IsModified = true;
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.LastName).IsModified = true;
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.Email).IsModified = true;
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.DesignationID).IsModified = true;
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.OfficeID).IsModified = true;
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.DepartmentID).IsModified = true;
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.PhoneNumber).IsModified = true;
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.SkypeID).IsModified = true;
                Context.Entry<Employee>(updatedEmployee).Property(emp => emp.Image).IsModified = true;
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteEmployee(int empID)
        {
            var employee = Context.Employees.Find(empID);
            if (employee != null)
            {
                Context.Employees.Remove(employee);
                Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}