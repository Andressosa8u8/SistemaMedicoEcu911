using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;

namespace SistemaECU911.Template.Views
{
    public partial class Inicio : System.Web.UI.Page
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
            var query = from p in dc.Tbl_Person
                        where p.Per_estado == "AP"
                        select new
                        {
                            p.Per_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_segNombre,
                            p.Per_priApellido,
                            p.Per_segApellido,
                            p.Per_genero,
                        };

            grvPacientes.DataSource = query.ToList();
            grvPacientes.DataBind();
        }

        protected void grvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Template/Views/Personas.aspx?cod=" + codigo, true);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] ListaNPersonas()
        {
            //object olista;
            List<Sp_Npersona_puestoTrabajoResult> olista = new List<Sp_Npersona_puestoTrabajoResult>();
            olista = CN_Reporte_NPersona.Reporte_NPersona().ToList();
            
            var objetoLista = new object[olista.Count + 1];
            objetoLista[0] = new object[]{
                "",
                ""
            };
            int j = 0;
            foreach (var i in olista)
            {
                j++;
                objetoLista[j] = new object[] { i.Per_puestoTrabajo, i.numero_personas };
            }
            return objetoLista;

        }
    }
}