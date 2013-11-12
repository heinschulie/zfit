using System;
using System.Collections.Generic;
using System.Linq;

namespace zfit
{
    /// <summary>
    /// A disposable class to wrap the Web Service methods located at a specific URL.
    /// </summary>
    class ServiceHost : IDisposable
    {
        #region Fields
        /// <summary>
        /// A Web Service stub. Note that this private unmanaged resource must be disposed
        /// </summary>
        private zfitService.zfitWebMethods _webService;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the web service.
        /// </summary>
        /// <value>
        /// The web service.
        /// </value>
        public zfitService.zfitWebMethods WebService
        {
            get { return _webService; }
            set { _webService = value; }
        }
        #endregion

        #region Constructor
        public ServiceHost(string aUrl)
        {
            _webService = new zfitService.zfitWebMethods() { Url = aUrl };
        }
        #endregion

        #region Disposer
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_webService != null)
                {
                    _webService.Dispose();
                    _webService = null;
                }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="ServiceHost"/> is reclaimed by garbage collection.
        /// </summary>
        ~ServiceHost()
        {
            Dispose(false);
        }
        #endregion

    }
}
