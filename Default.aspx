<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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

            <%--<div class="ikon">
                <a href="foto/berlin_skyer.jpg">
                    <img src="fotothumbs/berlin_skyer.jpg" alt="" /></a>
            </div>
            <div class="ikon">
                <img src="fotothumbs/j_museum.jpg" alt="" />
            </div>
            <div class="ikon">
                <img src="fotothumbs/j_museum_1.jpg" alt="" />
            </div>
            <div class="ikon">
                <img src="fotothumbs/hus_i_taagen.jpg" alt="" />
            </div>
            <div class="ikon">
                <img src="fotothumbs/nytaar2.jpg" alt="" />
            </div>
            <div class="ikon">
                <img src="fotothumbs/nytaar5.jpg" alt="" />
            </div>
            <div class="ikon">
                <img src="fotothumbs/j_museum_4.jpg" alt="" />
            </div>
            <div class="ikon">
                <img src="fotothumbs/lobra.jpg" alt="" />
            </div>--%>

            <!--
	 
						BILLEDUDTRÆK SLUT!
	 
					-->

        </div>


</asp:Content>

