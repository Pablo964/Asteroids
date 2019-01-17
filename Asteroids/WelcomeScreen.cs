class WelcomeScreen
{
    public void Run()
    {
        Image welcome = new Image("data/welcome.png");
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(welcome, 0, 0);
        SdlHardware.ShowHiddenScreen();
        SdlHardware.Pause(2000);
    }
}

