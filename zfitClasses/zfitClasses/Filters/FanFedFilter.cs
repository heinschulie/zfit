using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class FanFedFilter : Zephob
    {
        private FanFed _fanFedFilter = new FanFed();

        public FanFed FanfedFilter
        {
            get { return _fanFedFilter; }
            set { _fanFedFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanFedFilter))
            {
                throw new ArgumentException("Invalid assignment source", "FanFedFilter");
            }

            _fanFedFilter.AssignFromSource((aSource as FanFedFilter)._fanFedFilter);
        }
    }
}

