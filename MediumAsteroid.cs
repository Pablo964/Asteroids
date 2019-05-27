using System;

class MediumAsteroid : Enemy
{
    public MediumAsteroid()
    {
        LoadImage("data/mediumAsteroid.png");
        width = 50;
        height = 43;
        xSpeed = rnd.Next(0, 9);
        ySpeed = rnd.Next(0, 9);
        negativeX = rnd.Next(0, 2);
        negativeY = rnd.Next(0, 2);
    }

    public override string TypeEnemy()
    {
        return "mediumAsteroid";
    }
}

