<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true"
     CodeBehind="TransferSet.aspx.cs" Inherits="HRM.TransferSet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="nav-justified">
        <tr>
            <td style="height: 42px; font-size: xx-large;" class="text-center" colspan="2">Employee Transfer Information</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">TransferID</td>
            <td class="auto-style5">
                <asp:TextBox ID="txttransferid" runat="server" BackColor="#CCCCCC" ReadOnly="True" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Emp ID</td>
            <td>
                <asp:DropDownList AppendDataBoundItems="true" ID="DRPemp" runat="server"  DataSourceID="SqlDataSource1" DataTextField="name"  DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">


                    <asp:ListItem Selected="True">Select Name</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrm %>" SelectCommand="SELECT [id], [name] FROM [emplyee]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">OldDepartment</td>
            <td>
                <asp:TextBox ID="txtolddept" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">NewDepartment</td>
            <td>
                <asp:DropDownList  ID="drp" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Display" TypeName="HRM_DAL.DeptAccess"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">OldDivision</td>
            <td>
                <asp:TextBox ID="txtolddiv" runat="server" Enabled="false"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td class="auto-style6">NewDivision</td>
            <td>
              <%--  <asp:TextBox ID="txtnewdev" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="newdiv"  runat="server" DataSourceID="ObjectDataSource3" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="Display" TypeName="HRM_DAL.DivisionAccess"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">OldSection</td>
            <td>
                <asp:TextBox ID="txtoldsec" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">NewSection</td>
            <td>
                <asp:DropDownList ID="drpsec" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Name" DataValueField="Id" ></asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="Display" TypeName="HRM_DAL.sceAccess"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">TransferActiveDate</td>
            <td>
                <asp:TextBox ID="txttransferactivedate" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncalender" OnClick="btncalender_Click" runat="server" Text="Set Date" Width="74px" />
                <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="43px" ShowGridLines="True" Visible="False" Width="220px" OnSelectionChanged="Calendar1_SelectionChanged">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">TransferDate</td>
            <td>
                <asp:TextBox ID="txtransferdate" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="btntransferdate" OnClick="btntransferdate_Click" runat="server" Text="Set Date" Width="74px" />
&nbsp;&nbsp;&nbsp;
                <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" OnSelectionChanged="Calendar2_SelectionChanged" Visible="False">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Remark</td>
            <td>
                <asp:TextBox ID="txtremark" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">StatusState</td>
            <td>
                <asp:TextBox ID="txtstatusstate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 37px">
                &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;
                <asp:Button ID="btnsaveall"  runat="server" Text="Save All" Height="32px" OnClick="btnsaveall_Click" Width="126px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 37px">
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:Hrm %>" DeleteCommand="DELETE FROM [Transfer_info] WHERE [TransferID] = @original_TransferID AND (([EmpID] = @original_EmpID) OR ([EmpID] IS NULL AND @original_EmpID IS NULL)) AND (([OldDepartment] = @original_OldDepartment) OR ([OldDepartment] IS NULL AND @original_OldDepartment IS NULL)) AND (([NewDepartment] = @original_NewDepartment) OR ([NewDepartment] IS NULL AND @original_NewDepartment IS NULL)) AND (([OldDivision] = @original_OldDivision) OR ([OldDivision] IS NULL AND @original_OldDivision IS NULL)) AND (([NewDivision] = @original_NewDivision) OR ([NewDivision] IS NULL AND @original_NewDivision IS NULL)) AND (([OldSection] = @original_OldSection) OR ([OldSection] IS NULL AND @original_OldSection IS NULL)) AND (([NewSection] = @original_NewSection) OR ([NewSection] IS NULL AND @original_NewSection IS NULL)) AND (([TransferActiveDate] = @original_TransferActiveDate) OR ([TransferActiveDate] IS NULL AND @original_TransferActiveDate IS NULL)) AND (([TransferDate] = @original_TransferDate) OR ([TransferDate] IS NULL AND @original_TransferDate IS NULL)) AND (([Remark] = @original_Remark) OR ([Remark] IS NULL AND @original_Remark IS NULL)) AND (([StatusState] = @original_StatusState) OR ([StatusState] IS NULL AND @original_StatusState IS NULL))" InsertCommand="INSERT INTO [Transfer_info] ([EmpID], [OldDepartment], [NewDepartment], [OldDivision], [NewDivision], [OldSection], [NewSection], [TransferActiveDate], [TransferDate], [Remark], [StatusState]) VALUES (@EmpID, @OldDepartment, @NewDepartment, @OldDivision, @NewDivision, @OldSection, @NewSection, @TransferActiveDate, @TransferDate, @Remark, @StatusState)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Transfer_info]" UpdateCommand="UPDATE [Transfer_info] SET [EmpID] = @EmpID, [OldDepartment] = @OldDepartment, [NewDepartment] = @NewDepartment, [OldDivision] = @OldDivision, [NewDivision] = @NewDivision, [OldSection] = @OldSection, [NewSection] = @NewSection, [TransferActiveDate] = @TransferActiveDate, [TransferDate] = @TransferDate, [Remark] = @Remark, [StatusState] = @StatusState WHERE [TransferID] = @original_TransferID AND (([EmpID] = @original_EmpID) OR ([EmpID] IS NULL AND @original_EmpID IS NULL)) AND (([OldDepartment] = @original_OldDepartment) OR ([OldDepartment] IS NULL AND @original_OldDepartment IS NULL)) AND (([NewDepartment] = @original_NewDepartment) OR ([NewDepartment] IS NULL AND @original_NewDepartment IS NULL)) AND (([OldDivision] = @original_OldDivision) OR ([OldDivision] IS NULL AND @original_OldDivision IS NULL)) AND (([NewDivision] = @original_NewDivision) OR ([NewDivision] IS NULL AND @original_NewDivision IS NULL)) AND (([OldSection] = @original_OldSection) OR ([OldSection] IS NULL AND @original_OldSection IS NULL)) AND (([NewSection] = @original_NewSection) OR ([NewSection] IS NULL AND @original_NewSection IS NULL)) AND (([TransferActiveDate] = @original_TransferActiveDate) OR ([TransferActiveDate] IS NULL AND @original_TransferActiveDate IS NULL)) AND (([TransferDate] = @original_TransferDate) OR ([TransferDate] IS NULL AND @original_TransferDate IS NULL)) AND (([Remark] = @original_Remark) OR ([Remark] IS NULL AND @original_Remark IS NULL)) AND (([StatusState] = @original_StatusState) OR ([StatusState] IS NULL AND @original_StatusState IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_TransferID" Type="Int32" />
                        <asp:Parameter Name="original_EmpID" Type="Int32" />
                        <asp:Parameter Name="original_OldDepartment" Type="String" />
                        <asp:Parameter Name="original_NewDepartment" Type="String" />
                        <asp:Parameter Name="original_OldDivision" Type="String" />
                        <asp:Parameter Name="original_NewDivision" Type="String" />
                        <asp:Parameter Name="original_OldSection" Type="String" />
                        <asp:Parameter Name="original_NewSection" Type="String" />
                        <asp:Parameter DbType="Date" Name="original_TransferActiveDate" />
                        <asp:Parameter DbType="Date" Name="original_TransferDate" />
                        <asp:Parameter Name="original_Remark" Type="String" />
                        <asp:Parameter Name="original_StatusState" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="EmpID" Type="Int32" />
                        <asp:Parameter Name="OldDepartment" Type="String" />
                        <asp:Parameter Name="NewDepartment" Type="String" />
                        <asp:Parameter Name="OldDivision" Type="String" />
                        <asp:Parameter Name="NewDivision" Type="String" />
                        <asp:Parameter Name="OldSection" Type="String" />
                        <asp:Parameter Name="NewSection" Type="String" />
                        <asp:Parameter DbType="Date" Name="TransferActiveDate" />
                        <asp:Parameter DbType="Date" Name="TransferDate" />
                        <asp:Parameter Name="Remark" Type="String" />
                        <asp:Parameter Name="StatusState" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="EmpID" Type="Int32" />
                        <asp:Parameter Name="OldDepartment" Type="String" />
                        <asp:Parameter Name="NewDepartment" Type="String" />
                        <asp:Parameter Name="OldDivision" Type="String" />
                        <asp:Parameter Name="NewDivision" Type="String" />
                        <asp:Parameter Name="OldSection" Type="String" />
                        <asp:Parameter Name="NewSection" Type="String" />
                        <asp:Parameter DbType="Date" Name="TransferActiveDate" />
                        <asp:Parameter DbType="Date" Name="TransferDate" />
                        <asp:Parameter Name="Remark" Type="String" />
                        <asp:Parameter Name="StatusState" Type="String" />
                        <asp:Parameter Name="original_TransferID" Type="Int32" />
                        <asp:Parameter Name="original_EmpID" Type="Int32" />
                        <asp:Parameter Name="original_OldDepartment" Type="String" />
                        <asp:Parameter Name="original_NewDepartment" Type="String" />
                        <asp:Parameter Name="original_OldDivision" Type="String" />
                        <asp:Parameter Name="original_NewDivision" Type="String" />
                        <asp:Parameter Name="original_OldSection" Type="String" />
                        <asp:Parameter Name="original_NewSection" Type="String" />
                        <asp:Parameter DbType="Date" Name="original_TransferActiveDate" />
                        <asp:Parameter DbType="Date" Name="original_TransferDate" />
                        <asp:Parameter Name="original_Remark" Type="String" />
                        <asp:Parameter Name="original_StatusState" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="TransferID" DataSourceID="SqlDataSource3" Width="1304px" Height="204px">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="Command" />
                        <asp:BoundField DataField="TransferID" HeaderText="Transfer ID" InsertVisible="False" ReadOnly="True" SortExpression="TransferID" />
                        <asp:BoundField DataField="EmpID" HeaderText="Emp ID" SortExpression="EmpID" />
                        <asp:BoundField DataField="OldDepartment" HeaderText="Old Department" SortExpression="OldDepartment" />
                        <asp:BoundField DataField="NewDepartment" HeaderText="New Department" SortExpression="NewDepartment" />
                        <asp:BoundField DataField="OldDivision" HeaderText="Old Division" SortExpression="OldDivision" />
                        <asp:BoundField DataField="NewDivision" HeaderText="New Division" SortExpression="NewDivision" />
                        <asp:BoundField DataField="OldSection" HeaderText="Old Section" SortExpression="OldSection" />
                        <asp:BoundField DataField="NewSection" HeaderText="New Section" SortExpression="NewSection" />
                        <asp:BoundField DataField="TransferActiveDate" HeaderText="Transfer Active Date" SortExpression="TransferActiveDate" />
                        <asp:BoundField DataField="TransferDate" HeaderText="Transfer Date" SortExpression="TransferDate" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
                        <asp:BoundField DataField="StatusState" HeaderText="Status State" SortExpression="StatusState" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            width: 91px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
        .auto-style6 {
            width: 91px;
        }
    </style>
</asp:Content>

