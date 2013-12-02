using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanFedKey : Zephob
    {
        #region Fields

        private int _fanKey;
        private int _fedKey;

        #endregion

        #region Properties

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
        ///   Gets or sets the <see cref="Fed"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Fed"/> key.
        /// </value>
        public int FedKey
        {
            get { return _fedKey; }
            set { _fedKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="FedKey"/> class.
        /// </summary>
        public FanFedKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanFedKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFedKey">A Fed key.</param>
        public FanFedKey(int aCellKey, int aFedKey)
        {
            _fanKey = aCellKey; 
            _fedKey = aFedKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FanFedKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FanFedKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFedKey1">Key 1.</param>
            /// <param name="aFedKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FanFedKey aFanFedKey1, FanFedKey aFanFedKey2)
            {
                return aFanFedKey1._fedKey == aFanFedKey2._fedKey && aFanFedKey1._fanKey == aFanFedKey2._fanKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFanFedKey">A FanFedKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FanFedKey aFanFedKey)
            {
                return Convert.ToInt32(aFanFedKey._fedKey) ^
                       Convert.ToInt32(aFanFedKey._fanKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanFedKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanFedKey))
            {
                throw new ArgumentException("Invalid assignment source", "FanFedKey");
            }
            _fanKey = (aSource as FanFedKey)._fanKey;
            _fedKey = (aSource as FanFedKey)._fedKey;
        }

        #endregion
    }
}
