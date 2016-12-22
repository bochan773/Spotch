using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}
        void LoginBtnClicked(object sender, EventArgs args)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            //テスト用にユーザーIDとpassは固定
            if (username == "inada" && password == "pass")
            {
                //this.DisplayAlert("Success", "ログイン成功", "はい");
                this.BindingContext = new { err = "" };
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                this.BindingContext = new { err = "ユーザーが存在しないか、パスワードが間違っています。" };
            }


        }
    }
}
