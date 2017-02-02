using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class EditUserProfilePage : ContentPage
	{
		public EditUserProfilePage ()
		{
            InitializeComponent();

            var username = Application.Current.Properties["username"] as string;
            var birthday = (DateTime)Application.Current.Properties["birthday"];
            var email = Application.Current.Properties["email"] as string;

            usernameText.Text = username;
            birthdayEntry.Date = birthday;
            emailEntry.Text = email;

        }


        private async void SaveClick(object sender, EventArgs e)
        {
            var result = await DisplayAlert("保存", "変更内容を保存しますか？(まだ保存されません)", "OK", "キャンセル");
            /*
            if (result)
            {
                Application.Current.Properties.Clear();

                Application.Current.MainPage = new TopPage();
            }
            */
            await Navigation.PopAsync();
        }
    }
}
