<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="album.aspx.cs" Inherits="album" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content_top">

        <div id="content_top_album">

            <h1>Færøerne</h1>

        </div>

    </div>

    <div id="content_ikon">

        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Billeder.fkAlbumId, Album.Id, Billeder.imgnavn, Billeder.Id AS billedId, Billeder.alt AS billedTekst, Billeder.fkAlbumId AS AlbumId, Album.navn FROM Album INNER JOIN Billeder ON Billeder.fkAlbumId = Album.Id ORDER BY Album.navn"></asp:SqlDataSource>--%>

        <asp:Repeater ID="RepeaterAlbum" runat="server">

            <ItemTemplate>

                <div class="ikon">
                    <a href="upload/originalsResized/<%# Eval ("imgnavn") %>" title="<%# Eval ("alt") %>">
                        <img src="upload/thumbs/<%# Eval ("thumbnavn") %>" alt="" /></a>
                </div>

            </ItemTemplate>
        </asp:Repeater>


        <%--<div class="ikon"><img src="../foto_ikon/post_skib.jpg" alt="" /></div>
						<div class="ikon"><img src="../foto_ikon/hus_i_taagen.jpg" alt="" /></div>
						<div class="ikon"><img src="../foto_ikon/vaedder.jpg" alt="" /></div>
						<div class="ikon"><img src="../foto_ikon/lobra.jpg" alt="" /></div>     --%>
    </div>

</asp:Content>

