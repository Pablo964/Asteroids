/**
 * Game.cs - Asteroids
 * 
 * Changes:
 * Acceleration
 * Rotation player
 */

using System;

class Game
{

    static Player player;

    static int numEnemies;


    static Enemy[] enemies;

    protected Room room;

    static bool finished;

    protected Font font18;

    //NEW
    const int SIZE = 4;
    protected string[] imagesPlayer;
    public static int position = 0;
    protected int acceleration;
    protected int coolDown;
    //-----

    public Game()
    {
        player = new Player();
        player.MoveTo(200, 100);

        numEnemies = 2;
        enemies = new Enemy[numEnemies];


        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i] = new Enemy();
        }

        finished = false;

        Random rnd = new Random();
        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i].MoveTo(rnd.Next(200, 800),
                rnd.Next(50, 600));
            enemies[i].SetSpeed(rnd.Next(1, 5),
                rnd.Next(1, 5));
        }

        Font font18 = new Font("data/Joystix.ttf", 18);
        

        SdlHardware.WriteHiddenText("Score: ",
            40, 10,
            0xCC, 0xCC, 0xCC,
            font18);

        room = new Room();

        //NEW
        imagesPlayer = new string[SIZE];
        imagesPlayer[0] = "data/nave_up.png";
        imagesPlayer[1] = "data/nave_der.png";
        imagesPlayer[2] = "data/nave_down.png";
        imagesPlayer[3] = "data/nave_izq.png";

        coolDown = 0;
        //-----
    }



    void UpdateScreen()
    {
        SdlHardware.ClearScreen();

        room.DrawOnHiddenScreen();

        player.DrawOnHiddenScreen();
        for (int i = 0; i < numEnemies; i++)
            enemies[i].DrawOnHiddenScreen();
        SdlHardware.ShowHiddenScreen();
    }


    void CheckUserInput()
    {
        if (coolDown > 0)
        {
            coolDown--;
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;


        player.Reduce();

        if (SdlHardware.KeyPressed(SdlHardware.KEY_SPC))
        {

            if (position == 2)
            {
                player.IncSpeedY(8);
            }

            else if (position == 0)
            {
                player.IncSpeedY(-10);
            }
            else if (position == 3)
            {
                player.IncSpeedX(-10);
            }
            else if (position == 1)
            {
                player.IncSpeedX(10);
            }
        }

        player.Move();

        if (coolDown > 0)
        {
            return;
        }

        //NEW
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
        {
<<<<<<< HEAD
            position++;
            if (position < 0)
            {
                position = SIZE - 1;
            }
            else if (position > (SIZE - 1))
            {
                position = 0;
            }
            player.LoadImage(imagesPlayer[position]);

            coolDown = 5;
=======
            player.MoveRight();
            /*if (room.CanMoveTo(player.GetX() + player.GetSpeedX(),
                    player.GetY(),
                    player.GetX() + player.GetWidth() + player.GetSpeedX(),
                    player.GetY() + player.GetHeight()))
                player.MoveRight();*/
        }    
>>>>>>> master

        }
        //NEW
        if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
<<<<<<< HEAD
        {
=======
            player.MoveLeft();
        /*if (room.CanMoveTo(player.GetX() - player.GetSpeedX(),
                player.GetY(),
                player.GetX() + player.GetWidth() - player.GetSpeedX(),
                player.GetY() + player.GetHeight()))
            player.MoveLeft();*/

        if (SdlHardware.KeyPressed(SdlHardware.KEY_UP))
            player.MoveUp();
        /*if (room.CanMoveTo(player.GetX(),
                player.GetY() - player.GetSpeedY(),
                player.GetX() + player.GetWidth(),
                player.GetY() + player.GetHeight() - player.GetSpeedY()))
            player.MoveUp();*/

        if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN))
            player.MoveDown();
        /*if (room.CanMoveTo(player.GetX(),
                player.GetY() + player.GetSpeedY(),
                player.GetX() + player.GetWidth(),
                player.GetY() + player.GetHeight() + player.GetSpeedY()))
            player.MoveDown();*/
>>>>>>> master

            position--;
            if (position < 0)
            {
                position = SIZE - 1;
            }
            else if (position > (SIZE - 1))
            {
                position--;
            }
            player.LoadImage(imagesPlayer[position]);

            coolDown = 5;
        }
        //NEW
    }

    static void UpdateWorld()
    {
        // Move enemies, background, etc 
        for (int i = 0; i < numEnemies; i++)
            enemies[i].Move();
    }

    static void CheckGameStatus()
    {
        // Check collisions and apply game logic
        for (int i = 0; i < numEnemies; i++)
            if (player.CollisionsWith(enemies[i]))
                finished = true;
    }

    static void PauseUntilNextFrame()
    {
        SdlHardware.Pause(40);
    }

    static void UpdateHighscore()
    {
        // Save highest score
        // TO DO
    }

    public void Run()
    {
        do
        {
            UpdateScreen();
            CheckUserInput();
            UpdateWorld();
            PauseUntilNextFrame();
            CheckGameStatus();
        }
        while (!finished);

        UpdateHighscore();
    }
}