using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class Cell : CellKey
    {
        #region Fields

        private string _cellName;
        private int _fanKey;
        private string _fanName;
        private byte[] _cellAvatar;

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
        ///   Gets or sets the FanKey property (the owner);
        /// </summary>
        /// <value>
        ///   The Key;
        /// </value>
        public int FanKey
        {
            get { return _fanKey; }
            set { _fanKey = value; }
        }
        /// <summary>
        ///   Gets or sets the Fan Name property;
        /// </summary>
        /// <value>
        ///   The Owner's Name;
        /// </value>
        public string FanName
        {
            get { return _fanName; }
            set { _fanName = value; }
        }

        /// <summary>
        ///   Gets or sets the Avatar property;
        /// </summary>
        /// <value>
        ///   The Avatar;
        /// </value>
        public byte[] CellAvatar
        {
            get { return _cellAvatar; }
            set { _cellAvatar = value; }
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Cell"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Cell))
            {
                throw new ArgumentException("Invalid Source Argument to Cell Assign");
            }
            base.AssignFromSource(aSource);
            _cellName = (aSource as Cell)._cellName;
            FanKey = (aSource as Cell).FanKey;
            _fanName = (aSource as Cell)._fanName;
            _cellAvatar = (aSource as Cell)._cellAvatar;
        }

        #endregion
    }
}
