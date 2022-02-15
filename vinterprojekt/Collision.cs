using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Collision
{
    public static Rectangle PlayerCollision(Rectangle playerRect)
    {
        int sw = Raylib.GetScreenWidth();
        int sh = Raylib.GetScreenHeight();

        if ((playerRect.x + playerRect.width) >= sw)
        {
            playerRect.x = sw - playerRect.width;
        }
        else if (playerRect.x <= 0)
        {
            playerRect.x = 0;
        }

        if ((playerRect.y + playerRect.height) >= sh)
        {
            playerRect.y = sh - playerRect.height;
        }
        else if (playerRect.y <= 0)
        {
            playerRect.y = 0;
        }
        return playerRect;
    }

}
