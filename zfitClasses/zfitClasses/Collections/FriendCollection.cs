using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FriendCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private FriendFilter _friendFilter = new FriendFilter();
        private List<Friend> _friendList = new List<Friend>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FriendCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FriendCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Friend"/> list.
        /// </summary>
        /// <value>
        /// The Friend list.
        /// </value>
        public FriendFilter FriendFilter
        {
            get { return _friendFilter; }
            set { _friendFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Friend"/> list.
        /// </summary>
        /// <value>
        /// The Friend list.
        /// </value>
        public List<Friend> FriendList
        {
            get { return _friendList; }
            set { _friendList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FriendCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FriendCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FriendCollection");
            }

            _isFiltered = (aSource as FriendCollection)._isFiltered;
            _friendFilter = (aSource as FriendCollection)._friendFilter;
            _friendList.Clear();
            foreach (Friend vFriendSource in (aSource as FriendCollection)._friendList)
            {
                Friend vFriendTarget = new Friend();
                vFriendTarget.AssignFromSource(vFriendSource);
                _friendList.Add(vFriendTarget);
            }
        }

        #endregion
    }
}
