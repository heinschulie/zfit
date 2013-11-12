using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// RoleFunction class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class RoleFunction : RoleFunctionKey
    {
        #region Fields

        private string _rolName;
        private string _fncName;
        private int _rfcAccessMap;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Role"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Role"/> name.
        /// </value>
        public string RolName
        {
            get { return _rolName; }
            set { _rolName = value; }
        }
        /// <summary>
        ///   Gets or sets the <see cref="Function"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Function"/> name.
        /// </value>
        public string FncName
        {
            get { return _fncName; }
            set { _fncName = value; }
        }
        /// <summary>
        ///   Gets or sets the AccessMap property;
        /// </summary>
        /// <value>
        ///   The AccessMap;
        /// </value>
        public int RfcAccessMap
        {
            get { return _rfcAccessMap; }
            set { _rfcAccessMap = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="RoleFunction"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is RoleFunction))
            {
                throw new ArgumentException("Invalid Source Argument to RoleFunction Assign");
            }
            base.AssignFromSource(aSource);
            _rolName = (aSource as RoleFunction)._rolName;
            _fncName = (aSource as RoleFunction)._fncName;
            _rfcAccessMap = (aSource as RoleFunction)._rfcAccessMap;
        }

        #endregion
    }
 }