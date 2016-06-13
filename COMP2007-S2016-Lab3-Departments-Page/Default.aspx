<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="COMP2007_S2016_Lab3_Departments_Page.Default" %>
<%--
    Author Name : Jasim Khan
    student id : 200263011
    date : 13-06-16
    description : Default page to display simple text using jumbotron
      --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <bs3:Jumbotron runat="server" ID="Jumbotron1">
        <BodyContent>
            <h1>Welcome!</h1>
        </BodyContent>
    </bs3:Jumbotron>
</asp:Content>
