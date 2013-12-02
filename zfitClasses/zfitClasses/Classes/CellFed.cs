using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class CellFed : CellFedKey
    {
        #region Fields

        private string _cellName;
        private string _fedName;
        private DateTime _cellfedDatejoined;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string CellName
        {
            get { return _cellName; }
            set { _cellName = value; }
        }
        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string FedName
        {
            get { return _fedName; }
            set { _fedName = value; }
        }
        /// <summary>
        ///   Gets or sets the CellfedDatejoined property;
        /// </summary>
        /// <value>
        ///   The CellFedDateJoined;
        /// </value>
        public DateTime CellFedDateJoined
        {
            get { return _cellfedDatejoined; }
            set { _cellfedDatejoined = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="CellFed"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFed))
            {
                throw new ArgumentException("Invalid Source Argument to CellFed Assign");
            }
            base.AssignFromSource(aSource);
            _cellName = (aSource as CellFed)._cellName;
            _fedName = (aSource as CellFed)._fedName;
            _cellfedDatejoined = (aSource as CellFed)._cellfedDatejoined;
        }

        #endregion
    }
}
