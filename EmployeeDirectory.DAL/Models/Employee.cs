using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.DAL.Models
{
    public class Employee:EntityMetaData
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("Designation")]
        public int DesignationID{ get; set; }

        [ForeignKey("Office")]
        public int OfficeID { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public long PhoneNumber { get; set; }

        public string SkypeID { get; set; }
        public string Image { get; set; }

        public Designation Designaton { get; set; }
        public Office  Office { get; set; }
        public Department Department { get; set; }
    }
}
