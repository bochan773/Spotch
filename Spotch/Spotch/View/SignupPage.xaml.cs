using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class SignupPage : ContentPage
	{
		public SignupPage ()
		{
			InitializeComponent ();
		}
        void SignupBtnClicked(object sender, EventArgs args)
        {
            string username = usernameEntry.Text;
            string userid = useridEntry.Text;
            string password = passwordEntry.Text;
            string email = emailEntry.Text;
            string birthday = birthdayEntry.Text;

            //テスト用にユーザーIDとpassは固定
            if (username.Length != 0 && password.Length != 0 && email.Length != 0)
            {
                this.DisplayAlert("Success", "アカウント作成成功", "はい");
                this.BindingContext = new { err = "" };

                Application.Current.Properties["userid"] = userid;
                Application.Current.Properties["pass"] = password;
                Application.Current.Properties["username"] = username;
                Application.Current.Properties["birthday"] = birthday;
                Application.Current.Properties["email"] = email;

                Application.Current.MainPage = new MainPage();
            }
            else
            {
                //エラー文は適当
                this.BindingContext = new { err = "全ての項目を入力してください。" };
            }


        }
    }
}
