using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Spotch.Pages
{
    public partial class TimeLinePage : ContentPage
	{
        ObservableCollection<Post> posts = new ObservableCollection<Post>();
        public TimeLinePage ()
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
                posts.Add(new Post { text = textInput.Text, time = DateTime.Now });
                textInput.Text = "";
            }
        }

        void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            Post post = args.Item as Post;

            Navigation.PushAsync(new MessageDetail(post), true);
            //SendSample
            //Navigation.PushAsync(new MessageDetail(new Post { text="Inada" }), true);

        }
    }
}
