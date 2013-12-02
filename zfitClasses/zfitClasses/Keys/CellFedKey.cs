using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class CellFedKey : Zephob
    {
        #region Fields

        private int _celKey;
        private int _fedKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="CellType"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="CellType"/> key.
        /// </value>
        public int CelKey
        {
            get { return _celKey; }
            set { _celKey = value; }
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
        public CellFedKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CellFedKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFedKey">A Fed key.</param>
        public CellFedKey(int aCellKey, int aFedKey)
        {
            _celKey = aCellKey; 
            _fedKey = aFedKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for CellFedKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<CellFedKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFedKey1">Key 1.</param>
            /// <param name="aFedKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(CellFedKey aCellFedKey1, CellFedKey aCellFedKey2)
            {
                return aCellFedKey1._fedKey == aCellFedKey2._fedKey && aCellFedKey1._celKey == aCellFedKey2._celKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aCellFedKey">A CellFedKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(CellFedKey aCellFedKey)
            {
                return Convert.ToInt32(aCellFedKey._fedKey) ^
                       Convert.ToInt32(aCellFedKey._celKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="CellFedKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFedKey))
            {
                throw new ArgumentException("Invalid assignment source", "CellFedKey");
            }
            _celKey = (aSource as CellFedKey)._celKey;
            _fedKey = (aSource as CellFedKey)._fedKey;
        }

        #endregion
    }
}
