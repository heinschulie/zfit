using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class CellFan : CellFanKey
    {
        #region Fields

        private string _cellName;
        private string _fanName;
        private string _fanSurname;
        private DateTime _cellfanDatejoined;

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
        public string FanName
        {
            get { return _fanName; }
            set { _fanName = value; }
        }
        /// <summary>
        ///   Gets or sets the Surname property;
        /// </summary>
        /// <value>
        ///   The Surname;
        /// </value>
        public string FanSurname
        {
            get { return _fanSurname; }
            set { _fanSurname = value; }
        }
        /// <summary>
        ///   Gets or sets the Fan Display name.
        /// </summary>
        /// <value>
        ///   The Fan Display name.
        /// </value>
        public string FanDisplayName
        {
            get { return String.Format("{0} {1}", _fanName, _fanSurname); }
        }
        /// <summary>
        ///   Gets or sets the CellfanDatejoined property;
        /// </summary>
        /// <value>
        ///   The CellFanDateJoined;
        /// </value>
        public DateTime CellFanDateJoined
        {
            get { return _cellfanDatejoined; }
            set { _cellfanDatejoined = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="CellFan"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is CellFan))
            {
                throw new ArgumentException("Invalid Source Argument to CellFan Assign");
            }
            base.AssignFromSource(aSource);
            _cellName = (aSource as CellFan)._cellName;
            _fanName = (aSource as CellFan)._fanName;
            _fanSurname = (aSource as CellFan)._fanSurname;
            _cellfanDatejoined = (aSource as CellFan)._cellfanDatejoined;
        }

        #endregion
    }
}
