
using Spotch.Controller;
using Spotch.Models;
using Spotch.View;
using System;
using Xamarin.Forms;

namespace Spotch
{
    public partial class App : Application
	{
        private ApplicationProperties sessionRepository = null;

        public App ()
		{
			InitializeComponent();
            
            sessionRepository = new ApplicationProperties();

            //端末内に保存するデータはユーザーIDのみ

        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            
            await sessionRepository.LoadAsync();
            //var ua = sessionRepository.GetValue<UserAccount>();
            var id = sessionRepository.LoadID();
            
            if (id != null)
            {
                //ユーザーIDが端末内に有る場合
                //サーバーと通信してユーザー情報を取得後、タイムライン(MainPage)に遷移

                Console.WriteLine("-----ログイン済みユーザーだよ");

                //ここに通信処理

                //返ってきたユーザー情報から端末内保存するクラスに割り当て
                UserAccount user = new UserAccount();

                sessionRepository.SetValue<UserAccount>(user);

                //成功したら画面推移
                Application.Current.MainPage = new MainPage();

            }
            else
            {

                //ユーザーIDが端末内にない場合
                //ログイン画面(TopPage)に遷移

                Console.WriteLine("-----初めてのユーザーだよ");

                Application.Current.MainPage = new TopPage();

            }

        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override  void OnResume ()
		{
            // Handle when your app resumes
        }
	}
}
