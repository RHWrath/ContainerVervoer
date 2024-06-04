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
        public int CurrentShipWeight { get {return containerstackrows.Sum(e => e.CurrentStackRowWeight); } }
        public IReadOnlyList<ContainerStackRow> ContainerStackRows { get { return containerstackrows; } }
        private List<ContainerStackRow> containerstackrows { get; set; } = new();
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
            
            try
            {
                //if (CanShipWeightBeHalfFilled() && OverMaxWeightOnShip())
                //{
                    onDocking = SortContainer(onDocking);
                    TryToPlaceCooledContainer();
                    TryToPlaceNormaleContainer();
                    TryToPlaceValuebleContainer();

                //}
            } 
            catch (Exception)
            {
                throw;
            }
        }

        private void TryToPlaceCooledContainer()
        {

            List<Container> CooledContainers = onDocking.Where(c => c.IsCooled).ToList();

            foreach (Container cooledcontainer in CooledContainers)
            {

                containerstackrows[0].AddingContainerStackRow(cooledcontainer);
            }
        }

        private void TryToPlaceNormaleContainer()
        {
            int RowIndex = 1;
            int AmountContainersAdded = 0;

            List<Container> NormalContainers = onDocking.Where(c => !c.IsCooled).Where(c => !c.IsValueble).ToList();
            foreach (Container normalcontainer in NormalContainers)
            {
                bool containerAdded = false;

                if (RowIndex == Length) RowIndex = 0;
                containerAdded = containerstackrows[RowIndex].AddingContainerStackRow(normalcontainer);

                if (containerAdded)  AmountContainersAdded++; else RowIndex++;

                if (AmountContainersAdded == Width) AmountContainersAdded = 0;
            }
        }

        private void TryToPlaceValuebleContainer()
        {
            List<Container> ValuebleContainers = onDocking.Where(c => c.IsValueble).Where(c => !c.IsCooled).ToList();

            foreach (Container valueblecontainer in ValuebleContainers)
            {
                bool containerAdded = false;

                for (int i = 0; i < ContainerStackRows.Count; i++)
                {
                    if (!containerAdded)
                    {
                        containerAdded = true;
                    }
                }
            }
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
        

        public int CalculateWeightRightside()
        {
            int RightWeight = 0;

            return RightWeight += containerstackrows.Sum(row => row.ContainerStacks.LastOrDefault().CurrentStackWeight);
        }

        public int CalculateWeightLeftside()
        {
            int RightWeight = 0;

            return RightWeight += containerstackrows.Sum(row => row.ContainerStacks.FirstOrDefault().CurrentStackWeight);
        }


        public bool CalculateMargins(int weightLeftside, int weightRightside)
        {
            return weightLeftside >= weightRightside * 0.80 && weightRightside >= weightLeftside * 0.80;
        }

        public bool CanShipWeightBeHalfFilled()
        {
            if (onDock.Sum(e => e.CurrentContainerWeight) >= MaxShipWeight /2)
            {
                return true;
            }
            return false;
        }

        public bool OverMaxWeightOnShip()
        {
            if (onDock.Sum(e => e.CurrentContainerWeight) >= MaxShipWeight)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
