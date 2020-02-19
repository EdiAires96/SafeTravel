<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRegion.aspx.cs" Inherits="SafeTravel.Admin.AddRegionaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style type="text/css">
        h1{
            margin-bottom:50px;
        }
        table {
            border-collapse: collapse;
        }

        td {
            padding-top: .7em;
            padding-bottom: .7em;
            padding-right: 1em;
        }
        button {
            margin-right:50px;
        }
    </style>


    <h1>Região</h1>
    <table>
        <tr>
            <td><asp:Label ID="LabelAddName" runat="server" AssociatedControlID="RegionName">Nome:</asp:Label></td>
            <td>
                <asp:TextBox ID="RegionName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRegionName" runat="server" Text="*Nome da região necessário." ControlToValidate="RegionName" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRegionName" runat="server" Text="* Nome inválido." ControlToValidate="RegionName" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[a-zA-ZáâãÁÃÂéêÉÊíîÍÎóôõÓÕÔúûÚÛ\s]{1,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddCountrys" runat="server" AssociatedControlID="Countrys">Países:</asp:Label></td>
            <td>
                <asp:TextBox ID="Countrys" runat="server" TextMode="MultiLine" Rows="4" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddConcerns" runat="server" AssociatedControlID="Concerns">Preocupações:</asp:Label></td>
            <td>
                <asp:TextBox ID="Concerns" TextMode="MultiLine" Rows="6" runat="server" Width="400px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddFinancialDescription" runat="server" AssociatedControlID="Description">Descrição::</asp:Label></td>
            <td>
                <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Rows="6" Width="400px"></asp:TextBox>
                
            </td>
        </tr>
        

    </table>

    <div>
        <br />
       <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancel" Width="150px" class="btn btn-primary" CausesValidation="false"/>
       <asp:Button ID="Save" runat="server" OnClick="AddRegionButtonClick" Text="Guardar" Width="150px" class="btn btn-primary" CausesValidation="true"
            style="margin-left:150px"/>
    </div>
    
</asp:Content>
