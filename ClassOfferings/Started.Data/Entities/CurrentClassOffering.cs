using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Started.Data.Entities
{
   public class CurrentClassOffering
    {
        public int ClassOfferingID { get; set; }

        public string ProgramName { get; set; }

        public string Semester { get; set; }

        public string SectionCode { get; set; }

        public string CourseID { get; set; }
        public int OfferingID { get; set; }
        public string RoomNumber { get; set; }
        public bool Cancelled { get; set; }
    }
}
