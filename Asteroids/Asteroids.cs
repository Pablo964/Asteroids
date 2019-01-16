class Asteroids
{
    static void Main()
    {
        bool fullScreen = false;
        SdlHardware.Init(1024, 768, 24, fullScreen);

        WelcomeScreen w = new WelcomeScreen();
        w.Run();

        Game g = new Game();
        g.Run();
    }
}
