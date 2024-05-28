using System;
using System.Collections;
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
        public int LeftsideWeight { get { return LeftsideWeightCalculator(); } }
        public int RightsideWeight { get { return RightsideWeightCalculator(); } }
        public int CurrentStackRowWeight { get { return ContainerStacks.Sum(e => e.CurrentStackWeight); } }
        public double DivideWidth { get { return Math.Round(Convert.ToDouble(ContainerStacks.Count()) / 2, MidpointRounding.ToZero); } }

        public ContainerStackRow(int width) 
        { 
            for (int i = 0; i < width; i++)
            {
                containerstack.Add(new ContainerStack());
            }
        }

        public void AddingContainerStackRow(Container Container)
        {
            bool containerAdded = false;

            foreach (ContainerStack Stack in containerstack)
            {
                if (!containerAdded)  containerAdded = Stack.TryAddingContainerToStack(Container);
            }
        }
        
        private int LeftsideWeightCalculator()
        {
            List<ContainerStack> LeftSideStacks =  ContainerStacks.TakeLast(Convert.ToInt32(DivideWidth)).ToList();

            return LeftSideStacks.Sum(e => e.CurrentStackWeight);
        }
        private int RightsideWeightCalculator()
        {
            List<ContainerStack> RightSideStacks = ContainerStacks.TakeLast(Convert.ToInt32(DivideWidth)).ToList();

            return RightSideStacks.Sum(e => e.CurrentStackWeight);
        }



    }
}
