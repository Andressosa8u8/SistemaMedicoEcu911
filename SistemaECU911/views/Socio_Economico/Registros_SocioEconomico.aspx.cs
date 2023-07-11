using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views_Socio_Economico
{
    public partial class PacientesSocioEconomico : System.Web.UI.Page
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
            var query = from r in dc.Tbl_SocioEconomico
                        join p in dc.Tbl_Person on r.Per_id equals p.Per_id
                        orderby r.Socio_economico_fechaHoraGuardado descending
                        select new
                        {
                            r.Socio_economico_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            r.Socio_economico_fechaHoraGuardado,
                            r.Socio_economico_fechaHoraModificacion
                        };

            grvPacientesSocioEconomico.DataSource = query.ToList();
            grvPacientesSocioEconomico.DataBind();
        }

        protected void grvPacientesSocioEconomico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Socio_Economico/Ficha_SocioEconomico.aspx?cod=" + codigo, true);
            }
        }
    }
}