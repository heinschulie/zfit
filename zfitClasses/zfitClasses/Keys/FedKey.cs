using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FedKey : Zephob
    {
        #region Fields

        private int _fedKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="FedType"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="FedType"/> key.
        /// </value>
        public int FeddKey
        {
            get { return _fedKey; }
            set { _fedKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="FedKey"/> class.
        /// </summary>
        public FedKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FedKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFedKey">A Fed key.</param>
        public FedKey( int aFedKey)
        {
            _fedKey = aFedKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FedKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FedKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFedKey1">Key 1.</param>
            /// <param name="aFedKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FedKey aFedKey1, FedKey aFedKey2)
            {
                return aFedKey1._fedKey == aFedKey2._fedKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFedKey">A FedKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FedKey aFedKey)
            {
                return Convert.ToInt32(aFedKey._fedKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Fed"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FedKey))
            {
                throw new ArgumentException("Invalid assignment source", "FedKey");
            }
            _fedKey = (aSource as FedKey)._fedKey;
        }

        #endregion
    }
}
