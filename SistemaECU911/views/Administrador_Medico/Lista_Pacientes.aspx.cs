using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Lista_Pacientes : System.Web.UI.Page
    {
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPaciente();
            }
        }

        private void cargarPaciente()
        {
            var query = from p in dc.Tbl_Person
                        where p.Per_estado == "AP"
                        select new
                        {
                            p.Per_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_segNombre,
                            p.Per_priApellido,
                            p.Per_segApellido,
                            p.Per_genero,
                        };

            grvPacientes.DataSource = query.ToList();
            grvPacientes.DataBind();
        }

        protected void grvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/Agregar_Pacientes.aspx?cod=" + codigo, true);
            }
        }
    }
}