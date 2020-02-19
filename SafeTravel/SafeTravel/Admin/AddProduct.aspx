<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SafeTravel.Admin.AddProduct" %>
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


    <h1>Registo do Produto</h1>
    <table >
        <tr>
            <td><asp:Label ID="LabelName" runat="server" AssociatedControlID="ProductName">Nome:</asp:Label></td>
            <td>
                <asp:TextBox ID="ProductName" runat="server" Width="412px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" runat="server" Text="*Nome do produto necessário." ControlToValidate="ProductName" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorProductName" runat="server" Text="* Nome inválido." ControlToValidate="ProductName" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-ZáâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛ\s]{1,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
                <tr>
            <td><asp:Label ID="LabelPrice" runat="server" AssociatedControlID="ProductPrice">Preço:</asp:Label></td>
            <td>
                <asp:TextBox ID="ProductPrice" runat="server" Width="412px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductPrice" runat="server" Text="* Preço necessário." ControlToValidate="ProductPrice" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorProductPrice" runat="server" Text="* Preço inválido (Ex.:99.99 )." ControlToValidate="ProductPrice" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
                    <tr>
            <td><asp:Label ID="LabelInfo" runat="server" AssociatedControlID="ProductInfo">Info:</asp:Label></td>
            <td>
                <asp:TextBox ID="ProductInfo" runat="server" Width="412px" TextMode="MultiLine" ></asp:TextBox>

            </td>
        </tr>

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
