/*
 * all variables with suffix 1 belong to player 1, 
 * and those with suffix 2 belong to player 2
 */
using System;
using System.Collections.Generic;
using System.IO;

class Game
{

    public static Player player;
    public static Player player2;
    public static bool player2Active;
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

    private Image imageArrowP1;
    private Image imageArrowP2;

    


    public Game()
    {
        maxEnemies = 20;
        player = new Player();
        player.MoveTo(200, 100);
        shot = new List<Shot>();
        shot.Add(new Shot());
        numEnemies = 1;
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
        activeShot2 = false;

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

        
        levelUp = true;
        maxVelocidad = 5;
        level = 1;

        shot.Add(new Shot());
        shot.Add(new Shot());
        shot[1].SetshotSpeed();

        imageArrowP1 = new Image("data/1player.png");
        imageArrowP2 = new Image("data/2player.png");

        

    }

    public static string GetImageShot() { return imageShot; }
    public static StreamReader GetInputMaxScore() { return inputMaxScore; }

    void UpdateScreen()
    {
        SdlHardware.ClearScreen();
        player.DrawLives(120);

        room.DrawOnHiddenScreen();
        if (player.GetAlive() == true)
        {
            player.DrawOnHiddenScreen();
        }

        if (player2Active)
        {
            if (player.GetAlive() == true)
            {
                SdlHardware.DrawHiddenImage(imageArrowP1, player.GetX() + 7,
                   player.GetY() - 30);
            }
            if (player2.GetAlive() == true)
            {
                player2.DrawOnHiddenScreen();
                SdlHardware.DrawHiddenImage(imageArrowP2, player2.GetX() + 7,
                    player2.GetY() - 30);
            }
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
            Console.WriteLine("Enemies game: " + enemies.Count);
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
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["lives1"] + "",
            100, 10,
            0xC0, 0xC0, 0xC0,
            font24);

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

        if (Room.bossStage)
        {
            SdlHardware.WriteHiddenText("BOSS STAGE",
            400, 60,
            0xC0, 0xC0, 0xC0,
            font24);
        }
        if (!player2Active)
        {
            SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["press2"] + "",
            700, 10,
            0xC0, 0xC0, 0xC0,
            font24);
        }
        else
        {
            SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["lives2"] + "",
            750, 10,
            0xC0, 0xC0, 0xC0,
            font24);
            player2.DrawLives(760);

            if (player2.GetUnbeatable() == true)
            {
                player2.DrawUnbeatable();
            }
        }
        if (player.GetUnbeatable() == true)
        {
            player.DrawUnbeatable();
        }
        
        SdlHardware.ShowHiddenScreen();

        levelUp = true;
    }


    void CheckUserInput()
    {
        if (player.GetcoolDownRevive() > 0)
        {
            player.SetcoolDownRevive(player.GetcoolDownRevive() - 5);
        }
        if (player2Active)
        {
            if (player2.GetcoolDownRevive() > 0)
            {
                player2.SetcoolDownRevive(player2.GetcoolDownRevive() - 5);
            }
        }
        if (coolDownChangeSprite > 0)
        {
            coolDownChangeSprite -= 9;

        }
        if (coolDownShot > 0)
        {
            coolDownShot -= 2;
        }
        if (coolDownShot <= 0)
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
            if (coolDownShot2 <= 0)
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


        //PLAYER 1
        if (player.GetcoolDownRevive() > 0)
        {
            return;
        }
        else
        {
            player.SetContainsSequence(false);
        }
        if (player.GetAlive() == true)
        {
            if (!(coolDownShot > 0 && player.GetcoolDownRevive() == 0))
            {

                if (SdlHardware.KeyPressed(SdlHardware.KEY_I))
                {
                    player.SetUnbeatable(false);

                    Shot.Shoot(player, ref coolDownShot, 0, ref position,
                        ref activeShot);
                }
            }
            player.Reduce();

            if (SdlHardware.KeyPressed(SdlHardware.KEY_O)
                    && player.GetcoolDownRevive() == 0)
            {
                player.ChangeVelocity(position, ref player);
            }

            player.Move();
            shot[0].Move(position);

            if (coolDownChangeSprite > 0)
            {
                return;
            }

            if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT)
                    && player.GetcoolDownRevive() == 0)
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

            if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT)
                    && player.GetcoolDownRevive() == 0)
            {
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

            if (SdlHardware.KeyPressed(SdlHardware.KEY_P)
                    && player.GetcoolDownRevive() == 0)
            {
                if (!(enfriamientoTeletransporte > 0) && numTeletransportes > 0)
                {
                    player.Teletransporte();
                    enfriamientoTeletransporte = 70;
                    numTeletransportes--;
                }
            }
        }
        //PLAYER 2
        
        if (player2Active)
        {
            if (player2.GetcoolDownRevive() > 0)
            {
                return;
            }
            else
            {
                player2.SetContainsSequence(false);
            }
            if (player2.GetAlive() == true)
            {
                player2.Reduce();
                if (SdlHardware.KeyPressed(SdlHardware.KEY_N)
                        && player2.GetcoolDownRevive() == 0)
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

                if (SdlHardware.KeyPressed(SdlHardware.KEY_E)
                        && player2.GetcoolDownRevive() == 0)
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

                if (SdlHardware.KeyPressed(SdlHardware.KEY_Q)
                        && player2.GetcoolDownRevive() == 0)
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

                if (SdlHardware.KeyPressed(SdlHardware.KEY_M)
                        && player2.GetcoolDownRevive() == 0)
                {
                    if (!(enfriamientoTeletransporte2 > 0)
                            && numTeletransportes2 > 0)
                    {
                        player2.Teletransporte();
                        enfriamientoTeletransporte2 = 70;
                        numTeletransportes2--;
                    }
                }

                if (!(coolDownShot2 > 0))
                {

                    if (SdlHardware.KeyPressed(SdlHardware.KEY_B) 
                            && player2Active 
                            && player2.GetcoolDownRevive() == 0)
                    {
                        player2.SetUnbeatable(false);
                        activeShot2 = true;
                        Shot.Shoot(player2, ref coolDownShot2, 1, ref position2,
                                ref activeShot2);
                    }
                }

                if (activeShot2)
                {
                    shot[1].Move(position);
                }
            }
        }
        
    }

    void UpdateWorld()
    {
        // Move enemies, background, etc 
        foreach (Enemy e in enemies)
        {
            e.Move();
            e.InfiniteScreen();
        }

        player.InfiniteScreen();

        if (player2Active)
        {
            player2.InfiniteScreen();
        }

        foreach (Shot s in shot)
        {
            s.InfiniteScreen();
        } 
    }


    public  void CheckGameStatus()
    {
        
        Shot.CollisionShot(0, ref activeShot);

        if (player.GetUnbeatable() == false)
            Player.CollisionPlayer(ref player);
        

        if ((player.GetAlive() == false && player2Active == false)||
                (player.GetAlive() == false && player2.GetAlive()== false))
        {
            finished = true;
            activeShot = false;
            activeShot2 = false;
            player2Active = false;
        }
        if (player.GetLives()<=0)
        {
            player.SetAlive(false);
        }

        
        if (player2Active)
        {
            if (activeShot2)
                Shot.CollisionShot(1, ref activeShot2);

            if (player2.GetUnbeatable() == false)
                Player.CollisionPlayer(ref player2);
            
            if (player2.GetLives() <= 0)
                player2.SetAlive(false);
        }
        if (finished == true)
        {
            try
            {
                if (File.Exists(fileMaxScore))
                {
                    inputMaxScore = new StreamReader(fileMaxScore);
                }
                
                string line = inputMaxScore.ReadLine();
                inputMaxScore.Close();
                maxScore = Convert.ToInt32(line);
                if (score > maxScore)
                {
                    maxScore = score;
                    File.WriteAllText(fileMaxScore,
                            Convert.ToString(score));
                }
                Score.Run(score, maxScore);
                score = 0;
            }
            catch (Exception e)
            {
                maxScore = score;
                Score.Run(score, maxScore);
                Console.WriteLine(e.Message);
            }
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