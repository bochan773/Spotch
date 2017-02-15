using Newtonsoft.Json;
using Spotch.Controller;
using Spotch.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.View
{
    class Message
    {
        [JsonProperty(PropertyName = "latitude")]
        public double latitude { set; get; }

        [JsonProperty(PropertyName = "longitude")]
        public double longitude { set; get; }

        [JsonProperty(PropertyName = "range")]
        public int range { set; get; }
    }

    public partial class TimeLinePage : ContentPage
	{
        WebSocketClient _webSocket;
        ObservableCollection<Post> _timeline = ObservableCollectionSerializable<Post>.GetInstance;
        Xamarin.Forms.GoogleMaps.Position _p = new Xamarin.Forms.GoogleMaps.Position(0,0);

        string uri = "ws://kbckj.net:8080/socket/articles/find";
        private Position _current;

        public TimeLinePage()
        {
            InitializeComponent();
            Title = "TimeLine";
            messageView.ItemsSource = _timeline;


            loadTimeLine();
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
        async void getCurrent()
        {
            GeoManager gm = new GeoManager();
            _current = await gm.getCurrent();
        }

        void loadTimeLine()
        {
            _webSocket = new WebSocketClient(uri);

            getCurrent();
            var msg = new Message
            {
                latitude = _current.Latitude,
                longitude = _current.Longitude,
                range = 5000
            };

            var json = _webSocket.getJson(msg);

            // json to List<Post>
            var result = JsonConvert.DeserializeObject<Post>(json);
            _timeline.Add(result);
        }

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

        void OnLoadTapped(object sender, EventArgs args)
        {
            loadTimeLine();
        }
    }
}
