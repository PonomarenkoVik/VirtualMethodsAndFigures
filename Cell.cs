using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180131_InheritanceDemo
{
    class Cell
    {
        public bool Exist { get; set; }
        public ColorFig Color { get; set; }
        public bool Hide { get; set; }
        public Cell()
        {
            Exist = false;
            Color = ColorFig.Empty;
            Hide = false;
        }
    }
}
