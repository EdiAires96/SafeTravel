<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMedic.aspx.cs" Inherits="SafeTravel.Admin.AddMedic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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


    <h1>Registo do Médico</h1>
    <table >
        <tr>
            <td><asp:Label ID="LabelName" runat="server" AssociatedControlID="MedicName" >Nome:</asp:Label></td>
            <td>
                <asp:TextBox ID="MedicName" runat="server" Width="412px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMedicName" runat="server" Text="*Nome do médico necessário." ControlToValidate="MedicName" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMedicName" runat="server" Text="* Nome inválido." ControlToValidate="MedicName" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-ZáâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛ\s]{1,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
                <tr>
            <td><asp:Label ID="LabelPhoneNumber" runat="server" AssociatedControlID="MedicPhoneNumber">Telemovel:</asp:Label></td>
            <td>
                <asp:TextBox ID="MedicPhoneNumber" runat="server" Width="412px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMedicPhoneNumber" runat="server" Text="* Número de telemovel necessário." ControlToValidate="MedicPhoneNumber" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMedicPhoneNumber" runat="server" Text="* Número de telemovel inválido." ControlToValidate="MedicPhoneNumber" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]{9,}$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelEmail" runat="server" AssociatedControlID="MedicEmail">Email:</asp:Label></td>
            <td>
                <asp:TextBox ID="MedicEmail" runat="server" Width="412px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMedicEmail" runat="server" Text="* Email do médico necessário." ControlToValidate="MedicEmail" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorMedicEmail" runat="server" Text="* Email inválido." ControlToValidate="MedicEmail" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9a-zA-Z.-_!#$%&?+]+@[0-9a-zA-Z.-]+[a-z]+$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
           </tr>
<!--
        </tr>
          <tr>
            <td><asp:Label ID="LabelPassword" runat="server" AssociatedControlID="MedicPassword">Password:</asp:Label></td>
            <td>
                <asp:TextBox ID="MedicPassword" runat="server" Width="412px"></asp:TextBox>
            </td>
        </tr>  
    -->
          <tr>
            <td><asp:Label ID="LabelActive" runat="server">Activo:</asp:Label></td>
            <td>
               <asp:Label ID="LabelYes" runat="server">Yes</asp:Label> <asp:CheckBox id="CheckYes" runat="server"></asp:CheckBox>
               <asp:Label ID="LabelNo" runat="server">No</asp:Label> <asp:CheckBox id="CheckNo" runat="server"></asp:CheckBox>
            </td>
        </tr>





    </table>

   <p> </p> 
       <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancel" Width="150px" class="btn btn-primary" CausesValidation="false"/>
       <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Guardar" Width="150px" class="btn btn-primary" CausesValidation="true"
            style="margin-left:150px"/>



</asp:Content>
