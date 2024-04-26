using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace ProyectoFinal.Database
{
    public class Usuario
    {
        [PrimaryKey,AutoIncrement]
        public int idusario {  get; set; }
        public string nombre { get; set; }
         public string correo { get; set; }
        public string password { get; set; }
        public string ciudad {  get; set; }
        public string color { get; set; }
        public string edad { get; set; }
    }
}
