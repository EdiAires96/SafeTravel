<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pharmacies.aspx.cs" Inherits="SafeTravel.Admin.Pharmacies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="PharmaciesListTitle" runat="server" class="ContentHead"><h1>Lista de Farmácias 
        <asp:Button ID="AddPharmacy" runat="server" OnClick="AddPharmacy_Click" Text="Nova Farmácia" class="btn btn-primary" 
        style="margin-left:950px; width:180px; "/>
         </h1>
    </div>

        <asp:GridView ID="PharmacyList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="SafeTravel.Models.Pharmacy" SelectMethod="GetPharmacies"
        CssClass="table table-striped table-bordered" >
         <Columns>
        <asp:BoundField DataField="pharmacy_id" HeaderText="Id" SortExpression="pharmacy_id" visible="false"/>        
        <asp:HyperLinkField DataNavigateUrlFields="pharmacy_id" DataTextField="p_name" HeaderText="Nome" DataNavigateUrlFormatString="AddPharmacy.aspx?pharmacyID={0}" />
        <asp:BoundField DataField="adress" HeaderText="Morada" /> 
        <asp:BoundField DataField="email" HeaderText="Email" />    
        <asp:BoundField DataField="phone_number" HeaderText="Telemovel" />
        <asp:BoundField DataField="is_active" HeaderText="Activa" />
 
        </Columns>    
    </asp:GridView>





</asp:Content>
