using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS1Intelligence.Forms.TestApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : TabbedPage
    {
        public Main()
        {
            InitializeComponent();
            Children.Add(new ErrorPage());
            Children.Add(new NetworkPage());
            Children.Add(new UserflowPage());
            Children.Add(new OthersPage());
        }
    }
}
