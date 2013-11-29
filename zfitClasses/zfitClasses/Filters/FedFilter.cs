using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FedFilter : Zephob
    {
        private bool _isFiltered;
        private string _fedNameFilter;

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public string FedNameFilter
        {
            get { return _fedNameFilter; }
            set { _fedNameFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FedFilter))
            {
                throw new ArgumentException("Invalid assignment source", "FedFilter");
            }

            _isFiltered = (aSource as FedFilter)._isFiltered;
            _fedNameFilter = (aSource as FedFilter)._fedNameFilter;
        }
    }
}
