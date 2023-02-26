using System;

namespace laba8
{
    internal class Polygon: Figure
    {
        public Polygon(double x =0 , double y = 0, double width = 0, double height = 0) : base(x, y, width, height) { }

        public override void Draw()
        {

        }
    }
    
    internal class Triangle: Polygon
    {
        public Triangle(double x = 0, double y = 0, double width = 0, double height = 0) : base(x, y, width, height) { }

        public override void Draw() 
        { 
        
        }
    }
}
