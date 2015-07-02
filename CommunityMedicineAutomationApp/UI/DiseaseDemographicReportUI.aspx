<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centralControl.Master" AutoEventWireup="true" CodeBehind="DiseaseDemographicReportUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.DiseaseDemographicReportUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.6.4.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>

    <asp:Panel runat="server" ID="DiseaseDemographicPanel" GroupingText="Disease Demographic Report">
        
        <table>
            <tr>
                <td><br/></td>
            </tr>
            
            <tr>
                
                <td><asp:Label runat="server" Text="From"></asp:Label></td>
                <td><asp:TextBox runat="server" ID="firstdate"  Width="220"/></td>
                 <td><asp:Label runat="server" Text="To"></asp:Label></td>
                <td><asp:TextBox runat="server" ID="lastdate"  Width="220"/></td>

            </tr>
            
            
            <tr>
                <td><asp:Label runat="server" Text="Disease"></asp:Label></td>
                <td><asp:DropDownList runat="server" ID="diseaseDropDownList" AutoPostBack="True" Width="220" /></td>
                <td><asp:Button runat="server" ID="showDemographicReportButton" Text="Show" OnClick="showDemographicReportButton_OnClick"/></td>
            </tr>


        </table>
        
        
        <asp:GridView runat="server" ID="diseaseGridView">
            
        </asp:GridView>
        
        <br />
        <br />
        
        <asp:Button runat="server" Text="Print" ID="diseaseDemographicReportButton" OnClick="diseaseDemographicReportButton_OnClick" Width="124px"/>

    </asp:Panel>
    
      
    <script type="text/javascript">
        $("#<%=firstdate.ClientID%>").datepicker();
        $("#<%=lastdate.ClientID%>").datepicker();
    </script>

</asp:Content>
