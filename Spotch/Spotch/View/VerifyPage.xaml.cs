using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class VerifyPage : ContentPage
	{
		public VerifyPage ()
		{
			InitializeComponent ();


            //テスト用に５秒sleep
            //System.Threading.Thread.Sleep(5000);
            sleepAsync();

            Application.Current.MainPage = new MainPage();
        }

        private async void sleepAsync()
        {
            await Task.Delay(5 * 1000);
        }
    }
}
