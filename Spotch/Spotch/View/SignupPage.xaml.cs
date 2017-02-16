using Newtonsoft.Json;
using Spotch.Controller;
using Spotch.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spotch.View
{
	public partial class SignupPage : ContentPage
	{
        private ApplicationProperties _sessionRepository = null;
        private WebSocketClient _webSocket;
        private string uri = "ws://kbckj.net:8080/socket/user/signup";

        public SignupPage ()
		{
			InitializeComponent ();

            //sessionRepository.SetValue<UserAccount>(new UserAccount());
            _sessionRepository = new ApplicationProperties();
            _webSocket = new WebSocketClient(uri);
        }

        void SignupBtnClicked(object sender, EventArgs args)
        {
            
            string uname = username.Text;
            string pass = password.Text;
            string mail = email.Text;
            DateTime birth = birthday.Date;
            
            //ユーザー情報が全部の項目入力されているかチェック
            if (uname.Length != 0 && pass.Length != 0 && mail.Length != 0)
            {   
                //入力されていたらそのデータを取得してUserクラスを作る
                UserAccount ua = new UserAccount
                {
                    userName = uname,
                    password = pass,
                    birthday = birth,
                    email = mail
                };
               

                bool check = IsValidMailAddress(mail);
                if (check)
                {

                    Console.WriteLine("uaの内容" + ua.userName + "::" + ua.password + "::" + ua.email + "::" + ua.birthday);

                    Device.BeginInvokeOnMainThread(async () =>
                    { 
                        //サーバーに送る
                        await _webSocket.sendObject(ua);


                        await Task.Run(async () =>
                        {
                            await Task.Delay(300);
                            var json = _webSocket.getJson();
                            var obj = JsonConvert.DeserializeObject<SignupModel>(json);

                            Console.WriteLine("戻ってきたデータuserid:"+obj.userId+":::::::result:"+obj.result);

                            if (!obj.result)
                            {
                                return;
                            }
                            
                                //サーバから返却されたユーザーIDと共に端末内にユーザー情報保存

                                var userid = obj.userId;
                                ua.userId = userid;
                                _sessionRepository.SaveID(userid);

                                this._sessionRepository.SetValue<UserAccount>(ua);

                                bool flg = await this._sessionRepository.SaveAsync();
                                //await this.DisplayAlert("Success", "アカウント作成成功", "はい");
                                //Application.Current.MainPage = new MainPage();
                                
                                Console.WriteLine("アカウント作成に成功だよ！");
                        });

                        Application.Current.MainPage = new MainPage();
                    });
                    
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


        /*ごみ
         * Device.BeginInvokeOnMainThread(async () =>
                    { 
                        //サーバーに送る
                        await _webSocket.sendObject(ua);


                        await Task.Run(async () =>
                        {
                            await Task.Delay(200);
                            var json = _webSocket.getJson();
                            var obj = JsonConvert.DeserializeObject<SignupModel>(json);

                            Console.WriteLine("戻ってきたデータuserid:"+obj.userId+":::::::result:"+obj.result);

                            if (obj.result)
                            {
                                //サーバから返却されたユーザーIDと共に端末内にユーザー情報保存

                                var userid = obj.userId;
                                ua.userId = userid;
                                _sessionRepository.SaveID(userid);

                                this._sessionRepository.SetValue<UserAccount>(ua);

                                bool flg = await this._sessionRepository.SaveAsync();

                                if (flg)
                                {
                                    Console.WriteLine("Saveされたよ");
                                }
                                else
                                {
                                    Console.WriteLine("失敗じゃないかな");
                                }

                                //await this.DisplayAlert("Success", "アカウント作成成功", "はい");
                                //Application.Current.MainPage = new MainPage();
                                Application.Current.MainPage = new UserProfilePage();
                                Console.WriteLine("アカウント作成に成功だよ！");
                            }
                            else
                            {
                                Console.WriteLine("アカウント作成に失敗したよ");
                                this.BindingContext = new { err = "アカウントの作成に失敗しました。" };
                            }
                        });
                    });
         */
    }
}
