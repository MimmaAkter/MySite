<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true" 
    CodeBehind="DEpt.aspx.cs" Inherits="HRM.DEpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h3>Department Information</h3>
    <table>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand" >
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        
                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="e">Edit</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="d">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Display" TypeName="HRM_DAL.DeptAccess"></asp:ObjectDataSource>
            </td>
        </tr>       
    </table>
    <br />
    <br />
    <table border="1">
         <tr>
            <td>Name</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>            
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" Visible="false"/>
                <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                <asp:HiddenField ID="hdnID" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
