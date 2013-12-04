using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanSessionKey : Zephob
    {
        #region Fields

        private int _wrtKey;
        private int _fanKey;
        private int _fssKey;

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

        /// <summary>
        ///   Gets or sets the <see cref="FanSession"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="FanSession"/> key.
        /// </value>
        public int FssKey
        {
            get { return _fssKey; }
            set { _fssKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanKey"/> class.
        /// </summary>
        public FanSessionKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanSessionKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFanKey">A FanSession key.</param>
        public FanSessionKey(int aWrtlKey, int aFanKey, int aFssKey)
        {
            _wrtKey = aWrtlKey;
            _fanKey = aFanKey;
            _fssKey = aFssKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FanSessionKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FanSessionKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFanKey1">Key 1.</param>
            /// <param name="aFanKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FanSessionKey aFanSessionKey1, FanSessionKey aFanSessionKey2)
            {
                return (aFanSessionKey1._fanKey == aFanSessionKey2._fanKey && aFanSessionKey1._wrtKey == aFanSessionKey2._wrtKey) && aFanSessionKey1.FssKey == aFanSessionKey2.FssKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFanSessionKey">A FanSessionKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FanSessionKey aFanSessionKey)
            {
                return Convert.ToInt32(aFanSessionKey._fanKey) ^
                       Convert.ToInt32(aFanSessionKey._wrtKey) ^
                       Convert.ToInt32(aFanSessionKey._fssKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanSessionKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanSessionKey))
            {
                throw new ArgumentException("Invalid assignment source", "FanSessionKey");
            }
            _wrtKey = (aSource as FanSessionKey)._wrtKey;
            _fanKey = (aSource as FanSessionKey)._fanKey;
            _fssKey = (aSource as FanSessionKey)._fssKey;
        }

        #endregion
    }
}
