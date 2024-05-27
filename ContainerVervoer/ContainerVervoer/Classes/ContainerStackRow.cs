using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.Classes
{
    public class ContainerStackRow
    {
        public IReadOnlyList<ContainerStack> ContainerStacks { get { return containerstack; } }

        private List<ContainerStack> containerstack { get; set; } = new();

        public ContainerStackRow(int width) 
        { 
            for (int i = 0; i < width; i++)
            {
                containerstack.Add(new ContainerStack());
            }
        }




    }
}
