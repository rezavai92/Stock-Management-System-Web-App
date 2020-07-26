<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementSystem.UI.StockOutUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Stock out</title>
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
        <h1>Stock Out</h1>
    </div> 
    
    <!--/* Logout */-->    
    <div class="Logout">
        <button type="button" class="logoutbutton" runat="server" OnServerClick="logOutButton_Click">Logout</button>
    </div>   
    
   <!--/* Main Content*/-->
    <div class="contents">
    <form id="stockOutForm" runat="server">
    <div>
     <table> 

            <tr> 
                <td>
                    <asp:Label ID="companyLabel" runat="server" Text="Company :"></asp:Label> &nbsp;</td>
                <td> <asp:DropDownList   AutoPostBack="true" ID="companyDropDownList"  runat="server"  OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" Width="250px" Height="25px">
                    </asp:DropDownList><br/><br/></td>
            </tr> 

            <tr> 
                <td>
                    <asp:Label ID="itemLabel" runat="server" Text="Item :"></asp:Label> &nbsp;</td>
                <td> <asp:DropDownList ID="itemDropDownList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" Width="250px" Height="25px"></asp:DropDownList> <br/><br/></td>
            </tr> 

            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Reorder Level :"></asp:Label>&nbsp; </td>
                <td>
                    <asp:TextBox ID="reorderLabelTextBox"  Enabled="false" runat="server" Width="250px" Height="25px"></asp:TextBox><br/><br/></td>
            </tr> 

            <tr> 
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Available Quantity :"></asp:Label>&nbsp; </td>
                <td> <asp:TextBox ID="availableQuantityTextBox" Enabled="false" runat="server" Width="250px" Height="25px"></asp:TextBox><br/><br/></td>
            </tr> 

            <tr> 
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Stock Out Quantity :"></asp:Label> &nbsp;</td>
                <td> <asp:TextBox ID="stockOutQuantityTextBox"  runat="server" Width="250px" Height="25px"></asp:TextBox> <br/> <br/></td>
            </tr> 


            <tr>
                 <td></td> 
                 <td> 
                     <asp:Button ID="addButton" runat="server" Text="Add"  Font-Bold="True" Width="100px" Height="30px"  OnClick="addButton_Click1"  />
                 </td> 
            </tr>
        </table>
    </div> 
        <br/>
        <br/>

        <div>
            <asp:GridView ID="stockOutGridView" AutoGenerateColumns="false" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="0px" Width="400px">

               <Columns> 
                   <asp:TemplateField HeaderText="SL No" >

                       <ItemTemplate> 

                           <%# Container.DataItemIndex+1%> 

                       </ItemTemplate>
                   </asp:TemplateField > 
                   
                  <asp:BoundField  DataField="Item" HeaderText="Item" />
                   <asp:BoundField  DataField="Company" HeaderText =" Company" />
                   <asp:BoundField  DataField="Quantity" HeaderText="Quantity" />

               </Columns>
                
               



            </asp:GridView>
        </div> 
        <br /> <br /> 
        <div >  
           <table> 
               <tr>
                   <td>&nbsp; &nbsp;</td>
                   <td>&nbsp; &nbsp;</td>
                   <td>
                    <asp:Button ID="sellButton" runat="server" Text="Sell" Font-Bold="True" Width="100px" Height="30px"  OnClick="sellButton_Click" /> </td>
                   <td> &nbsp; &nbsp; &nbsp;</td>
                   <td><asp:Button ID="damageButton" runat="server" Text="Damage" Font-Bold="True" Width="100px" Height="30px"  OnClick="damageButton_Click" /> </td>
                   <td>&nbsp; &nbsp; &nbsp;</td>
                   <td> <asp:Button ID="lostButton" runat="server" Text="Lost" Font-Bold="True" Width="100px" Height="30px"  OnClick="lostButton_Click" /></td>
               </tr>
           </table>
            <br/>
            <br/>
        </div>

        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
    </form>
    <%--    <br/>
  <a href="IndexUI.aspx" >Home </a>--%>



     <script src="../Scripts/jquery-3.4.1.min.js"></script> 

    <script src="../Scripts/jquery.validate.js"></script>

    <script type="text/javascript">


        $().ready(function () {



            $.validator.addMethod(
           "selectNone",
           function (value, element) {
               if (element.value == "0") {
                   return false;
               }
               else return true;
           },
           "Please select an option."
         );

            $.validator.addMethod(
               "regex",

               function (value, element, regexp) {
                   var re = new RegExp(regexp);
                   return this.optional(element) || re.test(value);
               },
               "Please check your input."
       );
            $("#stockOutForm").validate({
                rules: {
                    stockOutQuantityTextBox: {

                        required: true,
                        regex: /^[1-9]\d*$/,

                    },


                    companyDropDownList: {

                        selectNone: true,
                    }

                }


                 ,
                messages: {

                    stockOutQuantityTextBox: {

                        required: "Empty Stock Out Quantity Textbox",
                        regex: "You must enter a positive integer  value",
                    },



                }


            })
        });

        </script>
        
</div>
 </div>

    </body>
</html>
