using CapaDatos;
using CapaNegocio;
using iTextSharp.tool.xml.html;
using SistemaECU911.Template.Views_Pacientes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views
{
    public partial class Configuracion : System.Web.UI.Page
    {

        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Medico"] != null)
                {
                    string priNom = Session["prinombre"].ToString();
                    string segNom = Session["segnombre"].ToString();
                    string priApe = Session["priapellido"].ToString();
                    string segApe = Session["segapellido"].ToString();
                    string correo = Session["correo"].ToString();
                    string tel = Session["telefono"].ToString();
                    string dir = Session["direccion"].ToString();

                    //---------------------Datos precargados-------------------- -

                    txt_priNombre.Text = priNom;
                    txt_segNombre.Text = segNom;
                    txt_priApellido.Text = priApe;
                    txt_segApellido.Text = segApe;
                    txt_correo.Text = correo;
                    txt_telefono.Text = tel;
                    txt_direccion.Text = dir;

                    //imgPerfil2.ImageUrl = "/Template/Views/CargarImagen.aspx?id=" + id;
                }

                Timer1.Enabled = false;
            }
        }
        private void ActualizarInformacionUsurio(Tbl_Person per)
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
            int usulogueado = Convert.ToInt32(Session["Medico"].ToString());
            usu = CN_Usuarios.obtenerUsuariosxId(usulogueado);

            if (usu != null)
            {
                ActualizarInformacionUsurio(usu);
            }            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }
    }
}