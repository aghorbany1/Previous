using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Started.Data.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]

        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }

        public DateTime DateHired { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int PositionID { get; set; }

        public int ProgramID { get; set; }

        public string LoginID { get; set; }

        [NotMapped]

        public string FullName
        {
            get
            {
                return LastName + "," + FirstName;
            }
        }

    }
}
