
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

            Position position = new Position(post.latitude, post.longitude);

            if (position != null)
            {
                MyMap.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                        new Position(post.latitude,post.longitude), 
                        Distance.FromMiles(1)
                    )
                );

                // Pinの表示
                var pin = new Pin()
                {
                    Label = post.content,
                    Position = position
                };
                MyMap.Pins.Add(pin);
            }
            else
            {
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(_location, Distance.FromMiles(1)));
            }
            
            this.BindingContext = post;
        }
    }
}
