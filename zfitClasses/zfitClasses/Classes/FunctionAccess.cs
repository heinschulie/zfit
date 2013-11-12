using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    /// <summary>
    ///  FunctionAccess
    /// </summary>
    public class FunctionAccess : Zephob
    {
        #region Fields
        private string _function;
        private Access _access = new Access();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the access.
        /// </summary>
        /// <value>
        /// The access.
        /// </value>
        public Access Access
        {
            get { return _access; }
            set { _access = value; }
        }
        /// <summary>
        /// Gets or sets the function.
        /// </summary>
        /// <value>
        /// The function.
        /// </value>
        public string Function
        {
            get { return _function; }
            set { _function = value; }
        }
        #endregion

        #region AssignFromSource
        /// <summary>
        /// Assigns the properties of aSource to this instance.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FunctionAccess))
            {
                throw new ArgumentException("Invalid Source Argument to FunctionAccess Assign");
            }
            _function = (aSource as FunctionAccess)._function;
            _access = (aSource as FunctionAccess)._access;
            _access.AccessMap = (aSource as FunctionAccess)._access.AccessMap;
        }
        #endregion

    }
}
