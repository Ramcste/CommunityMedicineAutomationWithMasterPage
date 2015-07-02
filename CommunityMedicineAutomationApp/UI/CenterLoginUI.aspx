<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centralControl.Master" AutoEventWireup="true" CodeBehind="centerLoginUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.centerLoginUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel runat="server" ID="centerLoginPanel">
        <table>
            
            <tr>
                <td>
                      <asp:Label runat="server" ID="label1">Center Code</asp:Label>
                </td>
                
                <td>
                       <asp:TextBox runat="server" ID="codeTextBox" Width="220"/><br/><br/> 
                </td>
            </tr>
            
            <tr>
                <td>
                       <asp:Label runat="server" ID="label2">Password</asp:Label>
                </td>
                <td>
                     <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password" Width="220"/><br/> <br/> 
                </td>
            </tr>
            
            <tr>
                <td></td><br/> <br/>  <td>
       &nbsp;&nbsp;&nbsp; <asp:Button runat="server" ID="logincenterButon" Text="Login" Width="120" OnClick="logincenterButon_OnClick"/>
            
        </td>
            </tr>
            
            <tr>
                <td> <br/><br/></td>
            </tr>
        </table>
        
        <asp:Label runat="server" ID="label3"/>
             

    </asp:Panel>

</asp:Content>
