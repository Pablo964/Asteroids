using System.Collections;

class WelcomeScreen
{
    protected Image welcome;
    protected int option;
    protected Font font24;
    protected static bool activeTricks;

    public WelcomeScreen()
    {
        welcome = new Image("data/welcome.png");
        option = 0;
        font24 = new Font("data/Joystix.ttf", 24);
        activeTricks = false;
    }

    public int GetChosenOption()
    {
        return option;
    }

    public void DrawWelcomeScreen(bool tricks)
    {
        option = 0;
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(welcome, 0, 0);

        if (tricks)
        {
            SdlHardware.WriteHiddenText("0. " + 
                    ChooseLanguage.lenguage["tricks"],
            400, 440,
            0x80, 0x80, 0x80,
            font24);
        }
        //Menu:
        SdlHardware.WriteHiddenText("1. " + ChooseLanguage.lenguage["play"],
            400, 470,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("2. " +
                ChooseLanguage.lenguage["controlsAndMore"],
            400, 500,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("3. " + ChooseLanguage.lenguage["credits"],
            400, 530,
            0xA0, 0xA0, 0xA0,
            font24);

        SdlHardware.WriteHiddenText("Q. " + ChooseLanguage.lenguage["quit"],
            400, 560,
            0x80, 0x80, 0x80,
            font24);

        SdlHardware.ShowHiddenScreen();
    }

    public void Run()
    {
        DrawWelcomeScreen(false);
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
            if (SdlHardware.KeyPressed(SdlHardware.KEY_3))
            {
                option = 3;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_Q))
            {
                option = 4;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_0) && activeTricks)
            {
                option = 5;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_Z))
            {
                activeTricks = true;
                DrawWelcomeScreen(true);
            }


            SdlHardware.Pause(100); // To avoid using 100% CPU
        }
        while (option == 0);
    }
}

