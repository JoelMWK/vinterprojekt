using System;
using System.Collections.Generic;
using Raylib_cs;


int speed = 3;
int speedJ = 16;
float speedF = 6.4f;
float v = 5f;
int bulletS = 4;

Raylib.InitWindow(800, 800, "Vinterprojekt");
Raylib.SetTargetFPS(60);

Rectangle playerRect = new Rectangle(50, 661, 100, 119);
Rectangle floor = new Rectangle(0, 780, 800, 20);

bool collision = Raylib.CheckCollisionRecs(playerRect, floor);
Rectangle overlap = Raylib.GetCollisionRec(playerRect, floor);
Texture2D playerImage = Raylib.LoadTexture("yes.png");



while (!Raylib.WindowShouldClose())
{

    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) playerRect.y -= speedJ;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) playerRect.y += speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) playerRect.x += speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) playerRect.x -= speed;


    Console.WriteLine(playerRect.y);


    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.SKYBLUE);

    Raylib.DrawRectangleRec(floor, Color.WHITE);
    Raylib.DrawRectangleRec(playerRect, Color.WHITE);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    Raylib.DrawRectangleRec(overlap, Color.ORANGE);






    Raylib.EndDrawing();

}