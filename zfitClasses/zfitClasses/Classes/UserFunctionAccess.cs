using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    /// <summary>
    /// A specific functional access for a specific user.
    /// </summary>
    public class UserFunctionAccess : UserKey
    {
        #region Fields

        private FunctionAccess _functionAccess = new FunctionAccess();
        #endregion

        #region Properties
        
        /// <summary>
        /// Gets or sets the access map.
        /// </summary>
        /// <value>
        /// The access map.
        /// </value>
        public FunctionAccess FunctionAccess
        {
            get { return _functionAccess; }
            set { _functionAccess = value; }
        }
        #endregion

        /// <summary>
        /// Assigns all <c>aSource</c> UserFunctionAccess's properties to this instance of <see cref="UserFunctionAccess"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is UserFunctionAccess))
            {
                throw new ArgumentException("Invalid Source Argument to FunctionAccess Assign");
            }

            base.AssignFromSource(aSource);
            _functionAccess.AssignFromSource((aSource as UserFunctionAccess)._functionAccess);
        }
    }
}
