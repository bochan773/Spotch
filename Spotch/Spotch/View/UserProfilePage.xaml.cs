using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class UserProfilePage : ContentPage
	{
		public UserProfilePage ()
		{
			InitializeComponent ();

            var username = Application.Current.Properties["username"] as string;
            var birthday = Application.Current.Properties["birthday"] as string;
            var email = Application.Current.Properties["email"] as string;

            usernameText.Text = username;
            birthdayEntry.Text = birthday;
            emailEntry.Text = email;

            this.LogoutBtn.Clicked += LogoutBtn_Clicked;
        }

        private async void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("ログアウト", "ログアウトしていいですか？", "OK", "キャンセル");
            if (result)
            {
                Application.Current.Properties.Clear();

                Application.Current.MainPage = new TopPage();
            }
        }
    }
}
