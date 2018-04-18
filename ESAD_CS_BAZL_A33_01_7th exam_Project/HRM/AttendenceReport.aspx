<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true" CodeBehind="AttendenceReport.aspx.cs" Inherits="HRM.AttendenceReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table>
       <tr>
           <td>
               <asp:Label ID="Label1" runat="server" Text="Employee ID"></asp:Label>
           </td>
           <td>
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           </td>
       </tr>
       <tr>
           <td>
               <asp:Label ID="Label2" runat="server" Text="Start Date"></asp:Label>
           </td>
           <td>
               <asp:TextBox ID="txtsdate" runat="server"></asp:TextBox>
           </td>
       </tr>
       <tr>
           <td>
               <asp:Label ID="Label3" runat="server" Text="End Date"></asp:Label>
           </td>
           <td>
               <asp:TextBox ID="txtedate" runat="server"></asp:TextBox>
           </td>
       </tr>

       <tr>
           <td>
               <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
           </td>
       </tr>
   </table>
    <div>
         <%--<rsweb:ReportViewer ID="ReportViewer2" runat="server" Width="800px"></rsweb:ReportViewer>--%>

    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="454px" Width="889px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" >
        <LocalReport ReportEmbeddedResource="HRM.AttendenceReport.rdlc" ReportPath="AttendenceReport.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="HRM.dbHrmEsadDataSetTableAdapters.sp_displayAttendenceTableAdapter"></asp:ObjectDataSource>
   <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>--%>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="dbHrmEsadDataSetTableAdapters.sp_displayAttendenceTableAdapter"></asp:ObjectDataSource>
</asp:Content>
