using System;
using ProjetoAppStartupOne.Config;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProjetoAppStartupOne.iOS.Config.DbPathConfig))]
namespace ProjetoAppStartupOne.iOS.Config
{
    internal class DbPathConfig : IDbPathConfig
    {
        private string path;
        public string Path
        {
            get
            {
                if (string.IsNullOrEmpty(path))
                {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    path = System.IO.Path.Combine(path, "..", "Library");
                }
                return path;
            }
        }
    }
}