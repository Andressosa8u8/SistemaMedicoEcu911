using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Lista_Antecedentes_Familiares : System.Web.UI.Page
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
                            //Antecedentes = fm.idTipAntecedentePer == 0 ? "SIN ANTECENDENTES" :
                            //               fm.idTipAntecedentePer == 1 ? "ENFERMEDAD CARDIO VASCULAR" :
                            //               fm.idTipAntecedentePer == 2 ? "ENFERMEDAD METABÓLICA" :
                            //               fm.idTipAntecedentePer == 3 ? "ENFERMEDAD NEUROLÓGICA" :
                            //               fm.idTipAntecedentePer == 4 ? "ENFERMEDAD ONCÓLOGICA" :
                            //               fm.idTipAntecedentePer == 5 ? "ENFERMEDAD INFECCIOSA" :
                            //               fm.idTipAntecedentePer == 6 ? "ENFERMEDAD HEREDITARIA/CONGÓNICA" :
                            //               fm.idTipAntecedentePer == 7 ? "DISCAPACIDADES" :
                            //               "OTROS",
                            AntecedentesFamiliares = fm.idTipAntecedenteFam == 0 ? "SIN ANTECENDENTES" :
                                           fm.idTipAntecedenteFam == 1 ? "ENFERMEDAD CARDIO VASCULAR" :
                                           fm.idTipAntecedenteFam == 2 ? "ENFERMEDAD METABÓLICA" :
                                           fm.idTipAntecedenteFam == 3 ? "ENFERMEDAD NEUROLÓGICA" :
                                           fm.idTipAntecedenteFam == 4 ? "ENFERMEDAD ONCÓLOGICA" :
                                           fm.idTipAntecedenteFam == 5 ? "ENFERMEDAD INFECCIOSA" :
                                           fm.idTipAntecedenteFam == 6 ? "ENFERMEDAD HEREDITARIA/CONGÓNICA" :
                                           fm.idTipAntecedenteFam == 7 ? "DISCAPACIDADES" :
                                           "OTROS",
                            Descripcion = fm.antecedentePer == "" ? "SIN DESCRIPCIÓN" : fm.antecedentePer.ToString(),
                            Fecha = fm.fechaHoraGuardado.ToString()
                            //Diagnostico = fm.diagnostico == "" ? "SIN DIAGNÓSTICO" : fm.diagnostico.ToString(),
                            //Codigo = fm.codigoDiag == "" ? "SIN CÓDIGO" : fm.codigoDiag.ToString()
                        };
            grvDatos.DataSource = query.ToList();
            grvDatos.DataBind();
        }
    }
}