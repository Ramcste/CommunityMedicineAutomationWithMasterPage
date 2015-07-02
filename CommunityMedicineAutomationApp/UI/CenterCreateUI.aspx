<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centralControl.Master" AutoEventWireup="true" CodeBehind="centerCreateUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.centerCreateUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <asp:Panel runat="server" id="createcentralControlEntryPanel" GroupingText="Create centralControl" HorizontalAlign="Left">
       
       
       <table>
             <tr>
                 <td></td>
                 <td><br/><br/></td>
             </tr>
            <tr>
                <td><asp:Label runat="server" ID="label1">Name</asp:Label></td>
                <td><asp:TextBox runat="server" ID="nameTextBox" Width="220"/><br/><br/></td>
            </tr>
             <tr>
                <td><asp:Label runat="server" ID="label2">District</asp:Label></td>
                <td><asp:DropDownList runat="server" ID="districtDropDownList" Width="220" AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_OnSelectedIndexChanged" /><br/><br/> </td>
            </tr>
            
             <tr>
                <td><asp:Label runat="server" ID="label3">Thana</asp:Label></td>
                <td><asp:DropDownList runat="server" ID="thanaDropDownList" AutoPostBack="True" Width="220"/> <br/><br/></td>
               
            </tr>
            
            <tr>
                <td></td>
               <td><asp:Button runat="server" ID="savecentralControlEntryButton" OnClick="savecentralControlEntryButton_OnClick" Text="Save" /> <br/><br/></td>
            </tr>
             <tr>
                 <td></td>
                 <td></td>
             </tr>

        </table>
        <asp:Label runat="server" ID="label6"></asp:Label>
        <br/>
        <br/>
    
       

   </asp:Panel> 
    

</asp:Content>
