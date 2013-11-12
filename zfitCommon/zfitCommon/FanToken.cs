using System;
using System.Collections.Generic;
using System.Linq;


namespace Zephry
{
    [Serializable]
    public class FanToken : Zephob
    {

        //#region Static Constructor

        ///// <summary>
        /////   Initializes the <see cref="FanToken"/> class.
        ///// </summary>
        ///// <remarks>
        /////   Constructor overload is static for instant construction (not lazy)
        ///// </remarks>
        //static FanToken()
        //{
        //}

        //#endregion

        //#region Instance Singleton

        ///// <summary>
        /////   Instance.
        ///// </summary>
        //private static FanToken _instance = new FanToken();

        ///// <summary>
        /////   Gets the <see cref="Session"/> instance.
        ///// </summary>
        //public static FanToken Instance
        //{
        //    get { return _instance; }
        //    set { _instance = value; }
        //}

        //#endregion

        #region Fields

        /// <summary>
        /// FanID.
        /// </summary>
        private string _fanID;
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
        public string FanID
        {
            get { return _fanID; }
            set { _fanID = value; }
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
        /// Assigns aSource to this instance of <see cref="FanToken"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanToken))
            {
                throw new ArgumentException("Invalid Assignment Source for FanToken");
            }

            _fanID = (aSource as FanToken)._fanID;
            _password = (aSource as FanToken)._password;
            _url = (aSource as FanToken)._url;
            _method = (aSource as FanToken)._method;
            _context = (aSource as FanToken)._context;
            _version = (aSource as FanToken)._version;
        }
        #endregion

    }
}
