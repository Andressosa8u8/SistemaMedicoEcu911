using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using SistemaECU911.Template.Views_Pacientes;
using System.Configuration;

namespace SistemaECU911.autentificacion
{
    public partial class recuperarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Timer1.Enabled = false;
            }
        }

        private void recuperar()
        {
            Tbl_Person per = new Tbl_Person();
            string email = txt_email.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Por favor, complete el campo de correo.', 'error')", true);
                return;
            }

            bool existe = CN_Usuarios.autentificarxCorreo(email);

            if (existe)
            {
                per = CN_Usuarios.obtenerCorreo(email);

                // Generar y almacenar el token
                string token = Guid.NewGuid().ToString();
                DateTime expiration = DateTime.Now.AddMinutes(5);

                string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Tbl_Person SET ResetPasswordToken = @token, ResetPasswordTokenUsed = 0, ResetPasswordTokenExpiration = @expiration WHERE Per_id = @userID", connection))
                    {
                        cmd.Parameters.AddWithValue("@token", token);
                        cmd.Parameters.AddWithValue("@expiration", expiration);
                        cmd.Parameters.AddWithValue("@userID", per.Per_id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Enviar el correo electrónico al usuario con el enlace que incluye el token
                EnviarCorreoConEnlaceReset(per.Per_correo, token);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Éxito!', 'Correo enviado con éxito.', 'success')", true);
                txt_email.Text = "";
                Timer1.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'El correo no existe.', 'error')", true);
                txt_email.Text = "";
            }
        }

        private void EnviarCorreoConEnlaceReset(string to, string token)
        {
            // Configuración de correo electrónico
            string from = "Sistema.Medico@ecu911.gob.ec"; // Tu correo remitente
            string subject = "Recuperación de Contraseña"; // Asunto del correo

            // Cuerpo del correo con formato HTML
            string body = "<html><body>";
            body += "<img src='../resources/images/LogoMedico.png' alt='Encabezado' style='width: 100%; height: auto;'>";
            body += "<h2>Recuperación de Contraseña</h2>";
            body += "<p>Haga clic en el siguiente enlace para restablecer su contraseña:</p>";
            body += "<p><a href='https://localhost:44359/autentificacion/cambioPassword.aspx?token=" + token + "'>Restablecer Contraseña</a></p>";
            body += "<p>El enlace tiene una caducidad de 5 minutos desde la hora en la que se solicito el cambio de contraseña, porfavor tomar en cuenta.</p>";
            body += "<img src='../resources/images/LogoMedico.png' alt='Pie de página' style='width: 100%; height: auto;'>";
            body += "</body></html>";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            // Configuración del servidor SMTP
            SmtpClient smtpClient = new SmtpClient("10.121.6.246"); // Cambia esto al servidor SMTP que estés utilizando
            smtpClient.Port = 25; // Puerto del servidor SMTP
            smtpClient.Credentials = new NetworkCredential("Sismed", "Sis.med911"); // Cambia esto a tus credenciales de SMTP
            smtpClient.EnableSsl = false; // Configura según la seguridad de tu servidor SMTP

            try
            {
                smtpClient.Send(mailMessage);
                // Mensaje de éxito
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Éxito!', 'Correo enviado con éxito.', 'success')", true);
            }
            catch (Exception)
            {
                // Manejo de errores al enviar el correo
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Correo no enviado intentelo de nuevo.', 'error')", true);
                txt_email.Text = "";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {
            recuperar();
        }
    }
}