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

            if (Application.Current.Properties.ContainsKey("userid"))
            {
                var userid = Application.Current.Properties["userid"] as string;
                var pass = Application.Current.Properties["pass"] as string;
                // do something with id

                useridEntry.Text = userid;
                passwordEntry.Text = pass;
            }
        }
        void LoginBtnClicked(object sender, EventArgs args)
        {
            string userid = useridEntry.Text;
            string password = passwordEntry.Text;

            //テスト用にユーザーIDとpassは固定
            if (userid == "inada" && password == "pass")
            {
                //this.DisplayAlert("Success", "ログイン成功", "はい");
                this.BindingContext = new { err = "" };
                
                
                Application.Current.Properties["userid"] = userid;
                Application.Current.Properties["pass"] = password;
                Application.Current.Properties["username"] = "Inada Natsumi";
                Application.Current.Properties["birthday"] = "1995/09/06";
                Application.Current.Properties["email"] = "xxx@xx.xx.xx";

                Application.Current.MainPage = new MainPage();
            }
            else if (userid == "doi" && password == "pass")
            {
                //テスト用 本番ではいらないelseif
                this.BindingContext = new { err = "" };

                Application.Current.Properties["userid"] = userid;
                Application.Current.Properties["pass"] = password;
                Application.Current.Properties["username"] = "Doi Kosuke";
                Application.Current.Properties["birthday"] = "1995/07/03";
                Application.Current.Properties["email"] = "yyy@yy.yy.yy";

                Application.Current.MainPage = new MainPage();
            }
            else
            {
                this.BindingContext = new { err = "ユーザーが存在しないか、パスワードが間違っています。" };
            }


        }
    }
}
