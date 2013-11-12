using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    ///   A TransactionStatus is always returned by the Ruci Service layer to a calling application, regardless of whether additional arguments are returned. In the event
    ///   of a successful transaction, the <see cref="TransactionResult"/> is set to OK. Exceptions cause the TransactionResult to be set to one of the Exception results.
    /// </summary>
    public class TransactionStatus
    {
        #region Fields
        private TransactionResult _transactionResult;
        private SourceAssembly _sourceAssembly;
        private string _targetUrl;
        private string _message;
        private string _innerMessage;
        private List<MessagePair> _messagePairList = new List<MessagePair>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the transaction result.
        /// </summary>
        /// <value>
        /// The transaction result.
        /// </value>
        public TransactionResult TransactionResult
        {
            get { return _transactionResult; }
            set { _transactionResult = value; }
        }
        /// <summary>
        /// Gets or sets the target URL.
        /// </summary>
        /// <value>
        /// The target URL.
        /// </value>
        public string TargetUrl
        {
            get { return _targetUrl; }
            set { _targetUrl = value; }
        }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        /// <summary>
        /// Gets or sets the inner message.
        /// </summary>
        /// <value>
        /// The inner message.
        /// </value>
        public string InnerMessage
        {
            get { return _innerMessage; }
            set { _innerMessage = value; }
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
        #endregion

        #region Methods

        /// <summary>
        /// Assigns the fields and properties of aSource to this instance.
        /// </summary>
        /// <param name="aSource">A source TransactionStatus.</param>
        public void AssignFromSource(TransactionStatus aSource)
        {
            if (aSource == null) { return; }

            _transactionResult = aSource._transactionResult;
            _sourceAssembly = aSource._sourceAssembly;
            _targetUrl = aSource._targetUrl;
            _message = aSource._message;
            _innerMessage = aSource._innerMessage;
            aSource._messagePairList.ForEach(vSourceMessagePair =>
            {
                var vTargetMessagePair = new MessagePair(vSourceMessagePair.Message, vSourceMessagePair.Subject);
                _messagePairList.Add(vTargetMessagePair);
            });
        }
        #endregion
    }
}
