﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    public interface IShape
    {
        double GetWidth();
        double GetHight();
        double GetArea();
        double GetPerimeter();
    }
}
