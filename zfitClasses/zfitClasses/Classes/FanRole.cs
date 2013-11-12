using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// FanRole class.
    /// </summary>
    /// <remarks>
    ///   namespace Lookfor
    /// </remarks>
    public class FanRole : FanRoleKey
    {
        #region Fields

        private string _fanDisplayName;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Fan"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Fan"/> name.
        /// </value>
        public string FanDisplayName
        {
            get { return _fanDisplayName; }
            set { _fanDisplayName = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanRole"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanRole))
            {
                throw new ArgumentException("Invalid Source Argument to FanRole Assign");
            }
            base.AssignFromSource(aSource);
            _fanDisplayName = (aSource as FanRole)._fanDisplayName;
        }

        #endregion
    }
 }