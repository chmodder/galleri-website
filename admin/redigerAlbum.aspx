<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="redigerAlbum.aspx.cs" Inherits="admin_redigerAlbum" %>

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
                <asp:Label ID="redigerID" runat="server"></asp:Label></td>
            <td>
                <asp:TextBox ID="redigernavn" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="redigeroprettetDen" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="redigerredigeretDen" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td colspan="7">
                <asp:Button ID="redigerButton" runat="server" Text="Rediger album" OnClick="redigerButton_Click"  /></td>
        </tr>
        
        <tr>
            <td colspan="7">
                <a href="default.aspx">Tilbage til album-oversigten</a></td>
        </tr>



        </table>

</asp:Content>

