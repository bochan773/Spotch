using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class TopPage : ContentPage
	{
		public TopPage ()
		{
			InitializeComponent ();
            this.LoginBtn.Clicked += LoginBtn_Clicked;
            this.SignupBtn.Clicked += SignupBtn_Clicked;
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        private void SignupBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SignupPage();
        }
    }
}
