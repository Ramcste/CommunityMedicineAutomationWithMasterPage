<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centralControl.Master" AutoEventWireup="true" CodeBehind="centerInfoUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.centerInfoUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel runat="server" ID="centerInfoUIPanel">
        
        <table>
            
            <tr>
                <td></td>
                <td></td>

            </tr>

            <tr>
                <td><asp:Label runat="server" >District Name:</asp:Label></td>
                <td><asp:Label runat="server" ID="districtName"></asp:Label></td>

            </tr>
            
            <tr>
                <td><asp:Label runat="server" >Thana Name:</asp:Label></td>
                <td><asp:Label runat="server" ID="thanaName"></asp:Label></td>

            </tr>

            <tr>
                <td><asp:Label runat="server" >center Name:</asp:Label></td>
                <td><asp:Label runat="server" ID="centerName"></asp:Label></td>

            </tr>
            
            <tr>
                <td><asp:Label runat="server" >center Code:</asp:Label></td>
                <td><asp:Label runat="server" ID="centerCode"></asp:Label></td>

            </tr>
            
            <tr>
                <td><asp:Label runat="server" >center Password:</asp:Label></td>
                <td><asp:Label runat="server" ID="centerPassword"></asp:Label></td>

            </tr>
            
            <tr>
                <td></td>
                <td><br/><br/></td>
            </tr>

        </table>

    </asp:Panel>
    
    <asp:Button runat="server" ID="centerInfoPrintButton" Text="Export To PDF"  OnClick="centerInfoPrintButton_OnClick" />

</asp:Content>
