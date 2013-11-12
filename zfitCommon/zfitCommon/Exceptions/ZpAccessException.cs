using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Zephry
{
    /// <summary>
    /// The Zephry Custom Database  Exception that extends Exception with Message, Method and Object codes.
    /// The intention is that these codes may be translatable by the failing application.
    /// </summary>
    [Serializable]
    public class ZpAccessException : Exception
    {
        #region Fields
        /// <summary>
        /// The User ID of the disallowed user.
        /// </summary>
        private string _userID;
        /// <summary>
        /// The mode of access that was disallowed.
        /// </summary>
        private AccessMode _accessMode;
        /// <summary>
        /// The object that disallowed the access
        /// </summary>
        private string _object;
        #endregion

        #region Properties
        public string Object
        {
            get { return _object; }
            set { _object = value; }
        }
        public AccessMode AccessMode
        {
            get { return _accessMode; }
            set { _accessMode = value; }
        }
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ZpCodedException"/> class.
        /// </summary>
        public ZpAccessException()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ZpAccessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ZpAccessException(string message)
            : base(message)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ZpAccessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ZpAccessException(string message, Exception innerException)
            : base(message, innerException)
        {

        }         
        /// <summary>
        /// Initializes a new instance of the <see cref="ZpAccessException"/> class.
        /// </summary>
        /// <param name="aMessage">The AccessException message.</param>
        /// <param name="aUserID">The UserID of the access controlled user.</param>
        /// <param name="aAccessMode">The AccessMode.</param>
        /// <param name="aObject">The access controlled object.</param>
        public ZpAccessException(string aMessage, string aUserID, AccessMode aAccessMode, string aObject)
            : base(aMessage)
        {
            _userID = aUserID;
            _accessMode = aAccessMode;
            _object = aObject;
        }
        /// <summary>
        ///   Initializes a new instance of the <see cref="ZpCodedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected ZpAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                return;

            _userID = info.GetString("_userID");
            _accessMode = (AccessMode)info.GetInt32("_accessMode");
            _object = info.GetString("_object");

        }
        #endregion

        #region Serialization GetObjectData
        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic). </exception>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/>
        /// </PermissionSet>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info == null)
                return;

            info.AddValue("_userID", _userID);
            info.AddValue("_accessMode", _accessMode);
            info.AddValue("_object", _object);
        }
        #endregion
    }
}
