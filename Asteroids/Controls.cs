class Controls
{
    public void Run()
    {
        Image arrowP1 = new Image("data/1player.png");
        Image arrowP2 = new Image("data/2player.png");
        Font font24 = new Font("data/Joystix.ttf", 24);
        Font font18 = new Font("data/Joystix.ttf", 18);
        Font font10 = new Font("data/Joystix.ttf", 12);

        SdlHardware.ClearScreen();
        //SdlHardware.DrawHiddenImage(arrowP1, -100, -90);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["controls"]+"",
            390, 80,
            0xCC, 0xCC, 0xCC,
            font24);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["player1"] + "",
            20, 140,
            0xCC, 0xCC, 0xCC,
            font18);
        SdlHardware.WriteHiddenText("1. "+ 
                ChooseLanguage.lenguage["moveP1"],
            50, 180,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText("2. " +
                ChooseLanguage.lenguage["control2"] + " 'i'",
            50, 200,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText("3. " +
                ChooseLanguage.lenguage["control3"] + " 'o'",
            50, 220,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText("3. " +
                ChooseLanguage.lenguage["control4"]+ " 'p'",
            50, 240,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText("R " + ChooseLanguage.lenguage["toReturn"],
            20, 20,
            0xBB, 0xBB, 0xBB,
            font24);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["player2"] + "",
            20, 300,
            0xCC, 0xCC, 0xCC,
            font18);
        SdlHardware.WriteHiddenText("1. " +
                ChooseLanguage.lenguage["moveP2"],
            50, 340,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText("2. " +
                ChooseLanguage.lenguage["control2"] + " 'b'",
            50, 360,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText("3. " +
                ChooseLanguage.lenguage["control3"] + " 'n'",
            50, 380,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText("3. " +
                ChooseLanguage.lenguage["control4"] + " 'M'",
            50, 400,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText("4. " +
                ChooseLanguage.lenguage["chooseP2"] +"",
            50, 420,
            0xCC, 0xCC, 0xCC,
            font10);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["details"] + "",
           390, 450,
           0xCC, 0xCC, 0xCC,
           font24);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["development1"]+"",
           50, 500,
           0xCC, 0xCC, 0xCC,
           font10);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["development2"]+"",
           50, 540,
           0xCC, 0xCC, 0xCC,
           font10);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["development3"] +"",
           50, 580,
           0xCC, 0xCC, 0xCC,
           font10);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["development4"] + "",
           50, 620,
           0xCC, 0xCC, 0xCC,
           font10);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["development5"] + "",
          50, 640,
          0xCC, 0xCC, 0xCC,
          font10);
        SdlHardware.DrawHiddenImage(arrowP1, 560, 535);
        SdlHardware.DrawHiddenImage(arrowP2, 560, 580);
        SdlHardware.ShowHiddenScreen();

        do
        {
            SdlHardware.Pause(100); // To avoid using 100% CPU
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_R));
    }
}
