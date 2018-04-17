<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CarEdit.aspx.cs" Inherits="Admin.AdminCarEdit" %>

<%@ Register Src="~/UserControls/CarEditControl.ascx" TagName="CarEditControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="text-align: right;">
        <uc1:CarEditControl ID="CarEditControl1" runat="server" EditType="EtModify" />
    </div>
    <div>
        <asp:Button ID="Button3" runat="server" Text="אישור" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="חזרה" OnClick="Button4_Click" />
    </div>
</asp:Content>
