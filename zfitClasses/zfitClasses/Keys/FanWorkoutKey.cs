using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanWorkoutKey : Zephob
    {
        #region Fields

        private int _wrtKey;
        private int _fanKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="WrtlType"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="WrtlType"/> key.
        /// </value>
        public int WrtKey
        {
            get { return _wrtKey; }
            set { _wrtKey = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Fan"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Fan"/> key.
        /// </value>
        public int FanKey
        {
            get { return _fanKey; }
            set { _fanKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanKey"/> class.
        /// </summary>
        public FanWorkoutKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanWorkoutKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFanKey">A Fan key.</param>
        public FanWorkoutKey(int aWrtlKey, int aFanKey)
        {
            _wrtKey = aWrtlKey; 
            _fanKey = aFanKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FanWorkoutKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FanWorkoutKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFanKey1">Key 1.</param>
            /// <param name="aFanKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FanWorkoutKey aFanWorkoutKey1, FanWorkoutKey aFanWorkoutKey2)
            {
                return aFanWorkoutKey1._fanKey == aFanWorkoutKey2._fanKey && aFanWorkoutKey1._wrtKey == aFanWorkoutKey2._wrtKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFanWorkoutKey">A FanWorkoutKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FanWorkoutKey aFanWorkoutKey)
            {
                return Convert.ToInt32(aFanWorkoutKey._fanKey) ^
                       Convert.ToInt32(aFanWorkoutKey._wrtKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanWorkoutKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanWorkoutKey))
            {
                throw new ArgumentException("Invalid assignment source", "FanWorkoutKey");
            }
            _wrtKey = (aSource as FanWorkoutKey)._wrtKey;
            _fanKey = (aSource as FanWorkoutKey)._fanKey;
        }

        #endregion
    }
}
