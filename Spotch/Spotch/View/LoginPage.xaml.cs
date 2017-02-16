using Spotch.Controller;
using Spotch.Models;
using System;

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
            
            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            
            //情報が入力されているか確認
            if (email.Length!=0 && password.Length!=0)
            {
                //this.DisplayAlert("Success", "ログイン成功", "はい");

                //-------ここで通信処理-------
                //ユーザー情報と位置情報を送る

                //テスト用のnew
                UserAccount us = new UserAccount();
                us.user_id = 24392;

                //ユーザーが存在するか確認
                if (us!=null)
                {
                    //通信成功でユーザー認証成功したとき、タイムラインページに飛ぶ

                    this.BindingContext = new { err = "" };
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    this.BindingContext = new { err = "ユーザーが存在しないか、パスワードが間違っています。" };
                }
            }
            else
            {
                //this.BindingContext = new { err = "ユーザーが存在しないか、パスワードが間違っています。" };
                this.BindingContext = new { err = "ユーザー情報を入力してください。" };
            }
            

            //メールアドレスとパスワードでログイン
            //サーバーから返ってきたユーザー情報から、IDを端末内に保存

            
            this.DisplayAlert("Error!", "現在ログイン機能は使えませんSignUpから入ってください", "はい");
            Application.Current.MainPage = new TopPage();
            
        }
    }
}
