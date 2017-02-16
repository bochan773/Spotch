using Newtonsoft.Json;
using Spotch.Controller;
using Spotch.Models;
using System;
using System.Collections.Generic;
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
        //List<Post> _timeline = TimeLine.Collections;
        
        readonly string uri = "ws://kbckj.net:8080/socket/articles/find";
        private Position _current;

        public TimeLinePage()
        {
            InitializeComponent();
            Title = "TimeLine";
                        
            loadTimeLine();
            messageView.ItemsSource = TimeLine.Collections;
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
        async Task getCurrent()
        {
            GeoManager gm = new GeoManager();
            _current = await gm.getCurrent();
        }

        void loadTimeLine()
        {
            _webSocket = new WebSocketClient(uri);
            /*
            var jsonTest = @"[{
                                ""postId"":1422,
                                ""userId"":1,
                                ""latitude"":33.8343396,
                                ""longitude"":132.7660037,
                                ""content"":""あいうえお"",
                                ""createAt"":""2017-02-15 18:20:57""
                             },
                             {
                                ""postId"":1424,
                                ""userId"":2,
                                ""latitude"":33.8343396,
                                ""longitude"":132.7660037,
                                ""content"":""かきくけこ"",
                                ""createAt"":""2017-02-15 18:23:27""
                            　},
{
                                ""postId"":1425,
                                ""userId"":3,
                                ""latitude"":33.8343396,
                                ""longitude"":132.7660037,
                                ""content"":""さしすせそ"",
                                ""createAt"":""2017-02-15 18:24:27""
                            　}
                            ]";
            */

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
                       TimeLine.Collections = JsonConvert.DeserializeObject<List<Post>>(json);
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
