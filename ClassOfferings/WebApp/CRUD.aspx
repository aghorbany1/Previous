<%@ Page Title="Class Offerings A07" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="WebApp.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <h1>CRUD - StarTed</h1>
    </div>

     <div class="row col-md-12">
        <div class="alert alert-warning">
            <blockquote style="font-style: italic">
                This page will be used to demonstrate filter searches.Also, user can select a single item in the short list to edit.
            </blockquote>
        </div>
    </div>
                     
  <div class="row">   
        <div class="col-9">
            <asp:Label ID="Error" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="CoursePartialName:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="CoursePartialName" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchCourse" runat="server" Text="Search" OnClick="SearchCourse_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                       
            <asp:Label ID="Label5" runat="server" Text="Filtered Course List:"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList ID="ClassOfferingList" runat="server" Width="100px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ClassOffering" runat="server" Text="Class Offerings?" OnClick="ClassOffering_Click"/> &nbsp;&nbsp;

             <asp:DropDownList ID="OfferingList" runat="server" Width="150px"></asp:DropDownList>&nbsp;&nbsp;
             <asp:Button ID="SelectOffering" runat="server" Text="Select Offering" OnClick="SelectOffering_Click"/>  <br />  <br />
            <br /><br />
    </div>

      
            <asp:DataList ID="MessageList" runat="server">
                 <ItemTemplate>
                     <%# Container.DataItem %>
                 </ItemTemplate>
             </asp:DataList>

       <div class="col-md-10">
           <fieldset class="form-horizontal">
              <legend>Class Offerings Information</legend>

                <asp:Label ID="Label3" runat="server" Text="Class Offering ID:" AssociatedControlID="ClassID"></asp:Label>&nbsp;
               <asp:Label ID="ClassID" runat="server" Text=""></asp:Label>

                <asp:Label ID="Label7" runat="server" Text="Offering:" AssociatedControlID="OfferingList"></asp:Label>&nbsp;
                <asp:Label ID="OfferingID" runat="server" Text=""></asp:Label>

                <asp:Label ID="Label8" runat="server" Text="Section Code:" AssociatedControlID="SectionCode"></asp:Label>&nbsp;
                <asp:TextBox ID="SectionCode" runat="server"></asp:TextBox>

                <asp:Label ID="Label9" runat="server" Text="Employee:" AssociatedControlID="EmployeeLabel"></asp:Label>&nbsp;
                <asp:Label ID="EmployeeLabel" runat="server" Text=""></asp:Label>
                                
                <asp:Label ID="Label10" runat="server" Text="Room Number:" AssociatedControlID="RoomNumber"></asp:Label>&nbsp;
                <asp:TextBox ID="RoomNumber" runat="server"></asp:TextBox>

                <asp:Label ID="Label11" runat="server" Text="Cancelled:" AssociatedControlID="Cancelled"></asp:Label>&nbsp;
                <asp:CheckBox ID="Cancelled" runat="server" Text="."></asp:CheckBox> <br />
             </fieldset>
        </div>
        


    <div class="col-md-10"> 
             <asp:Label ID="Label2" runat="server" Text="Employee:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="EmployeeSearchTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchEmployee" runat="server" Text="Search" OnClick="SearchEmployee_Click"  />&nbsp;&nbsp;&nbsp;

            <asp:DropDownList ID="EmployeeDropDownList" runat="server" Width="100px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SelectEmployee" runat="server" Text="Select Employee" OnClick="SelectEmployee_Click"/><br/><br />
    </div>
              
        <div class="col-md-6"> 
             <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click"/>&nbsp;&nbsp;
             <asp:Button ID="AddClass" runat="server" Text="Add"/>&nbsp;&nbsp;
             <asp:Button ID="UdateClass" runat="server" Text="Update" ForeColor="Green"/>&nbsp;&nbsp;
            <asp:Button ID="DeleteClass" runat="server" Text="Delete" ForeColor="Red"/>
         </div>   

 
</div>
    <script src="../Scripts/bootwrap-freecode.js"></script>

</asp:Content>
