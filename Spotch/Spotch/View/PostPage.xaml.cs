using Spotch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.View
{
	public partial class PostPage : ContentPage
	{
        ObservableCollection<Post> posts = new ObservableCollection<Post>();

        public PostPage()
        {
            InitializeComponent();
        }

        public PostPage (ObservableCollection<Post> posts)
		{
			InitializeComponent ();
            Title = "Post";

            this.posts = posts;
            //messageView.ItemsSource = posts;
        }

        async void OnSendTapped(object sender, EventArgs args)
        {
            if (textInput.Text == null)
            {
                textInput.Text = "";
            }
            if (textInput.Text.Length != 0)
            {
                // Current Location
                Controller.GeoManager gm = new Controller.GeoManager();
                // Cast Geolocator.Abstruction.Position -> GoogleMaps.Position
                // Xamarin.Forms.GoogleMaps.Position p = gm.getCurrentLocation();
                Xamarin.Forms.GoogleMaps.Position p = await gm.getCurrent();

                // Post
                posts.Add(new Post
                {
                    message = textInput.Text,
                    time = DateTime.Now,
                    position = p
                });

                textInput.Text = "";

                // close
                await Navigation.PopModalAsync(false);
            }
        }

        async void closePage(object sender, EventArgs args)
        {
            var result = await DisplayAlert("Close", "閉じてもいいですか？", "OK", "キャンセル");

            if (result == true) {
                // close
                await Navigation.PopModalAsync(false);
            }
        }
    }
}
