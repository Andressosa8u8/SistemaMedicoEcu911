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
    public partial class PacientesPeriodica : System.Web.UI.Page
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
            var query = from pe in dc.Tbl_Periodica
                        join p in dc.Tbl_Person on pe.Per_id equals p.Per_id
                        join pro in dc.Tbl_Profesional on pe.prof_id equals pro.prof_id
                        orderby pe.perio_fechaHoraGuardado descending
                        select new
                        {
                            pe.perio_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            pro.prof_NomApe,
                            pe.perio_fechaHoraGuardado,
                            pe.perio_fecha_horaModificacion
                        };

            grvPacientesPeriodica.DataSource = query.ToList();
            grvPacientesPeriodica.DataBind();
        }

        protected void grvPacientesPeriodica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/HC_Periodica.aspx?cod=" + codigo, true);
            }
        }
    }
}