using Started.Data.Entities;
using StartedSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Query : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
        }

  

        protected Exception GetInnerException(Exception ex)
        {
            
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        //protected void SearchCourse_Click(object sender, EventArgs e)
        //{
        //    //validation that a choice was made
        //        if (ClassOfferingView.SelectedIndex == 0)
        //    {
        //        Message.Text = "Select a course Name to view class offering";
        //    }
        //    try
        //    {
        //        ClassOfferingController sysmgr = new ClassOfferingController();
        //        List<ClassOffering> info = null;
        //        info = sysmgr.ClassOfferings_FindByCourse(ClassOfferingView.SelectedValue);
        //        SearchCourseName.DataSource = info;

        //        SearchCourseName.DataBind();


        //    }
        //    catch (Exception ex)
        //    {
        //        Message.Text = ex.Message;
        //    }
        //}

        //protected void FetchEmployeeDetail_Click(object sender, EventArgs e)
        //{
        //    //validation that a choice was made
        //    if (ClassOfferingView.SelectedIndex == 0)
        //    {
        //        Message.Text = "Select a Employee Name to view the Detail";
        //    }
        //    try
        //    {
        //        EmployeeController sysmgr = new EmployeeController();
        //        List<Employee> info = null;
        //        info = sysmgr.EmployeeList_FindByName(EmployeeList.SelectedValue);
        //        EmployeeList.DataSource = info;

        //        EmployeeList.DataBind();


        //    }
        //    catch (Exception ex)
        //    {
        //        Message.Text = ex.Message;
        //    }
        //}
    }
}