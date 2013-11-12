using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FunctionKey class.
    /// </summary>
    /// <remarks>
    ///   namespace Lookfor
    /// </remarks>
    public class FunctionKey : Zephob
    {
        #region Fields

        private int _fncKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Function"/> key.
        /// </summary>
        /// <value>
        ///   <see cref="Function"/> key.
        /// </value>
        public int FncKey
        {
            get { return _fncKey; }
            set { _fncKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="FunctionKey"/> class.
        /// </summary>
        public FunctionKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="FunctionKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aFncKey">A Function key.</param>
        public FunctionKey( int aFncKey)
        {
            _fncKey = aFncKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for FunctionKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<FunctionKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aFunctionKey1">Key 1.</param>
            /// <param name="aFunctionKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(FunctionKey aFunctionKey1, FunctionKey aFunctionKey2)
            {
                return aFunctionKey1._fncKey == aFunctionKey2._fncKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aFunctionKey">A FunctionKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(FunctionKey aFunctionKey)
            {
                return Convert.ToInt32(aFunctionKey._fncKey);
            }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Function"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FunctionKey))
            {
                throw new ArgumentException("Invalid assignment source", "FunctionKey");
            }
            _fncKey = (aSource as FunctionKey)._fncKey;
        }

        #endregion
    }
 }