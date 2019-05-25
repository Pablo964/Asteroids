using System;
using System.IO;

class Player : Sprite
{
    protected int coolDown;
    protected int lives;
    protected bool alive;
    public bool unbeatable;
    protected Image live;
    protected Font font8;
    protected int unbeatableY;
    protected int unbeatableX;
    private int coolDownRevive;

    public Player()
    {
        LoadImage("data/nave_up.png");
        x = 50;
        y = 120;
        xSpeed = ySpeed = 0;
        width = 22;
        height = 15;
        coolDown = 0;
        lives = 3;
        alive = true;
        unbeatable = true;
        live = new Image("data/vida.png");
        font8 = new Font("data/Joystix.ttf", 8);
        
        LoadSequence(DISAPPEARING,
            new string[] { "data/explosion1.png",
                "data/explosion2.png", "data/explosion3.png",
                "data/explosion4.png"});
        
        coolDownRevive = 0;
    }

    public int GetcoolDownRevive() { return this.coolDownRevive; }
    public void SetcoolDownRevive(int newCoolDown)
    {
        this.coolDownRevive = newCoolDown;
    }
    public bool GetUnbeatable() { return unbeatable; }
    public void SetUnbeatable(bool newUnbeatable) { unbeatable = newUnbeatable;}

    public bool GetAlive() { return this.alive; }
    public void SetAlive(bool newAlive) { this.alive = newAlive; }

    public int GetLives() { return this.lives; }
    public void SetLives(int newLives) { this.lives = newLives; }

    public void DrawUnbeatable()
    {
        unbeatableY = y + 40;
        unbeatableX = x - 15;

        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["unbeatable"] + "",
            (short)unbeatableX, (short)unbeatableY,
            0xC0, 0xC0, 0xC0,
            font8);
    }

    public void DrawLives(int liveX)
    {
        if (lives == 3)
        {
            SdlHardware.DrawHiddenImage(live, liveX, 40);
            SdlHardware.DrawHiddenImage(live, liveX + 30, 40);
            SdlHardware.DrawHiddenImage(live, liveX + 60, 40);
        }
        if (lives == 2)
        {
            SdlHardware.DrawHiddenImage(live, liveX + 30, 40);
            SdlHardware.DrawHiddenImage(live, liveX + 10, 40);
        }
        if (lives == 1)
        {
            SdlHardware.DrawHiddenImage(live, liveX + 30, 40);
        }
        
    }

    public static void CollisionPlayer(ref Player player)
    {
        for (int i = 0; i < Game.enemies.Count; i++)
        {
            if (player.CollisionsWith(Game.enemies[i]) 
                && Game.enemyAlive[i] == true)
            {
                player.lives--;
                player.unbeatable = true;
                player.containsSequence = true;
                player.ChangeDirection(DISAPPEARING);
                player.coolDownRevive = 200;
                player.SetSpeed(0,0);
            }
        }
    }

    public void ChangeVelocity(int positionSprite, ref Player player)
    {
        switch (positionSprite)
        {
            case 0:
                player.IncSpeedY(-2);
                break;

            case 1:
                player.IncSpeedY(-6 / 2);
                player.IncSpeedX(6 / 2);
                break;

            case 2:
                player.IncSpeedY(-6 / 2);
                player.IncSpeedX(6 / 2);
                break;

            case 3:
                player.IncSpeedY(-6 / 2);
                player.IncSpeedX(6 / 2);
                break;

            case 4:
                player.IncSpeedX(6);
                break;

            case 5:
                player.IncSpeedY(6 / 2);
                player.IncSpeedX(6 / 2);
                break;

            case 6:
                player.IncSpeedY(6 / 2);
                player.IncSpeedX(6 / 2);
                break;

            case 7:
                player.IncSpeedY(6 / 2);
                player.IncSpeedX(6 / 2);
                break;

            case 8:
                player.IncSpeedY(6);
                break;

            case 9:
                player.IncSpeedY(6 / 2);
                player.IncSpeedX(-6 / 2);
                break;

            case 10:
                player.IncSpeedY(6 / 2);
                player.IncSpeedX(-6 / 2);
                break;

            case 11:
                player.IncSpeedY(6 / 2);
                player.IncSpeedX(-6 / 2);
                break;

            case 12:
                player.IncSpeedX(-6);
                break;

            case 13:
                player.IncSpeedY(-6 / 2);
                player.IncSpeedX(-6 / 2);
                break;

            case 14:
                player.IncSpeedY(-6 / 2);
                player.IncSpeedX(-6 / 2);
                break;

            case 15:
                player.IncSpeedY(-6 / 2);
                player.IncSpeedX(-6 / 2);
                break;
        }
    }

    public void Reduce()
    {
        if (coolDown > 0)
        {
            coolDown--;
        }

        if (coolDown > 0)
        {
            return;
        }

        if (xSpeed > 0)
        {
            xSpeed -= 1;

        }
        else if (xSpeed < 0)
        {
            xSpeed += 1;
        }

        if (ySpeed > 0)
        {
            ySpeed -= 1;

        }
        else if (ySpeed < 0)
        {
            ySpeed += 1;
        }

        coolDown = 6;

    }
    public void IncSpeedY(int speed)
    {
        this.ySpeed += +speed;

        if (ySpeed > 20)
        {
            ySpeed = 20;
        }
        if (ySpeed < -20)
        {
            ySpeed = -20;
        }
    }

    public void IncSpeedX(int speed)
    {
        this.xSpeed += speed;

        if (xSpeed > 20)
        {
            xSpeed = 20;
        }
        if (xSpeed < -20)
        {
            xSpeed = -20;
        }
    }
    override public void Move()
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

    public void Teletransporte()
    {
        Random aleatorio = new Random();
        int numAleatorio = aleatorio.Next(-70, 1000);

        x = numAleatorio;

        numAleatorio = aleatorio.Next(-20, 750);

        y = numAleatorio;
    }
}

