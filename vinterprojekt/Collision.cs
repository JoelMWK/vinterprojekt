using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Collision
{
    public static void PlayerCollision(Rectangle playerRect, bool collision, Rectangle box, Rectangle overlap)
    {


        if ((playerRect.x + playerRect.width) >= Raylib.GetScreenWidth())
        {
            playerRect.x = Raylib.GetScreenWidth() - playerRect.width;
        }
        else if (playerRect.x <= 0)
        {
            playerRect.x = 0;
        }

        if ((playerRect.y + playerRect.height) >= Raylib.GetScreenHeight())
        {
            playerRect.y = Raylib.GetScreenHeight() - playerRect.height;
        }
        else if (playerRect.y <= 0)
        {
            playerRect.y = 0;
        }


        collision = Raylib.CheckCollisionRecs(playerRect, box);

        if (collision)
        {
            overlap = Raylib.GetCollisionRec(playerRect, box);
        }
    }

}
