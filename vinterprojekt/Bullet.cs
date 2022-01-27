using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Bullet
{
    public static void PlayerShooting()
    {

        Rectangle bullet = new Rectangle(20, 20, 15, 45);
        Texture2D bulletImage = Raylib.LoadTexture("bullet.png");

        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
        {
            //Raylib.DrawRectangleRec(bullet, Color.WHITE);
            Raylib.DrawTexture(bulletImage, (int)bullet.x, (int)bullet.y, Color.WHITE);
        }
    }

}