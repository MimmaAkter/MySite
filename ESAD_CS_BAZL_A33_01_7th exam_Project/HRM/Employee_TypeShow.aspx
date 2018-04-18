<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true" 
    CodeBehind="Employee_TypeShow.aspx.cs" 
    Inherits="HRM.Employee_TypeShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <table class="nav-justified">
       
    <tr>
        <td class="auto-style4" colspan="2">Employee Type Modification</td>
    </tr>
       
    <tr>
        <td style="width: 230px; height: 53px" class="text-center">Employee Type</td>
        <td style="height: 53px">
            <asp:TextBox ID="TextBox1" runat="server" Height="26px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp<asp:Button ID="Button1" runat="server" Height="32px" OnClick="Button1_Click" Text="Save" Width="68px" />

             </td>
    </tr>
</table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeType_ID" DataSourceID="SqlDataSource2" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" >
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="EmployeeType_ID" HeaderText="EmployeeType_ID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeType_ID" />
            <asp:BoundField DataField="Employee_Types" HeaderText="Employee_Types" SortExpression="Employee_Types" />
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
   <%-- <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CreateEmployeTypeConnectionString %>" DeleteCommand="DELETE FROM [Employee_Type] WHERE [EmployeeType_ID] = @EmployeeType_ID" InsertCommand="INSERT INTO [Employee_Type] ([Employee_Types]) VALUES (@Employee_Types)" SelectCommand="SELECT * FROM [Employee_Type]" UpdateCommand="UPDATE [Employee_Type] SET [Employee_Types] = @Employee_Types WHERE [EmployeeType_ID] = @EmployeeType_ID">--%>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
         ConnectionString="<%$ ConnectionStrings:hrm %>" DeleteCommand="DELETE FROM [Employee_Type] WHERE [EmployeeType_ID] = @EmployeeType_ID" InsertCommand="INSERT INTO [Employee_Type] ([Employee_Types]) VALUES (@Employee_Types)" SelectCommand="SELECT * FROM [Employee_Type]" UpdateCommand="UPDATE [Employee_Type] SET [Employee_Types] = @Employee_Types WHERE [EmployeeType_ID] = @EmployeeType_ID">
        <DeleteParameters>
            <asp:Parameter Name="EmployeeType_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Employee_Types" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Employee_Types" Type="String" />
            <asp:Parameter Name="EmployeeType_ID" Type="Int32" />
        </UpdateParameters>
</asp:SqlDataSource>
    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
            font-size: xx-large;
            color: #993300;
            height: 64px;
        }
    </style>
</asp:Content>

