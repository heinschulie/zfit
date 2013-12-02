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
        private string _fanNameFilter;

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

            _fanNameFilter = (aSource as FanFilter)._fanNameFilter;
        }
    }
}
