
using Xamarin.Forms;

namespace Spotch.View
{
    public partial class MessageDetail : ContentPage
	{
        public MessageDetail(Post post)
        {
            InitializeComponent();

            Title = "詳細";

            this.BindingContext = post;
            

        }
    }
}
