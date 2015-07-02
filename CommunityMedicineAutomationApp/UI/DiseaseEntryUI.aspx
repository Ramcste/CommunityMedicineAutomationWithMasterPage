<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centralControl.Master" AutoEventWireup="true" CodeBehind="DiseaseEntryUI.aspx.cs" ValidateRequest="false" Inherits="CommunityMedicineAutomationApp.UI.DiseaseEntryUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:Panel runat="server" ID="diseaseEntryPanel" GroupingText="Disease Entry"  HorizontalAlign="Left">
            
           <table>  
       
               <tr>
                   <td></td>
                   <td><br/> <br/></td>
               </tr>
               
                  <tr>
                <td><asp:Label runat="server" ID="label1">Name</asp:Label></td>
                <td><asp:TextBox runat="server" ID="nameTextBox" Width="169px"/> <br/> <br/></td>

                
            </tr>
             <tr>
                <td><asp:Label runat="server" ID="label2">Description</asp:Label></td>
                <td><textarea runat="server" id="descriptionTextBox"></textarea><br/> <br/></td>
            </tr>
            
             <tr>
                <td><asp:Label runat="server" ID="label3">Treatment Procedure</asp:Label></td>
                <td><asp:TextBox runat="server" ID="treatmentProcedureTextBox" TextMode="MultiLine" Width="175px"/></td>
                
                  <td>&nbsp;&nbsp;<asp:Button runat="server" ID="saveDiseaseButton" Text="Save"  OnClick="saveDiseaseButton_OnClick"/></td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
            </tr>

        </table>
        <asp:Label runat="server" ID="label4"></asp:Label>
        <br/>
        <br/>
        <asp:GridView runat="server" ID="diseaseGridView" Width="825px" AutoGenerateColumns="False" Height="77px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" CellPadding="3" GridLines="Horizontal" AllowPaging="True" PageSize="5" OnPageIndexChanging="diseaseGridView_PageIndexChanging1"   >
        <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                  <asp:TemplateField HeaderText="Serial No.">
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name"  />
                <asp:BoundField DataField="Description" HeaderText="Description" HtmlEncode="False" />
                <asp:BoundField DataField="TreatmentProcedure" HeaderText="Treatment"  />
            </Columns>
            
            
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" PageButtonCount="5" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
            

            

        </asp:GridView>
    </asp:Panel>

     

  
     
</asp:Content>
