<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="StockManagementSystem.UI.ItemSetupUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Item Setup</title>
    <link href="../css/reset.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&display=swap" rel="stylesheet">
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/content-area.css" rel="stylesheet" />
     <style> label.error{ color: red } </style>
</head>
<body>

<!--/* Side Bar */-->
<section id="sideMenu">
    <div id="Logo"><img src="../Resources/Logo.png" /></div>
    <div class="sidebar">
        <nav>
            <ul>
                <li><a href="IndexUI.aspx">Home</a></li>
                <li><a href="CategorySetupUI.aspx">Category Setup</a></li>
                <li><a href="CompanySetupUI.aspx">Company Setup</a></li>
                <li><a href="ItemSetupUI.aspx">Item Setup</a></li>
                <li><a href="StockInUI.aspx">Stock In</a></li>
                <li><a href="StockOutUI.aspx">Stock Out</a></li>
                <li><a href="SearchViewUI.aspx">Search</a></li>
                <li><a href="ViewSaleUI.aspx">Sales</a></li>
           </ul>
        </nav>
    </div>
</section>
    
<!--/* Header Banner */-->
<header>
    <div class="header">
        <h1>STOCK MANAGEMENT SYSTEM</h1>
    </div>
</header>
 
 <!--/* Header */-->
<div class="content-area">
    <div class="heading">
        <h1>Item Setup</h1>
    </div>   
  
    <!--/* Logout */-->    
    <div class="Logout">
        <button type="button" class="logoutbutton" runat="server" OnServerClick="logOutButton_Click">Logout</button>
    </div>  
          
<!--/* Main Content*/-->
    <div class="contents">
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Category:"></asp:Label> </td>
            <td>
                <asp:DropDownList ID="categoryDropDownList" runat="server" Width="250px" Height="25px"></asp:DropDownList><br/><br/> </td>
        </tr> 

        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Company:"></asp:Label> </td>
            
              <td>  <asp:DropDownList ID="companyDropDownList" runat="server" Width="250px" Height="25px"></asp:DropDownList><br/><br/> </td>
        </tr>

        <tr>
            <td> <asp:Label ID="Label3" runat="server" Text="Item Name:"></asp:Label> </td>
            <td>
                <asp:TextBox ID="itemNameTextBox" runat="server" Width="250px" Height="25px"></asp:TextBox><br/><br/> </td>
        </tr>

        <tr>
            <td> <asp:Label ID="Label4" runat="server" Text="Reorder Level:"></asp:Label>&nbsp;</td>
            <td> <asp:TextBox ID="reOrderLevelTextBox" value="0" runat="server" Width="250px" Height="25px"></asp:TextBox><br/><br/></td>
        </tr>
        <tr>
            <td> </td>
            <td>
                <asp:Button ID="saveButton" runat="server" Text="Save" Font-Bold="True" Width="100px" Height="30px" OnClick="saveButton_Click" /></td>
        </tr>
    </table>
    </div>
        <br/>
        <asp:Label ID="messageLabel" runat="server" > </asp:Label>
        <asp:Label ID="messageLabel1" runat="server" > </asp:Label>


        <asp:HiddenField ID="idHiddenField" runat="server" />

      </form> <br/>
        
       <%--   <a href="IndexUI.aspx" >Home</a>--%>

    <script src="../Scripts/jquery-3.4.1.min.js"></script> 

    <script src="../Scripts/jquery.validate.js"></script>

    <script type="text/javascript" >
        $().ready(function () {



           
            $.validator.addMethod(
               "regex",

               function (value, element, regexp) {
                   var re = new RegExp(regexp);
                   return this.optional(element) || re.test(value);
               },
               "Please check your input."
       );
            $("#form1").validate({
                rules: {
                    reOrderLevelTextBox: {

                        required: true,
                        regex: /^[0-9]\d*$/,

                    },
                    itemNameTextBox : {
                        required: true,
                    }

                   


                }


                 ,
                messages: {

                    reOrderLevelTextBox: {

                        required: "Empty reorder level ",
                        regex: "You must enter any positive integer ",
                    },



                }


            })
        });

    </script>

</div>
</div>

</body>
</html>
