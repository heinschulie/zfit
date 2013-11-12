using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace zfit
{
    public class FanFilter : Zephob
    {
        private bool _isFiltered;
        private string _fanNameFilter;

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public string FanNameFilter
        {
            get { return _fanNameFilter; }
            set { _fanNameFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanFilter))
            {
                throw new ArgumentException("Invalid assignment source", "FanFilter");
            }

            _isFiltered = (aSource as FanFilter)._isFiltered;
            _fanNameFilter = (aSource as FanFilter)._fanNameFilter;
        }
    }
}
