using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Medico : System.Web.UI.MasterPage
    {
        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //int id = '1';

            if (Session["Medico"] != null)
            {
                string usulogeado = Session["Medico"].ToString();
                string priNom = Session["prinombre"].ToString();
                string segNom = Session["segnombre"].ToString();
                string priApe = Session["priapellido"].ToString();
                string segApe = Session["segapellido"].ToString();
                string resRol = Session["rol"].ToString();
                lbl_nombre.Text = priNom + " " + segNom;
                lbl_apellido.Text = priApe + " " + segApe;
                lbl_rol.Text = resRol;
                //imgPerfil2.ImageUrl = "/Template/Views/CargarImagen.aspx?id=" + id;
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