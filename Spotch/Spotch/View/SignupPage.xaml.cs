using Spotch.Controller;
using Spotch.Models;
using System;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class SignupPage : ContentPage
	{
        private ApplicationProperties sessionRepository = null;

        public SignupPage ()
		{
			InitializeComponent ();

            //sessionRepository.SetValue<UserAccount>(new UserAccount());
            sessionRepository = new ApplicationProperties();
        }

        async void SignupBtnClicked(object sender, EventArgs args)
        {
            
            string uname = username.Text;
            string pass = password.Text;
            string mail = email.Text;
            DateTime birth = birthday.Date;
            
            //ユーザー情報が全部の項目入力されているかチェック
            if (uname.Length != 0 && pass.Length != 0 && mail.Length != 0)
            {   
                //入力されていたらそのデータを取得してUserクラスを作る
                UserAccount ua = new UserAccount();
                
                ua.username = uname;
                ua.password = pass;
                ua.birthday = birth;
                ua.email = mail;

                bool check = IsValidMailAddress(mail);
                if (check)
                {

                    //１発でクラスにあてはめれるようなものがあればいいな…
                    //ua = UserEntry.BindingContext as UserAccount;
                    //ua.birthday = birth;
                    //これでうまくいきそうだけどbirthdayのbindingが分からない？

                    Console.WriteLine("uaの内容" + ua.username + "::" + ua.password + "::" + ua.email + "::" + ua.birthday);

                    //ここに通信処理
                    //アカウント作成依頼
                    //通信に成功した場合、サーバから返却されたユーザーIDと共に端末内にユーザー情報保存

                    this.sessionRepository.SetValue<UserAccount>(ua);

                    bool flg = await this.sessionRepository.SaveAsync();

                    if (flg)
                    {
                        Console.WriteLine("Saveされたよ");
                    }
                    else
                    {
                        Console.WriteLine("失敗じゃないかな");
                    }

                    await this.DisplayAlert("Success", "アカウント作成成功", "はい");
                    //Application.Current.MainPage = new MainPage();
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    this.BindingContext = new { err = "メールアドレスを正しく入力してください。" };
                }

            }
            else
            {
                //エラー文は適当
                this.BindingContext = new { err = "全ての項目を入力してください。" };
            }


        }

        /// <summary>
        /// 指定された文字列がメールアドレスとして正しい形式か検証する
        /// </summary>
        /// <param name="mail">検証する文字列</param>
        /// <returns>正しい時はTrue。正しくない時はFalse。</returns>
        private bool IsValidMailAddress(string mail)
        {
            try
            {
                System.Net.Mail.MailAddress a = new System.Net.Mail.MailAddress(mail);
            }
            catch (FormatException e)
            {
                return false;
            }
            return true;
        } 

        //利用規約ページをモーダルで出す
        void AUPTap(object sender, EventArgs args)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await Navigation.PushModalAsync(new AcceptableUsePolicyPage(), false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
        }
    }
}
