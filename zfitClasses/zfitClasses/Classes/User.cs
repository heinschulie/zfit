using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// User class.
    /// </summary>
    /// <remarks>
    ///   namespace Z2Z
    /// </remarks>
    public class User : UserKey
    {
        #region Fields

        private string _usrID;
        private string _usrPassword;
        private string _usrName;
        private string _usrSurname;
        private string _usrEmail;
        private string _usrMobile;
        private string _usrPhone;
        private string _usrFax;
        private bool _usrWebContact;
        private string _usrWebTitle;
        private byte[] _usrAvatar;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the ID property;
        /// </summary>
        /// <value>
        ///   The ID;
        /// </value>
        public string UsrID
        {
            get { return _usrID; }
            set { _usrID = value; }
        }
        /// <summary>
        ///   Gets or sets the Password property;
        /// </summary>
        /// <value>
        ///   The Password;
        /// </value>
        public string UsrPassword
        {
            get { return _usrPassword; }
            set { _usrPassword = value; }
        }
        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string UsrName
        {
            get { return _usrName; }
            set { _usrName = value; }
        }
        /// <summary>
        ///   Gets or sets the Surname property;
        /// </summary>
        /// <value>
        ///   The Surname;
        /// </value>
        public string UsrSurname
        {
            get { return _usrSurname; }
            set { _usrSurname = value; }
        }
        /// <summary>
        ///   Gets or sets the User Display name.
        /// </summary>
        /// <value>
        ///   The User Display name.
        /// </value>
        public string UsrDisplayName
        {
            get { return String.Format("{0} {1}", _usrName, _usrSurname); }
        }
        /// <summary>
        ///   Gets or sets the Email property;
        /// </summary>
        /// <value>
        ///   The Email;
        /// </value>
        public string UsrEmail
        {
            get { return _usrEmail; }
            set { _usrEmail = value; }
        }
        /// <summary>
        ///   Gets or sets the Mobile property;
        /// </summary>
        /// <value>
        ///   The Mobile;
        /// </value>
        public string UsrMobile
        {
            get { return _usrMobile; }
            set { _usrMobile = value; }
        }
        /// <summary>
        ///   Gets or sets the Phone property;
        /// </summary>
        /// <value>
        ///   The Phone;
        /// </value>
        public string UsrPhone
        {
            get { return _usrPhone; }
            set { _usrPhone = value; }
        }
        /// <summary>
        ///   Gets or sets the Fax property;
        /// </summary>
        /// <value>
        ///   The Fax;
        /// </value>
        public string UsrFax
        {
            get { return _usrFax; }
            set { _usrFax = value; }
        }
        /// <summary>
        /// Gets or sets the usr web title.
        /// </summary>
        /// <value>
        /// The usr web title.
        /// </value>
        public string UsrWebTitle
        {
            get { return _usrWebTitle; }
            set { _usrWebTitle = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [usr web contact].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [usr web contact]; otherwise, <c>false</c>.
        /// </value>
        public bool UsrWebContact
        {
            get { return _usrWebContact; }
            set { _usrWebContact = value; }
        }
        /// <summary>
        ///   Gets or sets the Avatar property;
        /// </summary>
        /// <value>
        ///   The Avatar;
        /// </value>
        public byte[] UsrAvatar
        {
            get { return _usrAvatar; }
            set { _usrAvatar = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="User"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is User))
            {
                throw new ArgumentException("Invalid Source Argument to User Assign");
            }
            base.AssignFromSource(aSource);
            _usrID = (aSource as User)._usrID;
            _usrPassword = (aSource as User)._usrPassword;
            _usrName = (aSource as User)._usrName;
            _usrSurname = (aSource as User)._usrSurname;
            _usrEmail = (aSource as User)._usrEmail;
            _usrMobile = (aSource as User)._usrMobile;
            _usrPhone = (aSource as User)._usrPhone;
            _usrFax = (aSource as User)._usrFax;
            _usrWebContact = (aSource as User)._usrWebContact;
            _usrWebTitle = (aSource as User)._usrWebTitle;
            _usrAvatar = (aSource as User)._usrAvatar;
        } 

#endregion
    }
 }