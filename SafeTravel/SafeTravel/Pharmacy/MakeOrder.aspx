<%@ Page Title="" Language="C#" MasterPageFile="~/Medic/Site2.Master" AutoEventWireup="true" CodeBehind="MakeOrder.aspx.cs" Inherits="SafeTravel.Pharmacy.MakeOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .grid td, .grid th
        {
            text-align:center;
         }
    </style>

       <script type="text/javascript" src="../Medic/Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="../Content/bootstrap.min.css" type="text/css"/>
    <script type="text/javascript" src="../Medic/Scripts/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>

    <script type="text/javascript" src="../Medic/Scripts/jquery.simple-dtpicker.js"></script>     
    <link type="text/css" href="../Styles/jquery.simple-dtpicker.css" rel="stylesheet" />
    <br />
    <br />

             <div id="NewOrderTitle" runat="server" class="ContentHead"><h1>Nova Encomenda</h1></div>

    <br />
    <br />

     <table>
            <tr>
                <td><label>Data de Encomenda: </label></td> 
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" style="margin-right:50px"></asp:TextBox>
                    <asp:TextBox ID="TextBoxOrderDate" runat="server" style="margin-right:50px" Visible="false" ></asp:TextBox>
                 </td>

                <script type="text/javascript">
                    $(document).ready(function () {
                        $("#<%=TextBox1.ClientID%>").appendDtpicker({
                            "dateFormat": "DD/MM/YYYY",
                            "futureOnly": true,
                            "autodateOnStart": false,
                            "locale": "pt",
                            "dateOnly": true
                        });

                    });
                    $(document).ready(function () {
                        $("#<%=TextBox2.ClientID%>").appendDtpicker({
                            "dateFormat": "DD/MM/YYYY",
                            "futureOnly": true,
                            "autodateOnStart": false,
                            "locale": "pt",
                            "dateOnly": true
                        });

                    });
                </script> 
                <td></td>
                <td><label>Data de Entrega: </label></td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoxDeliveryDate" runat="server" Visible="false" ></asp:TextBox>
                </td>
            </tr>
        </table>
    
    <br />
    <br />

    <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table>
                     <tr> 
                         <td>
                             <asp:Label runat="server" ID="lblListBox" Text="Produtos a encomendar:" Font-Bold="True" ></asp:Label>
                         </td>
                        
                        <td> 
                              <asp:ListBox ID="ListBoxProducts" runat="server" SelectionMode="Multiple"  class="btn btn-primary"
                                    ItemType="SafeTravel.Models.Product" DataTextField="p_name"
                                    SelectMethod="GetProducts" DataValueField="product_id"  OnSelectedIndexChanged="ListBoxProducts_SelectedIndexChanged"  AutoPostBack="True" > 
                            </asp:ListBox>
                        </td>
   
                            <script type="text/javascript">
                                function pageLoad() {
                                    $("#<%=ListBoxProducts.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });                                  
                                }
                             </script>        
                    </tr>
                </table>  
                <br />
                 <table>
                     <tr>
                         <td>
                            <asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" CellPadding="4"
                                CssClass="table table-striped table-bordered" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="center">
                                <RowStyle VerticalAlign="Middle" HorizontalAlign="center" />
                            
                                <Columns>
                                    <asp:BoundField DataField="product_id" HeaderText="Id" SortExpression="product_id" visible="false"/>  
                                    <asp:BoundField DataField="p_name" HeaderText="Produto" ItemStyle-Width="15%"  />
                                    <asp:TemplateField  HeaderText="Quantidade" ItemStyle-Width="20%">            
                                       <ItemTemplate>
                                          <asp:TextBox ID="howMany" runat="server" Width="40px" Text="<%#:1%>" style="text-align:center" ></asp:TextBox>
                                       </ItemTemplate>  
                                        </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td> 
                    </tr>
                </table>
                  
            </ContentTemplate>                
        </asp:UpdatePanel>
                                <asp:GridView ID="GridViewSeeProducts" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" CellPadding="4"
                                CssClass="table table-striped table-bordered grid" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="center">
                                <RowStyle VerticalAlign="Middle" HorizontalAlign="center"/>
                               <Columns>  
                                    <asp:BoundField DataField="p_name" HeaderText="Produto" ItemStyle-Width="15%"  />
                                     <asp:BoundField DataField="quantity" HeaderText="Quantidade" ItemStyle-Width="15%"  />
                                </Columns>
                            </asp:GridView>
            <br />
            <br />

    <table>
     <tr>
            <td>
                <asp:Label runat="server" ID="lblInfo" Text="Observações:" Font-Bold="True" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="info" runat="server" TextMode="MultiLine" Rows="4" Width="400px"></asp:TextBox>
                
            </td>
        </tr>
</table>
     <br />
     <br />
    <div >
       <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancelar" Width="150px" class="btn btn-primary" />
       <asp:Button ID="Save" runat="server" OnClick="AddNewOrder_Click" Text="Guardar" Width="150px" class="btn btn-primary" 
            style="margin-left:150px"/>
    </div>

    <div style="text-align:center">
             <asp:Button ID="back" runat="server" OnClick="Cancel_Click" Text="Voltar" Width="150px" class="btn btn-primary" Visible="false" />
    </div>


</asp:Content>
