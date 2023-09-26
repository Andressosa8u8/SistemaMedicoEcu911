using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador
{
    public partial class Inicio : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cantidadUsuarios();
            }
        }

        public void cantidadUsuarios()
        {
            //cargar informacion cards
            var querySocio = dc.Tbl_Person.Count(p => p.Per_estado == "PP");
            totalInactivos.Text = querySocio.ToString();
            //pacientes activos
            var queryPaciente = dc.Tbl_Person.Count(pa => pa.Per_estado == "AP");
            totalPacientes.Text = queryPaciente.ToString();
            //pacientes ecu
            var queryEcu = dc.Tbl_Person.Count(ec => ec.Emp_id == 1 && ec.Per_estado == "AP");
            totalEcu.Text = queryEcu.ToString();
            //pacientes articulados
            var queryArticulados = dc.Tbl_Person.Count(ar => ar.Emp_id != 1 && ar.Per_estado == "AP");
            totalArticulados.Text = queryArticulados.ToString();
        }
    }
}