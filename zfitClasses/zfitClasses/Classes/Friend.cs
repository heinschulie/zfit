using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zfit
{
    public class Friend : FriendKey
    {
        #region Fields

        private string _fan1Name;
        private string _fan2Name;
        private string _fan1Surname;
        private string _fan2Surname;
        private int _relationship;
        private string _relationshiptype;
        private string _friendDateEstablished;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the relationship property;
        /// </summary>
        /// <value>
        ///   The Relationship;
        /// </value>
        public int Relationship
        {
            get { return _relationship; }
            set { _relationship = value; }
        }

        /// <summary>
        ///   Gets or sets the relationshiptype property;
        /// </summary>
        /// <value>
        ///   The Relationshiptype;
        /// </value>
        public string RelationshipType
        {
            get { return _relationshiptype; }
            set { _relationshiptype = value; }
        }
        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string Fan1Name
        {
            get { return _fan1Name; }
            set { _fan1Name = value; }
        }
        /// <summary>
        ///   Gets or sets the Surname property;
        /// </summary>
        /// <value>
        ///   The Surname;
        /// </value>
        public string Fan1Surname
        {
            get { return _fan1Surname; }
            set { _fan1Surname = value; }
        }
        /// <summary>
        ///   Gets or sets the Fan Display name.
        /// </summary>
        /// <value>
        ///   The Fan Display name.
        /// </value>
        public string Fan1DisplayName
        {
            get { return String.Format("{0} {1}", _fan1Name, _fan1Surname); }
        }
        /// <summary>
        ///   Gets or sets the Name property;
        /// </summary>
        /// <value>
        ///   The Name;
        /// </value>
        public string Fan2Name
        {
            get { return _fan2Name; }
            set { _fan2Name = value; }
        }
        /// <summary>
        ///   Gets or sets the Surname property;
        /// </summary>
        /// <value>
        ///   The Surname;
        /// </value>
        public string Fan2Surname
        {
            get { return _fan2Surname; }
            set { _fan2Surname = value; }
        }
        /// <summary>
        ///   Gets or sets the Fan Display name.
        /// </summary>
        /// <value>
        ///   The Fan Display name.
        /// </value>
        public string Fan2DisplayName
        {
            get { return String.Format("{0} {1}", _fan2Name, _fan2Surname); }
        }
        /// <summary>
        ///   Gets or sets the Fan1fanDateEstablished property;
        /// </summary>
        /// <value>
        ///   The FriendDateJoined;
        /// </value>
        public string FriendDateEstablished
        {
            get { return _friendDateEstablished; }
            set { _friendDateEstablished = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Friend"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Friend))
            {
                throw new ArgumentException("Invalid Source Argument to Friend Assign");
            }
            base.AssignFromSource(aSource);
            _fan1Name = (aSource as Friend)._fan1Name;
            _fan2Name = (aSource as Friend)._fan2Name;
            _fan1Surname = (aSource as Friend)._fan1Surname;
            _fan2Surname = (aSource as Friend)._fan2Surname;
            _friendDateEstablished = (aSource as Friend)._friendDateEstablished;
            _relationshiptype = (aSource as Friend)._relationshiptype;
            _relationship = (aSource as Friend)._relationship;
        }

        #endregion
    }
}
