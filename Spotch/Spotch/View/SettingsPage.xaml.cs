using System;
using Xamarin.Forms;
using Spotch.Models;

namespace Spotch.View
{
    public partial class SettingsPage : ContentPage
	{
        public string fontColor = "#ccc";
        public Color fontColor2 = new Color(0,0,0);

		public SettingsPage ()
		{
			InitializeComponent ();
            this.BindingContext = UIColorModel.Instance;
        }

        public void setBackgroundColor()
        {
            this.BackgroundColor = UIColorModel._backgroundColor;
        }

        public void OnWhiteColor(object sender, EventArgs args)
        {
            UIColorModel._backgroundColor = WHITE.BackgroundColor;
            setBackgroundColor();
            UIColorModel._fontColor = "#333";
        }

        public void OnDarkColor(object sender, EventArgs args)
        {
            UIColorModel._backgroundColor = DARK.BackgroundColor;
            setBackgroundColor();
            UIColorModel._fontColor = "#fff";
        }
    }
}
