using System;

class Room
{
    protected Image stars1, stars2;

    protected int mapHeight = 14, mapWidth = 35;
    protected int tileWidth = 51, tileHeight = 38;
    protected int leftMargin = 0, topMargin = 0;
    public static int quantityLevelToBoss = 2;
    public static bool bossStage = false;
    static Sound soundBoss;

    //aumentar array
    protected string[] levelData =
    {
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       "};

    public Room()
    {
        stars1 = new Image("data/estrellas3.png");
        stars2 = new Image("data/estrellas4.png");
        soundBoss = new Sound("data/bossStage.mp3");
    }

    public void DrawOnHiddenScreen()
    {
        for (int row = 0; row < mapHeight; row++)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                int posX = col * tileWidth + leftMargin;
                int posY = row * tileHeight + topMargin;
                switch (levelData[row][col])
                {
                    case '1': SdlHardware.DrawHiddenImage(stars1, posX, posY);
                        break;
                    case '2': SdlHardware.DrawHiddenImage(stars2, posX, posY);
                        break;
                }
            }
        }
    }

    public void NewLevel(ref int maxVelocidad, ref bool finished, 
            ref Player player)
    {
        Game.level += 1;

        if (Game.numEnemies < 20)
        {
            if (Game.level % quantityLevelToBoss == 0)
                Game.numEnemies++;
            else
                Game.numEnemies += 2;
        }
        if (maxVelocidad < 25)
        {
            maxVelocidad += 1;
        }

        if (Game.level % quantityLevelToBoss == 0)
        {
            bossStage = true;
            soundBoss.BackgroundPlay();
            Game.enemies.Add(new Boss());
        }
        else
        {
            soundBoss.StopMusic();
            bossStage = false;
            for (int i = 0; i < Game.numEnemies; i++)
            {
                Game.enemies.Add(new Enemy());
            }
        }
        finished = false;

        Random rnd = new Random();

        for (int i = 0; i < Game.enemies.Count; i++)
        {
            int randomX = rnd.Next(200, 800);
            int randomY = rnd.Next(50, 600);

            if (randomX > player.GetX() || randomX < player.GetX() ||
                    randomY > player.GetY() || randomY < player.GetY())
            {
                Game.enemies[i].MoveTo(randomX, randomY);
            }
            Game.enemies[i].SetSpeed(rnd.Next(1, maxVelocidad),
                rnd.Next(1, maxVelocidad));
        }

        for (int i = 0; i < Game.numEnemies; i++)
        {
            Game.enemyAlive.Add(true);
        }

    }
}
