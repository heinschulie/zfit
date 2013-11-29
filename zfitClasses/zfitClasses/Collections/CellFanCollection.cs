using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class CellFanCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private CellFanFilter _cellFanFilter;
        private List<CellFan> _cellFanList = new List<CellFan>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="CellFanCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="CellFanCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="CellFan"/> list.
        /// </summary>
        /// <value>
        /// The CellFan list.
        /// </value>
        public CellFanFilter CellFanFilter
        {
            get { return _cellFanFilter; }
            set { _cellFanFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="CellFan"/> list.
        /// </summary>
        /// <value>
        /// The CellFan list.
        /// </value>
        public List<CellFan> CellFanList
        {
            get { return _cellFanList; }
            set { _cellFanList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="CellFanCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFanCollection))
            {
                throw new ArgumentException("Invalid assignment source", "CellFanCollection");
            }

            _isFiltered = (aSource as CellFanCollection)._isFiltered;
            _cellFanFilter = (aSource as CellFanCollection)._cellFanFilter;
            _cellFanList.Clear();
            foreach (CellFan vCellFanSource in (aSource as CellFanCollection)._cellFanList)
            {
                CellFan vCellFanTarget = new CellFan();
                vCellFanTarget.AssignFromSource(vCellFanSource);
                _cellFanList.Add(vCellFanTarget);
            }
        }

        #endregion
    }
}
