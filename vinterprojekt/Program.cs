using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

static void main()
{

    float speed = 4.3f;

    Vector2 playerMovement = new Vector2();


    Raylib.InitWindow(1000, 1000, "Vinterprojekt");
    Raylib.SetTargetFPS(60);

    Rectangle playerRect = new Rectangle(50, 661, 88, 100);
    Rectangle box = new Rectangle(500, 400, 80, 80);

    bool collision = false;
    Rectangle overlap = Raylib.GetCollisionRec(playerRect, box);
    Texture2D playerImage = Raylib.LoadTexture("yes.png");






    while (!Raylib.WindowShouldClose())
    {
        playerMovement = PlayerMovement(speed);
        playerRect.y += playerMovement.Y;
        playerRect.x += playerMovement.X;

        if (Raylib.CheckCollisionRecs(playerRect, box))
        {
            playerRect.y -= playerMovement.Y;
        }

        if (Raylib.CheckCollisionRecs(playerRect, box))
        {
            playerRect.x -= playerMovement.X;
        }

        PlayerCollision(playerRect, collision, box, overlap);
        PlayerShooting();
        LevelDesign();

        Console.WriteLine("y = " + playerRect.y);
        Console.WriteLine("x = " + playerRect.x);

        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.SKYBLUE);

        //Raylib.DrawRectangleRec(playerRect, Color.WHITE);
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        Raylib.DrawRectangleRec(box, Color.WHITE);
        Raylib.DrawRectangleRec(overlap, Color.ORANGE);

        Raylib.EndDrawing();

    }
}

static void PlayerCollision(Rectangle playerRect, bool collision, Rectangle box, Rectangle overlap)
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


static void PlayerShooting()
{

    Rectangle bullet = new Rectangle(20, 20, 15, 45);
    Texture2D bulletImage = Raylib.LoadTexture("bullet.png");

    if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
    {
        //Raylib.DrawRectangleRec(bullet, Color.WHITE);
        Raylib.DrawTexture(bulletImage, (int)bullet.x, (int)bullet.y, Color.WHITE);
    }

}

static void LevelDesign()
{

    int[,] level = {
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1},
        {1,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };

    for (int y = 0; y < level.GetLength(1); y++)
    {
        for (int x = 0; x < level.GetLength(0); x++)
        {
            level[x, y] = 0;
        }

    }

}

static Vector2 PlayerMovement(float speed)
{
    Vector2 movement = Vector2.Zero;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = +speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X += speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X -= speed;

    return movement;
}


main();