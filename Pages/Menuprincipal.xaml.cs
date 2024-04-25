using Plugin.CloudFirestore;
using ProyectoFinal.Database;

namespace ProyectoFinal.Pages;

public partial class Menuprincipal : ContentPage
{
    string Usuario, Passw, Correo;
    int ID;

    private void Clicked_btnpublicar(object sender, EventArgs e)
    {

    }

    private void Clicked_btnverofertas(object sender, EventArgs e)
    {

    }

    public Menuprincipal(string usuario, string passw, string correo, int id)
    {
        InitializeComponent();

        Usuario = usuario; Passw = passw; Correo = correo; ID = id;
        Console.WriteLine(passw, correo);
    }

    private async void Clicked_btnverperfil(object sender, EventArgs e)
    {
        // Obtener los valores introducidos por el usuario


        // Realizar la consulta a la base de datos
        var usuariosSnapshot = await CrossCloudFirestore.Current
                                       .Instance
                                       .Collection("Usuario")
                                       .GetAsync();

        // Recorrer los documentos devueltos por la consulta
        foreach (var documento in usuariosSnapshot.Documents)
        {
            // Acceder a los datos del documento
            var datosDocumento = documento.Data;

            // Variables para almacenar los datos del usuario
            string nombreUsuario = string.Empty;
            string contrasenaUsuario = string.Empty;
            string correoUsuario = string.Empty;
            Console.WriteLine(ID);
            // Verificar si el usuario coincide con el campo "nombre" en la base de datos
            if (datosDocumento.TryGetValue("idusario", out var idusarioDB) && idusarioDB.ToString() == ID.ToString())
            {
                datosDocumento.TryGetValue("nombre", out var usuarioDB);
                datosDocumento.TryGetValue("correo", out var correoDB);
                datosDocumento.TryGetValue("password", out var passwDB);

                nombreUsuario = usuarioDB.ToString();
                contrasenaUsuario = correoDB.ToString();
                correoUsuario = passwDB.ToString();
                Console.WriteLine(contrasenaUsuario,correoUsuario);
                Navigation.PushModalAsync(new Perfil(nombreUsuario, contrasenaUsuario, correoUsuario, ID));
                break;
            }
        }
    }
}