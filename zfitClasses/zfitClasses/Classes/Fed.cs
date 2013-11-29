using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class Fed : FedKey
    {
        #region Fields

        private string _fedName;
        private int _fanKey;
        private string _fanName;
        private byte[] _fedAvatar;

        #endregion

        #region Properties

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
        public byte[] FedAvatar
        {
            get { return _fedAvatar; }
            set { _fedAvatar = value; }
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Fed"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Fed))
            {
                throw new ArgumentException("Invalid Source Argument to Fed Assign");
            }
            base.AssignFromSource(aSource);
            _fedName = (aSource as Fed)._fedName;
            FanKey = (aSource as Fed).FanKey;
            _fanName = (aSource as Fed)._fanName;
            _fedAvatar = (aSource as Fed)._fedAvatar;
        }

        #endregion
    }
}
