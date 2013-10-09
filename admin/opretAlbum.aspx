<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="opretAlbum.aspx.cs" Inherits="admin_opretAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <asp:TextBox ID="newAlbumInput" runat="server" Text="Skriv album navn her"></asp:TextBox>
    <%--<input id="newAlbumInput" type="text" placeholder="Skriv album-navnet her" />--%>
    <asp:Button ID="gemAlbumBtn" runat="server" Text="Gem album" OnClick="gemAlbumBtn_Click" />
    <a href="default.aspx">Tilbage til album-oversigten</a>
    <asp:Panel ID="PanelMsgSuccess" runat="server" Visible="False">Succes!! Albummet er oprettet</asp:Panel>

</asp:Content>

