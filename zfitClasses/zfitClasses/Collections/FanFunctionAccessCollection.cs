using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// A list of functional accesses for a specific user.
    /// </summary>
    public class FanFunctionAccessCollection : FanKey
    {
        #region Static Constructor

        /// <summary>
        /// Initializes the <see cref="FanFunctionAccessCollection"/> class.
        /// </summary>
        /// <remarks>
        /// Constructor overload is static for instant construction (not lazy)
        /// </remarks>
        static FanFunctionAccessCollection()
        {
        }

        #endregion

        #region Instance Singleton

        /// <summary>
        ///   Instance.
        /// </summary>
        private static FanFunctionAccessCollection _instance = new FanFunctionAccessCollection();

        /// <summary>
        /// Gets the <see cref="FanFunctionAccessCollection"/> instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static FanFunctionAccessCollection Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        #endregion
                
        #region Fields
        private List<FunctionAccess> _functionAccessList = new List<FunctionAccess>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the function access list.
        /// </summary>
        /// <value>
        /// The function access list.
        /// </value>
        public List<FunctionAccess> FunctionAccessList
        {
            get { return _functionAccessList; }
            set { _functionAccessList = value; }
        }
        #endregion

        #region AssignFromSource
        /// <summary>
        /// Assigns the properties of aSource to this instance.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanFunctionAccessCollection))
            {
                throw new ArgumentException("Invalid Source Argument to FanFunctionAccessCollection Assign");
            }

            base.AssignFromSource(aSource);
            _functionAccessList.Clear();
            (aSource as FanFunctionAccessCollection)._functionAccessList.ForEach(vFunctionAccessSource =>
            {
                var vFunctionAccessTarget = new FunctionAccess();
                vFunctionAccessTarget.AssignFromSource(vFunctionAccessSource);
                _functionAccessList.Add(vFunctionAccessTarget);
            });
        }
        #endregion

        #region Can
        /// <summary>
        /// Determines whether a function of this instance can be actioned.
        /// </summary>
        /// <param name="aAccessMode">A access mode.</param>
        /// <param name="aFunction">A function.</param>
        /// <returns>
        ///   <c>true</c> if the function can be actioned; otherwise, <c>false</c>.
        /// </returns>
        public bool Can(AccessMode aAccessMode, string aFunction)
        {
            var vCan = true;
            FunctionAccess vFunctionAccess = _functionAccessList.FirstOrDefault(c => c.Function == aFunction);
            if (vFunctionAccess == null)
            {
                vCan = false;
            }
            else
            {
                switch (aAccessMode)
                {
                    case AccessMode.List:
                        if (!vFunctionAccess.Access.List) { vCan = false; }
                        break;
                    case AccessMode.Create:
                        if (!vFunctionAccess.Access.Create) { vCan = false; }
                        break;
                    case AccessMode.Read:
                        if (!vFunctionAccess.Access.Read) { vCan = false; }
                        break;
                    case AccessMode.Update:
                        if (!vFunctionAccess.Access.Update) { vCan = false; }
                        break;
                    case AccessMode.Delete:
                        if (!vFunctionAccess.Access.Delete) { vCan = false; }
                        break;
                    default:
                        vCan = false;
                        break;
                }
            }
            return vCan;
        }
        #endregion

    }
}
