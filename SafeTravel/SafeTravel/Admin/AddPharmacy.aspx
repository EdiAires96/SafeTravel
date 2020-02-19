<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPharmacy.aspx.cs" Inherits="SafeTravel.Admin.AddPharmacy" %>
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


    <h1>Registo da Farmácia</h1>
    <table >
        <tr>
            <td><asp:Label ID="LabelName" runat="server" AssociatedControlID="PharmacyName">Nome:</asp:Label></td>
            <td>
                <asp:TextBox ID="PharmacyName" runat="server" Width="412px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPharmacyName" runat="server" Text="*Nome da farmácia necessário." ControlToValidate="PharmacyName" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPharmacyName" runat="server" Text="* Nome inválido." ControlToValidate="PharmacyName" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-ZáâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛ\s]{1,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
                <tr>
            <td><asp:Label ID="LabelAddress" runat="server" AssociatedControlID="PharmacyAddress">Morada:</asp:Label></td>
            <td>
                <asp:TextBox ID="PharmacyAddress" runat="server" Width="412px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPharmacyAddress" runat="server" Text="*Morada da farmácia necessário." ControlToValidate="PharmacyAddress" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPharmacyAddress" runat="server" Text="* Morada inválida." ControlToValidate="PharmacyAddress" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9áâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛ\s]{1,30}$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
                <tr>
            <td><asp:Label ID="LabelPhoneNumber" runat="server" AssociatedControlID="PharmacyPhoneNumber">Telemovel:</asp:Label></td>
            <td>
                <asp:TextBox ID="PharmacyPhoneNumber" runat="server" Width="412px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPharmacyPhoneNumber" runat="server" Text="* Número de telemovel necessário." ControlToValidate="PharmacyPhoneNumber" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPharmacyPhoneNumber" runat="server" Text="* Número de telemovel inválido." ControlToValidate="PharmacyPhoneNumber" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]{9,}$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelEmail" runat="server" AssociatedControlID="PharmacyEmail">Email:</asp:Label></td>
            <td>
                <asp:TextBox ID="PharmacyEmail" runat="server" Width="412px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPharmacyEmail" runat="server" Text="* Email da farmácia necessário." ControlToValidate="PharmacyEmail" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPharmacyEmail" runat="server" Text="* Email inválido." ControlToValidate="PharmacyEmail" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9a-zA-Z.-_!#$%&?+]+@[0-9a-zA-Z.-]+[a-z]+$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <!--
                <tr>
            <td><asp:Label ID="LabelPassword" runat="server" AssociatedControlID="PharmacyPassword">Password:</asp:Label></td>
            <td>
                <asp:TextBox ID="PharmacyPassword" runat="server" Width="412px"></asp:TextBox>
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
