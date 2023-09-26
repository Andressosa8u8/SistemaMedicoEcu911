using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador
{
    public partial class Lista_Instituciones : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarInstituciones();
            }
        }

        private void cargarInstituciones()
        {
            var query = from e in dc.Tbl_Empresa
                        select new
                        {
                            e.Emp_id,
                            e.Emp_nombre,
                            e.Emp_estado,
                        };

            grvInstituciones.DataSource = query.ToList();
            grvInstituciones.DataBind();
        }

        protected void grvInstituciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador/Agregar_Instituciones.aspx?cod=" + codigo, true);
            }
        }
    }
}