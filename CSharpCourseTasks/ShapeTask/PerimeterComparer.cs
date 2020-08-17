﻿using System.Collections.Generic;
using ShapeTask.Shapes;

namespace ShapeTask
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
        }
    }
}
