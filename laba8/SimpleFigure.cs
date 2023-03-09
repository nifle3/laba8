using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal abstract class SimpleFigure : IFigurable
    {
        private double _x;
        private double _y;
        private double _width;
        private double _height;
        public SimpleFigure(double x, double y, double width, double height) =>
           (Width, Height, X, Y) = (width, height, x, y);

        public abstract void Draw();
        
        public bool MoveTo(double deltax, double deltay)
        {
            return true;
        }

        public void Scale(double deltax, double deltay)
        {

        }
            
        public double X { set { _x = value >= 0 ? value : 0; } get => _x; }
        public double Y { set { _y = value >= 0 ? value : 0; } get => _y; }
        public double Width { set { _width = value >= 0 ? value : 1; } get => _width; }
        public double Height { set { _height = value >= 0 ? value : 1; } get => _height; }
    }
}
