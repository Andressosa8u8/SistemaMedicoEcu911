using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views_Pacientes
{
    public partial class Inicio : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                cargarHClinica();
                //grvPacientes.VirtualItemCount = Count();

            }
        }

        private void cargarHClinica()
        {
            string cedula = Session["Cedula"].ToString();

            var query = dc.ObtenerPaciente(cedula);

            //var query = from hm in dc.Tbl_FichasMedicas where hm.Per_id = ced
            //            join p in dc.Tbl_Personas on hm.Per_id equals p.Per_id
            //            join pro in dc.Tbl_Profesional on hm.prof_id equals pro.prof_id                        
            //            //where p.Per_cedula != "1717418196"
            //            orderby hm.fechaHoraGuardado descending
            //            select new
            //            {
            //                hm.idFichaMedica,
            //                p.Per_cedula,
            //                pro.prof_NomApe,
            //                hm.fechaHoraGuardado
            //            };

            grvHClinica.DataSource = query.ToList();
            grvHClinica.DataBind();
        }

        protected void grvHClinica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Visualizar")
            {
                Response.Redirect("~/views/Pacientes/Ficha_Medica.aspx?cod=" + codigo, true);
            }
        }
    }
}