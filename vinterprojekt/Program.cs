using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

//Variablar för spelet
float speed = 4.3f;
bool alive = false;
bool keyTaken = false;
string room = "start";
int hp = 100;

Raylib.InitWindow(1000, 1000, "Vinterprojekt");
Raylib.SetTargetFPS(60);

//Gör en vector för playermovement
Vector2 playerMovement = new Vector2();
//Skapar en rectangle som ska vara för gubben
Rectangle playerRect = new Rectangle(0, 1000 - 60, 53, 60);

//Skapar textur variablar
Texture2D playerImage = Raylib.LoadTexture("yes.png");
Texture2D start = Raylib.LoadTexture("start.png");
Texture2D keyTexture = Raylib.LoadTexture("key.png");
Texture2D doorTexture = Raylib.LoadTexture("door.png");
Texture2D wallTexture = Raylib.LoadTexture("wall.png");

//Skapar listor för objekt i spelet
List<Rectangle> door = new List<Rectangle>();
List<Rectangle> key = new List<Rectangle>();
List<Rectangle> map = Levels.LevelDesign(door, key); 


while (!Raylib.WindowShouldClose())
{
    //StartScreen
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
    //Spelet
    else
    {

        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.SKYBLUE);

        //Ritar ut texturen playerImage med positionen av playerRect.x och playerRect.y som checkas i metoden "PlayerMovement"
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

        Raylib.EndDrawing();

        //If statement på vad som ska hända i dem två rummen (man ska ha samma movement samt collision)
        if (room == "start" || room == "hallway")
        {
            playerRect = Collision.PlayerCollision(playerRect);
            playerMovement = PlayerMovement(speed);
    
            playerRect.y += playerMovement.Y;
            playerRect.x += playerMovement.X;

        }

        //IF statement vad som ska häna i room "start"
        if (room == "start")
        {
            //Foreach loop som jag använder genom att ta in en lista som innehåller en position samt storlek som finns i metoden "Levels"
            //Jag tar in key listan där jag sätter en textur på den med texture2D och bestämmer positionen på den
            //genom att använda keyRect.x och y
            foreach (Rectangle keyRect in key)
            {
                if (Raylib.CheckCollisionRecs(playerRect, keyRect) && keyTaken == false) keyTaken = true;
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
            //Det är samma sak för denna foreach loop med jag tar in mapen alltså där hindren ska vara
            //Checkar colliisonen mellan playerRect och boxen genom checkcollisionrecs och sedan tar man -hp om man går in i väggen
            foreach (Rectangle box in map)
            {
                Raylib.DrawTexture(wallTexture, (int)box.x, (int)box.y, Color.WHITE);
                if (Raylib.CheckCollisionRecs(playerRect, box)) { playerRect.y -= playerMovement.Y; hp -= 2; }
                if (Raylib.CheckCollisionRecs(playerRect, box)) { playerRect.x -= playerMovement.X; hp -= 2; }
            }
            Raylib.DrawText("Health: " + hp, 40, 20, 30, Color.WHITE);
        }
        else if (room == "hallway")
        {
            Raylib.DrawText("To be continued!", 260, 400, 70, Color.WHITE);
            Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

            playerRect.y = 400;
            playerRect.x = 200;
        }

        Levels.checkKey(keyTaken, Levels.level);
        map = Levels.LevelDesign(door, key, false);

        if (hp <= 0)
        {
            room = "death";
            if (room == "death")
            {
                Raylib.DrawText("YOU DIED!", 300, 400, 50, Color.RED);
            }
        }
    }
}

//Playermovement metod
static Vector2 PlayerMovement(float speed)
{
    //Skapar en vector för playermovement som jag kallar movement
    Vector2 movement = new Vector2();
    //När man trycker på W,A,S eller D så kommer karaktären att flyttas med speed (4.3 per frame)
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = +speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X += speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X -= speed;

    //Returnerar movement
    return movement;
}