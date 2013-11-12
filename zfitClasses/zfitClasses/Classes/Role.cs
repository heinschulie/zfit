using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// Role class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class Role : RoleKey
    {
        #region Fields

        private string _rolName;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Role"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Role"/> name.
        /// </value>
        public string RolName
        {
            get { return _rolName; }
            set { _rolName = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Role"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Role))
            {
                throw new ArgumentException("Invalid Source Argument to Role Assign");
            }
            base.AssignFromSource(aSource);
            _rolName = (aSource as Role)._rolName;
        }

        #endregion
    }
 }