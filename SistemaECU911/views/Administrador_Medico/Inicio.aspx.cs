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
                totalFichasMedicas2();
            }
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] RevOrganosSistemas()
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] AntPersonales()
        {

            var olista = CN_Reporte_NPersona.Reporte_Sp_Grafico_AntecedentePer();
            var objetoLista1 = new List<object>();

            int maxLength = olista.Count;

            for (int j = 0; j < maxLength; j++)
            {
                // Aquí debes usar las propiedades correspondientes de tu objeto "olista" para obtener los valores
                string cantPersonaSeleccioneAntecePerson = "";
                int cantPersonaEnferCardiVascuAntecePerson = 0;
                int cantPersonaEnferMetabAntecePerson = 0;
                int cantPersonaEnferNeuroAntecePerson = 0;
                int cantPersonaEnferOncolAntecePerson = 0;
                int cantPersonaEnferInfecAntecePerson = 0;
                int cantPersonaEnferHered_CongóAntecePerson = 0;
                int cantPersonaDiscaAntecePerson = 0;
                int cantPersonaOtrosAntecePerson = 0;
                // Agrega las demás variables aquí


                if (j < olista.Count)
                {
                    cantPersonaSeleccioneAntecePerson = olista[j].CantPersonaSinAntecedenteAntecePerson.ToString();
                    cantPersonaEnferCardiVascuAntecePerson = olista[j].CantPersonaEnferCardiVascuAntecePerson ?? 0;
                    cantPersonaEnferMetabAntecePerson = olista[j].CantPersonaEnferMetabAntecePerson ?? 0;
                    cantPersonaEnferNeuroAntecePerson = olista[j].CantPersonaEnferNeuroAntecePerson ?? 0;
                    // Asigna los valores de las demás variables aquí
                    cantPersonaEnferOncolAntecePerson = olista[j].CantPersonaEnferOncolAntecePerson ?? 0;
                    cantPersonaEnferInfecAntecePerson = olista[j].CantPersonaEnferInfecAntecePerson ?? 0;
                    cantPersonaEnferHered_CongóAntecePerson = olista[j].CantPersonaEnferHered_CongóAntecePerson ?? 0;
                    cantPersonaDiscaAntecePerson = olista[j].CantPersonaDiscaAntecePerson ?? 0;

                    cantPersonaOtrosAntecePerson = olista[j].CantPersonaOtrosAntecePerson ?? 0;

                }

                objetoLista1.Add(new object[] {
            cantPersonaSeleccioneAntecePerson,
            cantPersonaEnferCardiVascuAntecePerson,
            cantPersonaEnferMetabAntecePerson,
            cantPersonaEnferNeuroAntecePerson,
            cantPersonaEnferOncolAntecePerson,
            cantPersonaEnferInfecAntecePerson,
            cantPersonaEnferHered_CongóAntecePerson,
            cantPersonaDiscaAntecePerson,
            cantPersonaOtrosAntecePerson
            // Agrega las demás variables aquí
        });
            }

            return objetoLista1.ToArray();
        }

        public void totalFichasMedicas2()
        {

            //Sin Antecedente
            var PersonasSinAntecedentes = CN_Reporte_NPersona.ObtenerEnfSinAntecedente();
            //Cardiovascular
            var PersonasCardiovascular = CN_Reporte_NPersona.ObtenerEnfCardioVascular();
            //Metabolica
            var PersonasMetabolica = CN_Reporte_NPersona.ObtenerEnfMetabolica();
            //Neurologica
            var PersonasNeurologicas = CN_Reporte_NPersona.ObtenerEnfNeurologica();
            //Oncologica
            var PersonasOncologicas = CN_Reporte_NPersona.ObtenerEnfOncologica();
            //Infecciosa
            var PersonasInfecciosas = CN_Reporte_NPersona.ObtenerEnfInfecciosa();
            //Congonita
            var PersonasCongonita = CN_Reporte_NPersona.ObtenerEnfHereditariaCongonita();
            //Discapacidad
            var PersonasDiscapacidad = CN_Reporte_NPersona.ObtenerEnfDiscapacidad();
            //Otros
            var PersonasOtros = CN_Reporte_NPersona.ObtenerEnfOtros();

            //total Personas con Enfermedades
            var totalPersonasRegistradas = CN_Reporte_NPersona.ObtenerPersonasTotal();

            double totalPersonasSinAntecedentes = ((double)PersonasSinAntecedentes.Count / totalPersonasRegistradas.Count) * 100;
            double totalPersonasCardiovascular = ((double)PersonasCardiovascular.Count / totalPersonasRegistradas.Count) * 100;
            double totalPersonasMetabolica = ((double)PersonasMetabolica.Count / totalPersonasRegistradas.Count) * 100;
            double totalPersonasNeurologicas = ((double)PersonasNeurologicas.Count / totalPersonasRegistradas.Count) * 100;
            double totalPersonasOncologicas = ((double)PersonasOncologicas.Count / totalPersonasRegistradas.Count) * 100;
            double totalPersonasInfecciosas = ((double)PersonasInfecciosas.Count / totalPersonasRegistradas.Count) * 100;
            double totalPersonasCongonita = ((double)PersonasCongonita.Count / totalPersonasRegistradas.Count) * 100;
            double totalPersonasDiscapacidad = ((double)PersonasDiscapacidad.Count / totalPersonasRegistradas.Count) * 100;
            double totalPersonasOtros = ((double)PersonasOtros.Count / totalPersonasRegistradas.Count) * 100;

            // Asigna el valor a un control, como un Label, para mostrarlo en la página
            lbl_sinAntecedente.Text = $"Porcentaje de personas Sin Antecedentes: {totalPersonasSinAntecedentes:F2}%";
            lbl_cardioVascular.Text = $"Porcentaje de personas CardioVascular: {totalPersonasCardiovascular:F2}%";
            lbl_metabolica.Text = $"Porcentaje de personas Metabólica: {totalPersonasMetabolica:F2}%";
            lbl_neurologia.Text = $"Porcentaje de personas Neurologicas: {totalPersonasNeurologicas:F2}%";
            lbl_oncologica.Text = $"Porcentaje de personas Oncologicas: {totalPersonasOncologicas:F2}%";
            lbl_infecciosa.Text = $"Porcentaje de personas Infecciosas: {totalPersonasInfecciosas:F2}%";
            lbl_herediCongonita.Text = $"Porcentaje de personas Congonita: {totalPersonasCongonita:F2}%";
            lbl_discapacidad.Text = $"Porcentaje de personas Discapacidad: {totalPersonasDiscapacidad:F2}%";
            lbl_otros.Text = $"Porcentaje de personas Otros: {totalPersonasOtros:F2}%";

        }


    }

}