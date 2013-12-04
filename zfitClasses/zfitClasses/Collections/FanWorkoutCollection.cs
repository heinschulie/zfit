using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanWorkoutCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private FanWorkoutFilter _fanWorkoutFilter = new FanWorkoutFilter();
        private List<FanWorkout> _fanWorkoutList = new List<FanWorkout>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FanWorkoutCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FanWorkoutCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="FanWorkout"/> list.
        /// </summary>
        /// <value>
        /// The FanWorkout list.
        /// </value>
        public FanWorkoutFilter FanWorkoutFilter
        {
            get { return _fanWorkoutFilter; }
            set { _fanWorkoutFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="FanWorkout"/> list.
        /// </summary>
        /// <value>
        /// The FanWorkout list.
        /// </value>
        public List<FanWorkout> FanWorkoutList
        {
            get { return _fanWorkoutList; }
            set { _fanWorkoutList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FanWorkoutCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanWorkoutCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FanWorkoutCollection");
            }

            _isFiltered = (aSource as FanWorkoutCollection)._isFiltered;
            _fanWorkoutFilter = (aSource as FanWorkoutCollection)._fanWorkoutFilter;
            _fanWorkoutList.Clear();
            foreach (FanWorkout vFanWorkoutSource in (aSource as FanWorkoutCollection)._fanWorkoutList)
            {
                FanWorkout vFanWorkoutTarget = new FanWorkout();
                vFanWorkoutTarget.AssignFromSource(vFanWorkoutSource);
                _fanWorkoutList.Add(vFanWorkoutTarget);
            }
        }

        #endregion
    }
}
