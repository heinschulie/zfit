using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanSessionFilter : Zephob
    {
        private FanSession _fssFilter = new FanSession();

        public FanSession FssFilter
        {
            get { return _fssFilter; }
            set { _fssFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanSessionFilter))
            {
                throw new ArgumentException("Invalid assignment source", "FanSessionFilter");
            }

            _fssFilter.AssignFromSource((aSource as FanSessionFilter)._fssFilter);
        }
    }
}
