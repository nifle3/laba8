using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal class Rectangle: Figure
    {
        public Rectangle(double x = 0, double y = 0, double width = 0, double height = 0) : base(x, y, width, height) { }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, (float)X, (float)Y, (float)Width, (float)Height);

            Init.pictureBox.Image = Init.bitmap;
        }
    }
    internal class Square : Rectangle 
    {
        public Square(double x = 0, double y = 0, double side = 0) : base(x, y, side, side) { }
        public override void Draw()
        {
            base.Draw();
        }

    }
}
