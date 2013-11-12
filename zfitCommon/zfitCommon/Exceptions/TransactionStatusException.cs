using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Zephry
{
    /// <summary>
    ///   TransactionStatusException class. Inherits from <see cref="Exception"/>.
    /// </summary>
    /// <remarks>
    ///   namespace Zephry.
    /// </remarks>
    [Serializable]
    public class TransactionStatusException : Exception
    {
        #region Fields

        /// <summary>
        ///   TransactionStatus instance set on custom constructor
        /// </summary>
        private TransactionStatus _transactionStatus = new TransactionStatus();

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the transaction status.
        /// </summary>
        /// <value>
        ///   The transaction status.
        /// </value>
        public TransactionStatus TransactionStatus
        {
            get { return _transactionStatus; }
            set { _transactionStatus = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Base Constructor, invoked by constructor overloads
        /// </summary>
        public TransactionStatusException()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TransactionStatusException"/> class.
        /// </summary>
        /// <param name="aTransactionStatus">A transaction status.</param>
        public TransactionStatusException(TransactionStatus aTransactionStatus)
        {
            _transactionStatus.AssignFromSource(aTransactionStatus);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionStatusException"/> class.
        /// </summary>
        /// <param name="aMessagePairs">A paramater list of <see cref="MessagePair"/>s.</param>
        public TransactionStatusException(params MessagePair[] aMessagePairs)
        {
            Array.ForEach(aMessagePairs, vSourceMessagePair =>
            {
                var vTargetMessagePair = new MessagePair(vSourceMessagePair.Message, vSourceMessagePair.Subject);
                _transactionStatus.MessagePairList.Add(vTargetMessagePair);
            }); ;
        }

        /// <summary>
        ///   Implement the Deserialization constructor, invokes Base Serialization constructor, and deserializes fro info to private _transactionStatus
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected TransactionStatusException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                _transactionStatus.MessagePairList = (List<MessagePair>)info.GetValue("MessagePair", typeof(List<MessagePair>));
            }
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is a null reference . </exception>
        ///   
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/>
        ///   </PermissionSet>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info != null)
            {
                info.AddValue("MessagePairList", _transactionStatus.MessagePairList, typeof(List<MessagePair>));
            }
            base.GetObjectData(info, context);
        }

        #endregion
    }
}
