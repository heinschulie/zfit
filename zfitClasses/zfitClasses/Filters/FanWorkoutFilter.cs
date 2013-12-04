using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanWorkoutFilter : Zephob
    {
        private FanWorkout _fawFilter = new FanWorkout();

        public FanWorkout FawFilter
        {
            get { return _fawFilter; }
            set { _fawFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanWorkoutFilter))
            {
                throw new ArgumentException("Invalid assignment source", "FanWorkoutFilter");
            }

            _fawFilter.AssignFromSource((aSource as FanWorkoutFilter)._fawFilter);
        }
    }
}
