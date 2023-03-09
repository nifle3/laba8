using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal interface IFigurable
    {
        public abstract void Draw();
        public bool MoveTo(double deltax, double deltay);
        public bool Scale(double deltax, double deltay);
    }
}
