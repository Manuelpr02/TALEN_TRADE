using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Database
{
    public class LocalDB
    {
        static SQLiteAsyncConnection db;
        //Método para iniciar la conexión y crear la base de datos y las tablas
        static async Task Init()
        {

            if (db != null) { return; }
            //Se crea
            var databasepath = Path.Combine(FileSystem.AppDataDirectory, "dblocatyfyfyfyf33.db");
            //Se conecta
            db = new SQLiteAsyncConnection(databasepath);
            await db.CreateTableAsync<Usuario>();
        }
        public static async Task<int> AddCliente(string Nombre, string Email, string pasw)
        {
            await Init();
            var user = new Usuario
            {
                nombre = Nombre,
                correo = Email,
                password = pasw
            };
            await db.InsertAsync(user);
            return user.idusario;
        }
        public static async Task<Usuario> GetUsuario(int idus)
        {
            var user = await db.Table<Usuario>().Where(l => l.idusario == idus).FirstOrDefaultAsync();
            return user;
        }

    }
}
