using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   UserRoleCollection class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class UserRoleCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private int _userKeyFilter;
        private List<UserRole> _userRoleList = new List<UserRole>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="UserRoleCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="UserRoleCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }
        /// <summary>
        ///   Gets or sets the <c>UserKeyFilter</c>.
        /// </summary>
        /// <value>
        ///   The <c>UserKeyFilter</c>.
        /// </value>
        public int UserKeyFilter
        {
            get { return _userKeyFilter; }
            set { _userKeyFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="UserRole"/> list.
        /// </summary>
        /// <value>
        /// The UserRole list.
        /// </value>
        public List<UserRole> UserRoleList
        {
            get { return _userRoleList; }
            set { _userRoleList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="UserRoleCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is UserRoleCollection))
            {
                throw new ArgumentException("Invalid assignment source", "UserRoleCollection");
            }

            _isFiltered = (aSource as UserRoleCollection)._isFiltered;
            _userKeyFilter = (aSource as UserRoleCollection)._userKeyFilter;
            _userRoleList.Clear();
            foreach (UserRole vUserRoleSource in (aSource as UserRoleCollection)._userRoleList)
            {
                UserRole vUserRoleTarget = new UserRole();
                vUserRoleTarget.AssignFromSource(vUserRoleSource);
                _userRoleList.Add(vUserRoleTarget);
            }
        }

        #endregion
    }
}