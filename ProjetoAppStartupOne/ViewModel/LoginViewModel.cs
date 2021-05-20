using ProjetoAppStartupOne.Services;
using ProjetoAppStartupOne.View;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjetoAppStartupOne.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command cmdLogin { get; set; }
        public Command cmdCreateAccount { get; set; }
        public Command cmdEsqueciMinhaSenha { get; set; }
        public Command cmdSetting { get; set; }

        ILoginService ilog = DependencyService.Get<ILoginService>();
        public LoginViewModel()
        {
            this.cmdLogin = new Command(gotoMainPage);
            this.cmdCreateAccount = new Command(gotoCreateAccountPage);
            this.cmdEsqueciMinhaSenha = new Command(gotoEsqueciSenhaPage);
            this.cmdSetting = new Command(gotoSettingsPage);
        }

        private void gotoSettingsPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }

        private void gotoCreateAccountPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateAccountPage());
        }

        private void gotoEsqueciSenhaPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new EsqueciSenhaPage());
        }

        private void gotoMainPage(object obj)
        {
            if (ilog.Login(Usuario,Senha))
            {
                App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                LoginMessage = "Login inválido.";
                TurnLoginMessage = true;
            }            
        }

        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Usuario"));
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Senha"));
            }
        }

        private string loginMessage;
        public string LoginMessage
        {
            get { return loginMessage; }
            set
            {
                loginMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoginMessage"));
            }
        }

        private bool turnLoginMessage = false;
        public bool TurnLoginMessage
        {
            get { return turnLoginMessage; }
            set
            {
                turnLoginMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TurnLoginMessage"));
            }
        }
    }
}
