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
        float xPosition = 0;
        float yPosition = 0;
        
        // Window Arrays
        int[] windowX = [330, 430];
        int[] frameX = [347, 330, 447, 430];
        int[] frameY = [170, 188, 170, 188];
        int[] frameW = [5, 40, 5, 40];
        int[] frameH = [40, 5, 40, 5];

        Color Brown = new Color(120, 90, 85);
        Color roofRed = new Color(176, 74, 88);
        Color indoorYellow = new Color(230, 223, 161);
        Color skyBlue = new Color(140, 186, 222);
        Color grassGreen = new Color(138, 163, 85);
        Color marksTheSpot = new Color(110, 95, 77);
        Color dogBrown = new Color(209, 174, 138);
        Color dogLegs = new Color(186, 146, 115);
        Color dogEyes = new Color(87, 72, 59);
 
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

            DrawHouse();
            DrawMark1();
            DrawDog();
        }
        void DrawMark1()
        {
            Draw.FillColor = marksTheSpot;
            Draw.Quad(500, 370, 510, 360, 540, 390, 530, 400);
            Draw.Quad(530, 360, 540, 370, 510, 400, 500, 390);
        }
        void DrawMark2()
        {
            Draw.FillColor = Color.Black;
            Draw.Quad(500, 370, 510, 360, 540, 390, 530, 400);
            Draw.Quad(530, 360, 540, 370, 510, 400, 500, 390);
        }
        void DrawHouse()
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
        void DrawDog()
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
    }
}