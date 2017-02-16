using Newtonsoft.Json;
using Spotch.Controller;
using Spotch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.View
{
	public partial class HotSpotPage : ContentPage
	{
        private WebSocketClient _webSocket;
        readonly string uri = "ws://kbckj.net:8080/socket/articles/find";
        private Position _current;
        private List<PostModel> _collections;

        public HotSpotPage ()
		{
			InitializeComponent ();


            MyMap.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                        new Position(_current.Latitude, _current.Longitude),
                        Distance.FromMiles(1)
                    )
                );
        }

        void moveToRegion()
        {
        }

        void showPins()
        {
            Task.Run(async () =>
            {
                await Task.Delay(100);

                MyMap.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                        new Position(_current.Latitude, _current.Longitude),
                        Distance.FromMiles(1)
                    )
                );

                foreach (PostModel obj in _collections)
                {
                    Console.WriteLine("message:" + obj.message);
                    // Pinの表示
                    var pin = new Pin()
                    {
                        Label = obj.message,
                        Position = new Position(obj.latitude, obj.longitude)
                    };
                    MyMap.Pins.Add(pin);
                }

            });
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
                    await Task.Run(async () =>
                    {
                        await Task.Delay(150);
                        var json = _webSocket.getJson();
                        Console.WriteLine("List<Post>Json:" + json);
                        TimeLine.Collections = JsonConvert.DeserializeObject<List<PostModel>>(json);
                        this._collections = TimeLine.Collections;
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
        }
    }
}
