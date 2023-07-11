using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views
{
    public partial class PacientesInmunizaciones : System.Web.UI.Page
    {
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPaciente();
                //grvPacientes.VirtualItemCount = Count();
            }
        }

        private void cargarPaciente()
        {
            var query = from i in dc.Tbl_Inmunizaciones
                        join p in dc.Tbl_Person on i.Per_id equals p.Per_id
                        orderby i.inmu_fechaHoraGuardado descending
                        select new
                        {
                            i.inmu_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            i.inmu_fechaHoraGuardado,
                            i.inmu_fecha_horaModificacion
                        };

            grvPacientesInmunizaciones.DataSource = query.ToList();
            grvPacientesInmunizaciones.DataBind();
        }

        protected void grvPacientesInmunizaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/HC_Inmunizaciones.aspx?cod=" + codigo, true);
            }
        }
    }
}