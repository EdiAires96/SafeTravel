<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientsList.aspx.cs" Inherits="SafeTravel.Medic.PatientsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                    <div id="PatientsListTitle" runat="server" class="ContentHead"><h1>Lista de Utentes
                 <asp:Button ID="MedicAddPatient" runat="server" OnClick="MedicAddPatient_Click" Text="Novo Utente" class="btn btn-primary" 
                    style="margin-left:950px; width:180px; "/>
                </h1>
            </div>
     <asp:GridView ID="PatientsList2" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="SafeTravel.Models.Patient" SelectMethod="GetPatients"
        CssClass="table table-striped table-bordered" >
         <Columns>
        <asp:BoundField DataField="patient_id " HeaderText="Id" SortExpression="patient_id " visible="false"/>        
        <asp:HyperLinkField DataNavigateUrlFields="patient_id" DataTextField="p_name" HeaderText="Nome" DataNavigateUrlFormatString="MedicAddPatient.aspx?patientID={0}" /> 
        <asp:BoundField DataField="p_address" HeaderText="Morada" /> 
        <asp:BoundField DataField="date_of_birth" HeaderText="Data de Nascimento" DataFormatString="{0:d}" HtmlEncode="false"/>
         <asp:BoundField DataField="number_health" HeaderText="Nº Utente" />
        <asp:BoundField DataField="p_email" HeaderText="Email" />    
        <asp:BoundField DataField="phone_number" HeaderText="Telemovel" />
        <asp:BoundField DataField="job" HeaderText="Profissão" />
        <asp:BoundField DataField="naturality" HeaderText="Naturalidade" /> 
        <asp:BoundField DataField="genre" HeaderText="Sexo" /> 
        <asp:BoundField DataField="financial_number" HeaderText="NºSeg.Social" /> 
        </Columns>    
    </asp:GridView>
</asp:Content>
