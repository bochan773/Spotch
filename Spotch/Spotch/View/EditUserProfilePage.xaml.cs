using Spotch.Controller;
using Spotch.Models;
using System;
using Xamarin.Forms;

namespace Spotch.View
{
	public partial class EditUserProfilePage : ContentPage
	{
        private ISessionRepository sessionRepository = null;
        private UserAccount us;

        public EditUserProfilePage ()
		{
			InitializeComponent ();
            /*
            var userName = Application.Current.Properties["userName"] as string;
            var birthday = (DateTime)Application.Current.Properties["birthday"];
            var email = Application.Current.Properties["email"] as string;

            userNameText.Text = userName;
            birthdayEntry.Date = birthday;
            emailEntry.Text = email;
            */

            BindingUser();
        }

        private async void BindingUser()
        {
            await this.sessionRepository.LoadAsync();
            us = this.sessionRepository.GetValue<UserAccount>();
            if (us != null)
            {
                Console.WriteLine("-----ユーザーデータが保存されてるよ");
                user.BindingContext = us;
            }
            else
            {
                Console.WriteLine("-----ユーザーデータがないよ");
            }
        }

        private async void SaveClick(object sender, EventArgs e)
        {
            var result = await DisplayAlert("保存", "変更内容を保存しますか？", "OK", "キャンセル");

            if (result)
            {
                //変更された内容を確認
                string userName = usernameText.Text;
                string email = emailEntry.Text;
                DateTime birthday = birthdayEntry.Date;

                if (!userName.Equals(us.userName))
                {
                    Console.WriteLine("--------ユーザー名が変更されたよ---------");
                    us.userName = userName;

                }
                if (!email.Equals(us.email))
                {
                    Console.WriteLine("--------メールアドレスが変更されたよ----------");
                    us.email = email;
                }
                if (!birthday.Equals(us.birthday))
                {
                    Console.WriteLine("--------誕生日が変更されたよ-----------");
                    us.birthday = birthday;
                }

                //ここで通信
                //ユーザー情報を送信して、端末内情報も更新
                this.sessionRepository.SetValue<UserAccount>(us);
                bool flg = await this.sessionRepository.SaveAsync();
                
                //前のページに戻る
                await Navigation.PopAsync();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
    }
}
