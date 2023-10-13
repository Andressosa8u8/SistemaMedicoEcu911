using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace SistemaECU911.views.Administrador
{
    public partial class Lista_Usuarios_Pasivos : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarPacienteInactivo(); 
        }

        private void cargarPacienteInactivo()
        {
            var query = from p in dc.Tbl_Person
                        where p.Per_estado == "PA" || p.Per_estado == "PM" || p.Per_estado == "PS" || p.Per_estado == "PP"
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

            grvPacientesInactivos.DataSource = query.ToList();
            grvPacientesInactivos.DataBind();
        }

        protected void grvPacientesInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/views/Administrador/Agregar_Usuarios.aspx?cod=" + codigo, true);
            }
        }
    }
}