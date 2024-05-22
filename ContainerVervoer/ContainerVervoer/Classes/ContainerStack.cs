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
        public IEnumerable<Container> Containers { get { return containers; } }
        private List<Container> containers { get; set; }


        public bool AcceptebleStackWeight() 
        {
            if (CurrentStackWeight <= MAXWEIGHT)
            { return true; } else { return false; }
        }

        public void ChangeCurrentStackWeight()
        {
            CurrentStackWeight = 0;
            foreach (var container in containers)
            {             
                CurrentStackWeight =+container.CurrentContainerWeight;                
            }
        }

        public void AddContainerToStack(Container currentContainer)
        {
            containers.Add(currentContainer);
            ChangeCurrentStackWeight();
        }

    }
}
