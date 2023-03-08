using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal interface IFigurable
    {
        public abstract void Draw();
        public abstract void MoveTo(double deltaX, double deltaY);
    }
}
