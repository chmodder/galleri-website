<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="opretBillede.aspx.cs" Inherits="admin_opretBillede" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">


   <p>
        <asp:FileUpload ID="FileUpload_img" runat="server" />
    </p>
    <p>
        <asp:Button ID="Button_upload" runat="server" OnClick="Button_upload_Click"
            Text="Upload" />
    </p>

    <asp:TextBox ID="billedTekst" Text="Skriv billedtekst her" runat="server"></asp:TextBox>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Album]"></asp:SqlDataSource>

    <asp:DropDownList ID="albumPicker" runat="server" DataSourceID="SqlDataSource1" DataValueField="Id" DataTextField="navn" style="width: 88px"></asp:DropDownList>

    <asp:Label ID="Label_besked" runat="server" Text=""></asp:Label>

</asp:Content>

