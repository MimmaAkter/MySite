<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true" CodeBehind="SalaryReport.aspx.cs" Inherits="HRM.SalaryReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, 
    Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms"
     TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                Employee ID :
            </td>
            <td>
                <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                Date :
            </td>
            <td>
                <asp:TextBox ID="txtdt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td>
               <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
           </td>
            

        </tr>
    </table>
    
    <div>
       <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="807px">
            <LocalReport ReportEmbeddedResource="HRM.Report1.rdlc" ReportPath="HRM.Report1">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>--%>
        <rsweb:ReportViewer ID="ReportViewer2" runat="server"></rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetData" TypeName="HRM.dbHrmEsadDataSetattendanceTableAdapters.attendenceTableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="HRM.dbHrmEsadDataSet1TableAdapters.sp_Display_RecordsTableAdapter"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="dbHrmEsadDataSet1TableAdapters.sp_Display_RecordsTableAdapter"></asp:ObjectDataSource>
    </div>
</asp:Content>
