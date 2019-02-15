class Player : Sprite
{
    public Player()
    {
        LoadImage("data/nave_up.png");
        x = 50;
        y = 120;
        xSpeed = ySpeed = 0;
        width = 22;
        height = 15;
    }

    public void Reduce()
    {

        if (xSpeed > 0)
        {
            xSpeed -= 2;

        }
        else if (xSpeed < 0)
        {
            xSpeed += 2;
        }

        if (ySpeed > 0)
        {
            ySpeed -= 2;

        }
        else if (ySpeed < 0)
        {
            ySpeed += 2;
        }

    }
    public void IncSpeedY(int speed)
    {
        this.ySpeed += speed;

        if (ySpeed > 20)
        {
            ySpeed = 30;
        }
    }

    public void IncSpeedX(int speed)
    {
        this.xSpeed += speed;

        if (xSpeed > 20)
        {
            xSpeed = 30;
        }
    }
    public void Move()
    {
        MoveRight();
        MoveDown();
    }

    public void MoveRight()
    {
        x += xSpeed;
    }

    public void MoveLeft()
    {
        x -= xSpeed;
    }

    public void MoveUp()
    {
        y -= ySpeed;
    }

    public void MoveDown()
    {
        y += ySpeed;
    }
}

