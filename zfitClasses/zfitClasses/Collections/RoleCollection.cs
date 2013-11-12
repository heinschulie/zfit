using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   RoleCollection class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class RoleCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;

        private List<Role> _roleList = new List<Role>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="RoleCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="RoleCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Role"/> list.
        /// </summary>
        /// <value>
        /// The Role list.
        /// </value>
        public List<Role> RoleList
        {
            get { return _roleList; }
            set { _roleList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="RoleCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is RoleCollection))
            {
                throw new ArgumentException("Invalid assignment source", "RoleCollection");
            }

            _isFiltered = (aSource as RoleCollection)._isFiltered;

            _roleList.Clear();
            foreach (Role vRoleSource in (aSource as RoleCollection)._roleList)
            {
                Role vRoleTarget = new Role();
                vRoleTarget.AssignFromSource(vRoleSource);
                _roleList.Add(vRoleTarget);
            }
        }

        #endregion
    }
}