
using Spotch.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.View
{
    public partial class MessageDetail : ContentPage
	{
        public Position location = new Position(35.6691088, 139.6012966);　// Default Location : Tokyo

        public MessageDetail(Post post)
        {
            InitializeComponent();
            Title = "詳細";

            if (post.position != null)
            {
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(post.position, Distance.FromMiles(1)));

                // Pinの表示
                var pin = new Pin()
                {
                    Label = post.text,
                    Position = post.position
                };
                MyMap.Pins.Add(pin);
                
            }
            else
            {
                post.position = location;
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(1)));
            }
            

            this.BindingContext = post;
        }
    }
}
