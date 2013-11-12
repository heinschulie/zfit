using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FanRoleCollection class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class FanRoleCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private int _fanKeyFilter;
        private List<FanRole> _fanRoleList = new List<FanRole>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FanRoleCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FanRoleCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }
        /// <summary>
        ///   Gets or sets the <c>FanKeyFilter</c>.
        /// </summary>
        /// <value>
        ///   The <c>FanKeyFilter</c>.
        /// </value>
        public int FanKeyFilter
        {
            get { return _fanKeyFilter; }
            set { _fanKeyFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="FanRole"/> list.
        /// </summary>
        /// <value>
        /// The FanRole list.
        /// </value>
        public List<FanRole> FanRoleList
        {
            get { return _fanRoleList; }
            set { _fanRoleList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FanRoleCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanRoleCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FanRoleCollection");
            }

            _isFiltered = (aSource as FanRoleCollection)._isFiltered;
            _fanKeyFilter = (aSource as FanRoleCollection)._fanKeyFilter;
            _fanRoleList.Clear();
            foreach (FanRole vFanRoleSource in (aSource as FanRoleCollection)._fanRoleList)
            {
                FanRole vFanRoleTarget = new FanRole();
                vFanRoleTarget.AssignFromSource(vFanRoleSource);
                _fanRoleList.Add(vFanRoleTarget);
            }
        }

        #endregion
    }
}