<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSaleUI.aspx.cs" Inherits="StockManagementSystem.UI.ViewSaleUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>View Sale</title> 
    <link href="../css/reset.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&display=swap" rel="stylesheet">
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/content-area.css" rel="stylesheet" /> 
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    
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
        <h1>View Sales</h1>
    </div>  
    
    <!--/* Logout */-->    
    <div class="Logout">
        <button type="button" class="logoutbutton" runat="server" OnServerClick="logOutButton_Click">Logout</button>
    </div>  

   <!--/* Main Content*/-->
    <div class="contents">

    <form id="viewSaleForm" runat="server">
    <div>
        <table> 
            
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="From Date : "></asp:Label>&nbsp;</td>
                <td> <asp:TextBox ID="fromDateTextBox" runat="server" Width="250px" Height="25px"></asp:TextBox><br/><br/></td>
            </tr> 
             
            
             <tr>
                <td> <asp:Label ID="Label2" runat="server" Text="To Date :"></asp:Label>&nbsp;</td>
                <td> <asp:TextBox ID="toDateTextBox" runat="server" Width="250px" Height="25px"></asp:TextBox><br/><br/></td>
            </tr>
              <tr>
                <td>&nbsp;</td>
                <td> <asp:Button ID="searchButton" runat="server" Text="Search" Font-Bold="True" Width="100px" Height="30px"  OnClick="searchButton_Click" /></td>
            </tr>
            </table>
        <br/>
        <br/>

        <asp:GridView ID="viewSaleGridView" AutoGenerateColumns="false" runat="server" > 
            <Columns>

               
                 <asp:TemplateField HeaderText="SL NO" >
                    <ItemTemplate> <%# Container.DataItemIndex+1%> </ItemTemplate> 

                </asp:TemplateField>  
               
                <asp:BoundField  DataField="Item" HeaderText="Item" />
                <asp:BoundField  DataField="SaleQuantity" HeaderText="Sale Quantiy" />
                
            </Columns>
            <%--<EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BackColor="#800080" BorderColor="#800080" ForeColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle BackColor="White" ForeColor="#003399" BorderColor="#660066" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#FFFF66" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" HorizontalAlign="Center" VerticalAlign="Middle"  />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SortedDescendingHeaderStyle BackColor="#002876" HorizontalAlign="Center" VerticalAlign="Middle" /> --%>

        </asp:GridView>
    
    </div>
       </form>
      <%--  <br/>
         <a href="IndexUI.aspx" >Index </a>--%>

    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.min.js"></script>

    <script src="../Scripts/jquery.validate.js"></script>

    <script> 
        
        $(function () {
            
           

            $("#fromDateTextBox").datepicker({ dateFormat: 'yy-mm-dd',
                changeMonth: true,
                minDate: '-10Y',
                onSelect: function (date) {

                    var selectedDate = new Date(date);
                    var msecsInADay = 86400000;
                    var endDate = new Date(selectedDate);

                    //Set Minimum Date of EndDatePicker After Selected Date of StartDatePicker
                    $("#toDateTextBox").datepicker("option", "minDate", endDate);


                }
               
              
              
                
            } );
                                  
              
            $("#toDateTextBox").datepicker({ dateFormat: 'yy-mm-dd', });
            
            
         

         
            $("#viwSaleForm").validate({

                
                rules: {
                    name: "required",

                },
                messages: {

                }
            });
        });

    </script>
</div>        
</div>        

</body>
</html>
