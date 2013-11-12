using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    ///   RoleFunctionCollection class.
    /// </summary>
    /// <remarks>
    ///   namespace zfit
    /// </remarks>
    public class RoleFunctionCollection : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private int _roleKeyFilter;
        private int _functionKeyFilter;
        private List<RoleFunction> _roleFunctionList = new List<RoleFunction>();

        #endregion

        #region  Properties

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="RoleFunctionCollection"/> is filtered.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="RoleFunctionCollection"/> is filtered; otherwise, <c>false</c>.
        /// </value>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }
        /// <summary>
        ///   Gets or sets the <c>RoleKeyFilter</c>.
        /// </summary>
        /// <value>
        ///   The <c>RoleKeyFilter</c>.
        /// </value>
        public int RoleKeyFilter
        {
            get { return _roleKeyFilter; }
            set { _roleKeyFilter = value; }
        }
        /// <summary>
        ///   Gets or sets the <c>FunctionKeyFilter</c>.
        /// </summary>
        /// <value>
        ///   The <c>FunctionKeyFilter</c>.
        /// </value>
        public int FunctionKeyFilter
        {
            get { return _functionKeyFilter; }
            set { _functionKeyFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="RoleFunction"/> list.
        /// </summary>
        /// <value>
        /// The RoleFunction list.
        /// </value>
        public List<RoleFunction> RoleFunctionList
        {
            get { return _roleFunctionList; }
            set { _roleFunctionList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="RoleFunctionCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is RoleFunctionCollection))
            {
                throw new ArgumentException("Invalid assignment source", "RoleFunctionCollection");
            }

            _isFiltered = (aSource as RoleFunctionCollection)._isFiltered;
            _roleKeyFilter = (aSource as RoleFunctionCollection)._roleKeyFilter;
            _functionKeyFilter = (aSource as RoleFunctionCollection)._functionKeyFilter;
            _roleFunctionList.Clear();
            foreach (RoleFunction vRoleFunctionSource in (aSource as RoleFunctionCollection)._roleFunctionList)
            {
                RoleFunction vRoleFunctionTarget = new RoleFunction();
                vRoleFunctionTarget.AssignFromSource(vRoleFunctionSource);
                _roleFunctionList.Add(vRoleFunctionTarget);
            }
        }

        #endregion
    }
}