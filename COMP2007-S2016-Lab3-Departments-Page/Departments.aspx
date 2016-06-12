﻿<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="COMP2007_S2016_Lab3_Departments_Page.Departments" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
       <div class="row">
           <div class="col-md-offset-2 col-md-8">
               <h1>Departments List</h1>
               <a href="DepartmentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Departments</a>
              <div>
                  <label for="PageSizeDropDownList"> Records Per Page: </label>
                <asp:DropDownList ID="PageSizeDropDownList" runat="server"
                     AutoPostBack="true" CssClass="btn btn-default btn-sm dropdown-toggle"
                     OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged">
                   <asp:ListItem Text="3" Value="3"></asp:ListItem>
                   <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="All" Value="1000"></asp:ListItem>
               </asp:DropDownList>
                  </div>
               <div>
                   <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="DepartmentsGridView" 
                       AutoGenerateColumns="false" DataKeyNames="DepartmentID" OnRowDeleting="DepartmentsGridView_RowDeleting"
                        AllowPaging="true" PageSize="3" OnPageIndexChanging="DepartmentsGridView_PageIndexChanging"
                        >
                       <Columns>
                           <asp:BoundField DataField="DepartmentID" HeaderText="Departments ID" Visible="true" />
                           <asp:BoundField DataField="Name" HeaderText="Departments Name" Visible="true" />
                           <asp:BoundField DataField="Budget" HeaderText="Budget" Visible="true" />
                           <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'/>Delete"
                              ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                       </Columns>
                   </asp:GridView>
               </div>
           </div>
       </div>
   </div>
</asp:Content>
    