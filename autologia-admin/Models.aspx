<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Models.aspx.cs" Inherits="Admin_Models" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="UserControls/FileUploadControl.ascx" TagName="FileUploadControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right" style="margin: 5px; text-align: right;">
        <fieldset class="ui-corner-all">
            <legend>דגמים</legend>
            <div>
                יצרן</div>
            <div style="padding-bottom: 5px">
                <asp:DropDownList ID="DropDownListManufactor" runat="server" AutoPostBack="True"
                    OnDataBound="DropDownList1_DataBound" DataTextField="NAME" DataValueField="ID"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="150px">
                </asp:DropDownList>
            </div>
            <div>
                דגם</div>
            <div>
                <asp:ListBox ID="ListBoxModels" runat="server" DataTextField="NAME" DataValueField="ID"
                    Width="100%" Height="250px" OnSelectedIndexChanged="CarModelSelected" AutoPostBack="true">
                </asp:ListBox>
                <asp:TextBox ID="TextBoxCarModel" runat="server" Width="98%" BackColor="ActiveCaption"></asp:TextBox>
            </div>
            <div style="padding-bottom: 5px">
                <asp:Button ID="ButtonUpdateCarModel" runat="server" Text="עדכן" OnClick="UpdateCarModel"
                    CssClass="Button" />
                <asp:Button ID="ButtonNewCarModel" runat="server" Text="שמור" OnClick="AddCarModel"
                    CssClass="Button" />
                <asp:Button ID="ButtonDeleteCarModel" runat="server" Text="מחק" OnClick="DeleteCarModel" OnClientClick="return DeleteConfirmation();"
                    CssClass="Button" />
            </div>
        </fieldset>
    </div>
    <div class="right" style="margin: 5px; text-align: right;">
        <fieldset class="ui-corner-all">
            <legend>תתי דגמים</legend>
            <div>
                <asp:ListBox ID="ListBoxCarSubModels" runat="server" DataTextField="NAME" DataValueField="ID"
                    Width="100%" Height="195px" OnSelectedIndexChanged="CarSubModelSelected" AutoPostBack="true">
                </asp:ListBox>
                <asp:TextBox ID="TextBoxCarSubModel" runat="server" Width="98%" BackColor="ActiveCaption"></asp:TextBox>
            </div>
            <br />
            <div>
                תמונה קטנה</div>
            <div>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
            <div>
                תמונה גדולה</div>
            <div>
                <asp:FileUpload ID="FileUpload2" runat="server" />
            </div>
            <br />
            <div style="padding-bottom: 5px">
                <asp:Button ID="ButtonUpdateSubModel" runat="server" Text="עדכן" OnClick="UpdateSubModel"
                    CssClass="Button" />
                <asp:Button ID="ButtonNewSubModel" runat="server" Text="שמור" OnClick="AddSubModel"
                    CssClass="Button" />
                <asp:Button ID="ButtonDelete" runat="server" Text="מחק" OnClick="DeleteSubModel" OnClientClick="return DeleteConfirmation();"
                    CssClass="Button" />
            </div>
        </fieldset>
    </div>
    <div class="left" style="text-align: right; margin: 20px; height: 300px;">
        <div>
            <asp:Label ID="Label1" runat="server" Text="לא נמצאה תמונה" Visible="false" Font-Bold="true"
                Font-Size="Large" ForeColor="ScrollBar"></asp:Label>
        </div>
        <div>
            <asp:Image ID="SmallCarImage" runat="server" Visible="false" Width="124px" Height="65px" />
        </div>
        <div>
            <asp:Image ID="BigCarImage" runat="server" Visible="false" Width="350px" Height="200px" />
        </div>
    </div>
</asp:Content>
