using ProjetoAppStartupOne.Model;
using SQLite;
using System.Collections.Generic;

namespace ProjetoAppStartupOne.Services
{
    public class LoginService : BaseService<UsuarioNovo>, ILoginService
    {
        public bool Login(string usuario, string senha)
        {
            try
            {

                var resultado = base.FindWithQuery("SELECT * FROM UsuarioNovo Where Usuario=? AND Senha=?", usuario, senha);
                if (resultado != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SQLiteException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
