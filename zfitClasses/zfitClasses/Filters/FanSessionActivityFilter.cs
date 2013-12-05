using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanSessionActivityFilter : Zephob
    {
        private FanSessionActivityKey _fsaFilter = new FanSessionActivityKey();

        public FanSessionActivityKey FsaFilter
        {
            get { return _fsaFilter; }
            set { _fsaFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanSessionActivityFilter))
            {
                throw new ArgumentException("Invalid assignment source", "FanSessionActivityFilter");
            }

            _fsaFilter.AssignFromSource((aSource as FanSessionActivityFilter)._fsaFilter);
        }
    }
}
