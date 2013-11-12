using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    ///   Host class.
    /// </summary>
    /// <remarks>
    ///   namespace Smart7
    /// </remarks>
    public class EmailHost
    {

        #region Fields

        private string _name;
        private int _port;
        private bool _enableSsl;
        private int _deliveryMethod;
        private bool _useDefaultCredentials;
        private string _userID;
        private string _password;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [enable SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable SSL]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableSsl
        {
            get { return _enableSsl; }
            set { _enableSsl = value; }
        }
        /// <summary>
        /// Gets or sets the delivery method.
        /// </summary>
        /// <value>
        /// The delivery method.
        /// </value>
        public int DeliveryMethod
        {
            get { return _deliveryMethod; }
            set { _deliveryMethod = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [use default credentials].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [use default credentials]; otherwise, <c>false</c>.
        /// </value>
        public bool UseDefaultCredentials
        {
            get { return _useDefaultCredentials; }
            set { _useDefaultCredentials = value; }
        }
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        /// <value>
        /// The user ID.
        /// </value>
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion

    }
 }