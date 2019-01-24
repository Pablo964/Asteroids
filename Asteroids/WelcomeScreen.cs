class WelcomeScreen
{
    protected int option;

    public WelcomeScreen()
    {
        option = 0;
    }

    public int GetChosenOption()
    {
        return option;
    }


    public void Run()
    {

        Image welcome = new Image("data/welcome.png");
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(welcome, 0, 0);
        SdlHardware.ShowHiddenScreen();
        do
        {
            if (SdlHardware.KeyPressed(SdlHardware.KEY_1))
            {
                option = 1;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_2))
            {
                option = 2;
            }
            SdlHardware.Pause(100); // To avoid using 100% CPU
        }
        while (option == 0);
    }
}

