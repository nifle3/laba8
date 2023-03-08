using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace laba8
{
    internal class Polygon: IFigurable
    {
        private Point[] _points;

        public override void Draw()
        {

        }
        public override void MoveTo(double deltax, double deltay)
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
