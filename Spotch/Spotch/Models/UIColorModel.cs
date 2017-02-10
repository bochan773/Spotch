using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Spotch.Models
{
    class UIColorModel
    {
        private static UIColorModel _instance;
        public static Color _backgroundColor { get; set; }
        public static string _fontColor { get; set; }

        public static UIColorModel Instance
        {
            get { return _instance ?? (_instance = new UIColorModel()); }
        }
    }
}
