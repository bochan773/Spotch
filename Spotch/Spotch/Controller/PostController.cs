/* Socket.IO Client .NET についてチュートリアル記載ページ
 * https://components.xamarin.com/view/socketioclientdotnet
 * json.net
 * https://www.nuget.org/packages/Newtonsoft.Json/
 * json.net 使い方
 * http://qiita.com/ta-yamaoka/items/a7ff1d9651310ade4e76
 */

using SocketIO.Client;

public class PostController
{
    static void Main()
    {
        /*
        // connect to a Socket.IO server
        var socket = IO.Socket("http://chat.socket.io/");
        bool connected = socket.Connect();

        // whenever the server emits "new message", update the chat body
        //サーバーが「新しいメッセージ」を発行するたびに、チャット本体を更新します
        socket.On("new message", data => {
            // get the json data from the server message
            //サーバーメッセージからjsonデータを取得する
            var jobject = data as JToken;

            // get the message data values
            var username = jobject.Value<string>("username");
            var message = jobject.Value<string>("message");

            // display message...
        });


        // we can send messages to the server
        //サーバーにメッセージを送信できます
        socket.Emit("add user", "username");
        if (connected)
        {
            socket.Emit("new message", "This is a message from Xamarin.Android...");
        }

        // or we can just send events
        //または単にイベントを送信することができます
        socket.Emit("typing");
        // cancel that typing event
        //そのタイピングイベントをキャンセルする
        socket.Emit("stop typing");

        // disconnect from the server
        socket.Close();

    */

    }
}