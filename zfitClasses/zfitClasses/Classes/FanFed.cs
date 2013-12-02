using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class FanFed : FanFedKey
    {
        #region Fields

        private string _fanName;
        private string _fedName;
        private string _fanSurname;
        private DateTime _fanfedDatejoined;

        #endregion

        #region Properties

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
        ///   Gets or sets the CellfedDatejoined property;
        /// </summary>
        /// <value>
        ///   The FanFedDateJoined;
        /// </value>
        public DateTime FanFedDateJoined
        {
            get { return _fanfedDatejoined; }
            set { _fanfedDatejoined = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanFed"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanFed))
            {
                throw new ArgumentException("Invalid Source Argument to FanFed Assign");
            }
            base.AssignFromSource(aSource);
            _fanName = (aSource as FanFed)._fanName;
            _fedName = (aSource as FanFed)._fedName;
            _fanfedDatejoined = (aSource as FanFed)._fanfedDatejoined;
        }

        #endregion
    }
}
