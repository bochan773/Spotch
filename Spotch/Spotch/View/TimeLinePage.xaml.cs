using Newtonsoft.Json;
using Spotch.Controller;
using Spotch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private WebSocketClient _webSocket;
        private readonly string uri = "ws://kbckj.net:8080/socket/articles/find";
        private Position _current;

        public TimeLinePage()
        {
            InitializeComponent();
            Title = "TimeLine";
                        
            loadTimeLine();
            messageView.ItemsSource = TimeLine.Collections;

            
            /*
            RefreshCommand = new Command( (nothing) => {
                loadTimeLine();
                // Binding機構経由でListViewのIsRefreshingプロパティも変更する
                IsRefreshing = false;
            },
                // ICommand.CanExecuteにもバインドしたプロパティを利用できる
                (nothing) => !IsRefreshing
            );
            */
            
        }

        // ListViewを引っ張った時に実行させるコマンド
        public ICommand RefreshCommand
        {
            get;
            private set;
        }
        // ListView.IsRefreshingと同期させるプロパティ
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                if (value == isRefreshing)
                    return;
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        

        async Task getCurrent()
        {
            GeoManager gm = new GeoManager();
            _current = await gm.getCurrent();
        }

        void loadTimeLine()
        {
            _webSocket = new WebSocketClient(uri);

            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await getCurrent();

                    var msg = new Message
                    {
                        latitude = _current.Latitude,
                        longitude = _current.Longitude,
                        range = 100
                    };

                    await _webSocket.sendObject(msg);
                    await Task.Run(async() =>
                   {
                       await Task.Delay(200);
                       var json = _webSocket.getJson();
                       Console.WriteLine("List<Post>Json:" + json);
                       TimeLine.Collections = JsonConvert.DeserializeObject<List<PostModel>>(json);

                       messageView.ItemsSource = TimeLine.Collections;
                   });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
        }

        void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            PostModel post = args.Item as PostModel;

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
