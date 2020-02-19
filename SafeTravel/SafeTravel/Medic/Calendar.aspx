

<%@ Page Title="" Language="C#" MasterPageFile="~/Medic/Site2.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="SafeTravel.Medic.Calendar" %>

   <asp:Content ID="Content" ContentPlaceHolderID="head" runat="server">
    	

	    
	
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--Load Script and Stylesheet -->
	<script type="text/javascript" src="../Scripts/jquery.min.js"></script>
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

        .auto-style1 {
            width: 609px;
        }

        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #345578;
            padding: 0;
        }
        .modalPopup .header
        {
            color: #ffffff;
            background-color: #446e9b;
            border-color: #446e9b;
            height: 50px;
            color: White;
            line-height: 50px;
            text-align: center;
            font-size:20px;
            font-weight: bold;
    
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
            margin-bottom: 10px;
            margin-left:10px;
           
        }
        
    </style>



            <h1> Agenda </h1> 
             <div>
                 <asp:Button ID="agending" runat="server" Text="Nova Consulta" class="btn btn-primary" 
                    style="margin-left:950px; width:180px; " OnClick="agendingClick"/>

                 
                 <div>

                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
                        PopupControlID="pnlPopup" TargetControlID="agending" BackgroundCssClass="modalBackground"
                        >
                    </ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none" Width="450px">
                        <div class="header">
                            Marcar Consulta
                        </div>
                        
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="body">
                                        <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lnumber" runat="server" Text="Número de Utente:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tnumber" runat="server" OnTextChanged="tNumberChange" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lname" runat="server" Text="Nome:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tname" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="ldate" runat="server" Text="Data:" ></asp:Label>
                                            </td>
                                            <td >
                                                <asp:TextBox ID="tdate" runat="server" Text="DD/MM/AAAA"></asp:TextBox>
                                                <script type="text/javascript">
                                                    function pageLoad() {
                                                        $(document).ready(function () {
                                                            $("#<%=tdate.ClientID%>").appendDtpicker({
                                                                "dateFormat": "DD/MM/YYYY hh:mm",
                                                                "futureOnly": true,
                                                                "autodateOnStart": false,
                                                                "locale": "pt"
                                                            });

                                                        });
                                                    }
                                                </script> 
                                           
                                            </td>
                                            <td>
                                                <asp:Image  ID="icalendar" runat="server" ImageUrl="~/Images/calendar.png" BorderStyle="None" Width="30px" Height="30px"/>
                                          
                                            </td>
                                        
                                        </tr>
                                       <tr>
                                            <td>
                                                <asp:Label ID="lobs" runat="server" Text="Observações:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tobs" runat="server"  TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                       <tr>
                                            <asp:Label ID="lerror" runat="server" Text="" Style="color:red"></asp:Label>
                                       </tr>

                                    </table>
                                   </div>
                                    <div id="btn" style="margin-bottom:10px; margin-left:155px" >
                                        <asp:Button ID="btnHide" runat="server" Text="Cancelar" class="btn btn-primary" OnClick="Cancel_Click"/>
                                        <asp:Button ID="btnAdd" runat="server" Text="Marcar" OnClick="Add_Click"  class="btn btn-primary" style="margin-left:60px"/>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                               
                        
                            
                    </asp:Panel>
                 </div>
            </div>
   

			<table id="calendar">
				<tr>
					<td>
						<asp:Calendar id="Calendar1" runat="server" BackColor="White" Width="686px"
							ForeColor="Black" Height="369px" Font-Size="9pt" Font-Names="Verdana" BorderColor="White" BorderWidth="1px" NextPrevFormat="FullMonth" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged">
							<TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
							<NextPrevStyle VerticalAlign="Bottom" Font-Bold="True" Font-Size="10pt" ForeColor="#333333"></NextPrevStyle>
							<DayHeaderStyle Font-Size="10pt" Font-Bold="True"></DayHeaderStyle>
							<SelectedDayStyle ForeColor="White" BackColor="#333399" Font-Bold="True"></SelectedDayStyle>
							<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="White" BorderWidth="4px" Font-Size="12pt" ForeColor="#333399"></TitleStyle>
							<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
						</asp:Calendar>
					</td>
					<td class="auto-style1">
						<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" AutoGenerateColumns="False" Width="469px" ForeColor="#333333" GridLines="None">
							<SelectedItemStyle Font-Bold="True" ForeColor="#333333" BackColor="#E2DED6"></SelectedItemStyle>
							<ItemStyle ForeColor="#333333" BackColor="#F7F6F3"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#5D7B9D"></HeaderStyle>
							<EditItemStyle BackColor="#999999" />
							<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
							<AlternatingItemStyle BackColor="White" ForeColor="#284775" />
							<Columns>
                                <asp:BoundColumn DataField="id" HeaderText="Id"  Visible="false"/>
                                <asp:BoundColumn DataField="Time" HeaderText="Hora" />
                                <asp:HyperLinkColumn DataNavigateUrlField="id"  DataTextField="Patient" HeaderText="Utente" DataNavigateUrlFormatString="MedicEditAndGoto.aspx?patientID={0}" />
                                <asp:BoundColumn DataField="obs" HeaderText="Observações" />
								
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#284775"></PagerStyle>
						</asp:DataGrid>
        </table>
</asp:Content>
