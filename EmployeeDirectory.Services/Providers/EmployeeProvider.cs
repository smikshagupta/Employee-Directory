using AutoMapper;
using Concerns;
using EmployeeDirectory.DAL;
using EmployeeDirectory.DAL.Models;
using EmployeeDirectory.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeDirectory.Services.Providers
{
    public class EmployeeProvider:IEmployeeContract
    {
        private EmployeeContext Context { get; set; }
        private readonly IMapper _mapper;
        public EmployeeProvider(EmployeeContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeConcern>> GetEmployees()
        {
            List<Employee> employees=new List<Employee>();
            try
            {
                var result = Context.Employees.Include(e => e.Department).Include(e => e.Office).Include(e => e.Designaton);
                //var query= from emp in Context.Employees

                //           select emp;
               // var data=await result.ToListAsync();
                
                employees = result.ToList();

            }
            catch (Exception ex )
            {

                await Console.Out.WriteLineAsync(  ex.Message );
            }
            return _mapper.Map<List<EmployeeConcern>>(employees);

        }

        public async Task<bool> AddEmployee(EmployeeConcern employee)
        {
            if(employee != null)
                {
                await Context.Employees.AddAsync(_mapper.Map<Employee>(employee));
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateEmployee(int empID, EmployeeConcern emp)
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
                await Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int empID)
        {
            var employee = await Context.Employees.FindAsync(empID);
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