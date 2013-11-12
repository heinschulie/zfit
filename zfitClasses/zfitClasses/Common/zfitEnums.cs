using System;
using System.Collections.Generic;
using System.Linq;

namespace zfit
{
    
    #region RippleSelect
    /// <summary>
    /// RippleSelect Enumerator. Describes whether a single object must be selected, or an object together with 
    /// all its recursive subordinates.
    /// </summary>
    public enum RippleSelect
    {
        /// <summary>
        /// Select a Single object
        /// </summary>
        Single,
        /// <summary>
        /// Select an object and its recursive subordinates
        /// </summary>
        Community,
        /// <summary>
        /// Selects all objects
        /// </summary>
        All
    };
    #endregion

}
