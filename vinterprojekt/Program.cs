using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;


float speed = 4.3f;
bool alive = false;
bool keyTaken = false;
int points = 0;
string room = "start";


Raylib.InitWindow(1000, 1000, "Vinterprojekt");
Raylib.SetTargetFPS(60);

Vector2 playerMovement = new Vector2();
Rectangle playerRect = new Rectangle(0, 1000 - 60, 53, 60);

Texture2D playerImage = Raylib.LoadTexture("yes.png");
Texture2D start = Raylib.LoadTexture("start.png");
Texture2D keyTexture = Raylib.LoadTexture("key.png");
Texture2D doorTexture = Raylib.LoadTexture("door.png");
Texture2D wallTexture = Raylib.LoadTexture("wall.png");

List<Rectangle> door = new List<Rectangle>();
List<Rectangle> key = new List<Rectangle>();
List<Rectangle> map = Levels.LevelDesign(door, key);



while (!Raylib.WindowShouldClose())
{
    if (!alive)
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawTexture(start, 0, 0, Color.WHITE);

        Raylib.DrawText("Vinterprojekt", 280, 300, 60, Color.ORANGE);
        Raylib.DrawText("START", 430, 500, 30, Color.WHITE);

        Raylib.EndDrawing();

        if (Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
        {
            int mX = Raylib.GetMouseX();
            int mY = Raylib.GetMouseY();
            if (mX >= 420 & mX <= 545 & mY >= 498 & mY <= 528) alive = true;
        }
    }
    else
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.SKYBLUE);

        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

        Raylib.EndDrawing();

        if (room == "start" || room == "hallway")
        {
            CountDown.timer();
            playerRect = Collision.PlayerCollision(playerRect);
            playerMovement = PlayerMovement(speed);

            playerRect.y += playerMovement.Y;
            playerRect.x += playerMovement.X;
        }

        if (room == "start")
        {
            foreach (Rectangle keyRect in key)
            {
                if (Raylib.CheckCollisionRecs(playerRect, keyRect) && keyTaken == false) { points++; keyTaken = true; }
                if (!keyTaken)
                {
                    Raylib.DrawTexture(keyTexture, (int)keyRect.x, (int)keyRect.y, Color.WHITE);
                }
            }
            foreach (Rectangle doorRect in door)
            {
                Raylib.DrawTexture(doorTexture, (int)doorRect.x, (int)doorRect.y, Color.WHITE);
                if (Raylib.CheckCollisionRecs(playerRect, doorRect)) room = "hallway";

            }
            foreach (Rectangle box in map)
            {
                Raylib.DrawTexture(wallTexture, (int)box.x, (int)box.y, Color.WHITE);
                if (Raylib.CheckCollisionRecs(playerRect, box)) playerRect.y -= playerMovement.Y;
                if (Raylib.CheckCollisionRecs(playerRect, box)) playerRect.x -= playerMovement.X;
            }
        }
        else if (room == "hallway")
        {
            Raylib.ClearBackground(Color.BEIGE);
            Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        }

        Levels.checkKey(keyTaken, Levels.level);
    }
}

static Vector2 PlayerMovement(float speed)
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = +speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X += speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X -= speed;

    return movement;
}