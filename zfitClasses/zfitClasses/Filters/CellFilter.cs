using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class CellFilter : Zephob
    {
        private bool _isFiltered;
        private string _cellNameFilter;

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

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

            _isFiltered = (aSource as CellFilter)._isFiltered;
            _cellNameFilter = (aSource as CellFilter)._cellNameFilter;
        }
    }
}
