using Spotch.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Spotch.View
{
    public partial class TimeLinePage : ContentPage
	{
        ObservableCollection<Post> timeline = ObservableCollectionSerializable<Post>.GetInstance;
        Xamarin.Forms.GoogleMaps.Position p = new Xamarin.Forms.GoogleMaps.Position(0,0);
        public TimeLinePage()
        {
            InitializeComponent();
            Title = "TimeLine";
            messageView.ItemsSource = timeline;            
        }

        /*
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy == value)
                    return;

                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        */

        void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            Post post = args.Item as Post;

            Navigation.PushAsync(new MessageDetail(post), true);
        }

        async void OnPostTapped(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new PostPage(), false);
        }
    }
}
