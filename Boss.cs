
class Boss : Enemy
{

    public Boss()
    {
        LoadImage("data/boss.png");
        width = 300;
        height = 255;
        xSpeed = rnd.Next(0, 9);
        ySpeed = rnd.Next(0, 9);
        negativeX = rnd.Next(0, 2);
        negativeY = rnd.Next(0, 2);
    }

    public override string TypeEnemy()
    {
        return "boss";
    }
}

