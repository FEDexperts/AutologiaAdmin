<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Manufactors.aspx.cs" Inherits="Admin_Manufactors" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register src="UserControls/FileUploadControl.ascx" tagname="FileUploadControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right" style="text-align: right">
        <fieldset class="ui-corner-all">
            <legend>יצרנים</legend>
            <div>
                <asp:ListBox ID="ListBoxManufactorers" runat="server" DataTextField="NAME" DataValueField="ID"
                    Width="100%" Height="160px" OnSelectedIndexChanged="ManufactorerSelected" AutoPostBack="true">
                </asp:ListBox>
                <asp:TextBox ID="TextBoxSelManufactorer" runat="server" Width="98%" BackColor="ActiveCaption"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="ButtonNewManufactorer" runat="server" Text="שמור" OnClick="NewManufactorer"
                    CssClass="Button" Enabled="true" />
                <asp:Button ID="ButtonUpdateManufatorer" runat="server" Text="עדכן" OnClick="UpdateManufactorer"
                    CssClass="Button" Enabled="true" />
                <asp:Button ID="ButtonDeleteManufacture" runat="server" Text="מחיקה" OnClick="DeleteManufactorer" OnClientClick="return DeleteConfirmation();"
                    CssClass="Button" Enabled="true" />
            </div>
        </fieldset>
    </div>
    <div class="right" style="text-align: right; margin-right: 10px;">
        <fieldset class="ui-corner-all">
            <legend>קישורים ב footer</legend>
            <div>
                <asp:TextBox ID="TextBoxManufactorLink" runat="server" Width="300px" style="direction: ltr" BackColor="ActiveCaption"></asp:TextBox>
            </div>
        </fieldset>
    </div>
    <div class="right" style="text-align: right; margin-right: 10px;">
        <fieldset class="ui-corner-all">
            <legend>תמונה</legend>
            <div>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" />
            </div>
            <div>
                <asp:Image ID="ImageManufactor" runat="server" Width="200px" Height="200px" Visible="false" />
            </div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="לא נמצאה תמונה" Visible="true" Font-Bold="true"
                    Font-Size="Large" ForeColor="ScrollBar"></asp:Label>
            </div>
        </fieldset>
    </div>
</asp:Content>

