<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPageLogin.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <asp:Panel ID="PanelMsgFejl" runat="server" CssClass="alert alert-danger alert-dismissable" Visible="False">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
        <strong>Forkert</strong> Brugernavn aller password
           
    </asp:Panel>

    <div class="form-group">
        <label class="col-lg-2 control-label">Brugernavn</label>
        <div class="col-lg-10">
            <asp:TextBox ID="inputBrugernavn" CssClass="form-control" Placeholder="Brugernavn" runat="server"></asp:TextBox>
        </div>

    </div>
    <div class="form-group">
        <label class="col-lg-2 control-label">Password</label>
        <div class="col-lg-10">
            <asp:TextBox ID="inputPassword" CssClass="form-control" TextMode="Password" Placeholder="Password" runat="server"></asp:TextBox>
        </div>

    </div>
    <div class="form-group">
        <div class="col-lg-offset-2 col-lg-10">
            <div class="checkbox">
                <label>
                    <input type="checkbox">
                    Remember me
                </label>
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="col-lg-offset-2 col-lg-10">
            <%--<button type="submit" class="btn btn-default">Sign in</button>--%>
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="ButtonLogin_Click" />
        </div>
    </div>
    
    <div class="form-group">
        <div class="col-lg-offset-2 col-lg-10">
            <%--<button type="submit" class="btn btn-default">Sign in</button>--%>
            <asp:Button ID="ButtonOpret" runat="server" Text="Opret bruger" CssClass="btn btn-default" OnClick="ButtonOpret_Click" />
        </div>
    </div>

</asp:Content>

