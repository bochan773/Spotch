using System;
using System.Collections.Generic;
using System.Text;

namespace Spotch.Models
{
    class TimeLine
    {
        // Singleton
        private static List<PostModel> _collection = new List<PostModel>();

        public static List<PostModel> Collections
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
