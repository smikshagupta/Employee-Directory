using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concerns
{
    public class EmployeeConcern
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public DesignationConcern Designation { get; set; }
        public DepartmentConcern Department { get; set; }

        public OfficeConcern Office { get; set; }
        public long PhoneNumber { get; set; }

        public string SkypeID { get; set; }
        public string Image { get; set;}

    }
}