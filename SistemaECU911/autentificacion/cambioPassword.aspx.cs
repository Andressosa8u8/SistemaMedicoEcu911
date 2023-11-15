using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.autentificacion
{
    public partial class cambioPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si se proporcionó un token en la URL
                string token = Request.QueryString["token"];
                if (string.IsNullOrEmpty(token))
                {
                    // El token no se proporcionó, muestra un mensaje de error o redirige a una página de error
                    Response.Redirect("../error/404.aspx");
                }

                // Utiliza una consulta SQL para obtener la información del token
                string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ResetPasswordToken, ResetPasswordTokenUsed, ResetPasswordTokenExpiration FROM Tbl_Person WHERE ResetPasswordToken = @token", connection))
                    {
                        cmd.Parameters.AddWithValue("@token", token);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                // Token no encontrado, muestra un mensaje de error o redirige a una página de error
                                Response.Redirect("../error/404.aspx");
                            }
                            else
                            {
                                // Obtén la información del token
                                bool tokenUsed = Convert.ToBoolean(reader["ResetPasswordTokenUsed"]);
                                DateTime expiration = Convert.ToDateTime(reader["ResetPasswordTokenExpiration"]);

                                // Cierra el DataReader
                                reader.Close();

                                // Verifica si el token es válido y no ha expirado
                                if (tokenUsed || expiration < DateTime.Now)
                                {
                                    // Token no válido, muestra un mensaje de error o redirige a una página de error
                                    Response.Redirect("../error/404.aspx");
                                }
                                else
                                {
                                    Timer1.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void cambiarClave(Tbl_Person per)
        {
            try
            {
                if (txt_passNueva.Text == txt_passNueva2.Text)
                {
                    string nuevaClave = GetMD5(txt_passNueva.Text);
                    string token = Request.QueryString["token"];

                    // Utiliza una consulta SQL para actualizar la contraseña y marcar el token como utilizado
                    string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ToString();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE Tbl_Person SET Per_pass = @nuevaClave, ResetPasswordTokenUsed = 1 WHERE ResetPasswordToken = @token", connection))
                        {
                            cmd.Parameters.AddWithValue("@nuevaClave", nuevaClave);
                            cmd.Parameters.AddWithValue("@token", token);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Éxito!', 'Su clave ha sido modificada con éxito.', 'success')", true);
                    Timer1.Enabled = true;
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Las contraseñas nuevas no coinciden con la confirmación', 'error')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'No se ha podido realizar el cambio de su clave: " + ex.Message + "', 'error')", true);
                Limpiar();
            }
        }

        private void Limpiar()
        {
            txt_passNueva.Text = txt_passNueva2.Text = "";
        }

        protected void btn_cambiar_Click(object sender, EventArgs e)
        {
            // Verifica si se proporcionó un token en la URL
            string token = Request.QueryString["token"];
            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("../error/404.aspx");
                return;
            }

            // Obtiene la información de la persona con el token
            Tbl_Person pertk = CN_Personas.obtenerUsuariosxToken(token);

            if (pertk != null)
            {
                cambiarClave(pertk);
            }
            else
            {
                // El token no es válido, muestra un mensaje de error o redirige a una página de error
                Response.Redirect("../error/404.aspx");        
            }
        }

        public static string GetMD5(string str)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convierte los bytes en una cadena hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }

    }

}