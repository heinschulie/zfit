using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class FanSession : FanSessionKey
    {
        #region Fields

        private string _wrtName;
        private string _fanName;
        private string _fanSurname;
        private string _fssDateDone;
        private int _celKey;
        private string _celName;
        private int _prgKey;
        private string _prgName;
        private bool _fssLock;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string WrtName
        {
            get { return _wrtName; }
            set { _wrtName = value; }
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
        ///   Gets or sets the FanSessionDateDone property;
        /// </summary>
        /// <value>
        ///   The FanSessionDateDone;
        /// </value>
        public string FanSessionDateDone
        {
            get { return _fssDateDone; }
            set { _fssDateDone = value; }
        }

        /// <summary>
        ///   Gets or sets the Key property;
        /// </summary>
        /// <value>
        ///   The Key;
        /// </value>
        public int CelKey
        {
            get { return _celKey; }
            set { _celKey = value; }
        }

        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string CelName
        {
            get { return _celName; }
            set { _celName = value; }
        }

        /// <summary>
        ///   Gets or sets the Key property;
        /// </summary>
        /// <value>
        ///   The Key;
        /// </value>
        public int PrgKey
        {
            get { return _prgKey; }
            set { _prgKey = value; }
        }

        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string PrgName
        {
            get { return _prgName; }
            set { _prgName = value; }
        }

        /// <summary>
        ///   Gets or sets the Lock property;
        /// </summary>
        /// <value>
        ///   The Lock;
        /// </value>
        public bool FssLock
        {
            get { return _fssLock; }
            set { _fssLock = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanSession"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanSession))
            {
                throw new ArgumentException("Invalid Source Argument to FanSession Assign");
            }
            base.AssignFromSource(aSource);
            _wrtName = (aSource as FanSession)._wrtName;
            _fanName = (aSource as FanSession)._fanName;
            _fanSurname = (aSource as FanSession)._fanSurname;
            _fssDateDone = (aSource as FanSession)._fssDateDone;
            _celKey = (aSource as FanSession)._celKey;
            _celName = (aSource as FanSession)._celName;
            _prgKey = (aSource as FanSession)._prgKey;
            _prgName = (aSource as FanSession)._prgName;
            _fssLock = (aSource as FanSession)._fssLock;

        }

        #endregion
    }
}
