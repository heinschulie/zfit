using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   UserRoleKey class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class UserRoleKey : Zephob
    {
        #region Fields

        private int _usrKey;
        private int _rolkey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="User"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="User"/> key.
        /// </value>
        public int UsrKey
        {
            get { return _usrKey; }
            set { _usrKey = value; }
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
        ///   Initializes a new instance of the <see cref="UserRoleKey"/> class.
        /// </summary>
        public UserRoleKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="UserRoleKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aUsrKey">A User key.</param>
        /// <param name="aRolkey">A Role key.</param>
        public UserRoleKey( int aUsrKey,  int aRolkey)
        {
            _usrKey = aUsrKey;
            _rolkey = aRolkey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for UserRoleKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<UserRoleKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aUserRoleKey1">Key 1.</param>
            /// <param name="aUserRoleKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(UserRoleKey aUserRoleKey1, UserRoleKey aUserRoleKey2)
            {
                return aUserRoleKey1._usrKey == aUserRoleKey2._usrKey &&
                       aUserRoleKey1._rolkey == aUserRoleKey2._rolkey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aUserRoleKey">A UserRoleKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(UserRoleKey aUserRoleKey)
            {
                return Convert.ToInt32(aUserRoleKey._usrKey) ^
                       Convert.ToInt32(aUserRoleKey._rolkey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="UserRole"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is UserRoleKey))
            {
                throw new ArgumentException("Invalid assignment source", "UserRoleKey");
            }
            _usrKey = (aSource as UserRoleKey)._usrKey;
            _rolkey = (aSource as UserRoleKey)._rolkey;
        }

        #endregion
    }
 }