using System;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace laba8
{
    internal class Polygon: IFigurable
    {
        private Point[] _points;

        public Polygon(Point[] points) =>
            _points = points;

        public void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, _points);   

            Init.pictureBox.Image = Init.bitmap;
        }

        public bool MoveTo(double deltax, double deltay)
        {
            Point[] point = (Point[])_points.Clone();

            for (int i = 0; i < point.Length; i++)
            {
                if (!OutWidnow(point[i].X + deltax, point[i].Y + deltay))
                {
                    return false;
                }

                point[i].X += (int)deltax;
                point[i].Y += (int)deltay;
            }

            _points = (Point[])point.Clone();

            return true;
        }

        private bool OutWidnow(double x, double y)
        {
            double width = Init.pictureBox.Width;
            double Height = Init.pictureBox.Height; 

            if (!(x >= width || x <= 0) && !(y >= Height || y <= 0))
                return true;

            return false;
        }

        public bool Scale(double deltax, double deltay)
        {
            Point[] point = (Point[])_points.Clone();
            
            if (point.Length != 1) 
            {
                for (int i = 1; i < point.Length; i++)
                {
                    if (OutWidnow(point[i].X + deltax, point[i].Y + deltay))
                    {
                        return false;
                    }

                    point[i].X += (int)deltax;
                    point[i].Y += (int)deltay;
                }
            }

            _points = (Point[])point.Clone();

            return true;
        }
    }
    
    internal class Triangle: Polygon
    {
        public Triangle(Point[] pt): base (pt)
        {
        }
    }
}
