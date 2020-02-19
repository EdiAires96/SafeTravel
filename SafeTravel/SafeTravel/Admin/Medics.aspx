<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medics.aspx.cs" Inherits="SafeTravel.Admin.Medics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <div id="MedicsListTitle" runat="server" class="ContentHead"><h1>Lista de Médicos  
                 <asp:Button ID="AddMedic" runat="server" OnClick="AddMedic_Click" Text="Novo Médico" class="btn btn-primary" 
                    style="margin-left:950px; width:180px; "/>
                </h1>
            </div>
    


 
    <asp:GridView ID="MedicsList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="SafeTravel.Models.Medic" SelectMethod="GetMedics"
        CssClass="table table-striped table-bordered" >
         <Columns>
        <asp:BoundField DataField="medic_id" HeaderText="Id" SortExpression="medic_id" visible="false"/>        
        <asp:HyperLinkField DataNavigateUrlFields="medic_id" DataTextField="m_mame" HeaderText="Nome" DataNavigateUrlFormatString="AddMedic.aspx?MedicID={0}"/>  
        <asp:BoundField DataField="m_email" HeaderText="Email" />    
        <asp:BoundField DataField="phone_number" HeaderText="Telemovel" />
        <asp:BoundField DataField="is_active" HeaderText="Activo" />
        </Columns>    
    </asp:GridView>
        



    </asp:Content>
