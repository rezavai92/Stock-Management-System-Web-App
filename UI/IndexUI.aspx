<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementSystem.UI.IndexUI" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Home</title>
    <link href="../css/reset.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&display=swap" rel="stylesheet">
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/content-area.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">

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
    
<!--/* Title */-->
<section class="content-area">
    <div class="heading">
        <h1>Home</h1>
  </div>

    <!--/* Logout */-->  
     <div class="Logout">
        <button type="button"   class="logoutbutton" runat="server" OnServerClick="logOutButton_Click" >Logout</button>
    </div>  
   

    <!--/* Home Content */-->
    <div class="container">
        <div class="cards">
            <a href="CategorySetupUI.aspx">
                <div class="card">
                   <img src="../Resources/category-icon.svg" alt="category" class="category-img" style="width: 100%">
                    <span class="category-title">Category Setup</span>
                </div>
            </a>
        </div>

        <div class="cards">
            <a href="CompanySetupUI.aspx">
                <div class="card">
                    <img src="../Resources/company-icon.svg " alt="company" class="company-img" style="width: 100%">
                    <span class="company-title">Company Setup</span>
                </div>
            </a>
        </div>

        <div class="cards">
            <a href="ItemSetupUI.aspx">
                <div class="card">
                    <img src="..//Resources/item-icon.svg" alt="item" class="item-img" style="width: 100%">
                    <span class="item-title">Item Setup</span>
                </div>
            </a>
        </div>
        
        <div class="cards">
            <a href="StockInUI.aspx">
                <div class="card">
                    <img src="..//Resources/stockin-icon.svg" alt="stockin" class="stockin-img" style="width: 100%">
                    <span class="stockin-title">Stock In</span>
                </div>
            </a>
        </div>
        
        <div class="cards">
            <a href="StockOutUI.aspx">
                <div class="card">
                    <img src="..//Resources/stockout-icon.svg" alt="stockout" class="stockout-img" style="width: 100%">
                    <span class="stockout-title">Stock Out</span>
                </div>
            </a>
        </div>
        
        <div class="cards">
            <a href="SearchViewUI.aspx">
                <div class="card">
                    <img src="..//Resources/search-icon.svg" alt="search" class="search-img" style="width: 100%">
                    <span class="search-title">Search</span>
                </div>
            </a>
        </div>
        
        <div class="cards">
            <a href="ViewSaleUI.aspx">
                <div class="card">
                    <img src="..//Resources/sales-icon.svg" alt="stockin" class="sales-img" style="width: 100%">
                    <span class="sales-title">Sales Report</span>
                </div>
            </a>
        </div>
        
       

    </div>
</section>
    </form>
</body>
</html>

