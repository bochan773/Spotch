using Spotch.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

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

        
        void OnSendTapped(object sender, EventArgs args)
        {
            if (textInput.Text == null)
            {
                textInput.Text = "";
            }
            if (textInput.Text.Length != 0)
            {
                //var lm = new Controller.GeoManager();
                //var p = new Position(lm.position.Latitude, lm.position.Longitude);
                //position = new double[] { p.Latitude, p.Longitude }



                posts.Add(new Post { text = textInput.Text,
                                     time = DateTime.Now
                });

                textInput.Text = "";
            }
        }


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
            await Navigation.PushModalAsync(new PostPage(posts));
        }
    }
}
