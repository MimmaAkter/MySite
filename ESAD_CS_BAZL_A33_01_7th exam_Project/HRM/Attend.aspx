<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true" CodeBehind="Attend.aspx.cs" Inherits="HRM.Attend" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen"
        href="http://tarruda.github.com/bootstrap-datetimepicker/assets/css/bootstrap-datetimepicker.min.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hiid" runat="server" />
    <br />
    <table style="width:650px;">
        <tr>
            <td colspan="3">
                <h1 class="text-center"> Employee Attendence Information</h1>
            </td>
        </tr>
        <tr>
            
            <td>
                <asp:Label ID="Label7" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td colspan="2">
               <%-- <asp:TextBox ID="txtemp" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="txtem" AppendDataBoundItems="true" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="name" DataValueField="id" AutoPostBack="true" OnSelectedIndexChanged="txtem_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Select Name</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrm %>" SelectCommand="SELECT [name], [id] FROM [emplyee] ORDER BY [name]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="InTime"></asp:Label>
            </td>
            <td colspan="2">
                <%-- <asp:TextBox ID="txtintime" runat="server"></asp:TextBox>--%>
                <div class="well">
                    <div class="datetimepicker3 input-append">
                        <input data-format="hh:mm:ss" type="text" id="txttime" runat="server" />
                        <span class="add-on">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                        </span>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="OutTime"></asp:Label>
            </td>
            <td colspan="2">
                <div class="well">
                <div class="datetimepicker3 input-append">
                    <input data-format="hh:mm:ss" type="text" id="txtouttime" runat="server" />
                    <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                    </span>
                </div>
                <%--<asp:TextBox ID="txtouttime" runat="server"></asp:TextBox>--%>
                    </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="InTime_Lanch"></asp:Label>
            </td>
            <td colspan="2">
                <div class="well">
                 <div class="datetimepicker3 input-append">
                    <input data-format="hh:mm:ss" type="text" id="txtInTimeLanch" runat="server" />
                    <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                    </span>
                </div>
                </div>
                <%--<asp:TextBox ID="txtInTime_Lanch" runat="server"></asp:TextBox>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="OutTime_Lanch"></asp:Label>
            </td>
            <td colspan="2">
                <div class="well">
                <%--<asp:TextBox ID="txtouttimelanch" runat="server"></asp:TextBox>--%>
                <div class="datetimepicker3 input-append">
                    <input data-format="hh:mm:ss" type="text" id="txtouttimelan" runat="server" />
                    <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                    </span>
                </div>
                    </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Attendence Date"></asp:Label>

            </td>
            <td colspan="2">
                <div class="well">
                <%--  <asp:TextBox ID="txtattendence" runat="server"></asp:TextBox>--%>
                <div id="datetimepicker4" class="input-append">
                    <input data-format="yyyy-MM-dd" type="text" runat="server" id="txtattendence" />
                    <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                    </span>
                </div>
                    </div>
            </td>


        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Status"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtss" runat="server"></asp:TextBox>
            </td>


        </tr>

        <tr>
            <td></td>
            <td colspan="2">
                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnclear_Click" />
                <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btnDelate_Click" />
            </td>


        </tr>

        <tr>
            <td></td>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999"
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="600px" 
                     >
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="EmpID" HeaderText="EmpID" />
                        <asp:BoundField DataField="InTime" HeaderText="InTime" />
                        <asp:BoundField DataField="outTime" HeaderText="outTime" />
                        <asp:BoundField DataField="InTime_Lanch" HeaderText="InTime_Lanch" />
                        <asp:BoundField DataField="OutTime_Lanch" HeaderText="OutTime_Lanch" />
                        <asp:BoundField DataField="Attend_Date" HeaderText="Attend_Date" />
                        <asp:BoundField DataField="Statuss" HeaderText="Statuss" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("ID")%>' 
                                    OnClick="LinkButton1_Click">
                                    Edit</asp:LinkButton>
                                <%--<asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("id")%>'
                                    OnClick="displayutton1_Click">View</asp:LinkButton>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </td>


        </tr>


        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label ID="lblmess" runat="server" Text="" ForeColor="Green"></asp:Label>
            </td>


        </tr>
    </table>
    <br />
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
        DataSourceID="SqlDataSource1" DataKeyNames="ID">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="InTime" HeaderText="InTime" SortExpression="InTime" />
            <asp:BoundField DataField="outTime" HeaderText="outTime" SortExpression="outTime" />
            <asp:BoundField DataField="InTime_Lanch" HeaderText="InTime_Lanch" SortExpression="InTime_Lanch" />
            <asp:BoundField DataField="OutTime_Lanch" HeaderText="OutTime_Lanch" SortExpression="OutTime_Lanch" />
            <asp:BoundField DataField="Attend_Date" HeaderText="Attend_Date" SortExpression="Attend_Date" />
            <asp:BoundField DataField="Statuss" HeaderText="Statuss" SortExpression="Statuss" />--%>
    <%-- <asp:BoundField DataField="TotalHour" HeaderText="TotalHour" ReadOnly="True" SortExpression="TotalHour" />--%>
    <%--  </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>--%>



    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrm %>"
        SelectCommand="SELECT * FROM [attendence]"></asp:SqlDataSource>--%>



    <script type="text/javascript"
        src="http://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js">
    </script>
    <script type="text/javascript"
        src="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/js/bootstrap.min.js">
    </script>
    <script type="text/javascript"
        src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.min.js">
    </script>
    <script type="text/javascript"
        src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.pt-BR.js">
    </script>
    <%-- <script type="text/javascript">
      $('#datetimepicker').datetimepicker({
        format: 'dd/MM/yyyy hh:mm:ss',
        language: 'pt-BR'
      });
    </script>--%>
    <script type="text/javascript">
        $(function () {
            $('.datetimepicker3').datetimepicker({
                pickDate: false
            });

        });
        $(function () {
            $('#datetimepicker4').datetimepicker({
                pickTime: false
            });
        });
    </script>
    <%--https://tarruda.github.io/bootstrap-datetimepicker/--%>
</asp:Content>
