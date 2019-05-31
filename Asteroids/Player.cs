using System;

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
    static Sound deathPlayerSound;
    private int maxSpeed;
    private int valueIncreseSpeed;


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

        deathPlayerSound = new Sound("data/deathPlayerSound.wav");

        maxSpeed = 15;
        valueIncreseSpeed = 1;
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
                deathPlayerSound.PlayOnce();
                player.lives--;
                player.unbeatable = true;
                player.containsSequence = true;
                player.ChangeDirection(DISAPPEARING);
                player.coolDownRevive = 200;
                player.SetSpeed(0,0);
            }
        }
    }


    /*
    * this method receives the shot from the player who took it
    * and depending on where the player is looking adds or
    * subtracts speed to the x-axis or y-axis.
    */
    public void ChangeVelocity(int positionSprite, ref Player player)
    {
        switch (positionSprite)
        {
            case 0:
                player.IncSpeedY(-valueIncreseSpeed);
                break;

            case 1:
                player.IncSpeedY(-valueIncreseSpeed);
                player.IncSpeedX(valueIncreseSpeed);
                break;

            case 2:
                player.IncSpeedY(-valueIncreseSpeed);
                player.IncSpeedX(valueIncreseSpeed);
                break;

            case 3:
                player.IncSpeedY(-valueIncreseSpeed);
                player.IncSpeedX(valueIncreseSpeed);
                break;

            case 4:
                player.IncSpeedX(valueIncreseSpeed);
                break;

            case 5:
                player.IncSpeedY(valueIncreseSpeed);
                player.IncSpeedX(valueIncreseSpeed);
                break;

            case 6:
                player.IncSpeedY(valueIncreseSpeed);
                player.IncSpeedX(valueIncreseSpeed);
                break;

            case 7:
                player.IncSpeedY(valueIncreseSpeed);
                player.IncSpeedX(valueIncreseSpeed);
                break;

            case 8:
                player.IncSpeedY(valueIncreseSpeed);
                break;

            case 9:
                player.IncSpeedY(valueIncreseSpeed);
                player.IncSpeedX(-valueIncreseSpeed);
                break;

            case 10:
                player.IncSpeedY(valueIncreseSpeed);
                player.IncSpeedX(-valueIncreseSpeed);
                break;

            case 11:
                player.IncSpeedY(valueIncreseSpeed);
                player.IncSpeedX(-valueIncreseSpeed);
                break;

            case 12:
                player.IncSpeedX(-valueIncreseSpeed);
                break;

            case 13:
                player.IncSpeedY(-valueIncreseSpeed);
                player.IncSpeedX(-valueIncreseSpeed);
                break;

            case 14:
                player.IncSpeedY(-valueIncreseSpeed);
                player.IncSpeedX(-valueIncreseSpeed);
                break;

            case 15:
                player.IncSpeedY(-valueIncreseSpeed);
                player.IncSpeedX(-valueIncreseSpeed);
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

        if (ySpeed > maxSpeed)
        {
            ySpeed = maxSpeed;
        }
        if (ySpeed < -maxSpeed)
        {
            ySpeed = -maxSpeed;
        }
    }

    public void IncSpeedX(int speed)
    {
        this.xSpeed += speed;

        if (xSpeed > maxSpeed)
        {
            xSpeed = maxSpeed;
        }
        if (xSpeed < -maxSpeed)
        {
            xSpeed = -maxSpeed;
        }
    }
    override public void Move()
    {
        MoveX();
        MoveY();
    }

    public void MoveX()
    {
        x += xSpeed;
    }

    public void MoveY()
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

