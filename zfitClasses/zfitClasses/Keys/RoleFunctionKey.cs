using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   RoleFunctionKey class.
    /// </summary>
    /// <remarks>
    ///   namespace Lookfor
    /// </remarks>
    public class RoleFunctionKey : Zephob
    {
        #region Fields

        private int _rolKey;
        private int _fncKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Role"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Role"/> key.
        /// </value>
        public int RolKey
        {
            get { return _rolKey; }
            set { _rolKey = value; }
        }
        /// <summary>
        ///   Gets or sets the <see cref="Function"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Function"/> key.
        /// </value>
        public int FncKey
        {
            get { return _fncKey; }
            set { _fncKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="RoleFunctionKey"/> class.
        /// </summary>
        public RoleFunctionKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="RoleFunctionKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aRolKey">A Role key.</param>
        /// <param name="aFncKey">A Function key.</param>
        public RoleFunctionKey( int aRolKey,  int aFncKey)
        {
            _rolKey = aRolKey;
            _fncKey = aFncKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for RoleFunctionKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<RoleFunctionKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aRoleFunctionKey1">Key 1.</param>
            /// <param name="aRoleFunctionKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(RoleFunctionKey aRoleFunctionKey1, RoleFunctionKey aRoleFunctionKey2)
            {
                return aRoleFunctionKey1._rolKey == aRoleFunctionKey2._rolKey &&
                       aRoleFunctionKey1._fncKey == aRoleFunctionKey2._fncKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aRoleFunctionKey">A RoleFunctionKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(RoleFunctionKey aRoleFunctionKey)
            {
                return Convert.ToInt32(aRoleFunctionKey._rolKey) ^
                       Convert.ToInt32(aRoleFunctionKey._fncKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="RoleFunction"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is RoleFunctionKey))
            {
                throw new ArgumentException("Invalid assignment source", "RoleFunctionKey");
            }
            _rolKey = (aSource as RoleFunctionKey)._rolKey;
            _fncKey = (aSource as RoleFunctionKey)._fncKey;
        }

        #endregion
    }
 }