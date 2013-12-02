using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FriendKey : Zephob
    {
        #region Fields

        private int _fan1Key;
        private int _fan2Key;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Fan"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Fan"/> key.
        /// </value>
        public int Fan1Key
        {
            get { return _fan1Key; }
            set { _fan1Key = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Fan"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Fan"/> key.
        /// </value>
        public int Fan2Key
        {
            get { return _fan2Key; }
            set { _fan2Key = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="Fan2Key"/> class.
        /// </summary>
        public FriendKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FriendKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFan2Key">A Fan key.</param>
        public FriendKey(int aFan1lKey, int aFan2Key)
        {
            _fan1Key = aFan1lKey; 
            _fan2Key = aFan2Key;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FriendKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FriendKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFan2Key1">Key 1.</param>
            /// <param name="aFan2Key2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FriendKey aFriendKey1, FriendKey aFriendKey2)
            {
                return aFriendKey1._fan2Key == aFriendKey2._fan2Key && aFriendKey1._fan1Key == aFriendKey2._fan1Key;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFriendKey">A FriendKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FriendKey aFriendKey)
            {
                return Convert.ToInt32(aFriendKey._fan2Key) ^
                       Convert.ToInt32(aFriendKey._fan1Key);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FriendKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FriendKey))
            {
                throw new ArgumentException("Invalid assignment source", "FriendKey");
            }
            _fan1Key = (aSource as FriendKey)._fan1Key;
            _fan2Key = (aSource as FriendKey)._fan2Key;
        }

        #endregion
    }
}
