using Plugin.CloudFirestore;
namespace ProyectoFinal.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private async void Clicked_btnEntrar(object sender, EventArgs e)
    {
        // Obtener los valores introducidos por el usuario
        string usuario = Usuarioentry.Text;
        string contrasena = Passwentry.Text;

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

            // Verificar si el usuario coincide con el campo "nombre" en la base de datos
            if (datosDocumento.TryGetValue("nombre", out var usuarioBD) && usuarioBD.ToString() == usuario)
            {
                // Verificar si la contraseña coincide con el campo "password" en la base de datos
                if (datosDocumento.TryGetValue("password", out var contrasenaBD) && contrasenaBD.ToString() == contrasena)
                {
                    datosDocumento.TryGetValue("correo", out var correoBD);
                    datosDocumento.TryGetValue("idusario", out var idBD);
                    string Correo = correoBD.ToString();
                    int idDocumentoInt = Convert.ToInt32(idBD);
                    // Si las credenciales son correctas, hacer algo aquí
                    await DisplayAlert("Éxito", "¡Inicio de sesión exitoso!", "OK");
                    Console.WriteLine(contrasena, Correo);
                    await Navigation.PushModalAsync(new Menuprincipal(usuario,Correo,contrasena,idDocumentoInt));
                    return;
                }
            }
        }

        // Si llegamos aquí, las credenciales son incorrectas o el usuario no existe
        await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
    }



    private void Clicked_btnRegistrar(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Registrar());
    }
}