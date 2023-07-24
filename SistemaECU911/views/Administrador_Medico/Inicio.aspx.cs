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
using iTextSharp.text;

namespace SistemaECU911.Template.Views
{
    public partial class Inicio : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cantidadPacientes();
                //grvPacientes.VirtualItemCount = Count();
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] ListaNPersonas()
        {
            var olista = CN_Reporte_NPersona.Reporte_Sp_Grafico_OrganosYSistemas();
            var objetoLista = new List<object>();

            int maxLength = olista.Count;

            for (int j = 0; j < maxLength; j++)
            {

                string cantPersonaOrgSentConPatologia = "";
                int cantPersonaOrgSentSinPatologia = 0;
                int cantPersonaRespiConPatologia = 0;
                int cantPersonaRespiSinPatologia = 0;
                // Agrega las demás variables aquí
                int cantPersonaCardioVascularConPatologia = 0;
                int cantPersonaCardioVascularSinPatologia = 0;
                int cantPersonaDigestivoConPatologia = 0;
                int cantPersonaDigestivoSinPatologia = 0;
                int cantPersonaGenitalConPatologia = 0;
                int cantPersonaGenitalSinPatologia = 0;
                int cantPersonaUrinarioConPatologia = 0;
                int cantPersonaUrinarioSinPatologia = 0;
                int cantPersonaMuscularConPatologia = 0;
                int cantPersonaMuscularSinPatologia = 0;
                int cantPersonaEsqueleticoConPatologia = 0;
                int cantPersonaEsqueleticoSinPatologia = 0;
                int cantPersonaNerviosoConPatologia = 0;
                int cantPersonaNerviosoSinPatologia = 0;
                int cantPersonaEndocrinoConPatologia = 0;
                int cantPersonaEndocrinoSinPatologia = 0;
                int cantPersonaHemoLinfaticoConPatologia = 0;
                int cantPersonaHemoLinfaticoSinPatologia = 0;
                int cantPersonaTegumentarioConPatologia = 0;
                int cantPersonaTegumentarioSinPatologia = 0;

                if (j < olista.Count)
                {
                    cantPersonaOrgSentConPatologia = olista[j].CantPersonaOrgSentConPatologia?.ToString();
                    cantPersonaOrgSentSinPatologia = olista[j].CantPersonaOrgSentSinPatologia ?? 0;
                    cantPersonaRespiConPatologia = olista[j].CantPersonaRespiConPatologia ?? 0;
                    cantPersonaRespiSinPatologia = olista[j].CantPersonaRespiSinPatologia ?? 0;
                    // Asigna los valores de las demás variables aquí
                    cantPersonaCardioVascularConPatologia = olista[j].CantPersonaCardioVascConPatologia ?? 0;
                    cantPersonaCardioVascularSinPatologia = olista[j].CantPersonaCardioVascSinPatologia ?? 0;
                    cantPersonaDigestivoConPatologia = olista[j].CantPersonaDigestivoConPatologia ?? 0;
                    cantPersonaDigestivoSinPatologia = olista[j].CantPersonaDigestivoSinPatologia ?? 0;
                    cantPersonaGenitalConPatologia = olista[j].CantPersonaGenitalConPatologia ?? 0;
                    cantPersonaGenitalSinPatologia = olista[j].CantPersonaGenitalSinPatologia ?? 0;
                    cantPersonaUrinarioConPatologia = olista[j].CantPersonaUrinarioConPatologia ?? 0;
                    cantPersonaUrinarioSinPatologia = olista[j].CantPersonaUrinarioSinPatologia ?? 0;
                    cantPersonaMuscularConPatologia = olista[j].CantPersonaMuscularConPatologia ?? 0;
                    cantPersonaMuscularSinPatologia = olista[j].CantPersonaMuscularSinPatologia ?? 0;
                    cantPersonaEsqueleticoConPatologia = olista[j].CantPersonaEsqueleticoConPatologia ?? 0;
                    cantPersonaEsqueleticoSinPatologia = olista[j].CantPersonaEsqueleticoSinPatologia ?? 0;
                    cantPersonaNerviosoConPatologia = olista[j].CantPersonaNerviosoConPatologia ?? 0;
                    cantPersonaNerviosoSinPatologia = olista[j].CantPersonaNerviosoSinPatologia ?? 0;
                    cantPersonaEndocrinoConPatologia = olista[j].CantPersonaEndocrinoConPatologia ?? 0;
                    cantPersonaEndocrinoSinPatologia = olista[j].CantPersonaEndocrinoSinPatologia ?? 0;
                    cantPersonaHemoLinfaticoConPatologia = olista[j].CantPersonaHemoLinfaticoConPatologia ?? 0;
                    cantPersonaHemoLinfaticoSinPatologia = olista[j].CantPersonaHemoLinfaticoSinPatologia ?? 0;
                    cantPersonaTegumentarioConPatologia = olista[j].CantPersonaTegumentarioConPatologia ?? 0;
                    cantPersonaTegumentarioSinPatologia = olista[j].CantPersonaTegumentarioSinPatologia ?? 0;
                }

                objetoLista.Add(new object[] {
            cantPersonaOrgSentConPatologia,
            cantPersonaOrgSentSinPatologia,
            cantPersonaRespiConPatologia,
            cantPersonaRespiSinPatologia,
            // Agrega las demás variables aquí
            cantPersonaCardioVascularConPatologia,
            cantPersonaCardioVascularSinPatologia,
            cantPersonaDigestivoConPatologia,
            cantPersonaDigestivoSinPatologia,
            cantPersonaGenitalConPatologia,
            cantPersonaGenitalSinPatologia,
            cantPersonaUrinarioConPatologia,
            cantPersonaUrinarioSinPatologia,
            cantPersonaMuscularConPatologia,
            cantPersonaMuscularSinPatologia,
            cantPersonaEsqueleticoConPatologia,
            cantPersonaEsqueleticoSinPatologia,
            cantPersonaNerviosoConPatologia,
            cantPersonaNerviosoSinPatologia,
            cantPersonaEndocrinoConPatologia,
            cantPersonaEndocrinoSinPatologia,
            cantPersonaHemoLinfaticoConPatologia,
            cantPersonaHemoLinfaticoSinPatologia,
            cantPersonaTegumentarioConPatologia,
            cantPersonaTegumentarioSinPatologia
        });
            }

            return objetoLista.ToArray();
        }

        public void cantidadPacientes()
        {
            //cargar informacion cards
            var querySocio = dc.Tbl_Person.Count(p => p.Per_estado == "IN");
            totalInactivos.Text = querySocio.ToString();
            var queryPaciente = dc.Tbl_Person.Count(pa => pa.Per_estado == "AP");
            totalPacientes.Text = queryPaciente.ToString();
            var queryEcu = dc.Tbl_Person.Count(ec => ec.Emp_id == 1);
            totalEcu.Text = queryEcu.ToString();
            var queryArticulados = dc.Tbl_Person.Count(ar => ar.Emp_id != 1);
            totalArticulados.Text = queryArticulados.ToString();
        }
    }
}