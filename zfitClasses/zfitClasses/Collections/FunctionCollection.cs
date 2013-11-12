using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FunctionCollection class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class FunctionCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;

        private List<Function> _functionList = new List<Function>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FunctionCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FunctionCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Function"/> list.
        /// </summary>
        /// <value>
        /// The Function list.
        /// </value>
        public List<Function> FunctionList
        {
            get { return _functionList; }
            set { _functionList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FunctionCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FunctionCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FunctionCollection");
            }

            _isFiltered = (aSource as FunctionCollection)._isFiltered;

            _functionList.Clear();
            foreach (Function vFunctionSource in (aSource as FunctionCollection)._functionList)
            {
                Function vFunctionTarget = new Function();
                vFunctionTarget.AssignFromSource(vFunctionSource);
                _functionList.Add(vFunctionTarget);
            }
        }

        #endregion
    }
}