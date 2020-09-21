<%@ Page Title="iGameGT - Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="prub._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Bienvenido a iGameGt&nbsp;&nbsp;&nbsp; </h1>
        <p class="lead">Juega partidas locales, 1vs1 y torneos locales de OThello</p>
        <p><a href="~/Account/Register">Registrarse</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Juega Partidas locales de OThello</h2>
           
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Jugar &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Juega Partidas 1vs1 de OThello</h2>
            
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Jugar &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Juega Torneos de OThello</h2>
            
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Jugar &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
