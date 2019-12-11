using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Started.Data.Entities
{
    [Table("ClassOfferings")]
    public class ClassOffering
    {
        [Key]

        public int ClassOfferingID { get; set; }

        [Required(ErrorMessage = "Offering ID is Required.")]
        public int OfferingID { get; set; }

        public string _SectionCode;
        public string SectionCode
        {
            get
            {
                return _SectionCode;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SectionCode = null;
                }
                else
                {
                    _SectionCode = value;
                }
            }
        }

        [Required(ErrorMessage = "Employee ID is Required.")]
        public int EmployeeID { get; set; }

        public string _RoomNumber;
       public readonly object ClassOfferingDescription;

        public string RoomNumber
        {
            get
            {
                return _RoomNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RoomNumber = null;
                }
                else
                {
                    _RoomNumber = value;
                }
            }
        }

        public bool Cancelled { get; set; }

    }
}
