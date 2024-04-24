using Plugin.CloudFirestore;
using ProyectoFinal.Database;
using System.Threading.Tasks;
namespace ProyectoFinal.Pages;

public partial class Registrar : ContentPage
{

	public Registrar()
	{
		InitializeComponent();
	}

    private void Clicked_btnvolver(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private async void Clicked_btnregistrar(object sender, EventArgs e)
    {
        // Verificar el formato del correo electrónico
        if (!IsValidEmail(CorreoEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, introduzca un correo electrónico válido", "OK");
            return;
        }

        // Verificar si el nombre y el correo ya existen en la base de datos
        var usuariosSnapshot = await CrossCloudFirestore.Current
                                              .Instance
                                              .Collection("Usuario")
                                              .WhereEqualsTo("nombre", Nombreentry.Text)
                                              .WhereEqualsTo("correo", CorreoEntry.Text)
                                              .GetAsync();

        if (usuariosSnapshot.Documents.Any())
        {
            await DisplayAlert("Error", "El nombre o correo electrónico ya están registrados", "OK");
            return;
        }
        string nombreUltimoDocumento = string.Empty;

        // Realizar una consulta para obtener el último documento creado en la colección "Usuario"
        int mayorValor = 0;

        // Obtener todos los documentos de la colección "Usuario"
        var usuariosSnapshot4 = await CrossCloudFirestore.Current
                                           .Instance
                                           .Collection("Usuario")
                                           .GetAsync();

        // Lista para almacenar los IDs de los documentos
        List<int> idsDocumentos = new List<int>();

        // Recorrer los documentos y guardar sus IDs en el vector
        foreach (var documento in usuariosSnapshot4.Documents)
        {
            idsDocumentos.Add(int.Parse(documento.Id));
        }

        // Ordenar el vector en orden descendente (de mayor a menor)
        idsDocumentos.Sort((a, b) => b.CompareTo(a));

        // Si hay elementos en el vector, asignar el primer elemento (mayor valor) a la variable mayorValor
        if (idsDocumentos.Any())
        {
            mayorValor = idsDocumentos[0];
        }

        // Mostrar el mayor valor del vector
        Console.WriteLine("El mayor valor del vector es: " + mayorValor);



        // Registrar el usuario si pasa las validaciones
        
        int idUsuario = await LocalDB.AddCliente(Nombreentry.Text, CorreoEntry.Text, PasswordEntry.Text);
        var usuarioTask = LocalDB.GetUsuario(idUsuario);
        Usuario user = new Usuario();

        // Esperar la finalización de la tarea y obtener el usuario
        await usuarioTask.ContinueWith(task =>
        {
            var usuario = task.Result; // Obtener el usuario de la tarea

            // Verificar si se encontró un usuario
            if (usuario != null)
            {
                // Asignar los valores del usuario a un nuevo objeto Usuario
                user.idusario = mayorValor + 1;
                user.nombre = usuario.nombre;
                user.correo = usuario.correo;
                user.password = usuario.password;
                // Asignar otros valores si los hay
            }
        });

        if (PasswordEntry.Text == NewPasswordEntry.Text)
        {
            await CrossCloudFirestore.Current
                             .Instance
                             .Collection("Usuario")
                             .Document((mayorValor + 1).ToString())
                             .SetAsync(user);

        }
        else
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
        }
        
    }

    // Método para verificar el formato del correo electrónico
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

}