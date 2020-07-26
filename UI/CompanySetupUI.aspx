<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockManagementSystem.UI.CompanySetupUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Company Setup</title>
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
        <h1>Company Setup</h1>
    </div>  
    
  <!--/* Logout */-->    
  <div class="Logout">
        <button type="button" class="logoutbutton" runat="server" OnServerClick="logOutButton_Click">Logout</button>
  </div>  
    
 <!--/* Main Content*/-->
    <div class="contents">
    <form id="companyForm" runat="server">
    <div id="namediv">

        <table>
            <tr>
                <td> <asp:Label ID="nameLabel" runat="server" Text="Name:"></asp:Label>&nbsp; </td>
                <td> <asp:TextBox ID="nameTextBox" runat="server" Width="250px" Height="25px"></asp:TextBox><br/><br/></td>
             </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="saveButton" CssClass="button" runat="server" Text="Save" Font-Bold="True" Width="100px" Height="30px" OnClick="saveButton_Click" /><br/><br/></td>
                </tr>

        </table>


 <!--/* Gridview */-->
    </div>
        <div>
            <asp:GridView ID="companyGridView"  AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  Width="320px">

                <AlternatingRowStyle BackColor="White" />

            <Columns>

                <asp:TemplateField HeaderText="SL No"> 
                    <ItemTemplate> <%# Container.DataItemIndex+1 %> </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name" />
            </Columns>

            </asp:GridView>
        </div>
        <br/>
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
    </form>
        
    <%--  <br/><a href="IndexUI.aspx" > Home </a>--%>
  
   </div>
</div>

    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
     <script type="text/javascript">
         $().ready(function () {





             $("#companyForm").validate({
                 rules: {
                     nameTextBox: "required"



                 }


                  ,
                 messages: {

                     nameTextBox: {

                         required: "Empty Company",

                     },



                 }


             })
         });
    </script>
</body>
</html>
