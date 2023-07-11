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
    public partial class PacientesCertificado : System.Web.UI.Page
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
            var query = from c in dc.Tbl_Certificado
                        join p in dc.Tbl_Person on c.Per_id equals p.Per_id
                        join pro in dc.Tbl_Profesional on c.prof_id equals pro.prof_id
                        orderby c.certi_fechaHoraGuardado descending
                        select new
                        {
                            c.certi_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            pro.prof_NomApe,
                            c.certi_fechaHoraGuardado,
                            c.certi_fecha_horaModificacion
                        };

            grvPacientesCertificado.DataSource = query.ToList();
            grvPacientesCertificado.DataBind();
        }

        protected void grvPacientesCertificado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/HC_Certificado.aspx?cod=" + codigo, true);
            }
        }

        

    }
}