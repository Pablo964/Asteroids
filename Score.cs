﻿using System;

class Score
{
    static protected Font font24;
    static int exit;
    public Score()
    {
        font24 = new Font("data/Joystix.ttf", 24);
        exit = 1;
    }

    public int GetExit()
    {
        return exit;
    }

    public static void Run(int score, int maxScore)
    {
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["score"] +
                " " + score,
            400, 350,
            0xC0, 0xC0, 0xC0,
            font24);

        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["maxScore"] +
                " " + maxScore,
            400, 300,
            0xC0, 0xC0, 0xC0,
            font24);

        SdlHardware.WriteHiddenText("Q. " + ChooseLanguage.lenguage["quit"],
            400, 530,
            0x80, 0x80, 0x80,
            font24);

        SdlHardware.ShowHiddenScreen();

        do
        {
            if (SdlHardware.KeyPressed(SdlHardware.KEY_Q))
            {
                exit = 0;
            }
            SdlHardware.Pause(100);
        }
        while (exit != 0);
    }
}

