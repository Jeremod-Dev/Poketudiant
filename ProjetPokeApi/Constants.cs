using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjetPokeApi
{
    public static class Constants
    {
        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // Comment acceder à la BDD
            SQLite.SQLiteOpenFlags.ReadWrite |
            //Si pas inexistante go la creer
            SQLite.SQLiteOpenFlags.Create |
            // activation du multi-threading
            SQLite.SQLiteOpenFlags.SharedCache;

        // Recupere le chemin d'acces à la BDD
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
