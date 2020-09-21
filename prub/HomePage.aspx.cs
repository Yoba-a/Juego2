using Antlr.Runtime.Tree;
using Microsoft.Ajax.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Mapping;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace prub
{
    public partial class HomePage : System.Web.UI.Page
    {

        private static int[] Juego = new int[64];
        private string[] xmlGame = new string[64];
        public static int[,] tablero = new int[8, 8];
        public static bool MyStaticBool { get; set; }
        public static bool determinaTurno { get; set; }
        public static bool jugadorBlanco { get; set; }
        public static bool jugadorNegro { get; set; }
        private static bool mensage { get; set; }
        private static string [] idboton = new string[1];
        private ImageButton[,] Botones = new ImageButton[8,8];
        List<ImageButton> botoncitos = new List<ImageButton>();

        protected void Page_Load(object sender, EventArgs e)

        {
            List<ImageButton> lstBtnCalc = new List<ImageButton>() {
             ImageButton011A,
             ImageButton021B,
             ImageButton031C,
             ImageButton041D,
             ImageButton051E,
             ImageButton061F,
             ImageButton071G,
             ImageButton081H,
             ImageButton092A,
             ImageButton102B,
             ImageButton112C,
             ImageButton122D,
             ImageButton132E,
             ImageButton142F,
             ImageButton152G,
             ImageButton162H,
             ImageButton173A,
             ImageButton183B,
             ImageButton193C,
             ImageButton203D,
             ImageButton213E,
             ImageButton223F,
             ImageButton233G,
             ImageButton243H,
             ImageButton254A,
             ImageButton264B,
             ImageButton274C,
             ImageButton284D,
             ImageButton294E,
             ImageButton304F,
             ImageButton314G,
             ImageButton324H,
             ImageButton335A,
             ImageButton345B,
             ImageButton355C,
             ImageButton365D,
             ImageButton375E,
             ImageButton385F,
             ImageButton395G,
             ImageButton405H,
             ImageButton416A,
             ImageButton426B,
             ImageButton436C,
             ImageButton446D,
             ImageButton456E,
             ImageButton466F,
             ImageButton476G,
             ImageButton486H,
             ImageButton497A,
             ImageButton507B,
             ImageButton517C,
             ImageButton527D,
             ImageButton537E,
             ImageButton547F,
             ImageButton557G,
             ImageButton567H,
             ImageButton578A,
             ImageButton588B,
             ImageButton598C,
             ImageButton608D,
             ImageButton618E,
             ImageButton628F,
             ImageButton638G,
             ImageButton648H,
             };

            int jn = 1;
            for (int i = 0; i < 64; i += 8)
            {

                xmlGame[i] = jn.ToString() + "A";
                xmlGame[i + 1] = jn.ToString() + "B";
                xmlGame[i + 2] = jn.ToString() + "C";
                xmlGame[i + 3] = jn.ToString() + "D";
                xmlGame[i + 4] = jn.ToString() + "E";
                xmlGame[i + 5] = jn.ToString() + "F";
                xmlGame[i + 6] = jn.ToString() + "G";
                xmlGame[i + 7] = jn.ToString() + "H";
                jn += 1;
            }

           

            button_change(lstBtnCalc);

            int inndic = 0;
            Label3.Text = "";
            for (int h = 0; h < 8; h++)
            {

                for (int g = 0; g < 8; g++)
                {
                    if (inndic < Juego.Length)
                    {
                        tablero[h, g] = Juego[inndic];
                        Botones[h, g] = lstBtnCalc[inndic];
                        inndic += 1;
                        Label3.Text += tablero[h, g].ToString();
                    }
                    /*if (Juego[contador] == 1 || Juego[contador] == 2)

                    {
                    lstBtnCalc[contador].OnClientClick = "this.disabled=true";
                }*/
                }
            }

            if (mensage != true)
            {
                Turno();

                desHabBoton();
                gameLogic();
              

            }

        }

        protected void button_change(List<ImageButton> lstlstBtnCalc)
        {
            List<ImageButton> lis = lstlstBtnCalc;

            for (int i = 0; i == 64; i++)
            {

                if (Juego[i] == 1)
                {
                    lis[i].ImageUrl = "~/Imagenes/white.png";
                }
                else if (Juego[i] == 2)
                {
                    lis[i].ImageUrl = "~/Imagenes/black.png";
                }
                else
                {
                    lis[i].ImageUrl = "~/Imagenes/wood-table-surface.jpg";
                }

            }
            if (MyStaticBool != true) {
                foreach (ImageButton btn in lis)
                {
                    btn.Height = 60;
                    btn.Width = 60;
                    btn.ImageUrl = "~/Imagenes/wood-table-surface.jpg";

                }

                
                TableRow2.Height = 60;
                ImageButton284D.ImageUrl = "~/Imagenes/white.png";
                ImageButton294E.ImageUrl = "~/Imagenes/black.png";
                ImageButton365D.ImageUrl = "~/Imagenes/black.png";
                ImageButton375E.ImageUrl = "~/Imagenes/white.png";

                ImageButton284D.OnClientClick = "this.disabled=true";
                ImageButton294E.OnClientClick = "this.disabled=true";
                ImageButton365D.OnClientClick = "this.disabled=true";
                ImageButton375E.OnClientClick = "this.disabled=true";
                Juego[27] = 1;
                Juego[28] = 2;
                Juego[35] = 2;
                Juego[36] = 1;

            }
            else
            {
                foreach (ImageButton btn in lis)
                {
                    btn.Height = 60;
                    btn.Width = 60;

                }

            }

        }



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)

        {
            int inndice = 0;
            Label3.Text = "";
            for (int h = 0; h < 8; h++)
            {

                for (int g = 0; g < 8; g++)
                {
                    if (inndice < Juego.Length)
                    {
                        tablero[h, g] = Juego[inndice];
                        inndice += 1;
                        Label3.Text += tablero[h, g].ToString();
                    }
                }
            }

            ImageButton imageButton = sender as ImageButton;
            string id = imageButton.ID.ToString();
            string dos = id.Substring(11, 2);
            
            int numeroposicion = Convert.ToInt32(dos) - 1;
            /* Label1.Text = id + " " +random + " "+ dos;*/
                if (jugadorBlanco)
                {
                gameMoves(imageButton);
                    imageButton.ImageUrl = "~/Imagenes/white.png";
                    jugadorNegro = true;
                    jugadorBlanco = false;
                    Juego[numeroposicion] = 1;
                    Label4.Text = "blanco btnid" + id;
                idboton[0] = imageButton.ID.ToString();
                foreach(ImageButton img in Botones){
                    img.OnClientClick = "this.disabled= true";

                }

            }
            else if (jugadorNegro)
                {
                gameMoves(imageButton);
                jugadorBlanco = true;
                    jugadorNegro = false;
                    imageButton.ImageUrl = "~/Imagenes/black.png";
                    Juego[numeroposicion] = 2;
                    Label4.Text = "negro btnid" + id;
                idboton[0] = imageButton.ID.ToString();
                foreach (ImageButton img in Botones)
                {
                    img.OnClientClick = "this.disabled= true";

                }

            }

            int inndice2 = 0;
            Label3.Text = "";
            for (int h = 0; h < 8; h++)
            {

                for (int g = 0; g < 8; g++)
                {
                    if (inndice2 < Juego.Length)
                    {
                        tablero[h, g] = Juego[inndice2];
                        inndice2 += 1;
                        Label3.Text += tablero[h, g].ToString();
                    }
                }
            }




            MyStaticBool = true;
            Label1.Text = "posicion " + numeroposicion + Juego[numeroposicion].ToString() + " " + Juego[0].ToString();
            Label2.Text = " ";
            restablecerMarcadas();
            gameLogic();

            for (int g = 0; g < 64; g++)
            {
                Label2.Text += Juego[g].ToString();

            }

        }
      
        public void restablecerMarcadas()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j =0; j < 8; j++)
                {
                    if (tablero[i, j] == 1 || tablero[i,j] == 2) { }
                    {
                        Botones[i, j].BorderStyle = BorderStyle.None;
                        Botones[i, j].BorderWidth = 0;
                    }
                }
            }
        }
        public void desHabBoton()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Botones[i, j].OnClientClick = "this.disabled = true";


                }
            }
        }


        protected void gameLogic()
        {
            /*BorderStyle = "Solid" BorderWidth = "10" BorderColor = "White"
              Botones[contador + espaciador].BorderStyle = BorderStyle.Solid;
              Botones[contador + espaciador].BorderWidth = 10;
             Botones[contador + espaciador].BorderColor = Color.White;
             */
            
            for (int i = 0; i < 8; i++) { 

                for (int j = 0; j < 8; j++)
                {


                    if (tablero[i, j] == 1 && jugadorBlanco)
                    {
                        if (j < 7)
                        {
                            if (tablero[i, j + 1] == 2)
                            {

                                
                                for (int esp = j; esp < 7; esp++)
                                {

                                    if (tablero[i, esp] == 2 && tablero[i, esp + 1] == 0)
                                    {
                                        Botones[i, esp + 1].BorderStyle = BorderStyle.Solid;
                                        Botones[i, esp + 1].BorderWidth = 3;
                                        Botones[i, esp + 1].BorderColor = Color.White;
                                        Botones[i, esp + 1].OnClientClick = "this.disabled = false";
                                       /* if (Botones[i,esp+1].ID.Equals(btn.ID) && btn.ID != null)
                                        {

                                            string id = btn.ID.ToString();
                                            string dos = id.Substring(11, 2);
                                            int numeroposicion = Convert.ToInt32(dos) - 1;
                                            int conta = 0;
                                            for (int x = esp + 2; x >j; x--)
                                            {
                                                Botones[i, x].ImageUrl  = "~/Imagenes/white.png";
                                                Juego[numeroposicion-conta] = 1;
                                                conta += 1;
                                            }
                                            

                                        }*/
                                            break;

                                    }


                                }
                                

                            }
                        }
                        if (j > 1)
                        {
                            if (tablero[i, j - 1] == 2)
                            {

                                for (int esp = j; esp > 0; esp--)
                                {

                                    if (tablero[i, esp] == 2 && tablero[i, esp - 1] == 0)
                                    {
                                        Botones[i, esp - 1].BorderStyle = BorderStyle.Solid;
                                        Botones[i, esp - 1].BorderWidth = 3;
                                        Botones[i, esp - 1].BorderColor = Color.White;
                                        Botones[i, esp - 1].OnClientClick = "this.disabled = false";

                                        break;

                                    }

                                }

                            }
                        }
                        if (i > 1)
                        {
                            if (tablero[i - 1, j] == 2)
                            {
                                for (int esp = i; esp > 0; esp--)
                                {

                                    if (tablero[esp, j] == 2 && tablero[esp - 1, j] == 0)
                                    {
                                        Botones[esp - 1, j].BorderStyle = BorderStyle.Solid;
                                        Botones[esp - 1, j].BorderWidth = 3;
                                        Botones[esp - 1, j].BorderColor = Color.White;
                                        Botones[esp - 1, j].OnClientClick = "this.disabled = false";
                                        break;

                                    }

                                }

                            }
                        }
                        if (i < 7) {
                             if (tablero[i + 1, j] == 2)
                            {

                                for (int esp = i; esp < 7; esp++)
                                {

                                    if (tablero[esp,j] == 2 && tablero[ esp + 1,j] == 0)
                                    {
                                        Botones[ esp + 1, j].BorderStyle = BorderStyle.Solid;
                                        Botones[ esp + 1, j].BorderWidth = 3;
                                        Botones[ esp + 1, j].BorderColor = Color.White;
                                        Botones[esp + 1, j].OnClientClick = "this.disabled = false";
                                        break;

                                    }

                                }

                            }
                        }
                        if (i > 1 && j > 1) {
                             if (tablero[i - 1, j - 1] == 2)
                            {
                                bool stopLoop = false;
                                for (int fila = i-1; fila > 0; fila--)
                                {
                                    for (int columna = j-1; columna > 0; columna--)
                                    {
                                        if (tablero[fila, columna] == 2 && tablero[fila - 1, columna - 1] == 0 && tablero[fila , columna - 1] != 3 && tablero[fila - 1, columna ] != 3)
                                        {
                                            Botones[fila - 1, columna - 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila - 1, columna - 1].BorderWidth = 3;
                                            Botones[fila - 1, columna - 1].BorderColor = Color.White;
                                            Botones[fila - 1, columna - 1].OnClientClick = "this.disabled = false";
                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }



                            }
                        }
                        if (i > 1 && j < 7) {
                             if (tablero[i - 1, j + 1] == 2)
                             {
                                bool stopLoop = false;
                                for (int fila = i - 1; fila > 0; fila--)
                                {
                                    for (int columna = j + 1; columna <7; columna++)
                                    {
                                        if (tablero[fila, columna] == 2 && tablero[fila - 1, columna + 1] == 0 && tablero[fila, columna + 1] != 3 && tablero[fila - 1, columna] != 3)
                                        {
                                            Botones[fila - 1, columna + 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila - 1, columna + 1].BorderWidth = 3;
                                            Botones[fila - 1, columna + 1].BorderColor = Color.White;
                                            Botones[fila - 1, columna + 1].OnClientClick = "this.disabled = false";
                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }

                             }
                        }
                        if (i < 7 && j > 1) {
                            if (tablero[i + 1, j - 1] == 2)
                            {
                                bool stopLoop = false;
                                for (int fila = i + 1; fila <7; fila++)
                                {
                                    for (int columna = j - 1; columna >0; columna--)
                                    {
                                        if (tablero[fila, columna] == 2 && tablero[fila + 1, columna - 1] == 0 && tablero[fila+1, columna ] != 3 && tablero[fila , columna-1] != 3)
                                        {
                                            Botones[fila + 1, columna - 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila + 1, columna - 1].BorderWidth = 3;
                                            Botones[fila + 1, columna - 1].BorderColor = Color.White;
                                            Botones[fila + 1, columna - 1].OnClientClick = "this.disabled = false";
                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }

                            }
                        }
                        if (i < 7 && j < 7) {
                            if (tablero[i + 1, j + 1] == 2)
                            {
                                bool stopLoop = false;
                                for (int fila = i + 1; fila < 7; fila++)
                                {
                                    for (int columna = j + 1; columna < 7; columna++)
                                    {
                                        if (tablero[fila, columna] == 2 && tablero[fila + 1, columna + 1] == 0 && tablero[fila + 1, columna] != 3 && tablero[fila, columna + 1] != 3)
                                        {
                                            Botones[fila + 1, columna + 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila + 1, columna + 1].BorderWidth = 3;
                                            Botones[fila + 1, columna + 1].BorderColor = Color.White;
                                            Botones[fila + 1, columna + 1].OnClientClick = "this.disabled = false";
                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }
                            }
                        }

                    }


                    if (tablero[i, j] == 2 && jugadorNegro )
                    {
                        if (j < 7)
                        {
                            if (tablero[i, j + 1] == 1)
                            {


                                for (int esp = j; esp < 7; esp++)
                                {

                                    if (tablero[i, esp] == 1 && tablero[i, esp + 1] == 0)
                                    {
                                        Botones[i, esp + 1].BorderStyle = BorderStyle.Solid;
                                        Botones[i, esp + 1].BorderWidth = 3;
                                        Botones[i, esp + 1].BorderColor = Color.Black;
                                        Botones[i, esp + 1].OnClientClick = "this.disabled = false";
                                        break;

                                    }

                                }

                            }
                        }
                        if (j > 1)
                        {
                            if (tablero[i, j - 1] == 1)
                            {

                                for (int esp = j; esp > 0; esp--)
                                {

                                    if (tablero[i, esp] == 1 && tablero[i, esp - 1] == 0)
                                    {
                                        Botones[i, esp - 1].BorderStyle = BorderStyle.Solid;
                                        Botones[i, esp - 1].BorderWidth = 3;
                                        Botones[i, esp - 1].BorderColor = Color.Black;
                                        Botones[i, esp - 1].OnClientClick = "this.disabled = false";
                                        break;

                                    }

                                }

                            }
                        }
                        if (i > 1)
                        {
                            if (tablero[i - 1, j] == 1)
                            {
                                for (int esp = i; esp > 0; esp--)
                                {

                                    if (tablero[esp, j] == 1 && tablero[esp - 1, j] == 0)
                                    {
                                        Botones[esp - 1, j].BorderStyle = BorderStyle.Solid;
                                        Botones[esp - 1, j].BorderWidth = 3;
                                        Botones[esp - 1, j].BorderColor = Color.Black;
                                        Botones[esp - 1, j].OnClientClick = "this.disabled = false";
                                        break;

                                    }

                                }

                            }
                        }
                        if (i < 7)
                        {
                            if (tablero[i + 1, j] == 1)
                            {

                                for (int esp = i; esp < 7; esp++)
                                {

                                    if (tablero[esp, j] == 1 && tablero[esp + 1, j] == 0)
                                    {
                                        Botones[esp + 1, j].BorderStyle = BorderStyle.Solid;
                                        Botones[esp + 1, j].BorderWidth = 3;
                                        Botones[esp + 1, j].BorderColor = Color.Black;
                                        Botones[esp + 1, j].OnClientClick = "this.disabled = false";
                                        break;

                                    }

                                }

                            }
                        }
                        if (i > 1 && j > 1)
                        {
                            if (tablero[i - 1, j - 1] == 1)
                            {
                                bool stopLoop = false;
                                for (int fila = i - 1; fila > 0; fila--)
                                {
                                    for (int columna = j - 1; columna > 0; columna--)
                                    {
                                        if (tablero[fila, columna] == 1 && tablero[fila - 1, columna - 1] == 0 && tablero[fila, columna - 1] != 3 && tablero[fila - 1, columna] != 3)
                                        {
                                            Botones[fila - 1, columna - 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila - 1, columna - 1].BorderWidth = 3;
                                            Botones[fila - 1, columna - 1].BorderColor = Color.Black;
                                            Botones[fila - 1, columna - 1].OnClientClick = "this.disabled = false";
                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }



                            }
                        }
                        if (i > 1 && j < 7)
                        {
                            if (tablero[i - 1, j + 1] == 1)
                            {
                                bool stopLoop = false;
                                for (int fila = i - 1; fila > 0; fila--)
                                {
                                    for (int columna = j + 1; columna < 7; columna++)
                                    {
                                        if (tablero[fila, columna] == 1 && tablero[fila - 1, columna + 1] == 0 && tablero[fila, columna + 1] != 3 && tablero[fila - 1, columna] != 3)
                                        {
                                            Botones[fila - 1, columna + 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila - 1, columna + 1].BorderWidth = 3;
                                            Botones[fila - 1, columna + 1].BorderColor = Color.Black;
                                            Botones[fila - 1, columna + 1].OnClientClick = "this.disabled = false";
                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }

                            }
                        }
                        if (i < 7 && j > 1)
                        {
                            if (tablero[i + 1, j - 1] == 1)
                            {
                                bool stopLoop = false;
                                for (int fila = i + 1; fila < 7; fila++)
                                {
                                    for (int columna = j - 1; columna > 0; columna--)
                                    {
                                        if (tablero[fila, columna] == 1 && tablero[fila + 1, columna - 1] == 0 && tablero[fila + 1, columna] != 3 && tablero[fila, columna - 1] != 3)
                                        {
                                            Botones[fila + 1, columna - 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila + 1, columna - 1].BorderWidth = 3;
                                            Botones[fila + 1, columna - 1].BorderColor = Color.Black;
                                            Botones[fila + 1, columna - 1].OnClientClick = "this.disabled = false";
                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }

                            }
                        }
                        if (i < 7 && j < 7)
                        {
                            if (tablero[i + 1, j + 1] == 1)
                            {
                                bool stopLoop = false;
                                for (int fila = i + 1; fila < 7; fila++)
                                {
                                    for (int columna = j + 1; columna < 7; columna++)
                                    {
                                        if (tablero[fila, columna] == 1 && tablero[fila + 1, columna + 1] == 0 && tablero[fila + 1, columna] != 3 && tablero[fila, columna + 1] != 3)
                                        {
                                            Botones[fila + 1, columna + 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila + 1, columna + 1].BorderWidth = 3;
                                            Botones[fila + 1, columna + 1].BorderColor = Color.Black;
                                            Botones[fila + 1, columna + 1].OnClientClick = "this.disabled = false";
                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }
                            }
                        }

                    }


                }

            }

        }




        protected void gameMoves(ImageButton btn)
        {
            /*BorderStyle = "Solid" BorderWidth = "10" BorderColor = "White"
              Botones[contador + espaciador].BorderStyle = BorderStyle.Solid;
              Botones[contador + espaciador].BorderWidth = 10;
             Botones[contador + espaciador].BorderColor = Color.White;
             */

            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {


                    if (tablero[i, j] == 1 && jugadorBlanco)
                    {
                        if (j < 7)
                        {
                            if (tablero[i, j + 1] == 2)
                            {


                                for (int esp = j; esp < 7; esp++)
                                {

                                    if (tablero[i, esp] == 2 && tablero[i, esp + 1] == 0)
                                    {
                                     /*ya*/   
                                        if (Botones[i,esp+1].ID.Equals(btn.ID) && btn.ID != null)
                                         {

                                             string id = btn.ID.ToString();
                                             string dos = id.Substring(11, 2);
                                             int numeroposicion = Convert.ToInt32(dos) - 1;
                                             int conta = 0;
                                             for (int x = esp + 1; x >j; x--)
                                             {
                                                 Botones[i, x].ImageUrl  = "~/Imagenes/white.png";
                                                 Juego[numeroposicion-conta] = 1;
                                                 conta += 1;
                                             }


                                         }
                                        break;

                                    }


                                }


                            }
                        }
                        if (j > 1)
                        {
                            if (tablero[i, j - 1] == 2)
                            {

                                for (int esp = j; esp > 0; esp--)
                                {

                                    if (tablero[i, esp] == 2 && tablero[i, esp - 1] == 0)
                                    {
                                        /*Botones[i, esp - 1].BorderStyle = BorderStyle.Solid;
                                        Botones[i, esp - 1].BorderWidth = 3;
                                        Botones[i, esp - 1].BorderColor = Color.White;
                                        Botones[i, esp - 1].OnClientClick = "this.disabled = false";*/

                                        if (Botones[i, esp - 1].ID.Equals(btn.ID) && btn.ID != null)
                                        {

                                            string id = btn.ID.ToString();
                                            string dos = id.Substring(11, 2);
                                            int numeroposicion = Convert.ToInt32(dos) - 1;
                                            int conta = 0;
                                            for (int x = esp - 1; x < j; x++)
                                            {
                                                Botones[i, x].ImageUrl = "~/Imagenes/white.png";
                                                Juego[numeroposicion + conta] = 1;
                                                conta += 1;
                                            }


                                        }

                                        break;

                                    }

                                }

                            }
                        }
                        if (i > 1)
                        {
                            if (tablero[i - 1, j] == 2)
                            {
                                for (int esp = i; esp > 0; esp--)
                                {

                                    if (tablero[esp, j] == 2 && tablero[esp - 1, j] == 0)
                                    {
                                         if (Botones[esp-1, j].ID.Equals(btn.ID) && btn.ID != null)
                                        {

                                            string id = btn.ID.ToString();
                                            string dos = id.Substring(11, 2);
                                            int numeroposicion = Convert.ToInt32(dos) - 1;
                                            int conta = 0;
                                            for (int x = esp - 1; x < i; x++)
                                            {
                                                Botones[x, j].ImageUrl = "~/Imagenes/white.png";
                                                Juego[numeroposicion + conta] = 1;
                                                conta += 8;
                                            }


                                        }
                                        break;

                                    }

                                }

                            }
                        }
                        if (i < 7)
                        {
                            if (tablero[i + 1, j] == 2)
                            {

                                for (int esp = i; esp < 7; esp++)
                                {

                                    if (tablero[esp, j] == 2 && tablero[esp + 1, j] == 0)
                                    {
                                        /*  Botones[esp + 1, j].BorderStyle = BorderStyle.Solid;
                                          Botones[esp + 1, j].BorderWidth = 3;
                                          Botones[esp + 1, j].BorderColor = Color.White;
                                          Botones[esp + 1, j].OnClientClick = "this.disabled = false";
                                          break;*/
                                        if (Botones[esp + 1, j].ID.Equals(btn.ID) && btn.ID != null)
                                        {

                                            string id = btn.ID.ToString();
                                            string dos = id.Substring(11, 2);
                                            int numeroposicion = Convert.ToInt32(dos) - 1;
                                            int conta = 0;
                                            for (int x = esp + 1; x > i; x--)
                                            {
                                                Botones[x, j].ImageUrl = "~/Imagenes/white.png";
                                                Juego[numeroposicion + conta] = 1;
                                                conta -= 8;
                                            }


                                        }
                                        break;
                                    }

                                }

                            }
                        }
                        if (i > 1 && j > 1)
                        {
                            if (tablero[i - 1, j - 1] == 2)
                            {
                                bool stopLoop = false;
                                for (int fila = i - 1; fila > 0; fila--)
                                {
                                    for (int columna = j - 1; columna > 0; columna--)
                                    {
                                        if (tablero[fila, columna] == 2 && tablero[fila - 1, columna - 1] == 0 && tablero[fila, columna - 1] != 3 && tablero[fila - 1, columna] != 3)
                                        {
                                            /* Botones[fila - 1, columna - 1].BorderStyle = BorderStyle.Solid;
                                             Botones[fila - 1, columna - 1].BorderWidth = 3;
                                             Botones[fila - 1, columna - 1].BorderColor = Color.White;
                                             Botones[fila - 1, columna - 1].OnClientClick = "this.disabled = false";*/
                                            if (Botones[fila -1 , columna -1].ID.Equals(btn.ID) && btn.ID != null)
                                            {

                                                string id = btn.ID.ToString();
                                                string dos = id.Substring(11, 2);
                                                int numeroposicion = Convert.ToInt32(dos) - 1;
                                                int conta = 0;
                                                int x = fila - 1;
                                                    for (int y = columna-1; y <j; y++ )
                                                    {
                                                        Botones[x, y].ImageUrl = "~/Imagenes/white.png";
                                                        x += 1;
                                                        Juego[numeroposicion + conta] = 1;
                                                        conta += 9;

                                                    
                                                }


                                            }


                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }



                            }
                        }
                        if (i > 1 && j < 7)
                        {
                            if (tablero[i - 1, j + 1] == 2)
                            {
                                bool stopLoop = false;
                                for (int fila = i - 1; fila > 0; fila--)
                                {
                                    for (int columna = j + 1; columna < 7; columna++)
                                    {
                                        if (tablero[fila, columna] == 2 && tablero[fila - 1, columna + 1] == 0 && tablero[fila, columna + 1] != 3 && tablero[fila - 1, columna] != 3)
                                        {
                                            /*Botones[fila - 1, columna + 1].BorderStyle = BorderStyle.Solid;
                                            Botones[fila - 1, columna + 1].BorderWidth = 3;
                                            Botones[fila - 1, columna + 1].BorderColor = Color.White;
                                            Botones[fila - 1, columna + 1].OnClientClick = "this.disabled = false";*/


                                             if (Botones[fila -1 , columna +1].ID.Equals(btn.ID) && btn.ID != null)
                                            {

                                                string id = btn.ID.ToString();
                                                string dos = id.Substring(11, 2);
                                                int numeroposicion = Convert.ToInt32(dos) - 1;
                                                int conta = 0;
                                                int x = fila - 1;
                                                    for (int y = columna+1; y >j; y-- )
                                                    {
                                                        Botones[x, y].ImageUrl = "~/Imagenes/white.png";
                                                        x += 1;
                                                        Juego[numeroposicion + conta] = 1;
                                                        conta += 9;

                                                    
                                                }


                                            }





                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }

                            }
                        }
                        if (i < 7 && j > 1)
                        {
                            if (tablero[i + 1, j - 1] == 2)
                            {
                                bool stopLoop = false;
                                for (int fila = i + 1; fila < 7; fila++)
                                {
                                    for (int columna = j - 1; columna > 0; columna--)
                                    {
                                        if (tablero[fila, columna] == 2 && tablero[fila + 1, columna - 1] == 0 && tablero[fila + 1, columna] != 3 && tablero[fila, columna - 1] != 3)
                                        {
                                            /* Botones[fila + 1, columna - 1].BorderStyle = BorderStyle.Solid;
                                             Botones[fila + 1, columna - 1].BorderWidth = 3;
                                             Botones[fila + 1, columna - 1].BorderColor = Color.White;
                                             Botones[fila + 1, columna - 1].OnClientClick = "this.disabled = false";
                                             stopLoop = true;*/

                                            if (Botones[fila + 1, columna - 1].ID.Equals(btn.ID) && btn.ID != null)
                                            {

                                                string id = btn.ID.ToString();
                                                string dos = id.Substring(11, 2);
                                                int numeroposicion = Convert.ToInt32(dos) - 1;
                                                int conta = 0;
                                                int x = fila + 1;
                                                for (int y = columna - 1; y < j; y++)
                                                {
                                                    Botones[x, y].ImageUrl = "~/Imagenes/white.png";
                                                    x -= 1;
                                                    Juego[numeroposicion + conta] = 1;
                                                    conta -= 9;


                                                }


                                            }





                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }

                            }
                        }
                        if (i < 7 && j < 7)
                        {
                            if (tablero[i + 1, j + 1] == 2)
                            {
                                bool stopLoop = false;
                                for (int fila = i + 1; fila < 7; fila++)
                                {
                                    for (int columna = j + 1; columna < 7; columna++)
                                    {
                                        if (tablero[fila, columna] == 2 && tablero[fila + 1, columna + 1] == 0 && tablero[fila + 1, columna] != 3 && tablero[fila, columna + 1] != 3)
                                        {
                                            /* Botones[fila + 1, columna + 1].BorderStyle = BorderStyle.Solid;
                                             Botones[fila + 1, columna + 1].BorderWidth = 3;
                                             Botones[fila + 1, columna + 1].BorderColor = Color.White;
                                             Botones[fila + 1, columna + 1].OnClientClick = "this.disabled = false";
                                             stopLoop = true;*/





                                            if (Botones[fila + 1, columna + 1].ID.Equals(btn.ID) && btn.ID != null)
                                            {

                                                string id = btn.ID.ToString();
                                                string dos = id.Substring(11, 2);
                                                int numeroposicion = Convert.ToInt32(dos) - 1;
                                                int conta = 0;
                                                int x = fila + 1;
                                                for (int y = columna + 1; y > j; y--)
                                                {
                                                    Botones[x, y].ImageUrl = "~/Imagenes/white.png";
                                                    x -= 1;
                                                    Juego[numeroposicion + conta] = 1;
                                                    conta -= 9;


                                                }


                                            }





                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }
                            }
                        }

                    }


                    if (tablero[i, j] == 2 && jugadorNegro)
                    {
                        if (j < 7)
                        {
                            if (tablero[i, j + 1] == 1)
                            {


                                for (int esp = j; esp < 7; esp++)
                                {

                                    if (tablero[i, esp] == 1 && tablero[i, esp + 1] == 0)
                                    {
                                        /* Botones[i, esp + 1].BorderStyle = BorderStyle.Solid;
                                         Botones[i, esp + 1].BorderWidth = 3;
                                         Botones[i, esp + 1].BorderColor = Color.Black;
                                         Botones[i, esp + 1].OnClientClick = "this.disabled = false";*/
                                        if (Botones[i, esp + 1].ID.Equals(btn.ID) && btn.ID != null)
                                        {

                                            string id = btn.ID.ToString();
                                            string dos = id.Substring(11, 2);
                                            int numeroposicion = Convert.ToInt32(dos) - 1;
                                            int conta = 0;
                                            for (int x = esp + 1; x > j; x--)
                                            {
                                                Botones[i, x].ImageUrl = "~/Imagenes/black.png";
                                                Juego[numeroposicion - conta] = 2;
                                                conta += 1;
                                            }


                                        }
                                        break;

                                    }

                                }

                            }
                        }
                        if (j > 1)
                        {
                            if (tablero[i, j - 1] == 1)
                            {

                                for (int esp = j; esp > 0; esp--)
                                {

                                    if (tablero[i, esp] == 1 && tablero[i, esp - 1] == 0)
                                    {
                                        /* Botones[i, esp - 1].BorderStyle = BorderStyle.Solid;
                                         Botones[i, esp - 1].BorderWidth = 3;
                                         Botones[i, esp - 1].BorderColor = Color.Black;
                                         Botones[i, esp - 1].OnClientClick = "this.disabled = false";*/
                                        if (Botones[i, esp - 1].ID.Equals(btn.ID) && btn.ID != null)
                                        {

                                            string id = btn.ID.ToString();
                                            string dos = id.Substring(11, 2);
                                            int numeroposicion = Convert.ToInt32(dos) - 1;
                                            int conta = 0;
                                            for (int x = esp - 1; x < j; x++)
                                            {
                                                Botones[i, x].ImageUrl = "~/Imagenes/black.png";
                                                Juego[numeroposicion + conta] = 2;
                                                conta += 1;
                                            }


                                        }

                                        break;

                                    }

                                }

                            }
                        }
                        if (i > 1)
                        {
                            if (tablero[i - 1, j] == 1)
                            {
                                for (int esp = i; esp > 0; esp--)
                                {

                                    if (tablero[esp, j] == 1 && tablero[esp - 1, j] == 0)
                                    {
                                        /* Botones[esp - 1, j].BorderStyle = BorderStyle.Solid;
                                         Botones[esp - 1, j].BorderWidth = 3;
                                         Botones[esp - 1, j].BorderColor = Color.Black;
                                         Botones[esp - 1, j].OnClientClick = "this.disabled = false";*/

                                        if (Botones[esp - 1, j].ID.Equals(btn.ID) && btn.ID != null)
                                        {

                                            string id = btn.ID.ToString();
                                            string dos = id.Substring(11, 2);
                                            int numeroposicion = Convert.ToInt32(dos) - 1;
                                            int conta = 0;
                                            for (int x = esp - 1; x < i; x++)
                                            {
                                                Botones[x, j].ImageUrl = "~/Imagenes/black.png";
                                                Juego[numeroposicion + conta] = 2;
                                                conta += 8;
                                            }


                                        }
                                        break;

                                    }

                                }

                            }
                        }
                        if (i < 7)
                        {
                            if (tablero[i + 1, j] == 1)
                            {

                                for (int esp = i; esp < 7; esp++)
                                {

                                    if (tablero[esp, j] == 1 && tablero[esp + 1, j] == 0)
                                    {
                                        /* Botones[esp + 1, j].BorderStyle = BorderStyle.Solid;
                                         Botones[esp + 1, j].BorderWidth = 3;
                                         Botones[esp + 1, j].BorderColor = Color.Black;
                                         Botones[esp + 1, j].OnClientClick = "this.disabled = false";*/
                                        if (Botones[esp + 1, j].ID.Equals(btn.ID) && btn.ID != null)
                                        {

                                            string id = btn.ID.ToString();
                                            string dos = id.Substring(11, 2);
                                            int numeroposicion = Convert.ToInt32(dos) - 1;
                                            int conta = 0;
                                            for (int x = esp + 1; x > i; x--)
                                            {
                                                Botones[x, j].ImageUrl = "~/Imagenes/black.png";
                                                Juego[numeroposicion + conta] = 2;
                                                conta -= 8;
                                            }


                                        }
                                        break;

                                    }

                                }

                            }
                        }
                        if (i > 1 && j > 1)
                        {
                            if (tablero[i - 1, j - 1] == 1)
                            {
                                bool stopLoop = false;
                                for (int fila = i - 1; fila > 0; fila--)
                                {
                                    for (int columna = j - 1; columna > 0; columna--)
                                    {
                                        if (tablero[fila, columna] == 1 && tablero[fila - 1, columna - 1] == 0 && tablero[fila, columna - 1] != 3 && tablero[fila - 1, columna] != 3)
                                        {
                                            /* Botones[fila - 1, columna - 1].BorderStyle = BorderStyle.Solid;
                                             Botones[fila - 1, columna - 1].BorderWidth = 3;
                                             Botones[fila - 1, columna - 1].BorderColor = Color.Black;
                                             Botones[fila - 1, columna - 1].OnClientClick = "this.disabled = false";
                                             stopLoop = true;*/

                                            if (Botones[fila - 1, columna - 1].ID.Equals(btn.ID) && btn.ID != null)
                                            {

                                                string id = btn.ID.ToString();
                                                string dos = id.Substring(11, 2);
                                                int numeroposicion = Convert.ToInt32(dos) - 1;
                                                int conta = 0;
                                                int x = fila - 1;
                                                for (int y = columna - 1; y < j; y++)
                                                {
                                                    Botones[x, y].ImageUrl = "~/Imagenes/black.png";
                                                    x += 1;
                                                    Juego[numeroposicion + conta] = 2;
                                                    conta += 9;


                                                }


                                            }


                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }



                            }
                        }
                        if (i > 1 && j < 7)
                        {
                            if (tablero[i - 1, j + 1] == 1)
                            {
                                bool stopLoop = false;
                                for (int fila = i - 1; fila > 0; fila--)
                                {
                                    for (int columna = j + 1; columna < 7; columna++)
                                    {
                                        if (tablero[fila, columna] == 1 && tablero[fila - 1, columna + 1] == 0 && tablero[fila, columna + 1] != 3 && tablero[fila - 1, columna] != 3)
                                        {
                                            /* Botones[fila - 1, columna + 1].BorderStyle = BorderStyle.Solid;
                                             Botones[fila - 1, columna + 1].BorderWidth = 3;
                                             Botones[fila - 1, columna + 1].BorderColor = Color.Black;
                                             Botones[fila - 1, columna + 1].OnClientClick = "this.disabled = false";
                                             stopLoop = true;*/

                                            if (Botones[fila - 1, columna + 1].ID.Equals(btn.ID) && btn.ID != null)
                                            {

                                                string id = btn.ID.ToString();
                                                string dos = id.Substring(11, 2);
                                                int numeroposicion = Convert.ToInt32(dos) - 1;
                                                int conta = 0;
                                                int x = fila - 1;
                                                for (int y = columna + 1; y > j; y--)
                                                {
                                                    Botones[x, y].ImageUrl = "~/Imagenes/black.png";
                                                    x += 1;
                                                    Juego[numeroposicion + conta] = 2;
                                                    conta += 9;


                                                }


                                            }





                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }

                            }
                        }
                        if (i < 7 && j > 1)
                        {
                            if (tablero[i + 1, j - 1] == 1)
                            {
                                bool stopLoop = false;
                                for (int fila = i + 1; fila < 7; fila++)
                                {
                                    for (int columna = j - 1; columna > 0; columna--)
                                    {
                                        if (tablero[fila, columna] == 1 && tablero[fila + 1, columna - 1] == 0 && tablero[fila + 1, columna] != 3 && tablero[fila, columna - 1] != 3)
                                        {
                                            /*  Botones[fila + 1, columna - 1].BorderStyle = BorderStyle.Solid;
                                              Botones[fila + 1, columna - 1].BorderWidth = 3;
                                              Botones[fila + 1, columna - 1].BorderColor = Color.Black;
                                              Botones[fila + 1, columna - 1].OnClientClick = "this.disabled = false";
                                              stopLoop = true;*/
                                            if (Botones[fila + 1, columna - 1].ID.Equals(btn.ID) && btn.ID != null)
                                            {

                                                string id = btn.ID.ToString();
                                                string dos = id.Substring(11, 2);
                                                int numeroposicion = Convert.ToInt32(dos) - 1;
                                                int conta = 0;
                                                int x = fila + 1;
                                                for (int y = columna - 1; y < j; y++)
                                                {
                                                    Botones[x, y].ImageUrl = "~/Imagenes/black.png";
                                                    x -= 1;
                                                    Juego[numeroposicion + conta] = 2;
                                                    conta -= 9;


                                                }


                                            }

                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }

                            }
                        }
                        if (i < 7 && j < 7)
                        {
                            if (tablero[i + 1, j + 1] == 1)
                            {
                                bool stopLoop = false;
                                for (int fila = i + 1; fila < 7; fila++)
                                {
                                    for (int columna = j + 1; columna < 7; columna++)
                                    {
                                        if (tablero[fila, columna] == 1 && tablero[fila + 1, columna + 1] == 0 && tablero[fila + 1, columna] != 3 && tablero[fila, columna + 1] != 3)
                                        {
                                            /* Botones[fila + 1, columna + 1].BorderStyle = BorderStyle.Solid;
                                             Botones[fila + 1, columna + 1].BorderWidth = 3;
                                             Botones[fila + 1, columna + 1].BorderColor = Color.Black;
                                             Botones[fila + 1, columna + 1].OnClientClick = "this.disabled = false";
                                             stopLoop = true;*/
                                            if (Botones[fila + 1, columna + 1].ID.Equals(btn.ID) && btn.ID != null)
                                            {

                                                string id = btn.ID.ToString();
                                                string dos = id.Substring(11, 2);
                                                int numeroposicion = Convert.ToInt32(dos) - 1;
                                                int conta = 0;
                                                int x = fila + 1;
                                                for (int y = columna + 1; y > j; y--)
                                                {
                                                    Botones[x, y].ImageUrl = "~/Imagenes/black.png";
                                                    x -= 1;
                                                    Juego[numeroposicion + conta] = 2;
                                                    conta -= 9;


                                                }


                                            }





                                            stopLoop = true;
                                            break;
                                        }
                                    }
                                    if (stopLoop) { break; }

                                }
                            }
                        }

                    }


                }

            }

        }



        protected void Turno()
            {
            Random rnd = new Random();
            int random = rnd.Next(1, 3);
            if (random == 1)
                {
                mensage = true;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Inicia el jugador con fichas blancas" + "');", true);
                
                jugadorBlanco = true;

                }
                else{
                mensage = true;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Inicia el jugador con fichas negras" + "');", true);
                determinaTurno = true;
                jugadorNegro =  true;
                }


            }

            protected void Button1_Click(object sender, EventArgs e)
            {
                List<ImageButton> lis = new List<ImageButton>() {
             ImageButton011A,
             ImageButton021B,
             ImageButton031C,
             ImageButton041D,
             ImageButton051E,
             ImageButton061F,
             ImageButton071G,
             ImageButton081H,
             ImageButton092A,
             ImageButton102B,
             ImageButton112C,
             ImageButton122D,
             ImageButton132E,
             ImageButton142F,
             ImageButton152G,
             ImageButton162H,
             ImageButton173A,
             ImageButton183B,
             ImageButton193C,
             ImageButton203D,
             ImageButton213E,
             ImageButton223F,
             ImageButton233G,
             ImageButton243H,
             ImageButton254A,
             ImageButton264B,
             ImageButton274C,
             ImageButton284D,
             ImageButton294E,
             ImageButton304F,
             ImageButton314G,
             ImageButton324H,
             ImageButton335A,
             ImageButton345B,
             ImageButton355C,
             ImageButton365D,
             ImageButton375E,
             ImageButton385F,
             ImageButton395G,
             ImageButton405H,
             ImageButton416A,
             ImageButton426B,
             ImageButton436C,
             ImageButton446D,
             ImageButton456E,
             ImageButton466F,
             ImageButton476G,
             ImageButton486H,
             ImageButton497A,
             ImageButton507B,
             ImageButton517C,
             ImageButton527D,
             ImageButton537E,
             ImageButton547F,
             ImageButton557G,
             ImageButton567H,
             ImageButton578A,
             ImageButton588B,
             ImageButton598C,
             ImageButton608D,
             ImageButton618E,
             ImageButton628F,
             ImageButton638G,
             ImageButton648H,
             };
                XmlTextReader xmlTextReader = new XmlTextReader(TextBox1.Text);
                string ficha = "";
                List<string> partida = new List<string>();
                int contador = 0;
                string tiro = "";
                XmlDocument doc = new XmlDocument();
                doc.Load(TextBox1.Text);
                while (xmlTextReader.Read())
                {
                    if (xmlTextReader.NodeType == XmlNodeType.Element)
                    {
                        if (xmlTextReader.Name.Equals("ficha"))
                        {
                            ficha = "";
                        }
                    }
                    if (xmlTextReader.NodeType == XmlNodeType.Text)
                    {
                        ficha += xmlTextReader.ReadContentAsString() + "-";
                        contador += 1;
                        if (contador == 3)
                        {
                            partida.Add(ficha);
                            contador = 0;
                        }
                    }
                }
                XmlNode node = doc.SelectSingleNode("tablero").SelectSingleNode("siguienteTiro");
                tiro = node.SelectSingleNode("color").InnerText.ToString();
                string[] separadas;
                MyStaticBool = true;
                for (int i = 0; i < partida.Count; i++)
                {
                    separadas = partida[i].Split('-');

                    string color = separadas[0];
                    string posicion = separadas[2] + separadas[1];
                    if (color == "blanco")
                    {
                        int indice = Array.IndexOf(xmlGame, posicion);
                        if (indice != -1)
                        {
                            Juego[indice] = 1;
                            lis[indice].ImageUrl = "~/Imagenes/white.png";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "campos fuera del tablero" + "');", true);
                        }
                    }
                    if (color == "negro")
                    {
                        int indice = Array.IndexOf(xmlGame, posicion);
                        if (indice != -1)
                        {
                            Juego[indice] = 2;
                            lis[indice].ImageUrl = "~/Imagenes/black.png";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "campos fuera del tablero" + "');", true);
                        }
                    }

                }




            }

            protected void actualizar()
            {
                List<ImageButton> lis = new List<ImageButton>() {
             ImageButton011A,
             ImageButton021B,
             ImageButton031C,
             ImageButton041D,
             ImageButton051E,
             ImageButton061F,
             ImageButton071G,
             ImageButton081H,
             ImageButton092A,
             ImageButton102B,
             ImageButton112C,
             ImageButton122D,
             ImageButton132E,
             ImageButton142F,
             ImageButton152G,
             ImageButton162H,
             ImageButton173A,
             ImageButton183B,
             ImageButton193C,
             ImageButton203D,
             ImageButton213E,
             ImageButton223F,
             ImageButton233G,
             ImageButton243H,
             ImageButton254A,
             ImageButton264B,
             ImageButton274C,
             ImageButton284D,
             ImageButton294E,
             ImageButton304F,
             ImageButton314G,
             ImageButton324H,
             ImageButton335A,
             ImageButton345B,
             ImageButton355C,
             ImageButton365D,
             ImageButton375E,
             ImageButton385F,
             ImageButton395G,
             ImageButton405H,
             ImageButton416A,
             ImageButton426B,
             ImageButton436C,
             ImageButton446D,
             ImageButton456E,
             ImageButton466F,
             ImageButton476G,
             ImageButton486H,
             ImageButton497A,
             ImageButton507B,
             ImageButton517C,
             ImageButton527D,
             ImageButton537E,
             ImageButton547F,
             ImageButton557G,
             ImageButton567H,
             ImageButton578A,
             ImageButton588B,
             ImageButton598C,
             ImageButton608D,
             ImageButton618E,
             ImageButton628F,
             ImageButton638G,
             ImageButton648H,
             };
                for (int i = 0; i == 64; i++)
                {

                    if (Juego[i] == 1)
                    {
                        lis[i].ImageUrl = "~/Imagenes/white.png";
                    }
                    else if (Juego[i] == 2)
                    {
                        lis[i].ImageUrl = "~/Imagenes/black.png";
                    }
                    else
                    {
                        lis[i].ImageUrl = "~/Imagenes/wood-table-surface.jpg";
                    }

                }
            }

            protected void Button2_Click(object sender, EventArgs e)
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", null));
                XElement nodoRaiz = new XElement("tablero");
                document.Add(nodoRaiz);
                Label2.Text = " ";
                for (int i = 0; i < 64; i++)
                {

                    Label2.Text += Juego[i].ToString();
                    if (Juego[i] == 1)
                    {
                        XElement ficha = new XElement("ficha");

                        string colorTex = "blanco";
                        string posicion = xmlGame[i];
                        string fila = posicion.Substring(0, 1);
                        string columna = posicion.Substring(1, 1);
                        ficha.Add(new XElement("color", colorTex));
                        ficha.Add(new XElement("columna", columna));
                        ficha.Add(new XElement("fila", fila));
                        nodoRaiz.Add(ficha);
                    }
                    else if (Juego[i] == 2)
                    {
                        XElement ficha = new XElement("ficha");

                        string colorTex = "negro";
                        string posicion = xmlGame[i];
                        string fila = posicion.Substring(0, 1);
                        string columna = posicion.Substring(1, 1);
                        ficha.Add(new XElement("color", colorTex));
                        ficha.Add(new XElement("columna", columna));
                        ficha.Add(new XElement("fila", fila));
                        nodoRaiz.Add(ficha);
                    }


                }
                document.Save(@"C:\Users\y\Source\Repos\Yoba-a\prub\prub\XML\tablero.xml");
                Label1.Text = "xml generado";
            }
        }
    }
