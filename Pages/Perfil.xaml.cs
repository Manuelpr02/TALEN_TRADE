using Plugin.CloudFirestore;
using ProyectoFinal.Database;

namespace ProyectoFinal.Pages;

public partial class Perfil : ContentPage
{
	int ID;
	public Perfil(string usuario, string passw, string correo, int id)
	{
		InitializeComponent();
		Console.WriteLine(passw, correo);
		Usuarioentry.Text = usuario;
		Passwentry.Text = passw;
		Correoentry.Text = correo;
		ID = id;
	}

    private async void Clicked_btnguardar(object sender, EventArgs e)
    {
        string ciudads = string.Empty;
        string colors = string.Empty;
        string edads = string.Empty;

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
            
            // Verificar si el usuario coincide con el campo "nombre" en la base de datos
            if (datosDocumento.TryGetValue("idusario", out var idusarioDB) && idusarioDB.ToString() == ID.ToString())
            {
                datosDocumento.TryGetValue("edad", out var edadDB);
                datosDocumento.TryGetValue("color", out var colorDB);
                datosDocumento.TryGetValue("ciudad", out var ciudadDB);

                ciudads= ciudadDB.ToString();
                colors = colorDB.ToString();
                edads = edadDB.ToString();

            }
        }
        // Esperar la finalización de la tarea y obtener el usuario

        Usuario user = new Usuario { password = Correoentry.Text , idusario=ID, nombre = Usuarioentry.Text, correo = Passwentry.Text, edad = edads, color=edads,ciudad=ciudads };
			
        await CrossCloudFirestore.Current
                                 .Instance
                                 .Collection("Usuario")
								 .Document(ID.ToString())
                                 .SetAsync(user);
		await DisplayAlert("Confirmado", "Se ha guardado los nuevos datos del usuario", "OK");
		await Navigation.PopModalAsync();
    }

    private async void Clicked_btnvolver(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void Clicked_cancelar(object sender, EventArgs e)
    {
        await DisplayAlert("Cancelado", "Se ha cancelado la modificación del usuario", "OK");
        await Navigation.PopModalAsync();
    }
}