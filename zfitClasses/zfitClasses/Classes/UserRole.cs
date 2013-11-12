using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// UserRole class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class UserRole : UserRoleKey
    {
        #region Fields

        private string _usrDisplayName;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="User"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="User"/> name.
        /// </value>
        public string UsrDisplayName
        {
            get { return _usrDisplayName; }
            set { _usrDisplayName = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="UserRole"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is UserRole))
            {
                throw new ArgumentException("Invalid Source Argument to UserRole Assign");
            }
            base.AssignFromSource(aSource);
            _usrDisplayName = (aSource as UserRole)._usrDisplayName;
        }

        #endregion
    }
 }