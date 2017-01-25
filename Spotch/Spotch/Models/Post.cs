
using System;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.Models
{
    public class Post
    {
        public string text { get; set; }
        public Position position { get; set; }
        public DateTime time { get; set; }
    }
}