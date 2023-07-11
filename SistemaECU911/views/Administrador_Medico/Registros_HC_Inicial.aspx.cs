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
    public partial class PacientesInicial : System.Web.UI.Page
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
            var query = from i in dc.Tbl_Inicial
                        join p in dc.Tbl_Person on i.Per_id equals p.Per_id
                        join pro in dc.Tbl_Profesional on i.prof_id equals pro.prof_id
                        orderby i.inicial_fechaHoraGuardado descending
                        select new
                        {
                            i.inicial_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            pro.prof_NomApe,
                            i.inicial_fechaHoraGuardado,
                            i.inicial_fecha_horaModificacion
                        };

            grvPacientesInicial.DataSource = query.ToList();
            grvPacientesInicial.DataBind();

        }

        protected void grvPacientesInicial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/HC_Inicial.aspx?cod=" + codigo, true);
            }
        }

    }
}