using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class CellFedCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private CellFedFilter _cellFedFilter;
        private List<CellFed> _cellFedList = new List<CellFed>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="CellFedCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="CellFedCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="CellFed"/> list.
        /// </summary>
        /// <value>
        /// The CellFed list.
        /// </value>
        public CellFedFilter CellFedFilter
        {
            get { return _cellFedFilter; }
            set { _cellFedFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="CellFed"/> list.
        /// </summary>
        /// <value>
        /// The CellFed list.
        /// </value>
        public List<CellFed> CellFedList
        {
            get { return _cellFedList; }
            set { _cellFedList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="CellFedCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFedCollection))
            {
                throw new ArgumentException("Invalid assignment source", "CellFedCollection");
            }

            _isFiltered = (aSource as CellFedCollection)._isFiltered;
            _cellFedFilter = (aSource as CellFedCollection)._cellFedFilter;
            _cellFedList.Clear();
            foreach (CellFed vCellFedSource in (aSource as CellFedCollection)._cellFedList)
            {
                CellFed vCellFedTarget = new CellFed();
                vCellFedTarget.AssignFromSource(vCellFedSource);
                _cellFedList.Add(vCellFedTarget);
            }
        }

        #endregion
    }
}
