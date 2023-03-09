using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace laba8
{
    internal class Polygon: IFigurable
    {
        private Point[] _points;

        public void Draw()
        {

        }
        public void MoveTo(double deltax, double deltay)
        {

        }

        public void Scale(double deltax, double deltay)
        {

        }
    }
    
    internal class Triangle: Polygon
    {
        public Triangle()
        {

        }
    }
}
