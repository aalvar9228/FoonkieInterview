using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoonkieInterview.Views.Reusable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInfoView : ContentView
    {
        public UserInfoView()
        {
            InitializeComponent();
        }
    }
}