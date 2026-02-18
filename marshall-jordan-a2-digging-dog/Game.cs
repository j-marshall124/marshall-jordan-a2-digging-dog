// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        
        // Window Arrays
        int[] windowX = [330, 430];
        int[] frameX = [347, 330, 447, 430];
        int[] frameY = [170, 188, 170, 188];
        int[] frameW = [5, 40, 5, 40];
        int[] frameH = [40, 5, 40, 5];

        int[] boneX = [495, 495, 545, 545];
        int[] boneY = [315, 325, 315, 325];

        int[] cloudX = [100, 130, 75, 115, 155, 600, 630, 575, 615, 655];
        int[] cloudY = [65, 75, 100, 100, 100, 75, 65, 100, 100, 100];

        int digX = 500;
        int digY = 360;

        // Custom colors
        Color Brown = new Color(120, 90, 85);
        Color roofRed = new Color(176, 74, 88);
        Color indoorYellow = new Color(230, 223, 161);
        Color skyBlue = new Color(140, 186, 222);
        Color grassGreen = new Color(138, 163, 85);
        Color marksTheSpot = new Color(110, 95, 77);
        Color dogBrown = new Color(209, 174, 138);
        Color dogLegs = new Color(186, 146, 115);
        Color dogEyes = new Color(87, 72, 59);
        Color outerHole = new Color(92, 70, 68);
        Color innerHole = new Color(120, 90, 85);
        Color fence = new Color(186, 146, 115);
        Color bushesGreen = new Color(50, 86, 29);
 
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Set up window
            Window.SetTitle("Digging Dog");
            Window.SetSize(800, 600);
            // Remove outlines
            Draw.LineColor = Color.Clear;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // Reset background
            Window.ClearBackground(Color.OffWhite);

            // Sky
            Draw.FillColor = skyBlue;
            Draw.Rectangle(0, 0, 800, 250);

            // Grass
            Draw.FillColor = grassGreen;
            Draw.Rectangle(0, 250, 800, 600);

            DrawMark();

            if (Input.IsMouseButtonDown(0)) // Checks if the mouse is over the X
            {
                bool isDogOnX = Input.GetMouseX() > digX && Input.GetMouseX() < digX + 40 && Input.GetMouseY() > digY && Input.GetMouseY() < digY + 40;

                if (isDogOnX)
                {
                    DrawHole();
                    DrawBone();
                }
            }

            DrawFence(0, 210);
            DrawHouse();
            DrawDogHouse();

            if (Input.IsMouseButtonDown(0)) // Makes dog bark when left mouse is pressed
            {
                DrawDogBark();
            }
            else
            {
                DrawDog();
            }

            DrawBushes(0, 575);
            DrawClouds();
        }
        void DrawMark() // Drawing for the X
        {
            Draw.FillColor = Color.Clear; // Invisible box to check for mouse click
            Draw.Square(digX, digY, 40);
            Draw.FillColor = marksTheSpot;
            Draw.Quad(500, 370, 510, 360, 540, 390, 530, 400);
            Draw.Quad(530, 360, 540, 370, 510, 400, 500, 390);
        }
        void DrawHole() // Hole drawing
        {
            Draw.FillColor = outerHole; // Outer
            Draw.Circle(520, 380, 40);
            Draw.FillColor = innerHole; // Inner
            Draw.Circle(520, 380, 30);
        }
        void DrawBone() // Bone drawing
        {
            Draw.FillColor = Color.OffWhite;
            for (int boneIndex = 0; boneIndex < 4; boneIndex++) // Draws the bone
            {
                Draw.Circle(boneX[boneIndex], boneY[boneIndex], 10);
            }
            Draw.Rectangle(490, 310, 60, 20);
        }
        void DrawBushes(float bushesX, float bushesY) // Drawing for the bushes
        {
            Draw.FillColor = bushesGreen;
            for (int bushesIndex = 0; bushesIndex < 31; bushesIndex++) // Draws the bushes
            {
                bushesX = bushesX + 25;
                Draw.Circle(bushesX, bushesY, 40);
            }
        }
        void DrawHouse() // House drawing
        {
            Draw.FillColor = Brown;
            Draw.Rectangle(300, 150, 200, 150); // House
            Draw.FillColor = roofRed;
            Draw.Triangle(300, 150, 400, 50, 500, 150); // Roof
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(370, 230, 60, 70);
            Draw.FillColor = Color.Black;
            Draw.Circle(420, 270, 5);

            Draw.FillColor = indoorYellow;
            for (int windowIndex = 0; windowIndex < 2; windowIndex++) // Draws the two windows
            {
                Draw.Square(windowX[windowIndex], 170, 40);
            }

            Draw.FillColor = Color.Black;
            for (int frameIndex = 0; frameIndex < 4; frameIndex++) // Draws the frames for the two windows
            {
                Draw.Rectangle(frameX[frameIndex], frameY[frameIndex], frameW[frameIndex], frameH[frameIndex]);
            }
            
        }
        void DrawDogHouse() // Dog house drawing
        {
            Draw.FillColor = Brown;
            Draw.Rectangle(650, 250, 100, 80); // House
            Draw.FillColor = roofRed;
            Draw.Triangle(650, 250, 700, 200, 750, 250); // Roof
            Draw.FillColor = Color.DarkGray;
            Draw.Arc(700, 290, 40, 40, 180, 360);
            Draw.Rectangle(680, 290, 40, 40);
            Draw.FillColor = Color.Black;
            Draw.Rectangle(660, 255, 80, 10);
            Draw.FillColor = dogBrown;
            Draw.Rectangle(665, 257, 70, 5);
        }
        void DrawFence(float fenceX, float fenceY) // Draws fence across the screen
        {
            Draw.FillColor = fence;
            for (int fenceIndex = 0; fenceIndex < 30; fenceIndex++)
            {
                Draw.Rectangle(fenceX, fenceY, 20, 50);
                fenceX = fenceX + 30; // Moves the fence post 30 to the right
            }
            Draw.Rectangle(0, 230, 800, 10);
        }
        void DrawClouds() // Cloud drawings
        {
            Draw.FillColor = Color.OffWhite;
            for (int cloudIndex = 0; cloudIndex < 10; cloudIndex++) // Draws the clouds
            {
                Draw.Circle(cloudX[cloudIndex], cloudY[cloudIndex], 30);
            }
        }
        void DrawDog() // Draws the dog and moves it with the mouse cursor
        {
            Draw.FillColor = dogBrown;
            // Body
            Draw.Rectangle(Input.GetMouseX() - 45, Input.GetMouseY() - 20, 90, 40);

            // Head
            Draw.Square(Input.GetMouseX() + 30, Input.GetMouseY() - 40, 40);

            // Ears
            Draw.FillColor = dogLegs;
            Draw.Quad(Input.GetMouseX() + 30, Input.GetMouseY() - 40, Input.GetMouseX() + 25, Input.GetMouseY() - 25, Input.GetMouseX() + 35, Input.GetMouseY() - 20, Input.GetMouseX() + 40, Input.GetMouseY() - 30);

            // Eyes
            Draw.FillColor = Color.OffWhite;
            Draw.Square(Input.GetMouseX() + 55, Input.GetMouseY() - 35, 15);
            Draw.FillColor = dogEyes;
            Draw.Square(Input.GetMouseX() + 60, Input.GetMouseY() - 30, 10);

            // Nose            
            Draw.FillColor = dogBrown;
            Draw.Square(Input.GetMouseX() + 60, Input.GetMouseY() - 20, 20);            
            Draw.FillColor = Color.Black;
            Draw.Square(Input.GetMouseX() + 75, Input.GetMouseY() - 20, 5);

            // Tail
            Draw.FillColor = dogBrown;
            Draw.Quad(Input.GetMouseX() - 60, Input.GetMouseY() - 30, Input.GetMouseX() - 50, Input.GetMouseY() - 40, Input.GetMouseX() - 30, Input.GetMouseY() - 20, Input.GetMouseX() - 40, Input.GetMouseY() - 10);
            
            // Back Legs
            Draw.FillColor = dogLegs;
            Draw.Rectangle(Input.GetMouseX() - 25, Input.GetMouseY() + 20, 10, 10);
            Draw.Rectangle(Input.GetMouseX() +30, Input.GetMouseY() + 20, 10, 10);

            // Front Legs
            Draw.FillColor = dogBrown;
            Draw.Rectangle(Input.GetMouseX() - 30, Input.GetMouseY() + 20, 10, 20);
            Draw.Rectangle(Input.GetMouseX() + 25, Input.GetMouseY() + 20, 10, 20);
        }
        void DrawDogBark() // Draws the dog barking
        {
            Draw.FillColor = dogBrown;
            // Body
            Draw.Rectangle(Input.GetMouseX() - 45, Input.GetMouseY() - 20, 90, 40);

            // Head
            Draw.Square(Input.GetMouseX() + 30, Input.GetMouseY() - 40, 40);

            // Ears
            Draw.FillColor = dogLegs;
            Draw.Quad(Input.GetMouseX() + 30, Input.GetMouseY() - 40, Input.GetMouseX() + 25, Input.GetMouseY() - 25, Input.GetMouseX() + 35, Input.GetMouseY() - 20, Input.GetMouseX() + 40, Input.GetMouseY() - 30);

            // Eyes
            Draw.FillColor = Color.OffWhite;
            Draw.Square(Input.GetMouseX() + 55, Input.GetMouseY() - 35, 15);
            Draw.FillColor = dogEyes;
            Draw.Square(Input.GetMouseX() + 60, Input.GetMouseY() - 30, 10);

            // Nose            
            Draw.FillColor = dogBrown;
            Draw.Rectangle(Input.GetMouseX() + 60, Input.GetMouseY() - 20, 20, 10);
            Draw.Quad(Input.GetMouseX() + 63, Input.GetMouseY() - 7, Input.GetMouseX() + 57, Input.GetMouseY() - 3, Input.GetMouseX() + 73, Input.GetMouseY() + 2, Input.GetMouseX() + 78, Input.GetMouseY() - 3);
            Draw.FillColor = Color.Black;
            Draw.Square(Input.GetMouseX() + 75, Input.GetMouseY() - 20, 5);

            // Tail
            Draw.FillColor = dogBrown;
            Draw.Rectangle(Input.GetMouseX() - 45, Input.GetMouseY() - 40, 15, 25);

            // Back Legs
            Draw.FillColor = dogLegs;
            Draw.Rectangle(Input.GetMouseX() - 25, Input.GetMouseY() + 20, 10, 10);
            Draw.Rectangle(Input.GetMouseX() + 30, Input.GetMouseY() + 20, 10, 10);

            // Front Legs
            Draw.FillColor = dogBrown;
            Draw.Rectangle(Input.GetMouseX() - 30, Input.GetMouseY() + 20, 10, 20);
            Draw.Rectangle(Input.GetMouseX() + 25, Input.GetMouseY() + 20, 10, 20);
        }
    }
}