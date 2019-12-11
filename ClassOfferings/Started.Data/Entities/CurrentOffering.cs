using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Started.Data.Entities
{
    public class CurrentOffering
    {
        public int OfferingID { get; set; }

        public string ProgramName { get; set; }

        public string Semester { get; set; }

        public string CourseID { get; set; }
    }
}
