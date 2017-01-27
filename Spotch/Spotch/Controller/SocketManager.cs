
using SocketIO.Client;
using Spotch.Models;

namespace Spotch.Controller
{
    class SocketManager
    {
        // connect to a Socket.IO server
        private Socket socket = IO.Socket("http://chat.socket.io/");

        void login()
        {
            // connect to a Socket.IO server
            socket.Connect();

            // TODO

            // disconnect from the server
            socket.Close();
        }
        
        void getTimeLine()
        {
            // Connect
            socket.Connect();

            socket.On("find", (data)=>
            {

            });

            // Close
            socket.Close();
        }

        void addPost(Post post)
        {
            // Connect
            socket.Connect();

            var emit_post = Newtonsoft.Json.JsonConvert.SerializeObject(post);
            // Post
            socket.Emit("add user", emit_post);

            // Close
            socket.Close();
        }
    }
}
