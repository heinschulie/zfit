using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class Workout : WorkoutKey
    {
        #region Fields

        private string _wrtName;
        private string _wrtResultFunction;
        private string _wrtDescription;
        private int _ownerKey;
        private string _ownerName;
        private int _wrtAvailability;
        private int _fedKey;
        private string _fedName;
        private int _celKey;
        private string _celName;
        private string _dateCreated; //Date handled as string - converted within data.dll 

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
        ///   Gets or sets the ResultFunction property;
        /// </summary>
        /// <value>
        ///   The ResultFunction;
        /// </value>
        public string WrtResultFunction
        {
            get { return _wrtResultFunction; }
            set { _wrtResultFunction = value; }
        }
        /// <summary>
        ///   Gets or sets the Description property;
        /// </summary>
        /// <value>
        ///   The Description;
        /// </value>
        public string WrtDescription
        {
            get { return _wrtDescription; }
            set { _wrtDescription = value; }
        }

        /// <summary>
        ///   Gets or sets the Owner;
        /// </summary>
        /// <value>
        ///   The Owner;
        /// </value>
        public int WrtOwnerKey
        {
            get { return _ownerKey; }
            set { _ownerKey = value; }
        }
        /// <summary>
        ///   Gets the OwnerName property;
        /// </summary>
        /// <value>
        ///   The OwnerName;
        /// </value>
        public string WrtOwnerName
        {
            get { return _ownerName; }
            set { _ownerName = value; }
        }

        /// <summary>
        ///   Gets or sets the WrtAvailability;
        /// </summary>
        /// <value>
        ///   The Availability;
        /// </value>
        public int WrtAvailability
        {
            get { return _wrtAvailability; }
            set { _wrtAvailability = value; }
        }

        /// <summary>
        ///   Gets or sets the FedKey;
        /// </summary>
        /// <value>
        ///   The FedKey;
        /// </value>
        public int FedKey
        {
            get { return _fedKey; }
            set { _fedKey = value; }
        }
        /// <summary>
        ///   Gets the FedName property;
        /// </summary>
        /// <value>
        ///   The FedName;
        /// </value>
        public string FedName
        {
            get { return _fedName; }
            set { _fedName = value; }
        }

        /// <summary>
        ///   Gets or sets the CelKey;
        /// </summary>
        /// <value>
        ///   The CelKey;
        /// </value>
        public int CelKey
        {
            get { return _celKey; }
            set { _celKey = value; }
        }
        /// <summary>
        ///   Gets the CelName property;
        /// </summary>
        /// <value>
        ///   The CelName;
        /// </value>
        public string CelName
        {
            get { return _celName; }
            set { _celName = value; }
        }

        /// <summary>
        ///   Gets or sets the DateCreated property;
        /// </summary>
        /// <value>
        ///   The DateCreated;
        /// </value>
        public string DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }


        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Workout"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Workout))
            {
                throw new ArgumentException("Invalid Source Argument to Workout Assign");
            }
            base.AssignFromSource(aSource);
            _wrtName = (aSource as Workout)._wrtName;
            _wrtResultFunction = (aSource as Workout)._wrtResultFunction;
            _wrtDescription = (aSource as Workout)._wrtDescription;
            _ownerKey = (aSource as Workout)._ownerKey;
            _ownerName = (aSource as Workout)._ownerName;
            _wrtAvailability = (aSource as Workout)._wrtAvailability;
            _wrtAvailability = (aSource as Workout)._wrtAvailability;
            _fedKey = (aSource as Workout)._fedKey;
            _fedName = (aSource as Workout)._fedName;
            _celKey = (aSource as Workout)._celKey;
            _celName = (aSource as Workout)._celName;
            _dateCreated = (aSource as Workout)._dateCreated;
        }

        #endregion
    }
}
