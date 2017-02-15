
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spotch.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms.GoogleMaps;
using System.Threading.Tasks;
//using WebSocket4Net;
using System;

namespace Spotch.Controller
{
    class WebSocketClient2
    {
        /*
        private WebSocket _websocket;
        private string _strJson;
        private ObservableCollection<Post> _timeline = ObservableCollectionSerializable<Post>.GetInstance;
        private Position _current;

        public WebSocketClient2(string uri)
        {
            this._websocket = new WebSocket(uri);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Connecting to:" + uri);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            //_websocket.Opened += new EventHandler(websocket_Opened);
            this._websocket.Opened           += new EventHandler((sender, e) => websocket_Opened(sender, e, this._strJson));
            this._websocket.Error            += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocket_Error);
            this._websocket.Closed           += new EventHandler(websocket_Closed);
            this._websocket.MessageReceived  += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
        }

        public void addPost(Post post)
        {
            this._strJson = JsonConvert.SerializeObject(post);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("post:" + _strJson);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            this._websocket.Open();
        }

        public void websocket_Opened(object sender, EventArgs e, string message)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Success websocket opened:" + message);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            this._websocket.Send(message);
        }

        public void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Error thrown trying to open websocket:" + e.Exception.Message);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }

        public void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Websocket closed");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }

        public void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(e.Message);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }


        async void getCurrent()
        {
            GeoManager gm = new GeoManager();
            this._current = await gm.getCurrent();
        }
        */

        /*
        private Socket socket = IO.Socket("http://kbckj.net:8080/socket");

        void login()
        {
            // connect to a Socket.IO server
            socket.Connect();

            // TODO

            // disconnect from the server
            socket.Close();
        }

        async void getCurrent()
        {
            GeoManager gm = new GeoManager();
            _current = await gm.getCurrent();
        }

        public void getTimeLine()
        {
            // Connect
            socket.Connect();

            getCurrent();

            string position = 
                "{latitude:" + _current.Latitude + 
                ",longtitude:" + _current.Longitude + 
                ",range:" + 50 + 
                "}";

            socket.Emit("articles/find",position);

            socket.On("result/find", (data)=>
            {
                object o = (object)data;
                var jobject = o as JToken;
                var sobject = (string)jobject;

                var post = JsonConvert.DeserializeObject<Post>(sobject);
                _timeline.Add(post);
            });
            
            // Close
            socket.Close();
        }
        

        public void addPost(Post post)
        {
            // Connect
            socket.Connect();

            var emit_post = JsonConvert.SerializeObject(post);

            socket.Emit("articles/test", "よろしく");
            // Post
            socket.Emit("articles/create", emit_post);

            // Close
            socket.Close();
        }
        */
    }
}
