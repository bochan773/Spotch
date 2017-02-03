
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocketIO.Client;
using Spotch.Models;

namespace Spotch.Controller
{
    class SocketManager
    {
        // connect to a Socket.IO server
        private Socket socket = IO.Socket("http://kbckj.net:8080/socket");

        void login()
        {
            // connect to a Socket.IO server
            socket.Connect();

            // TODO

            // disconnect from the server
            socket.Close();
        }
        
        /*
        ObservableCollectionSerializable<Posts> getTimeLine()
        {
            ObservableCollectionSerializable timeline = new ObservableCollectionSerializable();
            // Connect
            socket.Connect();

            socket.Emit("articles/find");

            socket.On("result/find", (data)=>
            {
                object o = (object)data;
                var jobject = o as JToken;
                var sobject = (string)jobject;

                timeline = JsonConvert.DeserializeObject<ObservableCollectionSerializable>(sobject);
            });
            
            // Close
            socket.Close();

            return timeline;
        }
        */

        public void addPost(Post post)
        {
            // Connect
            socket.Connect();

            var emit_post = JsonConvert.SerializeObject(post);
            // Post
            socket.Emit("add user", emit_post);

            // Close
            socket.Close();
        }
    }
}
