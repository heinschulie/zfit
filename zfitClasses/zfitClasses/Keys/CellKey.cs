using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class CellKey : Zephob
    { 
        #region Fields

        private int _celKey;

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

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="CellKey"/> class.
        /// </summary>
        public CellKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="CellKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aCellKey">A Cell key.</param>
        public CellKey( int aCellKey)
        {
            _celKey = aCellKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for CellKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<CellKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aCellKey1">Key 1.</param>
            /// <param name="aCellKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(CellKey aCellKey1, CellKey aCellKey2)
            {
                return aCellKey1._celKey == aCellKey2._celKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aCellKey">A CellKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(CellKey aCellKey)
            {
                return Convert.ToInt32(aCellKey._celKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Cell"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellKey))
            {
                throw new ArgumentException("Invalid assignment source", "CellKey");
            }
            _celKey = (aSource as CellKey)._celKey;
        }

        #endregion
    }
}