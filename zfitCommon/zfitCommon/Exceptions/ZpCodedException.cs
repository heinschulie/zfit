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
    public class ZpCodedException: Exception
    {
        #region Fields
        /// <summary>
        ///   The assembly in which the <see cref="ZpCodedException"/> originates.
        /// </summary>
        private SourceAssembly _sourceAssembly;
        /// <summary>
        /// A Message Code that can be translated. Describes the type of failure.
        /// </summary>
        private string _messageCode;
        /// <summary>
        /// A Method Code that can be translated. Describes where the failure occured.
        /// </summary>
        private string _methodCode;
        /// <summary>
        /// An Object Code that can be translated. Describes the Object that failed.
        /// </summary>
        private string _objectCode;
        /// <summary>
        /// A list of translatable messagepairs, used primarily for handling multiple exceptions
        /// </summary>
        private List<MessagePair> _messagePairList = new List<MessagePair>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the source assembly.
        /// </summary>
        /// <value>
        /// The source assembly.
        /// </value>
        public SourceAssembly SourceAssembly
        {
            get { return _sourceAssembly; }
            set { _sourceAssembly = value; }
        }
        /// <summary>
        /// Gets or sets the aMessage code.
        /// </summary>
        /// <value>
        /// The aMessage code.
        /// </value>
        public string MessageCode
        {
            get { return _messageCode; }
            set { _messageCode = value; }
        }
        /// <summary>
        /// Gets or sets the method code.
        /// </summary>
        /// <value>
        /// The method code.
        /// </value>
        public string MethodCode
        {
            get { return _methodCode; }
            set { _methodCode = value; }
        }
        /// <summary>
        /// Gets or sets the object code.
        /// </summary>
        /// <value>
        /// The object code.
        /// </value>
        public string ObjectCode
        {
            get { return _objectCode; }
            set { _objectCode = value; }
        }
        /// <summary>
        /// Gets or sets the message pair list.
        /// </summary>
        /// <value>
        /// The message pair list.
        /// </value>
        public List<MessagePair> MessagePairList
        {
            get { return _messagePairList; }
            set { _messagePairList = value; }
        }

        #endregion       

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ZpCodedException"/> class.
        /// </summary>
        public ZpCodedException()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ZpCodedException"/> class.
        /// </summary>
        /// <param name="aSourceAssembly">A source assembly.</param>
        /// <param name="aMessage">The aMessage.</param>
        /// <param name="aMessageCode">The aMessage code.</param>
        /// <param name="aMethodCode">The method code.</param>
        /// <param name="aObjectCode">The object code.</param>
        public ZpCodedException(SourceAssembly aSourceAssembly, string aMessage, string aMessageCode, string aMethodCode, string aObjectCode)
            : base(aMessage)
        {
            _sourceAssembly = aSourceAssembly;
            _messageCode = aMessageCode;
            _methodCode = aMethodCode;
            _objectCode = aObjectCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZpCodedException"/> class.
        /// </summary>
        /// <param name="aSourceAssembly">A source assembly.</param>
        /// <param name="aMessage">A message.</param>
        /// <param name="aMessageCode">A message code.</param>
        /// <param name="aMethodCode">A method code.</param>
        /// <param name="aObjectCode">A object code.</param>
        /// <param name="aInnerException">A inner exception.</param>
        public ZpCodedException(SourceAssembly aSourceAssembly, string aMessage, string aMessageCode, string aMethodCode, string aObjectCode, Exception aInnerException)
            : base(aMessage, aInnerException)
        {
            _sourceAssembly = aSourceAssembly;
            _messageCode = aMessageCode;
            _methodCode = aMethodCode;
            _objectCode = aObjectCode;
        }
        /// <summary>
        ///   Initializes a new instance of the <see cref="ZpCodedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected ZpCodedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                return;

            _sourceAssembly = (SourceAssembly)info.GetInt32("_sourceAssembly");
            _messageCode = info.GetString("_messageCode");
            _methodCode = info.GetString("_methodCode");
            _objectCode = info.GetString("_objectCode");
            _messagePairList = (List<MessagePair>)info.GetValue("_messagePairList", typeof(List<MessagePair>));

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

            info.AddValue("_sourceAssembly", _sourceAssembly);
            info.AddValue("_messageCode", _messageCode);
            info.AddValue("_methodCode", _methodCode);
            info.AddValue("_objectCode", _objectCode); 
            info.AddValue("_messagePairList", _messagePairList, typeof(List<MessagePair>));
        }
        #endregion
    }
}
