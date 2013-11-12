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

        private string _fanID;
        private string _fanPassword;
        private string _fanName;
        private string _fanSurname;
        private string _fanEmail;
        private string _fanMobile;
        private string _fanPhone;
        private string _fanFax;
        private bool _fanWebContact;
        private string _fanWebTitle;
        private byte[] _fanAvatar;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the ID property;
        /// </summary>
        /// <value>
        ///   The ID;
        /// </value>
        public string FanID
        {
            get { return _fanID; }
            set { _fanID = value; }
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
        ///   Gets or sets the Mobile property;
        /// </summary>
        /// <value>
        ///   The Mobile;
        /// </value>
        public string FanMobile
        {
            get { return _fanMobile; }
            set { _fanMobile = value; }
        }
        /// <summary>
        ///   Gets or sets the Phone property;
        /// </summary>
        /// <value>
        ///   The Phone;
        /// </value>
        public string FanPhone
        {
            get { return _fanPhone; }
            set { _fanPhone = value; }
        }
        /// <summary>
        ///   Gets or sets the Fax property;
        /// </summary>
        /// <value>
        ///   The Fax;
        /// </value>
        public string FanFax
        {
            get { return _fanFax; }
            set { _fanFax = value; }
        }
        /// <summary>
        /// Gets or sets the usr web title.
        /// </summary>
        /// <value>
        /// The usr web title.
        /// </value>
        public string FanWebTitle
        {
            get { return _fanWebTitle; }
            set { _fanWebTitle = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [usr web contact].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [usr web contact]; otherwise, <c>false</c>.
        /// </value>
        public bool FanWebContact
        {
            get { return _fanWebContact; }
            set { _fanWebContact = value; }
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
            _fanID = (aSource as Fan)._fanID;
            _fanPassword = (aSource as Fan)._fanPassword;
            _fanName = (aSource as Fan)._fanName;
            _fanSurname = (aSource as Fan)._fanSurname;
            _fanEmail = (aSource as Fan)._fanEmail;
            _fanMobile = (aSource as Fan)._fanMobile;
            _fanPhone = (aSource as Fan)._fanPhone;
            _fanFax = (aSource as Fan)._fanFax;
            _fanWebContact = (aSource as Fan)._fanWebContact;
            _fanWebTitle = (aSource as Fan)._fanWebTitle;
            _fanAvatar = (aSource as Fan)._fanAvatar;
        } 

#endregion
    }
 }