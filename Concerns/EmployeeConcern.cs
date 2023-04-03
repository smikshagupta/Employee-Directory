using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concerns
{
    public class EmployeeConcern
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("DesignationConcern")]
        public int DesignationIDID { get; set; }

        [ForeignKey("OfficeConcern")]
        public int  OfficeID { get; set; }

        [ForeignKey("DepartmentConcern")]
        public int DepartmentID { get; set; }

        public long PhoneNumber { get; set; }

        public string SkypeID { get; set; }
        public string Image { get; set;}

    }
}