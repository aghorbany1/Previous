using System;
using Started.Data.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using System.Collections.Generic;
using StartedSystem.DAL;
using System.Data.SqlClient;
using System.ComponentModel;
#endregion

namespace StartedSystem.BLL
{
    [DataObject]
    public class CourseController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Course> Courses_List()
        {
            using (var context = new StartedContext())
            {
                return context.Courses.ToList();
            }
        }

        public Course Courses_Get(int courseid)
        {
            using (var context = new StartedContext())
            {
                return context.Courses.Find(courseid);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Course> Courses_FindByProgram(int programid)
        {
            using (var context = new StartedContext())
            {
                var results = context.Database.SqlQuery<Course>("Courses_FindByProgram @programid", new SqlParameter("ProgramID", programid));
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Course> Courses_FindByPartialName(string partialname)
        {
            using (var context = new StartedContext())
            {
                var results = context.Database.SqlQuery<Course>("Courses_FindByPartialName @partialname",
                    new SqlParameter("partialname", partialname));
                return results.ToList();
            }
        }

        //[DataObjectMethod(DataObjectMethodType.Select, false)]
        //public List<ClassOffering> CurrentOfferings_FindByCourse(object selectedValue)
        //{
        //    using (var context = new StartedContext())
        //    {
        //        var results = context.Database.SqlQuery<Course>("CurrentOfferings_FindByCourse @offeringid",
        //            new SqlParameter("OfferingID", Offeringid));
        //        return results.ToList();
        //    }
        //}
    }
}
