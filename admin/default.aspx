<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="admin_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">


    <asp:SqlDataSource ID="SqlDataAlbums" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' 
                            SelectCommand="SELECT MAX (Album.Id) AS Id, 
                                           MAX (Album.navn) AS navn, 
                                           COUNT(Billeder.Id) AS antalBilleder 
                                           FROM Billeder 
                                           RIGHT JOIN Album 
                                           ON Billeder.fkAlbumId = Album.Id GROUP BY Album.Id">
        </asp:SqlDataSource>


    <table class="table table-striped">


        <a href="opretAlbum.aspx">Opret Album</a>

        <tr>
            <th>Navn</th>
            <th>Antal billeder</th>
        </tr>

        <asp:Repeater ID="RepeaterAlbums" DataSourceID="SqlDataAlbums" runat="server">




            <ItemTemplate>

                <tr>
                    <td><%# Eval ("navn") %></td>
                    
                    <td><%# Eval ("AntalBilleder") %></td>
                    <td>
                        <a class="adminLink" href="visBilleder.aspx?id=<%# Eval("Id") %>">Vis Billeder</a>
                    </td>
                    <td>
                        <a class="adminLink" href="redigerAlbum.aspx?id=<%# Eval("Id") %>">Rediger Album</a>
                    </td>
                    <td>
                        <a class="adminLink" href="sletAlbum.aspx?id=<%# Eval("Id") %>">Slet Album</a>
                    </td>
                </tr>

            </ItemTemplate>

        </asp:Repeater>

    </table>

</asp:Content>

