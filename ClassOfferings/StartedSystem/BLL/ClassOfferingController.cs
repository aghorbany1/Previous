
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

#region Additional Namespaces
using Started.Data.Entities;
using StartedSystem.DAL;
using System.ComponentModel;
#endregion

namespace StartedSystem.BLL
{
    [DataObject]
    public class ClassOfferingController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ClassOffering> ClassOffering_List()
        {
            using (var context = new StartedContext())
            {
                return context.ClassOfferings.ToList();
            }
        }
        public ClassOffering ClassOfferings_Get(int classofferingid)
        {
            using (var context = new StartedContext())
            {
                return context.ClassOfferings.Find(classofferingid);
            }
        }


        public int ClassOffering_Add(ClassOffering item)
        {
            using (var context = new StartedContext())
            {
                context.ClassOfferings.Add(item);
                context.SaveChanges();
                return item.ClassOfferingID;
            }
        }

        public int ClassOffering_Update(ClassOffering item)
        {
            using (var context = new StartedContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public int ClassOffering_Delete(int classofferingid)
        {
            using (var context = new StartedContext())
            {
                var existing = context.ClassOfferings.Find(classofferingid);

                existing.Cancelled = true;
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        //public List<ClassOffering> ClassingOfferings_FindByCourse(string courseid)
        //{
        //    using (var context = new StartedContext())
        //    {
        //        var results = context.Database.SqlQuery<ClassOffering>("ClassOfferings_FindByCourse @courseid"
        //            , new SqlParameter("CourseID", courseid));
        //        return results.ToList();
        //    }
        //}

        public List<ClassOffering> ClassOffering_FindByCourse(string courseId)
        {
            using (var context = new StartedContext())
            {
                IEnumerable<ClassOffering> results =
                    context.Database.SqlQuery<ClassOffering>("CurrentClassOfferings_FindByCourse @CourseID"
                        , new SqlParameter("CourseID", courseId));
                return results.ToList();
            }
        }

        public List<CurrentClassOffering> CurrentClassOfferings_FindByCourse(string courseId)
        {
            using (var context = new StartedContext())
            {
                IEnumerable<CurrentClassOffering> results =
                    context.Database.SqlQuery<CurrentClassOffering>("CurrentClassOfferings_FindByCourse @CourseID"
                        , new SqlParameter("CourseID", courseId));
                return results.ToList();
            }
        }

        public ClassOffering CurrentOfferings_FindByCourse(int v)
        {
            throw new NotImplementedException();
        }

        public CurrentOffering CurrentOfferings_FindByCourse(string selectedValue)
        {
            throw new NotImplementedException();
        }
    }
}
