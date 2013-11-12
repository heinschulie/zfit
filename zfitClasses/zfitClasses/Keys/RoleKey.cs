using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   RoleKey class.
    /// </summary>
    /// <remarks>
    ///   namespace Lookfor
    /// </remarks>
    public class RoleKey : Zephob
    {
        #region Fields

        private int _rolKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Role"/> key.
        /// </summary>
        /// <value>
        ///   <see cref="Role"/> key.
        /// </value>
        public int RolKey
        {
            get { return _rolKey; }
            set { _rolKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="RoleKey"/> class.
        /// </summary>
        public RoleKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="RoleKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aRolKey">A Role key.</param>
        public RoleKey( int aRolKey)
        {
            _rolKey = aRolKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for RoleKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<RoleKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aRoleKey1">Key 1.</param>
            /// <param name="aRoleKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(RoleKey aRoleKey1, RoleKey aRoleKey2)
            {
                return aRoleKey1._rolKey == aRoleKey2._rolKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aRoleKey">A RoleKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(RoleKey aRoleKey)
            {
                return Convert.ToInt32(aRoleKey._rolKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Role"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is RoleKey))
            {
                throw new ArgumentException("Invalid assignment source", "RoleKey");
            }
            _rolKey = (aSource as RoleKey)._rolKey;
        }

        #endregion
    }
 }