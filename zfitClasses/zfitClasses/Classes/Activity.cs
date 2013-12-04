using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class Activity : ActivityKey
    {
        #region Fields

        private string _excName;
        private string _wrtName;
        private string _actDescription;
        private int _actUnitOfMeasure;
        private int _actMeasure;
        private int _actUnitOfTime;
        private int _actTime;
        private int _actRepetitions;
        private int _actRest;
        private int _actResultType;

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
        ///   Gets or sets the ActDescription property;
        /// </summary>
        /// <value>
        ///   The ActDescription;
        /// </value>
        public string ActDescription
        {
            get { return _actDescription; }
            set { _actDescription = value; }
        }
        /// <summary>
        ///   Gets or sets the ActUnitOfMeasure property;
        /// </summary>
        /// <value>
        ///   The ActUnitOfMeasure;
        /// </value>
        public int ActUnitOfMeasure
        {
            get { return _actUnitOfMeasure; }
            set { _actUnitOfMeasure = value; }
        }

        /// <summary>
        ///   Gets or sets the ActMeasure;
        /// </summary>
        /// <value>
        ///   The ActMeasure;
        /// </value>
        public int ActMeasure
        {
            get { return _actMeasure; }
            set { _actMeasure = value; }
        }
        /// <summary>
        ///   Gets the ActUnitOfTime property;
        /// </summary>
        /// <value>
        ///   The ActUnitOfTime;
        /// </value>
        public int ActUnitOfTime
        {
            get { return _actUnitOfTime; }
            set { _actUnitOfTime = value; }
        }

        /// <summary>
        ///   Gets or sets the ActAvailability;
        /// </summary>
        /// <value>
        ///   The Availability;
        /// </value>
        public int ActTime
        {
            get { return _actTime; }
            set { _actTime = value; }
        }

        /// <summary>
        ///   Gets or sets the ActRepetitions;
        /// </summary>
        /// <value>
        ///   The ActRepetitions;
        /// </value>
        public int ActRepetitions
        {
            get { return _actRepetitions; }
            set { _actRepetitions = value; }
        }
        /// <summary>
        ///   Gets the ActRest property;
        /// </summary>
        /// <value>
        ///   The ActRest;
        /// </value>
        public int ActRest
        {
            get { return _actRest; }
            set { _actRest = value; }
        }

        /// <summary>
        ///   Gets or sets the ActResultType;
        /// </summary>
        /// <value>
        ///   The ActResultType;
        /// </value>
        public int ActResultType
        {
            get { return _actResultType; }
            set { _actResultType = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Activity"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Activity))
            {
                throw new ArgumentException("Invalid Source Argument to Activity Assign");
            }
            base.AssignFromSource(aSource);
            _excName = (aSource as Activity)._excName;
            _wrtName = (aSource as Activity)._wrtName;
            _actDescription = (aSource as Activity)._actDescription;
            _actUnitOfMeasure = (aSource as Activity)._actUnitOfMeasure;
            _actMeasure = (aSource as Activity)._actMeasure;
            _actUnitOfTime = (aSource as Activity)._actUnitOfTime;
            _actTime = (aSource as Activity)._actTime;
            _actRepetitions = (aSource as Activity)._actRepetitions;
            _actRest = (aSource as Activity)._actRest;
            _actResultType = (aSource as Activity)._actResultType;
        }

        #endregion
    }
}
