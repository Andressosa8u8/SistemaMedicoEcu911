using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Lista_Diagnostico_Codigo : System.Web.UI.Page
    {
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }
        }
        private void cargarDatos()
        {
            var query = from fm in dc.Tbl_FichasMedicas
                        join p in dc.Tbl_Person on fm.Per_id equals p.Per_id
                        select new
                        {
                            p.Per_id,
                            p.Per_cedula,
                            p.Per_priNombre,
                            p.Per_priApellido,
                            Diagnostico = fm.diagnostico == "" ? "SIN DIAGNÓSTICO" : fm.diagnostico.ToString(),
                            Codigo = fm.codigoDiag == "" ? "SIN CÓDIGO" : fm.codigoDiag.ToString(),
                            Fecha = fm.fechaHoraGuardado.ToString()
                        };
            grvDatos.DataSource = query.ToList();
            grvDatos.DataBind();
        }
    }
}