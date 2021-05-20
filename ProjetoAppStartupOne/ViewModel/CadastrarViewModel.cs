using ProjetoAppStartupOne.Model;
using ProjetoAppStartupOne.Services;
using ProjetoAppStartupOne.View;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjetoAppStartupOne.ViewModel
{
    public class CadastrarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command cmdCadastrar { get; set; }
        IUsuarioNovoService icadastrar = DependencyService.Get<IUsuarioNovoService>();
        UsuarioNovo usuarioNovo = new UsuarioNovo();
        public CadastrarViewModel()
        {
            this.cmdCadastrar = new Command(gotoLoginPage);
        }

        private void gotoLoginPage(object obj)
        {            
            usuarioNovo.Nome = Nome;
            usuarioNovo.Telefone = Telefone;
            usuarioNovo.Email = Email;
            usuarioNovo.Usuario = Usuario;
            usuarioNovo.Senha = Senha;
            if (usuarioNovo.Nome != null && usuarioNovo.Usuario != null && usuarioNovo.Senha != null )
            {
                try
                {
                    var usuarioWithId = icadastrar.Insert(usuarioNovo);
                    App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                catch (Exception ex)
                {
                    CadastroMensagem = ex.Message;
                    TurnCadastroMessage = true;
                }                
            }   
            else
            {
                CadastroMensagem = "Erro no cadastro.";
                TurnCadastroMessage = true;
            }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nome"));
            }
        }

        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set
            {
                telefone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Telefone"));
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
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

        private string cadastroMensagem;
        public string CadastroMensagem
        {
            get { return cadastroMensagem; }
            set
            {
                cadastroMensagem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CadastroMensagem"));
            }
        }

        private bool turnCadastroMessage = false;
        public bool TurnCadastroMessage
        {
            get { return turnCadastroMessage; }
            set
            {
                turnCadastroMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TurnCadastroMessage"));
            }
        }
    }
}
