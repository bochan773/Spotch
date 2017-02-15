
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spotch.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms.GoogleMaps;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Text;
using WebSocketSharp;
using System.Collections.Generic;

namespace Spotch.Controller
{
    class WebSocketClient
    {
        private string _strJson;
        private WebSocket _ws;

        public WebSocketClient(string uri)
        {
            using (this._ws = new WebSocket(uri))
            {
                //this._ws.OnMessage += (sender, e) => _strJson = e.Data;
                this._ws.OnMessage += (sender, e) =>
                {
                    _strJson = e.Data;

                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                    Console.Write("recievedData:" + e.Data);
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                };
            }
        }

        public string getJson(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            this._ws.Connect();
            this._ws.Send(json);

            return json;
        }

        public void sendPost(object obj)
        {
            this._strJson = JsonConvert.SerializeObject(obj);
            this._ws.Connect();
            debugJson();
            this._ws.Send(this._strJson);
        }

        public void debugJson()
        {
            this._ws.Connect();
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine(_strJson);
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
        }

        public string getJson()
        {
            return _strJson;
        }

    }
}
