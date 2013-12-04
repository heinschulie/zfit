using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class FanWorkout : FanWorkoutKey
    {
        #region Fields

        private string _wrtName;
        private string _fanName;
        private string _fanSurname;
        private string _fawDatecreated;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string WrtName
        {
            get { return _wrtName; }
            set { _wrtName = value; }
        }
        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string FanName
        {
            get { return _fanName; }
            set { _fanName = value; }
        }
        /// <summary>
        ///   Gets or sets the Surname property;
        /// </summary>
        /// <value>
        ///   The Surname;
        /// </value>
        public string FanSurname
        {
            get { return _fanSurname; }
            set { _fanSurname = value; }
        }
        /// <summary>
        ///   Gets or sets the Fan Display name.
        /// </summary>
        /// <value>
        ///   The Fan Display name.
        /// </value>
        public string FanDisplayName
        {
            get { return String.Format("{0} {1}", _fanName, _fanSurname); }
        }
        /// <summary>
        ///   Gets or sets the WorkoutfanDatejoined property;
        /// </summary>
        /// <value>
        ///   The FanWorkoutDateJoined;
        /// </value>
        public string FanWorkoutDateCreated
        {
            get { return _fawDatecreated; }
            set { _fawDatecreated = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="FanWorkout"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FanWorkout))
            {
                throw new ArgumentException("Invalid Source Argument to FanWorkout Assign");
            }
            base.AssignFromSource(aSource);
            _wrtName = (aSource as FanWorkout)._wrtName;
            _fanName = (aSource as FanWorkout)._fanName;
            _fanSurname = (aSource as FanWorkout)._fanSurname;
            _fawDatecreated = (aSource as FanWorkout)._fawDatecreated;
        }

        #endregion
    }
}
