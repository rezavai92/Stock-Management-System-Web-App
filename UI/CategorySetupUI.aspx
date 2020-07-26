<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySetupUI.aspx.cs" Inherits="StockManagementSystem.UI.CategorySetupUI"  EnableEventValidation="false" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Category Setup</title>
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

<header>
    <div class="header">
        <h1>STOCK MANAGEMENT SYSTEM</h1>
    </div>
</header>



 <!--/* Main Content*/-->
<div class="content-area">
    <div class="heading">
        <h1>Category Setup</h1>
    </div> 
    
    <!--/* Logout */-->    
    <div class="Logout">
        <button type="button" class="logoutbutton" runat="server" OnServerClick="logOutButton_Click" >Logout</button>
    </div>
    
    
        <div class="contents">
            <form id="categoryForm" runat="server">
                <div id="namediv">
        <table>
            <tr>  
                <td>
                    <asp:Label  ID="Label1" runat="server" Text="Name: "></asp:Label> &nbsp;</td>
                <td><asp:TextBox ID="nameTextBox"  runat="server" Width="250px" Height="25px"></asp:TextBox><br/><br/> </td>
                </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="saveButton" runat="server" cssclass="button" Text="Save" Font-Bold="True" Width="100px" Height="30px" OnClick="saveButton_Click" /><br/><br/> </td>
            </tr>
        </table>

                </div>

    
            
 <!--/* Gridview */-->
        <div>
            <asp:GridView ID="categoryGridView"  DataKeyNames="Id" AutoGenerateColumns="false"  runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="categoryGridView_SelectedIndexChanged" OnRowDataBound="categoryGridView_RowDataBound" OnRowCommand="categoryGridView_RowCommand"  Width="320px">

                <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                <Columns>

                     <asp:TemplateField HeaderText="SL No">
                        <ItemTemplate> <%# Container.DataItemIndex+1%> </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField  DataField="Name" HeaderText="Name" />

                    <asp:CommandField SelectText="Select" ShowSelectButton="true" Visible="false" />
                </Columns>
            </asp:GridView>
        </div>

               <br/>
        <asp:HiddenField ID="idHiddenField" runat="server" />
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>

 </form> 

<%-- <br/><a href="IndexUI.aspx" > Home </a>--%>
  

</div>
</div> 
    
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>

    <script type="text/javascript">
        $().ready(function () {




           
            $("#categoryForm").validate({
                rules: {
                    nameTextBox : "required"



                }


                 ,
                messages: {

                    nameTextBox: {

                        required: "Empty Category ",
                       
                    },



                }


            })
        });
    </script>
</body>
</html>
