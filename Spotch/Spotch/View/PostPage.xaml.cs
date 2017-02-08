using Spotch.Controller;
using Spotch.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.View
{
    public partial class PostPage : ContentPage
	{
        ObservableCollection<Post> _timeline = ObservableCollectionSerializable<Post>.GetInstance;
        Position _current;

        public PostPage()
        {
            InitializeComponent();
            Title = "Post";

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(35, 139), Distance.FromMiles(1)));
            getCurrent();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(_current, Distance.FromMiles(1)));
        }

        async void getCurrent()
        {
            GeoManager gm = new GeoManager();
            _current = await gm.getCurrent();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(_current, Distance.FromMiles(1)));
        }

        async void OnSendTapped(object sender, EventArgs args)
        {
            // exit
            if (textInput.Text == null && textInput.Text.Length == 0)
            {
                return;
            }

            if (_current.Latitude != 0 && _current.Longitude != 0 ) {
                // Post
                /*
                posts.Add(new Post
                {
                    message = textInput.Text,
                    time = DateTime.Now,
                    position = current
                });*/
                

                _timeline.Add(new Post
                {
                    message = textInput.Text,
                    time = DateTime.Now,
                    position = _current
                });

                textInput.Text = "";
                
                // close
                await Navigation.PopModalAsync(false);
            }
            else
            {
                var result = await DisplayAlert("Error", "現在位置がまだ取得できていません。", "OK", "キャンセル");
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
