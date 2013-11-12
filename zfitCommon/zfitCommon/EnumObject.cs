using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zephry
{
    //Experimental class to facilitate ASP.NET DevExpress front-end development by enabling ASPXGridview databinding to enumerations  
    public class EnumObject
    {
        #region Fields

        private string _enumName;
        private int _enumValue; 
         
        #endregion

        #region Properties

        public string EnumName
        {
            get { return _enumName; }
            set { _enumName = value; }
        }

        public int EnumValue
        {
            get { return _enumValue; }
            set { _enumValue = value; }
        }

        /// <summary>
        /// Assigns the fields and properties of aSource to this instance.
        /// </summary>
        /// <param name="aSource">A source TransactionStatus.</param>
        public void AssignFromSource(EnumObject aSource)
        {
            if (aSource == null) { return; }

            _enumName = aSource._enumName;
            _enumValue = aSource._enumValue;
        }
        #endregion
    }
}
