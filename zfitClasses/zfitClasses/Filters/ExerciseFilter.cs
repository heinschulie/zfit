using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class ExerciseFilter : Zephob
    {
        private Exercise _exerciseFilter = new Exercise();

        public Exercise ExcFilter
        {
            get { return _exerciseFilter; }
            set { _exerciseFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ExerciseFilter))
            {
                throw new ArgumentException("Invalid assignment source", "ExerciseFilter");
            }

            _exerciseFilter.AssignFromSource((aSource as ExerciseFilter)._exerciseFilter);
        }
    }
}
