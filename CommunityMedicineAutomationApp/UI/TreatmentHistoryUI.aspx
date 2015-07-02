<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centerControl.Master" EnableViewState="false" AutoEventWireup="true" CodeBehind="TreatmentHistoryUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel runat="server" ID="TreatmentHistoryPanel" GroupingText="All History" HorizontalAlign="Left">
        <table>
            
            <tr>
                <td>
                    <br/>
                     <br/>
                </td>
            </tr>

            <tr>
               <td>
                   <asp:Label ID="Label1" runat="server" Text="National Id"></asp:Label></td>
                <td>
                    <asp:TextBox ID="nationalIdTextBox" runat="server" Width="220"></asp:TextBox></td>
                
                <td>
                    <asp:Button ID="showDetailasButton" runat="server" Text="Show Details" OnClick="showDetailasButton_OnClick" /> </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label></td>
                
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server" Width="220" /> </td>
            </tr>
            
            
            <tr>
                <td> <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label> </td>
                
                <td>  <asp:TextBox ID="addressTextBox" runat="server" Width="220" TextMode="MultiLine"/> </td>

            </tr>
            
            <tr>
                <td><asp:Label runat="server" ID="Label4"/>
                    <br/>
                    
                    <br/>
                </td>
            </tr>

        </table>
        
       
        

    </asp:Panel>
    
     <div ID="centerInfo" runat="server">
            
        </div>
        
        <div ID="GridviewDiv" runat="server">
            
        </div>
    <br/>
   
    
    <br/>
    

    <asp:Button runat="server" ID="TreatmentHistoryPrintButton" Text="Treatment History" OnClick="TreatmentHistoryPrintButton_OnClick"/>

</asp:Content>
