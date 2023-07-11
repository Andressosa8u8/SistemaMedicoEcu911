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
    public partial class PacientesPedidoExamenes : System.Web.UI.Page
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
            var query = from ped in dc.Tbl_PedidoExamenes
                        join p in dc.Tbl_Person on ped.Per_id equals p.Per_id
                        orderby ped.pedExa_fechaHoraGuardado descending
                        select new
                        {
                            ped.pedExa_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            ped.pedExa_fechaHoraGuardado,
                            ped.pedExa_fecha_horaModificacion
                        };

            grvPacientesPedidoExamenes.DataSource = query.ToList();
            grvPacientesPedidoExamenes.DataBind();
        }

        protected void grvPacientesPedidoExamenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/HC_PedidoExamenes.aspx?cod=" + codigo, true);
            }
        }
    }
}