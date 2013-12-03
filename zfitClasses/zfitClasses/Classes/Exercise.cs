using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class Exercise : ExerciseKey
    {
        #region Fields

        private string _excName;
        private int _excType;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string ExcName
        {
            get { return _excName; }
            set { _excName = value; }
        }

        /// <summary>
        ///   Gets or sets the Type;
        /// </summary>
        /// <value>
        ///   The Key;
        /// </value>
        public int ExcType
        {
            get { return _excType; }
            set { _excType = value; }
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Exercise"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Exercise))
            {
                throw new ArgumentException("Invalid Source Argument to Exercise Assign");
            }
            base.AssignFromSource(aSource);
            _excName = (aSource as Exercise)._excName;
            _excType = (aSource as Exercise)._excType;
        }

        #endregion
    }
}
