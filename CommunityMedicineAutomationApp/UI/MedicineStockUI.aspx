<%@ Page Title="" Language="C#" MasterPageFile="~/UI/centerControl.Master" AutoEventWireup="true" CodeBehind="MedicineStockUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.MedicineStockUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel runat="server" ID="medicineStockPanel" GroupingText="Medicine Stock" HorizontalAlign="Left">
        
           <asp:GridView ID="medicineStockGridView" runat="server" Width="550px">
               

        </asp:GridView>
        

    </asp:Panel>

</asp:Content>
