using System;

namespace laba8
{
    internal class Ellipse :Figure
    {
        public Ellipse(double x = 0,double y = 0, double width = 0, double height = 0) : base(x,y,width,height) { }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(Init.pen, (float)X, (float)Y, (float)Width, (float)Height);

            Init.pictureBox.Image = Init.bitmap;
        }
    }

    internal class Circle : Ellipse
    {
        public Circle(double x = 0, double y = 0, double radius = 0):base(x,y,radius, radius) { }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
