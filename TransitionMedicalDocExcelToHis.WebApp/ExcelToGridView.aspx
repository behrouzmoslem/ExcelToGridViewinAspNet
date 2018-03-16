<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelToGridView.aspx.cs" Inherits="TransitionMedicalDocExcelToHis.WebApp.ExcelToGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <h3>Transition Excel Data To GridView</h3>
                </div>
                <div class="col-sm-2"></div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <div class="col-sm-4">
                        <asp:FileUpload runat="server" ID="fileUploader" />
                    </div>
                    <div class="col-sm-8">
                        <asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_OnClick" />
                    </div>


                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <div class="col-sm-2">
                        <asp:Label runat="server" Text="Has Header" />

                    </div>
                    <div>
                        <asp:RadioButtonList runat="server" ID="rbl" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="Yes" Selected="True" />
                            <asp:ListItem Text="No" Value="No" />
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="GridView1"></asp:GridView>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
