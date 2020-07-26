<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchViewUI.aspx.cs" Inherits="StockManagementSystem.UI.SearchViewUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Search Item</title>
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
 
 <!--/* Title */-->
<div class="content-area">
    <div class="heading">
        <h1>Search</h1>
     </div>

    <!--/* Logout */-->    
    <div class="Logout">
        <button type="button" class="logoutbutton" runat="server" OnServerClick="logOutButton_Click">Logout</button>
    </div>
   
  <!--/* Main Content*/-->
    <div class="contents">  
      
    <div>
        <form id="form1" runat="server">
    <table>
            <tr> 
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Company:"></asp:Label>&nbsp;
                </td>
                <td>
                    <asp:DropDownList  ID="companyDropDownList" runat="server" Width="250px" Height="25px"></asp:DropDownList><br/><br/>
                </td> 
                </tr> 

                 <tr> 
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Category :"></asp:Label>&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="categoryDropDownList" runat="server" Width="250px" Height="25px"></asp:DropDownList><br/><br/>
                </td> 
            </tr> 
            <tr>
                <td>&nbsp; </td> 
               <td>
                    <asp:Button ID="searchButton" runat="server" Text="Search" Font-Bold="True" Width="100px" Height="30px"  OnClick="searchButton_Click" /> </td>
            </tr>
           
        </table>
    
        <br/>
        <br/>
          <div class="grid">           
        <asp:GridView  AutoGenerateColumns="false" ID="searchGridView" runat="server" > 

            <Columns> 
                <asp:TemplateField HeaderText="SL No"> 
                    <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate>
                </asp:TemplateField> 
                <asp:BoundField  DataField="Item" HeaderText="Item" />
                <asp:BoundField DataField="Company" HeaderText="Company" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="AvailableQuantity" HeaderText="AvailableQuantity" />
                <asp:BoundField  DataField="ReorderLevel" HeaderText="ReorderLevel"/> 


            </Columns>
             

        </asp:GridView> 
        </div>
        <br/>
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
        </form>
    </div>
   
      <%--<br/>
     <a href="IndexUI.aspx" >Home </a>--%>
      
        
          
</div>
</div>


    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>

    <%-- <script type="text/javascript">


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

            
             $("#form1").validate({
                 rules: {
                     

                     companyDropDownList: {

                         selectNone: true,
                     },
                     categoryDropDownList : {

                         selectNone: true,
             }
                 }


                  ,
                 messages: {

                     


                 }


             })
         });


    </script>--%>
</body>
</html>
