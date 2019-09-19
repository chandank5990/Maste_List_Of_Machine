<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Master List Of Machine.aspx.cs" Inherits="Master_List_Of_Machine.Master_List_Of_Machine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <div style="width: 800px; font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif;
            border: 2px solid black;">
            <asp:Label ID="Label1" runat="server" Style="text-align: center; font-weight: 700;
                font-size: xx-large; color: #000000;" Text="MASTER LIST OF MACHINES"></asp:Label></div>
        <br />
        <table>
        <tr>
        <td>
            <asp:RadioButton ID="rdbtn4" GroupName="category" runat="server" Text="Machine" 
                style="font-weight: 700; color: #000000;"/></td>
            <td>
                <asp:RadioButton ID="rdbtn5" GroupName="category" runat="server" Text="Support Equipment" 
                    style="font-weight: 700; color: #000000;"/>
            </td>
        </tr>
        </table><br />
            <table>
        <tr>
        <td>
            <asp:RadioButton ID="rdbtn1" GroupName="unit" runat="server" Text="AWS-1" 
                style="font-weight: 700; color: #000000;"/></td>
            <td>
                <asp:RadioButton ID="rdbtn2" GroupName="unit" runat="server" Text="AWS-2" 
                    style="font-weight: 700; color: #000000;"/>
            </td>
            <td>
                <asp:RadioButton ID="rdbtn3" GroupName="unit" runat="server" Text="Both" 
                    style="font-weight: 700; color: #000000;"/>
            </td>
            <td>
                <asp:Button ID="btnMasterListOfMachine" runat="server" Text="Master List Of Machine" 
                    style="font-weight: 700" onclick="btnMasterListOfMachine_Click" /></td>
        </tr>
        </table><br /><br />
        <div>
             <asp:GridView ID="GridView1" runat="server" CellSpacing="2" Style="color: Black;
                text-align: center; height: 218px; width: 700px; color: Black; text-align: center;"
                AutoGenerateColumns="False" ShowFooter="True" ShowHeaderWhenEmpty="True">
            <Columns>
             <asp:TemplateField HeaderText="Sr No.">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CodMaq" HeaderText="Machine No." ReadOnly="True" />
                    <asp:BoundField DataField="TipMaq" HeaderText="Machine Name" ReadOnly="True" />
                    <asp:BoundField DataField="InstallationDate" HeaderText="Installation Date" ReadOnly="True" />
                    <asp:BoundField DataField="AMC" HeaderText="AMC" ReadOnly="True" />
                    <asp:BoundField DataField="Active" HeaderText="Remarks" ReadOnly="True" />
                    </Columns>
                    <HeaderStyle BackColor="#ffffff" BorderStyle="Groove" />
                <EmptyDataTemplate>
                    No Record Available</EmptyDataTemplate>
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
    </center>
</asp:Content>
