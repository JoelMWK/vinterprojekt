using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Levels
{
    public static List<Rectangle> LevelDesign()
    {
        List<Rectangle> map = new List<Rectangle>();
        int[,] level = new int[10, 10]{
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,1,1,1,1,1,1,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1},
        };

        int size = 80;

        for (int y = 0; y < level.GetLength(1); y++)
        {
            for (int x = 0; x < level.GetLength(0); x++)
            {
                if (level[y, x] == 0)
                {

                }
                else if (level[y, x] == 1)
                {
                    map.Add(new Rectangle(x * size, y * size, size, size));
                }

            }

        }
        return map;
    }
}
