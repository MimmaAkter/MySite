<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true"
     CodeBehind="section.aspx.cs" Inherits="HRM.Section" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Section</h1>
    </div>
     <table>
        <tr>
            <td>Name</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" /></td>
        </tr>
    </table>
   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="section_name" HeaderText="section_name" SortExpression="section_name" />
            <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                                 <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton2_Click">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrm %>" 
    SelectCommand="SELECT [id], [section_name] FROM [section]"></asp:SqlDataSource>
</asp:Content>
