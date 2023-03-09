﻿using System;
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
        public void MoveTo(double deltax, double deltay);
        public void Scale(double deltax, double deltay);
    }
}
