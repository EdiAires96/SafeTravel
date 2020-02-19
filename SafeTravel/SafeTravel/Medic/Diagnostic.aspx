<%@ Page Title="" Language="C#" MasterPageFile="~/Medic/Site2.Master" AutoEventWireup="true" CodeBehind="Diagnostic.aspx.cs" Inherits="SafeTravel.Medic.Diagnostic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        

          
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../Medic/Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="../Content/bootstrap.min.css" type="text/css"/>
    <script type="text/javascript" src="../Medic/Scripts/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>

    <script type="text/javascript" src="../Medic/Scripts/jquery.simple-dtpicker.js"></script>     
    <link type="text/css" href="../Styles/jquery.simple-dtpicker.css" rel="stylesheet" />

         <style type="text/css">
        h1{
            margin-top:20px;
            margin-bottom:30px;
        }
        h2{
            margin-top:30px;
            margin-bottom:30px;
        }
        table {
            border-collapse: collapse;
            margin-top:10px;
        }

        td {
            padding-top: .7em;
            padding-bottom: .7em;
            padding-right: 1em;
        }
      
      </style>

    


    <h1>Diagonóstico do Utente</h1>

    <h2>Viagem</h2>

    <div id="trip">
        <table>
            <tr>
                <td><label>1.</label></td>
                <td><label>Data de Partida:</label></td> <td><asp:TextBox ID="tbBeginDate" runat="server"></asp:TextBox></td>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $("#<%=tbBeginDate.ClientID%>").appendDtpicker({
                            "dateFormat": "DD/MM/YYYY",
                            "futureOnly": true,
                            "autodateOnStart": false,
                            "locale": "pt",
                            "dateOnly": true
                        });

                    });
                    $(document).ready(function () {
                        $("#<%=tbEndDate.ClientID%>").appendDtpicker({
                            "dateFormat": "DD/MM/YYYY",
                            "futureOnly": true,
                            "autodateOnStart": false,
                            "locale": "pt",
                            "dateOnly": true
                        });

                    });
                </script> 
                <td></td>
                <td><label>Data de Chegada:</label></td><td><asp:TextBox ID="tbEndDate" runat="server"></asp:TextBox></td>
            </tr>
        </table>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table>
                     <tr> 
                         <td><label>2.</label></td>
                         <td>
                             <label>Qual o destino da sua viagem:</label>
                         </td>
                        
                        <td> 
                              <asp:ListBox ID="ListBoxRegions" runat="server" SelectionMode="Multiple"  class="btn btn-primary"
                                    ItemType="SafeTravel.Models.Region" DataTextField="r_name"
                                    SelectMethod="GetRegions" DataValueField="region_id"  OnSelectedIndexChanged="listBox1_SelectedIndexChanged"  AutoPostBack="True" > 
                            </asp:ListBox>
                        </td>
                        <td>
                            <asp:ListBox ID="ListBoxCountries" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                     OnSelectedIndexChanged="listBox2_SelectedIndexChanged" AutoPostBack="True" OnDataBound="DropDownList1_DataBound" > 
                            </asp:ListBox> 

                        </td>
                            <script type="text/javascript">
                                function pageLoad() {
                                    $("#<%=ListBoxRegions.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=List_Motives.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBoxCountries.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBoxAllergy.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBoxMedicines.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBoxAnticoagulant.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBox1.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBox2.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBox3.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBox4.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBox5.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBox6.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBox7.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBoxSick.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBoxVaccines.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                    $("#<%=ListBoxMalaria.ClientID%>").multiselect({
                                        includeSelectAllOption: true,
                                        enableFiltering: true
                                    });
                                   
                                    $(document).ready(function () {
                                        $(".dropdownAccomodation").each(function () {
                                            $(this).multiselect({
                                                includeSelectAllOption: true,
                                                enableFiltering: true
                                            }); 
                                        });
                                    });
                                    $(document).ready(function () {
                                        $(".checkin_datepick").each(function () {
                                            $(this).appendDtpicker({
                                                "dateFormat": "DD/MM/YYYY",
                                                "futureOnly": true,
                                                "autodateOnStart": false,
                                                "locale": "pt",
                                                "dateOnly": true

                                            });
                                        });
                                    });
                                    $(document).ready(function () {
                                        $(".checkout_datepick").each(function () {
                                            $(this).appendDtpicker({
                                                "dateFormat": "DD/MM/YYYY",
                                                "futureOnly": true,
                                                "autodateOnStart": false,
                                                "locale": "pt",
                                                "dateOnly": true
                                            });
                                        });
                                    });
                                    $(document).ready(function () {
                                        $(".date").each(function () {
                                            $(this).appendDtpicker({
                                                "dateFormat": "DD/MM/YYYY",
                                                "autodateOnStart": false,
                                                "locale": "pt",
                                                "dateOnly": true

                                            });
                                        });
                                    });

                                }
                             </script>        
                    </tr>
                </table>
                <table>
                     <tr>
                         <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" CellPadding="4"
                                CssClass="table table-striped table-bordered" OnDataBound="DropDownList2_DataBound" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="center">
                                <RowStyle VerticalAlign="Middle" HorizontalAlign="center" />
                            
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Id" SortExpression="id" visible="false"/>  
                                    <asp:BoundField DataField="name" HeaderText="País" ItemStyle-Width="15%"  />
                                    <asp:TemplateField  HeaderText="Localidade(s)" ItemStyle-Width="20%">            
                                       <ItemTemplate>
                                           <asp:TextBox runat="server" id="locals" TextMode="MultiLine"></asp:TextBox>
                                       </ItemTemplate>
                                        
                                       </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="Meio" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left">            
                                       <ItemTemplate>
                                           <asp:CheckBox ID="rural" runat="server" Text="rural"/><br />
                                           <asp:CheckBox ID="urbano" runat="server"  Text="urbano"/>
                                       </ItemTemplate>
                                        
                                       </asp:TemplateField>

                                    <asp:TemplateField  HeaderText="Alojamento" ItemStyle-Width="20%">            
                                       <ItemTemplate>
                                           <asp:ListBox ID="ListBoxAccomodation" runat="server" SelectionMode="Multiple"  class="dropdownAccomodation"> 
                                                <asp:ListItem Text="Hotel" Value="Hotel" />
                                                <asp:ListItem Text="Residêncial" Value="Residêncial" />
                                                <asp:ListItem Text="Casa" Value="Casa" />
                                                <asp:ListItem Text="Tenda" Value="Tenda" />
                                                <asp:ListItem Text="Bungalow" Value="Bungalow" />
                                               <asp:ListItem Text="Hostel" Value="Hostel" />
                                            </asp:ListBox> 
                                           <asp:TextBox ID="tbAccomodation" runat="server" Width="150px" ></asp:TextBox>
                                           <asp:Button ID="addAccomodation" runat="server" Text="Adicionar"  OnClick="addAccomodationClick"/>
                                       </ItemTemplate>
                                        
                                       </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="Atividades" ItemStyle-Width="20%">            
                                       <ItemTemplate>
                                           <asp:ListBox ID="ListBoxActivities" runat="server" SelectionMode="Multiple"  class="dropdownAccomodation"> 
                                               
                                            </asp:ListBox> 
                                           <asp:TextBox ID="tbActivities" runat="server" Width="150px"></asp:TextBox>
                                           <asp:Button ID="addActivities" runat="server" Text="Adicionar" OnClick="addActivitiesClick"/>
                                       </ItemTemplate>
                                        
                                       </asp:TemplateField>
                                    <asp:TemplateField  HeaderText="Chegada/Partida" ItemStyle-Width="20%">            
                                       <ItemTemplate>
                                            <asp:TextBox ID="checkin" runat="server" Text="" class="checkin_datepick" Width="150px" ></asp:TextBox>
                                           <br />
                                           <br />
                                            <asp:TextBox ID="checkout" runat="server" Text="" class="checkout_datepick" Width="150px"></asp:TextBox>
                                       </ItemTemplate>
                                        
                                       </asp:TemplateField>    
                                    
                                </Columns>
                                

                            </asp:GridView>
                        </td> 
                    </tr>
                </table>
            </ContentTemplate>
                        
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" >
            <ContentTemplate>
                                            
                <table>
                    <tr>
                        <td><label>3.</label></td>
                        <td>
                            <label>Motivo da Viagem:</label>
                        </td>
                        <td>
                            <asp:ListBox ID="List_Motives" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                     AutoPostBack="True"> 
                                <asp:ListItem Text="Trabalho" Value="Trabalho" />
                                <asp:ListItem Text="Aventura" Value="Aventura" />
                                <asp:ListItem Text="Lazer/Turismo" Value="Lazer/Turismo" />
                            </asp:ListBox>     
                        </td>
                        <td><label>Outro:</label></td>
                        <td>
                            <asp:TextBox ID="others_motives" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="add_motive" runat="server" Text="Adicionar"  OnClick="add_motive_click"/>
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
           </asp:UpdatePanel> 
         
        
    </div>

    <div>
        <h2>Estado de Saúde</h2>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
        
                <table>
                    <tr>
                       <td><label>4.</label></td> 
                        <td><label>É fumador(a):</label></td>
                        <td>
                            <asp:RadioButton ID="no_smoker" GroupName="gSmoker" runat="server" Text="Não"  OnCheckedChanged="smokerChange" AutoPostBack="true"/>
                        </td>
                        <td>                    
                            <asp:RadioButton ID="smoker" GroupName="gSmoker" runat="server" Text="Sim"  OnCheckedChanged="smokerChange" AutoPostBack="true"/>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td><label>5.</label></td>
                        <td>
                            <label>É alérgico (a) a algum medicamento, alimento, vacinas ou outros produtos:</label>
                        </td>
                        <td>
                            <asp:RadioButton ID="no_allergic" GroupName="gAllergic" runat="server" Text="Não" OnCheckedChanged="allergicChecked" AutoPostBack="true"/>
                        </td>
                        <td>
                            <asp:RadioButton ID="allergic" GroupName="gAllergic" runat="server" Text="Sim" OnCheckedChanged="allergicChecked" AutoPostBack="true"/>
                        </td>
                    </tr>
                  </table>
                <div runat="server" id="div5" visible="false">
                  <table> 
                    <tr>
                        <td>

                        </td>
                        <td>
                            <label>Se sim qual(is)</label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbAllergy" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="add_allergy" runat="server" Text="Adicionar"  OnClick="add_allergy_click"/>
                        </td>
                        <td>
                             <asp:ListBox ID="ListBoxAllergy" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                     AutoPostBack="True"> 
                           
                            </asp:ListBox>  
                        </td>
                    </tr>
                </table>
               </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td><label>6.</label></td>
                        <td>
                            <label>Toma habitualmente medicamentos ou faz algum tratamento médico regular:</label>
                        </td>
                        <td>
                            <asp:RadioButton ID="no_medicines" GroupName="gMedicines" runat="server" Text="Não" OnCheckedChanged="medicinesChecked" AutoPostBack="true"/>
                        </td>
                        <td>
                            <asp:RadioButton ID="medicines" GroupName="gMedicines" runat="server" Text="Sim" OnCheckedChanged="medicinesChecked" AutoPostBack="true"/>
                        </td>
                    </tr>
                    </table>

                    <div runat="server" id="div6" visible="false">
                       <table>
                            <tr>
                                <td>

                                </td>
                                <td>
                                    <label>Se sim qual(is)</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbMedicine" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="add_medicine" runat="server" Text="Adicionar"  OnClick="add_medicine_click"/>
                                </td>
                    
                                <td>
                                     <asp:ListBox ID="ListBoxMedicines" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                             AutoPostBack="True"> 
                           
                                    </asp:ListBox>  
                                </td>
                            </tr>
                        </table>

                        <table>

                            <tr>
                                <td>

                                </td>
                                <td>
                                    <label>Faz medicação anticoagulante:</label>
                                </td>
                                <td>
                                    <asp:RadioButton ID="no_anticoagulant" GroupName="gAnticoagulant" runat="server" Text="Não" OnCheckedChanged="anticoagulantChecked" AutoPostBack="true"/>
                                </td>
                                <td>
                                    <asp:RadioButton ID="anticoagulant" GroupName="gAnticoagulant" runat="server" Text="Sim" OnCheckedChanged="anticoagulantChecked" AutoPostBack="true"/>
                                </td>
                                <div runat="server" id="div6_2" visible="false">
                                    <td>
                                        <asp:TextBox ID="tbAnticoagulant" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="add_anticoagulant" runat="server" Text="Adicionar"  OnClick="add_anticoagulant_click"/>
                                    </td>
                    
                                    <td>
                                         <asp:ListBox ID="ListBoxAnticoagulant" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                                 AutoPostBack="True"> 
                           
                                        </asp:ListBox>  
                                    </td>
                                </div>
                            </tr>

                        </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server" ID="up1">
            <ContentTemplate>
                <table>
                    <tr>
                        <td><label>7.</label></td>
                        <td><label>Sofre ou já sofreu de alguma doença do:</label></td>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <label>Sistema neuropsiquiátrico (epilepsia, depressão, etc.)</label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="cb1Changed" AutoPostBack="true"/>
                        </td>
                        <div id="div7_1" runat="server" visible="false">
                            <td><label>Qual(is)</label></td>
                            <td><input id="Text1" type="text" runat="server"/></td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Adicionar" onClick="ButtonClick1"/>
                            </td>
                             <td>
                                 <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                           
                                </asp:ListBox>  
                            </td>
                        </div>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <label>Sistema cardiovascular (coração, HTA, etc.)</label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="cb2Changed" AutoPostBack="true"/>
                        </td>
                        <div runat="server" id="div7_2" visible="false">
                            <td><label>Qual(is)</label></td>
                            <td><input id="Text2" type="text" runat="server"/></td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="Adicionar"  onClick="ButtonClick2"/>
                            </td>
                             <td>
                                 <asp:ListBox ID="ListBox2" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                           
                                </asp:ListBox>  
                            </td>
                        </div>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <label>Sistema respiratório (pulmões)</label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="true" OnCheckedChanged="cb3Changed"/>
                        </td>
                        <div runat="server" id="div7_3" visible="false">
                            <td><label>Qual(is)</label></td>
                             <td><input id="Text3" type="text" runat="server"/></td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="Adicionar" onClick="ButtonClick3"/>
                            </td>
                             <td>
                                 <asp:ListBox ID="ListBox3" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                           
                                </asp:ListBox>  
                            </td>
                        </div>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <label>Sistema digestivo (doença inflamatória intestinal, hepatite, etc.)</label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="true" OnCheckedChanged="cb4Changed"/>
                        </td>
                        <div runat="server" id="div7_4" visible="false">
                            <td><label>Qual(is)</label></td>
                             <td><input id="Text4" type="text" runat="server"/></td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="Adicionar" onClick="ButtonClick4"/>
                            </td>
                             <td>
                                 <asp:ListBox ID="ListBox4" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                           
                                </asp:ListBox>  
                            </td>
                        </div> 
                    </tr>
                     <tr>
                        <td>

                        </td>
                        <td>
                            <label>Sistema endocrinológico (diabetes, doenças da tiróide, etc.)</label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="true" OnCheckedChanged="cb5Changed"/>
                        </td>
                         <div runat="server" id="div7_5" visible="false">
                             <td><label>Qual(is)</label></td>
                              <td><input id="Text5" type="text" runat="server"/></td>
                            <td>
                                <asp:Button ID="Button5" runat="server" Text="Adicionar" onClick="ButtonClick5"/>
                            </td>
                             <td>
                                 <asp:ListBox ID="ListBox5" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                           
                                </asp:ListBox>  
                            </td>
                         </div>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <label>Sistema urogenital (doenças renais crónicas)</label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="true" OnCheckedChanged="cb6Changed"/>
                        </td>
                        <div runat="server" id="div7_6" visible="false">
                            <td><label>Qual(is)</label></td>
                             <td><input id="Text6" type="text" runat="server"/></td>
                            <td>
                                <asp:Button ID="Button6" runat="server" Text="Adicionar" onClick="ButtonClick6"/>
                            </td>
                             <td>
                                 <asp:ListBox ID="ListBox6" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                           
                                </asp:ListBox>  
                            </td>
                        </div>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <label>Outras</label>
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="true" OnCheckedChanged="cb7Changed"/>
                        </td>
                        <div runat="server" id="div7_7" visible="false">
                            <td><label>Qual(is)</label></td>
                             <td><input id="Text7" type="text" runat="server"/></td>
                            <td>
                                <asp:Button ID="Button7" runat="server" Text="Adicionar" onClick="ButtonClick7"/>
                            </td>
                             <td>
                                 <asp:ListBox ID="ListBox7" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                           
                                </asp:ListBox>  
                            </td>
                        </div>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td><label>8.</label></td>
                        <td><label>Já realizou alguma(s) operação(ões) cirúrgica(s):</label></td>
                         <td>
                            <asp:RadioButton ID="noCirurgy" runat="server" Text="Não" GroupName="gCirurgy" AutoPostBack="true" OnCheckedChanged="cirurgyChecked"/>
                        </td>
                        <td>
                            <asp:RadioButton ID="Cirurgy" runat="server" Text="Sim" GroupName="gCirurgy" AutoPostBack="true" OnCheckedChanged="cirurgyChecked"/>
                        </td>
                    </tr>
                  </table>
                 <div runat="server" id="div8" visible="false">
                      <table>
                        <tr>
                            <td>

                            </td>
                            <td>
                                <label>Se sim, indique qual(ais) e refira o ano:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbcirurgy" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="add_cirurgy" runat="server" Text="Adicionar"  OnClick="add_cirurgy_click"/>

                            </td>
                            <td>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" CellPadding="4"
                                    CssClass="table table-striped table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="cirurgy" HeaderText="Cirurgia" />
                                        <asp:TemplateField  HeaderText="Ano">            
                                           <ItemTemplate>
                                                <asp:TextBox ID="year" runat="server" Text="" class="year"></asp:TextBox>
                                           
                                           </ItemTemplate>
                                        
                                           </asp:TemplateField>    
                                    
                                    </Columns>
                                

                                </asp:GridView>
                            </td>
                        </tr>
                    
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td><label>9.</label></td>
                    <td><label>Esteve recentemente doente:</label></td>
                    
                        <td>
                            <asp:RadioButton ID="no_sick" GroupName="gSick" runat="server" Text="Não" OnCheckedChanged="sickChecked" AutoPostBack="true"/>
                        </td>
                        <td>
                            <asp:RadioButton ID="sick" GroupName="gSick" runat="server" Text="Sim" OnCheckedChanged="sickChecked" AutoPostBack="true"/>
                        </td>
                </tr>
            </table>
            <div runat="Server" id="div9" visible="false">
                <table>
                    <tr>
                        <td></td>
                        <td><label>Se sim, com que doença(s)</label></td>
                        <td>
                            <asp:TextBox ID="tbSick" runat="server"></asp:TextBox>

                        </td>
                        <td>
                            <asp:Button ID="addSick" runat="server" Text="Adicionar" OnClick="addSickClick"/>
                        </td>
                        <td>
                             <asp:ListBox ID="ListBoxSick" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                           
                             </asp:ListBox>  
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td><label>10.</label></td>
                    <td><label>Que vacinações realizou nos últimos 10 anos:</label></td>
                </tr>
                </table>
                <table>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <asp:ListBox ID="ListBoxVaccines" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"  OnSelectedIndexChanged="vaccineChanged"> 
                                <asp:ListItem Text="Não sabe" Value="Não Sabe" />
                                <asp:ListItem Text="BCG" Value="BCG" />
                                <asp:ListItem Text="Cólera" Value="Cólera" />
                                <asp:ListItem Text="Difteria" Value="Difteria" />
                                <asp:ListItem Text="Encefalite Japonesa b" Value="Encefalite Japonesa b" />
                                <asp:ListItem Text="Febre amarela" Value="Febre amarela" />
                                <asp:ListItem Text="Febre tifóide" Value="Febre tifóide" />
                                <asp:ListItem Text="Hepatite A" Value="Hepatite A" />
                                <asp:ListItem Text="Hepatite B" Value="Hepatite B" />
                                <asp:ListItem Text="Meningite" Value="Meningite" />
                                <asp:ListItem Text="Papeira" Value="Papeira" />
                                <asp:ListItem Text="Polio" Value="Polio" />
                                <asp:ListItem Text="Raiva" Value="Raiva" />
                                <asp:ListItem Text="Sarampo" Value="Sarampo" />
                                <asp:ListItem Text="Tétano" Value="Tétano" />
                            </asp:ListBox>     
                        </td>
                        <td><label>Outra:</label></td>
                        <td>
                            <asp:TextBox ID="tbVaccines" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="addVaccine" runat="server" Text="Adicionar"  OnClick="addVaccineClick"/>
                        </td>
                        <td>
                            <asp:GridView ID="GridViewVaccines" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" CellPadding="4"
                                        CssClass="table table-striped table-bordered">
                                        <Columns>
                                            <asp:BoundField DataField="vaccine" HeaderText="Vacina" />
                                            <asp:TemplateField  HeaderText="Data">            
                                               <ItemTemplate>
                                                    <asp:TextBox ID="date" runat="server" Text="" class="date"></asp:TextBox>
                                           
                                               </ItemTemplate>
                                        
                                               </asp:TemplateField>    
                                    
                                        </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td><label>11.</label></td>
                    <td><label>É a 1ª vez que viaja para fora do país:</label></td>
                    <td>
                         <asp:RadioButton ID="noFirstTime" GroupName="gFristTime" runat="server" Text="Não" />
                    </td>
                    <td>
                         <asp:RadioButton ID="fristTime" GroupName="gFristTime" runat="server" Text="Sim" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td><label>12.</label></td>
                    <td><label>Alguma vez se sentiu doente durante ou após viagens para fora do país:</label></td>
                    <td>
                         <asp:RadioButton ID="noSickTraveling" GroupName="gSickTraveling" runat="server" Text="Não" OnCheckedChanged="sickTravellingChecked" AutoPostBack="true"/>
                    </td>
                    <td>
                         <asp:RadioButton ID="sickTraveling" GroupName="gSickTraveling" runat="server" Text="Sim" OnCheckedChanged="sickTravellingChecked" AutoPostBack="true"/>
                    </td>    
                </tr>
            </table>
            <div runat="server" id="div11" visible="false">
                <table>
                    <tr>
                        <td></td>
                        <td><label>Se sim, que doença(s):</label></td>
                        <td>
                            <asp:TextBox ID="tbSickTravelling" runat="server"></asp:TextBox>

                        </td>
                        <td>
                            <asp:Button ID="addSickTravelling" runat="server" Text="Adicionar" OnClick="addSickTravellingClick" />
                        </td>
                        <td>
                            <asp:GridView ID="GridViewSickTravelling" runat="server" AutoGenerateColumns="False"  GridLines="Vertical" CellPadding="4"
                                        CssClass="table table-striped table-bordered">
                                        <Columns>
                                            <asp:BoundField DataField="SickTravelling" HeaderText="Doenças" />
                                            <asp:TemplateField  HeaderText="Tratamento">            
                                               <ItemTemplate>
                                                    <asp:TextBox ID="treatment" runat="server" Text=""></asp:TextBox>
                                           
                                               </ItemTemplate>
                                        
                                               </asp:TemplateField>    
                                    
                                        </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td><label>13.</label></td>
                    <td><label>Já tomou algum medicamento para evitar o paludismo (= malária)</label></td>
                    <td>
                         <asp:RadioButton ID="noMalaria" GroupName="gMalaria" runat="server" Text="Não" OnCheckedChanged="malariaChecked" AutoPostBack="true"/>
                    </td>
                    <td>
                         <asp:RadioButton ID="malaria" GroupName="gMalaria" runat="server" Text="Sim" OnCheckedChanged="malariaChecked" AutoPostBack="true"/>
                    </td>    
                </tr>
            </table>
            <div runat="server" id="div12" visible="false">
                <table>
                    <tr>
                        <td></td>
                        <td><label>Se sim, qual:</label></td>
                        <td>
                            <asp:TextBox ID="tbMalaria" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="addMalaria" runat="server" Text="Adicionar" onClick="addMalariaClick"/>
                        </td>
                        <td>
                             <asp:ListBox ID="ListBoxMalaria" runat="server" SelectionMode="Multiple"  class="dropdown-menu"
                                         AutoPostBack="True"> 
                            </asp:ListBox>      
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <label>Gênero:</label>
                    </td>
                    <td>
                         <asp:RadioButton ID="male" GroupName="gGenre" runat="server" Text="M" OnCheckedChanged="genreChecked" AutoPostBack="true"/>
                    </td>
                    <td>
                         <asp:RadioButton ID="female" GroupName="gGenre" runat="server" Text="F" OnCheckedChanged="genreChecked" AutoPostBack="true"/>
                    </td>    
                </tr>
            </table>
            <div id="div13" runat="server" visible="false">
                <h2>Questões específicas para utentes do sexo feminino</h2>
                <table>
                    <tr>
                        <td><label>14.</label></td>
                        <td><label>Utiliza pílula anticoncepcional:</label></td>
                        <td>
                             <asp:RadioButton ID="noPill" GroupName="gPill" runat="server" Text="Não" OnCheckedChanged="pillChecked" AutoPostBack="true"/>
                        </td>
                        <td>
                             <asp:RadioButton ID="pill" GroupName="gPill" runat="server" Text="Sim" OnCheckedChanged="pillChecked" AutoPostBack="true"/>
                        </td>
                        <div id="div14" runat="server" visible="false">
                            <td>
                                <label>Se sim, há quanto tempo:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbPill" runat="server"></asp:TextBox>
                            </td>
                        </div>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td><label>15.</label></td>
                        <td><label>Tem história de infertilidade:</label></td>
                        <td>
                             <asp:RadioButton ID="noInfertility" GroupName="gInfertility" runat="server" Text="Não" OnCheckedChanged="infertilityChecked" AutoPostBack="true"/>
                        </td>
                        <td>
                             <asp:RadioButton ID="infertility" GroupName="gInfertility" runat="server" Text="Sim" OnCheckedChanged="infertilityChecked" AutoPostBack="true"/>
                        </td>
                        <div id="div15" runat="server" visible="false">
                            <td><lable>Se sim, está a tentar engravidar:</lable></td>
                            <td>
                                <asp:RadioButton ID="noGetPregnant" GroupName="gGetPregnant" runat="server" Text="Não" />
                             </td>
                             <td>
                                <asp:RadioButton ID="getPregnant" GroupName="gGetPregnant" runat="server" Text="Sim" />
                            </td>
                        </div>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td><label>16.</label></td>
                        <td><label>Está grávida:</label></td>
                        <td>
                             <asp:RadioButton ID="noPregnant" GroupName="gPregnat" runat="server" Text="Não" OnCheckedChanged="pregnantChecked" AutoPostBack="true"/>
                        </td>
                        <td>
                             <asp:RadioButton ID="pregnat" GroupName="gPregnant" runat="server" Text="Sim" OnCheckedChanged="pregnantChecked" AutoPostBack="true"/>
                        </td>
                        <div id="div16" runat="server" visible="false">
                            <td>
                                <label>Se sim, número de semanas:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="tbPregnant" runat="server"></asp:TextBox>
                            </td>
                        </div>
                    </tr>
                </table>
                <table>
                    <tr>
                       <td><label>17.</label></td>
                        <td><label>Espera engravidar nos próximos 3 meses:</label></td>
                         <td>
                            <asp:RadioButton ID="noGetPregnant3" GroupName="gGetPregnant3" runat="server" Text="Não" />
                         </td>
                         <td>
                             <asp:RadioButton ID="getPregnant3" GroupName="gGetPregnant3" runat="server" Text="Sim" />
                         </td>
                    </tr>
                </table>
                 <table>
                    <tr>
                       <td><label>18.</label></td>
                        <td><label>Encontra-se em fase de amamentação:</label></td>
                         <td>
                            <asp:RadioButton ID="noBreastfeeding" GroupName="gbreastfeeding" runat="server" Text="Não" />
                         </td>
                         <td>
                             <asp:RadioButton ID="breastfeeding" GroupName="gbreastfeeding" runat="server" Text="Sim" />
                         </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <br />
        <asp:Button ID="Cancel" runat="server" Text="Cancelar" Width="150px" class="btn btn-primary" CausesValidation="false" OnClick="cancelClick"/>
       <asp:Button ID="Next" runat="server" Text="Seguinte" Width="150px" class="btn btn-primary" CausesValidation="true"
            style="margin-left:400px" OnClick="nextClick"/>
    </div>
</asp:Content>
