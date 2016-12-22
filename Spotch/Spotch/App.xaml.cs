
using Xamarin.Forms;

namespace Spotch
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new Spotch.View.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
