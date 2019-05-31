//In welcome menu press "Z" to see the tricks option
class Tricks
{
    protected int option;
    protected Font font24;
    protected Image pointer;
    protected Image shot;
    public static bool immortal;
    public static bool morePoints;

    public Tricks()
    {
        pointer = new Image("data/nave_izq.png");
        shot = new Image("data/disparo.png");
        option = 1;
        font24 = new Font("data/Joystix.ttf", 24);
        immortal = false;
        morePoints = false;
    }

    public int GetChosenOption()
    {
        return option;
    }

    public void Run()
    {
        do
        {
            SdlHardware.ClearScreen();
            if (option < 2)
            {
                if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN))
                {
                    option++;
                    SdlHardware.Pause(200);
                    System.Console.WriteLine(option);
                }
            }
            if (option > 1)
            {
                if (SdlHardware.KeyPressed(SdlHardware.KEY_UP))
                {
                    option--;
                    SdlHardware.Pause(200);
                    System.Console.WriteLine(option);
                }
            }
           
            if (option == 1)
            {
                SdlHardware.WriteHiddenText("" + 
                    ChooseLanguage.lenguage["immortal"],
                300, 200, 0xC0, 0xC0, 0xC0, font24);

                if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT) || immortal)
                {

                    SdlHardware.WriteHiddenText("" + 
                        ChooseLanguage.lenguage["yes"],
                    560, 200,
                    0xC0, 0xC0, 0xC0,
                    font24);
                    immortal = true;
                }
                if (SdlHardware.KeyPressed(
                        SdlHardware.KEY_RIGHT) || !immortal)
                {
                    SdlHardware.WriteHiddenText("" +
                        ChooseLanguage.lenguage["no"],
                    560, 200,
                    0xC0, 0xC0, 0xC0,
                    font24);
                    immortal=false;
                }
            }
            else
            {
                SdlHardware.WriteHiddenText("" +
                   ChooseLanguage.lenguage["immortal"],
               300, 200, 0x80, 0x80, 0x80, font24);
            }

            if (option == 2)
            {
                SdlHardware.WriteHiddenText("" +
                    ChooseLanguage.lenguage["morePoints"],
                300, 300, 0xC0, 0xC0, 0xC0, font24);

                if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT) || morePoints)
                {

                    SdlHardware.WriteHiddenText("" +
                        ChooseLanguage.lenguage["yes"],
                    560, 300,
                    0xC0, 0xC0, 0xC0,
                    font24);
                    morePoints = true;
                }
                if (SdlHardware.KeyPressed(
                        SdlHardware.KEY_RIGHT) || !morePoints)
                {
                    SdlHardware.WriteHiddenText("" +
                        ChooseLanguage.lenguage["no"],
                    560, 300,
                    0xC0, 0xC0, 0xC0,
                    font24);
                    morePoints = false;
                }
            }
            else
            {
                SdlHardware.WriteHiddenText("" +
                   ChooseLanguage.lenguage["morePoints"],
               300, 300, 0x80, 0x80, 0x80, font24);
            }
            /*
            if (option == 3)
            {
                SdlHardware.WriteHiddenText("" +
                    ChooseLanguage.lenguage["bossEvery"],
                300, 400, 0xC0, 0xC0, 0xC0, font24);

                if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT) 
                    && Room.quantityLevelToBoss > 1)
                {
                    Room.quantityLevelToBoss--;
                    SdlHardware.WriteHiddenText("" + Room.quantityLevelToBoss,
                    560, 400,
                    0xC0, 0xC0, 0xC0,
                    font24);
                }
                if (SdlHardware.KeyPressed(
                        SdlHardware.KEY_RIGHT)
                        && Room.quantityLevelToBoss < 99)
                {
                    Room.quantityLevelToBoss++;
                    SdlHardware.WriteHiddenText("" + Room.quantityLevelToBoss,
                    560, 400,
                    0xC0, 0xC0, 0xC0,
                    font24);
                }
            }
            else
            {
                SdlHardware.WriteHiddenText("" +
                   ChooseLanguage.lenguage["bossEvery"],
               300, 400, 0x80, 0x80, 0x80, font24);
            }
            */
            SdlHardware.WriteHiddenText(""+ 
                ChooseLanguage.lenguage["instructionsTricks1"],
                20, 600,
                0xC0, 0xC0, 0xC0,
                font24);
            SdlHardware.WriteHiddenText("" +
                ChooseLanguage.lenguage["instructionsTricks2"],
               20, 650,
              0xC0, 0xC0, 0xC0,
               font24);

            SdlHardware.WriteHiddenText("R " +
               ChooseLanguage.lenguage["toReturn"],
              50, 20,
             0xC0, 0xC0, 0xC0,
              font24);


            SdlHardware.ShowHiddenScreen();
        } while (!SdlHardware.KeyPressed(SdlHardware.KEY_R));
    }
}
