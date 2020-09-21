<%@ Page  Title="iGameGT - Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="prub.HomePage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height: 116px">


        TURNO:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fichas Colocagas:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; jugador 1 : 2 fichas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Jugador 2 : 2 fichas
        <br />
        Ingresar direccion de archivo<br />
        <asp:TextBox ID="TextBox1" runat="server" Height="56px" Width="655px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonCARGAR" runat="server" OnClick="Button1_Click" Text="CARGAR XML" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="GUARDAR" runat="server" OnClick="Button2_Click" Text="GUARDAR XML" />

        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
         <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
         <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
         <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <br />
        <br />

        </div>
    <div style="height: 508px; width: 750px; margin-top: 95px">
   
        <asp:Table ID="Table1" runat="server"             
            Font-Size="X-Large" 
            Width="684px" 
            Font-Names="Palatino"
            BorderColor="DarkRed"
            BorderWidth="0px"
            ForeColor="Snow"
            CellPadding="0"
            CellSpacing="0" Height="472px" BackImageUrl="~/Imagenes/wood-table-surface.jpg" BorderStyle="Outset">
        
        <asp:TableHeaderRow 
                ID ="header"
                runat="server" 
                ForeColor="Snow"
                HorizontalAlign ="Justify"
               
                Font-Bold="true"
                BackImageUrl="~/Imagenes/wood-table-surface.jpg"
                VerticalAlign="Bottom">
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell>A</asp:TableHeaderCell>
                <asp:TableHeaderCell>B</asp:TableHeaderCell>
                <asp:TableHeaderCell>C</asp:TableHeaderCell>
                <asp:TableHeaderCell>D</asp:TableHeaderCell>
                <asp:TableHeaderCell>E</asp:TableHeaderCell>
                <asp:TableHeaderCell>F</asp:TableHeaderCell>
                <asp:TableHeaderCell>G</asp:TableHeaderCell>
                <asp:TableHeaderCell>H</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow 
                ID="TableRow1" 
                runat="server" 
BackImageUrl="~/Imagenes/wood-table-surface.jpg"              HorizontalAlign="Justify" VerticalAlign="Middle">
                <asp:TableCell>1</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID ="ImageButton011A" runat="server" OnClick="ImageButton1_Click"  /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton021B" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton031C" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton041D" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton051E" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton061F" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton071G" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton081H" runat="server" OnClick="ImageButton1_Click"/></asp:TableCell>
               
            </asp:TableRow>
            <asp:TableRow 
                ID="TableRow2" 
                runat="server" 
BackImageUrl="~/Imagenes/wood-table-surface.jpg"                >
                 <asp:TableCell>2</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID ="ImageButton092A" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton102B" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton112C" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton122D" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton132E" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton142F" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton152G" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton162H" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>

               
            </asp:TableRow>
             <asp:TableRow 
                ID="TableRow3" 
                runat="server" 
BackImageUrl="~/Imagenes/wood-table-surface.jpg"                >
                <asp:TableCell>3</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID ="ImageButton173A" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton183B" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton193C" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton203D" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton213E" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton223F" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton233G" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton243H" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>

               
            </asp:TableRow>
             <asp:TableRow 
                ID="TableRow4" 
                runat="server" 
BackImageUrl="~/Imagenes/wood-table-surface.jpg"                >
                <asp:TableCell>4</asp:TableCell>
                 
                <asp:TableCell><asp:ImageButton ID ="ImageButton254A" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton264B" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton274C" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton284D" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton294E" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton304F" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton314G" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton324H" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>

               
            </asp:TableRow>
             <asp:TableRow 
                ID="TableRow5" 
                runat="server" 
BackImageUrl="~/Imagenes/wood-table-surface.jpg"                BorderColor="Black">
                <asp:TableCell>5</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID ="ImageButton335A" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton345B" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton355C" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton365D" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton375E" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton385F" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton395G" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton405H" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>

               
            </asp:TableRow>
             <asp:TableRow 
                ID="TableRow6" 
                runat="server" 
BackImageUrl="~/Imagenes/wood-table-surface.jpg"                >
                <asp:TableCell>6</asp:TableCell>
               <asp:TableCell><asp:ImageButton ID ="ImageButton416A" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton426B" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton436C" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton446D" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton456E" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton466F" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton476G" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton486H" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>

               
            </asp:TableRow>
             <asp:TableRow 
                ID="TableRow7" 
                runat="server" 
                
BackImageUrl="~/Imagenes/wood-table-surface.jpg"                >
                <asp:TableCell>7</asp:TableCell>
             <asp:TableCell><asp:ImageButton ID ="ImageButton497A" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton507B" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton517C" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton527D" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton537E" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton547F" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton557G" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton567H" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>

               
            </asp:TableRow>
             <asp:TableRow 
                ID="TableRow8" 
                runat="server" 
BackImageUrl="~/Imagenes/wood-table-surface.jpg"                >
                <asp:TableCell>8</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID ="ImageButton578A" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton588B" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton598C" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton608D" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton618E" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton628F" runat="server"  OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton638G" runat="server" OnClick="ImageButton1_Click"/></asp:TableCell>
                 <asp:TableCell><asp:ImageButton ID ="ImageButton648H" runat="server" OnClick="ImageButton1_Click" /></asp:TableCell>

               
            </asp:TableRow>

            
            </asp:Table>
        
   
        <br />
        
   
        <br />
        <br />
        <br />
        
   
        <br />
        
   
    </div>


   
    

 </asp:Content>

