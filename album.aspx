<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="album.aspx.cs" Inherits="album" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content_top">

        <div id="content_top_album">



            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [navn] FROM [Album] WHERE Id = @id">

                <SelectParameters>

                    <asp:QueryStringParameter QueryStringField="id" Name="id" Type="String" />

                </SelectParameters>

            </asp:SqlDataSource>



            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">

                <ItemTemplate>

                    <h1><%# Eval ("navn") %></h1>

                </ItemTemplate>

            </asp:Repeater>

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
        <asp:Panel CssClass="white" ID="meddelelse" runat="server" Visible="False">Albummet er tomt</asp:Panel>

    </div>

</asp:Content>

