﻿using Spotch.Controller;
using Spotch.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.View
{
    public partial class PostPage : ContentPage
	{
        ObservableCollection<Post> posts = new ObservableCollection<Post>();
        Position current;


        public PostPage(ObservableCollection<Post> posts)
        {
            InitializeComponent();
            Title = "Post";

            this.posts = posts;
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(35, 139), Distance.FromMiles(1)));
            getCurrent();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(current, Distance.FromMiles(1)));
        }

        /*
        public PostPage(ObservableCollection<Post> posts, Position current)
        {
            InitializeComponent();
            Title = "Post";

            this.posts = posts;
            this.current = current;
            //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(this.current, Distance.FromMiles(1)));
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(current, Distance.FromMiles(1)));
        }
        */


        async void getCurrent()
        {
            GeoManager gm = new GeoManager();
            current = await gm.getCurrent();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(current, Distance.FromMiles(1)));
        }

        async void OnSendTapped(object sender, EventArgs args)
        {
            // exit
            if (textInput.Text == null && textInput.Text.Length == 0)
            {
                return;
            }

            if (current.Latitude != 0 && current.Longitude != 0 ) {
                // Post
                posts.Add(new Post
                {
                    message = textInput.Text,
                    time = DateTime.Now,
                    position = current
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