using System.Linq;
using ProjetoAppStartupOne.Model;
using ProjetoAppStartupOne.Resources;
using ProjetoAppStartupOne.Services;
using Xamarin.Forms;

namespace ProjetoAppStartupOne.ViewModel
{
    public class EditAccountViewModel : BaseViewModel
    {
        private readonly UsuarioNovo model;
        private readonly IUsuarioNovoService service;
        private string nome;
        private string telefone;
        private string email;
        private string usuario;
        private string senha;
        private Command salvarCommand;
        private Command deleteCommand;

        public EditAccountViewModel(UsuarioNovo model, IUsuarioNovoService service)
        {
            this.model = model;
            this.service = service;
            this.nome = model.Nome;
            this.telefone = model.Telefone;
            this.email = model.Email;
            this.usuario = model.Usuario;
            this.senha = model.Senha;
        }

        public string Nome { get => nome; set => SetProperty(ref nome, value); }
        public string Telefone { get => telefone; set => SetProperty(ref telefone, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Usuario { get => usuario; set => SetProperty(ref usuario, value); }
        public string Senha { get => senha; set => SetProperty(ref senha, value); }

        public Command SalvarCommand
        {
            get => salvarCommand = salvarCommand ?? new Command(async () =>
            {
                try
                {

                    var requiredFields = new[] { nameof(this.Nome), nameof(this.Usuario), nameof(this.Senha) };
                    var props = this.GetType().GetProperties().ToDictionary(p => p.Name, p => p);
                    foreach (var field in requiredFields)
                    {
                        var value = props[field].GetValue(this) as string;
                        if (string.IsNullOrEmpty(value))
                        {
                            await DisplayAlert("Sistema", $"Informar {field}", "Ok");
                            return;
                        }
                    }

                    this.service.Update(new UsuarioNovo()
                    {
                        Id = this.model.Id,
                        Email = this.email,
                        Nome = this.nome,
                        Senha = this.senha,
                        Telefone = this.telefone,
                        Usuario = this.usuario,
                    });

                    MessagingCenter.Send(string.Empty, Constants.EVENT_REFRESH_LIST);
                    await GoBackAsync();

                }
                catch
                {
                    await DisplayAlert("Sistema", "Erro ao editar conta", "Ok");
                }

            });
        }

        public Command DeleteCommand
        {
            get => deleteCommand = deleteCommand ?? new Command(async () =>
            {

                try
                {
                    this.service.Delete(this.model);

                    MessagingCenter.Send(string.Empty, Constants.EVENT_REFRESH_LIST);
                    await GoBackAsync();
                }
                catch
                {
                    await DisplayAlert("Sistema", "Erro ao excluir conta", "Ok");
                }
            });
        }

        public override void Dispose()
        {

        }
    }
}
