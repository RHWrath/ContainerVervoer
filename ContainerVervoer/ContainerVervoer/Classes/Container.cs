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
        public int CurrentWeight {  get; set; }

        public Container(bool iscooled, bool isvalueble,int currentweight) 
        { 
            if (!AcceptedWeight(currentweight))
            {
                throw new ArgumentException("Error invalid weight");
            }

            CurrentWeight = currentweight;
            IsCooled = iscooled;
            IsValueble = isvalueble;        
        }
        public bool AcceptedWeight(int Weight)
        {
            return Weight >= MAXWEIGHT && Weight <= MINWEIGHT;
        }
    }
    
}
