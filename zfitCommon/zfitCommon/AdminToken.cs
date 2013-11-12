using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AdminToken : Zephob
    {

        #region Fields

        /// <summary>
        /// UserID.
        /// </summary>
        private string _userID;
        /// <summary>
        ///   Password.
        /// </summary>
        [NonSerialized]
        private string _password;
        /// <summary>
        ///   The URL.
        /// </summary>
        private string _url;
        /// <summary>
        ///   The method of the current service call.
        /// </summary>
        [NonSerialized]
        private string _method;
        /// <summary>
        ///   Context.
        /// </summary>
        private ConnectionContext _context = ConnectionContext.Integrated;
        /// <summary>
        ///   Version.
        /// </summary>
        private string _version;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the user ID.
        /// </summary>
        /// <value>
        ///   The user ID.
        /// </value>
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        /// <summary>
        ///   Gets the password.
        /// </summary>
        /// <value>
        ///   The password.
        /// </value>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        ///   Gets the context.
        /// </summary>
        /// <value>
        ///   The context.
        /// </value>
        public ConnectionContext Context
        {
            get { return _context; }
            set { _context = value; }
        }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        /// <value>
        ///   The version.
        /// </value>
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        /// <summary>
        ///   Gets or sets the URL.
        /// </summary>
        /// <value>
        ///   The URL.
        /// </value>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        /// <summary>
        ///   Gets or sets the Method.
        /// </summary>
        /// <value>
        ///   The method.
        /// </value>
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }

        #endregion

        #region AssignFromSource
        /// <summary>
        /// Assigns aSource to this instance of <see cref="UserToken"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is AdminToken))
            {
                throw new ArgumentException("Invalid Assignment Source for AdminToken");
            }

            _userID = (aSource as AdminToken)._userID;
            _password = (aSource as AdminToken)._password;
            _url = (aSource as AdminToken)._url;
            _method = (aSource as AdminToken)._method;
            _context = (aSource as AdminToken)._context;
            _version = (aSource as AdminToken)._version;
        }
        #endregion

    }
}
