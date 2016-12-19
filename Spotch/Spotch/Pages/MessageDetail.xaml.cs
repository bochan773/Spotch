
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Spotch.Pages
{
	public partial class MessageDetail : ContentPage
	{
        public MessageDetail (Post post)
		{
			InitializeComponent ();

            Title = "詳細";

            this.BindingContext = post;

            Debug.WriteLine(post + "が送られました！！！！！！！！！！！！！！！！！！！");

        }
    }
}
