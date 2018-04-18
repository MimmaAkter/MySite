<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true"
     CodeBehind="Benefit.aspx.cs" Inherits="HRM.Benefit_WebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Benefit_ID" DataSourceID="SqlDataSource1">
           <Columns>
               <asp:BoundField DataField="Benefit_ID" HeaderText="Benefit_ID" ReadOnly="True" InsertVisible="False" SortExpression="Benefit_ID"></asp:BoundField>
               <asp:BoundField DataField="Benefit_Type" HeaderText="Benefit_Type" SortExpression="Benefit_Type"></asp:BoundField>
               <asp:TemplateField HeaderText="...">
                   <HeaderStyle BackColor="#99FF66" ForeColor="Fuchsia"></HeaderStyle>
                   <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("Benefit_ID") %>' OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                       <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("Benefit_ID") %>' OnClick="LinkButton2_Click">Delete</asp:LinkButton>
                   </ItemTemplate>
               </asp:TemplateField>
               
           </Columns>
       </asp:GridView>
       <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:hrm %>' SelectCommand="sp_displayBenefit" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
   </div>
    <table>
        <%--<tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Benefit ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Benefit Type"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <%--<td>
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
            </td>
            <td>
                <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
            </td>--%>
        </tr>
    </table>
</asp:Content>
