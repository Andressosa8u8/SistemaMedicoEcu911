using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador
{
    public partial class Lista_Especialidades : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarEspecialidad();
            }
        }

        private void cargarEspecialidad()
        {
            var query = from e in dc.Tbl_Especialidad
                        select new
                        {
                            e.espec_id,
                            e.espec_nombre,
                            e.espec_estado
                        };

            grvEspecialidad.DataSource = query.ToList();
            grvEspecialidad.DataBind();
        }

        protected void grvEspecialidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador/Agregar_Especialidad.aspx?cod=" + codigo, true);
            }
        }
    }
}