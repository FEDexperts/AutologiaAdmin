<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>משתמש:</div>
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
        <div>סיסמה:</div>
        <div>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="כנס" onclick="Button1_Click" /></div>
        <div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
