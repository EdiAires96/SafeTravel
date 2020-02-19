<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuildKit.aspx.cs" Inherits="SafeTravel.Medic.BuildKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .grid td, .grid th
        {
            text-align:center;
         }
    </style>
    <!-- CssClass="table table-striped table-bordered" 
        Gridview
        
        -->

         <div id="Titles" runat="server" class="ContentHead"> 
           <h1 style="float:left" >Lista de Produtos </h1>
           <h1 style="margin-left:700px" > Kit Médico </h1>
         </div>
    <table>
        <tr>
         <td>
               <div id="divProducts" style="width:600px" >  <!-- LEFT DIV -->
                   <asp:TextBox ID="textSearch" runat="server" style="margin-bottom:20px; margin-right:20px; margin-top:20px" ></asp:TextBox> 
                   <asp:Button ID="search" runat="server" Text="Procurar" OnClick="Search_Click" style="margin-bottom:20px; margin-top:20px; margin-right:20px;" Width="100px" />
                   <asp:Button ID="reset" runat="server" Text="Reset" OnClick="Reset_Click" style="margin-bottom:20px; margin-top:20px" Width="100px" />  

                    <asp:GridView ID="TotalProducts" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
                            ItemType="SafeTravel.Models.Product" SelectMethod="GetProducts" OnRowCommand="row_command"
                            CssClass="table table-striped table-bordered grid" >
                    
                             <Columns>
                            <asp:BoundField DataField="product_id" HeaderText="Id" SortExpression="product_id" visible="false"/>        
                            <asp:BoundField DataField="p_name" HeaderText="Nome" ItemStyle-HorizontalAlign="Center" /> 
                                 <asp:TemplateField HeaderText="Quantidade final">
                                     <ItemTemplate>
                                         <asp:TextBox ID="howMany" runat="server" Width="40px" Text="<%#:1%>" style="text-align:center" ></asp:TextBox>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                            <asp:ButtonField ButtonType="Button" CommandName="add" Text="Confirmar" HeaderText="Adicionar ao kit médico" ItemStyle-HorizontalAlign="Center" />
                            <asp:ButtonField ButtonType="Button" CommandName="remove" Text=" X " HeaderText="Remover" ItemStyle-HorizontalAlign="Center" />
                            </Columns>
    
                        </asp:GridView>

                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Visible="false" OnRowCommand="row_command2" 
                        CssClass="table table-striped table-bordered grid" >
                    <Columns>
                        <asp:BoundField DataField="product_id" HeaderText="Id" SortExpression="product_id" visible="false"/>   
                        <asp:BoundField DataField="p_name" HeaderText="Nome" />
                        <asp:TemplateField HeaderText="Quantidade final">
                        <ItemTemplate>
                         <asp:TextBox ID="howMany" runat="server" Width="40px" Text="<%#:1%>" style="text-align:center" ></asp:TextBox>
                         </ItemTemplate>
                          </asp:TemplateField>
                            <asp:ButtonField ButtonType="Button" CommandName="add" Text="Confirmar" HeaderText="Adicionar ao kit médico" ItemStyle-HorizontalAlign="Center" />
                            <asp:ButtonField ButtonType="Button" CommandName="remove" Text=" X " HeaderText="Remover" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
    </asp:GridView>
                   <br>
                    <asp:Label ID="lblAddNew" runat="server" Text="Adicionar outro produto: " style="margin-bottom:50px" withd="100px" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    <asp:Label ID="lblRemove" runat="server" Text="Remover produto do kit " style="margin-bottom:50px; margin-left:170px" withd="100px" Font-Bold="True" Font-Size="Medium"></asp:Label>
                   <br/>
                     <br>
                     <asp:Label ID="lblNome" runat="server" Text="Nome do produto " style="margin-bottom:20px"></asp:Label>
                      <asp:Label ID="lblQuant" runat="server" Text="Quantidade " style="margin-bottom:20px; margin-left:50px"></asp:Label>
                   <br/>
                    <asp:TextBox ID="newKitProduct" runat="server" style="margin-bottom:20px; margin-right:20px; margin-top:10px" ></asp:TextBox>
                    <asp:TextBox ID="newKitProductQuant" runat="server" style="margin-bottom:20px; margin-right:20px; margin-top:20px; text-align:center" Width="40px" Text="<%#:1%>" ></asp:TextBox> 
                   <asp:Button ID="addNewKitProduct" runat="server" Text="Adicionar" OnClick="AddNewKitProduct_Click" style="margin-bottom:20px; margin-top:20px;" />

                   <asp:DropDownList ID="DropDownList1" runat="server"  style="margin-bottom:20px; margin-top:20px; margin-left:25px" Width="140px" ></asp:DropDownList>
                    <asp:Button ID="RemoveKitProduct" runat="server" Text="Remover" OnClick="RemoveKitProduct_Click" style="margin-bottom:20px; margin-top:20px; margin-left:10px"/>

                   <asp:Label ID="lblDropItem" runat="server" Text="Label" Visible="false" ></asp:Label>

                   </div>
        </td>
        <td style="padding-left:50px">
            <asp:Label ID="emptyKit" runat="server" Text="O kit ainda não tem productos!" Font-Bold="True" Font-Size="Large" Visible="false" ></asp:Label>
                
            
                <div id="divKit" style="width:700px" >  <!-- RIGHT DIV -->
                   <asp:DataGrid id="DataGrid" runat="server" CellPadding="4" AutoGenerateColumns="False" Width="500px" ForeColor="#333333" GridLines="None">
				    <SelectedItemStyle Font-Bold="True" ForeColor="#333333" BackColor="#E2DED6"></SelectedItemStyle>
				    <ItemStyle ForeColor="#333333" BackColor="#F7F6F3"></ItemStyle>
				    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#5D7B9D"></HeaderStyle>
				    <EditItemStyle BackColor="#999999" />
				    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
				    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
				    <Columns>
                         <asp:BoundColumn DataField="Name" HeaderText="Produto" /> 
                         <asp:BoundColumn DataField="Quantity" HeaderText="Quantidade" /> 
				    </Columns>
				    <PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#284775"></PagerStyle>
			    </asp:DataGrid>
            </div>
    </td>
  </table>
    <br>
    <br/>
    <div style="text-align:center">
             <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancelar" Width="150px" class="btn btn-primary" />
            <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Confirmar" Width="150px" class="btn btn-primary" 
                    style="margin-left:150px"/>
    </div>
    

                             <!--
                            <asp:TemplateField   HeaderText="Quantidade">            
                                <ItemTemplate>
                                     <asp:TextBox ID="howMany" Width="40" runat="server" Text="<%#:1%>" ></asp:TextBox> 
                                </ItemTemplate>        
                            </asp:TemplateField>  
                                 -->
  
</asp:Content>



