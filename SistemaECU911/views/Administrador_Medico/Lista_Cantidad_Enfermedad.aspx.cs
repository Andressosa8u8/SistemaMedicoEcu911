using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Lista_Cantidad_Enfermedad : System.Web.UI.Page
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
                        let tipoEnfermedad = fm.tipAntecedentePer == "0" ? "SIN ENFERMEDAD"
                        : fm.tipAntecedentePer == "1" ? "ENFERMEDAD CARDIO-VASCULAR"
                        : fm.tipAntecedentePer == "2" ? "ENFERMEDAD METABÓLICA"
                        : fm.tipAntecedentePer == "3" ? "ENFERMEDAD NEUROLÓGICA"
                        : fm.tipAntecedentePer == "4" ? "ENFERMEDAD ONCOLÓGICA"
                        : fm.tipAntecedentePer == "5" ? "ENFERMEDAD INFECCIOSA"
                        : fm.tipAntecedentePer == "6" ? "ENFERMEDAD HEREDITARIA/CONGÓNITA"
                        : fm.tipAntecedentePer == "7" ? "DISCAPACIDADES"
                        : fm.tipAntecedentePer == "8" ? "OTROS" : null
                        where tipoEnfermedad != null
                        group fm by tipoEnfermedad into g
                        select new
                        {
                            idFichas = g.Max(f => f.idFichaMedica),
                            tEnfermedad = g.Key,
                            valor = g.Count(),
                        };

            grvDatos.DataSource = query.ToList();
            grvDatos.DataBind();
        }
    }
}