using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views_Pacientes
{
    public partial class Configuracion : System.Web.UI.Page
    {
        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Paciente"] != null)
                {
                    string usuLogueado = Session["Paciente"].ToString();
                    string priNom = Session["prinombre"].ToString();
                    string segNom = Session["segnombre"].ToString();
                    string priApe = Session["priapellido"].ToString();
                    string segApe = Session["segapellido"].ToString();
                    string correo = Session["correo"].ToString();
                    string tel = Session["telefono"].ToString();
                    string dir = Session["direccion"].ToString();

                    txt_priNombre.Text = priNom;
                    txt_segNombre.Text = segNom;
                    txt_priApellido.Text = priApe;
                    txt_segApellido.Text = segApe;
                    txt_correo.Text = correo;
                    txt_telefono.Text = tel;
                    txt_direccion.Text = dir;
                }
                Timer1.Enabled = false;
            }
        }
        private void ActualizarInformacionusuario(Tbl_Person usu)
        {
            try
            {
                per.Per_direccion = txt_direccion.Text;
                per.Per_telefono = txt_telefono.Text;
                per.Per_correo = txt_correo.Text;
                CN_Usuarios.ModificarUsuarios(per);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Actualizados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', ''No se pudo actualizar la informacion del usuario'', 'error')", true);
            }
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            Tbl_Person usu = new Tbl_Person();
            int usulogueado = Convert.ToInt32(Session["Paciente"].ToString());
            usu = CN_Usuarios.obtenerUsuariosxIdPaciente(usulogueado);

            if (usu != null)
            {
                ActualizarInformacionusuario(usu);
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }
    }
}