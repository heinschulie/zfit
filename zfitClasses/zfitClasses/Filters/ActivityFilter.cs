using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class ActivityFilter : Zephob
    {
        private Activity _activityFilter = new Activity();

        public Activity ActFilter
        {
            get { return _activityFilter; }
            set { _activityFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ActivityFilter))
            {
                throw new ArgumentException("Invalid assignment source", "ActivityFilter");
            }

            _activityFilter.AssignFromSource((aSource as ActivityFilter)._activityFilter);
        }
    }
}
