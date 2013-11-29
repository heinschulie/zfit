using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    public class CellCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private CellFilter _cellFilter; 
        private List<Cell> _cellList = new List<Cell>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="CellCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="CellCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Cell"/> list.
        /// </summary>
        /// <value>
        /// The Cell list.
        /// </value>
        public CellFilter CellFilter
        {
            get { return _cellFilter; }
            set { _cellFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Cell"/> list.
        /// </summary>
        /// <value>
        /// The Cell list.
        /// </value>
        public List<Cell> CellList
        {
            get { return _cellList; }
            set { _cellList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="CellCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellCollection))
            {
                throw new ArgumentException("Invalid assignment source", "CellCollection");
            }

            _isFiltered = (aSource as CellCollection)._isFiltered;
            _cellFilter = (aSource as CellCollection)._cellFilter;
            _cellList.Clear();
            foreach (Cell vCellSource in (aSource as CellCollection)._cellList)
            {
                Cell vCellTarget = new Cell();
                vCellTarget.AssignFromSource(vCellSource);
                _cellList.Add(vCellTarget);
            }
        }

        #endregion
    }
}
