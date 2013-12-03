using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class WorkoutFilter : Zephob
    {
        private Workout _workoutFilter = new Workout();

        public Workout ExcFilter
        {
            get { return _workoutFilter; }
            set { _workoutFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is WorkoutFilter))
            {
                throw new ArgumentException("Invalid assignment source", "WorkoutFilter");
            }

            _workoutFilter.AssignFromSource((aSource as WorkoutFilter)._workoutFilter);
        }
    }
}
