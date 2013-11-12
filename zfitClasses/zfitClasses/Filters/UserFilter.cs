using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace zfit
{
    public class UserFilter : Zephob
    {
        private bool _isFiltered;
        private string _userNameFilter;

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public string UserNameFilter
        {
            get { return _userNameFilter; }
            set { _userNameFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is UserFilter))
            {
                throw new ArgumentException("Invalid assignment source", "UserFilter");
            }

            _isFiltered = (aSource as UserFilter)._isFiltered;
            _userNameFilter = (aSource as UserFilter)._userNameFilter;
        }
    }
}
