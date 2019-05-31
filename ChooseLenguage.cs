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
                    lenguage.Add("tricks", "trucos");
                    lenguage.Add("immortal", "inmortal");
                    lenguage.Add("yes", "si");
                    lenguage.Add("no", "no");
                    lenguage.Add("morePoints", "más puntos");
                    lenguage.Add("instructionsTricks1", "use las flechas " +
                        "arriba y abajo para desplazarse");
                    lenguage.Add("instructionsTricks2", "y use las flechas " +
                        "izq y der para cambiar la selección");
                    lenguage.Add("bossEvery", "jefe cada ");
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
                        "the left arrow and to rotate the right arrow " +
                        "to the right");
                    lenguage.Add("control2", "to shoot press");
                    lenguage.Add("control3", "to move press");
                    lenguage.Add("control4", "to teleport press");
                    lenguage.Add("moveP2", "to rotate to the left press " +
                       "the 'q' and to rotate the right press 'e'");
                    lenguage.Add("details", "details");
                    lenguage.Add("development1", "The game consists of " +
                       "destroy by firing as many enemies as possible");
                    lenguage.Add("development2", "player 1 is represented by" +
                        " a red arrow : ");
                    lenguage.Add("development3", "player 2 is represented" +
                        " by a blue arrow: ");
                    lenguage.Add("development4", "when we're hit by an enemy" +
                        " we'll lose a life.");
                    lenguage.Add("development5", "and we'll become " +
                        "invincible until we fire.");
                    lenguage.Add("chooseP2", "To play with the second " +
                        "player press 2 in the game");
                    lenguage.Add("tricks", "tricks");
                    lenguage.Add("immortal", "immortal");
                    lenguage.Add("yes", "yes");
                    lenguage.Add("no", "no");
                    lenguage.Add("morePoints", "more points");
                    lenguage.Add("instructionsTricks1", "use the arrows " +
                        "up and down to scroll");
                    lenguage.Add("instructionsTricks2", "and use the arrows "+
                        "left and right to change the selection");
                    lenguage.Add("bossEvery", "boss every ");

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
                    lenguage.Add("controlsAndMore", "contrôles et " +
                        "plus encore");
                    lenguage.Add("controls", "commandes");
                    lenguage.Add("player1", "joueur 1");
                    lenguage.Add("player2", "joueur 2");
                    lenguage.Add("moveP1", "pour tourner vers la gauche, " +
                        "appuyez sur la flèche vers la gauche et pour faire" +
                        " pivoter la flèche droite vers la droite");
                    lenguage.Add("control2", "pour tirer appuyez sur le");
                    lenguage.Add("control3", "pour déplacer, appuyez sur " +
                        "les touches");
                    lenguage.Add("control4", "Pour se téléporter, " +
                        "appuyez sur");
                    lenguage.Add("moveP2", "pour tourner vers la gauche, " +
                        "appuyez sur 'q' la et pour faire" +
                        " pivoter 'e' la droite");
                    lenguage.Add("details", "détails");
                    lenguage.Add("development1", "Le jeu consiste à détruire"+
                        " en tirant sur autant d'ennemis que possible.");
                    lenguage.Add("development2", "le joueur 1 est représenté" +
                        " par une flèche rouge : ");
                    lenguage.Add("development3", "le joueur 2 est représenté" +
                        " par une flèche bleue: ");
                    lenguage.Add("development4", "quand nous sommes frappés" +
                        " par un ennemi, nous perdons une vie.");
                    lenguage.Add("development5", "et nous deviendrons " +
                        "invincibles jusqu'à ce qu'on tire.");
                    lenguage.Add("chooseP2", "Pour jouer avec le deuxième" +
                        " joueur, appuyez sur 2 dans le jeu.");
                    lenguage.Add("tricks", "trucs");
                    lenguage.Add("immortal", "immortel");
                    lenguage.Add("yes", "oui");
                    lenguage.Add("no", "pas");
                    lenguage.Add("morePoints", "plus de points");
                    lenguage.Add("instructionsTricks1", "utiliser les flèches"+
                        " vers le haut et vers le bas défiler");
                    lenguage.Add("instructionsTricks2", "et utilisez les " +
                        "flèches gauche et droite pour sélection.");
                    lenguage.Add("bossEvery", "boss tous les");
                    break;
            }
            shotX = 500;
            activeShot = false;
        }
        SdlHardware.Pause(120);      
    }
}

