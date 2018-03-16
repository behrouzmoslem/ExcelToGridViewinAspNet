<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TransitionMedicalDocExcelToHis.WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Import Excel Data into Gridview</h3>
    </div>

    <div class="row">
        <div class="col-md-4">

            <asp:FileUpload runat="server" ID="FileUpload1" CssClass="dropdown-menu" />
        </div>
        <div class="col-md-4">
            <asp:Button runat="server" ID="btnUpload" OnClick="btnUpload_OnClick" Text="Upload" CssClass="btn-info" />
        </div>

    </div>
    <br/>
    <div class="row">
        <div class="col-md-2">
            <asp:Label runat="server" Text="Has it Header?"></asp:Label>
        </div>
        <div class="col-md-2"  >
            <asp:RadioButtonList runat="server" ID="rbHDR" CssClass="list-group" RepeatDirection="Horizontal">
                <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                <asp:ListItem Text="No" Value="No" ></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:GridView runat="server" ID="gridview1"></asp:GridView>

        </div>

    </div>
</asp:Content>
