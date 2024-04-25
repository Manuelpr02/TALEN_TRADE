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

        // Esperar la finalización de la tarea y obtener el usuario
       
        Usuario user = new Usuario { password = Correoentry.Text , idusario=ID, nombre = Usuarioentry.Text, correo = Passwentry.Text };
			
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