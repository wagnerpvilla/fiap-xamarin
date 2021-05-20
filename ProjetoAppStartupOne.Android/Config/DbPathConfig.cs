using System;
using ProjetoAppStartupOne.Config;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProjetoAppStartupOne.Droid.Config.DbPathConfig))]
namespace ProjetoAppStartupOne.Droid.Config
{
    public class DbPathConfig : IDbPathConfig
    {
        private string path;
        public string Path => path ??= Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    }
}