using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace zfit
{
    public class UserKey : Zephob
    {        
        #region Fields

        private int _usrKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="UserType"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="UserType"/> key.
        /// </value>
        public int UsrKey
        {
            get { return _usrKey; }
            set { _usrKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="UserKey"/> class.
        /// </summary>
        public UserKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="UserKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aUsrKey">A User key.</param>
        public UserKey( int aUsrKey)
        {
            _usrKey = aUsrKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for UserKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<UserKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aUserKey1">Key 1.</param>
            /// <param name="aUserKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(UserKey aUserKey1, UserKey aUserKey2)
            {
                return aUserKey1._usrKey == aUserKey2._usrKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aUserKey">A UserKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(UserKey aUserKey)
            {
                return Convert.ToInt32(aUserKey._usrKey);
            }
        }

        #endregion

        #region AssignFromAlternateSource

        public void AssignFromAlternateSource(object aAlternateSource, List<Type> aAlternateTypeDescriptorList)
        {
            if (!(aAlternateTypeDescriptorList.Contains(aAlternateSource.GetType())))
            {
                throw new ArgumentException("Invalid assignment source", string.Format("{0}", aAlternateSource.GetType()));
            }
            _usrKey = (int)aAlternateSource.GetType().GetProperty("UsrKey").GetValue(aAlternateSource, null);
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="User"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is UserKey))
            {
                throw new ArgumentException("Invalid assignment source", "UserKey");
            }
            _usrKey = (aSource as UserKey)._usrKey;
        }

        #endregion
    }
}
