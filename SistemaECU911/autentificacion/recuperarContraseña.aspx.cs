using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                    string from = "sistema.medico.ecu911@gmail.com";
                    string pass = "SistemaMedico911";
                    string to = per.Per_correo;
                    string mensaje = "La contraseña que el olvido es: " + per.Per_pass;
                    //string mensaje = "La contraseña que el olvido es: <strong>" +
                    //    desencriptar(usu.usu_pass) + "</strong>";

                    if (new CN_Email().EnviarEmail(from, pass, to, mensaje))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Éxito!', 'Correo enviado con éxito.', 'success')", true);
                        txt_email.Text = "";
                        Timer1.Enabled = true;
                    }
                    else
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
        string desencriptar(string cadena)
        {
            string resultado = string.Empty;
            byte[] desencriptar = Convert.FromBase64String(cadena);
            resultado = System.Text.Encoding.Unicode.GetString(desencriptar);
            return resultado;
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