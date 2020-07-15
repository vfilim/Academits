using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape sh1, IShape sh2)
        {
            if (sh1.GetPerimeter() > sh2.GetPerimeter())
            {
                return 1;
            }
            else if (sh1.GetPerimeter() < sh2.GetPerimeter())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
