using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Started.Data.Entities;
using StartedSystem.DAL;
using System.Data.SqlClient;
using System.ComponentModel;
#endregion

namespace StartedSystem.BLL
{
    [DataObject]
    public class EmployeeController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Employee> Employee_List()
        {
            using (var context = new StartedContext())
            {
                return context.Employees.ToList();
            }
        }

        public Employee Employee_Get(int employeeid)
        {
            using (var context = new StartedContext())
            {
                return context.Employees.Find(employeeid);
            }
        }

        public List<Employee> Employees_List()
        {
            throw new NotImplementedException();
        }

        public List<Employee> Employees_FindByPartialName(string partialname)
        {
            using (var context = new StartedContext())
            {
                IEnumerable<Employee> results =
                    context.Database.SqlQuery<Employee>("Employees_FindByPartialName @partialname"
                        , new SqlParameter("partialname", partialname));
                return results.ToList();
            }
        }

        public List<Employee> Employees_FindByFullName(string employeeid)
        {
            using (var context = new StartedContext())
            {
                IEnumerable<Employee> results =
                    context.Database.SqlQuery<Employee>("Employees_FindByFullName @employeeid"
                        , new SqlParameter("employee", employeeid));
                return results.ToList();
            }
        }

        public List<Employee> EmployeeList_FindByName(string selectedValue)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Employee_FindById(string selectedValue)
        {
            throw new NotImplementedException();
        }
    }
}
