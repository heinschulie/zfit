using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanSessionCollection: Zephob
    {
        #region Fields

        private bool _isFiltered;
        private FanSessionFilter _fanSessionFilter = new FanSessionFilter();
        private List<FanSession> _fanSessionList = new List<FanSession>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FanSessionCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FanSessionCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="FanSession"/> list.
        /// </summary>
        /// <value>
        /// The FanSession list.
        /// </value>
        public FanSessionFilter FanSessionFilter
        {
            get { return _fanSessionFilter; }
            set { _fanSessionFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="FanSession"/> list.
        /// </summary>
        /// <value>
        /// The FanSession list.
        /// </value>
        public List<FanSession> FanSessionList
        {
            get { return _fanSessionList; }
            set { _fanSessionList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FanSessionCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanSessionCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FanSessionCollection");
            }

            _isFiltered = (aSource as FanSessionCollection)._isFiltered;
            _fanSessionFilter = (aSource as FanSessionCollection)._fanSessionFilter;
            _fanSessionList.Clear();
            foreach (FanSession vFanSessionSource in (aSource as FanSessionCollection)._fanSessionList)
            {
                FanSession vFanSessionTarget = new FanSession();
                vFanSessionTarget.AssignFromSource(vFanSessionSource);
                _fanSessionList.Add(vFanSessionTarget);
            }
        }

        #endregion
    }
}
