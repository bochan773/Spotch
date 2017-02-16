using Spotch.Controller;
using Spotch.Models;
using System;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class UserProfilePage : ContentPage
	{

        private ISessionRepository sessionRepository = null;

        public UserProfilePage ()
		{
			InitializeComponent ();

            //ログアウトボタンのクリックイベントの登録
            this.LogoutBtn.Clicked += LogoutBtn_Clicked;
            sessionRepository = new ApplicationProperties();

            BindingDate();
        }

        protected async void BindingDate()
        {
            await this.sessionRepository.LoadAsync();
            var us = this.sessionRepository.GetValue<UserAccount>();
            if (us != null)
            {
                Console.WriteLine("-----ユーザーデータが保存されてるよ");
                Console.WriteLine("testの内容" + us.username + "::" + us.password);
                user.BindingContext = us;
            }
            else
            {
                Console.WriteLine("-----ユーザーデータがないよ");
            }
        }

        //ログアウトボタンを押したときに呼ばれる
        private async void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("ログアウト", "ログアウトしていいですか？", "OK", "キャンセル");
            if (result)
            {
                Application.Current.Properties.Clear();

                Application.Current.MainPage = new TopPage();
            }
        }

        //editボタンを押したときに呼ばれる
        private void EditClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditUserProfilePage(), true);
        }
    }
}
