<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarEditControl.ascx.cs"
    Inherits="UserControls_CarEditControl" %>
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>

<table>
    <tbody>
        <tr>
            <td style="vertical-align: top; width: 300px;">
                <div style="font-weight: bold">
                    יצרן
                </div>
                <div>
                    <asp:DropDownList ID="DropDownListManufactor" runat="server" Width="200px" DataTextField="NAME" DataValueField="ID"
                        AutoPostBack="True" OnSelectedIndexChanged="DropDownListManufactor_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div style="font-weight: bold">
                    דגם
                </div>
                <div>
                    <asp:DropDownList ID="DropDownListModel" runat="server" Width="200px" AutoPostBack="True" DataTextField="NAME" DataValueField="ID"
                        OnSelectedIndexChanged="DropDownListModel_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div style="font-weight: bold">
                    תת דגם
                </div>
                <div>
                    <asp:DropDownList ID="DropDownListSubModel" runat="server" Width="250px" DataTextField="NAME" DataValueField="ID">
                    </asp:DropDownList>
                </div>
                <div style="font-weight: bold">
                    ארץ ייצור
                </div>
                <div>
                    <asp:DropDownList ID="DropDownListCountry" runat="server" Width="200px" DataTextField="NAME" DataValueField="VALUE">
                    </asp:DropDownList>
                </div>
                <div style="font-weight: bold">
                    שנת ייצור
                </div>
                <div>
                    <asp:DropDownList ID="DropDownListYear" runat="server" Width="200px" DataTextField="NAME" DataValueField="VALUE">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="vertical-align: top; width: 300px;">
                <div style="font-weight: bold">
                    סגנון רכב ראשי
                </div>
                <div>
                    <asp:RadioButtonList ID="ddMainType" ClientIDMode="Static" runat="server" Width="200px" AutoPostBack="true" RepeatLayout="Flow"
                        OnSelectedIndexChanged="ddMainTypeChanged" DataTextField="NAME" DataValueField="ID" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
                <div style="font-weight: bold">
                    סגנון רכב משני
                </div>
                <div>
                    <asp:RadioButtonList ID="ddSubType" ClientIDMode="Static" runat="server" Width="200px" DataTextField="NAME" DataValueField="ID" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
                <div style="font-weight: bold">
                    סוג תידלוק
                </div>
                <div>
                    <asp:RadioButtonList ID="ddFeulType" runat="server" Width="200px" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
                <div>
                    <div style="font-weight: bold">
                        תיבת הילוכים
                    </div>
                    <div>
                        <asp:RadioButtonList ID="CheckBoxListGeer" runat="server" RepeatColumns="3">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="type1 type2 subType72">
                    <div style="font-weight: bold">
                        מס' מושבים
                    </div>
                    <div>
                        <asp:RadioButtonList ID="ddSeats" runat="server" Width="200px" RepeatColumns="3">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div>
                    <div style="font-weight: bold">
                        מחיר
                    </div>
                    <div>
                        <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="type1">
                    <div style="font-weight: bold">
                        גודל הרכב
                    </div>
                    <div>
                        <asp:RadioButtonList ID="DropDownListCarSize" runat="server" Width="200px" RepeatColumns="3">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="type1">
                    <div style="font-weight: bold">
                        התאמה תדמיתית
                    </div>
                    <div>
                        <asp:CheckBoxList ID="CheckBoxListPerception" runat="server" RepeatColumns="4"></asp:CheckBoxList>
                    </div>
                </div>
                <div class="type2">
                    <div style="font-weight: bold">
                        עבירות שטח
                    </div>
                    <div>
                        <asp:RadioButtonList ID="ddSurface" runat="server" RepeatColumns="3">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="subType6">
                    <div style="font-weight: bold">
                        סוג הנעה
                    </div>
                    <div>
                        <asp:RadioButtonList ID="ddIgnition" runat="server" RepeatColumns="3">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="type1 type2">
                    <div style="font-weight: bold">
                        גודל נהג
                    </div>
                    <div>
                        <asp:CheckBoxList ID="CheckBoxListDriverSize" runat="server" RepeatColumns="3"></asp:CheckBoxList>
                    </div>
                </div>
            </td>
            <td style="vertical-align: top; width: 300px;">
                <div style="font-weight: bold" class="type1">
                    התאמה לריבוי נהגים
                </div>
                <div>
                    <asp:RadioButtonList ID="DropDownListMultiDriver" runat="server" Width="200px" RepeatColumns="2">
                    </asp:RadioButtonList>
                </div>
                <div style="font-weight: bold" class="type1">
                    מס' דלתות
                </div>
                <div>
                    <asp:RadioButtonList ID="DropDownListDors" runat="server" Width="200px" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
                <div class="subType73">
                    <div style="font-weight: bold">
                        נפח תא מטען
                    </div>
                    <div>
                        <asp:RadioButtonList ID="DropDownListTrunkSize" runat="server" Width="200px" RepeatColumns="3">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div style="font-weight: bold">
                    רמת איבזור
                </div>
                <div>
                    <asp:RadioButtonList ID="DropDownListAccessoriesLevel" runat="server" Width="200px" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>

                <div style="font-weight: bold" class="type1 type2">
                    זריזות ותגובת הרכב
                </div>
                <div class="type1 type2">
                    <asp:RadioButtonList ID="DropDownListResponse" runat="server" Width="200px" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
                <div style="font-weight: bold">
                    רמת בטיחות
                </div>
                <div>
                    <asp:RadioButtonList ID="DropDownListSafety" runat="server" Width="200px" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
                <div style="font-weight: bold" class="type3">
                    מרחב ראייה
                </div>
                <div>
                    <asp:RadioButtonList ID="ddVisualPerspective" runat="server" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
                <div style="font-weight: bold">
                    עלות אחזקה
                </div>
                <div>
                    <asp:RadioButtonList ID="DropDownListMaintanance" runat="server" Width="200px" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
                <div style="font-weight: bold">
                    תצרוכת דלק
                </div>
                <div>
                    <asp:RadioButtonList ID="DropDownListFuelConsume" runat="server" Width="200px" RepeatColumns="3">
                    </asp:RadioButtonList>
                </div>
            </td>
            <td style="vertical-align: top; width: 300px;">
                <div style="font-weight: bold">
                    תאור
                </div>
                <div>
                    <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" Rows="6" Width="300px"></asp:TextBox>
                </div>
                <div style="font-weight: bold">
                    בעד
                </div>
                <div>
                    <asp:TextBox ID="TextBoxFor" runat="server" TextMode="MultiLine" Rows="2" Width="300px"></asp:TextBox>
                </div>
                <div style="font-weight: bold">
                    נגד
                </div>
                <div>
                    <asp:TextBox ID="TextBoxAgainst" runat="server" TextMode="MultiLine" Rows="2" Width="300px"></asp:TextBox>
                </div>
                <div style="font-weight: bold">
                    קישורים
                </div>
                <div>
                    <asp:TextBox ID="TextBoxLink" runat="server" TextMode="MultiLine" Rows="6" Width="300px"></asp:TextBox>
                </div>
            </td>
        </tr>
    </tbody>
</table>
