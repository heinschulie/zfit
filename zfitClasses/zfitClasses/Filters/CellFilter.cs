using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class CellFilter : Zephob
    {
        private string _cellNameFilter;

        public string CellNameFilter
        {
            get { return _cellNameFilter; }
            set { _cellNameFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFilter))
            {
                throw new ArgumentException("Invalid assignment source", "CellFilter");
            }

            _cellNameFilter = (aSource as CellFilter)._cellNameFilter;
        }
    }
}
