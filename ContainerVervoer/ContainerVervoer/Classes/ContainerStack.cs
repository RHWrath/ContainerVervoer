using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.Classes
{
    public class ContainerStack
    {
        public const int MAXWEIGHT = 150;
        public int CurrentStackWeight { get; set; }
        public IEnumerable<Container> Containers { get { return Containers; } }
    }
}
