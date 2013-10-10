<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content_midt"></div>

    <div id="content_right">

        <!--
					
						BILLEDUDTRÆK START:
						Herunder er forsidens 8 billeder defineret statisk. Jeres opgave er at generere et 
						dynamisk udtræk, begrænset til 8 tilfældige billeder.
	 
	 					POPUP:
						1. jQuery Lightbox - Følg instruktionen i dokumentets <head></head>
						2. Hvert thumbnail skal være et link som peger på den store udgave af billedet på serveren.
	 
	 					I PRAKSIS:
						1. DB: Opret forbindelse til projektes database.
						2. SQL: Hent relevant data fra databasen.
						3. PHP/C#: Benyt en løkke til at udskrive resultatet.
					
					-->

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT TOP (8) Id, imgnavn, thumbnavn, alt FROM Billeder ORDER BY NEWID()"></asp:SqlDataSource>

        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">

            <ItemTemplate>

                <div class="ikon">
                    <a href="img/upload/originalsResized/<%# Eval ("imgnavn") %>">
                        <img src="img/upload/thumbs/<%# Eval ("thumbnavn") %>" alt="<%# Eval ("alt") %>" /></a>
                </div>

            </ItemTemplate>

        </asp:Repeater>

        <!--
	 
						BILLEDUDTRÆK SLUT!
	 
					-->

    </div>


</asp:Content>

