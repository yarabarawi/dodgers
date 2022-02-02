using System;
using Raylib_cs;

namespace dodgers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisering
            //--------------------------------------------------------------------------------------
            const int fönsterB = 800;
            const int fönsterH = 600;

            Raylib.InitWindow(fönsterB, fönsterH, "Snöflingor");
            Raylib.SetTargetFPS(60);

            // TODO: Infoga variabler och objekt här
            // gamestate variabler
            int poäng = 0;
            float tid = 0;
            int liv = 3;
            Random generator = new Random();
            Rectangle mynt1 = new Rectangle(400, 0, 50, 50);
            Rectangle mynt2 = new Rectangle(300, 0, 30, 30);
            Rectangle moster = new Rectangle(300, 0, 30, 30);
            Rectangle spelare = new Rectangle(100, fönsterH - 50, 100, 10);
            //--------------------------------------------------------------------------------------

            // Animationsloopen
            while (!Raylib.WindowShouldClose())
            {
                // Updatering
                //----------------------------------------------------------------------------------
                mynt1.y += 1;
                if (mynt1.y > fönsterH)
                {
                    mynt1.y = -100;
                    mynt1.x = generator.Next(0, fönsterB);
                }
                mynt2.y += 3;
                if (mynt2.y > fönsterH)
                {
                    mynt2.y = -300;
                    mynt2.x = generator.Next(0, fönsterB);
                }
                 moster.y += 3;
                if (moster.y > fönsterH)
                {
                    moster.y = -300;
                    moster.x = generator.Next(0, fönsterB);
                }

                //lyssna på tangenter
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    if (spelare.x > 3)
                    {
                        spelare.x -= 3;
                    }

                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    if (spelare.x < fönsterB - 100)
                    {
                        spelare.x += 3;
                    }

                }
                //om spelaren träffar ett mynt1

                if (Raylib.CheckCollisionRecs(spelare, mynt1))
                {
                    mynt1.y = 0;
                    mynt1.x = generator.Next(0, fönsterB);
                    poäng += 5;
                }
                if (Raylib.CheckCollisionRecs(spelare, mynt2))
                {
                    mynt2.y = 0;
                    mynt2.x = generator.Next(0, fönsterB);
                    poäng += 10;
                }
                if (Raylib.CheckCollisionRecs(spelare, moster))
                {
                    moster.y = 0;
                    moster.x = generator.Next(0, fönsterB);
                    liv--;
                }

                //----------------------------------------------------------------------------------

                // Rita
                //----------------------------------------------------------------------------------
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKBLUE);

                Raylib.DrawRectangleRec(mynt1, Color.GOLD);
                Raylib.DrawRectangleRec(mynt2, Color.YELLOW);
                Raylib.DrawRectangleRec(moster, Color.BROWN);
                Raylib.DrawRectangleRec(spelare, Color.RED);
                Raylib.DrawText($"poäng:{poäng} Liv{liv}", 10, 10, 20, Color.LIME);


                Raylib.EndDrawing();
                //----------------------------------------------------------------------------------
            }
        }
    }
}