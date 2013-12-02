using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FanFedCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private FanFedFilter _fanFedFilter;
        private List<FanFed> _fanFedList = new List<FanFed>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FanFedCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FanFedCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="FanFed"/> list.
        /// </summary>
        /// <value>
        /// The FanFed list.
        /// </value>
        public FanFedFilter FanFedFilter
        {
            get { return _fanFedFilter; }
            set { _fanFedFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="FanFed"/> list.
        /// </summary>
        /// <value>
        /// The FanFed list.
        /// </value>
        public List<FanFed> FanFedList
        {
            get { return _fanFedList; }
            set { _fanFedList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FanFedCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanFedCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FanFedCollection");
            }

            _isFiltered = (aSource as FanFedCollection)._isFiltered;
            _fanFedFilter = (aSource as FanFedCollection)._fanFedFilter;
            _fanFedList.Clear();
            foreach (FanFed vFanFedSource in (aSource as FanFedCollection)._fanFedList)
            {
                FanFed vFanFedTarget = new FanFed();
                vFanFedTarget.AssignFromSource(vFanFedSource);
                _fanFedList.Add(vFanFedTarget);
            }
        }

        #endregion
    }
}
