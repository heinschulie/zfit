using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class CellFanFilter : Zephob
    {
        private CellFan _cellFanFilter;


        public CellFan CellfanFilter
        {
            get { return _cellFanFilter; }
            set { _cellFanFilter = value; }
        }


        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFanFilter))
            {
                throw new ArgumentException("Invalid assignment source", "CellFanFilter");
            }

            _cellFanFilter.AssignFromSource((aSource as CellFanFilter)._cellFanFilter);          
        }
    }
}
