using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanSessionActivityCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private FanSessionActivityFilter _fanSessionActivityFilter = new FanSessionActivityFilter();
        private List<FanSessionActivity> _fanSessionActivityList = new List<FanSessionActivity>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FanSessionActivityCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FanSessionActivityCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="FanSessionActivity"/> list.
        /// </summary>
        /// <value>
        /// The FanSessionActivity list.
        /// </value>
        public FanSessionActivityFilter FanSessionActivityFilter
        {
            get { return _fanSessionActivityFilter; }
            set { _fanSessionActivityFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="FanSessionActivity"/> list.
        /// </summary>
        /// <value>
        /// The FanSessionActivity list.
        /// </value>
        public List<FanSessionActivity> FanSessionActivityList
        {
            get { return _fanSessionActivityList; }
            set { _fanSessionActivityList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FanSessionActivityCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanSessionActivityCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FanSessionActivityCollection");
            }

            _isFiltered = (aSource as FanSessionActivityCollection)._isFiltered;
            _fanSessionActivityFilter = (aSource as FanSessionActivityCollection)._fanSessionActivityFilter;
            _fanSessionActivityList.Clear();
            foreach (FanSessionActivity vFanSessionActivitySource in (aSource as FanSessionActivityCollection)._fanSessionActivityList)
            {
                FanSessionActivity vFanSessionActivityTarget = new FanSessionActivity();
                vFanSessionActivityTarget.AssignFromSource(vFanSessionActivitySource);
                _fanSessionActivityList.Add(vFanSessionActivityTarget);
            }
        }

        #endregion
    }
}
