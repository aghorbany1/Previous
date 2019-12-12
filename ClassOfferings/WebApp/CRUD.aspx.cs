
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional namespaces
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Started.Data.Entities;
using StartedSystem.BLL;
#endregion

namespace WebApp
{
    public partial class CRUD : System.Web.UI.Page
    {
       List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            MessageList.DataSource = null;
            MessageList.DataBind();

            if(!Page.IsPostBack)
            {

                BindClassOfferingList();
               // BindEmployeeList();
            }
        }


        protected Exception GetInnerException(Exception ex)
        {
           
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            MessageList.CssClass = cssclass;
            MessageList.DataSource = errormsglist;
            MessageList.DataBind();
        }

        //  *******ClassOffering BIND ****
        protected void BindClassOfferingList()
        {
            try
            {
                ClassOfferingController sysmgr = new ClassOfferingController();

                List<ClassOffering> info = null;
                info = sysmgr.ClassOffering_List();

                ClassOfferingList.DataSource = info;
                ClassOfferingList.DataTextField = nameof(Course.CourseName); 
                ClassOfferingList.DataValueField = nameof(Course.CourseID); 
                ClassOfferingList.DataBind();
                ClassOfferingList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                //using the specialized error handling DataList control
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            //catch (DbUpdateException ex)
            //{
            //    UpdateException updateException = (UpdateException)ex.InnerException;
            //    if (updateException.InnerException != null)
            //    {
            //        errormsgs.Add(updateException.InnerException.Message.ToString());
            //    }
            //    else
            //    {
            //        errormsgs.Add(updateException.Message);
            //    }
            //    LoadMessageDisplay(errormsgs, "alert alert-danger");
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (var entityValidationErrors in ex.EntityValidationErrors)
            //    {
            //        foreach (var validationError in entityValidationErrors.ValidationErrors)
            //        {
            //            errormsgs.Add(validationError.ErrorMessage);
            //        }
            //    }
            //    LoadMessageDisplay(errormsgs, "alert alert-danger");
            //}
            //catch (Exception ex)
            //{
            //    //errormsgs.Add(GetInnerException(ex).ToString());
            //    LoadMessageDisplay(errormsgs, "alert alert-danger");
            //}

        }

        //*******Employee BIND********
        protected void BindEmployeeList()
        {

            try
            {
                EmployeeController sysmgr = new EmployeeController();

                List<Employee> info = null;
                info = sysmgr.Employee_List();

                EmployeeDropDownList.DataSource = info;
                EmployeeDropDownList.DataTextField = nameof(Employee.FullName);
                EmployeeDropDownList.DataValueField = nameof(Employee.EmployeeID);
                EmployeeDropDownList.DataBind();
                EmployeeDropDownList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                //using the specialized error handling DataList control
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }         
        }

        //******Offering Bind *****
       
        protected void BindOfferingList()
        {
            try
            {
                ClassOfferingController sysmgr = new ClassOfferingController();

                List<ClassOffering> info = null;
                info = sysmgr.ClassOffering_List();

                OfferingList.DataSource = info;
                OfferingList.DataTextField = nameof(Course.CourseName);
                OfferingList.DataValueField = nameof(Course.CourseID);
                OfferingList.DataBind();
                OfferingList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                //using the specialized error handling DataList control
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            //catch (DbUpdateException ex)
            //{
            //    UpdateException updateException = (UpdateException)ex.InnerException;
            //    if (updateException.InnerException != null)
            //    {
            //        errormsgs.Add(updateException.InnerException.Message.ToString());
            //    }
            //    else
            //    {
            //        errormsgs.Add(updateException.Message);
            //    }
            //    LoadMessageDisplay(errormsgs, "alert alert-danger");
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (var entityValidationErrors in ex.EntityValidationErrors)
            //    {
            //        foreach (var validationError in entityValidationErrors.ValidationErrors)
            //        {
            //            errormsgs.Add(validationError.ErrorMessage);
            //        }
            //    }
            //    LoadMessageDisplay(errormsgs, "alert alert-danger");
            //}
            //catch (Exception ex)
            //{
            //    //errormsgs.Add(GetInnerException(ex).ToString());
            //    LoadMessageDisplay(errormsgs, "alert alert-danger");
            //}
        }

        //**** Button_Click
        protected void SearchCourse_Click(object sender, EventArgs e)
            {

            CourseController sysmgr = new CourseController();
            List<Course> info = sysmgr.Courses_FindByPartialName(CoursePartialName.Text);

            if (info.Count == 0)
            {
                errormsgs.Add("Course name not found");
                LoadMessageDisplay(errormsgs, "alret alret-info");

                BindClassOfferingList();
            }
            else
            {
                ClassOfferingList.DataSource = info;
                ClassOfferingList.DataBind();
                ClassOfferingList.DataSource = info;
                ClassOfferingList.DataTextField = nameof(Course.CourseName);
                ClassOfferingList.DataValueField = nameof(Course.CourseID);
                ClassOfferingList.DataBind();
                ClassOfferingList.Items.Insert(0, "select....");
            }
        }

        protected void ClassOffering_Click(object sender, EventArgs e)
        {

            
            if (ClassOfferingList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a Class");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            //if (string.IsNullOrEmpty(ClassOfferingList.Text))
            //{
            //    errormsgs.Add("Select Program, Course and Semester");
            //    LoadMessageDisplay(errormsgs, "alert alert-warning");
            //}
            else
            {
                try
                {
                    ClassOfferingController sysmgr = new ClassOfferingController();
                    List<CurrentClassOffering> info = sysmgr.CurrentClassOfferings_FindByCourse(ClassOfferingList.SelectedValue);

                    if (info == null)
                    {
                        errormsgs.Add("Class not found");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                        BindOfferingList();
                    }
                    else
                    {

                        //OfferingList.DataSource = info;
                        //OfferingList.DataBind();
                        //OfferingList.DataSource = info;
                        //OfferingList.DataTextField = nameof(Course.CourseName);
                        //OfferingList.DataValueField = nameof(Course.CourseID);
                        //OfferingList.DataBind();
                        //OfferingList.Items.Insert(0, "select....");

                        ClassID.Text = info.First().ClassOfferingID.ToString();
                        //OfferingList.SelectedValue = info.OfferingID.ToString();
                        SectionCode.Text = info.First().SectionCode.ToString();
                        //EmployeeDropDownList.SelectedValue = info.EmployeeID.ToString();
                        RoomNumber.Text = info.First().RoomNumber.ToString();
                        Cancelled.Checked = info.First().Cancelled;
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                //catch (DbUpdateException ex)
                //{
                //    UpdateException updateException = (UpdateException)ex.InnerException;
                //    if (updateException.InnerException != null)
                //    {
                //        errormsgs.Add(updateException.InnerException.Message.ToString());
                //    }
                //    else
                //    {
                //        errormsgs.Add(updateException.Message);
                //    }
                //    LoadMessageDisplay(errormsgs, "alert alert-danger");
                //}
                //catch (DbEntityValidationException ex)
                //{
                //    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                //    {
                //        foreach (var validationError in entityValidationErrors.ValidationErrors)
                //        {
                //            errormsgs.Add(validationError.ErrorMessage);
                //        }
                //    }
                //    LoadMessageDisplay(errormsgs, "alert alert-danger");
                //}
                //catch (Exception ex)
                //{
                //    errormsgs.Add(GetInnerException(ex).ToString());
                //    LoadMessageDisplay(errormsgs, "alert alert-danger");
                //}
            }
        }

        protected void SearchEmployee_Click(object sender, EventArgs e)
        {
            EmployeeController sysmgr = new EmployeeController();
            List<Employee> info = sysmgr.Employees_FindByPartialName(EmployeeSearchTextBox.Text);

            if (info.Count == 0)
            {
                errormsgs.Add("Employee name not found");
                LoadMessageDisplay(errormsgs, "alret alret-info");

                BindEmployeeList();
                BindClassOfferingList();
            }
            else
            {
                EmployeeDropDownList.DataSource = info;
                EmployeeDropDownList.DataBind();
                EmployeeDropDownList.DataSource = info;
                EmployeeDropDownList.DataTextField = nameof(Employee.FirstName);
                EmployeeDropDownList.DataValueField = nameof(Employee.LastName);
                EmployeeDropDownList.DataBind();
                EmployeeDropDownList.Items.Insert(0, "select....");
            }
        }

        protected void SelectEmployee_Click(object sender, EventArgs e)
        {
            {
                if (EmployeeDropDownList.SelectedIndex == 0)
                {
                    errormsgs.Add("Select a Course to obtain class offering.");
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                    EmployeeDropDownList.DataSource = null;
                    EmployeeDropDownList.DataBind();

                }
                else
                {
                    try
                    {
                        EmployeeController sysmgr = new EmployeeController();

                        List<Employee> info = null;
                        info = sysmgr.Employee_FindById(EmployeeDropDownList.SelectedValue);

                        //EmployeeLabel.DataBind();
                        EmployeeDropDownList.SelectedValue = info.First().EmployeeID.ToString();

                    }
                    catch (Exception ex)
                    {
                        Error.Text = ex.Message;
                    }
                }
            }
        }


        protected void Offerings_Click(object sender, EventArgs e)
        {
            if (ClassOfferingList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a Class");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            if (string.IsNullOrEmpty(ClassOfferingList.Text))
            {
                errormsgs.Add("Select Program, Course and Semester");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
            else
            {
                try
                {
                    ClassOfferingController sysmgr = new ClassOfferingController();
                    ClassOffering info = sysmgr.CurrentOfferings_FindByCourse(int.Parse(ClassOfferingList.SelectedValue));

                    if (info == null)
                    {
                        errormsgs.Add("Class not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }
                    else
                    {

                        BindClassOfferingList();

                        //ClassID.Text = info.ClassOfferingID.ToString();
                        //OfferingList.SelectedValue = info.OfferingID.ToString();
                        //SectionCode.Text = info.SectionCode.ToString();
                        //EmployeeDropDownList.SelectedValue = info.EmployeeID.ToString();
                        //RoomNumber.Text = info.RoomNumber.ToString();
                        //Cancelled.Checked = info.Cancelled;
                    }
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void SelectOffering_Click(object sender, EventArgs e)
        {

            if (ClassOfferingList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a Class");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            //if (string.IsNullOrEmpty(ClassOfferingList.Text))
            //{
            //    errormsgs.Add("Select Program, Course and Semester");
            //    LoadMessageDisplay(errormsgs, "alert alert-warning");
            //}
            else
            {
                try
                {
                    ClassOfferingController sysmgr = new ClassOfferingController();
                    List<CurrentOffering> info = null; sysmgr.CurrentOfferings_FindByCourse(OfferingList.SelectedValue);

                    if (info == null)
                    {
                        errormsgs.Add("Class not found");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                        BindOfferingList();
                    }
                    else
                    {
                       // ClassID.Text = info.First().ClassOfferingID.ToString();
                        OfferingID.Text = info.First().OfferingID.ToString();
                       // SectionCode.Text = info.First().SectionCode.ToString();
                        //EmployeeDropDownList.SelectedValue = info.EmployeeID.ToString();
                       // RoomNumber.Text = info.First().RoomNumber.ToString();
                       // Cancelled.Checked = info.First().Cancelled;
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                //catch (DbUpdateException ex)
                //{
                //    UpdateException updateException = (UpdateException)ex.InnerException;
                //    if (updateException.InnerException != null)
                //    {
                //        errormsgs.Add(updateException.InnerException.Message.ToString());
                //    }
                //    else
                //    {
                //        errormsgs.Add(updateException.Message);
                //    }
                //    LoadMessageDisplay(errormsgs, "alert alert-danger");
                //}
                //catch (DbEntityValidationException ex)
                //{
                //    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                //    {
                //        foreach (var validationError in entityValidationErrors.ValidationErrors)
                //        {
                //            errormsgs.Add(validationError.ErrorMessage);
                //        }
                //    }
                //    LoadMessageDisplay(errormsgs, "alert alert-danger");
                //}
                //catch (Exception ex)
                //{
                //    errormsgs.Add(GetInnerException(ex).ToString());
                //    LoadMessageDisplay(errormsgs, "alert alert-danger");
                //}
            }
        }

        // *** CLEAR ****
        protected void Clear_Click(object sender, EventArgs e)
        {
            CoursePartialName.Text = "";
            ClassID.Text = "";
            OfferingID.Text = "";
            SectionCode.Text = "";
            EmployeeLabel.Text = "";
            RoomNumber.Text = "";
            EmployeeSearchTextBox.Text = "";
            ClassOfferingList.SelectedIndex = 0;
            OfferingList.SelectedIndex = 0;
           // EmployeeDropDownList.SelectedIndex = 0;
            Cancelled.Checked = false;
        }

        //*** UPDATE ****
        protected void UpdateClass_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (string.IsNullOrEmpty(ClassID.Text))
                {
                    errormsgs.Add("Look up the customer to be updated");
                }
                if(OfferingList.SelectedIndex == 0)
                {
                    errormsgs.Add("Select Offering");
                }
                if (EmployeeDropDownList.SelectedIndex == 0)
                {
                    errormsgs.Add("Select Employee");
                }
                if (errormsgs.Count() > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        ClassOffering item = new ClassOffering();

                        item.ClassOfferingID = int.Parse(ClassID.Text);
                        item.OfferingID = int.Parse(OfferingList.SelectedValue);
                        item.SectionCode = string.IsNullOrEmpty(SectionCode.Text) ? null : SectionCode.Text;
                        item.EmployeeID = int.Parse(EmployeeDropDownList.SelectedValue);
                        item.RoomNumber = string.IsNullOrEmpty(RoomNumber.Text) ? null : RoomNumber.Text;
                        item.Cancelled = false;

                        ClassOfferingController sysmgr = new ClassOfferingController();

                        int rowaffected = sysmgr.ClassOffering_Update(item);

                        if (rowaffected == 0)
                        {
                            errormsgs.Add("Class no longer on file. Update not done");
                            LoadMessageDisplay(errormsgs, "alert alert-warning");
                        }
                        else
                        {
                            errormsgs.Add("Class Updated");
                            LoadMessageDisplay(errormsgs, "alert alert-success");
                        }
                        BindClassOfferingList();
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }
        
        // *** DELETE ****
        protected void DeleteClass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ClassID.Text))
            {
                errormsgs.Add("Look up the class to be cancelled");
            }
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    ClassOfferingController sysmgr = new ClassOfferingController();
                    int rowaffected = sysmgr.ClassOffering_Delete(int.Parse(ClassID.Text));

                    if (rowaffected == 0)
                    {
                        errormsgs.Add("Class no longer on file.");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }
                    else
                    {
                        errormsgs.Add("Class is cancelled");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        Cancelled.Checked = true;
                    }
                    BindClassOfferingList();
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        //*** ADD *****
        protected void AddClass_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                if(string.IsNullOrEmpty(OfferingList.Text))
                {
                   errormsgs.Add("Look up the class to be added");
                }
                OfferingList.Items.Insert(0, "select...");

                if (OfferingList.SelectedIndex == 0)
                {
                    errormsgs.Add("Look up the class to be added");
                }

                if (EmployeeDropDownList.SelectedIndex == 0)
                {
                    errormsgs.Add("Select Employee");
                }
                if (errormsgs.Count() > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        ClassOffering item = new ClassOffering();

                        item.OfferingID = int.Parse(OfferingList.SelectedValue);
                        item.SectionCode = string.IsNullOrEmpty(SectionCode.Text) ? null : SectionCode.Text;
                        item.EmployeeID = int.Parse(EmployeeDropDownList.SelectedValue);
                        item.RoomNumber = string.IsNullOrEmpty(RoomNumber.Text) ? null : RoomNumber.Text;
                        item.Cancelled = false;

                        ClassOfferingController sysmgr = new ClassOfferingController();
                        int newpk = sysmgr.ClassOffering_Add(item);

                        ClassID.Text = newpk.ToString();

                        BindClassOfferingList();
                        errormsgs.Add("Class has been added");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }
    }
}
