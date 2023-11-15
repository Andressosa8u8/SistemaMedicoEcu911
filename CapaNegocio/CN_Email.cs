using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Email
    {

        private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        // Metodo para modificar datos de las personas correo
        public static void ModificarToken(Tbl_Person per)
        {
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique los datos del correo" + ex.Message);
            }
        }



        MailMessage ma = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        public bool EnviarEmail(string from, string pass, string to, string mensaje)
        {
            try
            {
                ma.From = new MailAddress(from, "Ecu911 Sistema Medico", System.Text.Encoding.UTF8);
                ma.To.Add(new MailAddress(to));

                ma.Body = mensaje;
                ma.IsBodyHtml = true;
                ma.Subject = "Recuperacion De Contraseña";

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.EnableSsl = true;
                smtp.Timeout = 600000;

                smtp.Send(ma);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
                throw;
            }
        }

    }
}
