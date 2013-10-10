<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="visBilleder.aspx.cs" Inherits="admin_visBilleder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">

    <%--<h3><%# Eval ("navn") %></h3>--%>

    <asp:Button ID="opretImgBtn" runat="server" Text="Tilføj Billede" OnClick="opretImgBtn_Click" />

    <table>

        <tr>
            <th></th>
            <th>
                <label>Billede-ID</label></th>
            <th>
                <label>Billede-navn</label></th>
            <th>
                <label>Oprettet</label></th>
            <th>
                <label>Sidst ændret</label></th>
            <th></th>
        </tr>

        <asp:Repeater ID="RepeaterAlbum" runat="server">

            <ItemTemplate>

                <tr>
                    <td><a href="/upload/originalsResized/<%# Eval ("imgnavn") %>" title="<%# Eval ("alt") %>">
                        <img src="/upload/thumbs/<%# Eval ("imgnavn") %>" width="72" height="72" alt="" /></a></td>
                    <td>
                        <span id="albumnavn" runat="server"><%# Eval ("Id") %></span></td>
                    
                    <td>
                        <span ID="albumID" runat="server"><%# Eval ("imgnavn") %></span></td>

                    <td>
                        <span id="albumoprettetDen" runat="server"><%# Eval ("oprettetDen") %></span></td>
                    <td>
                        <span id="albumredigeretDen" runat="server"><%# Eval ("redigeretDen") %></span></td>
                    <td>
                        <a class="adminLink" href="SletBilleder.aspx?id=<%# Eval("Id") %>">Slet Billedet</a>
                        <%--<asp:Button ID="sletButton" runat="server" Text="Slet billede" OnClick="sletButton_Click" CommandArgument = '<%# Eval("Id") %>' />--%></td>

                </tr>

            </ItemTemplate>
        </asp:Repeater>

        <tr>
            <td colspan="5"></td>
        </tr>


        <tr>
            <td colspan="5">
                <a href="default.aspx">Tilbage til album-oversigten</a></td>
        </tr>

        <%--<tr>
            <td colspan="7">
                <asp:Label ID="albumSletAlbum" runat="server" Text=""></asp:Label></td>
        </tr>--%>
    </table>

</asp:Content>

