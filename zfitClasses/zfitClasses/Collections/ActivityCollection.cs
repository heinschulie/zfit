using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class ActivityCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private ActivityFilter _activityFilter = new ActivityFilter();
        private List<Activity> _activityList = new List<Activity>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="ActivityCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="ActivityCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Activity"/> list.
        /// </summary>
        /// <value>
        /// The Activity list.
        /// </value>
        public ActivityFilter ActivityFilter
        {
            get { return _activityFilter; }
            set { _activityFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Activity"/> list.
        /// </summary>
        /// <value>
        /// The Activity list.
        /// </value>
        public List<Activity> ActivityList
        {
            get { return _activityList; }
            set { _activityList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="ActivityCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ActivityCollection))
            {
                throw new ArgumentException("Invalid assignment source", "ActivityCollection");
            }

            _isFiltered = (aSource as ActivityCollection)._isFiltered;
            _activityFilter = (aSource as ActivityCollection)._activityFilter;
            _activityList.Clear();
            foreach (Activity vActivitySource in (aSource as ActivityCollection)._activityList)
            {
                Activity vActivityTarget = new Activity();
                vActivityTarget.AssignFromSource(vActivitySource);
                _activityList.Add(vActivityTarget);
            }
        }

        #endregion
    }
}
