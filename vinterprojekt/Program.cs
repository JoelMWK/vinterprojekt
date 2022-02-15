﻿using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;


float speed = 4.3f;
bool alive = false;
bool taken = false;
int points = 0;
string room = "start";


Raylib.InitWindow(1000, 1000, "Vinterprojekt");
Raylib.SetTargetFPS(60);

Vector2 playerMovement = new Vector2();
Rectangle playerRect = new Rectangle(0, 1000 - 68, 60, 68);

Texture2D playerImage = Raylib.LoadTexture("yes.png");
Texture2D start = Raylib.LoadTexture("start.png");
Texture2D coinTexture = Raylib.LoadTexture("coin.png");
Texture2D doorTexture = Raylib.LoadTexture("door.png");
Texture2D wallTexture = Raylib.LoadTexture("wall.png");

List<Rectangle> door = new List<Rectangle>();
List<Rectangle> point = new List<Rectangle>();
List<Rectangle> map = Levels.LevelDesign(points, door, point);



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
        Raylib.DrawText("Points: " + points, 900, 30, 20, Color.BLACK);

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
            foreach (Rectangle pointRect in point)
            {
                Raylib.DrawTexture(coinTexture, (int)pointRect.x, (int)pointRect.y, Color.WHITE);
                if (Raylib.CheckCollisionRecs(playerRect, pointRect) && taken == false) { points++; taken = true;}
                if (taken == true)
                {
                    point.RemoveAt(1);
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