<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="COMP2007_S2016_Lab3_Departments_Page.Departments" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
       <div class="row">
           <div class="col-md-offset-2 col-md-8">
               <h1>Departments List</h1>
               <a href="DepartmentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Departments</a>
               <div>
                   <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="DepartmentsGridView" AutoGenerateColumns="false">
                       <Columns>
                           <asp:BoundField DataField="DepartmentID" HeaderText="Departments ID" Visible="true" />
                           <asp:BoundField DataField="Name" HeaderText="Departments Name" Visible="true" />
                           <asp:BoundField DataField="Budget" HeaderText="Budget" Visible="true" />
                       </Columns>
                   </asp:GridView>
               </div>
           </div>
       </div>
   </div>
</asp:Content>
    