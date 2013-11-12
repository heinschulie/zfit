using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    ///   Zephob abstract class.
    /// </summary>
    /// <remarks>
    ///   namespace Zephry.
    /// </remarks>
    [Serializable]
    public abstract class Zephob
    {
        #region Fields
        
        /// <summary>
        ///   The HashValue.
        /// </summary>
        private int _hashValue;
        /// <summary>
        ///   The _objectState field defines whether a <see cref="Zephob"/> has one of 
        ///   of the following <see cref="ObjectState"/>s: 
        ///   <list type="bullet">
        ///     <item>
        ///         <term><b>None</b> -</term>
       ///          <description>No state.</description>
        ///     </item>
        ///     <item>
        ///         <term><b>Disabled</b> -</term>
        ///          <description>The <see cref="Zephob"/> is disabled.</description>
        ///     </item>
        ///     <item>
        ///         <term><b>Selected</b> -</term>
        ///          <description>The <see cref="Zephob"/> is selected.</description>
        ///     </item>
        ///   </list>
        /// </summary>
        private ObjectState _objectState = ObjectState.None;
        #endregion

        #region Properties
        /// <summary>
        ///   Gets or Sets the _hashValue field
        /// </summary>
        /// <value>
        ///   The HashValue.
        /// </value>
        public int HashValue
        {
            get { return _hashValue; }
            set { _hashValue = value; }
        }
        /// <summary>
        ///   Gets or sets the _objectState field.
        /// </summary>
        /// <value>
        ///  An <see cref="ObjectState"/>.
        /// </value>
        public ObjectState ObjectState
        {
            get { return _objectState; }
            set { _objectState = value; }
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns from source.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public abstract void AssignFromSource(object aSource);

        #endregion
    }
}
