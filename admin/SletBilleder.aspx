<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SletBilleder.aspx.cs" Inherits="admin_SletBilleder" %>






<asp:Content ID="Content1" ContentPlaceHolderID="head2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <table>

        <tr>

            <th>
                <label>Billede-ID</label></th>
            <th>
                <label>Billede-navn</label></th>

        </tr>

        <tr>
            
            <td>
                <asp:Label ID="billedeID" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="billedenavn" runat="server"></asp:Label></td>
            
        </tr>

       </table>

    <asp:Label ID="Label_msg" runat="server"></asp:Label>

    <%--<asp:TextBox ID="Label_slet_msg" runat="server"></asp:TextBox>--%>

    <asp:Button ID="sletBtn" runat="server" Text="Slet billedet" OnClick="sletBtn_Click" />

    <asp:Button ID="tilAlbumBtn" runat="server" Text="Gå tilbage" OnClick="tilAlbumBtn_Click" />

</asp:Content>

