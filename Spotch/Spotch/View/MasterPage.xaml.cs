using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class MasterPage : ContentPage
	{		
        public MasterPage ()
		{
			InitializeComponent ();

            usernameText.Text = Application.Current.Properties["username"] as string;
            emailText.Text = Application.Current.Properties["email"] as string;
        }

        // Detailページを画面遷移させるメソッド 
        void Navigate<P>() where P : Page, new()
        {
            // MainPageオブジェクトを取り出す 
            var mainPage = this.Parent as MainPage;
            // MainPageのDetailセクションに入っているページオブジェクトを取り出す 
            var detail = mainPage.Detail;
            if (detail.Navigation.NavigationStack.LastOrDefault() is P)
                return; //現在表示中と同じページなら、画面遷移しない 

            // 画面遷移する 
            detail.Navigation.PushAsync(new P(), true);
            // メニューを閉じる 
            mainPage.IsPresented = false;
        }

        // イベントハンドラー 
        protected void TimeLine_Tapped(object sender, EventArgs e)
          => Navigate<TimeLinePage>();
        protected void UserProfile_Tapped(object sender, EventArgs e)
          => Navigate<UserProfilePage>();
    }
}
