using System;
using System.DirectoryServices.ActiveDirectory;

namespace laba8
{
    internal class Polygon: Figure
    {
        private Point[] _points;

        public int i;
        public int count;

        public Polygon(int index) : base()
        {
            _points = new Point[index];
            i = 0;
            count = index;
        }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, _points);

            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(double deltaX, double deltaY)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                if (_points[i].X + deltaX < Init.pictureBox.Width)
                    _points[i].X += (int)deltaX;

                if (_points[i].Y + deltaY < Init.pictureBox.Height)
                    _points[i].Y += (int)deltaY;
            }
        }

        public Point this[int index]
        {
            set
            {
                if(index >= 0 && index < _points.Length)
                {
                    _points[index] = value;
                }
            }
        }
    }
    
    internal class Triangle: Polygon
    {
        public Triangle() : base(3) { }
    }
}
