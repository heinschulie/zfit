using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class FanSessionActivity : FanSessionActivityKey
    {
        #region Fields

        private string _fsaResult;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the Result property;
        /// </summary>
        /// <value>
        ///   The Result;
        /// </value>
        public string FsaResult
        {
            get { return _fsaResult; }
            set { _fsaResult = value; }
        }
 
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanSessionActivity"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanSessionActivity))
            {
                throw new ArgumentException("Invalid Source Argument to FanSessionActivity Assign");
            }
            base.AssignFromSource(aSource);
            _fsaResult = (aSource as FanSessionActivity)._fsaResult;
        }

        #endregion
    }
}
