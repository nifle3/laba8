using System;

namespace laba8
{
    internal class Polygon: Figure
    {
        public Polygon(double x, double y, double width, double height) : base(x, y, width, height) { }

        public override void Draw()
        {

        }
    }
    
    internal class Triangle: Polygon
    {
        public Triangle(double x, double y, double width, double height) : base(x, y, width, height) { }

        public override void Draw() 
        { 
        
        }
    }
}
