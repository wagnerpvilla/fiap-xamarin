using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAppStartupOne.Model
{
    public class UsuarioNovo : UsuarioModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
