namespace laba8
{
    internal class MyFig : SimpleFigure
    {
        public MyFig(double x, double y, double wid, double hei):base(x,y,wid,hei) { }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, (int)X, (int)(Y +(Height/2)), (int)Width, (int)Height/2);
            g.DrawEllipse(Init.pen, (int)X, (int)(Y + Height / 2), (int)Width, (int)Height/2);
            g.DrawPolygon(Init.pen, new Point[]{
                new Point((int)(X + Width/2), (int)Y), 
                new Point((int)X, (int)(Y + Height/2)), 
                new Point((int)(X + Width), (int)(Y + Height/2))
            });

            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
