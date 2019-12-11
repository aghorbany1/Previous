using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Started.Data.Entities
{
    [Table("Courses")]

    public class Course
    {
        [Key]
        public string CourseID { get; set; }

        [Required(ErrorMessage = "Course Name is Required.")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Credits are Required.")]
        public decimal Credits { get; set; }

        public int? TotalHours { get; set; }

        public int? ClassroomType { get; set; }

        [Required(ErrorMessage = "Term is Required.")]
        public int Term { get; set; }

        [Required(ErrorMessage = "Tuition is Required.")]
        public decimal Tuition { get; set; }

        public string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Description = null;
                }
                else
                {
                    _Description = value;
                }
            }
        }
        [NotMapped]

        public string CourseNames
        {
            get
            {
                return CourseName + "," + CourseID;
            }
        }
    }
}
