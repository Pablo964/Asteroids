using System;

class Enemy : Sprite
{
    protected static Random rnd = new Random();

    protected int negativeX;
    protected int negativeY;

    public Enemy()
    {
        LoadImage("data/enemy.png");
        width = 74;
        height = 63;
        xSpeed = rnd.Next(0, 9);
        ySpeed = rnd.Next(0, 9);
        negativeX = rnd.Next(0, 2);
        negativeY = rnd.Next(0, 2);
    }

    public override void Move()
    {
        x = (negativeX == 0) ? x-=xSpeed : x += xSpeed;

        y = (negativeY == 0) ? y -= ySpeed : y += xSpeed;
    }

    public virtual string TypeEnemy()
    {
        return "bigAsteroid";
    }
}

