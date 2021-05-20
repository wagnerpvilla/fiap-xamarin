using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ProjetoAppStartupOne.Model;
using ProjetoAppStartupOne.Resources;
using ProjetoAppStartupOne.Services;
using ProjetoAppStartupOne.View;
using Xamarin.Forms;

namespace ProjetoAppStartupOne.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IUsuarioNovoService service;
        private IEnumerable<UsuarioNovo> usuarios;
        private UsuarioNovo usuarioSelecionado;
        private Command selectionCommand;

        public MainPageViewModel()
        {
            this.service = DependencyService.Get<IUsuarioNovoService>();
            this.Usuarios = this.CarregarUsuarios();

            MessagingCenter.Subscribe(this, Constants.EVENT_REFRESH_LIST, (string _) =>
            {
                this.Usuarios = this.CarregarUsuarios();
                this.usuarioSelecionado = null;
            });

        }

        public IEnumerable<UsuarioNovo> Usuarios
        {
            get => usuarios;
            set => SetProperty(ref usuarios, value);
        }

        public UsuarioNovo UsuarioSelecionado
        {
            get => usuarioSelecionado;
            set => SetProperty(ref usuarioSelecionado, value);
        }

        public Command SelectionCommand
        {
            get => selectionCommand = selectionCommand ?? new Command(async () =>
            {
                var page = new EditAccountPage(new EditAccountViewModel(this.UsuarioSelecionado, this.service));
                await base.PushAsync(page);
            });
        }

        public override void Dispose()
        {
            MessagingCenter.Unsubscribe<string>(this, Constants.EVENT_REFRESH_LIST);
        }

        private IEnumerable<UsuarioNovo> CarregarUsuarios()
            => new ObservableCollection<UsuarioNovo>(this.service.GetAll());
    }
}
