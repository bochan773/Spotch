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



                posts.Add(new Post
                {
                    text = textInput.Text,
                    time = DateTime.Now
                });

                textInput.Text = "";
            }
        }
    }
}
