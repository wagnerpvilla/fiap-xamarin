using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAppStartupOne.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoAppStartupOne.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAccountPage : ContentPage
    {
        public EditAccountPage(EditAccountViewModel editAccountViewModel)
        {
            InitializeComponent();
            BindingContext = editAccountViewModel;
        }
    }
}