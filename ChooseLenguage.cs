using System;
using System.Collections;

class ChooseLanguage
{
    protected int option;
    protected Font font24;
    protected Image pointer;
    protected Image shot;
    protected int pointerY;
    protected int shotX;
    protected bool activeShot;
    public static Hashtable lenguage;

    public ChooseLanguage()
    {
        pointer = new Image("data/nave_izq.png");
        shot = new Image("data/disparo.png");
        option = 0;
        font24 = new Font("data/Joystix.ttf", 24);
        pointerY = 200;
        shotX = 500;
        lenguage = new Hashtable();
    }

    public int GetChosenOption()
    {
        return option;
    }

    public void Run()
    {
        option = 0;
        SdlHardware.ClearScreen();

        SdlHardware.DrawHiddenImage(pointer, 500, pointerY);
        SdlHardware.DrawHiddenImage(shot, shotX, pointerY + 13);

        SdlHardware.WriteHiddenText("CHOOSE YOUR LENGUAGE:",
            400, 100,
            0xC0, 0xC0, 0xC0,
            font24);

        SdlHardware.WriteHiddenText("SPANISH",
            300, 200,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("ENGLISH",
            300, 300,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("FRENCH",
            310, 400,
           0xC0, 0xC0, 0xC0,
            font24);

        SdlHardware.WriteHiddenText("PRESS SPACE TO SELECT",
            350, 550,
           0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("use the up and down arrows to scroll",
            220, 600,
           0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("between the options",
           350, 650,
          0xC0, 0xC0, 0xC0,
           font24);
        
        SdlHardware.ShowHiddenScreen();

        if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN) && pointerY < 400)
        {
            pointerY += 100;
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_UP) && pointerY > 200)
        {
            pointerY -= 100;
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_SPC))
        {
            activeShot = true;
        }

        if (activeShot && shotX > 400)
        {
            shotX -= 10;
        }
        else if (shotX <= 400)
        {
            switch (pointerY)
            {
                case 200:
                    option = 1;
                    lenguage.Add("play", "Jugar");
                    lenguage.Add("credits", "Creditos");
                    lenguage.Add("quit", "Salir");
                    lenguage.Add("score", "Puntuación:");
                    lenguage.Add("maxScore", "Máxima puntuación:");
                    lenguage.Add("level", "Nivel:");
                    lenguage.Add("toReturn", "Para volver");
                    lenguage.Add("press2", "p2 pulsa 2");
                    lenguage.Add("lives1", "vidas p1");
                    lenguage.Add("lives2", "vidas p2");
                    lenguage.Add("unbeatable", "invencible");
                    lenguage.Add("controlsAndMore", "controles y más");
                    lenguage.Add("controls", "controles");
                    lenguage.Add("player1", "jugador 1");
                    lenguage.Add("player2", "jugador 2");
                    lenguage.Add("moveP1", "Para rotar a la " +
                            "izquierda presione la flecha izquierda " +
                            "y para rotar a la derecha la flecha derecha");
                    lenguage.Add("control2", "Para disparar pulse");
                    lenguage.Add("control3", "Para moverse pulse");
                    lenguage.Add("control4", "Para teletransportarse pulse");
                    lenguage.Add("moveP2", "Para rotar a la " +
                           "izquierda presione 'q' " +
                           "y para rotar a la derecha presione 'e'");
                    lenguage.Add("details", "detalles");
                    lenguage.Add("development1", "El juego consiste en " +
                        "destruir disparando el mayor número de enemigos" +
                        " posibles");
                    lenguage.Add("development2", "el jugador 1 esta " +
                        "representado por una flecha roja : ");
                    lenguage.Add("development3", "el jugador 2 esta " +
                        "representado por una flecha azul : ");
                    lenguage.Add("development4", "cuando seamos " +
                        "alcanzados por un enemigo perderemos una vida");
                    lenguage.Add("development5", "y nos volveremos " +
                        "invencibles hasta que disparemos");
                    lenguage.Add("chooseP2", "Para jugar con el segundo" +
                        " jugador pulse 2 en el juego");


                    break;
                case 300:
                    option = 2;
                    lenguage.Add("play", "Play");
                    lenguage.Add("credits", "Credits");
                    lenguage.Add("quit", "Quit");
                    lenguage.Add("score", "Score:");
                    lenguage.Add("maxScore", "Max score:");
                    lenguage.Add("level", "Level:");
                    lenguage.Add("toReturn", "To return");
                    lenguage.Add("press2", "p2 press 2");
                    lenguage.Add("lives1", "lives p1");
                    lenguage.Add("lives2", "lives p2");
                    lenguage.Add("unbeatable", "unbeatable");
                    lenguage.Add("controlsAndMore", "controls and more");
                    lenguage.Add("controls", "controls");
                    lenguage.Add("player1", "player 1");
                    lenguage.Add("player2", "player 2");
                    lenguage.Add("moveP1", "to rotate to the left press " +
                        "the left arrow and to rotate the right arrow to the right");
                    lenguage.Add("control2", "to shoot press");
                    lenguage.Add("control3", "to move press");
                    lenguage.Add("control4", "to teleport press");
                    lenguage.Add("moveP2", "to rotate to the left press " +
                       "the 'q' and to rotate the right press 'e'");
                    lenguage.Add("details", "details");

                    break;

                case 400:
                    option = 3;
                    lenguage.Add("play", "jouer");
                    lenguage.Add("credits", "crédits");
                    lenguage.Add("quit", "sortir");
                    lenguage.Add("score", "ponctuation:");
                    lenguage.Add("maxScore", "note maximale:");
                    lenguage.Add("level", "niveau:");
                    lenguage.Add("toReturn", "pour revenir");
                    lenguage.Add("press2", "p2 appuyer sur 2");
                    lenguage.Add("lives1", "vies p1");
                    lenguage.Add("lives2", "vies p2");
                    lenguage.Add("unbeatable", "imbattable");
                    lenguage.Add("controlsAndMore", "contrôles et plus encore");
                    lenguage.Add("controls", "commandes");
                    lenguage.Add("player1", "joueur 1");
                    lenguage.Add("player2", "joueur 2");
                    lenguage.Add("moveP1", "pour tourner vers la gauche, " +
                        "appuyez sur la flèche vers la gauche et pour faire" +
                        " pivoter la flèche droite vers la droite");
                    lenguage.Add("control2", "pour tirer appuyez sur le");
                    lenguage.Add("control3", "pour déplacer, appuyez sur " +
                        "les touches");
                    lenguage.Add("control4", "Pour se téléporter, appuyez sur");
                    lenguage.Add("moveP2", "pour tourner vers la gauche, " +
                        "appuyez sur 'q' la et pour faire" +
                        " pivoter 'e' la droite");
                    lenguage.Add("details", "détails");

                    break;
            }
            shotX = 500;
            activeShot = false;
        }

        SdlHardware.Pause(120); // To avoid using 100% CPU        
    }
}

