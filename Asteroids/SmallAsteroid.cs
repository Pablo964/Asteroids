using System;

class SmallAsteroid : Enemy
{
    public SmallAsteroid()
    {
        LoadImage("data/smallAsteroid.png");
        width = 30;
        height = 26;
        xSpeed = rnd.Next(0, 9);
        ySpeed = rnd.Next(0, 9);
        negativeX = rnd.Next(0, 2);
        negativeY = rnd.Next(0, 2);
    }

    public override string TypeEnemy()
    {
        return "smallAsteroid";
    }
}
