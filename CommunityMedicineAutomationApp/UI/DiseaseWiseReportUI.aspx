<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centralControl.Master"  AutoEventWireup="true" CodeBehind="DiseaseWiseReportUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.DiseaseWiseReportUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.6.4.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>
    
    <asp:Panel runat="server" ID="diseaseWiseReportPanel" GroupingText="Disease Wise Report" HorizontalAlign="Left">
        
        <table>
            <tr>
                
                <td><br/><br/></td>

            </tr>
            
            <tr>
                <td><asp:Label runat="server" Text="Select Disease"></asp:Label></td>
                <td><asp:DropDownList runat="server" ID="diseaseDropDownList" Width="220" AutoPostBack="True" /></td>
                <td><asp:Button runat="server" ID="showDiseaseReportButton" Text="Show" OnClick="showDiseaseReportButton_OnClick" Width="78px"/></td>
            </tr>
            
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td><asp:Label runat="server" Text="Date Between"/></td>
                <td><asp:TextBox runat="server" ID="firstdateTextBox" Width="203px"/><br/></td>
                <td><asp:Label runat="server" Text="and"/></td>
                <td><asp:TextBox runat="server" ID="lastdateTextBox"  Width="177px"/></td>
            </tr>
            
            <tr>
                <td>
                    <br />
                <br /> 
                </td>
               
            </tr>

        </table>
        
        
        <asp:GridView runat="server" ID="diseaseWiseReportGridView" Width="599px" >
            
        </asp:GridView>
        <br/>
        <br/>
   
     <asp:Button runat="server" ID="DiseaseWiseReportButtonPdf" Text="ExporttoPDF" OnClick="DiseaseWiseReportButtonPdf_OnClick"  />

    </asp:Panel>
    
    
      <script type="text/javascript">
          $("#<%=firstdateTextBox.ClientID%>").datepicker();
          $("#<%=lastdateTextBox.ClientID%>").datepicker();

    </script>

</asp:Content>
