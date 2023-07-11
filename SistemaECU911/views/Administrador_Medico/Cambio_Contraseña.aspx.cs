using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views
{
    public partial class Contraseña : System.Web.UI.Page
    {

        private Tbl_Person usuinfo = new Tbl_Person();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Timer1.Enabled = false;
            }
        }

        private void cambiarClave(Tbl_Person per)
        {
            try
            {
                int usulogueado = Convert.ToInt32(Session["Medico"].ToString());
                bool existe = CN_Usuarios.autentificarxUsuario(usulogueado, GetMD5(txt_passAntigua.Text));
                if (existe)
                {
                    Tbl_Person perc = new Tbl_Person();
                    perc = CN_Usuarios.obtenerUsuariosxId(usulogueado);
                    string anterior = perc.Per_pass.ToString();
                    if (anterior == GetMD5(txt_passNueva.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Su nueva clave no puede ser igual a la anterior.', 'error')", true);
                    }
                    else
                    {
                        if (txt_passNueva.Text == txt_passNueva2.Text)
                        {
                            per.Per_pass = GetMD5(txt_passNueva.Text);
                            CN_Usuarios.ModificarUsuarios(per);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Éxito!', 'Su clave a sido modificada con exito.', 'success')", true);
                            Limpiar();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Las contraseña nueva no coinciden con la confirmación', 'error')", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'La contraseña anterior ingresada es incorrecta.', 'error')", true);
                    Timer1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'No se a podido realizar el cambio de su clave" + ex.Message + ".', 'error')", true);
                Limpiar();
            }
        }
        private void Limpiar()
        {
            txt_passAntigua.Text = txt_passNueva.Text = txt_passNueva2.Text = "";
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

        protected void btn_cambiar_Click(object sender, EventArgs e)
        {
            Tbl_Person usu = new Tbl_Person();
            int usulogeado = Convert.ToInt32(Session["Médico"].ToString());
            usu = CN_Usuarios.obtenerUsuariosxId(usulogeado);
            if (usu != null)
            {
                cambiarClave(usu);
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }
    }
}