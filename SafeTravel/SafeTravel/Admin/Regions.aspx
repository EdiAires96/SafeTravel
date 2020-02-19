<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Regions.aspx.cs" Inherits="SafeTravel.Admin.Regions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                <div id="RegionsListTitle" runat="server" class="ContentHead"><h1>Lista de Regiões 
                 <asp:Button ID="AddRegion" runat="server" OnClick="AddRegion_Click" Text="Nova Região" class="btn btn-primary" 
                    style="margin-left:950px; width:180px; "/>
                </h1>
            </div>

    <asp:GridView ID="RegionsList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="SafeTravel.Models.Region" SelectMethod="GetRegion"
        CssClass="table table-striped table-bordered" >
         <Columns>
        <asp:BoundField DataField="region_id" HeaderText="Id" SortExpression="region_id" visible="false"/>      
        <asp:HyperLinkField DataNavigateUrlFields="region_id" DataTextField="r_name" HeaderText="Nome" DataNavigateUrlFormatString="AddRegion.aspx?regionID={0}"  />
        <asp:BoundField DataField="countries" HeaderText="Páises" />    
        <asp:BoundField DataField="precautions" HeaderText="Precauçoes" /> 
        <asp:BoundField DataField="info" HeaderText="Info" /> 
        </Columns>    
    </asp:GridView>

</asp:Content>
