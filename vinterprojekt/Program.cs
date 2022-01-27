using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;


float speed = 4.3f;
bool alive = false;

Vector2 playerMovement = new Vector2();

//Vector2 textPos = new Vector2(380, 320);
//Font cartoon = Raylib.LoadFont("MOOCHIO.ttf");


Raylib.InitWindow(1000, 1000, "Vinterprojekt");
Raylib.SetTargetFPS(60);

Rectangle playerRect = new Rectangle(50, 661, 88, 100);
Rectangle box = new Rectangle(500, 400, 80, 80);

bool collision = false;
Rectangle overlap = Raylib.GetCollisionRec(playerRect, box);
Texture2D playerImage = Raylib.LoadTexture("yes.png");
Texture2D start = Raylib.LoadTexture("start.png");



while (!Raylib.WindowShouldClose())
{
    if (alive == false)
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(start, 0, 0, Color.WHITE);

        //Raylib.DrawTextEx(cartoon, "Winterproject", textPos, 60, 0, Color.ORANGE);
        Raylib.DrawText("Vinterprojekt", 280, 300, 60, Color.ORANGE);


        //Raylib.DrawRectangle(420, 498, 125, 30, Color.BEIGE);
        Raylib.DrawText("START", 430, 500, 30, Color.WHITE);

        if (Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.GetMouseX() >= 420 & Raylib.GetMouseX() <= 545 & Raylib.GetMouseY() >= 498 & Raylib.GetMouseY() <= 528) alive = true;
        }


        Raylib.EndDrawing();
    }
    else
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

        Collision.PlayerCollision(playerRect, collision, box, overlap);
        Bullet.PlayerShooting();
        Levels.LevelDesign();

        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.SKYBLUE);

        //Raylib.DrawRectangleRec(playerRect, Color.WHITE);
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        Raylib.DrawRectangleRec(box, Color.WHITE);
        Raylib.DrawRectangleRec(overlap, Color.ORANGE);

        Raylib.EndDrawing();
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

