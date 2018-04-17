<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Prices.aspx.cs" Inherits="Admin_Prices" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: right">
        <div>
            יצרן</div>
        <div style="padding-bottom: 5px">
            <asp:DropDownList ID="DropDownListManufactorer" runat="server" Width="150px" 
                DataTextField="NAME" DataValueField="ID" 
                AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div>
            דגם</div>
        <div style="padding-bottom: 5px">
            <asp:DropDownList ID="DropDownListModel" runat="server" Width="150px" 
                AutoPostBack="True" DataTextField="NAME" 
                DataValueField="ID">
            </asp:DropDownList>
        </div>
        <div>
            שנת ייצור
        </div>
        <div style="padding-bottom: 5px">
            <asp:DropDownList ID="DropDownListYear" runat="server" AutoPostBack="True" 
                DataTextField="VALUE" DataValueField="ID">
            </asp:DropDownList>
        </div>
        <div>
            תת דגם</div>
        <div style="max-height: 300px; width: 600px; overflow-y: auto">
            <asp:Repeater ID="RepeaterPrices" runat="server">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAME") %>'></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.ID") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PRICE") %>'></asp:TextBox>
                            </td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="padding-bottom: 5px">
            <asp:Button ID="Button1" runat="server" Text="עדכן" onclick="Button1_Click" />
        </div>
    </div>
</asp:Content>

