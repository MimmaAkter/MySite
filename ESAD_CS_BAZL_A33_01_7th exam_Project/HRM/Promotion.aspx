<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true"
     CodeBehind="Promotion.aspx.cs" Inherits="HRM.Promotion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        
       
       <table>
           <tr>
               <td> Search by ID:</td>
               <td>
                   <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
               </td>
               <td>
                   <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
                   
               </td>
           </tr>
           <tr>
               <td>Basic:</td>
               <td>
                   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
               </td>
           </tr>
           <tr>
               <td>HousRent</td>
               <td>
                   <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
               </td>
           </tr>
           <tr>
               <td>Medical:</td>
               <td>
                   <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
               </td>
           </tr>
           <tr>
               <td>Convences:</td>
               <td>
                   <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
               </td>
           </tr>
           <tr>
               <td>Tax:</td>
               <td>
                   <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
               </td>
           </tr>
           <tr>

               <td>Gross Salary:</td>
               <td>
                   <asp:HiddenField ID="HiddenField2" runat="server" />
                   <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
               </td>
           </tr>
           
       </table>
        <hr />

            <div>
              
                    
                <table>
                    <tr>
                        <td>Type</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Benefit_Type" DataValueField="Benefit_ID">
                            </asp:DropDownList><asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="Display" TypeName="HRM_DAL.BenefitAccess" OnSelecting="ObjectDataSource1_Selecting"></asp:ObjectDataSource>
                        </td>
                    </tr>

                     <tr>
               <td>Benifit Active Date</td>
                   <td>
                     <asp:TextBox ID="TextBox9" runat="server" ReadOnly="true"></asp:TextBox>
                       <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                       <asp:Button ID="Button5" runat="server" Text="Select Date" OnClick="Button5_Click" />
                   </td>
                </tr>
                    <tr>
                         <td>Benifit Entry Date</td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                        <asp:Button ID="Button6" runat="server" Text="Select Date" OnClick="Button6_Click" />
                     </td>
                </tr>
                <tr>
                <td>
                    Amount:
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                    
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Calculate" OnClick="Button2_Click" />
                   
                </td>
               
            </tr>
                </table>
            </div>

                      
                    

        
        <hr />
      
        <table>
           
            
           <tr>
                
               <td>Basic</td>
               <td>
                   <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>HousRent</td>
               <td>
                   <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

               </td>
           </tr>
           <tr>
               <td>Medical</td>
               <td>
                 <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

               </td>
           </tr>
           <tr>
               <td>Convences</td>
               <td>
                 <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>

               </td>
           </tr>
           <tr>
               <td>Tax</td>
               <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>

               </td>
           </tr>
           <tr>
               <td>Gross Salary</td>
               <td>
               <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>

               </td>
           </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
                <td></td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" />
                    <asp:Button ID="Button3" runat="server" Text="Save" OnClick="Button3_Click" />

                </td>
            </tr>
           
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="800px" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="1" style="margin-left: 0px">
            <Columns>
                <%--<asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="empid" HeaderText="empid" SortExpression="empid" />--%>
                <asp:BoundField DataField="pro_type" HeaderText="pro_type" SortExpression="pro_type" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                <asp:BoundField DataField="activedate" HeaderText="activedate" SortExpression="activedate" />
                <asp:BoundField DataField="pro_active" HeaderText="pro_active" SortExpression="pro_active" />
                <asp:BoundField DataField="Basics" HeaderText="Basics" SortExpression="Basics" />
                <asp:BoundField DataField="HouseRent" HeaderText="HouseRent" SortExpression="HouseRent" />
                <asp:BoundField DataField="Medicalmoney" HeaderText="Medicalmoney" SortExpression="Medicalmoney" />
                <asp:BoundField DataField="Convences" HeaderText="Convences" SortExpression="Convences" />
                <asp:BoundField DataField="taxes" HeaderText="taxes" SortExpression="taxes" />
                <asp:BoundField DataField="Gross_Salary" HeaderText="Gross_Salary" SortExpression="Gross_Salary" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton2_Click">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrm %>" SelectCommand="SELECT * FROM [promotion]"></asp:SqlDataSource>
    </div>
</asp:Content>
