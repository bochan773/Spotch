using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Spotch.Models
{
    class ObservableCollectionSerializable<T>
    {
        // Singleton
        private static ObservableCollection<T> _instance = new ObservableCollection<T>();

        public static ObservableCollection<T> GetInstance
        {
            get
            {
                if (_instance == null) _instance = new ObservableCollection<T>();
                return _instance;
            }
        }
    }
}
