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
    public partial class PacientesRetiro : System.Web.UI.Page
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
            var query = from r in dc.Tbl_Retiro
                        join p in dc.Tbl_Person on r.Per_id equals p.Per_id
                        join pro in dc.Tbl_Profesional on r.prof_id equals pro.prof_id
                        orderby r.ret_fechaHoraGuardado descending
                        select new
                        {
                            r.ret_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            pro.prof_NomApe,
                            r.ret_fechaHoraGuardado,
                            r.ret_fecha_horaModificacion
                        };

            grvPacientesRetiro.DataSource = query.ToList();
            grvPacientesRetiro.DataBind();
        }

        protected void grvPacientesRetiro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/HC_Retiro.aspx?cod=" + codigo, true);
            }
        }
    }
}