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
        public int CurrentStackWeight { get { return containers.Sum(e => e.CurrentContainerWeight); } }
        public IReadOnlyList<Container> Containers { get { return containers; } }
        private List<Container> containers { get; set; } = new();


        

        

        public void AddContainerToStack(Container currentContainer)
        {
            containers.Add(currentContainer);
        }


        public bool TryAddingContainerToStack(Container container)
        {
            if (containers.Count != 0)
            {
                if (AcceptebleStackWeight() && DoesNotExceedCarryWeight(containers))
                {
                    if (!NotOnValueble(container))
                    {
                        containers.Add(container);
                        return true;
                    }
                }
            }
            else
            {
                containers.Add(container);
                return true;
            }
            return false;
        }

        #region Checks
        private bool DoesNotExceedCarryWeight(List<Container> containers)
        {
            
            if (CurrentStackWeight <= Container.MAXCARRYWEIGHT)
            {
                return true;
            }
            else { return false; }
        }
        public bool AcceptebleStackWeight()
        {
            if (CurrentStackWeight <= MAXWEIGHT)
            { return true; }
            else { return false; }
        }

        private bool NotOnValueble(Container container)
        {
            return containers.LastOrDefault()!.IsValueble;
        }
        #endregion
    }
}
