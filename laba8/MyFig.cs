namespace laba8
{
    internal class MyFig : Figure
    {
        public MyFig(double x, double y, double wid, double hei):base(x,y,wid,hei) { }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, (int)X, (int)(Y +(Height/2)), (int)Width, (int)Height /2);
            g.DrawEllipse(Init.pen, (int)X+2, (int)(Y + (Height / 3)), (int)Width / 2, (int)Height / 4);
            g.DrawPolygon(Init.pen, );

            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
