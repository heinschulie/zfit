using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   FanCollection class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class FanCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;

        private List<Fan> _fanList = new List<Fan>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FanCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FanCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Fan"/> list.
        /// </summary>
        /// <value>
        /// The Fan list.
        /// </value>
        public List<Fan> FanList
        {
            get { return _fanList; }
            set { _fanList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FanCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FanCollection");
            }

            _isFiltered = (aSource as FanCollection)._isFiltered;

            _fanList.Clear();
            foreach (Fan vFanSource in (aSource as FanCollection)._fanList)
            {
                Fan vFanTarget = new Fan();
                vFanTarget.AssignFromSource(vFanSource);
                _fanList.Add(vFanTarget);
            }
        }

        #endregion
    }
}