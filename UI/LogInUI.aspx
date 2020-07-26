<%@ Page enableSessionState="true" Language="C#" AutoEventWireup="true" CodeBehind="LogInUI.aspx.cs" Inherits="StockManagementSystem.UI.LogInUI" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>SMS Login</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->	
    <link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../login_vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../login_fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../login_fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../login_vendor/animate/animate.css">
    <!--===============================================================================================-->	
    <link rel="stylesheet" type="text/css" href="../login_vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../login_vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../login_vendor/select2/select2.min.css">
    <!--===============================================================================================-->	
    <link rel="stylesheet" type="text/css" href="../login_vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../login_css/util.css">
    <link rel="stylesheet" type="text/css" href="../login_css/login_main.css">
    <!--===============================================================================================-->
</head>
<body>
	
<div class="limiter">
    <div class="container-login100" style="background-image: url('../login_images/bg-01.jpg');">
        <div class="wrap-login100">
            <form class="login100-form validate-form" runat="server">
                <span class="login100-form-logo">
                    <img src="../Resources/Logo.png" />
                </span>

                <span class="login100-form-title p-b-34 p-t-27">
                    Log in
                </span>

                <div class="wrap-input100 validate-input" data-validate = "Enter username">
                    <asp:TextBox ID="txtuserName" class="input100" placeholder="Username" runat="server"></asp:TextBox>
                    <span class="focus-input100" data-placeholder="&#xf207;"></span>
                </div>

                <div class="wrap-input100 validate-input" data-validate="Enter password">
                    <asp:TextBox ID="txtpassword" TextMode="Password" class="input100" placeholder="Password" runat="server"></asp:TextBox>
        
                    <span class="focus-input100" data-placeholder="&#xf191;"></span>
                </div>

                <div class="container-login100-form-btn">
                    <asp:Button ID="logInButton" class="login100-form-btn" runat="server" Text="Login" OnClick="logInButton_Click1" />
                  </div>

                <div class="text-center p-t-90">
                    <a class="txt1" href="#">
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </a>
                </div>
            </form>
        </div>
    </div>
</div>
	

<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
<script src="../login_vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
<script src="../login_vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
<script src="../login_vendor/bootstrap/js/popper.js"></script>
<script src="../login_vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
<script src="../login_vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
<script src="../login_vendor/daterangepicker/moment.min.js"></script>
<script src="../login_vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
<script src="../login_vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
<script src="../login_js/main.js"></script>

</body>
</html>
    

<%--    <form id="logInForm" runat="server">
    <div>
        
        <table> 
             <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label></td>
                <td> <asp:TextBox ID="userNameTextBox" runat="server"></asp:TextBox></td>

            </tr>

             <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label> </td>
                <td>
                    <input type="password" runat="server" id="passwordTextBox" />
                   

            </tr>

             <tr>
                <td> </td>
                <td> <asp:Button ID="logInButton" runat="server" Text="Log In" OnClick="logInButton_Click" /></td>

            </tr>
        </table>
        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
    </div>
    </form>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script> 
     <script> 
         $(function () {


             $("#logInForm").validate({
                 rules: {
                    
                     userNameTextBox: 'required',
                     passwordTextBox: 'required',

                 }
                    
                   
                ,
                 messages: {
                   
                     userNameTextBox: "Enter username please",
                     passwordTextBox: "Enter password please",
                    
                    
                    
                 } 
            
            
             } ) } ) ;


        

     </script>

</body>
</html>--%>
