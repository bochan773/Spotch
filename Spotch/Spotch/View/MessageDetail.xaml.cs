
using Spotch.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.View
{
    public partial class MessageDetail : ContentPage
	{
        public Position _location = new Position(35, 139);　// Default Location : Tokyo

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
                    Label = post.message,
                    Position = post.position
                };
                MyMap.Pins.Add(pin);
            }
            else
            {
                post.position = _location;
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(_location, Distance.FromMiles(1)));
            }
            
            this.BindingContext = post;
        }
    }
}
