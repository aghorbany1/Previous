<%@ Page Title="Class Offerings A07" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="WebApp.Query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <h1>ODS - StarTED</h1>
    </div>

     <div class="row col-md-12">
        <div class="alert alert-warning">
            <blockquote style="font-style: italic">
                This page will be used to demonstrate filter searches. It will
                be used to demonstrate the use of the GridView control in
                filter searchs. The GridView will show custom columns
                and formatting. The code behind will demonstrate accessing columns
                on the GridView
            </blockquote>
        </div>
    </div>

      <div class="row">
        <div class="col-md-10">
            <asp:Label ID="Label1" runat="server" Text="Search Course by Partial Name:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="CoursePartialName" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="SearchCourseByPartialName" runat="server" Text="Search Courses"/>
        </div>
    </div>
    <br /> 
    <div class="row">
        <div class="col-md-8">
            <asp:Label ID="Label3" runat="server" Text="Select a Course:"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList ID="SearchCourseName" runat="server" width="100px" DataSourceID="ObjectDataSource1" DataTextField="CourseName" DataValueField="CourseID" ></asp:DropDownList>&nbsp;&nbsp;
            <asp:Button ID="SearchCourse" runat="server" Text="Search" />
        </div>
    </div>
    <br />
     <%--<asp:Label ID="Label6" runat="server" Text="Class ID:" AssociatedControlID="ClassOfferingID"></asp:Label>&nbsp;
                <asp:TextBox ID="ClassOfferingID" runat="server" ReadOnly="true" Width="60px"></asp:TextBox>--%>

        <br /><br />

    <asp:Label ID="Message" runat="server" Text=""></asp:Label>

     <%-- <asp:Label ID="Label9" runat="server" Text="Class Offering Details:"></asp:Label>&nbsp;--%>
      &nbsp;&nbsp;
   
    <br /><br />
         <div class="col-md-12">
            <asp:GridView ID="ClassOfferingView" runat="server" 
                CssClass="table" GridLines="Horizontal" BorderStyle="None"
                AutoGenerateColumns="False"
           
            DataSourceID="ClassOfferingViewODS" AllowPaging="True" PageSize="5"
             >

                <Columns>
                 

                   <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="ClassOfferingID" runat="server" 
                            Text='<%# Eval("ClassOfferingID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="OfferingID">
                         <ItemTemplate>
                        <asp:Label ID="OfferingID" runat="server" 
                            Text='<%# Eval("OfferingID") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="SectionCode">
                    <ItemTemplate>
                        <asp:Label ID="SectionCode" runat="server" 
                            Text='<%# Eval("SectionCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                     <asp:TemplateField HeaderText="EmployeeID">
                         <ItemTemplate>
                             <asp:Label ID="EmployeeID" runat="server"
                                 Text='<%# Eval("EmployeeID") %>'></asp:Label>
                         </ItemTemplate>
                </asp:TemplateField>

<%--                   <asp:TemplateField HeaderText="Employee">
                    <ItemTemplate>
                        <asp:DropDownList ID="EmployeeList" runat="server" 
                            DataSourceID="EmployeeListODS" 
                            DataTextField="FullName" 
                            DataValueField="EmployeeID"
                             Enabled="false"
                             selectedvalue='<%# Eval("EmployeeID") %>'>

                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>--%>

                   <asp:TemplateField HeaderText="RoomNumber">
                    <ItemTemplate>
                        <asp:Label ID="RoomNumber" runat="server" 
                            Text='<%# Eval("RoomNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                         <asp:TemplateField HeaderText="Cancelled">
                    <ItemTemplate>
                         <asp:CheckBox ID="Cancelled" runat="server"
                             Checked='<%# Eval("Cancelled") %>' 
                             Enabled="false"/>
                    </ItemTemplate>
                </asp:TemplateField>
               

                </Columns>
                <EmptyDataTemplate>
                    No data to display at this time
                </EmptyDataTemplate>

            </asp:GridView>
             
 

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Courses_FindByPartialName" TypeName="StartedSystem.BLL.CourseController">
        <SelectParameters>
            <asp:ControlParameter ControlID="CoursePartialName" PropertyName="Text" DefaultValue="gfhythyehththrthrthrtyh" Name="partialname" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

   

             <asp:ObjectDataSource ID="ClassOfferingViewODS" runat="server" OldValuesParameterFormatString="original_{0}" 
                 SelectMethod="ClassingOfferings_FindByCourse" TypeName="StartedSystem.BLL.ClassOfferingController">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="SearchCourseName" PropertyName="SelectedValue" DefaultValue="0" 
                         Name="courseid" Type="String"></asp:ControlParameter>
                 </SelectParameters>
             </asp:ObjectDataSource>


              <asp:ObjectDataSource ID="EmployeeListODS" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="Employees_FindByPartialName" TypeName="StartedSystem.BLL.EmployeeController" SelectCountMethod="Employee_FindPartialName" 
        ></asp:ObjectDataSource>

     <script src="../Scripts/bootwrap-freecode.js"></script>

  </div>
</asp:Content>
