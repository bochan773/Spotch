using Spotch.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Spotch.View
{
    public partial class TimeLinePage : ContentPage
	{
        ObservableCollection<Post> _timeline = ObservableCollectionSerializable<Post>.GetInstance;
        Xamarin.Forms.GoogleMaps.Position _p = new Xamarin.Forms.GoogleMaps.Position(0,0);

        public TimeLinePage()
        {
            InitializeComponent();
            Title = "TimeLine";
            messageView.ItemsSource = _timeline;       
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

        void OnPostTapped(object sender, EventArgs args)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await Navigation.PushModalAsync(new PostPage(), false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
        }
    }
}
