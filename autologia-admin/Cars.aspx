<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Cars.aspx.cs" Inherits="Admin.Cars" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="height: 100px;">
                <div class="right cars-filter">
                    <div>
                        סגנון ראשי</div>
                    <div>
                        <asp:DropDownList ID="DropDownListMainType" runat="server"
                            DataTextField="DESCRIPTION" DataValueField="ID" 
                            AutoPostBack="true" OnDataBound="DropDownListMainType_DataBound"
                            OnSelectedIndexChanged="MainTypeChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="right cars-filter">
                    <div>
                        סגנון משני</div>
                    <div>
                        <asp:DropDownList ID="DropDownListSubType" runat="server"
                            DataTextField="DESCRIPTION" DataValueField="ID" AutoPostBack="true" OnDataBound="DropDownListSubType_DataBound">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="right cars-filter">
                    <div>
                        יצרן</div>
                    <div>
                        <asp:DropDownList ID="DropDownListManufactorer" runat="server" DataTextField="NAME"
                            DataValueField="ID" AutoPostBack="true" OnDataBound="DropDownListManufactorer_DataBound"
                            OnSelectedIndexChanged="ManufactorerChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="right cars-filter">
                    <div>
                        דגם</div>
                    <div>
                        <asp:DropDownList ID="DropDownListModel" runat="server"
                            DataTextField="NAME" DataValueField="ID" AutoPostBack="true" 
                            OnDataBound="DropDownListModel_DataBound"
                            OnSelectedIndexChanged="ModelChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="right cars-filter">
                    <div>
                        תת דגם</div>
                    <div>
                        <asp:DropDownList ID="DropDownListSubModel" runat="server"
                            DataTextField="NAME" DataValueField="ID" AutoPostBack="true" OnDataBound="DropDownListSubModel_DataBound">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="right cars-filter">
                    <div>
                        שנתון</div>
                    <div>
                        <asp:DropDownList ID="DropDownListYear" runat="server" DataSourceID="ObjectDataSourceYear"
                            DataTextField="VALUE" DataValueField="ID" AutoPostBack="true" OnDataBound="DropDownListYear_DataBound">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSourceYear" runat="server" SelectMethod="GetLookupDetails"
                            TypeName="AutologiaDL.General" OnSelected="ObjectDataSourceYearSelected">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="id" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
                <br />
                <div class="right cars-filter">
                    <asp:Button ID="ButtonSearch" runat="server" Text="חפש" OnClick="Search" />
                </div>
            </div>
            <div style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4"
                    ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="5"
                    PagerSettings-Mode="NumericFirstLast" PagerStyle-CssClass="pager" OnDataBound="GridView1_DataBound"
                    OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanged="GridView1_PageIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="תמונה">
                            <ItemTemplate>
                                <asp:Image ID="CarImage" runat="server" Width="50px" Height="50px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>
            <div style="text-align: right; margin-top: 10px">
                <asp:Button ID="ButtonEdit" runat="server" Text="עריכה" OnClick="ButtonEdit_Click" />
                <asp:Button ID="ButtonDelete" runat="server" Text="מחק" OnClick="Button2_Click" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="ButtonDelete" ConfirmText="האם אתה בטוח?">
                </cc1:ConfirmButtonExtender>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>

<div style="overflow-y: auto; height: 600px">
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>

    <asp:GridView ID="GridView1" runat="server">
        <Columns>
            <asp:BoundField />
        </Columns>
    </asp:GridView>


    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th></th>
                    <th>מספר מזהה</th>
                    <th>יצרן</th>
                    <th>שנת ייצור</th>
                    <th>מודל ראשי</th>
                    <th>מודל משני</th>
                    <th>סגנון ראשי</th>
                    <th>סגנון משני</th>
                    <th>סוג תדלוק</th>
                    <th>תיבת הילוכים</th>
                    <th>מושבים</th>
                    <th>ריבוי נהגים</th>
                    <th>גודל נהג</th>
                    <th>תא מטען</th>
                    <th>תחזוקה</th>
                    <th>צריכת דלק</th>
                    <th>בטיחות</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Button ID="btnEdit" runat="server" Text="עריכה" OnCommand="Btn_Command" CommandName="Edit" CommandArgument='<%#Eval("ID")%>' />
                    <asp:Button ID="btnDelete" runat="server" Text="מחיקה" OnCommand="Btn_Command" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' />
                </td>
                <td><%#Eval("ID")%></td>
                <td><%#Eval("MANUFACTOR")%></td>
                <td><%#Eval("YEAR")%></td>
                <td><%#Eval("MODEL")%></td>
                <td><%#Eval("SUB_TYPE")%></td>
                <td><%#Eval("MAIN_TYPE")%></td>
                <td><%#Eval("SUB_TYPE")%></td>
                <td><%#Eval("FUEL_TYPE")%></td>
                <td><%#Eval("GEER")%></td>
                <td><%#Eval("SEATS")%></td>
                <td><%#Eval("MULTI_DRIVER")%></td>
                <td><%#Eval("SIZE")%></td>
                <td><%#Eval("TRUNK")%></td>
                <td><%#Eval("MAINTANANCE")%></td>
                <td><%#Eval("FUEL_CONSUME")%></td>
                <td><%#Eval("SECURE")%></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>

</asp:Content>
