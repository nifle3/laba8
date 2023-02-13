using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal abstract partial class Figure
    {
        // Свойства с проверкой на отрицатльное число, через тернарную операцию
        public double X { set { x = value >= 0 ? value : 0; } get => x; }
        public double Y { set { y = value >= 0 ? value : 0; } get => y; }
        public double Width { set { width = value >= 0 ? value : 0; } get => width; }
        public double Height { set { height = value >= 0 ? value : 0; } get => height; }


        public Figure(double xc, double yc, double widthc, double heightc)=>
            (X, Y, Width, Height) = (xc, yc, widthc, heightc); // конструктор через кортеж.
        public void Move(double movex, double movey)// метод для передвижения фигур
        {
            X += movex;
            Y += movey;
        }
        public abstract void Draw(); //абстрактный класс через рисование
    }
}
