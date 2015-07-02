<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centerControl.Master" AutoEventWireup="true" CodeBehind="doctorEntryUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.doctorEntryUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" id="doctorEntryPanel" HorizontalAlign="Left" GroupingText="Doctor Entry">
        
   
         <table>
             <tr>
                 <td><br/><br/></td>
             </tr>

             <tr>
                 <td><asp:Label runat="server" >Name</asp:Label></td>
                 <td><asp:TextBox runat="server" ID="nameTextBox" Width="220"/></td>
                 
             </tr>
             
             <tr>
                 <td><asp:Label runat="server" >Degree</asp:Label></td>
                 <td><asp:TextBox runat="server" ID="degreeTextBox" Width="220"/></td>
             </tr>
             
             <tr>
                 <td><asp:Label runat="server" >Specialization</asp:Label></td>
                 <td><asp:TextBox runat="server" ID="specializationTextBox" Width="220"/></td>
             </tr>
             
             <tr>
                 <td></td>
                 <td><asp:Button runat="server" ID="doctorSaveButton" Text="Save" OnClick="doctorSaveButton_OnClick"/></td>
             </tr>

         </table>
         
         <asp:Label runat="server" ID="label1"/>
    
             
        

    </asp:Panel>
   
</asp:Content>
