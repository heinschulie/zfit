using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// Fan class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class Fan : FanKey
    {
        #region Fields

        private string _fanUserID;
        private string _fanPassword;
        private string _fanName;
        private string _fanSurname;
        private string _fanEmail;
        private byte[] _fanAvatar;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the ID property;
        /// </summary>
        /// <value>
        ///   The ID;
        /// </value>
        public string FanUserID
        {
            get { return _fanUserID; }
            set { _fanUserID = value; }
        }
        /// <summary>
        ///   Gets or sets the Password property;
        /// </summary>
        /// <value>
        ///   The Password;
        /// </value>
        public string FanPassword
        {
            get { return _fanPassword; }
            set { _fanPassword = value; }
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
        ///   Gets or sets the Email property;
        /// </summary>
        /// <value>
        ///   The Email;
        /// </value>
        public string FanEmail
        {
            get { return _fanEmail; }
            set { _fanEmail = value; }
        }
        /// <summary>
        ///   Gets or sets the Avatar property;
        /// </summary>
        /// <value>
        ///   The Avatar;
        /// </value>
        public byte[] FanAvatar
        {
            get { return _fanAvatar; }
            set { _fanAvatar = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Fan"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Fan))
            {
                throw new ArgumentException("Invalid Source Argument to Fan Assign");
            }
            base.AssignFromSource(aSource);
            _fanUserID = (aSource as Fan)._fanUserID;
            _fanPassword = (aSource as Fan)._fanPassword;
            _fanName = (aSource as Fan)._fanName;
            _fanSurname = (aSource as Fan)._fanSurname;
            _fanEmail = (aSource as Fan)._fanEmail;
            _fanAvatar = (aSource as Fan)._fanAvatar;
        } 

#endregion
    }
 }