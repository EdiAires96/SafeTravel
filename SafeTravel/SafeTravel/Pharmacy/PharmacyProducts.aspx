<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PharmacyProducts.aspx.cs" Inherits="SafeTravel.Pharmacy.PharmacyProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <br />
        <style>
        .grid td, .grid th
        {
            text-align:center;
         }
    </style>


    <h1> Produtos da Farmácia</h1>
    <br />
    <asp:GridView ID="GridProducts" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" CellPadding="4" 
        CssClass="table table-striped table-bordered grid"  >   
             <Columns> 
                <asp:BoundField DataField="p_name" HeaderText="Nome" ItemStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="stock" HeaderText="Stock" ItemStyle-HorizontalAlign="Center" />      
             </Columns> 
            </asp:GridView>

     <asp:Label ID="emptyGrid" runat="server" Text="Esta farmácia ainda não tem produtos associados!" Font-Bold="True" Font-Size="Large" Visible="false" ></asp:Label>

<!-- 
    <asp:HyperLinkField DataNavigateUrlFields="product_id" DataTextField="p_name" HeaderText="Nome" DataNavigateUrlFormatString="AddProduct.aspx?productID={0}"/>
    -->


</asp:Content>
