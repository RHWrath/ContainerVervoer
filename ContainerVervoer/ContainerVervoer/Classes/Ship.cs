using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.Classes
{
    public class Ship
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int MaxShipWeight { get; set; }
        public int CurrentShipWeight { get; set; }
        IEnumerable<ContainerStack> STONKs { get   { return stacks; } }
        private List<ContainerStack> stacks { get; set; } = new();
        IEnumerable<Container> OnDock {  get { return onDock; } }
        private List<Container> onDock { get; set; } = new();

        public Ship(int length,int width) 
        {
            Length = length;
            Width = width;
            MaxShipWeight = Length * Width * 150;
            CreateContainerStack();
        }

       public void AddContainerToStack()
        {

            foreach (var stack in stacks) 
            {
                if (stack.AcceptebleStackWeight())
                {
                    AddContainerToStack();
                }
            
            }

        }

        public bool CalculateMargins(int weightLeftside, int weightRightside)
        {
            return weightLeftside >= weightRightside * 0.80 && weightRightside >= weightLeftside * 0.80;
        }


        private void CreateContainerStack()
        {
            int StacksNeeded = Length * Width;
            for (int i = 0; i < StacksNeeded; i++)
            {
                stacks.Add(new ContainerStack());
            }
        }

        private void CalculateTotalWeightSide(int index)
        {
            for (int i = 0; i < stacks.Count / Width; i++)
            {
                CurrentShipWeight += stacks[index].CurrentStackWeight;
                index += Width;
            }
        }

        public bool ShipWeightHalfFilled()
        {
            int HalfShipWeight = MaxShipWeight / 2;
            if (MaxShipWeight <= HalfShipWeight)
            {
                return true;
            }
            return false;
        }

        

    }
}
