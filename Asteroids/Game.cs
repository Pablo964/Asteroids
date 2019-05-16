using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Game
{

    public static Player player;
    public static Player player2;
    protected bool player2Active;
    public static List<Shot> shot;
    public static int numEnemies;
    protected int coolDownChangeSprite;
    protected int coolDownShot;

    protected int coolDownChangeSprite2;
    protected int coolDownShot2;

    protected int numTeletransportes;
    protected int enfriamientoTeletransporte;

    protected int numTeletransportes2;
    protected int enfriamientoTeletransporte2;

    public static List<Enemy> enemies;

    const int SIZE = 16;
    protected string[] imagesPlayer;
    protected int position;
    protected int position2;

    protected static string imageShot;

    public static bool activeShot;
    public static bool activeShot2;

    public static List<bool> enemyAlive;

    protected Room room;

    public static bool finished;
    public static int score;
    public static int maxScore;
    public static StreamReader inputMaxScore;

    Score s;
    public static string fileMaxScore = "maxScore.txt";
    static protected Font font24;

    protected bool levelUp;
    static protected int maxEnemies;
    protected int maxVelocidad;
    public static int level;

    public Game()
    {
        maxEnemies = 20;
        player = new Player();
        player.MoveTo(200, 100);
        shot = new List<Shot>();
        shot.Add(new Shot());
        numEnemies = 2;
        enemies = new List<Enemy>();
        //---
        enemyAlive = new List<bool>();


        for (int i = 0; i < numEnemies; i++)
        {
            enemies.Add(new Enemy());
        }


        finished = false;

        Random rnd = new Random();
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveTo(rnd.Next(200, 800),
                rnd.Next(50, 600));
            enemies[i].SetSpeed(rnd.Next(1, 5),
                rnd.Next(1, 5));
        }


        for (int i = 0; i < enemies.Count; i++)
        {
            enemyAlive.Add(true);
        }



        Font font18 = new Font("data/Joystix.ttf", 18);

        room = new Room();
        //NEW
        imagesPlayer = new string[SIZE];
        imagesPlayer[0] = "data/nave_up.png";
        imagesPlayer[1] = "data/nave_up4.png";
        imagesPlayer[2] = "data/nave_up5.png";
        imagesPlayer[3] = "data/nave_up6.png";
        imagesPlayer[4] = "data/nave_der.png";
        imagesPlayer[5] = "data/nave_down1.png";
        imagesPlayer[6] = "data/nave_down2.png";
        imagesPlayer[7] = "data/nave_down3.png";
        imagesPlayer[8] = "data/nave_down.png";
        imagesPlayer[9] = "data/nave_down4.png";
        imagesPlayer[10] = "data/nave_down5.png";
        imagesPlayer[11] = "data/nave_down6.png";
        imagesPlayer[12] = "data/nave_izq.png";
        imagesPlayer[13] = "data/nave_up1.png";
        imagesPlayer[14] = "data/nave_up2.png";
        imagesPlayer[15] = "data/nave_up3.png";

        imageShot = "data/disparo.png";

        //shotSpeed = 22;

        activeShot = false;

        position = 0;
        position2 = 0;

        coolDownChangeSprite = 0;
        coolDownShot = 0;

        coolDownChangeSprite2 = 0;
        coolDownShot2 = 0;

        numTeletransportes = 3;
        enfriamientoTeletransporte = 0;

        numTeletransportes2 = 3;
        enfriamientoTeletransporte2 = 0;
        //-----
        score = 0;
        s = new Score();
        font24 = new Font("data/Joystix.ttf", 24);

        if (File.Exists(fileMaxScore))
        {
            inputMaxScore = new StreamReader(fileMaxScore);
        }

        levelUp = true;
        maxVelocidad = 5;
        level = 1;


    }

    public static string GetImageShot() { return imageShot; }
    public static StreamReader GetInputMaxScore() { return inputMaxScore; }

    void UpdateScreen()
    {
        SdlHardware.ClearScreen();

        room.DrawOnHiddenScreen();

        player.DrawOnHiddenScreen();

        if (player2Active)
        {
            player2.DrawOnHiddenScreen();
        }

        if (shot.Count > 0 && activeShot == true)
        {
            shot[0].DrawOnHiddenScreen();
        }
        if (activeShot2)
        {
            shot[1].DrawOnHiddenScreen();
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemyAlive[i] != false)
            {
                enemies[i].DrawOnHiddenScreen();
            }
        }


        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemyAlive[i] == true)
            {
                levelUp = false;
            }
        }

        if (levelUp == true)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies.Remove(enemies[i]);
                enemyAlive.Remove(enemyAlive[i]);
            }


            room.NewLevel(ref maxVelocidad, ref finished, ref player);
        }

        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["level"] + " "
                + level,
            400, 10,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["score"] + " "
                + score,
            400, 40,
            0xC0, 0xC0, 0xC0,
            font24);

        if (!player2Active)
        {
            SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["press2"] + "",
            700, 10,
            0xC0, 0xC0, 0xC0,
            font24);
        }
        SdlHardware.ShowHiddenScreen();

        levelUp = true;
    }


    void CheckUserInput()
    {
        if (coolDownChangeSprite > 0)
        {
            coolDownChangeSprite -= 9;

        }
        if (coolDownShot > 0)
        {
            coolDownShot -= 2;
        }
        if (coolDownShot == 0)
        {
            activeShot = false;
        }
        if (enfriamientoTeletransporte > 0)
        {
            enfriamientoTeletransporte -= 9;
        }

        if (player2Active)
        {
            if (coolDownChangeSprite2 > 0)
            {
                coolDownChangeSprite2 -= 9;

            }
            if (coolDownShot2 > 0)
            {
                coolDownShot2 -= 2;
            }
            if (coolDownShot2 == 0)
            {
                activeShot2 = false;
            }
            if (enfriamientoTeletransporte2 > 0)
            {
                enfriamientoTeletransporte2 -= 9;
            }
        }


        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;

        if (SdlHardware.KeyPressed(SdlHardware.KEY_2))
        {
            player2Active = true;
            player2 = new Player();
            player2.MoveTo(200, 200);

        }
        if (!(coolDownShot > 0))
        {

            if (SdlHardware.KeyPressed(SdlHardware.KEY_I))
            {
                Shot.Shoot(player, ref coolDownShot, 0, ref position,
                    ref activeShot);
            }
        }
        if (!(coolDownShot2 > 0))
        {

            if (SdlHardware.KeyPressed(SdlHardware.KEY_N) && player2Active)
            {

                Shot.Shoot(player2, ref coolDownShot2, 1, ref position2,
                        ref activeShot2);
            }
        }
        player.Reduce();

        if (SdlHardware.KeyPressed(SdlHardware.KEY_O))
        {
            player.ChangeVelocity(position, ref player);
        }

        player.Move();
        shot[0].Move(position);

        if (activeShot2)
        {
            shot[1].Move(position);
        }

        if (coolDownChangeSprite > 0)
        {
            return;
        }


        //PLAYER 1
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
        {
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

            coolDownChangeSprite = 10;

        }
        //NEW
        if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
        {
            Console.WriteLine(position);
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

            coolDownChangeSprite = 10;
        }
        if (enfriamientoTeletransporte > 0)
        {
            return;
        }
        //NEW
        if (SdlHardware.KeyPressed(SdlHardware.KEY_P))
        {
            if (!(enfriamientoTeletransporte > 0) && numTeletransportes > 0)
            {
                player.Teletransporte();
                enfriamientoTeletransporte = 70;
                numTeletransportes--;
            }
        }

        //PLAYER 2
        if (player2Active)
        {
            player2.Reduce();
            if (SdlHardware.KeyPressed(SdlHardware.KEY_B))
            {
                player2.ChangeVelocity(position2, ref player2);
            }

            player2.Move();
            if (shot.Count > 1)
            {
                shot[1].Move(position2);
            }
            

            if (coolDownChangeSprite2 > 0)
            {
                return;
            }



            if (SdlHardware.KeyPressed(SdlHardware.KEY_E))
            {
                position2++;
                if (position2 < 0)
                {
                    position2 = SIZE - 1;
                }
                else if (position2 > (SIZE - 1))
                {
                    position2 = 0;
                }
                player2.LoadImage(imagesPlayer[position2]);

                coolDownChangeSprite2 = 10;

            }
            
            if (SdlHardware.KeyPressed(SdlHardware.KEY_Q))
            {

                position2--;
                if (position2 < 0)
                {
                    position2 = SIZE - 1;
                }
                else if (position2 > (SIZE - 1))
                {
                    position2--;
                }
                player2.LoadImage(imagesPlayer[position2]);

                coolDownChangeSprite2 = 10;
            }
            if (enfriamientoTeletransporte2 > 0)
            {
                return;
            }
            //NEW
            if (SdlHardware.KeyPressed(SdlHardware.KEY_M))
            {
                if (!(enfriamientoTeletransporte2 > 0) 
                        && numTeletransportes2 > 0)
                {
                    player2.Teletransporte();
                    enfriamientoTeletransporte2 = 70;
                    numTeletransportes2--;
                }
            }
        }
        
    }

    static void UpdateWorld()
    {
        // Move enemies, background, etc 
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].Move();
            enemies[i].InfiniteScreen();
        }

        player.InfiniteScreen();
        foreach (Shot s in shot)
        {
            s.InfiniteScreen();
        }
        
    }


    public  void CheckGameStatus()
    {
        Shot.CollisionShot(0, ref activeShot);
        Player.CollisionPlayer(ref player);

        if (player2Active)
        {
            if (activeShot2)
            {
                Shot.CollisionShot(1, ref activeShot2);
            }
            Player.CollisionPlayer(ref player2);
        } 
    }

    static void PauseUntilNextFrame()
    {
        SdlHardware.Pause(40);
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
    }
}