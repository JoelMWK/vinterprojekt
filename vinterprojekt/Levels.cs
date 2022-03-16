using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Levels
{
    //Multidimensional array som definerar hur mappen ska se ut 
    //Den delar upp x och y i 12 olika columner och rows
    //En ruta får då 83,33 i height och width (1000/12) => 1000 = screen width och screen height 
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
            {0,1,1,0,0,1,0,0,0,0,1,0},
        };
    public static List<Rectangle> LevelDesign(List<Rectangle> door, List<Rectangle> key, bool rnd = true)
    {
        //Ny lista för mappen
        List<Rectangle> map = new List<Rectangle>();

        //Storleks variablar för leveln
        int size = 84;
        int sizeCoin = 30;

        if (rnd)
        {
            //Random generator som slumpar mellan 3, 4 eller 5
            //Sedan checkar if statments nedan om värdet instämmer så kommer 
            //den positionen få värdet 3 (en nyckel)
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
        }

        //For loop som läser in värdet på y som och getLength(1) returnerar nummer i den första dimensionen (y-led)
        //Samma sak för x
        for (int y = 0; y < level.GetLength(1); y++)
        {
            for (int x = 0; x < level.GetLength(0); x++)
            {
                //Definerar vad de olika värderna ska vara
                //1 skapar en ny map (box)
                if (level[y, x] == 1)
                {
                    map.Add(new Rectangle(x * size, y * size, size, size));
                }
                //2 skaper en ny dörr
                else if (level[y, x] == 2)
                {
                    door.Add(new Rectangle(x * size, y * size, size, size));
                }
                //3 skapar en ny nyckel 
                else if (level[y, x] == 3)
                {
                    key.Add(new Rectangle(x * size + 25, y * size + 25, sizeCoin, sizeCoin));
                }
            }
        }
        //Returnerar mappen
        return map;
    }

    public static int[,] checkKey(bool keyTaken, int[,] level)
    {
        //Tar in level arrayen och bool keytaken som säger vad som ska hända när man tar upp nyckeln
        //När man tar upp nyckeln så kommer en text upp samt en position på mappen kommer ta bort en vägg (level[8,11] = 0)
        //Samt lägga till en dörr som man ska kunna gå igenom
        if (keyTaken == true)
        {
            Raylib.DrawText("Door key: 1", Raylib.GetScreenWidth() - 120, 20, 20, Color.WHITE);
            level[8, 11] = 0;
            level[6, 11] = 2;
        }
        //Returnerar level arrayn
        return level;
    }
}