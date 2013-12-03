using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class ExerciseCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private ExerciseFilter _exerciseFilter = new ExerciseFilter();
        private List<Exercise> _exerciseList = new List<Exercise>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="ExerciseCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="ExerciseCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Exercise"/> list.
        /// </summary>
        /// <value>
        /// The Exercise list.
        /// </value>
        public ExerciseFilter ExerciseFilter
        {
            get { return _exerciseFilter; }
            set { _exerciseFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Exercise"/> list.
        /// </summary>
        /// <value>
        /// The Exercise list.
        /// </value>
        public List<Exercise> ExerciseList
        {
            get { return _exerciseList; }
            set { _exerciseList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="ExerciseCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ExerciseCollection))
            {
                throw new ArgumentException("Invalid assignment source", "ExerciseCollection");
            }

            _isFiltered = (aSource as ExerciseCollection)._isFiltered;
            _exerciseFilter = (aSource as ExerciseCollection)._exerciseFilter;
            _exerciseList.Clear();
            foreach (Exercise vExerciseSource in (aSource as ExerciseCollection)._exerciseList)
            {
                Exercise vExerciseTarget = new Exercise();
                vExerciseTarget.AssignFromSource(vExerciseSource);
                _exerciseList.Add(vExerciseTarget);
            }
        }

        #endregion
    }
}
