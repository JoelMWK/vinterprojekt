using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Levels
{

    static public int[,] level = new int[12, 12]{
            {0,1,0,1,0,0,0,0,0,1,0,1},
            {0,0,0,0,0,1,1,1,0,0,0,1},
            {1,0,1,1,1,1,1,1,0,1,1,1},
            {0,0,0,0,0,1,0,1,0,0,1,0},
            {0,1,1,1,0,1,0,0,0,0,0,0},
            {0,0,0,0,1,1,1,1,0,1,1,1},
            {1,1,1,0,1,0,0,0,0,1,0,0},
            {0,1,1,0,1,1,0,1,0,1,0,0},
            {0,0,0,0,0,1,0,1,0,1,1,1},
            {1,0,0,1,1,1,0,1,0,0,0,0},
            {0,0,0,0,0,1,0,1,1,1,1,0},
            {0,1,1,0,0,1,0,0,0,0,1,2},
        };


    public static List<Rectangle> LevelDesign(List<Rectangle> door, List<Rectangle> key)
    {

        List<Rectangle> map = new List<Rectangle>();

        int size = 84;
        int sizeCoin = 30;

        Random generator = new Random();
        int random = generator.Next(3, 6);

        if (level[0, 0] == 0)
        {
            if (random == 3)
            {
                level[0, 0] = 3;
            }
        }
        if (level[11, 9] == 0)
        {
            if (random == 4)
            {
                level[11, 9] = 3;
            }
        }
        if (level[6, 5] == 0)
        {
            if (random == 5)
            {
                level[6, 5] = 3;
            }
        }


        for (int y = 0; y < level.GetLength(1); y++)
        {
            for (int x = 0; x < level.GetLength(0); x++)
            {
                if (level[y, x] == 1)
                {
                    map.Add(new Rectangle(x * size, y * size, size, size));
                }
                else if (level[y, x] == 2)
                {
                    door.Add(new Rectangle(x * size, y * size, size, size));
                }
                else if (level[y, x] == 3)
                {
                    key.Add(new Rectangle(x * size + 25, y * size + 25, sizeCoin, sizeCoin));
                }
            }

        }

        return map;
    }

    public static int[,] checkKey(bool keyTaken, int[,] level)
    {
        if (keyTaken == true)
        {
            Raylib.DrawText("Door key: 1", Raylib.GetScreenWidth() - 120, 20, 20, Color.WHITE);
            level[8, 11] = 0;
        }
        return level;
    }
}