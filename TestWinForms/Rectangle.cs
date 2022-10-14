using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace TestWinForms
{
    public class Rectangle
    {
        public float X { get; }
        public float Y { get; }
        public float Width { get; }
        public float Height { get; }
        public Color Color { get; }

        public Rectangle(float x, float y, float width, float height, Color color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
        }

        public static Rectangle GetRandomRectangle()
        {
            Random random = new Random();

            int width = random.Next(10, 250);
            int height = random.Next(10, 150);

            int x = random.Next(0, 500);
            int y = random.Next(0, 300);

            Color color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));

            return new Rectangle(x, y, width, height, color);
        }

        public bool Intersects(Rectangle rectangle)
        {
            return !(X + Width < rectangle.X ||
                     X > rectangle.X + rectangle.Width ||
                     Y > rectangle.Y + rectangle.Height ||
                     Y + Height < rectangle.Y);
        }
    }
}
