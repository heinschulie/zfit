using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class ExerciseKey : Zephob
    {
        #region Fields

        private int _excKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Exc"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Exc"/> key.
        /// </value>
        public int ExcKey
        {
            get { return _excKey; }
            set { _excKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ExerciseKey"/> class.
        /// </summary>
        public ExerciseKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ExerciseKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aExerciseKey">A Exc key.</param>
        public ExerciseKey( int aExerciseKey)
        {
            _excKey = aExerciseKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for ExerciseKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<ExerciseKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aExerciseKey1">Key 1.</param>
            /// <param name="aExerciseKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(ExerciseKey aExerciseKey1, ExerciseKey aExerciseKey2)
            {
                return aExerciseKey1._excKey == aExerciseKey2._excKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aExerciseKey">A ExerciseKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(ExerciseKey aExerciseKey)
            {
                return Convert.ToInt32(aExerciseKey._excKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Exc"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ExerciseKey))
            {
                throw new ArgumentException("Invalid assignment source", "ExerciseKey");
            }
            _excKey = (aSource as ExerciseKey)._excKey;
        }

        #endregion
    }
}
