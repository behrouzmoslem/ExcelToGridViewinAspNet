<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TransitionMedicalDocExcelToHis.WebApp.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <h3>Test Transition Data Of Excel To grid</h3>
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-8">
                        <asp:FileUpload runat="server" ID="fileUploader" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="btnUpload" OnClick="btnUpload_OnClick" Text="Upload" />
                    </div>
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-8">
                        <asp:Label runat="server" Text="Has Header?"></asp:Label>
                        <div class="col-sm-2">
                            <asp:RadioButtonList runat="server" ID="rbl" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:RadioButtonList>

                        </div>
                        <div class="col-md-2"></div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="col-lg-12">
            <div class="row"><asp:GridView runat="server" ID="grid1"></asp:GridView></div>
        </div>
    </form>
</body>
</html>
