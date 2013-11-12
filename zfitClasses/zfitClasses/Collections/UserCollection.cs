using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   UserCollection class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class UserCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;

        private List<User> _userList = new List<User>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="UserCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="UserCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="User"/> list.
        /// </summary>
        /// <value>
        /// The User list.
        /// </value>
        public List<User> UserList
        {
            get { return _userList; }
            set { _userList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="UserCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is UserCollection))
            {
                throw new ArgumentException("Invalid assignment source", "UserCollection");
            }

            _isFiltered = (aSource as UserCollection)._isFiltered;

            _userList.Clear();
            foreach (User vUserSource in (aSource as UserCollection)._userList)
            {
                User vUserTarget = new User();
                vUserTarget.AssignFromSource(vUserSource);
                _userList.Add(vUserTarget);
            }
        }

        #endregion
    }
}