using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class ActivityKey : Zephob
    {
        #region Fields

        private int _excKey;
        private int _wrtKey;
        private int _actKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="CellType"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="CellType"/> key.
        /// </value>
        public int ExcKey
        {
            get { return _excKey; }
            set { _excKey = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Wrt"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Wrt"/> key.
        /// </value>
        public int WrtKey
        {
            get { return _wrtKey; }
            set { _wrtKey = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Act"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Act"/> key.
        /// </value>
        public int ActKey
        {
            get { return _actKey; }
            set { _actKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="WrtKey"/> class.
        /// </summary>
        public ActivityKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ActivityKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aWrtKey">A Wrt key.</param>
        public ActivityKey(int aCellKey, int aWrtKey, int aActKey)
        {
            _excKey = aCellKey;
            _wrtKey = aWrtKey;
            _actKey = aActKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for ActivityKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<ActivityKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aWrtKey1">Key 1.</param>
            /// <param name="aWrtKey2">Key 2.</param>
            /// <param name="aWrtKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(ActivityKey aActivityKey1, ActivityKey aActivityKey2)
            {
                return (aActivityKey1._wrtKey == aActivityKey2._wrtKey && aActivityKey1._excKey == aActivityKey2._excKey) && aActivityKey1._actKey == aActivityKey2._actKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aActivityKey">A ActivityKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(ActivityKey aActivityKey)
            {
                return Convert.ToInt32(aActivityKey._wrtKey) ^
                       Convert.ToInt32(aActivityKey._excKey) ^
                       Convert.ToInt32(aActivityKey._actKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="ActivityKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ActivityKey))
            {
                throw new ArgumentException("Invalid assignment source", "ActivityKey");
            }
            _excKey = (aSource as ActivityKey)._excKey;
            _wrtKey = (aSource as ActivityKey)._wrtKey;
            _actKey = (aSource as ActivityKey)._actKey;
        }

        #endregion
    }
}
