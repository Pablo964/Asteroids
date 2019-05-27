class Asteroids
{
    static void Main()
    {
        bool fullScreen = false;
        SdlHardware.Init(1024, 700, 24, fullScreen);

        WelcomeScreen w = new WelcomeScreen();
        ChooseLanguage l = new ChooseLanguage();

        do
        {
            if (l.GetChosenOption() == 0)
            {
                l.Run();
            }
            if (l.GetChosenOption() != 0)
            {
                w.Run();
                if (w.GetChosenOption() == 1)
                {
                    Game g = new Game();
                    g.Run();
                }
                else if (w.GetChosenOption() == 2)
                {
                    Controls controls = new Controls();
                    controls.Run();
                }
                else if (w.GetChosenOption() == 3)
                {
                    CreditsScreen credits = new CreditsScreen();
                    credits.Run();
                }
            }

        }
        while (w.GetChosenOption() != 4);

    }
}
