using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit 
{
    public class CellFedFilter : Zephob
    {
        private CellFed _cellFedFilter = new CellFed();

        public CellFed CellfedFilter
        {
            get { return _cellFedFilter; }
            set { _cellFedFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFedFilter))
            {
                throw new ArgumentException("Invalid assignment source", "CellFedFilter");
            }

            _cellFedFilter.AssignFromSource((aSource as CellFedFilter)._cellFedFilter);          
        }
    }
}
