<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SafeTravel.Admin.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                <div id="ProductsListTitle" runat="server" class="ContentHead"><h1>Lista de Produtos 
                 <asp:Button ID="AddProduct" runat="server" OnClick="AddProduct_Click" Text="Novo Produto" class="btn btn-primary" 
                    style="margin-left:950px; width:180px; "/>
                </h1>
            </div>
    
    <asp:GridView ID="ProductsList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="SafeTravel.Models.Product" SelectMethod="GetProducts"
        CssClass="table table-striped table-bordered" >
         <Columns>
        <asp:BoundField DataField="product_id" HeaderText="Id" SortExpression="product_id" visible="false"/>        
        <asp:HyperLinkField DataNavigateUrlFields="product_id" DataTextField="p_name" HeaderText="Nome" DataNavigateUrlFormatString="AddProduct.aspx?productID={0}"/>  
        <asp:BoundField DataField="price" HeaderText="Preço" DataFormatString="{0:c}" />    
        <asp:BoundField DataField="info" HeaderText="Info" />
        <asp:BoundField DataField="is_active" HeaderText="Activo" /> 
        </Columns>    
    </asp:GridView>





</asp:Content>
