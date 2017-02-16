
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
                    this._strJson = e.Data;
                };
                
            }
        }
        
        /*
        public void sendObject(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            this._ws.Connect();
            this._ws.Send(json);
        }
        */

        public async Task sendObject(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            this._ws.Connect();
            this._ws.Send(json);

            await Task.Delay(200);
        }

        public string getJson()
        {
            return _strJson;
        }
        
        public void debugJson()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine(_strJson);
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
        }
    }
}
