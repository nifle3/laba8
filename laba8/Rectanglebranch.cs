using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal class Rectangle: Figure
    {
        public Rectangle(double x, double y, double width, double height) : base(x, y, width, height) { }
        public override void Draw()
        {
        }
    }
    internal class Square : Rectangle 
    {
        public Square(double x, double y, double side) : base(x, y, side, side) { }
        public override void Draw()
        {
        }

    }
}
