using System;
using System.Collections.Generic;
using System.Text;

namespace Spotch.Models
{
    class TimeLine
    {
        // Singleton
        private static List<Post> _collection = new List<Post>();

        public static List<Post> Collections
        {
            get
            {
                return _collection;
            }
            set
            {
                _collection = value;
            }
        }
    }
}
