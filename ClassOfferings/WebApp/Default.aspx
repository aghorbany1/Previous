<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       <h1>Arya Ghorbany</h1>
       <p class="lead">Project A07: Class Offerings</p>
    </div>

     <div class="row">
        <div class="col-md-4">
            <h2>CRUD</h2>
            <p>
               CRUD – Single item Create/Read/Update/Delete.
            </p>
            
        </div>
        <div class="col-md-6">
            <h2>Query</h2>
            <p>                
                Query – ObjectDataSource Search & Display with a GridView.
            </p>
           
        </div>
     
       
        <div class="col-md-10">
            <h2>Known Bugs:</h2>
            <p>
                So far No bugs
            </p>
        </div>

        <div class="col-md-10">
            <h2>Entity Relationship Diagram:</h2>
            <asp:HyperLink id="link" runat="server">
                <asp:Image ID="img" runat="server" imageurl="~/img/07.png" /> 
            </asp:HyperLink>
        </div>

         <div class="col-md-10">
            <h2>Class diagram file of Entities:</h2>
            <asp:HyperLink id="link2" runat="server">
                <asp:Image ID="img2" runat="server" imageurl="~/img/Diagram07.png" /> 
            </asp:HyperLink>
        </div>

          <div class="col-md-10">
            <h2>Class diagram file of Application:</h2>
            <asp:HyperLink id="HyperLink1" runat="server">
                <asp:Image ID="Image1" runat="server" imageurl="~/img/SystemDiagram.png" /> 
            </asp:HyperLink>
        </div>

           <div class="col-md-10">
            <h2>Stored Procedures:</h2>
            <ul>
                <li>Courses_FindByPartialName</li>
                <li>CurrentClassOfferings_FindByCourse</li>
                <li>CurrentOfferings_FindByCourse</li>
                <li>Employees_FindByPartialName </li>
            </ul>
        </div>
    </div>


</asp:Content>
