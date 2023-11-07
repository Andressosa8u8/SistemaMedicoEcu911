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
            bool existe = CN_Usuarios.autentificarxCorreo(txt_email.Text);
            {
                if (existe)
                {
                    per = CN_Usuarios.obtenerCorreo(txt_email.Text);

                    string from = "bryan.sosa@ecu911.gob.ec"; // Tu correo remitente
                    /*string pass = "Bry4n50548u8";*/ // Tu contraseña
                    string to = per.Per_correo;
                    string mensaje = "La contraseña que olvidaste es: " + GetMD5(per.Per_pass);

                    //SmtpClient smtpClient = new SmtpClient("https://webmail.ecu911.gob.ec/EWS/Exchange.asmx"); // Cambia esto al servidor Exchange
                    SmtpClient smtpClient = new SmtpClient("10.121.6.246"); // Dirección IP del servidor SMTP

                    smtpClient.Port = 25; // Puede variar según la configuración de tu Exchange
                    smtpClient.Credentials = new NetworkCredential("Sosab", "Bry4n50548u8"); // Cambia esto a tus credenciales de Exchange
                    smtpClient.EnableSsl = false;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(from);
                    mailMessage.To.Add(to);
                    mailMessage.Subject = "Recuperación de Contraseña";
                    mailMessage.Body = mensaje;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Éxito!', 'Correo enviado con éxito.', 'success')", true);
                        txt_email.Text = "";
                        Timer1.Enabled = true;
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Correo no enviado intentelo de nuevo.', 'error')", true);
                        txt_email.Text = "";
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'El correo no existe.', 'error')", true);
                    txt_email.Text = "";
                }
            }
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
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