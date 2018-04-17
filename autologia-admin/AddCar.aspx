<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AddCar.aspx.cs" Inherits="Admin_AddCar" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register src="~/UserControls/CarEditControl.ascx" tagname="CarEditControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="" CssClass="errorMessage"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="" CssClass="errorMessage"></asp:Label>
    </div>
    <div style="text-align: right;">
        <uc1:CarEditControl ID="CarEditControl1" runat="server" EditType="EtNew" />
    </div>
    <div style="float: right;">
        <asp:Button ID="Button1" runat="server" Text="הוסף" OnClick="Button1_Click" />
    </div>
</asp:Content>
