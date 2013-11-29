using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class CellFanKey : Zephob
    {
        #region Fields

        private int _celKey;
        private int _fanKey;

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
        public CellFanKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CellFanKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFanKey">A Fan key.</param>
        public CellFanKey(int aCellKey, int aFanKey)
        {
            _celKey = aCellKey; 
            _fanKey = aFanKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for CellFanKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<CellFanKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFanKey1">Key 1.</param>
            /// <param name="aFanKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(CellFanKey aCellFanKey1, CellFanKey aCellFanKey2)
            {
                return aCellFanKey1._fanKey == aCellFanKey2._fanKey && aCellFanKey1._celKey == aCellFanKey2._celKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aCellFanKey">A CellFanKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(CellFanKey aCellFanKey)
            {
                return Convert.ToInt32(aCellFanKey._fanKey) ^
                       Convert.ToInt32(aCellFanKey._celKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="CellFanKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFanKey))
            {
                throw new ArgumentException("Invalid assignment source", "CellFanKey");
            }
            _celKey = (aSource as CellFanKey)._celKey;
            _fanKey = (aSource as CellFanKey)._fanKey;
        }

        #endregion
    }
}
