using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanSessionActivityKey : Zephob
    {
        #region Fields

        private int _wrtKey;
        private int _fanKey;
        private int _fssKey;
        private int _excKey;
        private int _actKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="WrtlType"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="WrtlType"/> key.
        /// </value>
        public int WrtKey
        {
            get { return _wrtKey; }
            set { _wrtKey = value; }
        }
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
        ///   Gets or sets the <see cref="FanSessionActivity"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="FanSessionActivity"/> key.
        /// </value>
        public int FssKey
        {
            get { return _fssKey; }
            set { _fssKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanKey"/> class.
        /// </summary>
        public FanSessionActivityKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FanSessionActivityKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFanKey">A FanSessionActivity key.</param>
        public FanSessionActivityKey(int aWrtlKey, int aFanKey, int aFssKey, int aExcKey, int aActKey)
        {
            _wrtKey = aWrtlKey;
            _fanKey = aFanKey;
            _fssKey = aFssKey;
            _excKey = aExcKey;
            _actKey = aActKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FanSessionActivityKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FanSessionActivityKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFanKey1">Key 1.</param>
            /// <param name="aFanKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FanSessionActivityKey aFanSessionActivityKey1, FanSessionActivityKey aFanSessionActivityKey2)
            {
                return  aFanSessionActivityKey1._fanKey == aFanSessionActivityKey2._fanKey && 
                        aFanSessionActivityKey1._wrtKey == aFanSessionActivityKey2._wrtKey && 
                        aFanSessionActivityKey1._fssKey == aFanSessionActivityKey2._fssKey &&
                        aFanSessionActivityKey1._actKey == aFanSessionActivityKey2._actKey &&
                        aFanSessionActivityKey1._excKey == aFanSessionActivityKey2._excKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFanSessionActivityKey">A FanSessionActivityKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FanSessionActivityKey aFanSessionActivityKey)
            {
                return Convert.ToInt32(aFanSessionActivityKey._fanKey) ^
                       Convert.ToInt32(aFanSessionActivityKey._wrtKey) ^
                       Convert.ToInt32(aFanSessionActivityKey._actKey) ^
                       Convert.ToInt32(aFanSessionActivityKey._excKey) ^
                       Convert.ToInt32(aFanSessionActivityKey._fssKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanSessionActivityKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanSessionActivityKey))
            {
                throw new ArgumentException("Invalid assignment source", "FanSessionActivityKey");
            }
            _wrtKey = (aSource as FanSessionActivityKey)._wrtKey;
            _fanKey = (aSource as FanSessionActivityKey)._fanKey;
            _fssKey = (aSource as FanSessionActivityKey)._fssKey;
            _fssKey = (aSource as FanSessionActivityKey)._excKey;
            _fssKey = (aSource as FanSessionActivityKey)._actKey;
        }

        #endregion
    }
}
