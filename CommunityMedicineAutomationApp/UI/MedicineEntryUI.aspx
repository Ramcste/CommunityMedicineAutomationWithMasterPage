<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centralControl.Master" AutoEventWireup="true" CodeBehind="MedicineEntryUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.MedicineEntryUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel runat="server" ID="medicineEntryPanel" GroupingText="Medicine Entry" HorizontalAlign="Left">
  

        <table>
            
             <tr>
                   <td></td>
                   <td><br/> <br/></td>
               </tr>

            <tr>
                <td><asp:Label runat="server" ID="label1">Name of Medicine with Mg/Ml</asp:Label></td>
                <td><asp:TextBox runat="server" ID="nameTextBox" TextMode="MultiLine" /></td>
            </tr>
     
                    
            <tr>
                    <td></td>
                   <td><asp:Button runat="server" ID="saveMedicineButton" Text="Save" OnClick="saveMedicineButton_OnClick"/> </td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
            </tr>

        </table>
        </asp:Panel>
    
        <asp:Label runat="server" ID="label5"></asp:Label>
        <br/>
        <br/>
        <asp:GridView runat="server" ID="medicineGridView" Width="825px" AutoGenerateColumns="False" Height="77px" BorderWidth="2px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" CellPadding="3" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="medicineGridView_PageIndexChanging"  PageSize="5"  >
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                  <asp:TemplateField HeaderText="Serial No." >
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name"   />
               
            </Columns>
                       

            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
            

            
            

        </asp:GridView>

</asp:Content>
