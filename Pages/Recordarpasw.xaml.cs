using System.Net.Mail;
using System.Net;

namespace ProyectoFinal.Pages;

public partial class Recordarpasw : ContentPage
{
	public Recordarpasw()
	{
		InitializeComponent();
	}
    private async void Clicked_btnEnviarCorreo(object sender, EventArgs e)
    {
        string correo = CorreoEntry.Text;
        string contrasena = "TuContraseñaDeCorreo"; // Reemplaza con tu contraseña de correo electrónico

        try
        {
            MailMessage mensaje = new MailMessage();
            SmtpClient clienteSMTP = new SmtpClient("smtp.gmail.com", 587);

            // Configurar el cliente SMTP
            clienteSMTP.EnableSsl = true;
            clienteSMTP.UseDefaultCredentials = false;
            clienteSMTP.Credentials = new NetworkCredential(correo, contrasena);

            // Configurar el mensaje
            mensaje.From = new MailAddress(correo);
            mensaje.To.Add(new MailAddress(correo));
            mensaje.Subject = "Recuperación de contraseña";
            mensaje.Body = "Aquí está tu contraseña: [2]"; // Reemplaza [TuContraseña] con la contraseña real

            // Enviar el mensaje
            clienteSMTP.Send(mensaje);

            await DisplayAlert("Correo Enviado", $"Se ha enviado un correo con la contraseña a {correo}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo enviar el correo: {ex.Message}", "OK");
        }
    }
}


