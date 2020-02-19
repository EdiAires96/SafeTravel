<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datepicker.aspx.cs" Inherits="DataTime.datepicker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <!--Requirement jQuery-->
	<script type="text/javascript" src="Scripts/jquery.min.js"></script>
	<!--Load Script and Stylesheet -->
	<script type="text/javascript" src="Scripts/jquery.simple-dtpicker.js"></script>
	<link type="text/css" href="Styles/jquery.simple-dtpicker.css" rel="stylesheet" />
	<!---->



</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="Text1" runat="server" ReadOnly="true"></asp:TextBox>
            <script type="text/javascript">
		    $(function(){
                $('*[id=Text1]').appendDtpicker({
                    "dateFormat": "DD/MM/YY h:m",
                    "futureOnly": true,
                    "autodateOnStart": false,
                    "locale": "pt"
                });

		    });
	</script>
        </div>
    </form>
</body>
</html>
