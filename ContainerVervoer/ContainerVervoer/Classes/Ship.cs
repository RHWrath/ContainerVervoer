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
        public int CurrentShipWeight { get { return stacks.Sum(e => e.CurrentStackWeight); } }
        public IReadOnlyList<ContainerStackRow> ContainerStackRows { get { return containerstackrows; } }
        private List<ContainerStackRow> containerstackrows { get; set; } = new();

        public IReadOnlyList<ContainerStack> Stacks { get   { return stacks; } }
        private List<ContainerStack> stacks { get; set; } = new();
        public IReadOnlyList<Container> onDock {  get { return onDocking; } }
        private List<Container> onDocking { get; set; } = new();

        public Ship(int length,int width) 
        {
            Length = length;
            Width = width;
            MaxShipWeight = Length * Width * 150;
            CreateContainerStackRow();
        }

       public void DivideContainersOverShip()
        {
            //int CurrentCooled = 0;
            //onDocking = SortContainer(onDocking);

            //foreach (var container in onDocking) 
            //{
            //    bool containerAdded = false;

            //    foreach (var stack in stacks)
            //        {
            //            while (containerAdded == false)
            //            {
            //                if (container.IsCooled && container.IsValueble)
            //                {
            //                    stack.AddContainerToStack(container);
            //                    containerAdded = true;
            //                }

            //                if (container.IsCooled)
            //                {
            //                    stack.AddContainerToStack(container);
            //                    containerAdded = true;
            //                }

            //                if (container.IsValueble)
            //                {
            //                    stack.AddContainerToStack(container);
            //                    containerAdded = true;
            //                }
            //                else
            //                {
            //                    stack.AddContainerToStack(container);
            //                    containerAdded = true;
            //                }
            //            }
            //        }
            //}

        }

        

        private void CreateContainerStackRow()
        {
            for (int i = 0; i < Length; i++)
            {
                containerstackrows.Add(new ContainerStackRow(Width));
            }
        }      
        

        public void AddContainerToDock(Container container)
        {
            onDocking.Add(container);
        }
        
        public List<Container> SortContainer(List<Container> ondocking)
        {
            return ondocking.OrderByDescending(c => c.IsCooled).ThenBy(c => c.IsValueble).ThenBy(c => c.CurrentContainerWeight).ToList();
        }

        #region WeightCalculatione
        public int CalculateWeightLeftside()
        {
            int LeftWeight =0;

            return LeftWeight += containerstackrows.Sum(row => row.ContainerStacks.FirstOrDefault().CurrentStackWeight);
        }

        public int CalculateWeightRightside()
        {
            int RightWeight = 0;

            return RightWeight += containerstackrows.Sum(row => row.ContainerStacks.LastOrDefault().CurrentStackWeight);
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
        public bool CalculateMargins(int weightLeftside, int weightRightside)
        {
            return weightLeftside >= weightRightside * 0.80 && weightRightside >= weightLeftside * 0.80;
        }
        #endregion
    }
}
