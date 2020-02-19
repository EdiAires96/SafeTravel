<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SafeTravel.Admin.Dashboard" %>
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


<table style="width:1000px; margin-left:200px; font-size:large" >
            <tr>
                <td><asp:Label ID="LabelMedics" runat="server"  > Médicos</asp:Label></td>
                 <td><asp:Label ID="LabelPharmacies" runat="server"  > Fármacias</asp:Label></td>
                <td><asp:Label ID="LabelPatients" runat="server"  > Utentes</asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="TotalMedics" runat="server"  > </asp:Label></td>
                 <td><asp:Label ID="TotalPharmacies" runat="server"  > </asp:Label></td>
                <td><asp:Label ID="TotalPatients" runat="server"  > </asp:Label></td>
            </tr>

</table>

</asp:Content>
