using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class WorkoutKey : Zephob
    {
        #region Fields

        private int _wrtKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Wrt"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Wrt"/> key.
        /// </value>
        public int WrtKey
        {
            get { return _wrtKey; }
            set { _wrtKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="WorkoutKey"/> class.
        /// </summary>
        public WorkoutKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="WorkoutKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aWorkoutKey">A Wrt key.</param>
        public WorkoutKey( int aWorkoutKey)
        {
            _wrtKey = aWorkoutKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for WorkoutKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<WorkoutKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aWorkoutKey1">Key 1.</param>
            /// <param name="aWorkoutKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(WorkoutKey aWorkoutKey1, WorkoutKey aWorkoutKey2)
            {
                return aWorkoutKey1._wrtKey == aWorkoutKey2._wrtKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aWorkoutKey">A WorkoutKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(WorkoutKey aWorkoutKey)
            {
                return Convert.ToInt32(aWorkoutKey._wrtKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Wrt"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is WorkoutKey))
            {
                throw new ArgumentException("Invalid assignment source", "WorkoutKey");
            }
            _wrtKey = (aSource as WorkoutKey)._wrtKey;
        }

        #endregion
    }
}
