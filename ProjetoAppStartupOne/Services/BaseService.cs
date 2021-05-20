using System;
using System.Collections.Generic;
using System.IO;
using ProjetoAppStartupOne.Config;
using ProjetoAppStartupOne.Model;
using SQLite;
using Xamarin.Forms;

namespace ProjetoAppStartupOne.Services
{
    public class BaseService<T> : IService<T>, IDisposable where T : new()
    {
        private readonly SQLiteConnection dbConnection;

        public BaseService()
        {
            var dbPath = DependencyService.Get<IDbPathConfig>();
            var dbFile = Path.Combine(dbPath.Path, "Usuario.db");
            dbConnection = new SQLiteConnection(dbFile);
            dbConnection.CreateTable<UsuarioNovo>();
        }

        public void Dispose()
        {
            dbConnection.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return dbConnection.Table<T>().ToList();
        }

        public T Insert(T model)
        {
            dbConnection.Insert(model);
            return model;
        }

        public T Update(T model)
        {
            dbConnection.Update(model);
            return model;
        }

        public void Delete(T model)
        {
            dbConnection.Delete(model);
        }

        protected T FindWithQuery(string query, params object[] args)
        {
            return this.dbConnection.FindWithQuery<T>(query, args);
        }

    }
}
