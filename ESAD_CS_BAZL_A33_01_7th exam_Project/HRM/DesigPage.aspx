<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true"
     CodeBehind="DesigPage.aspx.cs" Inherits="HRM.DesigPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <fieldset >
        <legend style="text-align:center"> Designation Information</legend>
        <table>
            <tr>
                <td>
                    <fieldset style="margin-left:100px;"  >
                        <legend>Insert Information</legend>
    <table>
        <tr>
            <td>Designation :</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                <asp:Label ID="lbMsg" runat="server" ></asp:Label>
            </td>
        </tr>
        </table>

                    </fieldset>
                </td>
                <td style="width:100px">

                </td>
                <td style="padding-top:50px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="DesId" HeaderText="Id" SortExpression="DesId"></asp:BoundField>
                        <asp:BoundField DataField="DesName" HeaderText="Designation" SortExpression="DesName"></asp:BoundField>
                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("DesId") %>' CommandName="Edt" Text="Edit">Edit</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("DesId") %>' CommandName="Del" Text="Delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Display" TypeName="HRM_DAL.DesigAccess" DeleteMethod="DeleteData">
                    <DeleteParameters>
                        <asp:Parameter Name="id" Type="Int32"/>
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </td>
            </tr>
        </table>
        <%--<tr>--%>
            
        <%--</tr>--%>
    <%--</table>--%>

    </fieldset>

</asp:Content>
