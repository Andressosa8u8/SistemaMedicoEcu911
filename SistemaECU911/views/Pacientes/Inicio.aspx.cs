using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views_Pacientes
{
    public partial class Inicio : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Asegúrate de que el usuario haya iniciado sesión antes de cargar la información
                if (Session["Paciente"] != null)
                {
                    cargarHClinica();
                }
                else
                {
                    // Manejar el caso donde el usuario no ha iniciado sesión
                    // Por ejemplo, redirigir a una página de inicio de sesión.
                }
            }
        }

        private void cargarHClinica()
        {
            if (Session["Paciente"] != null)
            {
                int idPaciente = Convert.ToInt32(Session["Paciente"]);

                var query = from se in dc.Tbl_FichasMedicas
                            join p in dc.Tbl_Person on se.Per_id equals p.Per_id
                            join pr in dc.Tbl_Profesional on se.prof_id equals pr.prof_id
                            where se.Per_id == idPaciente
                            select new
                            {
                                se.idFichaMedica,
                                p.Per_cedula,
                                pr.prof_NomApe,
                                se.fechaHoraGuardado
                            };

                grvHClinica.DataSource = query.ToList();
                grvHClinica.DataBind();
            } 
        }



        //private void cargarPaciente()
        //{
        //    var query = from r in dc.Tbl_SocioEconomico
        //                join p in dc.Tbl_Person on r.Per_id equals p.Per_id
        //                //orderby r.Socio_economico_fechaHoraGuardado descending
        //                select new
        //                {
        //                    r.Socio_economico_id,
        //                    p.Per_cedula,
        //                    p.Per_priNombre,
        //                    p.Per_priApellido,
        //                    r.Socio_economico_fechaHoraGuardado,
        //                    r.Socio_economico_fechaHoraModificacion
        //                };

        //    grvPacientesSocioEconomico.DataSource = query.ToList();
        //    grvPacientesSocioEconomico.DataBind();
        //}

        protected void grvHClinica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Visualizar")
            {
                Response.Redirect("~/views/Pacientes/Ficha_Medica.aspx?cod=" + codigo, true);
            }
        }

        //protected void grvPacientesSocioEconomico_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int codigo = Convert.ToInt32(e.CommandArgument);
        //    if (e.CommandName == "Visualizar")
        //    {
        //        Response.Redirect("~/views/Pacientes/SocioEconomico.aspx?cod=" + codigo, true);
        //    }
        //}
    }
}