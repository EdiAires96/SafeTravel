<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicAddPatient.aspx.cs" Inherits="SafeTravel.Medic.MedicAddPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
                <!--Requirement jQuery-->
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
	<!--Load Script and Stylesheet -->
	<script type="text/javascript" src="../Scripts/jquery.simple-dtpicker.js"></script>     
    <link type="text/css" href="../Styles/jquery.simple-dtpicker.css" rel="stylesheet" />

<style type="text/css">
        h1{
            margin-bottom:10px;
        }
        table {
            border-collapse: collapse;
        }

        td {
            padding-top: .7em;
            padding-bottom: .7em;
            padding-right: 1em;
        }
    </style>

      <div style="display:table-cell;width:500px;margin-right:50px;"> 
        <h1>Registo do Utente</h1>
        <table >
            <tr>
                <td><asp:Label ID="LabelName" runat="server" AssociatedControlID="PatientName">Nome:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientName" runat="server" Width="412px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorPatientName" runat="server" Text="* Nome do utente necessário." ControlToValidate="PatientName" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPatientName" runat="server" Text="* Nome inválido." ControlToValidate="PatientName" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-ZáâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛçÇ\s]{1,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
                           <tr>
                <td><asp:Label ID="LabelAddress" runat="server" AssociatedControlID="PatientAddress">Morada:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientAddress" runat="server" Width="412px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorPatientAddress" runat="server" Text="* Morada do utente necessário." ControlToValidate="PatientAddress" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPatientAdress" runat="server" Text="* Morada inválida." ControlToValidate="PatientAddress" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9áâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛçÇ\s]{1,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
                 <tr>
                <td><asp:Label ID="LabelDate" runat="server" AssociatedControlID="PatientDate">Data de Nascimento:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientDate" runat="server" Width="412px" ></asp:TextBox>
                    <script type="text/javascript">
                    $(document).ready(function () {
                        $("#<%=PatientDate.ClientID%>").appendDtpicker({
                            "dateFormat": "DD/MM/YYYY",
                            "futureOnly": true,
                            "autodateOnStart": false,
                            "locale": "pt",
                            "dateOnly":true
                        });

                    });
                </script> 
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" Text="* Data de nascimento necessária." ControlToValidate="PatientDate" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>
            </tr>
                    <tr>
                <td><asp:Label ID="LabelNumberHealth" runat="server" AssociatedControlID="PatientNumberHealth">Numero de Utente:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientNumberHealth" runat="server" Width="412px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorPatientNumberHealth" runat="server" Text="* Número de utente necessário." ControlToValidate="PatientNumberHealth" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPatientNumberHealth" runat="server" Text="* Número de utente inválido." ControlToValidate="PatientNumberHealth" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]{9}$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
               <tr>
                <td><asp:Label ID="LabelPhoneNumber" runat="server" AssociatedControlID="PatientPhoneNumber">Telemovel:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientPhoneNumber" runat="server" Width="412px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorPatientPhoneNumber" runat="server" Text="* Número de telemovel necessário." ControlToValidate="PatientPhoneNumber" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPatientPhoneNumber" runat="server" Text="* Número de telemovel inválido." ControlToValidate="PatientPhoneNumber" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]{9,}$" ForeColor="Red"></asp:RegularExpressionValidator>
                
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="LabelEmail" runat="server" AssociatedControlID="PatientEmail">Email:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientEmail" runat="server" Width="412px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPatientEmail" runat="server" Text="* Email do utente necessário." ControlToValidate="PatientEmail" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPatientEmail" runat="server" Text="* Email inválido." ControlToValidate="PatientEmail" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9a-zA-Z.-_!#$%&?+]+@[0-9a-zA-Z.-]+[a-z]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
              <tr>
                <td><asp:Label ID="LabelJob" runat="server" AssociatedControlID="PatientJob">Profissão:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientJob" runat="server" Width="412px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPatientJob" runat="server" Text="* Nome da profissão necessária." ControlToValidate="PatientJob" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPatientJob" runat="server" Text="* Profissão inválida." ControlToValidate="PatientJob" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-ZáâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛ\s]{1,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
                       <tr>
                <td><asp:Label ID="LabelNaturality" runat="server" AssociatedControlID="PatientNaturality">Naturalidade:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientNaturality" runat="server" Width="412px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPatientNaturality" runat="server" Text="* Naturalidade necessária." ControlToValidate="PatientNaturality" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPatientNaturality" runat="server" Text="* Naturalidade inválida." ControlToValidate="PatientNaturality" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-ZáâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛ\s]{1,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
                      <tr>
                <td><asp:Label ID="LabelGenre" runat="server">Sexo:</asp:Label></td>
                <td>
                   <asp:Label ID="LabelM" runat="server">M</asp:Label> <asp:CheckBox id="CheckM" runat="server"></asp:CheckBox>
                    <asp:Label ID="LabelF" runat="server">F</asp:Label> <asp:CheckBox id="CheckF" runat="server"></asp:CheckBox>
                </td>
            </tr>
                      <tr>
                <td><asp:Label ID="LabelFinancialNumber" runat="server" AssociatedControlID="PatientFinancialNumber">Numero de Contribuinte:</asp:Label></td>
                <td>
                    <asp:TextBox ID="PatientFinancialNumber" runat="server" Width="412px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorPatientFinancialNumber" runat="server" Text="* Número de contribuinte necessário." ControlToValidate="PatientFinancialNumber" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPatientFinancialNumber" runat="server" Text="* Número de contribuinte inválido." ControlToValidate="PatientFinancialNumber" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]{9}$" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>


        </table>

       <p> </p> 
           <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancel" Width="150px" class="btn btn-primary" CausesValidation="false"/>
           <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Guardar" Width="150px" class="btn btn-primary" CausesValidation="true"
                style="margin-left:150px"/>
    
    </div>
    <div runat="server" id="div2" style="display:table-cell;width:500px;align-items:center;" visible="false">
        <h1 style="margin-left:100px;">Diagnósticos Anteriores</h1>
        <table style="margin-left:100px;">
            <tr>
                <td>
                    <asp:GridView ID="GridViewDiagnostic" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" CellPadding="4"
                                    CssClass="table table-striped table-bordered"  ItemStyle-HorizontalAlign="center" >
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Id"  Visible="false"/>
                                        <asp:HyperLinkField  DataNavigateUrlFields="id"  DataTextField="Diag" HeaderText="Diagnostico" DataNavigateUrlFormatString="Diagnostic.aspx?patientIdDiagnosticId={0}" ItemStyle-HorizontalAlign="center"/>
                                        <asp:BoundField DataField="date" HeaderText="Data" ItemStyle-HorizontalAlign="center"/>
                                        <asp:BoundField DataField="regions" HeaderText="Regiões visitadas" ItemStyle-HorizontalAlign="center"/>
                                    </Columns>
                                

                   </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
