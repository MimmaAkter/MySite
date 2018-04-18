<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true"  EnableTheming="true"
    CodeBehind="Emplyee.aspx.cs" Inherits="HRM.Emplyee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <fieldset>
       <legend>Employee Info</legend>
  
    <table>
       <tr>
           <td>
               <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
          
      <table class="table table-bordered">
         
        <tr>
            <td style="width:30px;">Emplyee Name</td>
            <td style="width:2px;">:</td>
            <td style="width:90px;">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            <td style="width:50px;" > Father Name</td>
            <td style="width:2px;">:</td>
            <td style="width:90px;">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            
            </tr>
         
            
          <tr>
            <td > Mother Name</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
              <td>Date of Birth</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            </tr>
          
          <tr>
            <td>Gender</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
               <td>Nationality</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
            </tr>
         
          <tr>
            <td>Maritual_status</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
              <td>Religion</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
            </tr>
         
          <tr>
            <td>Mobile Number</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
              <td>Email</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td>
            </tr>
       
          <tr>
            <td>Home phone</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></td>
              <td>Present Address</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td>
            </tr>
           <tr>
            <td>Parmanent Address</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></td>
              <td>Division</td>
            <td>:</td>
            <td>

                <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="ObjectDataSource5" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                <asp:ObjectDataSource runat="server" ID="ObjectDataSource5" SelectMethod="Display" TypeName="HRM_DAL.DivisionAccess"></asp:ObjectDataSource>
            </td>
            </tr>
          <tr>
            <td>Gross Salary</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox></td>
              <td>Department</td>
            <td>:</td>
            <td>

                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource7" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                <asp:ObjectDataSource runat="server" ID="ObjectDataSource7" SelectMethod="Display" TypeName="HRM_DAL.DeptAccess"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Display" TypeName="HRM_DAL.DeptAccess"></asp:ObjectDataSource>
              </td>
            </tr>
         
          <tr>
            <td>Designation</td>
            <td>:</td>
            <td>
                 <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource2" DataTextField="DesName" DataValueField="DesId"></asp:DropDownList>
                 <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="Display" TypeName="HRM_DAL.DesigAccess"></asp:ObjectDataSource>
              </td>
              <td>Section</td>
            <td>:</td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="ObjectDataSource3" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="Display" TypeName="HRM_DAL.sceAccess"></asp:ObjectDataSource>
              </td>
            </tr>
        

        <tr>
           
            <td colspan="6">
               
                
                  <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                 <asp:Button ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

            </td>
        </tr>
         <tr>
             <td>Select Employee Name</td>
             <td>:</td>

             <td>
                 <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id"></asp:DropDownList>
                 <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:hrm %>' SelectCommand="SELECT [id], [name] FROM [emplyee]"></asp:SqlDataSource>
                 <asp:Button ID="Button2" runat="server" Text="Edit" OnClick="Button2_Click" />
                 <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
             </td>
         </tr>
         <tr>
             <td>
                 </td>
                 
         </tr>
    </table>
                </td>
           </tr>
        <tr>
           <td style="width: 100%; height: 400px; overflow: auto; vertical-align:top">
             <%--  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  SkinID="gridviewSkin1"
                   DataSourceID="ObjectDataSource4" AllowPaging="True">
                   <Columns>
                       <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                       <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                       <asp:BoundField DataField="father_name" HeaderText="father_name" SortExpression="father_name" />
                       <asp:BoundField DataField="mother_name" HeaderText="mother_name" SortExpression="mother_name" />
                       <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob" />
                       <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                       <asp:BoundField DataField="nationality" HeaderText="nationality" SortExpression="nationality" />
                       <asp:BoundField DataField="maritual_status" HeaderText="maritual_status" SortExpression="maritual_status" />
                       <asp:BoundField DataField="Religion" HeaderText="Religion" SortExpression="Religion" />
                       <asp:BoundField DataField="mobile" HeaderText="mobile" SortExpression="mobile" />
                       <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                       <asp:BoundField DataField="home_phone" HeaderText="home_phone" SortExpression="home_phone" />
                       <asp:BoundField DataField="present_address" HeaderText="present_address" SortExpression="present_address" />
                       <asp:BoundField DataField="parmanent_address" HeaderText="parmanent_address" SortExpression="parmanent_address" />
                       <asp:BoundField DataField="deptid" HeaderText="deptid" SortExpression="deptid" Visible="False" />
                       <asp:BoundField DataField="degid" HeaderText="degid" SortExpression="degid" Visible="False" />
                       <asp:BoundField DataField="secid" HeaderText="secid" SortExpression="secid" Visible="False" />
                       <asp:BoundField DataField="Divid" HeaderText="Divid" SortExpression="Divid" Visible="False" />
                   </Columns>
               </asp:GridView>--%>
               <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetData"
                    TypeName="HRM_DAL.EmpAccess"></asp:ObjectDataSource>
           </td>
       </tr>
   </table> </fieldset>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            width:240px;
        }
    </style>
</asp:Content>

