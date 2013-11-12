using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// Function class.
    /// </summary>
    /// <remarks>
    ///   namespace Lookfor
    /// </remarks>
    public class Function : FunctionKey
    {
        #region Fields

        private string _fncCode;
        private string _fncName;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the Code property;
        /// </summary>
        /// <value>
        ///   The Code;
        /// </value>
        public string FncCode
        {
            get { return _fncCode; }
            set { _fncCode = value; }
        }
        /// <summary>
        ///   Gets or sets the <see cref="Function"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Function"/> name.
        /// </value>
        public string FncName
        {
            get { return _fncName; }
            set { _fncName = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Function"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Function))
            {
                throw new ArgumentException("Invalid Source Argument to Function Assign");
            }
            base.AssignFromSource(aSource);
            _fncCode = (aSource as Function)._fncCode;
            _fncName = (aSource as Function)._fncName;
        }

        #endregion
    }
 }