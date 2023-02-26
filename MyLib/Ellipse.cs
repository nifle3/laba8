using System;

namespace laba8
{
    internal class Ellipse :Figure
    {
        public Ellipse(double x,double y, double width, double height) : base(x,y,width,height) { }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(Init.pen, (float)X, (float)Y, (float)Width, (float)Height);

            Init.picturebox.Image = Init.bitmap;
        }
    }

    internal class Circle : Ellipse
    {
        public Circle(double x, double y, double radius):base(x,y,radius, radius) { }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
