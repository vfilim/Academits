using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape sh1, IShape sh2)
        {
            if (sh1.GetArea() > sh2.GetArea())
            {
                return 1;
            }
            else if (sh1.GetArea() < sh2.GetArea())
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
