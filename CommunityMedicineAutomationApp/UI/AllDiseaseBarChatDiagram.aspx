<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centralControl.Master" AutoEventWireup="true" CodeBehind="AllDiseaseBarChatDiagram.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.AllDiseaseBarChatDiagram" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script src="../Scripts/jquery-1.6.4.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>

    <asp:Panel runat="server" ID="BarchatPanel" GroupingText="Bar Chart Panel" HorizontalAlign="Left">
        
        <table>
            <tr>
                <td><br/></td>
            </tr>
            <tr>
                <td> <asp:Label runat="server" ID="lable1" Text="From"/> </td>
                <td> <asp:TextBox runat="server" ID="fromDate"/></td>
                <td> <asp:Label runat="server" Text="To"/> </td>
                 <td> <asp:TextBox runat="server" ID="toDate"/></td>
            </tr>
            
              <tr>
              
                <td> <asp:DropDownList runat="server" Width="220" AutoPostBack="True" ID="districtDropDownList"/></td>
         <td> <asp:Button runat="server" Text="Show" Width="120" ID="showBarChat" OnClick="showBarChat_OnClick" /> </td>
                       </tr>
            
            

        </table>

    </asp:Panel>
    
    <asp:Panel runat="server" ID="Barchat">
        <asp:Chart ID="Chart1" runat="server">
            <series>
                <asp:Series Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        
    </asp:Panel>
    
     <script type="text/javascript">
         $("#<%=fromDate.ClientID%>").datepicker();
         $("#<%=toDate.ClientID%>").datepicker();
    </script>

</asp:Content>
