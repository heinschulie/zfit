using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry;

namespace zfit
{
    public class FedCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private FedFilter _fedFilter;
        private List<Fed> _fedList = new List<Fed>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="FedCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="FedCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Fed"/> list.
        /// </summary>
        /// <value>
        /// The Fed list.
        /// </value>
        public FedFilter FedFilter
        {
            get { return _fedFilter; }
            set { _fedFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Fed"/> list.
        /// </summary>
        /// <value>
        /// The Fed list.
        /// </value>
        public List<Fed> FedList
        {
            get { return _fedList; }
            set { _fedList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="FedCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FedCollection))
            {
                throw new ArgumentException("Invalid assignment source", "FedCollection");
            }

            _isFiltered = (aSource as FedCollection)._isFiltered;
            _fedFilter = (aSource as FedCollection)._fedFilter;
            _fedList.Clear();
            foreach (Fed vFedSource in (aSource as FedCollection)._fedList)
            {
                Fed vFedTarget = new Fed();
                vFedTarget.AssignFromSource(vFedSource);
                _fedList.Add(vFedTarget);
            }
        }

        #endregion
    }
}
