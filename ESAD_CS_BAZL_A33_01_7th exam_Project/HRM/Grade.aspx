<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" MasterPageFile="~/maintemp.Master" 
    Inherits="HRM.Grade" %>
<asp:Content ID="cn" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfgradeID" runat="server" />
    <h1 style="background-color:#c5e0c5; text-align:center" class="text-left">Employee's Grade:</h1>
    
        <table style="text-align:center;background-color:#d5e1dc ;  font-size:15pt" >
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="GradeName"></asp:Label>
                </td>
                <td colspan="2" class="auto-style4">
                    <asp:TextBox ID="txtgrade" runat="server"></asp:TextBox>
                </td>
            </tr>
            
             <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="GradeSalary"></asp:Label>
                </td>
                <td colspan="2" class="auto-style4">
                    <asp:TextBox ID="txtsalary" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                 <td class="auto-style4">
                     <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                     <asp:Button ID="btnupdate" runat="server" Text="Delete" OnClick="btnupdate_Click" />
                     <asp:Button ID="btndelete" runat="server" Text="Clear" OnClick="btndelete_Click" />
                 </td>
            </tr>
            <tr>
                <td></td>
                 <td class="auto-style4">
                     <asp:Label ID="lblsuccessmsg" runat="server" Text="" ForeColor="Green"></asp:Label>
                 </td>
            </tr>
            <tr>
                <td></td>
                 <td class="auto-style4">
                     <asp:Label ID="lblerrormsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                 </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:GridView ID="gvgrade"  runat="server" AutoGenerateColumns="false"   Width="482px">
            <Columns>
                <asp:BoundField DataField="GradeName" HeaderText="Grade Name" />
                 <asp:BoundField DataField="GradeSalary" HeaderText="Grade Salary" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkview" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="linkview_Click">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            width: 177px;
        }
    </style>
</asp:Content>



