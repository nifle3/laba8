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
            double sidex = _x + _width;
            double sidey = _y + _height;

            double pBWidth = Init.pictureBox.Width;
            double pBHeight = Init.pictureBox.Height;

            if (sidex + deltax <= pBWidth && _x + deltax >= 0 && sidey + deltay <= pBHeight && _y + deltay >= 0)
            {
                _x += deltax;
                _y += deltay;
                return true;
            }

            return false;
            }

        public void Scale(double deltax, double deltay)
        {
            double pBWidth = Init.pictureBox.Width;
            double pBHeight = Init.pictureBox.Height;

            if (_width + deltax >= 0 && _width <= pBWidth && _height + deltay >= 0 && _height <= pBHeight)
            {
                _width += deltax;
                _height += deltay;
            }
        }
            
        public double X { set { _x = value >= 0 ? value : 0; } get => _x; }
        public double Y { set { _y = value >= 0 ? value : 0; } get => _y; }
        public double Width { set { _width = value >= 0 ? value : 1; } get => _width; }
        public double Height { set { _height = value >= 0 ? value : 1; } get => _height; }
    }
}
