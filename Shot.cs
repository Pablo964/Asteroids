using System;
using System.Linq;

class Shot : Sprite
{
    protected int shotSpeed;
    static Sound fireSound, deathEnemySound;
    protected static int quantityEnemiesInBoss = 6;

    public Shot()
    {
        LoadImage("data/disparo.png");
        x = 50;
        y = 120;
        xSpeed = ySpeed = 0;
        width = 10;
        height = 10;
        shotSpeed = 45;

        fireSound = new Sound("data/asteroidsFire.wav");
        deathEnemySound = new Sound("data/asteroidsDeath.wav");
    }

    public int GetshotSpeed() { return shotSpeed; }
    public void SetshotSpeed() { this.shotSpeed = 22; }

    public static void CollisionShot(int shotPlayer, ref bool activeShot)
    {
        
        for (int i = 0; i < Game.enemies.Count; i++)
        {
            if ((Game.shot[shotPlayer].CollisionsWith(Game.enemies[i])
                       && Game.enemyAlive[i] == true
                       && activeShot == true)
                       && Game.enemies[i].TypeEnemy() != "smallAsteroid")
            {

                Game.enemyAlive[i] = false;

                if (shotPlayer == 0)
                    deathEnemySound.PlayOnce();
                else
                    deathEnemySound.PlayOnce();

                activeShot = false;

                Random rnd = new Random();

                for (int j = 0; j < 2; j++)
                {
                    if (Game.enemies[i].TypeEnemy() == "bigAsteroid")
                    {
                        Game.enemies.Add(new MediumAsteroid());
                    }
                    else
                    {
                        Game.enemies.Add(new SmallAsteroid());
                    }

                    Game.enemies.Last().MoveTo(Game.enemies[i].GetX(),
                            Game.enemies[i].GetY());

                    Game.enemies.Last().SetSpeed(rnd.Next(1, 5),
                        rnd.Next(1, 5));

                    Game.enemyAlive.Add(true);
                    Game.enemies[j].DrawOnHiddenScreen();
                }
                if (Game.enemies[i].TypeEnemy() == "boss")
                {
                    for (int x = 0; x < quantityEnemiesInBoss; x++)
                    {
                    
                        Game.enemies.Add(new Enemy());
                        Game.enemies.Last().MoveTo(Game.enemies[i].GetX(),
                            Game.enemies[i].GetY());

                        Game.enemies.Last().SetSpeed(rnd.Next(1, 10),
                            rnd.Next(1, 10));

                        Game.enemyAlive.Add(true);
                        Game.enemies[x].DrawOnHiddenScreen();
                    }
                    
                }
                Game.score += 20;
            }
            else if (Game.shot[shotPlayer].CollisionsWith(Game.enemies[i])
                    && Game.enemyAlive[i] == true
                    && activeShot == true
                    && Game.enemies[i].TypeEnemy() == "smallAsteroid")
            {
                deathEnemySound.PlayOnce();
                Game.enemyAlive[i] = false;
                activeShot = false;
            }
        }
    }
    
    public static void Shoot(Player player, ref int coolDownShot, 
            int positionShot, ref int positionSprite, ref bool activeShot)
    {

        fireSound.PlayOnce();

        Game.shot[positionShot].MoveTo(player.GetX() + 12, player.GetY() + 16);
        Game.shot[positionShot].LoadImage(Game.GetImageShot());

        coolDownShot = 30;
        activeShot = true;
        Game.shot[positionShot].ShotDirection(positionSprite, positionShot);
    }

    /*
     * this method receives the shot from the player who took it
     * and depending on where the player is looking adds or
     * subtracts speed to the x-axis or y-axis.
     */
    public void ShotDirection(int position, int playerShot)
    {
        switch (position)
        {

            case 0:
                Game.shot[playerShot].speedY(-shotSpeed);
                Game.shot[playerShot].speedX(0);
                break;

            case 1:

                Game.shot[playerShot].speedY(((-shotSpeed)) / 2);
                Game.shot[playerShot].speedX((shotSpeed) / 2);
                break;

            case 2:
                Game.shot[playerShot].speedY(-shotSpeed / 2);
                Game.shot[playerShot].speedX(shotSpeed / 2);
                break;

            case 3:
                Game.shot[playerShot].speedY(-shotSpeed / 2);
                Game.shot[playerShot].speedX(shotSpeed / 2);
                break;

            case 4:
                Game.shot[playerShot].speedX(shotSpeed);
                Game.shot[playerShot].speedY(0);
                break;

            case 5:
                Game.shot[playerShot].speedY(shotSpeed / 2);
                Game.shot[playerShot].speedX(shotSpeed / 2);
                break;

            case 6:
                Game.shot[playerShot].speedY(shotSpeed / 2);
                Game.shot[playerShot].speedX(shotSpeed / 2);
                break;

            case 7:
                Game.shot[playerShot].speedY(shotSpeed / 2);
                Game.shot[playerShot].speedX(shotSpeed / 2);
                break;

            case 8:
                Game.shot[playerShot].speedY(shotSpeed);
                Game.shot[playerShot].speedX(0);
                break;

            case 9:
                Game.shot[playerShot].speedY(shotSpeed / 2);
                Game.shot[playerShot].speedX(-shotSpeed / 2);
                break;

            case 10:
                Game.shot[playerShot].speedY(shotSpeed / 2);
                Game.shot[playerShot].speedX(-shotSpeed / 2);
                break;

            case 11:
                Game.shot[playerShot].speedY(shotSpeed / 2);
                Game.shot[playerShot].speedX(-shotSpeed / 2);
                break;

            case 12:
                Game.shot[playerShot].speedX(-shotSpeed);
                Game.shot[playerShot].speedY(0);
                break;

            case 13:
                Game.shot[playerShot].speedY(-shotSpeed / 2);
                Game.shot[playerShot].speedX(-shotSpeed / 2);
                break;

            case 14:
                Game.shot[playerShot].speedY(-shotSpeed / 2);
                Game.shot[playerShot].speedX(-shotSpeed / 2);
                break;

            case 15:
                Game.shot[playerShot].speedY(-shotSpeed / 2);
                Game.shot[playerShot].speedX(-shotSpeed / 2);
                break;
        }
    }

    public void speedY(int speed)
    {
        this.ySpeed = speed;
    }

    public void speedX(int speed)
    {
        this.xSpeed = speed;
    }
    public void Move(int position)
    {
        MoveRight(position);
        MoveDown(position);
    }

    public void MoveRight(int position)
    {
        switch (position)
        {
            case 1:
                x += xSpeed + 1;
                break;
            default:
                x += xSpeed;
                break;
        }

    }

    public void MoveDown(int position)
    {
        switch (position)
        {
            case 1:
                y += ySpeed + 5;
                break;
            default:
                y += ySpeed;
                break;
        }
    }

}


