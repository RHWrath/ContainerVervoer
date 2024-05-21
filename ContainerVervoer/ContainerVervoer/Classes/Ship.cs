using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.Classes
{
    public class Ship
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int MaxWeight { get; set; }
        IEnumerable<ContainerStack> Stacks { get; set; }
        IEnumerable<Container> OnDock {  get; set; }

        public Ship(int length,int width) 
        {
            Length = length;
            Width = width;
            MaxWeight = Length * Width * 150;
        
        }


    }
}
