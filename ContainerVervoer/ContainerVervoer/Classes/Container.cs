using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.Classes
{
    public class Container
    {
        public const int MAXWEIGHT = 30;
        public const int MINWEIGHT = 4;
        public const int MAXCARRYWEIGHT = 120;
        
        public bool IsCooled { get; set; }
        public bool IsValueble { get; set; }
        public int CurrentContainerWeight {  get; set; }

        public Container(bool iscooled, bool isvalueble,int currentweight) 
        {
            CurrentContainerWeight = currentweight;
            //if (!AcceptedWeight())
            //{
            //    throw new ArgumentException("Error invalid weight");
            //}

            IsCooled = iscooled;
            IsValueble = isvalueble;        
        }
        public bool AcceptedWeight()
        {
            return CurrentContainerWeight >= MINWEIGHT && CurrentContainerWeight <= MAXWEIGHT;
        }
    }
    
}
