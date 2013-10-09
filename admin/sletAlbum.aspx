<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="sletAlbum.aspx.cs" Inherits="admin_sletAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <table>

        <tr>
            <th>
                <label>Album-ID</label></th>
            <th>
                <label>Album-navn</label></th>
            <th>
                <label>Oprettelses-dato</label></th>
            <th>
                <label>Sidst redigeret dato</label></th>
        </tr>
        <tr>
            <td>
                <asp:Label ID="sletID" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="sletnavn" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="sletoprettetDen" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="sletredigeretDen" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td colspan="7">
                <asp:Button ID="sletButton" runat="server" Text="Slet album" OnClick="sletButton_Click"  /></td>
        </tr>
        
        <tr>
            <td colspan="7">
                <a href="default.aspx">Tilbage til album-oversigten</a></td>
        </tr>

        <%--<tr>
            <td colspan="7">
                <asp:Label ID="albumSletAlbum" runat="server" Text=""></asp:Label></td>
        </tr>--%>

        </table>

</asp:Content>

