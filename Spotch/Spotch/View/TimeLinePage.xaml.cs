using Spotch.Controller;
using Spotch.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Spotch.View
{
    public partial class TimeLinePage : ContentPage
	{
        ObservableCollection<Post> posts = new ObservableCollection<Post>();

        public TimeLinePage()
        {
            InitializeComponent();
            Title = "TimeLine";
            messageView.ItemsSource = posts;
        }

        /*
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
                Xamarin.Forms.GoogleMaps.Position p = await gm.getCurrent();

                // Submit Post
                posts.Add(new Post { text = textInput.Text,
                                     position = p,
                                     time = DateTime.Now
                });

                textInput.Text = "";
            }
        }*/


        void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            Post post = args.Item as Post;

            Navigation.PushAsync(new MessageDetail(post), true);

            /* text code
            var p = new Post { text = "Kawahara", position = new Position(33.834255, 132.765942) };
            Navigation.PushAsync(new MessageDetail(p), true);*/
        }

        async void OnPostTapped(object sender, EventArgs args)
        {
            //GeoManager gm = new GeoManager();
            //var current = await gm.getCurrent();
            await Navigation.PushModalAsync(new PostPage(posts), false);
        }
    }
}
