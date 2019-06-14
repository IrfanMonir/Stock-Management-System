<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="StockManagementWebApp.UI.LoginUI" %>

<!doctype html>
<html lang="en">
 <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Stock Management</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="../assets/vendor/bootstrap/css/bootstrap.min.css">
    <link href="../assets/vendor/fonts/circular-std/style.css" rel="stylesheet">
    <link rel="stylesheet" href="../assets/libs/css/style.css">
    <link rel="stylesheet" href="../assets/vendor/fonts/fontawesome/css/fontawesome-all.css">
    <style>
    html,
    body {
        height: 100%;
    }
    body {
        display: -ms-flexbox;
        display: flex;
        -ms-flex-align: center;
        align-items: center;
        padding-top: 40px;
        padding-bottom: 40px;
    }
    </style>
</head>

<body>
    <!-- ============================================================== -->
    <!-- login page  -->
    <!-- ============================================================== -->
    <div class="splash-container">
        <div class="card ">
            <div class="card-header text-center"><a href="../index.html">
                </a>
                <span class="splash-description">Please enter your user information.</span></div>
            <div class="card-body">
                <form runat="server">
                 <p class="text-danger"  id="errorMessageLabel" runat="server"></p>
                    <div class="form-group">
                    <asp:TextBox ID="userNameTextBox" class="form-control form-control-lg" runat="server" placeholder="Username" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="passwordTextBox" class="form-control form-control-lg" runat="server" placeholder="Password" autocomplete="off"></asp:TextBox>
                    </div>
                   <asp:Button ID="signInButton" runat="server"  class="btn btn-primary btn-lg btn-block"  Text="Sign in" OnClick="signInButton_Click" />
                </form>
            </div>
           
        </div>
    </div>
  
    <!-- ============================================================== -->
    <!-- end login page  -->
    <!-- ============================================================== -->
    <!-- Optional JavaScript -->
    <script src="../assets/vendor/jquery/jquery-3.3.1.min.js"></script>
    <script src="../assets/vendor/bootstrap/js/bootstrap.bundle.js"></script>
</body>
 
</html>