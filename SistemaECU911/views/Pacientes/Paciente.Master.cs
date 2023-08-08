using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Pacientes
{
    public partial class Paciente : System.Web.UI.MasterPage
    {
        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();

        protected void Page_Load(object sender, EventArgs e)
        {
            //int id = '1';

            if (Session["Paciente"] != null)
            {
                int usulogueado = Convert.ToInt32(Session["Paciente"].ToString());
                per = CN_Usuarios.obtenerUsuariosxId(usulogueado);

                if (per != null)
                {
                    string usulogeado = Session["Paciente"].ToString();
                    string cedula = Session["Cedula"].ToString();
                    string priNom = Session["prinombre"].ToString();
                    string segNom = Session["segnombre"].ToString();
                    string priApe = Session["priapellido"].ToString();
                    string segApe = Session["segapellido"].ToString();
                    string resRol = Session["rol"].ToString();
                    lbl_nombre.Text = priNom + " " + segNom;
                    lbl_apellido.Text = priApe + " " + segApe;
                    lbl_rol.Text = resRol;

                    // Cargar la imagen del usuario si está disponible
                    if (!string.IsNullOrEmpty(per.Per_imgNombre) && per.Per_imgByte != null)
                    {
                        string base64Image = Convert.ToBase64String(per.Per_imgByte.ToArray());
                        imgPerfil.ImageUrl = "data:image/png;base64," + base64Image;
                        imgPerfil2.ImageUrl = "data:image/png;base64," + base64Image;
                    }
                }
            }
            else
            {
                Response.Redirect("../../index.aspx");
            }

        }

        protected void Lnb_CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }

    }
}