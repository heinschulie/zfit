using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zephry; 

namespace zfit
{
    public class FriendFilter : Zephob
    {
        private Friend _friendFilter = new Friend();

        public Friend FriendshipFilter
        {
            get { return _friendFilter; }
            set { _friendFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is FriendFilter))
            {
                throw new ArgumentException("Invalid assignment source", "FriendFilter");
            }

            _friendFilter.AssignFromSource((aSource as FriendFilter)._friendFilter);
        }
    }
}
