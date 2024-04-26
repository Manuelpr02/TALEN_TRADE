using Plugin.CloudFirestore;

namespace ProyectoFinal.Pages;

public partial class Recordarpasw : ContentPage
{
	public Recordarpasw()
	{
		InitializeComponent();
	}

    private async void Clicked_btnvolver(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void Clicked_btnguardar(object sender, EventArgs e)
    {
        string edad = Edadentry.Text;
        string color = Colorentry.Text;
        string ciudad = Ciudadentry.Text;


        // Obtener la colección "Usuario" y aplicar filtros según los valores de entrada
        var usuariosSnapshot = await CrossCloudFirestore.Current
                                                                .Instance
                                                                .Collection("Usuario")
                                                                .WhereEqualsTo("ciudad", Ciudadentry.Text)  // Filtrar por ciudad
                                                                .WhereEqualsTo("color", Colorentry.Text)     // Filtrar por color
                                                                .WhereEqualsTo("edad", Edadentry.Text)  // Filtrar por edad (conversión a entero)
                                                                .GetAsync();

        if (usuariosSnapshot.Documents.Any())
        {
            var documento = usuariosSnapshot.Documents.FirstOrDefault();

            if (documento != null)
            {
                // Acceder a los datos del documento para obtener la contraseña
                var datosDocumento = documento.Data;

                // Verificar si el campo "password" está presente en los datos del documento
                if (datosDocumento.TryGetValue("password", out var contrasena))
                {
                    // Mostrar la contraseña almacenada en Firestore
                    await DisplayAlert("Contraseña", $"Su contraseña es: {contrasena}", "OK");
                }
            }
        }
        else
        {
            await DisplayAlert("Error","No se ha introducido los datos correctos", "OK");
        }



    }
}


