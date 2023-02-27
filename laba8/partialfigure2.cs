using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal abstract partial class Figure// часть класса Figure с методами и свойствами
    {
        // Свойства с проверкой на отрицатльное число, через тернарную операцию
        public double X { set { _x = value >= 0 ? value : 0; } get => _x; }
        public double Y { set { _y = value >= 0 ? value : 0; } get => _y; }
        public double Width { set { _width = value >= 0 ? value : 1; } get => _width; }
        public double Height { set { _height = value >= 0 ? value : 1; } get => _height; }

        public Figure() { }
        
        public Figure(double xc, double yc, double widthc, double heightc)=>
            (X, Y, Width, Height) = (xc, yc, widthc, heightc); // конструктор через кортеж.
        
        public abstract void Draw(); //абстрактный метод рисования

        public virtual void MoveTo(double deltaX, double deltaY)
        {
            if(X + deltaX < Init.pictureBox.Width)
                    X += deltaX;

            if (Y + deltaY < Init.pictureBox.Height)
                    Y += deltaY;
        }
    }
}
