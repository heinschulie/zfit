using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace zfit
{
    public class FanKey : Zephob
    {        
        #region Fields

        private int _fanKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="FanType"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="FanType"/> key.
        /// </value>
        public int FannKey
        {
            get { return _fanKey; }
            set { _fanKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanKey"/> class.
        /// </summary>
        public FanKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFanKey">A Fan key.</param>
        public FanKey( int aFanKey)
        {
            _fanKey = aFanKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FanKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FanKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFanKey1">Key 1.</param>
            /// <param name="aFanKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FanKey aFanKey1, FanKey aFanKey2)
            {
                return aFanKey1._fanKey == aFanKey2._fanKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFanKey">A FanKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FanKey aFanKey)
            {
                return Convert.ToInt32(aFanKey._fanKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Fan"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanKey))
            {
                throw new ArgumentException("Invalid assignment source", "FanKey");
            }
            _fanKey = (aSource as FanKey)._fanKey;
        }

        #endregion
    }
}
