W<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementWebApp.UI.StockOutUI" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">

    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->

    <link rel="stylesheet" href="../assets/vendor/bootstrap/css/bootstrap.min.css" runat="server" />
    <link href="../assets/vendor/fonts/circular-std/style.css" rel="stylesheet" runat="server" />
    <link rel="stylesheet" href="../assets/libs/css/style.css" runat="server" />
    <link rel="stylesheet" href="../assets/vendor/fonts/fontawesome/css/fontawesome-all.css" runat="server" />
    <link rel="stylesheet" href="../assets/vendor/charts/chartist-bundle/chartist.css" runat="server" />
    <link rel="stylesheet" href="../assets/vendor/charts/morris-bundle/morris.css" runat="server" />
    <link rel="stylesheet" href="../assets/vendor/fonts/material-design-iconic-font/css/materialdesignicons.min.css" runat="server" />
    <link rel="stylesheet" href="../assets/vendor/charts/c3charts/c3.css" runat="server" />
    <link rel="stylesheet" href="../assets/vendor/fonts/flag-icon-css/flag-icon.min.css" runat="server" />
    <link rel="stylesheet" href="../assets/vendor/datepicker/tempusdominus-bootstrap-4.css" />
    <link rel="stylesheet" href="../assets/vendor/inputmask/css/inputmask.css" />
    <title>Stock Management</title>
</head>
<body>
    <!-- ============================================================== -->
    <!-- main wrapper -->
    <!-- ============================================================== -->
    <div class="dashboard-main-wrapper">
        <!-- ============================================================== -->
        <!-- navbar -->
        <!-- ============================================================== -->
        <div class="dashboard-header">
            <nav class="navbar navbar-expand-lg bg-white fixed-top">
                <a class="navbar-brand" href="index.html">Stock Management</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse " id="navbarSupportedContent">
                </div>
            </nav>
        </div>
        <!-- ============================================================== -->
        <!-- end navbar -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- left sidebar -->
        <!-- ============================================================== -->
        <div class="nav-left-sidebar sidebar-dark">
            <div class="menu-list">
                <nav class="navbar navbar-expand-lg navbar-light">
                    <a class="d-xl-none d-lg-none" href="#">Dashboard</a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav flex-column">
                            <li class="nav-divider"></li>
                            <li class="nav-item ">
                                <a class="nav-link active" href="#" data-toggle="collapse" aria-expanded="false" data-target="#submenu-1" aria-controls="submenu-1"><i class="fa fa-fw fa-user-circle"></i>Dashboard <span class="badge badge-success">6</span></a>
                                <div id="submenu-1" class="collapse submenu" style="">
                                    <ul class="nav flex-column">
                                        <ul class="nav-item">
                                            <li>
                                                <a class="nav-link" href="IndexUI.aspx">Home</a>
                                                <a class="nav-link" href="CategoryUI.aspx">Category</a>
                                                <a class="nav-link" href="CompanyUI.aspx">Company</a>
                                                <a class="nav-link" href="ItemUI.aspx">Item</a>
                                                <a class="nav-link" href="StockInUI.aspx">Stock In</a>
                                                <a class="nav-link" href="StockOutUI.aspx">Stock Out</a>
                                                <a class="nav-link" href="SummaryUI.aspx">Summary</a>
                                                <a class="nav-link" href="SaleUI.aspx">Sale History</a>
                                            </li>
                                        </ul>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </div>
        <!-- ============================================================== -->
        <!-- end left sidebar -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- wrapper  -->
        <!-- ============================================================== -->
        <div class="dashboard-wrapper">
            <div class="dashboard-ecommerce">
                <div class="container-fluid dashboard-content ">
                    <!-- ============================================================== -->
                    <!-- pageheader  -->
                    <!-- ============================================================== -->
                    <div class="row">
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                            <div class="page-header">
                                <h2 class="pageheader-title">Stock Out</h2>
                                <div class="page-breadcrumb">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb">
                                            <li class="breadcrumb-item"><a href="#" class="breadcrumb-link">Dashboard</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Stock Out</li>
                                        </ol>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- ============================================================== -->
                    <!-- end pageheader  -->
                    <!-- ============================================================== -->
                    <!-- basic form  -->
                    <!-- ============================================================== -->
                    <div class="row">
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">

                            <div class="card">
                                <h1 class="card-header">Stock Out</h1>
                                <div class="card-body">
                                    <form method="POST" class="categorySaveForm" runat="server">
                                        <div class="form-group">
                                        </div>
                                        <%-- -------%>
                                        <div>
                                            <br />
                                            <asp:Label ID="Label1" runat="server" Font-Size="20px" ForeColor="#04046f" Text="Company  "></asp:Label>
                                            <asp:DropDownList ID="companyDropDownList" Font-Size="20px" ForeColor="#04046f" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CompanyList">
                                            </asp:DropDownList>
                                            <asp:Label ID="companyErrorMessege" Font-Size="20px" runat="server" Text="" ForeColor="red"></asp:Label>
                                            <br />

                                            <asp:Label ID="Label2" runat="server" Font-Size="20px" ForeColor="#04046f" Text="Item      "></asp:Label>
                                            <asp:DropDownList ID="itemDropDownList" Font-Size="20px" ForeColor="#04046f" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ItemList"></asp:DropDownList>
                                            <asp:Label ID="itemErrorMessege" runat="server" Text="" ForeColor="red"></asp:Label>

                                            <br />
                                            <div>
                                                <asp:Label ID="Label3" runat="server" Font-Size="20px" ForeColor="#04046f" Text="Reorder level  "></asp:Label>
                                            </div>
                                            <asp:TextBox ID="reorderLevelTextBox" Font-Size="20px" ForeColor="#04046f" BackColor="white" Style="height: 35px; width: 100%" class="form-control" runat="server"></asp:TextBox>
                                            <br />
                                            <div>
                                                <asp:Label ID="Label4" runat="server" Font-Size="20px" Style="height: 40px; width: 100%" ForeColor="#04046f" Text="Available Quantity  "></asp:Label>
                                            </div>
                                            <asp:TextBox ID="availableQuantityTextBox"  Font-Size="20px" BackColor="white" Style="height: 35px; width: 100%" class="form-control" runat="server"></asp:TextBox>

                                            <br />
                                            <asp:Label ID="Label5" runat="server" Font-Size="20px" ForeColor="#04046f" Text="Stock Out Quantity  "></asp:Label>
                                            <asp:TextBox ID="stockOutQuantityTextBox" ForeColor="#04046f" class="form-control" runat="server"></asp:TextBox>

                                            <asp:Label ID="errorMessegeLabel" runat="server" Text="" ForeColor="red"></asp:Label>

                                            <br />
                                            <br />
                                            <asp:Button ID="addButton" runat="server" Font-Size="20px"  class="btn btn-primary" OnClick="addButton_Click" Text="Add" />
                                            <asp:Button ID="stockAgainButton" runat="server" Font-Size="20px" class="btn btn-primary" Text="Stock Out Again" OnClick="stockAgainButton_Click" />
                                            <br />
                                            <br />
                                            <br />

                                            <asp:GridView ID="stockOutGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">

                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Item" HeaderStyle-Width="300px">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#Eval("Item")%>'></asp:Label>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("ItemId")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Company" HeaderStyle-Width="300px">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%#Eval("Company")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Quantity " HeaderStyle-Width="300px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="ItemQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                </Columns>

                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <EditRowStyle BackColor="#999999" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                            </asp:GridView>
                                            <br />
                                            <br />
                                            <br />
                                            <asp:Button ID="sellButton" Font-Size="20px" runat="server" class="btn btn-primary" OnClick="sellButton_Click" Text="Sell" />
                                            <asp:Button ID="damageButton" Font-Size="20px" runat="server" class="btn btn-primary" Text="Damage" OnClick="damageButton_Click" />
                                            <asp:Button ID="lostButton" Font-Size="20px" runat="server" class="btn btn-primary" Text="Lost" OnClick="lostButton_Click" />

                                            <br />
                                            <asp:Label ID="messegeLabel" runat="server"></asp:Label>
                                            <br />
                                        </div>
                                        <%-- -------%>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- ============================================================== -->
                    <!-- end basic form  -->
                </div>
            </div>
            <!-- ============================================================== -->

            <!-- ============================================================== -->
        </div>
        <!-- ============================================================== -->
        <!-- end wrapper  -->
        <!-- ============================================================== -->
    </div>
    <!-- ============================================================== -->
    <!-- end main wrapper  -->
    <!-- ============================================================== -->
    <!-- Optional JavaScript -->
    <script src="../assets/vendor/jquery/jquery-3.3.1.min.js"></script>
    <script src="../assets/vendor/bootstrap/js/bootstrap.bundle.js"></script>
    <script src="../assets/vendor/slimscroll/jquery.slimscroll.js"></script>
    <script src="../assets/libs/js/main-js.js"></script>
    <script src="../assets/vendor/inputmask/js/jquery.inputmask.bundle.js"></script>
    <script>
        $(function (e) {
            "use strict";
            $(".date-inputmask").inputmask("dd/mm/yyyy"),
                $(".phone-inputmask").inputmask("(999) 999-9999"),
                $(".international-inputmask").inputmask("+9(999)999-9999"),
                $(".xphone-inputmask").inputmask("(999) 999-9999 / x999999"),
                $(".purchase-inputmask").inputmask("aaaa 9999-****"),
                $(".cc-inputmask").inputmask("9999 9999 9999 9999"),
                $(".ssn-inputmask").inputmask("999-99-9999"),
                $(".isbn-inputmask").inputmask("999-99-999-9999-9"),
                $(".currency-inputmask").inputmask("$9999"),
                $(".percentage-inputmask").inputmask("99%"),
                $(".decimal-inputmask").inputmask({
                    alias: "decimal",
                    radixPoint: "."
                }),

                $(".email-inputmask").inputmask({
                    mask: "*{1,20}[.*{1,20}][.*{1,20}][.*{1,20}]@*{1,20}[*{2,6}][*{1,2}].*{1,}[.*{2,6}][.*{1,2}]",
                    greedy: !1,
                    onBeforePaste: function (n, a) {
                        return (e = e.toLowerCase()).replace("mailto:", "")
                    },
                    definitions: {
                        "*": {
                            validator: "[0-9A-Za-z!#$%&'*+/=?^_`{|}~/-]",
                            cardinality: 1,
                            casing: "lower"
                        }
                    }
                })
        });
    </script>
    <script src="../assets/libs/js/jquery.validate.min.js"></script>
    <script>
        $().ready(function () {
            // validate signup form on keyup and submit
            $(".categorySaveForm").validate({
                rules: {
                    categoryTextBox: "required"
                },
                messages: {
                    firstname: "Please enter category name"
                }
            });
        });
    </script>
</body>
</html>
