using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace SistemaECU911.Template.Views
{
    public partial class Pacientes : System.Web.UI.Page
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
            var query = from hm in dc.Tbl_FichasMedicas
                        join p in dc.Tbl_Person on hm.Per_id equals p.Per_id
                        join pro in dc.Tbl_Profesional on hm.prof_id equals pro.prof_id
                        orderby hm.fechaHoraGuardado descending
                        select new
                        {
                            hm.idFichaMedica,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            pro.prof_NomApe,
                            hm.fechaHoraGuardado,
                            hm.fechaHoraModificacion
                        };

            grvPacientes.DataSource = query.ToList();
            grvPacientes.DataBind();
        }

        protected void grvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador_Medico/Ficha_Medica.aspx?cod=" + codigo, true);
            }
        }

    }
}