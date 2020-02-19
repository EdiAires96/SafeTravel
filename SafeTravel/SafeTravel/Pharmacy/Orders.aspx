<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="SafeTravel.Pharmacy.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
        <style>
        .grid td, .grid th
        {
            text-align:center;
         }
    </style>

                <div id="OrdersListTitle" runat="server" class="ContentHead"><h1>Lista de Encomendas
                 <asp:Button ID="AddOrder" runat="server" OnClick="AddOrder_Click" Text="Nova Encomenda" class="btn btn-primary" 
                    style="margin-left:950px; width:200px; "/>
                </h1>
            </div>

    <br />
    <br />
    <asp:Label ID="emptyGrid" runat="server" Text="De momento ainda não existem encomendas pro confirmar!" Font-Bold="True" Font-Size="Large" Visible="false" ></asp:Label>

      <asp:GridView ID="GridOrders" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" CellPadding="4" OnRowCommand="row_command" CssClass="table table-striped table-bordered grid"  >
          
             <Columns> 
                  <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton runat="server" ID="linkButton" Text="Ver encomenda" OnClick="Link_Button_Click" ></asp:LinkButton>
                   </ItemTemplate>
                 </asp:TemplateField>
         <asp:BoundField DataField="OrderID" HeaderText="Encomendas" ItemStyle-HorizontalAlign="Center" /> 
           <asp:BoundField DataField="DeliveryDate" HeaderText="Data de entrega" ItemStyle-HorizontalAlign="Center" /> 
            <asp:ButtonField ButtonType="Button" CommandName="add" Text="Confirmar" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" />
             </Columns> 
            </asp:GridView>


    <br />
    <br />
    <br />


      <asp:GridView ID="GridReceiveOrders" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" CellPadding="4" CssClass="table table-striped table-bordered grid"  >
          
             <Columns>  
             <asp:BoundField DataField="OrderID2" HeaderText="Encomendas" ItemStyle-HorizontalAlign="Center" /> 
            <asp:BoundField DataField="DeliveryDate2" HeaderText="Encomendas Recebidas" ItemStyle-HorizontalAlign="Center" /> 
                     <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Label ID="lblStatus" runat="server" Text="Recebido" Font-Bold="True" Font-Size="Medium" ForeColor="#00cc00" ></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns> 
            </asp:GridView>


   <!-- 
    

      <asp:HyperLinkField DataNavigateUrlFields="OrderID" DataTextField="OrderID" HeaderText="Encomendas" DataNavigateUrlFormatString="MakeOrder.aspx?orderID={0}" />
 



          <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Label ID="lblStatus" runat="server" Text="Recebido" Font-Bold="True" Font-Size="Medium" ForeColor="#00cc00"  Visible="false"></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
 <asp:ButtonField ButtonType="Button" CommandName="add" Text="Confirmar" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" />
       
       <asp:Label ID="lblStatus2" runat="server" Text="Recebido" Font-Bold="True" Font-Size="Medium" ForeColor="#00cc00"  Visible="true"></asp:Label>
        -->



</asp:Content>
