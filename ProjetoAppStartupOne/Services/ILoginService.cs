using System;
using System.Collections.Generic;
using System.Text;
using ProjetoAppStartupOne.Model;

namespace ProjetoAppStartupOne.Services
{
    public interface ILoginService: IService<UsuarioNovo>
    {
        bool Login(string usuario, string senha);
    }
}
