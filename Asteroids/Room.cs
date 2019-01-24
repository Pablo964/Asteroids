class Room
{
    protected Image stars1, stars2;

    protected int mapHeight = 11, mapWidth = 16;
    protected int tileWidth = 59, tileHeight = 58;
    protected int leftMargin = 100, topMargin = 50;

    protected string[] levelData =
    {
        "                ",
        "                ",
        "   1     2      ",
        "                ",
        "       1         ",
        "             2   ",
        "                ",
        "          2     ",
        "    2           ",
        "         2      ",
        "AABAAAABBABAAABAA"};

    public Room()
    {
        stars1 = new Image("data/estrellas3.jpg");
        stars2 = new Image("data/estrellas4.jpg");
        
    }

    public void DrawOnHiddenScreen()
    {
        for (int row = 0; row < mapHeight; row++)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                int posX = col * tileWidth + leftMargin;
                int posY = row * tileHeight + topMargin;
                switch (levelData[row][col])
                {
                    case '1': SdlHardware.DrawHiddenImage(stars1, posX, posY); break;
                    case '2': SdlHardware.DrawHiddenImage(stars2, posX, posY); break;

                }
            }
        }
    }
}
