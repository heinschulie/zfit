using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zephry;

namespace zfit
{
    public class webObject : Zephob
    {
        #region Fields

        private Zephob _anObject;
        private TransactionStatus _aTransactionStatus;

        #endregion

        #region Properties

        public Zephob AnObject
        {
            get { return _anObject; }
            set { _anObject = value; }
        }

        public TransactionStatus aTransactionStatus
        {
            get { return _aTransactionStatus; }
            set { _aTransactionStatus = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Fan"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is webObject))
            {
                throw new ArgumentException("Invalid Source Argument to Fan Assign");
            }

            _aTransactionStatus.AssignFromSource((aSource as webObject)._aTransactionStatus);
            _anObject.AssignFromSource((aSource as webObject)._anObject); 
        }

        #endregion
    }
}