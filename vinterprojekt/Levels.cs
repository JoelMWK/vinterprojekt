using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Levels
{
    public static List<Rectangle> LevelDesign(int points, List<Rectangle> door, List<Rectangle> point)
    {

        List<Rectangle> map = new List<Rectangle>();

        int[,] level = new int[12, 12]{
            {3,1,0,1,0,0,0,0,0,1,0,1},
            {0,0,0,0,0,1,1,1,0,0,0,1},
            {1,0,1,1,1,1,1,1,0,1,1,1},
            {0,0,0,0,0,1,0,1,0,0,1,0},
            {0,1,1,1,0,1,0,0,0,0,0,0},
            {0,0,0,0,1,1,1,1,0,1,1,1},
            {1,1,1,0,1,3,0,0,0,1,0,0},
            {0,1,1,0,1,1,0,1,0,1,0,0},
            {0,0,0,0,0,1,0,1,0,1,1,1},
            {1,0,0,1,1,1,0,1,0,0,0,0},
            {0,0,0,0,0,1,0,1,1,1,1,0},
            {0,1,1,0,0,1,0,0,3,0,1,2},
        };


        int size = 84;
        int sizeCoin = 30;

        if (points == 3)
        {
            level[8, 11] = 0;
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
                    point.Add(new Rectangle(x * size + 25, y * size + 25, sizeCoin, sizeCoin));
                }
            }

        }

        return map;

    }

}