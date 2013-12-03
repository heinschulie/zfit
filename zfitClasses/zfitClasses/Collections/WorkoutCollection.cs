using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class WorkoutCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private WorkoutFilter _workoutFilter = new WorkoutFilter();
        private List<Workout> _workoutList = new List<Workout>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="WorkoutCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="WorkoutCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Workout"/> list.
        /// </summary>
        /// <value>
        /// The Workout list.
        /// </value>
        public WorkoutFilter WorkoutFilter
        {
            get { return _workoutFilter; }
            set { _workoutFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Workout"/> list.
        /// </summary>
        /// <value>
        /// The Workout list.
        /// </value>
        public List<Workout> WorkoutList
        {
            get { return _workoutList; }
            set { _workoutList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="WorkoutCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is WorkoutCollection))
            {
                throw new ArgumentException("Invalid assignment source", "WorkoutCollection");
            }

            _isFiltered = (aSource as WorkoutCollection)._isFiltered;
            _workoutFilter = (aSource as WorkoutCollection)._workoutFilter;
            _workoutList.Clear();
            foreach (Workout vWorkoutSource in (aSource as WorkoutCollection)._workoutList)
            {
                Workout vWorkoutTarget = new Workout();
                vWorkoutTarget.AssignFromSource(vWorkoutSource);
                _workoutList.Add(vWorkoutTarget);
            }
        }

        #endregion
    }
}
