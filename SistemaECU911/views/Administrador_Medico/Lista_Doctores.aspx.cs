using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Lista_Doctores : System.Web.UI.Page
    {
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDoctores();
            }
        }
        private void cargarDoctores()
        {
            var query = from p in dc.Tbl_Profesional
                        where p.prof_estado == "A"
                        select new
                        {
                            p.prof_id,
                            p.prof_NomApe,
                            p.prof_cedula
                        };

            grvDoctores.DataSource = query.ToList();
            grvDoctores.DataBind();
        }

        protected void grvDoctores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/Agregar_Doctores.aspx?cod=" + codigo, true);
            }
        }
    }
}