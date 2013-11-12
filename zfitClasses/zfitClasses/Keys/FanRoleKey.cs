using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FanRoleKey class.
    /// </summary>
    /// <remarks>
    ///   namespace Lookfor
    /// </remarks>
    public class FanRoleKey : Zephob
    {
        #region Fields

        private int _fanKey;
        private int _rolkey;

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
        ///   Gets or sets the <see cref="Role"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Role"/> key.
        /// </value>
        public int Rolkey
        {
            get { return _rolkey; }
            set { _rolkey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanRoleKey"/> class.
        /// </summary>
        public FanRoleKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanRoleKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFanKey">A Fan key.</param>
        /// <param name="aRolkey">A Role key.</param>
        public FanRoleKey( int aFanKey,  int aRolkey)
        {
            _fanKey = aFanKey;
            _rolkey = aRolkey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FanRoleKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FanRoleKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFanRoleKey1">Key 1.</param>
            /// <param name="aFanRoleKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FanRoleKey aFanRoleKey1, FanRoleKey aFanRoleKey2)
            {
                return aFanRoleKey1._fanKey == aFanRoleKey2._fanKey &&
                       aFanRoleKey1._rolkey == aFanRoleKey2._rolkey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFanRoleKey">A FanRoleKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FanRoleKey aFanRoleKey)
            {
                return Convert.ToInt32(aFanRoleKey._fanKey) ^
                       Convert.ToInt32(aFanRoleKey._rolkey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanRole"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanRoleKey))
            {
                throw new ArgumentException("Invalid assignment source", "FanRoleKey");
            }
            _fanKey = (aSource as FanRoleKey)._fanKey;
            _rolkey = (aSource as FanRoleKey)._rolkey;
        }

        #endregion
    }
 }