using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SistemaECU911.Template.Views
{
    public partial class Inicial : System.Web.UI.Page
    {

        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        private Tbl_Empresa emp = new Tbl_Empresa();
        private Tbl_Centro cen = new Tbl_Centro();
        private Tbl_Inicial inicial = new Tbl_Inicial();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    inicial = CN_Inicial.ObtenerInicialPorId(codigo);
                    int personasid = Convert.ToInt32(inicial.Per_id.ToString());
                    per = CN_HistorialMedico.ObtenerPersonasxId(personasid);
                    int empresaid = Convert.ToInt32(inicial.Emp_id.ToString());
                    emp = CN_HistorialMedico.ObtenerEmpresaxId(empresaid);

                    btn_guardar.Text = "Actualizar";

                    if (per != null || emp != null)
                    {
                        txt_numHClinica.ReadOnly = true;
                        cargarProfesional();
                        ddl_profesional.Enabled = false;

                        //Religion
                        if (inicial.inicial_catolicaRel == null)
                        {
                            ckb_catolica.Checked = false;

                        }
                        else
                        {
                            ckb_catolica.Checked = true;
                        }
                        if (inicial.inicial_evangelicaRel == null)
                        {
                            ckb_evangelica.Checked = false;

                        }
                        else
                        {
                            ckb_evangelica.Checked = true;
                        }
                        if (inicial.inicial_testJehovaRel == null)
                        {
                            ckb_testigo.Checked = false;

                        }
                        else
                        {
                            ckb_testigo.Checked = true;
                        }
                        if (inicial.inicial_mormonaRel == null)
                        {
                            ckb_mormona.Checked = false;

                        }
                        else
                        {
                            ckb_mormona.Checked = true;
                        }
                        if (inicial.inicial_otrasRel == null)
                        {
                            ckb_otrareligion.Checked = false;

                        }
                        else
                        {
                            ckb_otrareligion.Checked = true;
                        }

                        //Orientacion Sexual
                        if (inicial.inicial_gayOriSex == null)
                        {
                            cbk_gay.Checked = false;

                        }
                        else
                        {
                            cbk_gay.Checked = true;
                        }
                        if (inicial.inicial__lesbianaOriSex == null)
                        {
                            cbk_lesbiana.Checked = false;
                        }
                        else
                        {
                            cbk_lesbiana.Checked = true;
                        }
                        if (inicial.inicial_bisexualOriSex == null)
                        {
                            cbk_bisexual.Checked = false;

                        }
                        else
                        {
                            cbk_bisexual.Checked = true;
                        }
                        if (inicial.inicial_heterosexualOriSex == null)
                        {
                            cbk_heterosexual.Checked = false;

                        }
                        else
                        {
                            cbk_heterosexual.Checked = true;
                        }
                        if (inicial.inicial_norespondeOriSex == null)
                        {
                            cbk_noRespondeOriSex.Checked = false;

                        }
                        else
                        {
                            cbk_noRespondeOriSex.Checked = true;
                        }

                        //Identidad de genero
                        if (inicial.inicial_femeninoIdenGen == null)
                        {
                            cbk_femenino.Checked = false;

                        }
                        else
                        {
                            cbk_femenino.Checked = true;
                        }
                        if (inicial.inicial_masculinoIdenGen == null)
                        {
                            cbk_masculino.Checked = false;

                        }
                        else
                        {
                            cbk_masculino.Checked = true;
                        }
                        if (inicial.inicial_transFemeninoIdenGen == null)
                        {
                            cbk_transfemenino.Checked = false;

                        }
                        else
                        {
                            cbk_transfemenino.Checked = true;
                        }
                        if (inicial.inicial_transMasculinoIdenGen == null)
                        {
                            cbk_transmasculino.Checked = false;

                        }
                        else
                        {
                            cbk_transmasculino.Checked = true;
                        }
                        if (inicial.inicial_norespondeIdenGen == null)
                        {
                            cbk_noRespondeIdeGen.Checked = false;

                        }
                        else
                        {
                            cbk_noRespondeIdeGen.Checked = true;
                        }

                        //Discapacidad
                        if (inicial.inicial_siDis == null)
                        {
                            cbk_sidiscapacidad.Checked = false;

                        }
                        else
                        {
                            cbk_sidiscapacidad.Checked = true;
                        }
                        if (inicial.inicial_noDis == null)
                        {
                            cbk_nodiscapacidad.Checked = false;

                        }
                        else
                        {
                            cbk_nodiscapacidad.Checked = true;
                        }

                        //Vida sexual
                        if (inicial.inicial_siVidaSexActiva == null)
                        {
                            ckb_siVidSexAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_siVidSexAntGinObste.Checked = true;
                        }
                        if (inicial.inicial_noVidaSexActiva == null)
                        {
                            ckb_noVidSexAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_noVidSexAntGinObste.Checked = true;
                        }

                        //Metodo de planificacion familiar Antecedentes gineco obstetricos
                        if (inicial.inicial_siMetPlanifiFamiliar == null)
                        {
                            ckb_siMetPlaniAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_siMetPlaniAntGinObste.Checked = true;
                        }
                        if (inicial.inicial_noMetPlanifiFamiliar == null)
                        {
                            ckb_noMetPlaniAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_noMetPlaniAntGinObste.Checked = true;
                        }

                        //Papanicolaou
                        if (inicial.inicial_siExaRealiPapanicolaou == null)
                        {
                            ckb_siPapaniAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_siPapaniAntGinObste.Checked = true;
                        }
                        if (inicial.inicial_noExaRealiPapanicolaou == null)
                        {
                            ckb_noPapaniAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_noPapaniAntGinObste.Checked = true;
                        }

                        //Eco Mamario
                        if (inicial.inicial_siExaRealiEcoMamario == null)
                        {
                            ckb_siEcoMamaAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_siEcoMamaAntGinObste.Checked = true;
                        }
                        if (inicial.inicial_noExaRealiEcoMamario == null)
                        {
                            ckb_noEcoMamaAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_noEcoMamaAntGinObste.Checked = true;
                        }

                        //Colposcopia
                        if (inicial.inicial_siExaRealiColposcopia == null)
                        {
                            ckb_siColposAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_siColposAntGinObste.Checked = true;
                        }
                        if (inicial.inicial_noExaRealiColposcopia == null)
                        {
                            ckb_siMamograAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_siMamograAntGinObste.Checked = true;
                        }

                        //Mamografia
                        if (inicial.inicial_siExaRealiMamografia == null)
                        {
                            ckb_siMamograAntGinObste.Checked = false;
                        }
                        else
                        {
                            ckb_siMamograAntGinObste.Checked = true;
                        }
                        if (inicial.inicial_noExaRealiMamografia == null)
                        {
                            ckb_noMamograAntGinObste.Checked = false;

                        }
                        else
                        {
                            ckb_noMamograAntGinObste.Checked = true;
                        }

                        //Antigeno Prostatico
                        if (inicial.inicial_siExaRealiAntiProstatico == null)
                        {
                            ckb_siExaRealiAntProstaAntReproMascu.Checked = false;

                        }
                        else
                        {
                            ckb_siExaRealiAntProstaAntReproMascu.Checked = true;
                        }
                        if (inicial.inicial_noExaRealiAntiProstatico == null)
                        {
                            ckb_noExaRealiAntProstaAntReproMascu.Checked = false;

                        }
                        else
                        {
                            ckb_noExaRealiAntProstaAntReproMascu.Checked = true;
                        }

                        //Metodo de planificacion familiar Antecedentes reproductivos masculinos
                        if (inicial.inicial_siMetPlanifiFamiAntReproMascu == null)
                        {
                            ckb_siMetPlaniAntReproMascu.Checked = false;

                        }
                        else
                        {
                            ckb_siMetPlaniAntReproMascu.Checked = true;
                        }
                        if (inicial.inicial_noMetPlanifiFamiAntReproMascu == null)
                        {
                            ckb_noMetPlaniAntReproMascu.Checked = false;

                        }
                        else
                        {
                            ckb_noMetPlaniAntReproMascu.Checked = true;
                        }

                        //Eco Prostatico
                        if (inicial.inicial_siExaRealiEcoProstatico == null)
                        {
                            ckb_siExaRealiEcoProstaAntReproMascu.Checked = false;

                        }
                        else
                        {
                            ckb_siExaRealiEcoProstaAntReproMascu.Checked = true;
                        }
                        if (inicial.inicial_noExaRealiEcoProstatico == null)
                        {
                            ckb_noExaRealiEcoProstaAntReproMascu.Checked = false;

                        }
                        else
                        {
                            ckb_noExaRealiEcoProstaAntReproMascu.Checked = true;
                        }

                        //Tabaco
                        if (inicial.inicial_siConsuNocivosTabaco == null)
                        {
                            ckb_siConsuNociTabaHabToxi.Checked = false;

                        }
                        else
                        {
                            ckb_siConsuNociTabaHabToxi.Checked = true;
                        }
                        if (inicial.inicial_noConsuNocivosTabaco == null)
                        {
                            ckb_noConsuNociTabaHabToxi.Checked = false;

                        }
                        else
                        {
                            ckb_noConsuNociTabaHabToxi.Checked = true;
                        }

                        //Alcohol
                        if (inicial.inicial_siConsuNocivosAlcohol == null)
                        {
                            ckb_siConsuNociAlcoHabToxi.Checked = false;

                        }
                        else
                        {
                            ckb_siConsuNociAlcoHabToxi.Checked = true;
                        }
                        if (inicial.inicial_noConsuNocivosAlcohol == null)
                        {
                            ckb_noConsuNociAlcoHabToxi.Checked = false;

                        }
                        else
                        {
                            ckb_noConsuNociAlcoHabToxi.Checked = true;
                        }

                        //Otras Drogas
                        if (inicial.inicial_siConsuNocivosOtrasDrogas == null)
                        {
                            ckb_siConsuNociOtrasDroHabToxi.Checked = false;

                        }
                        else
                        {
                            ckb_siConsuNociOtrasDroHabToxi.Checked = true;
                        }
                        if (inicial.inicial_noConsuNocivosOtrasDrogas == null)
                        {
                            ckb_noConsuNociOtrasDroHabToxi.Checked = false;

                        }
                        else
                        {
                            ckb_noConsuNociOtrasDroHabToxi.Checked = true;
                        }

                        //Actividad Fisica
                        if (inicial.inicial_siEstiVidaActFisica == null)
                        {
                            ckb_siEstVidaActFisiEstVida.Checked = false;

                        }
                        else
                        {
                            ckb_siEstVidaActFisiEstVida.Checked = true;
                        }
                        if (inicial.inicial_noEstiVidaActFisica == null)
                        {
                            ckb_noEstVidaActFisiEstVida.Checked = false;

                        }
                        else
                        {
                            ckb_noEstVidaActFisiEstVida.Checked = true;
                        }

                        //Medicacion Habitual
                        if (inicial.inicial_siEstiVidaMediHabitual == null)
                        {
                            ckb_siEstVidaMedHabiEstVida.Checked = false;

                        }
                        else
                        {
                            ckb_siEstVidaMedHabiEstVida.Checked = true;
                        }
                        if (inicial.inicial_noEstiVidaMediHabitual == null)
                        {
                            ckb_noEstVidaMedHabiEstVida.Checked = false;

                        }
                        else
                        {
                            ckb_noEstVidaMedHabiEstVida.Checked = true;
                        }

                        //Riesgo Antecedentes de empleos anteriores
                        if (inicial.inicial_fisicoRies == null)
                        {
                            ckb_fisico.Checked = false;

                        }
                        else
                        {
                            ckb_fisico.Checked = true;
                        }
                        if (inicial.inicial_mecanicoRies == null)
                        {
                            ckb_mecanico.Checked = false;

                        }
                        else
                        {
                            ckb_mecanico.Checked = true;
                        }
                        if (inicial.inicial_quimicoRies == null)
                        {
                            ckb_quimico.Checked = false;

                        }
                        else
                        {
                            ckb_quimico.Checked = true;
                        }
                        if (inicial.inicial_biologicoRies == null)
                        {
                            ckb_biologico.Checked = false;

                        }
                        else
                        {
                            ckb_biologico.Checked = true;
                        }
                        if (inicial.inicial_ergonomicoRies == null)
                        {
                            ckb_ergonomico.Checked = false;

                        }
                        else
                        {
                            ckb_ergonomico.Checked = true;
                        }
                        if (inicial.inicial_psicosocial == null)
                        {
                            ckb_psicosocial.Checked = false;

                        }
                        else
                        {
                            ckb_psicosocial.Checked = true;
                        }
                        if (inicial.inicial_fisicoRies2 == null)
                        {
                            ckb_fisico2.Checked = false;

                        }
                        else
                        {
                            ckb_fisico2.Checked = true;
                        }
                        if (inicial.inicial_mecanicoRies2 == null)
                        {
                            ckb_mecanico2.Checked = false;

                        }
                        else
                        {
                            ckb_mecanico2.Checked = true;
                        }
                        if (inicial.inicial_quimicoRies2 == null)
                        {
                            ckb_quimico2.Checked = false;

                        }
                        else
                        {
                            ckb_quimico2.Checked = true;
                        }
                        if (inicial.inicial_biologicoRies2 == null)
                        {
                            ckb_biologico2.Checked = false;

                        }
                        else
                        {
                            ckb_biologico2.Checked = true;
                        }
                        if (inicial.inicial_ergonomicoRies2 == null)
                        {
                            ckb_ergonomico2.Checked = false;

                        }
                        else
                        {
                            ckb_ergonomico2.Checked = true;
                        }
                        if (inicial.inicial_psicosocial2 == null)
                        {
                            ckb_psicosocial2.Checked = false;

                        }
                        else
                        {
                            ckb_psicosocial2.Checked = true;
                        }
                        if (inicial.inicial_fisicoRies3 == null)
                        {
                            ckb_fisico3.Checked = false;

                        }
                        else
                        {
                            ckb_fisico3.Checked = true;
                        }
                        if (inicial.inicial_mecanicoRies3 == null)
                        {
                            ckb_mecanico3.Checked = false;

                        }
                        else
                        {
                            ckb_mecanico3.Checked = true;
                        }
                        if (inicial.inicial_quimicoRies3 == null)
                        {
                            ckb_quimico3.Checked = false;

                        }
                        else
                        {
                            ckb_quimico3.Checked = true;
                        }
                        if (inicial.inicial_biologicoRies3 == null)
                        {
                            ckb_biologico3.Checked = false;

                        }
                        else
                        {
                            ckb_biologico3.Checked = true;
                        }
                        if (inicial.inicial_ergonomicoRies3 == null)
                        {
                            ckb_ergonomico3.Checked = false;

                        }
                        else
                        {
                            ckb_ergonomico3.Checked = true;
                        }
                        if (inicial.inicial_psicosocial3 == null)
                        {
                            ckb_psicosocial3.Checked = false;

                        }
                        else
                        {
                            ckb_psicosocial3.Checked = true;
                        }
                        if (inicial.inicial_fisicoRies4 == null)
                        {
                            ckb_fisico4.Checked = false;

                        }
                        else
                        {
                            ckb_fisico4.Checked = true;
                        }
                        if (inicial.inicial_mecanicoRies4 == null)
                        {
                            ckb_mecanico4.Checked = false;

                        }
                        else
                        {
                            ckb_mecanico4.Checked = true;
                        }
                        if (inicial.inicial_quimicoRies4 == null)
                        {
                            ckb_quimico4.Checked = false;

                        }
                        else
                        {
                            ckb_quimico4.Checked = true;
                        }
                        if (inicial.inicial_biologicoRies4 == null)
                        {
                            ckb_biologico4.Checked = false;

                        }
                        else
                        {
                            ckb_biologico4.Checked = true;
                        }
                        if (inicial.inicial_ergonomicoRies4 == null)
                        {

                            ckb_ergonomico4.Checked = false;
                        }
                        else
                        {
                            ckb_ergonomico4.Checked = true;
                        }
                        if (inicial.inicial_psicosocial4 == null)
                        {

                            ckb_psicosocial4.Checked = false;
                        }
                        else
                        {
                            ckb_psicosocial4.Checked = true;
                        }

                        //ANTECEDENTES PERSONALES
                        //----------- ACCIDENTES DE TRABAJO ( DESCRIPCIÓN) -----------
                        if (inicial.inicial_siCalificadoIESSAcciTrabajo == null)
                        {
                            ckb_siAccTrabDescrip.Checked = false;
                        }
                        else
                        {
                            ckb_siAccTrabDescrip.Checked = true;
                        }
                        if (inicial.inicial_noCalificadoIESSAcciTrabajo == null)
                        {
                            ckb_noAccTrabDescrip.Checked = false;
                        }
                        else
                        {
                            ckb_noAccTrabDescrip.Checked = true;
                        }
                        //----------- ENFERMEDADES PROFESIONALES -----------
                        if (inicial.inicial_siCalificadoIESSEnfProfesionales == null)
                        {
                            ckb_siprofesional.Checked = false;
                        }
                        else
                        {
                            ckb_siprofesional.Checked = true;
                        }
                        if (inicial.inicial_noCalificadoIESSEnfProfesionales == null)
                        {
                            ckb_noprofesional.Checked = false;
                        }
                        else
                        {
                            ckb_noprofesional.Checked = true;
                        }

                        //Antecedentes Familiares (Detallar el Parentesco)
                        if (inicial.inicial_enfCarVasAnteFamiliares == null)
                        {
                            ckb_enfermedadcardiovascular.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadcardiovascular.Checked = true;

                        }
                        if (inicial.inicial_enfMetaAnteFamiliares == null)
                        {
                            ckb_enfermedadmetabolica.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadmetabolica.Checked = true;

                        }
                        if (inicial.inicial_enfNeuroAnteFamiliares == null)
                        {
                            ckb_enfermedadneurologica.Checked = false; ;
                        }
                        else
                        {
                            ckb_enfermedadneurologica.Checked = true;

                        }
                        if (inicial.inicial_enfOncoAnteFamiliares == null)
                        {
                            ckb_enfermedadoncologica.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadoncologica.Checked = true;

                        }
                        if (inicial.inicial_enfInfeAnteFamiliares == null)
                        {
                            ckb_enfermedadinfecciosa.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadinfecciosa.Checked = true;

                        }
                        if (inicial.inicial_enfHereCongeAnteFamiliares == null)
                        {
                            ckb_enfermedadhereditaria.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadhereditaria.Checked = true;

                        }
                        if (inicial.inicial_discapaAnteFamiliares == null)
                        {
                            ckb_discapacidades.Checked = false;
                        }
                        else
                        {
                            ckb_discapacidades.Checked = true;

                        }
                        if (inicial.inicial_otrosAnteFamiliares == null)
                        {
                            ckb_otrosenfer.Checked = false;
                        }
                        else
                        {
                            ckb_otrosenfer.Checked = true;

                        }

                        //Factores de riesgo del puesto de trabajo
                        //----------- Fisico -----------
                        if (inicial.inicial_temAltasFis == null)
                        {
                            ckb_tempaltas.Checked = false;
                        }
                        else
                        {
                            ckb_tempaltas.Checked = true;
                        }
                        if (inicial.inicial_temAltasFis2 == null)
                        {
                            ckb_tempaltas2.Checked = false;
                        }
                        else
                        {
                            ckb_tempaltas2.Checked = true;
                        }
                        if (inicial.inicial_temAltasFis3 == null)
                        {
                            ckb_tempaltas3.Checked = false;
                        }
                        else
                        {
                            ckb_tempaltas3.Checked = true;
                        }
                        if (inicial.inicial_temAltasFis4 == null)
                        {
                            ckb_tempaltas4.Checked = false;
                        }
                        else
                        {
                            ckb_tempaltas4.Checked = true;
                        }
                        if (inicial.inicial_temBajasFis == null)
                        {
                            ckb_tempbajas.Checked = false;
                        }
                        else
                        {
                            ckb_tempbajas.Checked = true;

                        }
                        if (inicial.inicial_temBajasFis2 == null)
                        {
                            ckb_tempbajas2.Checked = false;
                        }
                        else
                        {
                            ckb_tempbajas2.Checked = true;
                        }
                        if (inicial.inicial_temBajasFis3 == null)
                        {
                            ckb_tempbajas3.Checked = false;
                        }
                        else
                        {
                            ckb_tempbajas3.Checked = true;

                        }
                        if (inicial.inicial_temBajasFis4 == null)
                        {
                            ckb_tempbajas4.Checked = false;
                        }
                        else
                        {
                            ckb_tempbajas4.Checked = true;

                        }
                        if (inicial.inicial_radIonizanteFis == null)
                        {
                            ckb_radiacion.Checked = false;
                        }
                        else
                        {
                            ckb_radiacion.Checked = true;

                        }
                        if (inicial.inicial_radIonizanteFis2 == null)
                        {
                            ckb_radiacion2.Checked = false;
                        }
                        else
                        {
                            ckb_radiacion2.Checked = true;

                        }
                        if (inicial.inicial_radIonizanteFis3 == null)
                        {
                            ckb_radiacion3.Checked = false;
                        }
                        else
                        {
                            ckb_radiacion3.Checked = true;

                        }
                        if (inicial.inicial_radIonizanteFis4 == null)
                        {
                            ckb_radiacion4.Checked = false;
                        }
                        else
                        {
                            ckb_radiacion4.Checked = true;

                        }
                        if (inicial.inicial_radNoIonizanteFis == null)
                        {
                            ckb_noradiacion.Checked = false;
                        }
                        else
                        {
                            ckb_noradiacion.Checked = true;

                        }
                        if (inicial.inicial_radNoIonizanteFis2 == null)
                        {
                            ckb_noradiacion2.Checked = false;
                        }
                        else
                        {
                            ckb_noradiacion2.Checked = true;

                        }
                        if (inicial.inicial_radNoIonizanteFis3 == null)
                        {
                            ckb_noradiacion3.Checked = false;
                        }
                        else
                        {
                            ckb_noradiacion3.Checked = true;

                        }
                        if (inicial.inicial_radNoIonizanteFis4 == null)
                        {
                            ckb_noradiacion4.Checked = false;
                        }
                        else
                        {
                            ckb_noradiacion4.Checked = true;

                        }
                        if (inicial.inicial_ruidoFis == null)
                        {
                            ckb_ruido.Checked = false;
                        }
                        else
                        {
                            ckb_ruido.Checked = true;

                        }
                        if (inicial.inicial_ruidoFis2 == null)
                        {
                            ckb_ruido2.Checked = false;
                        }
                        else
                        {
                            ckb_ruido2.Checked = true;

                        }
                        if (inicial.inicial_ruidoFis3 == null)
                        {
                            ckb_ruido3.Checked = false;
                        }
                        else
                        {
                            ckb_ruido3.Checked = true;

                        }
                        if (inicial.inicial_ruidoFis4 == null)
                        {
                            ckb_ruido4.Checked = false;
                        }
                        else
                        {
                            ckb_ruido4.Checked = true;

                        }
                        if (inicial.inicial_vibracionFis == null)
                        {
                            ckb_vibracion.Checked = false;
                        }
                        else
                        {
                            ckb_vibracion.Checked = true;

                        }
                        if (inicial.inicial_vibracionFis2 == null)
                        {
                            ckb_vibracion2.Checked = false;
                        }
                        else
                        {
                            ckb_vibracion2.Checked = true;

                        }
                        if (inicial.inicial_vibracionFis3 == null)
                        {
                            ckb_vibracion3.Checked = false;
                        }
                        else
                        {
                            ckb_vibracion3.Checked = true;

                        }
                        if (inicial.inicial_vibracionFis4 == null)
                        {
                            ckb_vibracion4.Checked = false;
                        }
                        else
                        {
                            ckb_vibracion4.Checked = true;

                        }
                        if (inicial.inicial_iluminacionFis == null)
                        {
                            ckb_iluminacion.Checked = false;
                        }
                        else
                        {
                            ckb_iluminacion.Checked = true;

                        }
                        if (inicial.inicial_iluminacionFis2 == null)
                        {
                            ckb_iluminacion2.Checked = false;
                        }
                        else
                        {
                            ckb_iluminacion2.Checked = true;

                        }
                        if (inicial.inicial_iluminacionFis3 == null)
                        {
                            ckb_iluminacion3.Checked = false;
                        }
                        else
                        {
                            ckb_iluminacion3.Checked = true;

                        }
                        if (inicial.inicial_iluminacionFis4 == null)
                        {
                            ckb_iluminacion4.Checked = false;
                        }
                        else
                        {
                            ckb_iluminacion4.Checked = true;

                        }
                        if (inicial.inicial_ventilacionFis == null)
                        {
                            ckb_ventilacion.Checked = false;
                        }
                        else
                        {
                            ckb_ventilacion.Checked = true;

                        }
                        if (inicial.inicial_ventilacionFis2 == null)
                        {
                            ckb_ventilacion2.Checked = false;
                        }
                        else
                        {
                            ckb_ventilacion2.Checked = true;

                        }
                        if (inicial.inicial_ventilacionFis3 == null)
                        {
                            ckb_ventilacion3.Checked = false;
                        }
                        else
                        {
                            ckb_ventilacion3.Checked = true;

                        }
                        if (inicial.inicial_ventilacionFis4 == null)
                        {
                            ckb_ventilacion4.Checked = false;
                        }
                        else
                        {
                            ckb_ventilacion4.Checked = true;

                        }
                        if (inicial.inicial_fluElectricoFis == null)
                        {
                            ckb_fluidoelectrico.Checked = false;
                        }
                        else
                        {
                            ckb_fluidoelectrico.Checked = true;

                        }
                        if (inicial.inicial_fluElectricoFis2 == null)
                        {
                            ckb_fluidoelectrico2.Checked = false;
                        }
                        else
                        {
                            ckb_fluidoelectrico2.Checked = true;

                        }
                        if (inicial.inicial_fluElectricoFis3 == null)
                        {
                            ckb_fluidoelectrico3.Checked = false;
                        }
                        else
                        {
                            ckb_fluidoelectrico3.Checked = true;

                        }
                        if (inicial.inicial_fluElectricoFis4 == null)
                        {
                            ckb_fluidoelectrico4.Checked = false;
                        }
                        else
                        {
                            ckb_fluidoelectrico4.Checked = true;

                        }
                        if (inicial.inicial_otrosFis == null)
                        {
                            ckb_otrosFisico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosFisico.Checked = true;

                        }
                        if (inicial.inicial_otrosFis2 == null)
                        {
                            ckb_otrosFisico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosFisico2.Checked = true;

                        }
                        if (inicial.inicial_otrosFis3 == null)
                        {
                            ckb_otrosFisico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosFisico3.Checked = true;

                        }
                        if (inicial.inicial_otrosFis4 == null)
                        {
                            ckb_otrosFisico4.Checked = false;
                        }
                        else
                        {
                            ckb_otrosFisico4.Checked = true;

                        }
                        //----------- Mecanico -----------
                        if (inicial.inicial_atraMaquinasMec == null)
                        {
                            ckb_atrapmaquinas.Checked = false;
                        }
                        else
                        {
                            ckb_atrapmaquinas.Checked = true;

                        }
                        if (inicial.inicial_atraMaquinasMec2 == null)
                        {
                            ckb_atrapmaquinas2.Checked = false;
                        }
                        else
                        {
                            ckb_atrapmaquinas2.Checked = true;

                        }
                        if (inicial.inicial_atraMaquinasMec3 == null)
                        {
                            ckb_atrapmaquinas3.Checked = false;
                        }
                        else
                        {
                            ckb_atrapmaquinas3.Checked = true;

                        }
                        if (inicial.inicial_atraMaquinasMec4 == null)
                        {
                            ckb_atrapmaquinas4.Checked = false;
                        }
                        else
                        {
                            ckb_atrapmaquinas4.Checked = true;

                        }
                        if (inicial.inicial_atraSuperfiiesMec == null)
                        {
                            ckb_atrapsuperficie.Checked = false;
                        }
                        else
                        {
                            ckb_atrapsuperficie.Checked = true;

                        }
                        if (inicial.inicial_atraSuperfiiesMec2 == null)
                        {
                            ckb_atrapsuperficie2.Checked = false;
                        }
                        else
                        {
                            ckb_atrapsuperficie2.Checked = true;

                        }
                        if (inicial.inicial_atraSuperfiiesMec3 == null)
                        {
                            ckb_atrapsuperficie3.Checked = false;
                        }
                        else
                        {
                            ckb_atrapsuperficie3.Checked = true;

                        }
                        if (inicial.inicial_atraSuperfiiesMec4 == null)
                        {
                            ckb_atrapsuperficie4.Checked = false;
                        }
                        else
                        {
                            ckb_atrapsuperficie4.Checked = true;

                        }
                        if (inicial.inicial_atraObjetosMec == null)
                        {
                            ckb_atrapobjetos.Checked = false;
                        }
                        else
                        {
                            ckb_atrapobjetos.Checked = true;

                        }
                        if (inicial.inicial_atraObjetosMec2 == null)
                        {
                            ckb_atrapobjetos2.Checked = false;
                        }
                        else
                        {
                            ckb_atrapobjetos2.Checked = true;

                        }
                        if (inicial.inicial_atraObjetosMec3 == null)
                        {
                            ckb_atrapobjetos3.Checked = false;
                        }
                        else
                        {
                            ckb_atrapobjetos3.Checked = true;

                        }
                        if (inicial.inicial_atraObjetosMec4 == null)
                        {
                            ckb_atrapobjetos4.Checked = false;
                        }
                        else
                        {
                            ckb_atrapobjetos4.Checked = true;

                        }
                        if (inicial.inicial_caidaObjetosMec == null)
                        {
                            ckb_caidaobjetos.Checked = false;
                        }
                        else
                        {
                            ckb_caidaobjetos.Checked = true;

                        }
                        if (inicial.inicial_caidaObjetosMec2 == null)
                        {
                            ckb_caidaobjetos2.Checked = false;
                        }
                        else
                        {
                            ckb_caidaobjetos2.Checked = true;

                        }
                        if (inicial.inicial_caidaObjetosMec3 == null)
                        {
                            ckb_caidaobjetos3.Checked = false;
                        }
                        else
                        {
                            ckb_caidaobjetos3.Checked = true;

                        }
                        if (inicial.inicial_caidaObjetosMec4 == null)
                        {
                            ckb_caidaobjetos4.Checked = false;
                        }
                        else
                        {
                            ckb_caidaobjetos4.Checked = true;

                        }
                        if (inicial.inicial_caidaMisNivelMec == null)
                        {
                            ckb_caidamisnivel.Checked = false;
                        }
                        else
                        {
                            ckb_caidamisnivel.Checked = true;

                        }
                        if (inicial.inicial_caidaMisNivelMec2 == null)
                        {
                            ckb_caidamisnivel2.Checked = false;
                        }
                        else
                        {
                            ckb_caidamisnivel2.Checked = true;

                        }
                        if (inicial.inicial_caidaMisNivelMec3 == null)
                        {
                            ckb_caidamisnivel3.Checked = false;
                        }
                        else
                        {
                            ckb_caidamisnivel3.Checked = true;

                        }
                        if (inicial.inicial_caidaMisNivelMec4 == null)
                        {
                            ckb_caidamisnivel4.Checked = false;
                        }
                        else
                        {
                            ckb_caidamisnivel4.Checked = true;

                        }
                        if (inicial.inicial_caidaDifNivelMec == null)
                        {
                            ckb_caidadifnivel.Checked = false;
                        }
                        else
                        {
                            ckb_caidadifnivel.Checked = true;

                        }
                        if (inicial.inicial_caidaDifNivelMec2 == null)
                        {
                            ckb_caidadifnivel2.Checked = false;
                        }
                        else
                        {
                            ckb_caidadifnivel2.Checked = true;

                        }
                        if (inicial.inicial_caidaDifNivelMec3 == null)
                        {
                            ckb_caidadifnivel3.Checked = false;
                        }
                        else
                        {
                            ckb_caidadifnivel3.Checked = true;

                        }
                        if (inicial.inicial_caidaDifNivelMec4 == null)
                        {
                            ckb_caidadifnivel4.Checked = false;
                        }
                        else
                        {
                            ckb_caidadifnivel4.Checked = true;

                        }
                        if (inicial.inicial_contactoElecMec == null)
                        {
                            ckb_contaelectrico.Checked = false;
                        }
                        else
                        {
                            ckb_contaelectrico.Checked = true;

                        }
                        if (inicial.inicial_contactoElecMec2 == null)
                        {
                            ckb_contaelectrico2.Checked = false;
                        }
                        else
                        {
                            ckb_contaelectrico2.Checked = true;

                        }
                        if (inicial.inicial_contactoElecMec3 == null)
                        {
                            ckb_contaelectrico3.Checked = false;
                        }
                        else
                        {
                            ckb_contaelectrico3.Checked = true;

                        }
                        if (inicial.inicial_contactoElecMec4 == null)
                        {
                            ckb_contaelectrico4.Checked = false;
                        }
                        else
                        {
                            ckb_contaelectrico4.Checked = true;

                        }
                        if (inicial.inicial_conSuperTrabaMec == null)
                        {
                            ckb_contasuptrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_contasuptrabajo.Checked = true;

                        }
                        if (inicial.inicial_conSuperTrabaMec2 == null)
                        {
                            ckb_contasuptrabajo2.Checked = false;
                        }
                        else
                        {
                            ckb_contasuptrabajo2.Checked = true;

                        }
                        if (inicial.inicial_conSuperTrabaMec3 == null)
                        {
                            ckb_contasuptrabajo3.Checked = false;
                        }
                        else
                        {
                            ckb_contasuptrabajo3.Checked = true;

                        }
                        if (inicial.inicial_conSuperTrabaMec4 == null)
                        {
                            ckb_contasuptrabajo4.Checked = false;
                        }
                        else
                        {
                            ckb_contasuptrabajo4.Checked = true;

                        }
                        if (inicial.inicial_proPartiFragMec == null)
                        {
                            ckb_proyparticulas.Checked = false;
                        }
                        else
                        {
                            ckb_proyparticulas.Checked = true;

                        }
                        if (inicial.inicial_proPartiFragMec2 == null)
                        {
                            ckb_proyparticulas2.Checked = false;
                        }
                        else
                        {
                            ckb_proyparticulas2.Checked = true;

                        }
                        if (inicial.inicial_proPartiFragMec3 == null)
                        {
                            ckb_proyparticulas3.Checked = false;
                        }
                        else
                        {
                            ckb_proyparticulas3.Checked = true;

                        }
                        if (inicial.inicial_proPartiFragMec4 == null)
                        {
                            ckb_proyparticulas4.Checked = false;
                        }
                        else
                        {
                            ckb_proyparticulas4.Checked = true;

                        }
                        if (inicial.inicial_proFluidosMec == null)
                        {
                            ckb_proyefluidos.Checked = false;
                        }
                        else
                        {
                            ckb_proyefluidos.Checked = true;

                        }
                        if (inicial.inicial_proFluidosMec2 == null)
                        {
                            ckb_proyefluidos2.Checked = false;
                        }
                        else
                        {
                            ckb_proyefluidos2.Checked = true;

                        }
                        if (inicial.inicial_proFluidosMec3 == null)
                        {
                            ckb_proyefluidos3.Checked = false;
                        }
                        else
                        {
                            ckb_proyefluidos3.Checked = true;

                        }
                        if (inicial.inicial_proFluidosMec4 == null)
                        {
                            ckb_proyefluidos4.Checked = false;
                        }
                        else
                        {
                            ckb_proyefluidos4.Checked = true;

                        }
                        if (inicial.inicial_pinchazosMec == null)
                        {
                            ckb_pinchazos.Checked = false;
                        }
                        else
                        {
                            ckb_pinchazos.Checked = true;

                        }
                        if (inicial.inicial_pinchazosMec2 == null)
                        {
                            ckb_pinchazos2.Checked = false;
                        }
                        else
                        {
                            ckb_pinchazos2.Checked = true;

                        }
                        if (inicial.inicial_pinchazosMec3 == null)
                        {
                            ckb_pinchazos3.Checked = false;
                        }
                        else
                        {
                            ckb_pinchazos3.Checked = true;

                        }
                        if (inicial.inicial_pinchazosMec4 == null)
                        {
                            ckb_pinchazos4.Checked = false;
                        }
                        else
                        {
                            ckb_pinchazos4.Checked = true;

                        }
                        if (inicial.inicial_cortesMec == null)
                        {
                            ckb_cortes.Checked = false;
                        }
                        else
                        {
                            ckb_cortes.Checked = true;

                        }
                        if (inicial.inicial_cortesMec2 == null)
                        {
                            ckb_cortes2.Checked = false;
                        }
                        else
                        {
                            ckb_cortes2.Checked = true;

                        }
                        if (inicial.inicial_cortesMec3 == null)
                        {
                            ckb_cortes3.Checked = false;
                        }
                        else
                        {
                            ckb_cortes3.Checked = true;

                        }
                        if (inicial.inicial_cortesMec4 == null)
                        {
                            ckb_cortes4.Checked = false;
                        }
                        else
                        {
                            ckb_cortes4.Checked = true;

                        }
                        if (inicial.inicial_atropeVehiMec == null)
                        {
                            ckb_atroporvehiculos.Checked = false;
                        }
                        else
                        {
                            ckb_atroporvehiculos.Checked = true;

                        }
                        if (inicial.inicial_atropeVehiMec2 == null)
                        {
                            ckb_atroporvehiculos2.Checked = false;
                        }
                        else
                        {
                            ckb_atroporvehiculos2.Checked = true;

                        }
                        if (inicial.inicial_atropeVehiMec3 == null)
                        {
                            ckb_atroporvehiculos3.Checked = false;
                        }
                        else
                        {
                            ckb_atroporvehiculos3.Checked = true;

                        }
                        if (inicial.inicial_atropeVehiMec4 == null)
                        {
                            ckb_atroporvehiculos4.Checked = false;
                        }
                        else
                        {
                            ckb_atroporvehiculos4.Checked = true;

                        }
                        if (inicial.inicial_coliVehiMec == null)
                        {
                            ckb_choques.Checked = false;
                        }
                        else
                        {
                            ckb_choques.Checked = true;

                        }
                        if (inicial.inicial_coliVehiMec2 == null)
                        {
                            ckb_choques2.Checked = false;
                        }
                        else
                        {
                            ckb_choques2.Checked = true;

                        }
                        if (inicial.inicial_coliVehiMec3 == null)
                        {
                            ckb_choques3.Checked = false;
                        }
                        else
                        {
                            ckb_choques3.Checked = true;

                        }
                        if (inicial.inicial_coliVehiMec4 == null)
                        {
                            ckb_choques4.Checked = false;
                        }
                        else
                        {
                            ckb_choques4.Checked = true;

                        }
                        if (inicial.inicial_otrosMec == null)
                        {
                            ckb_otrosMecanico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosMecanico.Checked = true;

                        }
                        if (inicial.inicial_otrosMec2 == null)
                        {
                            ckb_otrosMecanico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosMecanico2.Checked = true;

                        }
                        if (inicial.inicial_otrosMec3 == null)
                        {
                            ckb_otrosMecanico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosMecanico3.Checked = true;

                        }
                        if (inicial.inicial_otrosMec4 == null)
                        {
                            ckb_otrosMecanico4.Checked = false;
                        }
                        else
                        {
                            ckb_otrosMecanico4.Checked = true;

                        }
                        //----------- Quimico -----------
                        if (inicial.inicial_solidosQui == null)
                        {
                            ckb_solidos.Checked = false;
                        }
                        else
                        {
                            ckb_solidos.Checked = true;

                        }
                        if (inicial.inicial_solidosQui2 == null)
                        {
                            ckb_solidos2.Checked = false;
                        }
                        else
                        {
                            ckb_solidos2.Checked = true;

                        }
                        if (inicial.inicial_solidosQui3 == null)
                        {
                            ckb_solidos3.Checked = false;
                        }
                        else
                        {
                            ckb_solidos3.Checked = true;

                        }
                        if (inicial.inicial_solidosQui4 == null)
                        {
                            ckb_solidos4.Checked = false;
                        }
                        else
                        {
                            ckb_solidos4.Checked = true;

                        }
                        if (inicial.inicial_polvosQui == null)
                        {
                            ckb_polvos.Checked = false;
                        }
                        else
                        {
                            ckb_polvos.Checked = true;

                        }
                        if (inicial.inicial_polvosQui2 == null)
                        {
                            ckb_polvos2.Checked = false;
                        }
                        else
                        {
                            ckb_polvos2.Checked = true;

                        }
                        if (inicial.inicial_polvosQui3 == null)
                        {
                            ckb_polvos3.Checked = false;
                        }
                        else
                        {
                            ckb_polvos3.Checked = true;

                        }
                        if (inicial.inicial_polvosQui4 == null)
                        {
                            ckb_polvos4.Checked = false;
                        }
                        else
                        {
                            ckb_polvos4.Checked = true;

                        }
                        if (inicial.inicial_humosQui == null)
                        {
                            ckb_humos.Checked = false;
                        }
                        else
                        {
                            ckb_humos.Checked = true;

                        }
                        if (inicial.inicial_humosQui2 == null)
                        {
                            ckb_humos2.Checked = false;
                        }
                        else
                        {
                            ckb_humos2.Checked = true;

                        }
                        if (inicial.inicial_humosQui3 == null)
                        {
                            ckb_humos3.Checked = false;
                        }
                        else
                        {
                            ckb_humos3.Checked = true;

                        }
                        if (inicial.inicial_humosQui4 == null)
                        {
                            ckb_humos4.Checked = false;
                        }
                        else
                        {
                            ckb_humos4.Checked = true;

                        }
                        if (inicial.inicial_liquidosQui == null)
                        {
                            ckb_liquidos.Checked = false;
                        }
                        else
                        {
                            ckb_liquidos.Checked = true;

                        }
                        if (inicial.inicial_liquidosQui2 == null)
                        {
                            ckb_liquidos2.Checked = false;
                        }
                        else
                        {
                            ckb_liquidos2.Checked = true;

                        }
                        if (inicial.inicial_liquidosQui3 == null)
                        {
                            ckb_liquidos3.Checked = false;
                        }
                        else
                        {
                            ckb_liquidos3.Checked = true;

                        }
                        if (inicial.inicial_liquidosQui4 == null)
                        {
                            ckb_liquidos4.Checked = false;
                        }
                        else
                        {
                            ckb_liquidos4.Checked = true;

                        }
                        if (inicial.inicial_vaporesQui == null)
                        {
                            ckb_vapores.Checked = false;
                        }
                        else
                        {
                            ckb_vapores.Checked = true;

                        }
                        if (inicial.inicial_vaporesQui2 == null)
                        {
                            ckb_vapores2.Checked = false;
                        }
                        else
                        {
                            ckb_vapores2.Checked = true;

                        }
                        if (inicial.inicial_vaporesQui3 == null)
                        {
                            ckb_vapores3.Checked = false;
                        }
                        else
                        {
                            ckb_vapores3.Checked = true;

                        }
                        if (inicial.inicial_vaporesQui4 == null)
                        {
                            ckb_vapores4.Checked = false;
                        }
                        else
                        {
                            ckb_vapores4.Checked = true;

                        }
                        if (inicial.inicial_aerosolesQui == null)
                        {
                            ckb_aerosoles.Checked = false;
                        }
                        else
                        {
                            ckb_aerosoles.Checked = true;

                        }
                        if (inicial.inicial_aerosolesQui2 == null)
                        {
                            ckb_aerosoles2.Checked = false;
                        }
                        else
                        {
                            ckb_aerosoles2.Checked = true;

                        }
                        if (inicial.inicial_aerosolesQui3 == null)
                        {
                            ckb_aerosoles3.Checked = false;
                        }
                        else
                        {
                            ckb_aerosoles3.Checked = true;

                        }
                        if (inicial.inicial_aerosolesQui4 == null)
                        {
                            ckb_aerosoles4.Checked = false;
                        }
                        else
                        {
                            ckb_aerosoles4.Checked = true;

                        }
                        if (inicial.inicial_neblinasQui == null)
                        {
                            ckb_neblinas.Checked = false;
                        }
                        else
                        {
                            ckb_neblinas.Checked = true;

                        }
                        if (inicial.inicial_neblinasQui2 == null)
                        {
                            ckb_neblinas2.Checked = false;
                        }
                        else
                        {
                            ckb_neblinas2.Checked = true;

                        }
                        if (inicial.inicial_neblinasQui3 == null)
                        {
                            ckb_neblinas3.Checked = false;
                        }
                        else
                        {
                            ckb_neblinas3.Checked = true;

                        }
                        if (inicial.inicial_neblinasQui4 == null)
                        {
                            ckb_neblinas4.Checked = false;
                        }
                        else
                        {
                            ckb_neblinas4.Checked = true;

                        }
                        if (inicial.inicial_gaseososQui == null)
                        {
                            ckb_gaseosos.Checked = false;
                        }
                        else
                        {
                            ckb_gaseosos.Checked = true;

                        }
                        if (inicial.inicial_gaseososQui2 == null)
                        {
                            ckb_gaseosos2.Checked = false;
                        }
                        else
                        {
                            ckb_gaseosos2.Checked = true;

                        }
                        if (inicial.inicial_gaseososQui3 == null)
                        {
                            ckb_gaseosos3.Checked = false;
                        }
                        else
                        {
                            ckb_gaseosos3.Checked = true;

                        }
                        if (inicial.inicial_gaseososQui4 == null)
                        {
                            ckb_gaseosos4.Checked = false;
                        }
                        else
                        {
                            ckb_gaseosos4.Checked = true;

                        }
                        if (inicial.inicial_otrosQui == null)
                        {
                            ckb_otrosQuimico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosQuimico.Checked = true;

                        }
                        if (inicial.inicial_otrosQui2 == null)
                        {
                            ckb_otrosQuimico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosQuimico2.Checked = true;

                        }
                        if (inicial.inicial_otrosQui3 == null)
                        {
                            ckb_otrosQuimico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosQuimico3.Checked = true;

                        }
                        if (inicial.inicial_otrosQui4 == null)
                        {
                            ckb_otrosQuimico4.Checked = false;
                        }
                        else
                        {
                            ckb_otrosQuimico4.Checked = true;

                        }
                        //----------- Biologico -----------
                        if (inicial.inicial_virusBio == null)
                        {
                            ckb_virus.Checked = false;
                        }
                        else
                        {
                            ckb_virus.Checked = true;

                        }
                        if (inicial.inicial_virusBio2 == null)
                        {
                            ckb_virus2.Checked = false;
                        }
                        else
                        {
                            ckb_virus2.Checked = true;

                        }
                        if (inicial.inicial_virusBio3 == null)
                        {
                            ckb_virus3.Checked = false;
                        }
                        else
                        {
                            ckb_virus3.Checked = true;

                        }
                        if (inicial.inicial_virusBio4 == null)
                        {
                            ckb_virus4.Checked = false;
                        }
                        else
                        {
                            ckb_virus4.Checked = true;

                        }
                        if (inicial.inicial_hongosBio == null)
                        {
                            ckb_hongos.Checked = false;
                        }
                        else
                        {
                            ckb_hongos.Checked = true;

                        }
                        if (inicial.inicial_hongosBio2 == null)
                        {
                            ckb_hongos2.Checked = false;
                        }
                        else
                        {
                            ckb_hongos2.Checked = true;

                        }
                        if (inicial.inicial_hongosBio3 == null)
                        {
                            ckb_hongos3.Checked = false;
                        }
                        else
                        {
                            ckb_hongos3.Checked = true;

                        }
                        if (inicial.inicial_hongosBio4 == null)
                        {
                            ckb_hongos4.Checked = false;
                        }
                        else
                        {
                            ckb_hongos4.Checked = true;

                        }
                        if (inicial.inicial_bacteriasBio == null)
                        {
                            ckb_bacterias.Checked = false;
                        }
                        else
                        {
                            ckb_bacterias.Checked = true;

                        }
                        if (inicial.inicial_bacteriasBio2 == null)
                        {
                            ckb_bacterias2.Checked = false;
                        }
                        else
                        {
                            ckb_bacterias2.Checked = true;

                        }
                        if (inicial.inicial_bacteriasBio3 == null)
                        {
                            ckb_bacterias3.Checked = false;
                        }
                        else
                        {
                            ckb_bacterias3.Checked = true;

                        }
                        if (inicial.inicial_bacteriasBio4 == null)
                        {
                            ckb_bacterias4.Checked = false;
                        }
                        else
                        {
                            ckb_bacterias4.Checked = true;

                        }
                        if (inicial.inicial_parasitosBio == null)
                        {
                            ckb_parasitos.Checked = false;
                        }
                        else
                        {
                            ckb_parasitos.Checked = true;

                        }
                        if (inicial.inicial_parasitosBio2 == null)
                        {
                            ckb_parasitos2.Checked = false;
                        }
                        else
                        {
                            ckb_parasitos2.Checked = true;

                        }
                        if (inicial.inicial_parasitosBio3 == null)
                        {
                            ckb_parasitos3.Checked = false;
                        }
                        else
                        {
                            ckb_parasitos3.Checked = true;

                        }
                        if (inicial.inicial_parasitosBio4 == null)
                        {
                            ckb_parasitos4.Checked = false;
                        }
                        else
                        {
                            ckb_parasitos4.Checked = true;

                        }
                        if (inicial.inicial_expVectBio == null)
                        {
                            ckb_expoavectores.Checked = false;
                        }
                        else
                        {
                            ckb_expoavectores.Checked = true;

                        }
                        if (inicial.inicial_expVectBio2 == null)
                        {
                            ckb_expoavectores2.Checked = false;
                        }
                        else
                        {
                            ckb_expoavectores2.Checked = true;

                        }
                        if (inicial.inicial_expVectBio3 == null)
                        {
                            ckb_expoavectores3.Checked = false;
                        }
                        else
                        {
                            ckb_expoavectores3.Checked = true;

                        }
                        if (inicial.inicial_expVectBio4 == null)
                        {
                            ckb_expoavectores4.Checked = false;
                        }
                        else
                        {
                            ckb_expoavectores4.Checked = true;

                        }
                        if (inicial.inicial_expAniSelvaBio == null)
                        {
                            ckb_expoanimselvaticos.Checked = false;
                        }
                        else
                        {
                            ckb_expoanimselvaticos.Checked = true;

                        }
                        if (inicial.inicial_expAniSelvaBio2 == null)
                        {
                            ckb_expoanimselvaticos2.Checked = false;
                        }
                        else
                        {
                            ckb_expoanimselvaticos2.Checked = true;

                        }
                        if (inicial.inicial_expAniSelvaBio3 == null)
                        {
                            ckb_expoanimselvaticos3.Checked = false;
                        }
                        else
                        {
                            ckb_expoanimselvaticos3.Checked = true;

                        }
                        if (inicial.inicial_expAniSelvaBio4 == null)
                        {
                            ckb_expoanimselvaticos4.Checked = false;
                        }
                        else
                        {
                            ckb_expoanimselvaticos4.Checked = true;

                        }
                        if (inicial.inicial_otrosBio == null)
                        {
                            ckb_otrosBiologico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosBiologico.Checked = true;

                        }
                        if (inicial.inicial_otrosBio2 == null)
                        {
                            ckb_otrosBiologico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosBiologico2.Checked = true;

                        }
                        if (inicial.inicial_otrosBio3 == null)
                        {
                            ckb_otrosBiologico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosBiologico3.Checked = true;

                        }
                        if (inicial.inicial_otrosBio4 == null)
                        {
                            ckb_otrosBiologico4.Checked = false;
                        }
                        else
                        {
                            ckb_otrosBiologico4.Checked = true;

                        }
                        //----------- Ergonomico -----------
                        if (inicial.inicial_maneManCarErg == null)
                        {
                            ckb_manmanualcargas.Checked = false;
                        }
                        else
                        {
                            ckb_manmanualcargas.Checked = true;

                        }
                        if (inicial.inicial_maneManCarErg2 == null)
                        {
                            ckb_manmanualcargas2.Checked = false;
                        }
                        else
                        {
                            ckb_manmanualcargas2.Checked = true;

                        }
                        if (inicial.inicial_maneManCarErg3 == null)
                        {
                            ckb_manmanualcargas3.Checked = false;
                        }
                        else
                        {
                            ckb_manmanualcargas3.Checked = true;

                        }
                        if (inicial.inicial_maneManCarErg4 == null)
                        {
                            ckb_manmanualcargas4.Checked = false;
                        }
                        else
                        {
                            ckb_manmanualcargas4.Checked = true;

                        }
                        if (inicial.inicial_movRepeErg == null)
                        {
                            ckb_movrepetitivo.Checked = false;
                        }
                        else
                        {
                            ckb_movrepetitivo.Checked = true;
                        }
                        if (inicial.inicial_movRepeErg2 == null)
                        {
                            ckb_movrepetitivo2.Checked = false;
                        }
                        else
                        {
                            ckb_movrepetitivo2.Checked = true;
                        }
                        if (inicial.inicial_movRepeErg3 == null)
                        {
                            ckb_movrepetitivo3.Checked = false;
                        }
                        else
                        {
                            ckb_movrepetitivo3.Checked = true;
                        }
                        if (inicial.inicial_movRepeErg4 == null)
                        {
                            ckb_movrepetitivo4.Checked = false;
                        }
                        else
                        {
                            ckb_movrepetitivo4.Checked = true;
                        }
                        if (inicial.inicial_posForzaErg == null)
                        {
                            ckb_postforzadas.Checked = false;
                        }
                        else
                        {
                            ckb_postforzadas.Checked = true;

                        }
                        if (inicial.inicial_posForzaErg2 == null)
                        {
                            ckb_postforzadas2.Checked = false;
                        }
                        else
                        {
                            ckb_postforzadas2.Checked = true;

                        }
                        if (inicial.inicial_posForzaErg3 == null)
                        {
                            ckb_postforzadas3.Checked = false;
                        }
                        else
                        {
                            ckb_postforzadas3.Checked = true;

                        }
                        if (inicial.inicial_posForzaErg4 == null)
                        {
                            ckb_postforzadas4.Checked = false;
                        }
                        else
                        {
                            ckb_postforzadas4.Checked = true;

                        }
                        if (inicial.inicial_trabPvdErg == null)
                        {
                            ckb_trabajopvd.Checked = false;
                        }
                        else
                        {
                            ckb_trabajopvd.Checked = true;

                        }
                        if (inicial.inicial_trabPvdErg2 == null)
                        {
                            ckb_trabajopvd2.Checked = false;
                        }
                        else
                        {
                            ckb_trabajopvd2.Checked = true;

                        }
                        if (inicial.inicial_trabPvdErg3 == null)
                        {
                            ckb_trabajopvd3.Checked = false;
                        }
                        else
                        {
                            ckb_trabajopvd3.Checked = true;

                        }
                        if (inicial.inicial_trabPvdErg4 == null)
                        {
                            ckb_trabajopvd4.Checked = false;
                        }
                        else
                        {
                            ckb_trabajopvd4.Checked = true;

                        }
                        if (inicial.inicial_otrosErg == null)
                        {
                            ckb_otrosErgonomico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosErgonomico.Checked = true;

                        }
                        if (inicial.inicial_otrosErg2 == null)
                        {
                            ckb_otrosErgonomico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosErgonomico2.Checked = true;

                        }
                        if (inicial.inicial_otrosErg3 == null)
                        {
                            ckb_otrosErgonomico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosErgonomico3.Checked = true;

                        }
                        if (inicial.inicial_otrosErg4 == null)
                        {
                            ckb_otrosErgonomico4.Checked = false;
                        }
                        else
                        {
                            ckb_otrosErgonomico4.Checked = true;

                        }
                        //----------- Psicosocial -----------
                        if (inicial.inicial_monoTrabPsi == null)
                        {
                            ckb_montrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_montrabajo.Checked = true;

                        }
                        if (inicial.inicial_monoTrabPsi2 == null)
                        {
                            ckb_montrabajo2.Checked = false;
                        }
                        else
                        {
                            ckb_montrabajo2.Checked = true;

                        }
                        if (inicial.inicial_monoTrabPsi3 == null)
                        {
                            ckb_montrabajo3.Checked = false;
                        }
                        else
                        {
                            ckb_montrabajo3.Checked = true;

                        }
                        if (inicial.inicial_monoTrabPsi4 == null)
                        {
                            ckb_montrabajo4.Checked = false;
                        }
                        else
                        {
                            ckb_montrabajo4.Checked = true;

                        }
                        if (inicial.inicial_sobrecarLabPsi == null)
                        {
                            ckb_sobrecargalaboral.Checked = false;
                        }
                        else
                        {
                            ckb_sobrecargalaboral.Checked = true;

                        }
                        if (inicial.inicial_sobrecarLabPsi2 == null)
                        {
                            ckb_sobrecargalaboral2.Checked = false;
                        }
                        else
                        {
                            ckb_sobrecargalaboral2.Checked = true;

                        }
                        if (inicial.inicial_sobrecarLabPsi3 == null)
                        {
                            ckb_sobrecargalaboral3.Checked = false;
                        }
                        else
                        {
                            ckb_sobrecargalaboral3.Checked = true;

                        }
                        if (inicial.inicial_sobrecarLabPsi4 == null)
                        {
                            ckb_sobrecargalaboral4.Checked = false;
                        }
                        else
                        {
                            ckb_sobrecargalaboral4.Checked = true;

                        }
                        if (inicial.inicial_minuTareaPsi == null)
                        {
                            ckb_minustarea.Checked = false;
                        }
                        else
                        {
                            ckb_minustarea.Checked = true;

                        }
                        if (inicial.inicial_minuTareaPsi2 == null)
                        {
                            ckb_minustarea2.Checked = false;
                        }
                        else
                        {
                            ckb_minustarea2.Checked = true;

                        }
                        if (inicial.inicial_minuTareaPsi3 == null)
                        {
                            ckb_minustarea3.Checked = false;
                        }
                        else
                        {
                            ckb_minustarea3.Checked = true;

                        }
                        if (inicial.inicial_minuTareaPsi4 == null)
                        {
                            ckb_minustarea4.Checked = false;
                        }
                        else
                        {
                            ckb_minustarea4.Checked = true;

                        }
                        if (inicial.inicial_altaResponPsi == null)
                        {
                            ckb_altarespon.Checked = false;
                        }
                        else
                        {
                            ckb_altarespon.Checked = true;

                        }
                        if (inicial.inicial_altaResponPsi2 == null)
                        {
                            ckb_altarespon2.Checked = false;
                        }
                        else
                        {
                            ckb_altarespon2.Checked = true;

                        }
                        if (inicial.inicial_altaResponPsi3 == null)
                        {
                            ckb_altarespon3.Checked = false;
                        }
                        else
                        {
                            ckb_altarespon3.Checked = true;

                        }
                        if (inicial.inicial_altaResponPsi4 == null)
                        {
                            ckb_altarespon4.Checked = false;
                        }
                        else
                        {
                            ckb_altarespon4.Checked = true;

                        }
                        if (inicial.inicial_autoTomaDesiPsi == null)
                        {
                            ckb_automadesiciones.Checked = false;
                        }
                        else
                        {
                            ckb_automadesiciones.Checked = true;

                        }
                        if (inicial.inicial_autoTomaDesiPsi2 == null)
                        {
                            ckb_automadesiciones2.Checked = false;
                        }
                        else
                        {
                            ckb_automadesiciones2.Checked = true;

                        }
                        if (inicial.inicial_autoTomaDesiPsi3 == null)
                        {
                            ckb_automadesiciones3.Checked = false;
                        }
                        else
                        {
                            ckb_automadesiciones3.Checked = true;

                        }
                        if (inicial.inicial_autoTomaDesiPsi4 == null)
                        {
                            ckb_automadesiciones4.Checked = false;
                        }
                        else
                        {
                            ckb_automadesiciones4.Checked = true;

                        }
                        if (inicial.inicial_supEstDirecDefiPsi == null)
                        {
                            ckb_supyestdireficiente.Checked = false;
                        }
                        else
                        {
                            ckb_supyestdireficiente.Checked = true;

                        }
                        if (inicial.inicial_supEstDirecDefiPsi2 == null)
                        {
                            ckb_supyestdireficiente2.Checked = false; ;
                        }
                        else
                        {
                            ckb_supyestdireficiente2.Checked = true;

                        }
                        if (inicial.inicial_supEstDirecDefiPsi3 == null)
                        {
                            ckb_supyestdireficiente3.Checked = false;
                        }
                        else
                        {
                            ckb_supyestdireficiente3.Checked = true;

                        }
                        if (inicial.inicial_supEstDirecDefiPsi4 == null)
                        {
                            ckb_supyestdireficiente4.Checked = false;
                        }
                        else
                        {
                            ckb_supyestdireficiente4.Checked = true;

                        }
                        if (inicial.inicial_conflicRolPsi == null)
                        {
                            ckb_conflictorol.Checked = false;
                        }
                        else
                        {
                            ckb_conflictorol.Checked = true;

                        }
                        if (inicial.inicial_conflicRolPsi2 == null)
                        {
                            ckb_conflictorol2.Checked = false;
                        }
                        else
                        {
                            ckb_conflictorol2.Checked = true;

                        }
                        if (inicial.inicial_conflicRolPsi3 == null)
                        {
                            ckb_conflictorol3.Checked = false;
                        }
                        else
                        {
                            ckb_conflictorol3.Checked = true;

                        }
                        if (inicial.inicial_conflicRolPsi4 == null)
                        {
                            ckb_conflictorol4.Checked = false;
                        }
                        else
                        {
                            ckb_conflictorol4.Checked = true;

                        }
                        if (inicial.inicial_falClariFunPsi == null)
                        {
                            ckb_faltaclarfunciones.Checked = false;
                        }
                        else
                        {
                            ckb_faltaclarfunciones.Checked = true;

                        }
                        if (inicial.inicial_falClariFunPsi2 == null)
                        {
                            ckb_faltaclarfunciones2.Checked = false;
                        }
                        else
                        {
                            ckb_faltaclarfunciones2.Checked = true;

                        }
                        if (inicial.inicial_falClariFunPsi3 == null)
                        {
                            ckb_faltaclarfunciones3.Checked = false;
                        }
                        else
                        {
                            ckb_faltaclarfunciones3.Checked = true;

                        }
                        if (inicial.inicial_falClariFunPsi4 == null)
                        {
                            ckb_faltaclarfunciones4.Checked = false;
                        }
                        else
                        {
                            ckb_faltaclarfunciones4.Checked = true;

                        }
                        if (inicial.inicial_incoDistriTrabPsi == null)
                        {
                            ckb_incorrdistrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_incorrdistrabajo.Checked = true;

                        }
                        if (inicial.inicial_incoDistriTrabPsi2 == null)
                        {
                            ckb_incorrdistrabajo2.Checked = false;
                        }
                        else
                        {
                            ckb_incorrdistrabajo2.Checked = true;

                        }
                        if (inicial.inicial_incoDistriTrabPsi3 == null)
                        {
                            ckb_incorrdistrabajo3.Checked = false;
                        }
                        else
                        {
                            ckb_incorrdistrabajo3.Checked = true;

                        }
                        if (inicial.inicial_incoDistriTrabPsi4 == null)
                        {
                            ckb_incorrdistrabajo4.Checked = false;
                        }
                        else
                        {
                            ckb_incorrdistrabajo4.Checked = true;

                        }
                        if (inicial.inicial_turnosRotaPsi == null)
                        {
                            ckb_turnorotat.Checked = false;
                        }
                        else
                        {
                            ckb_turnorotat.Checked = true;

                        }
                        if (inicial.inicial_turnosRotaPsi2 == null)
                        {
                            ckb_turnorotat2.Checked = false;
                        }
                        else
                        {
                            ckb_turnorotat2.Checked = true;

                        }
                        if (inicial.inicial_turnosRotaPsi3 == null)
                        {
                            ckb_turnorotat3.Checked = false;
                        }
                        else
                        {
                            ckb_turnorotat3.Checked = true;

                        }
                        if (inicial.inicial_turnosRotaPsi4 == null)
                        {
                            ckb_turnorotat4.Checked = false;
                        }
                        else
                        {
                            ckb_turnorotat4.Checked = true;

                        }
                        if (inicial.inicial_relInterperPsi == null)
                        {
                            ckb_relacinterpersonales.Checked = false;
                        }
                        else
                        {
                            ckb_relacinterpersonales.Checked = true;

                        }
                        if (inicial.inicial_relInterperPsi2 == null)
                        {
                            ckb_relacinterpersonales2.Checked = false;
                        }
                        else
                        {
                            ckb_relacinterpersonales2.Checked = true;

                        }
                        if (inicial.inicial_relInterperPsi3 == null)
                        {
                            ckb_relacinterpersonales3.Checked = false;
                        }
                        else
                        {
                            ckb_relacinterpersonales3.Checked = true;

                        }
                        if (inicial.inicial_relInterperPsi4 == null)
                        {
                            ckb_relacinterpersonales4.Checked = false;
                        }
                        else
                        {
                            ckb_relacinterpersonales4.Checked = true;

                        }
                        if (inicial.inicial_inesLabPsi == null)
                        {
                            ckb_inestalaboral.Checked = false;
                        }
                        else
                        {
                            ckb_inestalaboral.Checked = true;

                        }
                        if (inicial.inicial_inesLabPsi2 == null)
                        {
                            ckb_inestalaboral2.Checked = false;
                        }
                        else
                        {
                            ckb_inestalaboral2.Checked = true;

                        }
                        if (inicial.inicial_inesLabPsi3 == null)
                        {
                            ckb_inestalaboral3.Checked = false;
                        }
                        else
                        {
                            ckb_inestalaboral3.Checked = true;

                        }
                        if (inicial.inicial_inesLabPsi4 == null)
                        {
                            ckb_inestalaboral4.Checked = false;
                        }
                        else
                        {
                            ckb_inestalaboral4.Checked = true;

                        }
                        if (inicial.inicial_otrosPsi == null)
                        {
                            ckb_otrosPsicosocial.Checked = false;
                        }
                        else
                        {
                            ckb_otrosPsicosocial.Checked = true;

                        }
                        if (inicial.inicial_otrosPsi2 == null)
                        {
                            ckb_otrosPsicosocial2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosPsicosocial2.Checked = true;

                        }
                        if (inicial.inicial_otrosPsi3 == null)
                        {
                            ckb_otrosPsicosocial3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosPsicosocial3.Checked = true;

                        }
                        if (inicial.inicial_otrosPsi4 == null)
                        {
                            ckb_otrosPsicosocial4.Checked = false;
                        }
                        else
                        {
                            ckb_otrosPsicosocial4.Checked = true;

                        }

                        //Revision de Organos y Sistemas
                        if (inicial.inicial_pielAnexos == null)
                        {
                            ckb_pielanexos.Checked = false;
                        }
                        else
                        {
                            ckb_pielanexos.Checked = true;

                        }
                        if (inicial.inicial_orgSentidos == null)
                        {
                            ckb_organossentidos.Checked = false;
                        }
                        else
                        {
                            ckb_organossentidos.Checked = true;

                        }
                        if (inicial.inicial_respiratorio == null)
                        {
                            ckb_respiratorio.Checked = false;
                        }
                        else
                        {
                            ckb_respiratorio.Checked = true;

                        }
                        if (inicial.inicial_cardVascular == null)
                        {
                            ckb_cardiovascular.Checked = false;
                        }
                        else
                        {
                            ckb_cardiovascular.Checked = true;

                        }
                        if (inicial.inicial_digestivo == null)
                        {
                            ckb_digestivo.Checked = false;
                        }
                        else
                        {
                            ckb_digestivo.Checked = true;

                        }
                        if (inicial.inicial_genUrinario == null)
                        {
                            ckb_genitourinario.Checked = false;
                        }
                        else
                        {
                            ckb_genitourinario.Checked = true;

                        }
                        if (inicial.inicial_muscEsqueletico == null)
                        {
                            ckb_musculosesqueleticos.Checked = false;
                        }
                        else
                        {
                            ckb_musculosesqueleticos.Checked = true;

                        }
                        if (inicial.inicial_endocrino == null)
                        {
                            ckb_endocrino.Checked = false;
                        }
                        else
                        {
                            ckb_endocrino.Checked = true;

                        }
                        if (inicial.inicial_hemoLimfa == null)
                        {
                            ckb_hemolinfatico.Checked = false;
                        }
                        else
                        {
                            ckb_hemolinfatico.Checked = true;

                        }
                        if (inicial.inicial_nervioso == null)
                        {
                            ckb_nervioso.Checked = false;
                        }
                        else
                        {
                            ckb_nervioso.Checked = true;

                        }

                        //Regiones
                        if (inicial.inicial_cicatricesPiel == null)
                        {
                            ckb_cicatrices.Checked = false;
                        }
                        else
                        {
                            ckb_cicatrices.Checked = true;

                        }
                        if (inicial.inicial_tatuajesPiel == null)
                        {
                            ckb_tatuajes.Checked = false;
                        }
                        else
                        {
                            ckb_tatuajes.Checked = true;

                        }
                        if (inicial.inicial_pielFacerasPiel == null)
                        {
                            ckb_pielyfaneras.Checked = false;
                        }
                        else
                        {
                            ckb_pielyfaneras.Checked = true;

                        }
                        if (inicial.inicial_parpadosOjos == null)
                        {
                            ckb_parpados.Checked = false;
                        }
                        else
                        {
                            ckb_parpados.Checked = true;

                        }
                        if (inicial.inicial_conjuntuvasOjos == null)
                        {
                            ckb_conjuntivas.Checked = false;
                        }
                        else
                        {
                            ckb_conjuntivas.Checked = true;

                        }
                        if (inicial.inicial_pupilasOjos == null)
                        {
                            ckb_pupilas.Checked = false;
                        }
                        else
                        {
                            ckb_pupilas.Checked = true;

                        }
                        if (inicial.inicial_corneaOjos == null)
                        {
                            ckb_cornea.Checked = false;
                        }
                        else
                        {
                            ckb_cornea.Checked = true;

                        }
                        if (inicial.inicial_motilidadOjos == null)
                        {
                            ckb_motilidad.Checked = false;
                        }
                        else
                        {
                            ckb_motilidad.Checked = true;

                        }
                        if (inicial.inicial_cAudiExtreOido == null)
                        {
                            ckb_auditivoexterno.Checked = false;
                        }
                        else
                        {
                            ckb_auditivoexterno.Checked = true;

                        }
                        if (inicial.inicial_pabellonOido == null)
                        {
                            ckb_pabellon.Checked = false;
                        }
                        else
                        {
                            ckb_pabellon.Checked = true;

                        }
                        if (inicial.inicial_timpanosOido == null)
                        {
                            ckb_timpanos.Checked = false;
                        }
                        else
                        {
                            ckb_timpanos.Checked = true;

                        }
                        if (inicial.inicial_labiosOroFa == null)
                        {
                            ckb_labios.Checked = false;
                        }
                        else
                        {
                            ckb_labios.Checked = true;

                        }
                        if (inicial.inicial_lenguaOroFa == null)
                        {
                            ckb_lengua.Checked = false;
                        }
                        else
                        {
                            ckb_lengua.Checked = true;

                        }
                        if (inicial.inicial_faringeOroFa == null)
                        {
                            ckb_faringe.Checked = false;
                        }
                        else
                        {
                            ckb_faringe.Checked = true;

                        }
                        if (inicial.inicial_amigdalasOroFa == null)
                        {
                            ckb_amigdalas.Checked = false;
                        }
                        else
                        {
                            ckb_amigdalas.Checked = true;

                        }
                        if (inicial.inicial_dentaduraOroFa == null)
                        {
                            ckb_dentadura.Checked = false;
                        }
                        else
                        {
                            ckb_dentadura.Checked = true;

                        }
                        if (inicial.inicial_tabiqueNariz == null)
                        {
                            ckb_tabique.Checked = false;
                        }
                        else
                        {
                            ckb_tabique.Checked = true;

                        }
                        if (inicial.inicial_cornetesNariz == null)
                        {
                            ckb_cornetes.Checked = false;
                        }
                        else
                        {
                            ckb_cornetes.Checked = true;

                        }
                        if (inicial.inicial_mucosasNariz == null)
                        {
                            ckb_mucosa.Checked = false;
                        }
                        else
                        {
                            ckb_mucosa.Checked = true;

                        }
                        if (inicial.inicial_senosParanaNariz == null)
                        {
                            ckb_senosparanasales.Checked = false;
                        }
                        else
                        {
                            ckb_senosparanasales.Checked = true;

                        }
                        if (inicial.inicial_tiroiMasasCuello == null)
                        {
                            ckb_tiroides.Checked = false;
                        }
                        else
                        {
                            ckb_tiroides.Checked = true;

                        }
                        if (inicial.inicial_movilidadCuello == null)
                        {
                            ckb_movilidad.Checked = false;
                        }
                        else
                        {
                            ckb_movilidad.Checked = true;

                        }
                        if (inicial.inicial_mamasTorax == null)
                        {
                            ckb_mamas.Checked = false;
                        }
                        else
                        {
                            ckb_mamas.Checked = true;

                        }
                        if (inicial.inicial_corazonTorax == null)
                        {
                            ckb_corazon.Checked = false;
                        }
                        else
                        {
                            ckb_corazon.Checked = true;

                        }
                        if (inicial.inicial_pulmonesTorax2 == null)
                        {
                            ckb_pulmones.Checked = false;
                        }
                        else
                        {
                            ckb_pulmones.Checked = true;

                        }
                        if (inicial.inicial_parriCostalTorax2 == null)
                        {
                            ckb_parrillacostal.Checked = false;
                        }
                        else
                        {
                            ckb_parrillacostal.Checked = true;

                        }
                        if (inicial.inicial_viscerasAbdomen == null)
                        {
                            ckb_visceras.Checked = false;
                        }
                        else
                        {
                            ckb_visceras.Checked = true;

                        }
                        if (inicial.inicial_paredAbdomiAbdomen == null)
                        {
                            ckb_paredabdominal.Checked = false;
                        }
                        else
                        {
                            ckb_paredabdominal.Checked = true;

                        }
                        if (inicial.inicial_flexibilidadColumna == null)
                        {
                            ckb_flexibilidad.Checked = false;
                        }
                        else
                        {
                            ckb_flexibilidad.Checked = true;

                        }
                        if (inicial.inicial_desviacionColumna == null)
                        {
                            ckb_desviacion.Checked = false;
                        }
                        else
                        {
                            ckb_desviacion.Checked = true;

                        }
                        if (inicial.inicial_dolorColumna == null)
                        {
                            ckb_dolor.Checked = false;
                        }
                        else
                        {
                            ckb_dolor.Checked = true;

                        }
                        if (inicial.inicial_pelvisPelvis == null)
                        {
                            ckb_pelvis.Checked = false;
                        }
                        else
                        {
                            ckb_pelvis.Checked = true;

                        }
                        if (inicial.inicial_genitalesPelvis == null)
                        {
                            ckb_genitales.Checked = false;
                        }
                        else
                        {
                            ckb_genitales.Checked = true;

                        }
                        if (inicial.inicial_vascularExtre == null)
                        {
                            ckb_vascular.Checked = false;
                        }
                        else
                        {
                            ckb_vascular.Checked = true;

                        }
                        if (inicial.inicial_miemSupeExtre == null)
                        {
                            ckb_miembrosuperiores.Checked = false;
                        }
                        else
                        {
                            ckb_miembrosuperiores.Checked = true;

                        }
                        if (inicial.inicial_miemInfeExtre == null)
                        {
                            ckb_miembrosinferiores.Checked = false;
                        }
                        else
                        {
                            ckb_miembrosinferiores.Checked = true;

                        }
                        if (inicial.inicial_fuerzaNeuro == null)
                        {
                            ckb_fuerza.Checked = false;
                        }
                        else
                        {
                            ckb_fuerza.Checked = true;

                        }
                        if (inicial.inicial_sensibiNeuro == null)
                        {
                            ckb_sensibilidad.Checked = false;
                        }
                        else
                        {
                            ckb_sensibilidad.Checked = true;

                        }
                        if (inicial.inicial_marchaNeuro == null)
                        {
                            ckb_marcha.Checked = false;
                        }
                        else
                        {
                            ckb_marcha.Checked = true;

                        }
                        if (inicial.inicial_refleNeuro == null)
                        {
                            ckb_reflejos.Checked = false;
                        }
                        else
                        {
                            ckb_reflejos.Checked = true;

                        }

                        //Diagnostco
                        if (inicial.inicial_pre == null)
                        {
                            ckb_pre.Checked = false;
                        }
                        else
                        {
                            ckb_pre.Checked = true;

                        }
                        if (inicial.inicial_pre2 == null)
                        {
                            ckb_pre2.Checked = false;
                        }
                        else
                        {
                            ckb_pre2.Checked = true;

                        }
                        if (inicial.inicial_pre3 == null)
                        {
                            ckb_pre3.Checked = false;
                        }
                        else
                        {
                            ckb_pre3.Checked = true;

                        }
                        if (inicial.inicial_def == null)
                        {
                            ckb_def.Checked = false;
                        }
                        else
                        {
                            ckb_def.Checked = true;

                        }
                        if (inicial.inicial_def2 == null)
                        {
                            ckb_def2.Checked = false;
                        }
                        else
                        {
                            ckb_def2.Checked = true;

                        }
                        if (inicial.inicial_def3 == null)
                        {
                            ckb_def3.Checked = false;
                        }
                        else
                        {
                            ckb_def3.Checked = true;

                        }

                        //Aptitud Medica para el trabajo
                        if (inicial.inicial_apto == null)
                        {
                            ckb_apto.Checked = false;
                        }
                        else
                        {
                            ckb_apto.Checked = true;

                        }
                        if (inicial.inicial_aptoObserva == null)
                        {
                            ckb_aptoobservacion.Checked = false;
                        }
                        else
                        {
                            ckb_aptoobservacion.Checked = true;

                        }
                        if (inicial.inicial_aptoLimi == null)
                        {
                            ckb_aptolimitacion.Checked = false;
                        }
                        else
                        {
                            ckb_aptolimitacion.Checked = true;

                        }
                        if (inicial.inicial_NoApto == null)
                        {
                            ckb_noapto.Checked = false;
                        }
                        else
                        {
                            ckb_noapto.Checked = true;
                        }

                        txt_nomEmpresa.Text = emp.Emp_nombre.ToString();
                        //txt_rucEmp.Text = cen.cent_ruc.ToString();+++++++
                        txt_numHClinica.Text = per.Per_cedula.ToString();
                        txt_priNombre.Text = per.Per_priNombre.ToString();
                        txt_segNombre.Text = per.Per_segNombre.ToString();
                        txt_priApellido.Text = per.Per_priApellido.ToString();
                        txt_segApellido.Text = per.Per_segApellido.ToString();
                        txt_sexo.Text = per.Per_genero.ToString();
                        DateTime edad = Convert.ToDateTime(per.Per_fechaNacimiento);
                        DateTime naci = Convert.ToDateTime(edad);
                        DateTime actual = DateTime.Now;
                        Calculo(naci, actual);
                        txt_fechaingresotrabajo.Text = Convert.ToDateTime(per.Per_fechInicioTrabajo).ToString("yyyy-MM-dd");
                        txt_puestodetrabajociuo.Text = per.Per_puestoTrabajo.ToString();
                        txt_areadetrabajo.Text = per.Per_areaTrabajo.ToString();

                        if (inicial != null)
                        {
                            //A
                            txt_ciiu.Text = inicial.inicial_ciiu.ToString();
                            txt_numArchivo.Text = inicial.inicial_numArchivo.ToString();
                            txt_gruposanguineo.Text = inicial.inicial_groSanguineo.ToString();
                            txt_lateralidad.Text = inicial.inicial_lateralidad.ToString();
                            txt_tipodiscapacidad.Text = inicial.inicial_tipoDis.ToString();
                            txt_porcentajediscapacidad.Text = inicial.inicial_porcentDis.ToString();
                            txt_actividadesrelevantes.Text = inicial.inicial_actRelePuesTrabajo.ToString();

                            //B
                            txt_motivoconsultainicial.Text = inicial.inicial_descripcionMotivoConsulta.ToString();

                            //C
                            txt_antCliQuiDescripcion.Text = inicial.inicial_descripcionAnteceCliniQuirur.ToString();
                            txt_menarquiaAntGinObste.Text = inicial.inicial_menarquia.ToString();
                            txt_ciclosAntGinObste.Text = inicial.inicial_ciclos.ToString();

                            if (inicial.inicial_fechUltiMenstrua == "")
                            {
                                txt_fechUltiMensAntGinObste.Text = inicial.inicial_fechUltiMenstrua.ToString();
                            }
                            else
                            {
                                txt_fechUltiMensAntGinObste.Text = Convert.ToDateTime(inicial.inicial_fechUltiMenstrua).ToString("yyyy-MM-dd");
                            }

                            txt_gestasAntGinObste.Text = inicial.inicial_gestas.ToString();
                            txt_partosAntGinObste.Text = inicial.inicial_partos.ToString();
                            txt_cesareasAntGinObste.Text = inicial.inicial_cesareas.ToString();
                            txt_abortosAntGinObste.Text = inicial.inicial_abortos.ToString();
                            txt_vivosAntGinObste.Text = inicial.inicial_vivosHij.ToString();
                            txt_muertosAntGinObste.Text = inicial.inicial_muertosHij.ToString();
                            txt_tipoMetPlaniAntGinObste.Text = inicial.inicial_tipoMetPlanifiFamiliar.ToString();

                            txt_tiempoPapaniAntGinObste.Text = inicial.inicial_tiempoExaRealiPapanicolaou.ToString();
                            txt_resultadoPapaniAntGinObste.Text = inicial.inicial_resultadoExaRealiPapanicolaou.ToString();
                            txt_tiempoEcoMamaAntGinObste.Text = inicial.inicial_tiempoExaRealiEcoMamario.ToString();
                            txt_resultadoEcoMamaAntGinObste.Text = inicial.inicial_resultadoExaRealiEcoMamario.ToString();
                            txt_tiempoColposAntGinObste.Text = inicial.inicial_tiempoExaRealiColposcopia.ToString();
                            txt_resultadoColposAntGinObste.Text = inicial.inicial_resultadoExaRealiColposcopia.ToString();
                            txt_tiempoMamograAntGinObste.Text = inicial.inicial_tiempoExaRealiMamografia.ToString();
                            txt_resultadoMamograAntGinObste.Text = inicial.inicial_resultadoExaRealiMamografia.ToString();

                            txt_tiempoExaRealiAntProstaAntReproMascu.Text = inicial.inicial_tiempoExaRealiAntiProstatico.ToString();
                            txt_resultadoExaRealiAntProstaAntReproMascu.Text = inicial.inicial_resultadoExaRealiAntiProstatico.ToString();
                            txt_tipo1MetPlaniAntReproMascu.Text = inicial.inicial_tipo1MetPlanifiFamiAntReproMascu.ToString();
                            txt_vivosHijosAntReproMascu.Text = inicial.inicial_vivosHijAntReproMascu.ToString();
                            txt_muertosHijosAntReproMascu.Text = inicial.inicial_muertosHijAntReproMascu.ToString();
                            txt_tiempoExaRealiEcoProstaAntReproMascu.Text = inicial.inicial_tiempoExaRealiEcoProstatico.ToString();
                            txt_resultadoExaRealiEcoProstaAntReproMascu.Text = inicial.inicial_resultadoExaRealiEcoProstatico.ToString();
                            txt_tipo2MetPlaniAntReproMascu.Text = inicial.inicial_tipo2MetPlanifiFamiAntReproMascu.ToString();

                            txt_tiemConConsuNociTabaHabToxi.Text = inicial.inicial_tiempoConsuConsuNocivosTabaco.ToString();
                            txt_cantiConsuNociTabaHabToxi.Text = inicial.inicial_cantidadConsuNocivosTabaco.ToString();
                            txt_exConsumiConsuNociTabaHabToxi.Text = inicial.inicial_exConsumiConsuNocivosTabaco.ToString();
                            txt_tiemAbstiConsuNociTabaHabToxi.Text = inicial.inicial_tiempoAbstiConsuNocivosTabaco.ToString();
                            txt_tiemConConsuNociAlcoHabToxi.Text = inicial.inicial_tiempoConsuConsuNocivosAlcohol.ToString();
                            txt_cantiConsuNociAlcoHabToxi.Text = inicial.inicial_cantidadConsuNocivosAlcohol.ToString();
                            txt_exConsumiConsuNociAlcoHabToxi.Text = inicial.inicial_exConsumiConsuNocivosAlcohol.ToString();
                            txt_tiemAbstiConsuNociAlcoHabToxi.Text = inicial.inicial_tiempoAbstiConsuNocivosAlcohol.ToString();
                            txt_tiemCon1ConsuNociOtrasDroHabToxi.Text = inicial.inicial_tiempoConsu1ConsuNocivosOtrasDrogas.ToString();
                            txt_canti1ConsuNociOtrasDroHabToxi.Text = inicial.inicial_cantidad1ConsuNocivosOtrasDrogas.ToString();
                            txt_exConsumi1ConsuNociOtrasDroHabToxi.Text = inicial.inicial_exConsumi1ConsuNocivosOtrasDrogas.ToString();
                            txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text = inicial.inicial_tiempoAbsti1ConsuNocivosOtrasDrogas.ToString();
                            txt_otrasConsuNociOtrasDroHabToxi.Text = inicial.inicial_otrasConsuNocivos.ToString();
                            txt_tiemCon2ConsuNociOtrasDroHabToxi.Text = inicial.inicial_tiempoConsu2ConsuNocivosOtrasDrogas.ToString();
                            txt_canti2ConsuNociOtrasDroHabToxi.Text = inicial.inicial_cantidad2ConsuNocivosOtrasDrogas.ToString();
                            txt_exConsumi2ConsuNociOtrasDroHabToxi.Text = inicial.inicial_exConsumi2ConsuNocivosOtrasDrogas.ToString();
                            txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text = inicial.inicial_tiempoAbsti2ConsuNocivosOtrasDrogas.ToString();

                            txt_cualEstVidaActFisiEstVida.Text = inicial.inicial_cualEstiVidaActFisica.ToString();
                            txt_tiemCanEstVidaActFisiEstVida.Text = inicial.inicial_tiem_cantEstiVidaActFisica.ToString();
                            txt_cual1EstVidaMedHabiEstVida.Text = inicial.inicial_cual2EstiVidaMediHabitual.ToString();
                            txt_tiemCan1EstVidaMedHabiEstVida.Text = inicial.inicial_tiem_cant2EstiVidaMediHabitual.ToString();
                            txt_cual2EstVidaMedHabiEstVida.Text = inicial.inicial_cual3EstiVidaMediHabitual.ToString();
                            txt_tiemCan2EstVidaMedHabiEstVida.Text = inicial.inicial_tiem_cant3EstiVidaMediHabitual.ToString();
                            txt_cual3EstVidaMedHabiEstVida.Text = inicial.inicial_cual4EstiVidaMediHabitual.ToString();
                            txt_tiemCan3EstVidaMedHabiEstVida.Text = inicial.inicial_tiem_cant4EstiVidaMediHabitual.ToString();

                            //D
                            txt_empresa.Text = inicial.inicial_nomEmpresa.ToString();
                            txt_puestotrabajo.Text = inicial.inicial_puestoTrabajo.ToString();
                            txt_actdesempeña.Text = inicial.inicial_actDesemp.ToString();
                            txt_tiempotrabajo.Text = inicial.inicial_tiemTrabajo.ToString();
                            txt_obseantempleanteriores.Text = inicial.inicial_observacionesAnteEmpleAnteriores.ToString();
                            txt_empresa2.Text = inicial.inicial_nomEmpresa2.ToString();
                            txt_puestotrabajo2.Text = inicial.inicial_puestoTrabajo2.ToString();
                            txt_actdesempeña2.Text = inicial.inicial_actDesemp2.ToString();
                            txt_tiempotrabajo2.Text = inicial.inicial_tiemTrabajo2.ToString();
                            txt_obseantempleanteriores2.Text = inicial.inicial_observacionesAnteEmpleAnteriores2.ToString();
                            txt_empresa3.Text = inicial.inicial_nomEmpresa3.ToString();
                            txt_puestotrabajo3.Text = inicial.inicial_puestoTrabajo3.ToString();
                            txt_actdesempeña3.Text = inicial.inicial_actDesemp3.ToString();
                            txt_tiempotrabajo3.Text = inicial.inicial_tiemTrabajo3.ToString();
                            txt_obseantempleanteriores3.Text = inicial.inicial_observacionesAnteEmpleAnteriores3.ToString();
                            txt_empresa4.Text = inicial.inicial_nomEmpresa4.ToString();
                            txt_puestotrabajo4.Text = inicial.inicial_puestoTrabajo4.ToString();
                            txt_actdesempeña4.Text = inicial.inicial_actDesemp4.ToString();
                            txt_tiempotrabajo4.Text = inicial.inicial_tiemTrabajo4.ToString();
                            txt_obseantempleanteriores4.Text = inicial.inicial_observacionesAnteEmpleAnteriores4.ToString();

                            txt_especificar.Text = inicial.inicial_especificarCalificadoIESSAcciTrabajo.ToString();
                            if (inicial.inicial_fechaCalificadoIESSAcciTrabajo == "")
                            {
                                txt_fecha.Text = inicial.inicial_fechaCalificadoIESSAcciTrabajo.ToString();
                            }
                            else
                            {
                                txt_fecha.Text = Convert.ToDateTime(inicial.inicial_fechaCalificadoIESSAcciTrabajo).ToString("yyyy-MM-dd");
                            }
                            txt_observaciones2.Text = inicial.inicial_obserAcciTrabajo.ToString();

                            txt_espeprofesional.Text = inicial.inicial_especificarCalificadoIESSEnfProfesionales.ToString();
                            if (inicial.inicial_fechaCalificadoIESSEnfProfesionales == "")
                            {
                                txt_fechaprofesional.Text = inicial.inicial_fechaCalificadoIESSEnfProfesionales.ToString();
                            }
                            else
                            {
                                txt_fechaprofesional.Text = Convert.ToDateTime(inicial.inicial_fechaCalificadoIESSEnfProfesionales).ToString("yyyy-MM-dd");
                            }
                            txt_observaciones3.Text = inicial.inicial_obserEnfProfesionales.ToString();

                            //E
                            txt_descripcionantefamiliares.Text = inicial.inicial_descripcionAnteFamiliares.ToString();

                            //F
                            txt_puestodetrabajo.Text = inicial.inicial_area.ToString();
                            txt_act.Text = inicial.inicial_actividades.ToString();
                            txt_puestodetrabajo2.Text = inicial.inicial_area2.ToString();
                            txt_act2.Text = inicial.inicial_actividades2.ToString();
                            txt_puestodetrabajo3.Text = inicial.inicial_area3.ToString();
                            txt_act3.Text = inicial.inicial_actividades3.ToString();
                            txt_puestodetrabajo4.Text = inicial.inicial_area4.ToString();
                            txt_act4.Text = inicial.inicial_actividades4.ToString();

                            txt_medpreventivas.Text = inicial.inicial_medPreventivas.ToString();
                            txt_medpreventivas2.Text = inicial.inicial_medPreventivas.ToString();
                            txt_medpreventivas3.Text = inicial.inicial_medPreventivas.ToString();
                            txt_medpreventivas4.Text = inicial.inicial_medPreventivas.ToString();

                            //G
                            txt_descrextralaborales.Text = inicial.inicial_descripActExtLab.ToString();

                            //H
                            txt_enfermedadactualinicial.Text = inicial.inicial_descripEnfActual.ToString();

                            //I
                            txt_descrorganosysistemas.Text = inicial.inicial_descripRevActOrgSis.ToString();

                            //J
                            txt_preArterial.Text = inicial.inicial_preArterial.ToString();
                            txt_temperatura.Text = inicial.inicial_temperatura.ToString();
                            txt_freCardica.Text = inicial.inicial_frecCardiacan.ToString();
                            txt_satOxigeno.Text = inicial.inicial_satOxigenon.ToString();
                            txt_freRespiratoria.Text = inicial.inicial_frecRespiratorian.ToString();
                            txt_peso.Text = inicial.inicial_peson.ToString();
                            txt_talla.Text = inicial.inicial_tallan.ToString();
                            txt_indMasCorporal.Text = inicial.inicial_indMasCorporaln.ToString();
                            txt_perAbdominal.Text = inicial.inicial_perAbdominaln.ToString();

                            //K                            
                            txt_obervexamenfisicoregional.Text = inicial.inicial_observaExaFisRegInicial.ToString();

                            //L
                            txt_examen.Text = inicial.inicial_examen.ToString();
                            if (inicial.inicial_fecha == "")
                            {
                                txt_fechaexamen.Text = inicial.inicial_fecha.ToString();
                            }
                            else
                            {
                                txt_fechaexamen.Text = Convert.ToDateTime(inicial.inicial_fecha).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen.Text = inicial.inicial_resultados.ToString();

                            txt_examen2.Text = inicial.inicial_examen2.ToString();
                            if (inicial.inicial_fecha2 == "")
                            {
                                txt_fechaexamen2.Text = inicial.inicial_fecha2.ToString();
                            }
                            else
                            {
                                txt_fechaexamen2.Text = Convert.ToDateTime(inicial.inicial_fecha2).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen2.Text = inicial.inicial_resultados2.ToString();

                            txt_examen3.Text = inicial.inicial_examen3.ToString();
                            if (inicial.inicial_fecha3 == "")
                            {
                                txt_fechaexamen3.Text = inicial.inicial_fecha3.ToString();
                            }
                            else
                            {
                                txt_fechaexamen3.Text = Convert.ToDateTime(inicial.inicial_fecha3).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen3.Text = inicial.inicial_resultados3.ToString();

                            txt_examen4.Text = inicial.inicial_examen4.ToString();

                            if (inicial.inicial_fecha4 == "")
                            {
                                txt_fechaexamen4.Text = inicial.inicial_fecha4.ToString();
                            }
                            else
                            {
                                txt_fechaexamen4.Text = Convert.ToDateTime(inicial.inicial_fecha4).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen4.Text = inicial.inicial_resultados4.ToString();

                            txt_observacionexamen.Text = inicial.inicial_observacionesResExaGenEspRiesTrabajo.ToString();

                            //M
                            txt_descripdiagnostico.Text = inicial.inicial_descripciondiagnostico.ToString();
                            txt_cie.Text = inicial.inicial_cie.ToString();
                            txt_descripdiagnostico2.Text = inicial.inicial_descripcioninicialnostico2.ToString();
                            txt_cie2.Text = inicial.inicial_cie2.ToString();
                            txt_descripdiagnostico3.Text = inicial.inicial_descripcioninicialnostico3.ToString();
                            txt_cie3.Text = inicial.inicial_cie3.ToString();

                            //N
                            txt_observacionaptitud.Text = inicial.inicial_ObservAptMed.ToString();
                            txt_limitacionaptitud.Text = inicial.inicial_LimitAptMed.ToString();

                            //O
                            txt_descripciontratamiento.Text = inicial.inicial_descripcionRecTra.ToString();

                            //P                            
                            ddl_profesional.SelectedValue = inicial.prof_id.ToString();
                            txt_codigoDatProf.Text = inicial.inicial_cod.ToString();
                        }
                    }
                }
                txt_numHClinica.MaxLength = 10;
                txt_numHClinica.MaxLength = 10;
                txt_porcentajediscapacidad.MaxLength = 3;
                txt_vivosAntGinObste.MaxLength = 2;
                txt_muertosAntGinObste.MaxLength = 2;
                txt_tiempoPapaniAntGinObste.MaxLength = 2;
                txt_tiempoEcoMamaAntGinObste.MaxLength = 2;
                txt_tiempoColposAntGinObste.MaxLength = 2;
                txt_tiempoMamograAntGinObste.MaxLength = 2;
                txt_tiempoExaRealiAntProstaAntReproMascu.MaxLength = 2;
                txt_vivosHijosAntReproMascu.MaxLength = 2;
                txt_muertosHijosAntReproMascu.MaxLength = 2;
                txt_tiempoExaRealiEcoProstaAntReproMascu.MaxLength = 2;
                txt_tiemConConsuNociTabaHabToxi.MaxLength = 2;
                txt_tiemAbstiConsuNociTabaHabToxi.MaxLength = 2;
                txt_tiemConConsuNociAlcoHabToxi.MaxLength = 2;
                txt_tiemAbstiConsuNociAlcoHabToxi.MaxLength = 2;
                txt_tiemCon1ConsuNociOtrasDroHabToxi.MaxLength = 2;
                txt_tiemAbsti1ConsuNociOtrasDroHabToxi.MaxLength = 2;
                txt_tiemCon2ConsuNociOtrasDroHabToxi.MaxLength = 2;
                txt_tiemAbsti2ConsuNociOtrasDroHabToxi.MaxLength = 2;
                txt_tiempotrabajo.MaxLength = 2;
                txt_tiempotrabajo2.MaxLength = 2;
                txt_tiempotrabajo3.MaxLength = 2;
                txt_tiempotrabajo4.MaxLength = 2;

                Timer1.Enabled = false;
                cargarProfesional();
                defaultValidaciones();

                txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
            }
        }

        //protected void timerFechaHora_Tick(object sender, EventArgs e)
        //{
        //    if (inicial.inicial_fecha_hora == null)
        //    {
        //        txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
        //    }
        //}

        public void Calculo(DateTime nac, DateTime actual)
        {
            int año = nac.Year;
            int mes = nac.Month;
            int dia = nac.Day;

            int añoBisiesto = 0;

            for (int i = año; i < actual.Year; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    ++añoBisiesto;
                }
            }

            TimeSpan ts = actual.Subtract(nac);
            dia = ts.Days - añoBisiesto;
            int r = 0;

            año = Math.DivRem(dia, 365, out r);
            mes = Math.DivRem(r, 30, out r);
            dia = r;

            txt_edad.Text = año + "A, " + mes + "M, " + dia + "D";
        }

        //Metodo obtener cedula por numero de historia clinica
        [WebMethod]
        [ScriptMethod]
        public static List<string> ObtenerNumHClinica(string prefixText)
        {
            List<string> lista = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("select top(10) Per_cedula from Tbl_Person where Per_cedula LIKE + @Cedula + '%'", con);
                cmd.Parameters.AddWithValue("@Cedula", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                IDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(lector.GetString(0));
                }

                lector.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        protected void txt_numHClinica_TextChanged(object sender, EventArgs e)
        {
            lbl_numHClinica.Text = "";
            ObtenerCedula();
        }

        private void ObtenerCedula()
        {
            string cedula = txt_numHClinica.Text;

            if (cedula != "")
            {
                var lista = from c in dc.Tbl_Person
                            join e in dc.Tbl_Empresa on c.Emp_id equals e.Emp_id
                            join ce in dc.Tbl_Centro on c.cent_id equals ce.cent_id
                            where c.Per_cedula == cedula
                            select new
                            {
                                e.Emp_nombre,
                                ce.cent_ruc,
                                c.Per_priNombre,
                                c.Per_segNombre,
                                c.Per_priApellido,
                                c.Per_segApellido,
                                c.Per_genero,
                                c.Per_fechaNacimiento,
                                c.Per_fechInicioTrabajo,
                                c.Per_puestoTrabajo,
                                c.Per_areaTrabajo
                            };

                foreach (var item in lista)
                {
                    string nomEmpresa = item.Emp_nombre;
                    txt_nomEmpresa.Text = nomEmpresa;

                    string rucEmpresa = item.cent_ruc;
                    txt_rucEmp.Text = rucEmpresa;

                    string priNombre = item.Per_priNombre;
                    txt_priNombre.Text = priNombre;

                    string segNombre = item.Per_segNombre;
                    txt_segNombre.Text = segNombre;

                    string priApellido = item.Per_priApellido;
                    txt_priApellido.Text = priApellido;

                    string segApellido = item.Per_segApellido;
                    txt_segApellido.Text = segApellido;

                    string sexo = item.Per_genero;
                    txt_sexo.Text = sexo;

                    DateTime edad = Convert.ToDateTime(item.Per_fechaNacimiento);
                    DateTime naci = Convert.ToDateTime(edad);

                    DateTime actual = DateTime.Now;
                    Calculo(naci, actual);

                    DateTime fechaIngresoTrabajo = Convert.ToDateTime(item.Per_fechInicioTrabajo);
                    txt_fechaingresotrabajo.Text = Convert.ToDateTime(fechaIngresoTrabajo).ToString("yyyy-MM-dd");

                    string puestoTrabajo = item.Per_puestoTrabajo;
                    txt_puestodetrabajociuo.Text = puestoTrabajo;

                    string areaTrabajo = item.Per_areaTrabajo;
                    txt_areadetrabajo.Text = areaTrabajo;

                }
            }
            else
            {
                txt_nomEmpresa.Text = txt_rucEmp.Text = txt_priNombre.Text = txt_segNombre.Text = txt_priApellido.Text = txt_segApellido.Text = txt_sexo.Text = txt_edad.Text = txt_puestodetrabajociuo.Text = txt_areadetrabajo.Text = string.Empty;
            }
        }

        //Metodo obtener codigo cie10
        [WebMethod]
        [ScriptMethod]
        public static List<string> ObtenerCie10(string prefixText)
        {
            List<string> lista = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("select top(10) dec10 from cie10 where dec10 LIKE + @Name + '%'", con);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                IDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(lector.GetString(0));
                }

                lector.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        protected void txt_descripdiagnostico_TextChanged(object sender, EventArgs e)
        {
            ObtenerCodigo();
        }

        protected void txt_descripdiagnostico2_TextChanged(object sender, EventArgs e)
        {
            ObtenerCodigo2();
        }

        protected void txt_descripdiagnostico3_TextChanged(object sender, EventArgs e)
        {
            ObtenerCodigo3();
        }

        private void ObtenerCodigo()
        {
            string descripcion = txt_descripdiagnostico.Text;

            var lista = from c in dc.cie10
                        where c.dec10 == descripcion
                        select c;

            foreach (var item in lista)
            {
                string codigo = item.id10;
                txt_cie.Text = codigo;
            }
        }
        private void ObtenerCodigo2()
        {
            string descripcion2 = txt_descripdiagnostico2.Text;


            var lista = from c in dc.cie10
                        where c.dec10 == descripcion2
                        select c;

            foreach (var item in lista)
            {
                string codigo2 = item.id10;
                txt_cie2.Text = codigo2;
            }
        }
        private void ObtenerCodigo3()
        {
            string descripcion3 = txt_descripdiagnostico3.Text;

            var lista = from c in dc.cie10
                        where c.dec10 == descripcion3
                        select c;

            foreach (var item in lista)
            {
                string codigo3 = item.id10;
                txt_cie3.Text = codigo3;
            }
        }

        private void GuardarHistorial()
        {
            try
            {
                per = CN_HistorialMedico.ObtenerIdPersonasxCedula(txt_numHClinica.Text);
                int perso = Convert.ToInt32(per.Per_id.ToString());

                per = CN_HistorialMedico.ObtenerIdEmpresaxCedula(txt_numHClinica.Text);
                int empre = Convert.ToInt32(per.Emp_id.ToString());

                inicial = new Tbl_Inicial();

                if (ckb_catolica.Checked == true)
                {
                    inicial.inicial_catolicaRel = "SI";
                }
                if (ckb_evangelica.Checked == true)
                {
                    inicial.inicial_evangelicaRel = "SI";
                }
                if (ckb_testigo.Checked == true)
                {
                    inicial.inicial_testJehovaRel = "SI";
                }
                if (ckb_mormona.Checked == true)
                {
                    inicial.inicial_mormonaRel = "SI";
                }
                if (ckb_otrareligion.Checked == true)
                {
                    inicial.inicial_otrasRel = "SI";
                }
                if (cbk_gay.Checked == true)
                {
                    inicial.inicial_gayOriSex = "SI";
                }
                if (cbk_lesbiana.Checked == true)
                {
                    inicial.inicial__lesbianaOriSex = "SI";
                }
                if (cbk_bisexual.Checked == true)
                {
                    inicial.inicial_bisexualOriSex = "SI";
                }
                if (cbk_heterosexual.Checked == true)
                {
                    inicial.inicial_heterosexualOriSex = "SI";
                }
                if (cbk_noRespondeOriSex.Checked == true)
                {
                    inicial.inicial_norespondeOriSex = "SI";
                }
                if (cbk_femenino.Checked == true)
                {
                    inicial.inicial_femeninoIdenGen = "SI";
                }
                if (cbk_masculino.Checked == true)
                {
                    inicial.inicial_masculinoIdenGen = "SI";
                }
                if (cbk_transfemenino.Checked == true)
                {
                    inicial.inicial_transFemeninoIdenGen = "SI";
                }
                if (cbk_transmasculino.Checked == true)
                {
                    inicial.inicial_transMasculinoIdenGen = "SI";
                }
                if (cbk_noRespondeIdeGen.Checked == true)
                {
                    inicial.inicial_norespondeIdenGen = "SI";
                }
                if (cbk_sidiscapacidad.Checked == true)
                {
                    inicial.inicial_siDis = "SI";
                }
                if (cbk_nodiscapacidad.Checked == true)
                {
                    inicial.inicial_noDis = "SI";
                }
                if (ckb_siVidSexAntGinObste.Checked == true)
                {
                    inicial.inicial_siVidaSexActiva = "SI";
                }
                if (ckb_noVidSexAntGinObste.Checked == true)
                {
                    inicial.inicial_noVidaSexActiva = "SI";
                }
                if (ckb_siMetPlaniAntGinObste.Checked == true)
                {
                    inicial.inicial_siMetPlanifiFamiliar = "SI";
                }
                if (ckb_noMetPlaniAntGinObste.Checked == true)
                {
                    inicial.inicial_noMetPlanifiFamiliar = "SI";
                }
                if (ckb_siPapaniAntGinObste.Checked == true)
                {
                    inicial.inicial_siExaRealiPapanicolaou = "SI";
                }
                if (ckb_noPapaniAntGinObste.Checked == true)
                {
                    inicial.inicial_noExaRealiPapanicolaou = "SI";
                }
                if (ckb_siEcoMamaAntGinObste.Checked == true)
                {
                    inicial.inicial_siExaRealiEcoMamario = "SI";
                }
                if (ckb_noEcoMamaAntGinObste.Checked == true)
                {
                    inicial.inicial_noExaRealiEcoMamario = "SI";
                }
                if (ckb_siColposAntGinObste.Checked == true)
                {
                    inicial.inicial_siExaRealiColposcopia = "SI";
                }
                if (ckb_noColposAntGinObste.Checked == true)
                {
                    inicial.inicial_noExaRealiColposcopia = "SI";
                }
                if (ckb_siMamograAntGinObste.Checked == true)
                {
                    inicial.inicial_siExaRealiMamografia = "SI";
                }
                if (ckb_noMamograAntGinObste.Checked == true)
                {
                    inicial.inicial_noExaRealiMamografia = "SI";
                }
                if (ckb_siExaRealiAntProstaAntReproMascu.Checked == true)
                {
                    inicial.inicial_siExaRealiAntiProstatico = "SI";
                }
                if (ckb_noExaRealiAntProstaAntReproMascu.Checked == true)
                {
                    inicial.inicial_noExaRealiAntiProstatico = "SI";
                }
                if (ckb_siMetPlaniAntReproMascu.Checked == true)
                {
                    inicial.inicial_siMetPlanifiFamiAntReproMascu = "SI";
                }
                if (ckb_noMetPlaniAntReproMascu.Checked == true)
                {
                    inicial.inicial_noMetPlanifiFamiAntReproMascu = "SI";
                }
                if (ckb_siExaRealiEcoProstaAntReproMascu.Checked == true)
                {
                    inicial.inicial_siExaRealiEcoProstatico = "SI";
                }
                if (ckb_noExaRealiEcoProstaAntReproMascu.Checked == true)
                {
                    inicial.inicial_noExaRealiEcoProstatico = "SI";
                }
                if (ckb_siConsuNociTabaHabToxi.Checked == true)
                {
                    inicial.inicial_siConsuNocivosTabaco = "SI";
                }
                if (ckb_noConsuNociTabaHabToxi.Checked == true)
                {
                    inicial.inicial_noConsuNocivosTabaco = "SI";
                }
                if (ckb_siConsuNociAlcoHabToxi.Checked == true)
                {
                    inicial.inicial_siConsuNocivosAlcohol = "SI";
                }
                if (ckb_noConsuNociAlcoHabToxi.Checked == true)
                {
                    inicial.inicial_noConsuNocivosAlcohol = "SI";
                }
                if (ckb_siConsuNociOtrasDroHabToxi.Checked == true)
                {
                    inicial.inicial_siConsuNocivosOtrasDrogas = "SI";
                }
                if (ckb_noConsuNociOtrasDroHabToxi.Checked == true)
                {
                    inicial.inicial_noConsuNocivosOtrasDrogas = "SI";
                }
                if (ckb_siEstVidaActFisiEstVida.Checked == true)
                {
                    inicial.inicial_siEstiVidaActFisica = "SI";
                }
                if (ckb_noEstVidaActFisiEstVida.Checked == true)
                {
                    inicial.inicial_noEstiVidaActFisica = "SI";
                }
                if (ckb_siEstVidaMedHabiEstVida.Checked == true)
                {
                    inicial.inicial_siEstiVidaMediHabitual = "SI";
                }
                if (ckb_noEstVidaMedHabiEstVida.Checked == true)
                {
                    inicial.inicial_noEstiVidaMediHabitual = "SI";
                }
                if (ckb_fisico.Checked == true)
                {
                    inicial.inicial_fisicoRies = "SI";
                }
                if (ckb_mecanico.Checked == true)
                {
                    inicial.inicial_mecanicoRies = "SI";
                }
                if (ckb_quimico.Checked == true)
                {
                    inicial.inicial_quimicoRies = "SI";
                }
                if (ckb_biologico.Checked == true)
                {
                    inicial.inicial_biologicoRies = "SI";
                }
                if (ckb_ergonomico.Checked == true)
                {
                    inicial.inicial_ergonomicoRies = "SI";
                }
                if (ckb_psicosocial.Checked == true)
                {
                    inicial.inicial_psicosocial = "SI";
                }
                if (ckb_fisico2.Checked == true)
                {
                    inicial.inicial_fisicoRies2 = "SI";
                }
                if (ckb_mecanico2.Checked == true)
                {
                    inicial.inicial_mecanicoRies2 = "SI";
                }
                if (ckb_quimico2.Checked == true)
                {
                    inicial.inicial_quimicoRies2 = "SI";
                }
                if (ckb_biologico2.Checked == true)
                {
                    inicial.inicial_biologicoRies2 = "SI";
                }
                if (ckb_ergonomico2.Checked == true)
                {
                    inicial.inicial_ergonomicoRies2 = "SI";
                }
                if (ckb_psicosocial2.Checked == true)
                {
                    inicial.inicial_psicosocial2 = "SI";
                }
                if (ckb_fisico3.Checked == true)
                {
                    inicial.inicial_fisicoRies3 = "SI";
                }
                if (ckb_mecanico3.Checked == true)
                {
                    inicial.inicial_mecanicoRies3 = "SI";
                }
                if (ckb_quimico3.Checked == true)
                {
                    inicial.inicial_quimicoRies3 = "SI";
                }
                if (ckb_biologico3.Checked == true)
                {
                    inicial.inicial_biologicoRies3 = "SI";
                }
                if (ckb_ergonomico3.Checked == true)
                {
                    inicial.inicial_ergonomicoRies3 = "SI";
                }
                if (ckb_psicosocial3.Checked == true)
                {
                    inicial.inicial_psicosocial3 = "SI";
                }
                if (ckb_fisico4.Checked == true)
                {
                    inicial.inicial_fisicoRies4 = "SI";
                }
                if (ckb_mecanico4.Checked == true)
                {
                    inicial.inicial_mecanicoRies4 = "SI";
                }
                if (ckb_quimico4.Checked == true)
                {
                    inicial.inicial_quimicoRies4 = "SI";
                }
                if (ckb_biologico4.Checked == true)
                {
                    inicial.inicial_biologicoRies4 = "SI";
                }
                if (ckb_ergonomico4.Checked == true)
                {
                    inicial.inicial_ergonomicoRies4 = "SI";
                }
                if (ckb_psicosocial4.Checked == true)
                {
                    inicial.inicial_psicosocial4 = "SI";
                }
                if (ckb_siAccTrabDescrip.Checked == true)
                {
                    inicial.inicial_siCalificadoIESSAcciTrabajo = "SI";
                }
                if (ckb_noAccTrabDescrip.Checked == true)
                {
                    inicial.inicial_noCalificadoIESSAcciTrabajo = "SI";
                }
                if (ckb_siprofesional.Checked == true)
                {
                    inicial.inicial_siCalificadoIESSEnfProfesionales = "SI";
                }
                if (ckb_noprofesional.Checked == true)
                {
                    inicial.inicial_noCalificadoIESSEnfProfesionales = "SI";
                }
                if (ckb_enfermedadcardiovascular.Checked == true)
                {
                    inicial.inicial_enfCarVasAnteFamiliares = "SI";
                }
                if (ckb_enfermedadmetabolica.Checked == true)
                {
                    inicial.inicial_enfMetaAnteFamiliares = "SI";
                }
                if (ckb_enfermedadneurologica.Checked == true)
                {
                    inicial.inicial_enfNeuroAnteFamiliares = "SI";
                }
                if (ckb_enfermedadoncologica.Checked == true)
                {
                    inicial.inicial_enfOncoAnteFamiliares = "SI";
                }
                if (ckb_enfermedadinfecciosa.Checked == true)
                {
                    inicial.inicial_enfInfeAnteFamiliares = "SI";
                }
                if (ckb_enfermedadhereditaria.Checked == true)
                {
                    inicial.inicial_enfHereCongeAnteFamiliares = "SI";
                }
                if (ckb_discapacidades.Checked == true)
                {
                    inicial.inicial_discapaAnteFamiliares = "SI";
                }
                if (ckb_otrosenfer.Checked == true)
                {
                    inicial.inicial_otrosAnteFamiliares = "SI";
                }

                if (ckb_tempaltas.Checked == true)
                {
                    inicial.inicial_temAltasFis = "SI";
                }
                if (ckb_tempbajas.Checked == true)
                {
                    inicial.inicial_temBajasFis = "SI";
                }
                if (ckb_radiacion.Checked == true)
                {
                    inicial.inicial_radIonizanteFis = "SI";
                }
                if (ckb_noradiacion.Checked == true)
                {
                    inicial.inicial_radNoIonizanteFis = "SI";
                }
                if (ckb_ruido.Checked == true)
                {
                    inicial.inicial_ruidoFis = "SI";
                }
                if (ckb_vibracion.Checked == true)
                {
                    inicial.inicial_vibracionFis = "SI";
                }
                if (ckb_iluminacion.Checked == true)
                {
                    inicial.inicial_iluminacionFis = "SI";
                }
                if (ckb_ventilacion.Checked == true)
                {
                    inicial.inicial_ventilacionFis = "SI";
                }
                if (ckb_fluidoelectrico.Checked == true)
                {
                    inicial.inicial_fluElectricoFis = "SI";
                }
                if (ckb_otrosFisico.Checked == true)
                {
                    inicial.inicial_otrosFis = "SI";
                }

                if (ckb_tempaltas2.Checked == true)
                {
                    inicial.inicial_temAltasFis2 = "SI";
                }
                if (ckb_tempbajas2.Checked == true)
                {
                    inicial.inicial_temBajasFis2 = "SI";
                }
                if (ckb_radiacion2.Checked == true)
                {
                    inicial.inicial_radIonizanteFis2 = "SI";
                }
                if (ckb_noradiacion2.Checked == true)
                {
                    inicial.inicial_radNoIonizanteFis2 = "SI";
                }
                if (ckb_ruido2.Checked == true)
                {
                    inicial.inicial_ruidoFis2 = "SI";
                }
                if (ckb_vibracion2.Checked == true)
                {
                    inicial.inicial_vibracionFis2 = "SI";
                }
                if (ckb_iluminacion2.Checked == true)
                {
                    inicial.inicial_iluminacionFis2 = "SI";
                }
                if (ckb_ventilacion2.Checked == true)
                {
                    inicial.inicial_ventilacionFis2 = "SI";
                }
                if (ckb_fluidoelectrico2.Checked == true)
                {
                    inicial.inicial_fluElectricoFis2 = "SI";
                }
                if (ckb_otrosFisico2.Checked == true)
                {
                    inicial.inicial_otrosFis2 = "SI";
                }
                if (ckb_tempaltas3.Checked == true)
                {
                    inicial.inicial_temAltasFis3 = "SI";
                }
                if (ckb_tempbajas3.Checked == true)
                {
                    inicial.inicial_temBajasFis3 = "SI";
                }
                if (ckb_radiacion3.Checked == true)
                {
                    inicial.inicial_radIonizanteFis3 = "SI";
                }
                if (ckb_noradiacion3.Checked == true)
                {
                    inicial.inicial_radNoIonizanteFis3 = "SI";
                }
                if (ckb_ruido3.Checked == true)
                {
                    inicial.inicial_ruidoFis3 = "SI";
                }
                if (ckb_vibracion3.Checked == true)
                {
                    inicial.inicial_vibracionFis3 = "SI";
                }
                if (ckb_iluminacion3.Checked == true)
                {
                    inicial.inicial_iluminacionFis3 = "SI";
                }
                if (ckb_ventilacion3.Checked == true)
                {
                    inicial.inicial_ventilacionFis3 = "SI";
                }
                if (ckb_fluidoelectrico3.Checked == true)
                {
                    inicial.inicial_fluElectricoFis3 = "SI";
                }
                if (ckb_otrosFisico3.Checked == true)
                {
                    inicial.inicial_otrosFis3 = "SI";
                }
                if (ckb_tempaltas4.Checked == true)
                {
                    inicial.inicial_temAltasFis4 = "SI";
                }
                if (ckb_tempbajas4.Checked == true)
                {
                    inicial.inicial_temBajasFis4 = "SI";
                }
                if (ckb_radiacion4.Checked == true)
                {
                    inicial.inicial_radIonizanteFis4 = "SI";
                }
                if (ckb_noradiacion4.Checked == true)
                {
                    inicial.inicial_radNoIonizanteFis4 = "SI";
                }
                if (ckb_ruido4.Checked == true)
                {
                    inicial.inicial_ruidoFis4 = "SI";
                }
                if (ckb_vibracion4.Checked == true)
                {
                    inicial.inicial_vibracionFis4 = "SI";
                }
                if (ckb_iluminacion4.Checked == true)
                {
                    inicial.inicial_iluminacionFis4 = "SI";
                }
                if (ckb_ventilacion4.Checked == true)
                {
                    inicial.inicial_ventilacionFis4 = "SI";
                }
                if (ckb_fluidoelectrico4.Checked == true)
                {
                    inicial.inicial_fluElectricoFis4 = "SI";
                }
                if (ckb_otrosFisico4.Checked == true)
                {
                    inicial.inicial_otrosFis4 = "SI";
                }
                if (ckb_atrapmaquinas.Checked == true)
                {
                    inicial.inicial_atraMaquinasMec = "SI";
                }
                if (ckb_atrapsuperficie.Checked == true)
                {
                    inicial.inicial_atraSuperfiiesMec = "SI";
                }
                if (ckb_atrapobjetos.Checked == true)
                {
                    inicial.inicial_atraObjetosMec = "SI";
                }
                if (ckb_caidaobjetos.Checked == true)
                {
                    inicial.inicial_caidaObjetosMec = "SI";
                }
                if (ckb_caidamisnivel.Checked == true)
                {
                    inicial.inicial_caidaMisNivelMec = "SI";
                }
                if (ckb_caidadifnivel.Checked == true)
                {
                    inicial.inicial_caidaDifNivelMec = "SI";
                }
                if (ckb_contaelectrico.Checked == true)
                {
                    inicial.inicial_contactoElecMec = "SI";
                }
                if (ckb_contasuptrabajo.Checked == true)
                {
                    inicial.inicial_conSuperTrabaMec = "SI";
                }
                if (ckb_proyparticulas.Checked == true)
                {
                    inicial.inicial_proPartiFragMec = "SI";
                }
                if (ckb_proyefluidos.Checked == true)
                {
                    inicial.inicial_proFluidosMec = "SI";
                }
                if (ckb_pinchazos.Checked == true)
                {
                    inicial.inicial_pinchazosMec = "SI";
                }
                if (ckb_cortes.Checked == true)
                {
                    inicial.inicial_cortesMec = "SI";
                }
                if (ckb_atroporvehiculos.Checked == true)
                {
                    inicial.inicial_atropeVehiMec = "SI";
                }
                if (ckb_choques.Checked == true)
                {
                    inicial.inicial_coliVehiMec = "SI";
                }
                if (ckb_otrosMecanico.Checked == true)
                {
                    inicial.inicial_otrosMec = "SI";
                }
                if (ckb_solidos.Checked == true)
                {
                    inicial.inicial_solidosQui = "SI";
                }
                if (ckb_polvos.Checked == true)
                {
                    inicial.inicial_polvosQui = "SI";
                }
                if (ckb_humos.Checked == true)
                {
                    inicial.inicial_humosQui = "SI";
                }
                if (ckb_liquidos.Checked == true)
                {
                    inicial.inicial_liquidosQui = "SI";
                }
                if (ckb_vapores.Checked == true)
                {
                    inicial.inicial_vaporesQui = "SI";
                }
                if (ckb_aerosoles.Checked == true)
                {
                    inicial.inicial_aerosolesQui = "SI";
                }
                if (ckb_neblinas.Checked == true)
                {
                    inicial.inicial_neblinasQui = "SI";
                }
                if (ckb_gaseosos.Checked == true)
                {
                    inicial.inicial_gaseososQui = "SI";
                }
                if (ckb_otrosQuimico.Checked == true)
                {
                    inicial.inicial_otrosQui = "SI";
                }
                if (ckb_atrapmaquinas2.Checked == true)
                {
                    inicial.inicial_atraMaquinasMec2 = "SI";
                }
                if (ckb_atrapsuperficie2.Checked == true)
                {
                    inicial.inicial_atraSuperfiiesMec2 = "SI";
                }
                if (ckb_atrapobjetos2.Checked == true)
                {
                    inicial.inicial_atraObjetosMec2 = "SI";
                }
                if (ckb_caidaobjetos2.Checked == true)
                {
                    inicial.inicial_caidaObjetosMec2 = "SI";
                }
                if (ckb_caidamisnivel2.Checked == true)
                {
                    inicial.inicial_caidaMisNivelMec2 = "SI";
                }
                if (ckb_caidadifnivel2.Checked == true)
                {
                    inicial.inicial_caidaDifNivelMec2 = "SI";
                }
                if (ckb_contaelectrico2.Checked == true)
                {
                    inicial.inicial_contactoElecMec2 = "SI";
                }
                if (ckb_contasuptrabajo2.Checked == true)
                {
                    inicial.inicial_conSuperTrabaMec2 = "SI";
                }
                if (ckb_proyparticulas2.Checked == true)
                {
                    inicial.inicial_proPartiFragMec2 = "SI";
                }
                if (ckb_proyefluidos2.Checked == true)
                {
                    inicial.inicial_proFluidosMec2 = "SI";
                }
                if (ckb_pinchazos2.Checked == true)
                {
                    inicial.inicial_pinchazosMec2 = "SI";
                }
                if (ckb_cortes2.Checked == true)
                {
                    inicial.inicial_cortesMec2 = "SI";
                }
                if (ckb_atroporvehiculos2.Checked == true)
                {
                    inicial.inicial_atropeVehiMec2 = "SI";
                }
                if (ckb_choques2.Checked == true)
                {
                    inicial.inicial_coliVehiMec2 = "SI";
                }
                if (ckb_otrosMecanico2.Checked == true)
                {
                    inicial.inicial_otrosMec2 = "SI";
                }
                if (ckb_solidos2.Checked == true)
                {
                    inicial.inicial_solidosQui2 = "SI";
                }
                if (ckb_polvos2.Checked == true)
                {
                    inicial.inicial_polvosQui2 = "SI";
                }
                if (ckb_humos2.Checked == true)
                {
                    inicial.inicial_humosQui2 = "SI";
                }
                if (ckb_liquidos2.Checked == true)
                {
                    inicial.inicial_liquidosQui2 = "SI";
                }
                if (ckb_vapores2.Checked == true)
                {
                    inicial.inicial_vaporesQui2 = "SI";
                }
                if (ckb_aerosoles2.Checked == true)
                {
                    inicial.inicial_aerosolesQui2 = "SI";
                }
                if (ckb_neblinas2.Checked == true)
                {
                    inicial.inicial_neblinasQui2 = "SI";
                }
                if (ckb_gaseosos2.Checked == true)
                {
                    inicial.inicial_gaseososQui2 = "SI";
                }
                if (ckb_otrosQuimico2.Checked == true)
                {
                    inicial.inicial_otrosQui2 = "SI";
                }
                if (ckb_atrapmaquinas3.Checked == true)
                {
                    inicial.inicial_atraMaquinasMec3 = "SI";
                }
                if (ckb_atrapsuperficie3.Checked == true)
                {
                    inicial.inicial_atraSuperfiiesMec3 = "SI";
                }
                if (ckb_atrapobjetos3.Checked == true)
                {
                    inicial.inicial_atraObjetosMec3 = "SI";
                }
                if (ckb_caidaobjetos3.Checked == true)
                {
                    inicial.inicial_caidaObjetosMec3 = "SI";
                }
                if (ckb_caidamisnivel3.Checked == true)
                {
                    inicial.inicial_caidaMisNivelMec3 = "SI";
                }
                if (ckb_caidadifnivel3.Checked == true)
                {
                    inicial.inicial_caidaDifNivelMec3 = "SI";
                }
                if (ckb_contaelectrico3.Checked == true)
                {
                    inicial.inicial_contactoElecMec3 = "SI";
                }
                if (ckb_contasuptrabajo3.Checked == true)
                {
                    inicial.inicial_conSuperTrabaMec3 = "SI";
                }
                if (ckb_proyparticulas3.Checked == true)
                {
                    inicial.inicial_proPartiFragMec3 = "SI";
                }
                if (ckb_proyefluidos3.Checked == true)
                {
                    inicial.inicial_proFluidosMec3 = "SI";
                }
                if (ckb_pinchazos3.Checked == true)
                {
                    inicial.inicial_pinchazosMec3 = "SI";
                }
                if (ckb_cortes3.Checked == true)
                {
                    inicial.inicial_cortesMec3 = "SI";
                }
                if (ckb_atroporvehiculos3.Checked == true)
                {
                    inicial.inicial_atropeVehiMec3 = "SI";
                }
                if (ckb_choques3.Checked == true)
                {
                    inicial.inicial_coliVehiMec3 = "SI";
                }
                if (ckb_otrosMecanico3.Checked == true)
                {
                    inicial.inicial_otrosMec3 = "SI";
                }
                if (ckb_solidos3.Checked == true)
                {
                    inicial.inicial_solidosQui3 = "SI";
                }
                if (ckb_polvos3.Checked == true)
                {
                    inicial.inicial_polvosQui3 = "SI";
                }
                if (ckb_humos3.Checked == true)
                {
                    inicial.inicial_humosQui3 = "SI";
                }
                if (ckb_liquidos3.Checked == true)
                {
                    inicial.inicial_liquidosQui3 = "SI";
                }
                if (ckb_vapores3.Checked == true)
                {
                    inicial.inicial_vaporesQui3 = "SI";
                }
                if (ckb_aerosoles3.Checked == true)
                {
                    inicial.inicial_aerosolesQui3 = "SI";
                }
                if (ckb_neblinas3.Checked == true)
                {
                    inicial.inicial_neblinasQui3 = "SI";
                }
                if (ckb_gaseosos3.Checked == true)
                {
                    inicial.inicial_gaseososQui3 = "SI";
                }
                if (ckb_otrosQuimico3.Checked == true)
                {
                    inicial.inicial_otrosQui3 = "SI";
                }
                if (ckb_atrapmaquinas4.Checked == true)
                {
                    inicial.inicial_atraMaquinasMec4 = "SI";
                }
                if (ckb_atrapsuperficie4.Checked == true)
                {
                    inicial.inicial_atraSuperfiiesMec4 = "SI";
                }
                if (ckb_atrapobjetos4.Checked == true)
                {
                    inicial.inicial_atraObjetosMec4 = "SI";
                }
                if (ckb_caidaobjetos4.Checked == true)
                {
                    inicial.inicial_caidaObjetosMec4 = "SI";
                }
                if (ckb_caidamisnivel4.Checked == true)
                {
                    inicial.inicial_caidaMisNivelMec4 = "SI";
                }
                if (ckb_caidadifnivel4.Checked == true)
                {
                    inicial.inicial_caidaDifNivelMec4 = "SI";
                }
                if (ckb_contaelectrico4.Checked == true)
                {
                    inicial.inicial_contactoElecMec4 = "SI";
                }
                if (ckb_contasuptrabajo4.Checked == true)
                {
                    inicial.inicial_conSuperTrabaMec4 = "SI";
                }
                if (ckb_proyparticulas4.Checked == true)
                {
                    inicial.inicial_proPartiFragMec4 = "SI";
                }
                if (ckb_proyefluidos4.Checked == true)
                {
                    inicial.inicial_proFluidosMec4 = "SI";
                }
                if (ckb_pinchazos4.Checked == true)
                {
                    inicial.inicial_pinchazosMec4 = "SI";
                }
                if (ckb_cortes4.Checked == true)
                {
                    inicial.inicial_cortesMec4 = "SI";
                }
                if (ckb_atroporvehiculos4.Checked == true)
                {
                    inicial.inicial_atropeVehiMec4 = "SI";
                }
                if (ckb_choques4.Checked == true)
                {
                    inicial.inicial_coliVehiMec4 = "SI";
                }
                if (ckb_otrosMecanico4.Checked == true)
                {
                    inicial.inicial_otrosMec4 = "SI";
                }
                if (ckb_solidos4.Checked == true)
                {
                    inicial.inicial_solidosQui4 = "SI";
                }
                if (ckb_polvos4.Checked == true)
                {
                    inicial.inicial_polvosQui4 = "SI";
                }
                if (ckb_humos4.Checked == true)
                {
                    inicial.inicial_humosQui4 = "SI";
                }
                if (ckb_liquidos4.Checked == true)
                {
                    inicial.inicial_liquidosQui4 = "SI";
                }
                if (ckb_vapores4.Checked == true)
                {
                    inicial.inicial_vaporesQui4 = "SI";
                }
                if (ckb_aerosoles4.Checked == true)
                {
                    inicial.inicial_aerosolesQui4 = "SI";
                }
                if (ckb_neblinas4.Checked == true)
                {
                    inicial.inicial_neblinasQui4 = "SI";
                }
                if (ckb_gaseosos4.Checked == true)
                {
                    inicial.inicial_gaseososQui4 = "SI";
                }
                if (ckb_otrosQuimico4.Checked == true)
                {
                    inicial.inicial_otrosQui4 = "SI";
                }
                if (ckb_virus.Checked == true)
                {
                    inicial.inicial_virusBio = "SI";
                }
                if (ckb_hongos.Checked == true)
                {
                    inicial.inicial_hongosBio = "SI";
                }
                if (ckb_bacterias.Checked == true)
                {
                    inicial.inicial_bacteriasBio = "SI";
                }
                if (ckb_parasitos.Checked == true)
                {
                    inicial.inicial_parasitosBio = "SI";
                }
                if (ckb_expoavectores.Checked == true)
                {
                    inicial.inicial_expVectBio = "SI";
                }
                if (ckb_expoanimselvaticos.Checked == true)
                {
                    inicial.inicial_expAniSelvaBio = "SI";
                }
                if (ckb_otrosBiologico.Checked == true)
                {
                    inicial.inicial_otrosBio = "SI";
                }
                if (ckb_manmanualcargas.Checked == true)
                {
                    inicial.inicial_maneManCarErg = "SI";
                }
                if (ckb_movrepetitivo.Checked == true)
                {
                    inicial.inicial_movRepeErg = "SI";
                }
                if (ckb_postforzadas.Checked == true)
                {
                    inicial.inicial_posForzaErg = "SI";
                }
                if (ckb_trabajopvd.Checked == true)
                {
                    inicial.inicial_trabPvdErg = "SI";
                }
                if (ckb_otrosErgonomico.Checked == true)
                {
                    inicial.inicial_otrosErg = "SI";
                }
                if (ckb_virus2.Checked == true)
                {
                    inicial.inicial_virusBio2 = "SI";
                }
                if (ckb_hongos2.Checked == true)
                {
                    inicial.inicial_hongosBio2 = "SI";
                }
                if (ckb_bacterias2.Checked == true)
                {
                    inicial.inicial_bacteriasBio2 = "SI";
                }
                if (ckb_parasitos2.Checked == true)
                {
                    inicial.inicial_parasitosBio2 = "SI";
                }
                if (ckb_expoavectores2.Checked == true)
                {
                    inicial.inicial_expVectBio2 = "SI";
                }
                if (ckb_expoanimselvaticos2.Checked == true)
                {
                    inicial.inicial_expAniSelvaBio2 = "SI";
                }
                if (ckb_otrosBiologico2.Checked == true)
                {
                    inicial.inicial_otrosBio2 = "SI";
                }
                if (ckb_manmanualcargas2.Checked == true)
                {
                    inicial.inicial_maneManCarErg2 = "SI";
                }
                if (ckb_movrepetitivo2.Checked == true)
                {
                    inicial.inicial_movRepeErg2 = "SI";
                }
                if (ckb_postforzadas2.Checked == true)
                {
                    inicial.inicial_posForzaErg2 = "SI";
                }
                if (ckb_trabajopvd2.Checked == true)
                {
                    inicial.inicial_trabPvdErg2 = "SI";
                }
                if (ckb_otrosErgonomico2.Checked == true)
                {
                    inicial.inicial_otrosErg2 = "SI";
                }
                if (ckb_virus3.Checked == true)
                {
                    inicial.inicial_virusBio3 = "SI";
                }
                if (ckb_hongos3.Checked == true)
                {
                    inicial.inicial_hongosBio3 = "SI";
                }
                if (ckb_bacterias3.Checked == true)
                {
                    inicial.inicial_bacteriasBio3 = "SI";
                }
                if (ckb_parasitos3.Checked == true)
                {
                    inicial.inicial_parasitosBio3 = "SI";
                }
                if (ckb_expoavectores3.Checked == true)
                {
                    inicial.inicial_expVectBio3 = "SI";
                }
                if (ckb_expoanimselvaticos3.Checked == true)
                {
                    inicial.inicial_expAniSelvaBio3 = "SI";
                }
                if (ckb_otrosBiologico3.Checked == true)
                {
                    inicial.inicial_otrosBio3 = "SI";
                }
                if (ckb_manmanualcargas3.Checked == true)
                {
                    inicial.inicial_maneManCarErg3 = "SI";
                }
                if (ckb_movrepetitivo3.Checked == true)
                {
                    inicial.inicial_movRepeErg3 = "SI";
                }
                if (ckb_postforzadas3.Checked == true)
                {
                    inicial.inicial_posForzaErg3 = "SI";
                }
                if (ckb_trabajopvd3.Checked == true)
                {
                    inicial.inicial_trabPvdErg3 = "SI";
                }
                if (ckb_otrosErgonomico3.Checked == true)
                {
                    inicial.inicial_otrosErg3 = "SI";
                }
                if (ckb_virus4.Checked == true)
                {
                    inicial.inicial_virusBio4 = "SI";
                }
                if (ckb_hongos4.Checked == true)
                {
                    inicial.inicial_hongosBio4 = "SI";
                }
                if (ckb_bacterias4.Checked == true)
                {
                    inicial.inicial_bacteriasBio4 = "SI";
                }
                if (ckb_parasitos4.Checked == true)
                {
                    inicial.inicial_parasitosBio4 = "SI";
                }
                if (ckb_expoavectores4.Checked == true)
                {
                    inicial.inicial_expVectBio4 = "SI";
                }
                if (ckb_expoanimselvaticos4.Checked == true)
                {
                    inicial.inicial_expAniSelvaBio4 = "SI";
                }
                if (ckb_otrosBiologico4.Checked == true)
                {
                    inicial.inicial_otrosBio4 = "SI";
                }
                if (ckb_manmanualcargas4.Checked == true)
                {
                    inicial.inicial_maneManCarErg4 = "SI";
                }
                if (ckb_movrepetitivo4.Checked == true)
                {
                    inicial.inicial_movRepeErg4 = "SI";
                }
                if (ckb_postforzadas4.Checked == true)
                {
                    inicial.inicial_posForzaErg4 = "SI";
                }
                if (ckb_trabajopvd4.Checked == true)
                {
                    inicial.inicial_trabPvdErg4 = "SI";
                }
                if (ckb_otrosErgonomico4.Checked == true)
                {
                    inicial.inicial_otrosErg4 = "SI";
                }
                if (ckb_montrabajo.Checked == true)
                {
                    inicial.inicial_monoTrabPsi = "SI";
                }
                if (ckb_sobrecargalaboral.Checked == true)
                {
                    inicial.inicial_sobrecarLabPsi = "SI";
                }
                if (ckb_minustarea.Checked == true)
                {
                    inicial.inicial_minuTareaPsi = "SI";
                }
                if (ckb_altarespon.Checked == true)
                {
                    inicial.inicial_altaResponPsi = "SI";
                }
                if (ckb_automadesiciones.Checked == true)
                {
                    inicial.inicial_autoTomaDesiPsi = "SI";
                }
                if (ckb_supyestdireficiente.Checked == true)
                {
                    inicial.inicial_supEstDirecDefiPsi = "SI";
                }
                if (ckb_conflictorol.Checked == true)
                {
                    inicial.inicial_conflicRolPsi = "SI";
                }
                if (ckb_faltaclarfunciones.Checked == true)
                {
                    inicial.inicial_falClariFunPsi = "SI";
                }
                if (ckb_incorrdistrabajo.Checked == true)
                {
                    inicial.inicial_incoDistriTrabPsi = "SI";
                }
                if (ckb_turnorotat.Checked == true)
                {
                    inicial.inicial_turnosRotaPsi = "SI";
                }
                if (ckb_relacinterpersonales.Checked == true)
                {
                    inicial.inicial_relInterperPsi = "SI";
                }
                if (ckb_inestalaboral.Checked == true)
                {
                    inicial.inicial_inesLabPsi = "SI";
                }
                if (ckb_otrosPsicosocial.Checked == true)
                {
                    inicial.inicial_otrosPsi = "SI";
                }
                if (ckb_montrabajo2.Checked == true)
                {
                    inicial.inicial_monoTrabPsi2 = "SI";
                }
                if (ckb_sobrecargalaboral2.Checked == true)
                {
                    inicial.inicial_sobrecarLabPsi2 = "SI";
                }
                if (ckb_minustarea2.Checked == true)
                {
                    inicial.inicial_minuTareaPsi2 = "SI";
                }
                if (ckb_altarespon2.Checked == true)
                {
                    inicial.inicial_altaResponPsi2 = "SI";
                }
                if (ckb_automadesiciones2.Checked == true)
                {
                    inicial.inicial_autoTomaDesiPsi2 = "SI";
                }
                if (ckb_supyestdireficiente2.Checked == true)
                {
                    inicial.inicial_supEstDirecDefiPsi2 = "SI";
                }
                if (ckb_conflictorol2.Checked == true)
                {
                    inicial.inicial_conflicRolPsi2 = "SI";
                }
                if (ckb_faltaclarfunciones2.Checked == true)
                {
                    inicial.inicial_falClariFunPsi2 = "SI";
                }
                if (ckb_incorrdistrabajo2.Checked == true)
                {
                    inicial.inicial_incoDistriTrabPsi2 = "SI";
                }
                if (ckb_turnorotat2.Checked == true)
                {
                    inicial.inicial_turnosRotaPsi2 = "SI";
                }
                if (ckb_relacinterpersonales2.Checked == true)
                {
                    inicial.inicial_relInterperPsi2 = "SI";
                }
                if (ckb_inestalaboral2.Checked == true)
                {
                    inicial.inicial_inesLabPsi2 = "SI";
                }
                if (ckb_otrosPsicosocial2.Checked == true)
                {
                    inicial.inicial_otrosPsi2 = "SI";
                }
                if (ckb_montrabajo3.Checked == true)
                {
                    inicial.inicial_monoTrabPsi3 = "SI";
                }
                if (ckb_sobrecargalaboral3.Checked == true)
                {
                    inicial.inicial_sobrecarLabPsi3 = "SI";
                }
                if (ckb_minustarea3.Checked == true)
                {
                    inicial.inicial_minuTareaPsi3 = "SI";
                }
                if (ckb_altarespon3.Checked == true)
                {
                    inicial.inicial_altaResponPsi3 = "SI";
                }
                if (ckb_automadesiciones3.Checked == true)
                {
                    inicial.inicial_autoTomaDesiPsi3 = "SI";
                }
                if (ckb_supyestdireficiente3.Checked == true)
                {
                    inicial.inicial_supEstDirecDefiPsi3 = "SI";
                }
                if (ckb_conflictorol3.Checked == true)
                {
                    inicial.inicial_conflicRolPsi3 = "SI";
                }
                if (ckb_faltaclarfunciones3.Checked == true)
                {
                    inicial.inicial_falClariFunPsi3 = "SI";
                }
                if (ckb_incorrdistrabajo3.Checked == true)
                {
                    inicial.inicial_incoDistriTrabPsi3 = "SI";
                }
                if (ckb_turnorotat3.Checked == true)
                {
                    inicial.inicial_turnosRotaPsi3 = "SI";
                }
                if (ckb_relacinterpersonales3.Checked == true)
                {
                    inicial.inicial_relInterperPsi3 = "SI";
                }
                if (ckb_inestalaboral3.Checked == true)
                {
                    inicial.inicial_inesLabPsi3 = "SI";
                }
                if (ckb_otrosPsicosocial3.Checked == true)
                {
                    inicial.inicial_otrosPsi3 = "SI";
                }
                if (ckb_montrabajo4.Checked == true)
                {
                    inicial.inicial_monoTrabPsi4 = "SI";
                }
                if (ckb_sobrecargalaboral4.Checked == true)
                {
                    inicial.inicial_sobrecarLabPsi4 = "SI";
                }
                if (ckb_minustarea4.Checked == true)
                {
                    inicial.inicial_minuTareaPsi4 = "SI";
                }
                if (ckb_altarespon4.Checked == true)
                {
                    inicial.inicial_altaResponPsi4 = "SI";
                }
                if (ckb_automadesiciones4.Checked == true)
                {
                    inicial.inicial_autoTomaDesiPsi4 = "SI";
                }
                if (ckb_supyestdireficiente4.Checked == true)
                {
                    inicial.inicial_supEstDirecDefiPsi4 = "SI";
                }
                if (ckb_conflictorol4.Checked == true)
                {
                    inicial.inicial_conflicRolPsi4 = "SI";
                }
                if (ckb_faltaclarfunciones4.Checked == true)
                {
                    inicial.inicial_falClariFunPsi4 = "SI";
                }
                if (ckb_incorrdistrabajo4.Checked == true)
                {
                    inicial.inicial_incoDistriTrabPsi4 = "SI";
                }
                if (ckb_turnorotat4.Checked == true)
                {
                    inicial.inicial_turnosRotaPsi4 = "SI";
                }
                if (ckb_relacinterpersonales4.Checked == true)
                {
                    inicial.inicial_relInterperPsi4 = "SI";
                }
                if (ckb_inestalaboral4.Checked == true)
                {
                    inicial.inicial_inesLabPsi4 = "SI";
                }
                if (ckb_otrosPsicosocial4.Checked == true)
                {
                    inicial.inicial_otrosPsi4 = "SI";
                }
                if (ckb_pielanexos.Checked == true)
                {
                    inicial.inicial_pielAnexos = "SI";
                }
                if (ckb_respiratorio.Checked == true)
                {
                    inicial.inicial_respiratorio = "SI";
                }
                if (ckb_digestivo.Checked == true)
                {
                    inicial.inicial_digestivo = "SI";
                }
                if (ckb_musculosesqueleticos.Checked == true)
                {
                    inicial.inicial_muscEsqueletico = "SI";
                }
                if (ckb_hemolinfatico.Checked == true)
                {
                    inicial.inicial_hemoLimfa = "SI";
                }
                if (ckb_organossentidos.Checked == true)
                {
                    inicial.inicial_orgSentidos = "SI";
                }
                if (ckb_cardiovascular.Checked == true)
                {
                    inicial.inicial_cardVascular = "SI";
                }
                if (ckb_genitourinario.Checked == true)
                {
                    inicial.inicial_genUrinario = "SI";
                }
                if (ckb_endocrino.Checked == true)
                {
                    inicial.inicial_endocrino = "SI";
                }
                if (ckb_nervioso.Checked == true)
                {
                    inicial.inicial_nervioso = "SI";
                }
                if (ckb_cicatrices.Checked == true)
                {
                    inicial.inicial_cicatricesPiel = "SI";
                }
                if (ckb_auditivoexterno.Checked == true)
                {
                    inicial.inicial_cAudiExtreOido = "SI";
                }
                if (ckb_tabique.Checked == true)
                {
                    inicial.inicial_tabiqueNariz = "SI";
                }
                if (ckb_pulmones.Checked == true)
                {
                    inicial.inicial_pulmonesTorax2 = "SI";
                }
                if (ckb_pelvis.Checked == true)
                {
                    inicial.inicial_pelvisPelvis = "SI";
                }
                if (ckb_tatuajes.Checked == true)
                {
                    inicial.inicial_tatuajesPiel = "SI";
                }
                if (ckb_pabellon.Checked == true)
                {
                    inicial.inicial_pabellonOido = "SI";
                }
                if (ckb_cornetes.Checked == true)
                {
                    inicial.inicial_cornetesNariz = "SI";
                }
                if (ckb_parrillacostal.Checked == true)
                {
                    inicial.inicial_parriCostalTorax2 = "SI";
                }
                if (ckb_genitales.Checked == true)
                {
                    inicial.inicial_genitalesPelvis = "SI";
                }
                if (ckb_pielyfaneras.Checked == true)
                {
                    inicial.inicial_pielFacerasPiel = "SI";
                }
                if (ckb_timpanos.Checked == true)
                {
                    inicial.inicial_timpanosOido = "SI";
                }
                if (ckb_mucosa.Checked == true)
                {
                    inicial.inicial_mucosasNariz = "SI";
                }
                if (ckb_visceras.Checked == true)
                {
                    inicial.inicial_viscerasAbdomen = "SI";
                }
                if (ckb_vascular.Checked == true)
                {
                    inicial.inicial_vascularExtre = "SI";
                }
                if (ckb_parpados.Checked == true)
                {
                    inicial.inicial_parpadosOjos = "SI";
                }
                if (ckb_labios.Checked == true)
                {
                    inicial.inicial_labiosOroFa = "SI";
                }
                if (ckb_senosparanasales.Checked == true)
                {
                    inicial.inicial_senosParanaNariz = "SI";
                }
                if (ckb_paredabdominal.Checked == true)
                {
                    inicial.inicial_paredAbdomiAbdomen = "SI";
                }
                if (ckb_miembrosuperiores.Checked == true)
                {
                    inicial.inicial_miemSupeExtre = "SI";
                }
                if (ckb_conjuntivas.Checked == true)
                {
                    inicial.inicial_conjuntuvasOjos = "SI";
                }
                if (ckb_lengua.Checked == true)
                {
                    inicial.inicial_lenguaOroFa = "SI";
                }
                if (ckb_tiroides.Checked == true)
                {
                    inicial.inicial_tiroiMasasCuello = "SI";
                }
                if (ckb_flexibilidad.Checked == true)
                {
                    inicial.inicial_flexibilidadColumna = "SI";
                }
                if (ckb_miembrosinferiores.Checked == true)
                {
                    inicial.inicial_miemInfeExtre = "SI";
                }
                if (ckb_pupilas.Checked == true)
                {
                    inicial.inicial_pupilasOjos = "SI";
                }
                if (ckb_faringe.Checked == true)
                {
                    inicial.inicial_faringeOroFa = "SI";
                }
                if (ckb_movilidad.Checked == true)
                {
                    inicial.inicial_movilidadCuello = "SI";
                }
                if (ckb_desviacion.Checked == true)
                {
                    inicial.inicial_desviacionColumna = "SI";
                }
                if (ckb_fuerza.Checked == true)
                {
                    inicial.inicial_fuerzaNeuro = "SI";
                }
                if (ckb_cornea.Checked == true)
                {
                    inicial.inicial_corneaOjos = "SI";
                }
                if (ckb_amigdalas.Checked == true)
                {
                    inicial.inicial_amigdalasOroFa = "SI";
                }
                if (ckb_mamas.Checked == true)
                {
                    inicial.inicial_mamasTorax = "SI";
                }
                if (ckb_sensibilidad.Checked == true)
                {
                    inicial.inicial_sensibiNeuro = "SI";
                }
                if (ckb_motilidad.Checked == true)
                {
                    inicial.inicial_motilidadOjos = "SI";
                }
                if (ckb_dentadura.Checked == true)
                {
                    inicial.inicial_dentaduraOroFa = "SI";
                }
                if (ckb_corazon.Checked == true)
                {
                    inicial.inicial_corazonTorax = "SI";
                }
                if (ckb_dolor.Checked == true)
                {
                    inicial.inicial_dolorColumna = "SI";
                }
                if (ckb_marcha.Checked == true)
                {
                    inicial.inicial_marchaNeuro = "SI";
                }
                if (ckb_reflejos.Checked == true)
                {
                    inicial.inicial_refleNeuro = "SI";
                }
                if (ckb_pre.Checked == true)
                {
                    inicial.inicial_pre = "SI";
                }
                if (ckb_def.Checked == true)
                {
                    inicial.inicial_def = "SI";
                }
                if (ckb_pre2.Checked == true)
                {
                    inicial.inicial_pre2 = "SI";
                }
                if (ckb_def2.Checked == true)
                {
                    inicial.inicial_def2 = "SI";
                }
                if (ckb_pre3.Checked == true)
                {
                    inicial.inicial_pre3 = "SI";
                }
                if (ckb_def3.Checked == true)
                {
                    inicial.inicial_def3 = "SI";
                }
                if (ckb_apto.Checked == true)
                {
                    inicial.inicial_apto = "SI";
                }
                if (ckb_aptoobservacion.Checked == true)
                {
                    inicial.inicial_aptoObserva = "SI";
                }
                if (ckb_aptolimitacion.Checked == true)
                {
                    inicial.inicial_aptoLimi = "SI";
                }
                if (ckb_noapto.Checked == true)
                {
                    inicial.inicial_NoApto = "SI";
                }

                //A
                inicial.inicial_ciiu = txt_ciiu.Text.ToUpper();
                inicial.inicial_numArchivo = txt_numArchivo.Text.ToUpper();
                inicial.inicial_groSanguineo = txt_gruposanguineo.Text.ToUpper();
                inicial.inicial_lateralidad = txt_lateralidad.Text.ToUpper();
                inicial.inicial_tipoDis = txt_tipodiscapacidad.Text.ToUpper();
                inicial.inicial_porcentDis = txt_porcentajediscapacidad.Text.ToUpper();
                inicial.inicial_actRelePuesTrabajo = txt_actividadesrelevantes.Text.ToUpper();

                //B
                inicial.inicial_descripcionMotivoConsulta = txt_motivoconsultainicial.Text.ToUpper();

                //C
                inicial.inicial_descripcionAnteceCliniQuirur = txt_antCliQuiDescripcion.Text.ToUpper();

                inicial.inicial_menarquia = txt_menarquiaAntGinObste.Text.ToUpper();
                inicial.inicial_ciclos = txt_ciclosAntGinObste.Text.ToUpper();
                inicial.inicial_fechUltiMenstrua = txt_fechUltiMensAntGinObste.Text.ToUpper();
                inicial.inicial_gestas = txt_gestasAntGinObste.Text.ToUpper();
                inicial.inicial_partos = txt_partosAntGinObste.Text.ToUpper();
                inicial.inicial_cesareas = txt_cesareasAntGinObste.Text.ToUpper();
                inicial.inicial_abortos = txt_abortosAntGinObste.Text.ToUpper();
                inicial.inicial_vivosHij = txt_vivosAntGinObste.Text.ToUpper();
                inicial.inicial_muertosHij = txt_muertosAntGinObste.Text.ToUpper();
                inicial.inicial_tipoMetPlanifiFamiliar = txt_tipoMetPlaniAntGinObste.Text.ToUpper();

                inicial.inicial_tiempoExaRealiPapanicolaou = txt_tiempoPapaniAntGinObste.Text.ToUpper();
                inicial.inicial_resultadoExaRealiPapanicolaou = txt_resultadoPapaniAntGinObste.Text.ToUpper();
                inicial.inicial_tiempoExaRealiEcoMamario = txt_tiempoEcoMamaAntGinObste.Text.ToUpper();
                inicial.inicial_resultadoExaRealiEcoMamario = txt_resultadoEcoMamaAntGinObste.Text.ToUpper();
                inicial.inicial_tiempoExaRealiColposcopia = txt_tiempoColposAntGinObste.Text.ToUpper();
                inicial.inicial_resultadoExaRealiColposcopia = txt_resultadoColposAntGinObste.Text.ToUpper();
                inicial.inicial_tiempoExaRealiMamografia = txt_tiempoMamograAntGinObste.Text.ToUpper();
                inicial.inicial_resultadoExaRealiMamografia = txt_resultadoMamograAntGinObste.Text.ToUpper();

                inicial.inicial_tiempoExaRealiAntiProstatico = txt_tiempoExaRealiAntProstaAntReproMascu.Text.ToUpper();
                inicial.inicial_resultadoExaRealiAntiProstatico = txt_resultadoExaRealiAntProstaAntReproMascu.Text.ToUpper();
                inicial.inicial_tipo1MetPlanifiFamiAntReproMascu = txt_tipo1MetPlaniAntReproMascu.Text.ToUpper();
                inicial.inicial_vivosHijAntReproMascu = txt_vivosHijosAntReproMascu.Text.ToUpper();
                inicial.inicial_muertosHijAntReproMascu = txt_muertosHijosAntReproMascu.Text.ToUpper();
                inicial.inicial_tiempoExaRealiEcoProstatico = txt_tiempoExaRealiEcoProstaAntReproMascu.Text.ToUpper();
                inicial.inicial_resultadoExaRealiEcoProstatico = txt_resultadoExaRealiEcoProstaAntReproMascu.Text.ToUpper();
                inicial.inicial_tipo2MetPlanifiFamiAntReproMascu = txt_tipo2MetPlaniAntReproMascu.Text.ToUpper();

                inicial.inicial_tiempoConsuConsuNocivosTabaco = txt_tiemConConsuNociTabaHabToxi.Text.ToUpper();
                inicial.inicial_cantidadConsuNocivosTabaco = txt_cantiConsuNociTabaHabToxi.Text.ToUpper();
                inicial.inicial_exConsumiConsuNocivosTabaco = txt_exConsumiConsuNociTabaHabToxi.Text.ToUpper();
                inicial.inicial_tiempoAbstiConsuNocivosTabaco = txt_tiemAbstiConsuNociTabaHabToxi.Text.ToUpper();
                inicial.inicial_tiempoConsuConsuNocivosAlcohol = txt_tiemConConsuNociAlcoHabToxi.Text.ToUpper();
                inicial.inicial_cantidadConsuNocivosAlcohol = txt_cantiConsuNociAlcoHabToxi.Text.ToUpper();
                inicial.inicial_exConsumiConsuNocivosAlcohol = txt_exConsumiConsuNociAlcoHabToxi.Text.ToUpper();
                inicial.inicial_tiempoAbstiConsuNocivosAlcohol = txt_tiemAbstiConsuNociAlcoHabToxi.Text.ToUpper();
                inicial.inicial_tiempoConsu1ConsuNocivosOtrasDrogas = txt_tiemCon1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_cantidad1ConsuNocivosOtrasDrogas = txt_canti1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_exConsumi1ConsuNocivosOtrasDrogas = txt_exConsumi1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_tiempoAbsti1ConsuNocivosOtrasDrogas = txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_otrasConsuNocivos = txt_otrasConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_tiempoConsu2ConsuNocivosOtrasDrogas = txt_tiemCon2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_cantidad2ConsuNocivosOtrasDrogas = txt_canti2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_exConsumi2ConsuNocivosOtrasDrogas = txt_exConsumi2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_tiempoAbsti2ConsuNocivosOtrasDrogas = txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_cualEstiVidaActFisica = txt_cualEstVidaActFisiEstVida.Text.ToUpper();
                inicial.inicial_tiem_cantEstiVidaActFisica = txt_tiemCanEstVidaActFisiEstVida.Text.ToUpper();
                inicial.inicial_cual2EstiVidaMediHabitual = txt_cual1EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_tiem_cant2EstiVidaMediHabitual = txt_tiemCan1EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_cual3EstiVidaMediHabitual = txt_cual2EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_tiem_cant3EstiVidaMediHabitual = txt_tiemCan2EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_cual4EstiVidaMediHabitual = txt_cual3EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_tiem_cant4EstiVidaMediHabitual = txt_tiemCan3EstVidaMedHabiEstVida.Text.ToUpper();

                //D
                inicial.inicial_nomEmpresa = txt_empresa.Text.ToUpper();
                inicial.inicial_puestoTrabajo = txt_puestotrabajo.Text.ToUpper();
                inicial.inicial_actDesemp = txt_actdesempeña.Text.ToUpper();
                inicial.inicial_tiemTrabajo = txt_tiempotrabajo.Text.ToUpper();
                inicial.inicial_observacionesAnteEmpleAnteriores = txt_obseantempleanteriores.Text.ToUpper();
                inicial.inicial_nomEmpresa2 = txt_empresa2.Text.ToUpper();
                inicial.inicial_puestoTrabajo2 = txt_puestotrabajo2.Text.ToUpper();
                inicial.inicial_actDesemp2 = txt_actdesempeña2.Text.ToUpper();
                inicial.inicial_tiemTrabajo2 = txt_tiempotrabajo2.Text.ToUpper();
                inicial.inicial_observacionesAnteEmpleAnteriores2 = txt_obseantempleanteriores2.Text.ToUpper();
                inicial.inicial_nomEmpresa3 = txt_empresa3.Text.ToUpper();
                inicial.inicial_puestoTrabajo3 = txt_puestotrabajo3.Text.ToUpper();
                inicial.inicial_actDesemp3 = txt_actdesempeña3.Text.ToUpper();
                inicial.inicial_tiemTrabajo3 = txt_tiempotrabajo3.Text.ToUpper();
                inicial.inicial_observacionesAnteEmpleAnteriores3 = txt_obseantempleanteriores3.Text.ToUpper();
                inicial.inicial_nomEmpresa4 = txt_empresa4.Text.ToUpper();
                inicial.inicial_puestoTrabajo4 = txt_puestotrabajo4.Text.ToUpper();
                inicial.inicial_actDesemp4 = txt_actdesempeña4.Text.ToUpper();
                inicial.inicial_tiemTrabajo4 = txt_tiempotrabajo4.Text.ToUpper();
                inicial.inicial_observacionesAnteEmpleAnteriores4 = txt_obseantempleanteriores4.Text.ToUpper();

                inicial.inicial_especificarCalificadoIESSAcciTrabajo = txt_especificar.Text.ToUpper();
                inicial.inicial_fechaCalificadoIESSAcciTrabajo = txt_fecha.Text.ToUpper();
                inicial.inicial_obserAcciTrabajo = txt_observaciones2.Text.ToUpper();

                inicial.inicial_especificarCalificadoIESSEnfProfesionales = txt_espeprofesional.Text.ToUpper();
                inicial.inicial_fechaCalificadoIESSEnfProfesionales = txt_fechaprofesional.Text.ToUpper();
                inicial.inicial_obserEnfProfesionales = txt_observaciones3.Text.ToUpper();

                //E
                inicial.inicial_descripcionAnteFamiliares = txt_descripcionantefamiliares.Text.ToUpper();

                //F
                inicial.inicial_area = txt_puestodetrabajo.Text.ToUpper();
                inicial.inicial_actividades = txt_act.Text.ToUpper();
                inicial.inicial_area2 = txt_puestodetrabajo2.Text.ToUpper();
                inicial.inicial_actividades2 = txt_act2.Text.ToUpper();
                inicial.inicial_area3 = txt_puestodetrabajo3.Text.ToUpper();
                inicial.inicial_actividades3 = txt_act3.Text.ToUpper();
                inicial.inicial_area4 = txt_puestodetrabajo4.Text.ToUpper();
                inicial.inicial_actividades4 = txt_act4.Text.ToUpper();
                inicial.inicial_medPreventivas = txt_medpreventivas.Text.ToUpper();
                inicial.inicial_medPreventivas2 = txt_medpreventivas2.Text.ToUpper();
                inicial.inicial_medPreventivas3 = txt_medpreventivas3.Text.ToUpper();
                inicial.inicial_medPreventivas4 = txt_medpreventivas4.Text.ToUpper();

                //G
                inicial.inicial_descripActExtLab = txt_descrextralaborales.Text.ToUpper();

                //H
                inicial.inicial_descripEnfActual = txt_enfermedadactualinicial.Text.ToUpper();

                //I
                inicial.inicial_descripRevActOrgSis = txt_descrorganosysistemas.Text.ToUpper();

                //J
                inicial.inicial_preArterial = txt_preArterial.Text.ToUpper();
                inicial.inicial_temperatura = txt_temperatura.Text.ToUpper();
                inicial.inicial_frecCardiacan = txt_freCardica.Text.ToUpper();
                inicial.inicial_satOxigenon = txt_satOxigeno.Text.ToUpper();
                inicial.inicial_frecRespiratorian = txt_freRespiratoria.Text.ToUpper();
                inicial.inicial_peson = txt_peso.Text.ToUpper();
                inicial.inicial_tallan = txt_talla.Text.ToUpper();
                inicial.inicial_indMasCorporaln = txt_indMasCorporal.Text.ToUpper();
                inicial.inicial_perAbdominaln = txt_perAbdominal.Text.ToUpper();

                //K
                inicial.inicial_observaExaFisRegInicial = txt_obervexamenfisicoregional.Text.ToUpper();

                //L
                inicial.inicial_examen = txt_examen.Text.ToUpper();
                inicial.inicial_fecha = txt_fechaexamen.Text.ToUpper();
                inicial.inicial_resultados = txt_resultadoexamen.Text.ToUpper();
                inicial.inicial_examen2 = txt_examen2.Text.ToUpper();
                inicial.inicial_fecha2 = txt_fechaexamen2.Text.ToUpper();
                inicial.inicial_resultados2 = txt_resultadoexamen2.Text.ToUpper();
                inicial.inicial_examen3 = txt_examen3.Text.ToUpper();
                inicial.inicial_fecha3 = txt_fechaexamen3.Text.ToUpper();
                inicial.inicial_resultados3 = txt_resultadoexamen3.Text.ToUpper();
                inicial.inicial_examen4 = txt_examen4.Text.ToUpper();
                inicial.inicial_fecha4 = txt_fechaexamen4.Text.ToUpper();
                inicial.inicial_resultados4 = txt_resultadoexamen4.Text.ToUpper();
                inicial.inicial_observacionesResExaGenEspRiesTrabajo = txt_observacionexamen.Text.ToUpper();

                //M
                inicial.inicial_descripciondiagnostico = txt_descripdiagnostico.Text.ToUpper();
                inicial.inicial_cie = txt_cie.Text.ToUpper();
                inicial.inicial_descripcioninicialnostico2 = txt_descripdiagnostico2.Text.ToUpper();
                inicial.inicial_cie2 = txt_cie2.Text.ToUpper();
                inicial.inicial_descripcioninicialnostico3 = txt_descripdiagnostico3.Text.ToUpper();
                inicial.inicial_cie3 = txt_cie3.Text.ToUpper();

                //N
                inicial.inicial_ObservAptMed = txt_observacionaptitud.Text.ToUpper();
                inicial.inicial_LimitAptMed = txt_limitacionaptitud.Text.ToUpper();

                //O
                inicial.inicial_descripcionRecTra = txt_descripciontratamiento.Text.ToUpper();

                //P
                inicial.inicial_fechaHoraGuardado = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                inicial.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                inicial.inicial_cod = txt_codigoDatProf.Text.ToUpper();
                inicial.Per_id = perso;
                inicial.Emp_id = empre;

                CN_Inicial.GuardarInicial(inicial);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Guardados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Guardados', 'error')", true);
            }

        }

        private void ModificarInicial(Tbl_Inicial inicial)
        {
            try
            {
                if (ckb_catolica.Checked == true)
                {
                    inicial.inicial_catolicaRel = "SI";
                }
                else
                {
                    inicial.inicial_catolicaRel = null;
                }
                if (ckb_evangelica.Checked == true)
                {
                    inicial.inicial_evangelicaRel = "SI";
                }
                else
                {
                    inicial.inicial_evangelicaRel = null;
                }
                if (ckb_testigo.Checked == true)
                {
                    inicial.inicial_testJehovaRel = "SI";
                }
                else
                {
                    inicial.inicial_testJehovaRel = null;
                }
                if (ckb_mormona.Checked == true)
                {
                    inicial.inicial_mormonaRel = "SI";
                }
                else
                {
                    inicial.inicial_mormonaRel = null;
                }
                if (ckb_otrareligion.Checked == true)
                {
                    inicial.inicial_otrasRel = "SI";
                }
                else
                {
                    inicial.inicial_otrasRel = null;
                }
                if (cbk_gay.Checked == true)
                {
                    inicial.inicial_gayOriSex = "SI";
                }
                else
                {
                    inicial.inicial_gayOriSex = null;
                }
                if (cbk_lesbiana.Checked == true)
                {
                    inicial.inicial__lesbianaOriSex = "SI";
                }
                else
                {
                    inicial.inicial__lesbianaOriSex = null;
                }
                if (cbk_bisexual.Checked == true)
                {
                    inicial.inicial_bisexualOriSex = "SI";
                }
                else
                {
                    inicial.inicial_bisexualOriSex = null;
                }
                if (cbk_heterosexual.Checked == true)
                {
                    inicial.inicial_heterosexualOriSex = "SI";
                }
                else
                {
                    inicial.inicial_heterosexualOriSex = null;
                }
                if (cbk_noRespondeOriSex.Checked == true)
                {
                    inicial.inicial_norespondeOriSex = "SI";
                }
                else
                {
                    inicial.inicial_norespondeOriSex = null;
                }
                if (cbk_femenino.Checked == true)
                {
                    inicial.inicial_femeninoIdenGen = "SI";
                }
                else
                {
                    inicial.inicial_femeninoIdenGen = null;
                }
                if (cbk_masculino.Checked == true)
                {
                    inicial.inicial_masculinoIdenGen = "SI";
                }
                else
                {
                    inicial.inicial_masculinoIdenGen = null;
                }
                if (cbk_transfemenino.Checked == true)
                {
                    inicial.inicial_transFemeninoIdenGen = "SI";
                }
                else
                {
                    inicial.inicial_transFemeninoIdenGen = null;
                }
                if (cbk_transmasculino.Checked == true)
                {
                    inicial.inicial_transMasculinoIdenGen = "SI";
                }
                else
                {
                    inicial.inicial_transMasculinoIdenGen = null;
                }
                if (cbk_noRespondeIdeGen.Checked == true)
                {
                    inicial.inicial_norespondeIdenGen = "SI";
                }
                else
                {
                    inicial.inicial_norespondeIdenGen = null;
                }
                if (cbk_sidiscapacidad.Checked == true)
                {
                    inicial.inicial_siDis = "SI";
                }
                else
                {
                    inicial.inicial_siDis = null;
                }
                if (cbk_nodiscapacidad.Checked == true)
                {
                    inicial.inicial_noDis = "SI";
                }
                else
                {
                    inicial.inicial_noDis = null;
                }
                if (ckb_siVidSexAntGinObste.Checked == true)
                {
                    inicial.inicial_siVidaSexActiva = "SI";
                }
                else
                {
                    inicial.inicial_siVidaSexActiva = null;
                }
                if (ckb_noVidSexAntGinObste.Checked == true)
                {
                    inicial.inicial_noVidaSexActiva = "SI";
                }
                else
                {
                    inicial.inicial_noVidaSexActiva = null;
                }
                if (ckb_siMetPlaniAntGinObste.Checked == true)
                {
                    inicial.inicial_siMetPlanifiFamiliar = "SI";
                }
                else
                {
                    inicial.inicial_siMetPlanifiFamiliar = null;
                }
                if (ckb_noMetPlaniAntGinObste.Checked == true)
                {
                    inicial.inicial_noMetPlanifiFamiliar = "SI";
                }
                else
                {
                    inicial.inicial_noMetPlanifiFamiliar = null;
                }
                if (ckb_siPapaniAntGinObste.Checked == true)
                {
                    inicial.inicial_siExaRealiPapanicolaou = "SI";
                }
                else
                {
                    inicial.inicial_siExaRealiPapanicolaou = null;
                }
                if (ckb_noPapaniAntGinObste.Checked == true)
                {
                    inicial.inicial_noExaRealiPapanicolaou = "SI";
                }
                else
                {
                    inicial.inicial_noExaRealiPapanicolaou = null;
                }
                if (ckb_siEcoMamaAntGinObste.Checked == true)
                {
                    inicial.inicial_siExaRealiEcoMamario = "SI";
                }
                else
                {
                    inicial.inicial_siExaRealiEcoMamario = null;
                }
                if (ckb_noEcoMamaAntGinObste.Checked == true)
                {
                    inicial.inicial_noExaRealiEcoMamario = "SI";
                }
                else
                {
                    inicial.inicial_noExaRealiEcoMamario = null;
                }
                if (ckb_siColposAntGinObste.Checked == true)
                {
                    inicial.inicial_siExaRealiColposcopia = "SI";
                }
                else
                {
                    inicial.inicial_siExaRealiColposcopia = null;
                }
                if (ckb_noColposAntGinObste.Checked == true)
                {
                    inicial.inicial_noExaRealiColposcopia = "SI";
                }
                else
                {
                    inicial.inicial_noExaRealiColposcopia = null;
                }
                if (ckb_siMamograAntGinObste.Checked == true)
                {
                    inicial.inicial_siExaRealiMamografia = "SI";
                }
                else
                {
                    inicial.inicial_siExaRealiMamografia = null;
                }
                if (ckb_noMamograAntGinObste.Checked == true)
                {
                    inicial.inicial_noExaRealiMamografia = "SI";
                }
                else
                {
                    inicial.inicial_noExaRealiMamografia = null;
                }
                if (ckb_siExaRealiAntProstaAntReproMascu.Checked == true)
                {
                    inicial.inicial_siExaRealiAntiProstatico = "SI";
                }
                else
                {
                    inicial.inicial_siExaRealiAntiProstatico = null;
                }
                if (ckb_noExaRealiAntProstaAntReproMascu.Checked == true)
                {
                    inicial.inicial_noExaRealiAntiProstatico = "SI";
                }
                else
                {
                    inicial.inicial_noExaRealiAntiProstatico = null;
                }
                if (ckb_siMetPlaniAntReproMascu.Checked == true)
                {
                    inicial.inicial_siMetPlanifiFamiAntReproMascu = "SI";
                }
                else
                {
                    inicial.inicial_siMetPlanifiFamiAntReproMascu = null;
                }
                if (ckb_noMetPlaniAntReproMascu.Checked == true)
                {
                    inicial.inicial_noMetPlanifiFamiAntReproMascu = "SI";
                }
                else
                {
                    inicial.inicial_noMetPlanifiFamiAntReproMascu = null;
                }
                if (ckb_siExaRealiEcoProstaAntReproMascu.Checked == true)
                {
                    inicial.inicial_siExaRealiEcoProstatico = "SI";
                }
                else
                {
                    inicial.inicial_siExaRealiEcoProstatico = null;
                }
                if (ckb_noExaRealiEcoProstaAntReproMascu.Checked == true)
                {
                    inicial.inicial_noExaRealiEcoProstatico = "SI";
                }
                else
                {
                    inicial.inicial_noExaRealiEcoProstatico = null;
                }
                if (ckb_siConsuNociTabaHabToxi.Checked == true)
                {
                    inicial.inicial_siConsuNocivosTabaco = "SI";
                }
                else
                {
                    inicial.inicial_siConsuNocivosTabaco = null;
                }
                if (ckb_noConsuNociTabaHabToxi.Checked == true)
                {
                    inicial.inicial_noConsuNocivosTabaco = "SI";
                }
                else
                {
                    inicial.inicial_noConsuNocivosTabaco = null;
                }
                if (ckb_siConsuNociAlcoHabToxi.Checked == true)
                {
                    inicial.inicial_siConsuNocivosAlcohol = "SI";
                }
                else
                {
                    inicial.inicial_siConsuNocivosAlcohol = null;
                }
                if (ckb_noConsuNociAlcoHabToxi.Checked == true)
                {
                    inicial.inicial_noConsuNocivosAlcohol = "SI";
                }
                else
                {
                    inicial.inicial_noConsuNocivosAlcohol = null;
                }
                if (ckb_siConsuNociOtrasDroHabToxi.Checked == true)
                {
                    inicial.inicial_siConsuNocivosOtrasDrogas = "SI";
                }
                else
                {
                    inicial.inicial_siConsuNocivosOtrasDrogas = null;
                }
                if (ckb_noConsuNociOtrasDroHabToxi.Checked == true)
                {
                    inicial.inicial_noConsuNocivosOtrasDrogas = "SI";
                }
                else
                {
                    inicial.inicial_noConsuNocivosOtrasDrogas = null;
                }
                if (ckb_siEstVidaActFisiEstVida.Checked == true)
                {
                    inicial.inicial_siEstiVidaActFisica = "SI";
                }
                else
                {
                    inicial.inicial_siEstiVidaActFisica = null;
                }
                if (ckb_noEstVidaActFisiEstVida.Checked == true)
                {
                    inicial.inicial_noEstiVidaActFisica = "SI";
                }
                else
                {
                    inicial.inicial_noEstiVidaActFisica = null;
                }
                if (ckb_siEstVidaMedHabiEstVida.Checked == true)
                {
                    inicial.inicial_siEstiVidaMediHabitual = "SI";
                }
                else
                {
                    inicial.inicial_siEstiVidaMediHabitual = null;
                }
                if (ckb_noEstVidaMedHabiEstVida.Checked == true)
                {
                    inicial.inicial_noEstiVidaMediHabitual = "SI";
                }
                else
                {
                    inicial.inicial_noEstiVidaMediHabitual = null;
                }
                if (ckb_fisico.Checked == true)
                {
                    inicial.inicial_fisicoRies = "SI";
                }
                else
                {
                    inicial.inicial_fisicoRies = null;
                }
                if (ckb_mecanico.Checked == true)
                {
                    inicial.inicial_mecanicoRies = "SI";
                }
                else
                {
                    inicial.inicial_mecanicoRies = null;
                }
                if (ckb_quimico.Checked == true)
                {
                    inicial.inicial_quimicoRies = "SI";
                }
                else
                {
                    inicial.inicial_quimicoRies = null;
                }
                if (ckb_biologico.Checked == true)
                {
                    inicial.inicial_biologicoRies = "SI";
                }
                else
                {
                    inicial.inicial_biologicoRies = null;
                }
                if (ckb_ergonomico.Checked == true)
                {
                    inicial.inicial_ergonomicoRies = "SI";
                }
                else
                {
                    inicial.inicial_ergonomicoRies = null;
                }
                if (ckb_psicosocial.Checked == true)
                {
                    inicial.inicial_psicosocial = "SI";
                }
                else
                {
                    inicial.inicial_psicosocial = null;
                }
                if (ckb_fisico2.Checked == true)
                {
                    inicial.inicial_fisicoRies2 = "SI";
                }
                else
                {
                    inicial.inicial_fisicoRies2 = null;
                }
                if (ckb_mecanico2.Checked == true)
                {
                    inicial.inicial_mecanicoRies2 = "SI";
                }
                else
                {
                    inicial.inicial_mecanicoRies2 = null;
                }
                if (ckb_quimico2.Checked == true)
                {
                    inicial.inicial_quimicoRies2 = "SI";
                }
                else
                {
                    inicial.inicial_quimicoRies2 = null;
                }
                if (ckb_biologico2.Checked == true)
                {
                    inicial.inicial_biologicoRies2 = "SI";
                }
                else
                {
                    inicial.inicial_biologicoRies2 = null;
                }
                if (ckb_ergonomico2.Checked == true)
                {
                    inicial.inicial_ergonomicoRies2 = "SI";
                }
                else
                {
                    inicial.inicial_ergonomicoRies2 = null;
                }
                if (ckb_psicosocial2.Checked == true)
                {
                    inicial.inicial_psicosocial2 = "SI";
                }
                else
                {
                    inicial.inicial_psicosocial2 = null;
                }
                if (ckb_fisico3.Checked == true)
                {
                    inicial.inicial_fisicoRies3 = "SI";
                }
                else
                {
                    inicial.inicial_fisicoRies3 = null;
                }
                if (ckb_mecanico3.Checked == true)
                {
                    inicial.inicial_mecanicoRies3 = "SI";
                }
                else
                {
                    inicial.inicial_mecanicoRies3 = null;
                }
                if (ckb_quimico3.Checked == true)
                {
                    inicial.inicial_quimicoRies3 = "SI";
                }
                else
                {
                    inicial.inicial_quimicoRies3 = null;
                }
                if (ckb_biologico3.Checked == true)
                {
                    inicial.inicial_biologicoRies3 = "SI";
                }
                else
                {
                    inicial.inicial_biologicoRies3 = null;
                }
                if (ckb_ergonomico3.Checked == true)
                {
                    inicial.inicial_ergonomicoRies3 = "SI";
                }
                else
                {
                    inicial.inicial_ergonomicoRies3 = null;
                }
                if (ckb_psicosocial3.Checked == true)
                {
                    inicial.inicial_psicosocial3 = "SI";
                }
                else
                {
                    inicial.inicial_psicosocial3 = null;
                }
                if (ckb_fisico4.Checked == true)
                {
                    inicial.inicial_fisicoRies4 = "SI";
                }
                else
                {
                    inicial.inicial_fisicoRies4 = null;
                }
                if (ckb_mecanico4.Checked == true)
                {
                    inicial.inicial_mecanicoRies4 = "SI";
                }
                else
                {
                    inicial.inicial_mecanicoRies4 = null;
                }
                if (ckb_quimico4.Checked == true)
                {
                    inicial.inicial_quimicoRies4 = "SI";
                }
                else
                {
                    inicial.inicial_quimicoRies4 = null;
                }
                if (ckb_biologico4.Checked == true)
                {
                    inicial.inicial_biologicoRies4 = "SI";
                }
                else
                {
                    inicial.inicial_biologicoRies4 = null;
                }
                if (ckb_ergonomico4.Checked == true)
                {
                    inicial.inicial_ergonomicoRies4 = "SI";
                }
                else
                {
                    inicial.inicial_ergonomicoRies4 = null;
                }
                if (ckb_psicosocial4.Checked == true)
                {
                    inicial.inicial_psicosocial4 = "SI";
                }
                else
                {
                    inicial.inicial_psicosocial4 = null;
                }
                if (ckb_siAccTrabDescrip.Checked == true)
                {
                    inicial.inicial_siCalificadoIESSAcciTrabajo = "SI";
                }
                else
                {
                    inicial.inicial_siCalificadoIESSAcciTrabajo = null;
                }
                if (ckb_siprofesional.Checked == true)
                {
                    inicial.inicial_siCalificadoIESSEnfProfesionales = "SI";
                }
                else
                {
                    inicial.inicial_siCalificadoIESSEnfProfesionales = null;
                }
                if (ckb_noprofesional.Checked == true)
                {
                    inicial.inicial_noCalificadoIESSEnfProfesionales = "SI";
                }
                else
                {
                    inicial.inicial_noCalificadoIESSEnfProfesionales = null;
                }
                if (ckb_enfermedadcardiovascular.Checked == true)
                {
                    inicial.inicial_enfCarVasAnteFamiliares = "SI";
                }
                else
                {
                    inicial.inicial_enfCarVasAnteFamiliares = null;
                }
                if (ckb_enfermedadmetabolica.Checked == true)
                {
                    inicial.inicial_enfMetaAnteFamiliares = "SI";
                }
                else
                {
                    inicial.inicial_enfMetaAnteFamiliares = null;
                }
                if (ckb_enfermedadneurologica.Checked == true)
                {
                    inicial.inicial_enfNeuroAnteFamiliares = "SI";
                }
                else
                {
                    inicial.inicial_enfNeuroAnteFamiliares = null;
                }
                if (ckb_enfermedadoncologica.Checked == true)
                {
                    inicial.inicial_enfOncoAnteFamiliares = "SI";
                }
                else
                {
                    inicial.inicial_enfOncoAnteFamiliares = null;
                }
                if (ckb_enfermedadinfecciosa.Checked == true)
                {
                    inicial.inicial_enfInfeAnteFamiliares = "SI";
                }
                else
                {
                    inicial.inicial_enfInfeAnteFamiliares = null;
                }
                if (ckb_enfermedadhereditaria.Checked == true)
                {
                    inicial.inicial_enfHereCongeAnteFamiliares = "SI";
                }
                else
                {
                    inicial.inicial_enfHereCongeAnteFamiliares = null;
                }
                if (ckb_discapacidades.Checked == true)
                {
                    inicial.inicial_discapaAnteFamiliares = "SI";
                }
                else
                {
                    inicial.inicial_discapaAnteFamiliares = null;
                }
                if (ckb_otrosenfer.Checked == true)
                {
                    inicial.inicial_otrosAnteFamiliares = "SI";
                }
                else
                {
                    inicial.inicial_otrosAnteFamiliares = null;
                }
                if (ckb_tempaltas.Checked == true)
                {
                    inicial.inicial_temAltasFis = "SI";
                }
                else
                {
                    inicial.inicial_temAltasFis = null;
                }
                if (ckb_tempbajas.Checked == true)
                {
                    inicial.inicial_temBajasFis = "SI";
                }
                else
                {
                    inicial.inicial_temBajasFis = null;
                }
                if (ckb_radiacion.Checked == true)
                {
                    inicial.inicial_radIonizanteFis = "SI";
                }
                else
                {
                    inicial.inicial_radIonizanteFis = null;
                }
                if (ckb_noradiacion.Checked == true)
                {
                    inicial.inicial_radNoIonizanteFis = "SI";
                }
                else
                {
                    inicial.inicial_radNoIonizanteFis = null;
                }
                if (ckb_ruido.Checked == true)
                {
                    inicial.inicial_ruidoFis = "SI";
                }
                else
                {
                    inicial.inicial_ruidoFis = null;
                }
                if (ckb_vibracion.Checked == true)
                {
                    inicial.inicial_vibracionFis = "SI";
                }
                else
                {
                    inicial.inicial_vibracionFis = null;
                }
                if (ckb_iluminacion.Checked == true)
                {
                    inicial.inicial_iluminacionFis = "SI";
                }
                else
                {
                    inicial.inicial_iluminacionFis = null;
                }
                if (ckb_ventilacion.Checked == true)
                {
                    inicial.inicial_ventilacionFis = "SI";
                }
                else
                {
                    inicial.inicial_ventilacionFis = null;
                }
                if (ckb_fluidoelectrico.Checked == true)
                {
                    inicial.inicial_fluElectricoFis = "SI";
                }
                else
                {
                    inicial.inicial_fluElectricoFis = null;
                }
                if (ckb_otrosFisico.Checked == true)
                {
                    inicial.inicial_otrosFis = "SI";
                }
                else
                {
                    inicial.inicial_otrosFis = null;
                }
                if (ckb_tempaltas2.Checked == true)
                {
                    inicial.inicial_temAltasFis2 = "SI";
                }
                else
                {
                    inicial.inicial_temAltasFis2 = null;
                }
                if (ckb_tempbajas2.Checked == true)
                {
                    inicial.inicial_temBajasFis2 = "SI";
                }
                else
                {
                    inicial.inicial_temBajasFis2 = null;
                }
                if (ckb_radiacion2.Checked == true)
                {
                    inicial.inicial_radIonizanteFis2 = "SI";
                }
                else
                {
                    inicial.inicial_radIonizanteFis2 = null;
                }
                if (ckb_noradiacion2.Checked == true)
                {
                    inicial.inicial_radNoIonizanteFis2 = "SI";
                }
                else
                {
                    inicial.inicial_radNoIonizanteFis2 = null;
                }
                if (ckb_ruido2.Checked == true)
                {
                    inicial.inicial_ruidoFis2 = "SI";
                }
                else
                {
                    inicial.inicial_ruidoFis2 = null;
                }
                if (ckb_vibracion2.Checked == true)
                {
                    inicial.inicial_vibracionFis2 = "SI";
                }
                else
                {
                    inicial.inicial_vibracionFis2 = null;
                }
                if (ckb_iluminacion2.Checked == true)
                {
                    inicial.inicial_iluminacionFis2 = "SI";
                }
                else
                {
                    inicial.inicial_iluminacionFis2 = null;
                }
                if (ckb_ventilacion2.Checked == true)
                {
                    inicial.inicial_ventilacionFis2 = "SI";
                }
                else
                {
                    inicial.inicial_ventilacionFis2 = null;
                }
                if (ckb_fluidoelectrico2.Checked == true)
                {
                    inicial.inicial_fluElectricoFis2 = "SI";
                }
                else
                {
                    inicial.inicial_fluElectricoFis2 = null;
                }
                if (ckb_otrosFisico2.Checked == true)
                {
                    inicial.inicial_otrosFis2 = "SI";
                }
                else
                {
                    inicial.inicial_otrosFis2 = null;
                }
                if (ckb_tempaltas3.Checked == true)
                {
                    inicial.inicial_temAltasFis3 = "SI";
                }
                else
                {
                    inicial.inicial_temAltasFis3 = null;
                }
                if (ckb_tempbajas3.Checked == true)
                {
                    inicial.inicial_temBajasFis3 = "SI";
                }
                else
                {
                    inicial.inicial_temBajasFis3 = null;
                }
                if (ckb_radiacion3.Checked == true)
                {
                    inicial.inicial_radIonizanteFis3 = "SI";
                }
                else
                {
                    inicial.inicial_radIonizanteFis3 = null;
                }
                if (ckb_noradiacion3.Checked == true)
                {
                    inicial.inicial_radNoIonizanteFis3 = "SI";
                }
                else
                {
                    inicial.inicial_radNoIonizanteFis3 = null;
                }
                if (ckb_ruido3.Checked == true)
                {
                    inicial.inicial_ruidoFis3 = "SI";
                }
                else
                {
                    inicial.inicial_ruidoFis3 = null;
                }
                if (ckb_vibracion3.Checked == true)
                {
                    inicial.inicial_vibracionFis3 = "SI";
                }
                else
                {
                    inicial.inicial_vibracionFis3 = null;
                }
                if (ckb_iluminacion3.Checked == true)
                {
                    inicial.inicial_iluminacionFis3 = "SI";
                }
                else
                {
                    inicial.inicial_iluminacionFis3 = null;
                }
                if (ckb_ventilacion3.Checked == true)
                {
                    inicial.inicial_ventilacionFis3 = "SI";
                }
                else
                {
                    inicial.inicial_ventilacionFis3 = null;
                }
                if (ckb_fluidoelectrico3.Checked == true)
                {
                    inicial.inicial_fluElectricoFis3 = "SI";
                }
                else
                {
                    inicial.inicial_fluElectricoFis3 = null;
                }
                if (ckb_otrosFisico3.Checked == true)
                {
                    inicial.inicial_otrosFis3 = "SI";
                }
                else
                {
                    inicial.inicial_otrosFis3 = null;
                }
                if (ckb_tempaltas4.Checked == true)
                {
                    inicial.inicial_temAltasFis4 = "SI";
                }
                else
                {
                    inicial.inicial_temAltasFis4 = null;
                }
                if (ckb_tempbajas4.Checked == true)
                {
                    inicial.inicial_temBajasFis4 = "SI";
                }
                else
                {
                    inicial.inicial_temBajasFis4 = null;
                }
                if (ckb_radiacion4.Checked == true)
                {
                    inicial.inicial_radIonizanteFis4 = "SI";
                }
                else
                {
                    inicial.inicial_radIonizanteFis4 = null;
                }
                if (ckb_noradiacion4.Checked == true)
                {
                    inicial.inicial_radNoIonizanteFis4 = "SI";
                }
                else
                {
                    inicial.inicial_radNoIonizanteFis4 = null;
                }
                if (ckb_ruido4.Checked == true)
                {
                    inicial.inicial_ruidoFis4 = "SI";
                }
                else
                {
                    inicial.inicial_ruidoFis4 = null;
                }
                if (ckb_vibracion4.Checked == true)
                {
                    inicial.inicial_vibracionFis4 = "SI";
                }
                else
                {
                    inicial.inicial_vibracionFis4 = null;
                }
                if (ckb_iluminacion4.Checked == true)
                {
                    inicial.inicial_iluminacionFis4 = "SI";
                }
                else
                {
                    inicial.inicial_iluminacionFis4 = null;
                }
                if (ckb_ventilacion4.Checked == true)
                {
                    inicial.inicial_ventilacionFis4 = "SI";
                }
                else
                {
                    inicial.inicial_ventilacionFis4 = null;
                }
                if (ckb_fluidoelectrico4.Checked == true)
                {
                    inicial.inicial_fluElectricoFis4 = "SI";
                }
                else
                {
                    inicial.inicial_fluElectricoFis4 = null;
                }
                if (ckb_otrosFisico4.Checked == true)
                {
                    inicial.inicial_otrosFis4 = "SI";
                }
                else
                {
                    inicial.inicial_otrosFis4 = null;

                }
                if (ckb_atrapmaquinas.Checked == true)
                {
                    inicial.inicial_atraMaquinasMec = "SI";
                }
                else
                {
                    inicial.inicial_atraMaquinasMec = null;
                }
                if (ckb_atrapsuperficie.Checked == true)
                {
                    inicial.inicial_atraSuperfiiesMec = "SI";
                }
                else
                {
                    inicial.inicial_atraSuperfiiesMec = null;
                }
                if (ckb_atrapobjetos.Checked == true)
                {
                    inicial.inicial_atraObjetosMec = "SI";
                }
                else
                {
                    inicial.inicial_atraObjetosMec = null;
                }
                if (ckb_caidaobjetos.Checked == true)
                {
                    inicial.inicial_caidaObjetosMec = "SI";
                }
                else
                {
                    inicial.inicial_caidaObjetosMec = null;
                }
                if (ckb_caidamisnivel.Checked == true)
                {
                    inicial.inicial_caidaMisNivelMec = "SI";
                }
                else
                {
                    inicial.inicial_caidaMisNivelMec = null;
                }
                if (ckb_caidadifnivel.Checked == true)
                {
                    inicial.inicial_caidaDifNivelMec = "SI";
                }
                else
                {
                    inicial.inicial_caidaDifNivelMec = null;
                }
                if (ckb_contaelectrico.Checked == true)
                {
                    inicial.inicial_contactoElecMec = "SI";
                }
                else
                {
                    inicial.inicial_contactoElecMec = null;
                }
                if (ckb_contasuptrabajo.Checked == true)
                {
                    inicial.inicial_conSuperTrabaMec = "SI";
                }
                else
                {
                    inicial.inicial_conSuperTrabaMec = null;
                }
                if (ckb_proyparticulas.Checked == true)
                {
                    inicial.inicial_proPartiFragMec = "SI";
                }
                else
                {
                    inicial.inicial_proPartiFragMec = null;
                }
                if (ckb_proyefluidos.Checked == true)
                {
                    inicial.inicial_proFluidosMec = "SI";
                }
                else
                {
                    inicial.inicial_proFluidosMec = null;
                }
                if (ckb_pinchazos.Checked == true)
                {
                    inicial.inicial_pinchazosMec = "SI";
                }
                else
                {
                    inicial.inicial_pinchazosMec = null;
                }
                if (ckb_cortes.Checked == true)
                {
                    inicial.inicial_cortesMec = "SI";
                }
                else
                {
                    inicial.inicial_cortesMec = null;
                }
                if (ckb_atroporvehiculos.Checked == true)
                {
                    inicial.inicial_atropeVehiMec = "SI";
                }
                else
                {
                    inicial.inicial_atropeVehiMec = null;
                }
                if (ckb_choques.Checked == true)
                {
                    inicial.inicial_coliVehiMec = "SI";
                }
                else
                {
                    inicial.inicial_coliVehiMec = null;
                }
                if (ckb_otrosMecanico.Checked == true)
                {
                    inicial.inicial_otrosMec = "SI";
                }
                else
                {
                    inicial.inicial_otrosMec = null;
                }
                if (ckb_solidos.Checked == true)
                {
                    inicial.inicial_solidosQui = "SI";
                }
                else
                {
                    inicial.inicial_solidosQui = null;
                }
                if (ckb_polvos.Checked == true)
                {
                    inicial.inicial_polvosQui = "SI";
                }
                else
                {
                    inicial.inicial_polvosQui = null;
                }
                if (ckb_humos.Checked == true)
                {
                    inicial.inicial_humosQui = "SI";
                }
                else
                {
                    inicial.inicial_humosQui = null;
                }
                if (ckb_liquidos.Checked == true)
                {
                    inicial.inicial_liquidosQui = "SI";
                }
                else
                {
                    inicial.inicial_liquidosQui = null;
                }
                if (ckb_vapores.Checked == true)
                {
                    inicial.inicial_vaporesQui = "SI";
                }
                else
                {
                    inicial.inicial_vaporesQui = null;
                }
                if (ckb_aerosoles.Checked == true)
                {
                    inicial.inicial_aerosolesQui = "SI";
                }
                else
                {
                    inicial.inicial_aerosolesQui = null;
                }
                if (ckb_neblinas.Checked == true)
                {
                    inicial.inicial_neblinasQui = "SI";
                }
                else
                {
                    inicial.inicial_neblinasQui = null;
                }
                if (ckb_gaseosos.Checked == true)
                {
                    inicial.inicial_gaseososQui = "SI";
                }
                else
                {
                    inicial.inicial_gaseososQui = null;
                }
                if (ckb_otrosQuimico.Checked == true)
                {
                    inicial.inicial_otrosQui = "SI";
                }
                else
                {
                    inicial.inicial_otrosQui = null;
                }
                if (ckb_atrapmaquinas2.Checked == true)
                {
                    inicial.inicial_atraMaquinasMec2 = "SI";
                }
                else
                {
                    inicial.inicial_atraMaquinasMec2 = null;
                }
                if (ckb_atrapsuperficie2.Checked == true)
                {
                    inicial.inicial_atraSuperfiiesMec2 = "SI";
                }
                else
                {
                    inicial.inicial_atraSuperfiiesMec2 = null;
                }
                if (ckb_atrapobjetos2.Checked == true)
                {
                    inicial.inicial_atraObjetosMec2 = "SI";
                }
                else
                {
                    inicial.inicial_atraObjetosMec2 = null;
                }
                if (ckb_caidaobjetos2.Checked == true)
                {
                    inicial.inicial_caidaObjetosMec2 = "SI";
                }
                else
                {
                    inicial.inicial_caidaObjetosMec2 = null;
                }
                if (ckb_caidamisnivel2.Checked == true)
                {
                    inicial.inicial_caidaMisNivelMec2 = "SI";
                }
                else
                {
                    inicial.inicial_caidaMisNivelMec2 = null;

                }
                if (ckb_caidadifnivel2.Checked == true)
                {
                    inicial.inicial_caidaDifNivelMec2 = "SI";
                }
                else
                {
                    inicial.inicial_caidaDifNivelMec2 = null;
                }
                if (ckb_contaelectrico2.Checked == true)
                {
                    inicial.inicial_contactoElecMec2 = "SI";
                }
                else
                {
                    inicial.inicial_contactoElecMec2 = null;
                }
                if (ckb_contasuptrabajo2.Checked == true)
                {
                    inicial.inicial_conSuperTrabaMec2 = "SI";
                }
                else
                {
                    inicial.inicial_conSuperTrabaMec2 = null;
                }
                if (ckb_proyparticulas2.Checked == true)
                {
                    inicial.inicial_proPartiFragMec2 = "SI";
                }
                else
                {
                    inicial.inicial_proPartiFragMec2 = null;
                }
                if (ckb_proyefluidos2.Checked == true)
                {
                    inicial.inicial_proFluidosMec2 = "SI";
                }
                else
                {
                    inicial.inicial_proFluidosMec2 = null;
                }
                if (ckb_pinchazos2.Checked == true)
                {
                    inicial.inicial_pinchazosMec2 = "SI";
                }
                else
                {
                    inicial.inicial_pinchazosMec2 = null;
                }
                if (ckb_cortes2.Checked == true)
                {
                    inicial.inicial_cortesMec2 = "SI";
                }
                else
                {
                    inicial.inicial_cortesMec2 = null;
                }
                if (ckb_atroporvehiculos2.Checked == true)
                {
                    inicial.inicial_atropeVehiMec2 = "SI";
                }
                else
                {
                    inicial.inicial_atropeVehiMec2 = null;
                }
                if (ckb_choques2.Checked == true)
                {
                    inicial.inicial_coliVehiMec2 = "SI";
                }
                else
                {
                    inicial.inicial_coliVehiMec2 = null;
                }
                if (ckb_otrosMecanico2.Checked == true)
                {
                    inicial.inicial_otrosMec2 = "SI";
                }
                else
                {
                    inicial.inicial_otrosMec2 = null;
                }
                if (ckb_solidos2.Checked == true)
                {
                    inicial.inicial_solidosQui2 = "SI";
                }
                else
                {
                    inicial.inicial_solidosQui2 = null;
                }
                if (ckb_polvos2.Checked == true)
                {
                    inicial.inicial_polvosQui2 = "SI";
                }
                else
                {
                    inicial.inicial_polvosQui2 = null;
                }
                if (ckb_humos2.Checked == true)
                {
                    inicial.inicial_humosQui2 = "SI";
                }
                else
                {
                    inicial.inicial_humosQui2 = null;
                }
                if (ckb_liquidos2.Checked == true)
                {
                    inicial.inicial_liquidosQui2 = "SI";
                }
                else
                {
                    inicial.inicial_liquidosQui2 = null;
                }
                if (ckb_vapores2.Checked == true)
                {
                    inicial.inicial_vaporesQui2 = "SI";
                }
                else
                {
                    inicial.inicial_vaporesQui2 = null;
                }
                if (ckb_aerosoles2.Checked == true)
                {
                    inicial.inicial_aerosolesQui2 = "SI";
                }
                else
                {
                    inicial.inicial_aerosolesQui2 = null;
                }
                if (ckb_neblinas2.Checked == true)
                {
                    inicial.inicial_neblinasQui2 = "SI";
                }
                else
                {
                    inicial.inicial_neblinasQui2 = null;
                }
                if (ckb_gaseosos2.Checked == true)
                {
                    inicial.inicial_gaseososQui2 = "SI";
                }
                else
                {
                    inicial.inicial_gaseososQui2 = null;
                }
                if (ckb_otrosQuimico2.Checked == true)
                {
                    inicial.inicial_otrosQui2 = "SI";
                }
                else
                {
                    inicial.inicial_otrosQui2 = null;
                }
                if (ckb_atrapmaquinas3.Checked == true)
                {
                    inicial.inicial_atraMaquinasMec3 = "SI";
                }
                else
                {
                    inicial.inicial_atraMaquinasMec3 = null;
                }
                if (ckb_atrapsuperficie3.Checked == true)
                {
                    inicial.inicial_atraSuperfiiesMec3 = "SI";
                }
                else
                {
                    inicial.inicial_atraSuperfiiesMec3 = null;
                }
                if (ckb_atrapobjetos3.Checked == true)
                {
                    inicial.inicial_atraObjetosMec3 = "SI";
                }
                else
                {
                    inicial.inicial_atraObjetosMec3 = null;
                }
                if (ckb_caidaobjetos3.Checked == true)
                {
                    inicial.inicial_caidaObjetosMec3 = "SI";
                }
                else
                {
                    inicial.inicial_caidaObjetosMec3 = null;
                }
                if (ckb_caidamisnivel3.Checked == true)
                {
                    inicial.inicial_caidaMisNivelMec3 = "SI";
                }
                else
                {
                    inicial.inicial_caidaMisNivelMec3 = null;
                }
                if (ckb_caidadifnivel3.Checked == true)
                {
                    inicial.inicial_caidaDifNivelMec3 = "SI";
                }
                else
                {
                    inicial.inicial_caidaDifNivelMec3 = null;
                }
                if (ckb_contaelectrico3.Checked == true)
                {
                    inicial.inicial_contactoElecMec3 = "SI";
                }
                else
                {
                    inicial.inicial_contactoElecMec3 = null;
                }
                if (ckb_contasuptrabajo3.Checked == true)
                {
                    inicial.inicial_conSuperTrabaMec3 = "SI";
                }
                else
                {
                    inicial.inicial_conSuperTrabaMec3 = null;
                }
                if (ckb_proyparticulas3.Checked == true)
                {
                    inicial.inicial_proPartiFragMec3 = "SI";
                }
                else
                {
                    inicial.inicial_proPartiFragMec3 = null;
                }
                if (ckb_proyefluidos3.Checked == true)
                {
                    inicial.inicial_proFluidosMec3 = "SI";
                }
                else
                {
                    inicial.inicial_proFluidosMec3 = null;
                }
                if (ckb_pinchazos3.Checked == true)
                {
                    inicial.inicial_pinchazosMec3 = "SI";
                }
                else
                {
                    inicial.inicial_pinchazosMec3 = null;
                }
                if (ckb_cortes3.Checked == true)
                {
                    inicial.inicial_cortesMec3 = "SI";
                }
                else
                {
                    inicial.inicial_cortesMec3 = null;
                }
                if (ckb_atroporvehiculos3.Checked == true)
                {
                    inicial.inicial_atropeVehiMec3 = "SI";
                }
                else
                {
                    inicial.inicial_atropeVehiMec3 = null;
                }
                if (ckb_choques3.Checked == true)
                {
                    inicial.inicial_coliVehiMec3 = "SI";
                }
                else
                {
                    inicial.inicial_coliVehiMec3 = null;
                }
                if (ckb_otrosMecanico3.Checked == true)
                {
                    inicial.inicial_otrosMec3 = "SI";
                }
                else
                {
                    inicial.inicial_otrosMec3 = null;
                }
                if (ckb_solidos3.Checked == true)
                {
                    inicial.inicial_solidosQui3 = "SI";
                }
                else
                {
                    inicial.inicial_solidosQui3 = null;
                }
                if (ckb_polvos3.Checked == true)
                {
                    inicial.inicial_polvosQui3 = "SI";
                }
                else
                {
                    inicial.inicial_polvosQui3 = null;
                }
                if (ckb_humos3.Checked == true)
                {
                    inicial.inicial_humosQui3 = "SI";
                }
                else
                {
                    inicial.inicial_humosQui3 = null;
                }
                if (ckb_liquidos3.Checked == true)
                {
                    inicial.inicial_liquidosQui3 = "SI";
                }
                else
                {
                    inicial.inicial_liquidosQui3 = null;
                }
                if (ckb_vapores3.Checked == true)
                {
                    inicial.inicial_vaporesQui3 = "SI";
                }
                else
                {
                    inicial.inicial_vaporesQui3 = null;
                }
                if (ckb_aerosoles3.Checked == true)
                {
                    inicial.inicial_aerosolesQui3 = "SI";
                }
                else
                {
                    inicial.inicial_aerosolesQui3 = null;
                }
                if (ckb_neblinas3.Checked == true)
                {
                    inicial.inicial_neblinasQui3 = "SI";
                }
                else
                {
                    inicial.inicial_neblinasQui3 = null;
                }
                if (ckb_gaseosos3.Checked == true)
                {
                    inicial.inicial_gaseososQui3 = "SI";
                }
                else
                {
                    inicial.inicial_gaseososQui3 = null;
                }
                if (ckb_otrosQuimico3.Checked == true)
                {
                    inicial.inicial_otrosQui3 = "SI";
                }
                else
                {
                    inicial.inicial_otrosQui3 = null;
                }
                if (ckb_atrapmaquinas4.Checked == true)
                {
                    inicial.inicial_atraMaquinasMec4 = "SI";
                }
                else
                {
                    inicial.inicial_atraMaquinasMec4 = null;
                }
                if (ckb_atrapsuperficie4.Checked == true)
                {
                    inicial.inicial_atraSuperfiiesMec4 = "SI";
                }
                else
                {
                    inicial.inicial_atraSuperfiiesMec4 = null;
                }
                if (ckb_atrapobjetos4.Checked == true)
                {
                    inicial.inicial_atraObjetosMec4 = "SI";
                }
                else
                {
                    inicial.inicial_atraObjetosMec4 = null;
                }
                if (ckb_caidaobjetos4.Checked == true)
                {
                    inicial.inicial_caidaObjetosMec4 = "SI";
                }
                else
                {
                    inicial.inicial_caidaObjetosMec4 = null;
                }
                if (ckb_caidamisnivel4.Checked == true)
                {
                    inicial.inicial_caidaMisNivelMec4 = "SI";
                }
                else
                {
                    inicial.inicial_caidaMisNivelMec4 = null;
                }
                if (ckb_caidadifnivel4.Checked == true)
                {
                    inicial.inicial_caidaDifNivelMec4 = "SI";
                }
                else
                {
                    inicial.inicial_caidaDifNivelMec4 = null;
                }
                if (ckb_contaelectrico4.Checked == true)
                {
                    inicial.inicial_contactoElecMec4 = "SI";
                }
                else
                {
                    inicial.inicial_contactoElecMec4 = null;
                }
                if (ckb_contasuptrabajo4.Checked == true)
                {
                    inicial.inicial_conSuperTrabaMec4 = "SI";
                }
                else
                {
                    inicial.inicial_conSuperTrabaMec4 = null;
                }
                if (ckb_proyparticulas4.Checked == true)
                {
                    inicial.inicial_proPartiFragMec4 = "SI";
                }
                else
                {
                    inicial.inicial_proPartiFragMec4 = null;
                }
                if (ckb_proyefluidos4.Checked == true)
                {
                    inicial.inicial_proFluidosMec4 = "SI";
                }
                else
                {
                    inicial.inicial_proFluidosMec4 = null;
                }
                if (ckb_pinchazos4.Checked == true)
                {
                    inicial.inicial_pinchazosMec4 = "SI";
                }
                else
                {
                    inicial.inicial_pinchazosMec4 = null;
                }
                if (ckb_cortes4.Checked == true)
                {
                    inicial.inicial_cortesMec4 = "SI";
                }
                else
                {
                    inicial.inicial_cortesMec4 = null;
                }
                if (ckb_atroporvehiculos4.Checked == true)
                {
                    inicial.inicial_atropeVehiMec4 = "SI";
                }
                else
                {
                    inicial.inicial_atropeVehiMec4 = null;
                }
                if (ckb_choques4.Checked == true)
                {
                    inicial.inicial_coliVehiMec4 = "SI";
                }
                else
                {
                    inicial.inicial_coliVehiMec4 = null;
                }
                if (ckb_otrosMecanico4.Checked == true)
                {
                    inicial.inicial_otrosMec4 = "SI";
                }
                else
                {
                    inicial.inicial_otrosMec4 = null;
                }
                if (ckb_solidos4.Checked == true)
                {
                    inicial.inicial_solidosQui4 = "SI";
                }
                else
                {
                    inicial.inicial_solidosQui4 = null;
                }
                if (ckb_polvos4.Checked == true)
                {
                    inicial.inicial_polvosQui4 = "SI";
                }
                else
                {
                    inicial.inicial_polvosQui4 = null;
                }
                if (ckb_humos4.Checked == true)
                {
                    inicial.inicial_humosQui4 = "SI";
                }
                else
                {
                    inicial.inicial_humosQui4 = null;
                }
                if (ckb_liquidos4.Checked == true)
                {
                    inicial.inicial_liquidosQui4 = "SI";
                }
                else
                {
                    inicial.inicial_liquidosQui4 = null;
                }
                if (ckb_vapores4.Checked == true)
                {
                    inicial.inicial_vaporesQui4 = "SI";
                }
                else
                {
                    inicial.inicial_vaporesQui4 = null;
                }
                if (ckb_aerosoles4.Checked == true)
                {
                    inicial.inicial_aerosolesQui4 = "SI";
                }
                else
                {
                    inicial.inicial_aerosolesQui4 = null;
                }
                if (ckb_neblinas4.Checked == true)
                {
                    inicial.inicial_neblinasQui4 = "SI";
                }
                else
                {
                    inicial.inicial_neblinasQui4 = null;
                }
                if (ckb_gaseosos4.Checked == true)
                {
                    inicial.inicial_gaseososQui4 = "SI";
                }
                else
                {
                    inicial.inicial_gaseososQui4 = null;
                }
                if (ckb_otrosQuimico4.Checked == true)
                {
                    inicial.inicial_otrosQui4 = "SI";
                }
                else
                {
                    inicial.inicial_otrosQui4 = null;
                }
                if (ckb_virus.Checked == true)
                {
                    inicial.inicial_virusBio = "SI";
                }
                else
                {
                    inicial.inicial_virusBio = null;
                }
                if (ckb_hongos.Checked == true)
                {
                    inicial.inicial_hongosBio = "SI";
                }
                else
                {
                    inicial.inicial_hongosBio = null;
                }
                if (ckb_bacterias.Checked == true)
                {
                    inicial.inicial_bacteriasBio = "SI";
                }
                else
                {
                    inicial.inicial_bacteriasBio = null;
                }
                if (ckb_parasitos.Checked == true)
                {
                    inicial.inicial_parasitosBio = "SI";
                }
                else
                {
                    inicial.inicial_parasitosBio = null;
                }
                if (ckb_expoavectores.Checked == true)
                {
                    inicial.inicial_expVectBio = "SI";
                }
                else
                {
                    inicial.inicial_expVectBio = null;
                }
                if (ckb_expoanimselvaticos.Checked == true)
                {
                    inicial.inicial_expAniSelvaBio = "SI";
                }
                else
                {
                    inicial.inicial_expAniSelvaBio = null;
                }
                if (ckb_otrosBiologico.Checked == true)
                {
                    inicial.inicial_otrosBio = "SI";
                }
                else
                {
                    inicial.inicial_otrosBio = null;
                }
                if (ckb_manmanualcargas.Checked == true)
                {
                    inicial.inicial_maneManCarErg = "SI";
                }
                else
                {
                    inicial.inicial_maneManCarErg = null;
                }
                if (ckb_movrepetitivo.Checked == true)
                {
                    inicial.inicial_movRepeErg = "SI";
                }
                else
                {
                    inicial.inicial_movRepeErg = null;
                }
                if (ckb_postforzadas.Checked == true)
                {
                    inicial.inicial_posForzaErg = "SI";
                }
                else
                {
                    inicial.inicial_posForzaErg = null;
                }
                if (ckb_trabajopvd.Checked == true)
                {
                    inicial.inicial_trabPvdErg = "SI";
                }
                else
                {
                    inicial.inicial_trabPvdErg = null;
                }
                if (ckb_otrosErgonomico.Checked == true)
                {
                    inicial.inicial_otrosErg = "SI";
                }
                else
                {
                    inicial.inicial_otrosErg = null;
                }
                if (ckb_virus2.Checked == true)
                {
                    inicial.inicial_virusBio2 = "SI";
                }
                else
                {
                    inicial.inicial_virusBio2 = null;
                }
                if (ckb_hongos2.Checked == true)
                {
                    inicial.inicial_hongosBio2 = "SI";
                }
                else
                {
                    inicial.inicial_hongosBio2 = null;
                }
                if (ckb_bacterias2.Checked == true)
                {
                    inicial.inicial_bacteriasBio2 = "SI";
                }
                else
                {
                    inicial.inicial_bacteriasBio2 = null;
                }
                if (ckb_parasitos2.Checked == true)
                {
                    inicial.inicial_parasitosBio2 = "SI";
                }
                else
                {
                    inicial.inicial_parasitosBio2 = null;
                }
                if (ckb_expoavectores2.Checked == true)
                {
                    inicial.inicial_expVectBio2 = "SI";
                }
                else
                {
                    inicial.inicial_expVectBio2 = null;
                }
                if (ckb_expoanimselvaticos2.Checked == true)
                {
                    inicial.inicial_expAniSelvaBio2 = "SI";
                }
                else
                {
                    inicial.inicial_expAniSelvaBio2 = null;
                }
                if (ckb_otrosBiologico2.Checked == true)
                {
                    inicial.inicial_otrosBio2 = "SI";
                }
                else
                {
                    inicial.inicial_otrosBio2 = null;
                }
                if (ckb_manmanualcargas2.Checked == true)
                {
                    inicial.inicial_maneManCarErg2 = "SI";
                }
                else
                {
                    inicial.inicial_maneManCarErg2 = null;
                }
                if (ckb_movrepetitivo2.Checked == true)
                {
                    inicial.inicial_movRepeErg2 = "SI";
                }
                else
                {
                    inicial.inicial_movRepeErg2 = null;
                }
                if (ckb_postforzadas2.Checked == true)
                {
                    inicial.inicial_posForzaErg2 = "SI";
                }
                else
                {
                    inicial.inicial_posForzaErg2 = null;
                }
                if (ckb_trabajopvd2.Checked == true)
                {
                    inicial.inicial_trabPvdErg2 = "SI";
                }
                else
                {
                    inicial.inicial_trabPvdErg2 = null;
                }
                if (ckb_otrosErgonomico2.Checked == true)
                {
                    inicial.inicial_otrosErg2 = "SI";
                }
                else
                {
                    inicial.inicial_otrosErg2 = null;
                }
                if (ckb_virus3.Checked == true)
                {
                    inicial.inicial_virusBio3 = "SI";
                }
                else
                {
                    inicial.inicial_virusBio3 = null;
                }
                if (ckb_hongos3.Checked == true)
                {
                    inicial.inicial_hongosBio3 = "SI";
                }
                else
                {
                    inicial.inicial_hongosBio3 = null;
                }
                if (ckb_bacterias3.Checked == true)
                {
                    inicial.inicial_bacteriasBio3 = "SI";
                }
                else
                {
                    inicial.inicial_bacteriasBio3 = null;
                }
                if (ckb_parasitos3.Checked == true)
                {
                    inicial.inicial_parasitosBio3 = "SI";
                }
                else
                {
                    inicial.inicial_parasitosBio3 = null;
                }
                if (ckb_expoavectores3.Checked == true)
                {
                    inicial.inicial_expVectBio3 = "SI";
                }
                else
                {
                    inicial.inicial_expVectBio3 = null;
                }
                if (ckb_expoanimselvaticos3.Checked == true)
                {
                    inicial.inicial_expAniSelvaBio3 = "SI";
                }
                else
                {
                    inicial.inicial_expAniSelvaBio3 = null;
                }
                if (ckb_otrosBiologico3.Checked == true)
                {
                    inicial.inicial_otrosBio3 = "SI";
                }
                else
                {
                    inicial.inicial_otrosBio3 = null;
                }
                if (ckb_manmanualcargas3.Checked == true)
                {
                    inicial.inicial_maneManCarErg3 = "SI";
                }
                else
                {
                    inicial.inicial_maneManCarErg3 = null;
                }
                if (ckb_movrepetitivo3.Checked == true)
                {
                    inicial.inicial_movRepeErg3 = "SI";
                }
                else
                {
                    inicial.inicial_movRepeErg3 = null;
                }
                if (ckb_postforzadas3.Checked == true)
                {
                    inicial.inicial_posForzaErg3 = "SI";
                }
                else
                {
                    inicial.inicial_posForzaErg3 = null;
                }
                if (ckb_trabajopvd3.Checked == true)
                {
                    inicial.inicial_trabPvdErg3 = "SI";
                }
                else
                {
                    inicial.inicial_trabPvdErg3 = null;
                }
                if (ckb_otrosErgonomico3.Checked == true)
                {
                    inicial.inicial_otrosErg3 = "SI";
                }
                else
                {
                    inicial.inicial_otrosErg3 = null;
                }
                if (ckb_virus4.Checked == true)
                {
                    inicial.inicial_virusBio4 = "SI";
                }
                else
                {
                    inicial.inicial_virusBio4 = null;
                }
                if (ckb_hongos4.Checked == true)
                {
                    inicial.inicial_hongosBio4 = "SI";
                }
                else
                {
                    inicial.inicial_hongosBio4 = null;
                }
                if (ckb_bacterias4.Checked == true)
                {
                    inicial.inicial_bacteriasBio4 = "SI";
                }
                else
                {
                    inicial.inicial_bacteriasBio4 = null;
                }
                if (ckb_parasitos4.Checked == true)
                {
                    inicial.inicial_parasitosBio4 = "SI";
                }
                else
                {
                    inicial.inicial_parasitosBio4 = null;
                }
                if (ckb_expoavectores4.Checked == true)
                {
                    inicial.inicial_expVectBio4 = "SI";
                }
                else
                {
                    inicial.inicial_expVectBio4 = null;
                }
                if (ckb_expoanimselvaticos4.Checked == true)
                {
                    inicial.inicial_expAniSelvaBio4 = "SI";
                }
                else
                {
                    inicial.inicial_expAniSelvaBio4 = null;
                }
                if (ckb_otrosBiologico4.Checked == true)
                {
                    inicial.inicial_otrosBio4 = "SI";
                }
                else
                {
                    inicial.inicial_otrosBio4 = null;
                }
                if (ckb_manmanualcargas4.Checked == true)
                {
                    inicial.inicial_maneManCarErg4 = "SI";
                }
                else
                {
                    inicial.inicial_maneManCarErg4 = null;
                }
                if (ckb_movrepetitivo4.Checked == true)
                {
                    inicial.inicial_movRepeErg4 = "SI";
                }
                else
                {
                    inicial.inicial_movRepeErg4 = null;
                }
                if (ckb_postforzadas4.Checked == true)
                {
                    inicial.inicial_posForzaErg4 = "SI";
                }
                else
                {
                    inicial.inicial_posForzaErg4 = null;
                }
                if (ckb_trabajopvd4.Checked == true)
                {
                    inicial.inicial_trabPvdErg4 = "SI";
                }
                else
                {
                    inicial.inicial_trabPvdErg4 = null;
                }
                if (ckb_otrosErgonomico4.Checked == true)
                {
                    inicial.inicial_otrosErg4 = "SI";
                }
                else
                {
                    inicial.inicial_otrosErg4 = null;
                }
                if (ckb_montrabajo.Checked == true)
                {
                    inicial.inicial_monoTrabPsi = "SI";
                }
                else
                {
                    inicial.inicial_monoTrabPsi = null;
                }
                if (ckb_sobrecargalaboral.Checked == true)
                {
                    inicial.inicial_sobrecarLabPsi = "SI";
                }
                else
                {
                    inicial.inicial_sobrecarLabPsi = null;
                }
                if (ckb_minustarea.Checked == true)
                {
                    inicial.inicial_minuTareaPsi = "SI";
                }
                else
                {
                    inicial.inicial_minuTareaPsi = null;
                }
                if (ckb_altarespon.Checked == true)
                {
                    inicial.inicial_altaResponPsi = "SI";
                }
                else
                {
                    inicial.inicial_altaResponPsi = null;
                }
                if (ckb_automadesiciones.Checked == true)
                {
                    inicial.inicial_autoTomaDesiPsi = "SI";
                }
                else
                {
                    inicial.inicial_autoTomaDesiPsi = null;
                }
                if (ckb_supyestdireficiente.Checked == true)
                {
                    inicial.inicial_supEstDirecDefiPsi = "SI";
                }
                else
                {
                    inicial.inicial_supEstDirecDefiPsi = null;
                }
                if (ckb_conflictorol.Checked == true)
                {
                    inicial.inicial_conflicRolPsi = "SI";
                }
                else
                {
                    inicial.inicial_conflicRolPsi = null;
                }
                if (ckb_faltaclarfunciones.Checked == true)
                {
                    inicial.inicial_falClariFunPsi = "SI";
                }
                else
                {
                    inicial.inicial_falClariFunPsi = null;
                }
                if (ckb_incorrdistrabajo.Checked == true)
                {
                    inicial.inicial_incoDistriTrabPsi = "SI";
                }
                else
                {
                    inicial.inicial_incoDistriTrabPsi = null;
                }
                if (ckb_turnorotat.Checked == true)
                {
                    inicial.inicial_turnosRotaPsi = "SI";
                }
                else
                {
                    inicial.inicial_turnosRotaPsi = null;
                }
                if (ckb_relacinterpersonales.Checked == true)
                {
                    inicial.inicial_relInterperPsi = "SI";
                }
                else
                {
                    inicial.inicial_relInterperPsi = null;
                }
                if (ckb_inestalaboral.Checked == true)
                {
                    inicial.inicial_inesLabPsi = "SI";
                }
                else
                {
                    inicial.inicial_inesLabPsi = null;
                }
                if (ckb_otrosPsicosocial.Checked == true)
                {
                    inicial.inicial_otrosPsi = "SI";
                }
                else
                {
                    inicial.inicial_otrosPsi = null;
                }
                if (ckb_montrabajo2.Checked == true)
                {
                    inicial.inicial_monoTrabPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_monoTrabPsi2 = null;
                }
                if (ckb_sobrecargalaboral2.Checked == true)
                {
                    inicial.inicial_sobrecarLabPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_sobrecarLabPsi2 = null;
                }
                if (ckb_minustarea2.Checked == true)
                {
                    inicial.inicial_minuTareaPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_minuTareaPsi2 = null;
                }
                if (ckb_altarespon2.Checked == true)
                {
                    inicial.inicial_altaResponPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_altaResponPsi2 = null;
                }
                if (ckb_automadesiciones2.Checked == true)
                {
                    inicial.inicial_autoTomaDesiPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_autoTomaDesiPsi2 = null;
                }
                if (ckb_supyestdireficiente2.Checked == true)
                {
                    inicial.inicial_supEstDirecDefiPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_supEstDirecDefiPsi2 = null;
                }
                if (ckb_conflictorol2.Checked == true)
                {
                    inicial.inicial_conflicRolPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_conflicRolPsi2 = null;
                }
                if (ckb_faltaclarfunciones2.Checked == true)
                {
                    inicial.inicial_falClariFunPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_falClariFunPsi2 = null;
                }
                if (ckb_incorrdistrabajo2.Checked == true)
                {
                    inicial.inicial_incoDistriTrabPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_incoDistriTrabPsi2 = null;
                }
                if (ckb_turnorotat2.Checked == true)
                {
                    inicial.inicial_turnosRotaPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_turnosRotaPsi2 = null;
                }
                if (ckb_relacinterpersonales2.Checked == true)
                {
                    inicial.inicial_relInterperPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_relInterperPsi2 = null;
                }
                if (ckb_inestalaboral2.Checked == true)
                {
                    inicial.inicial_inesLabPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_inesLabPsi2 = null;
                }
                if (ckb_otrosPsicosocial2.Checked == true)
                {
                    inicial.inicial_otrosPsi2 = "SI";
                }
                else
                {
                    inicial.inicial_otrosPsi2 = null;
                }
                if (ckb_montrabajo3.Checked == true)
                {
                    inicial.inicial_monoTrabPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_monoTrabPsi3 = null;
                }
                if (ckb_sobrecargalaboral3.Checked == true)
                {
                    inicial.inicial_sobrecarLabPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_sobrecarLabPsi3 = null;
                }
                if (ckb_minustarea3.Checked == true)
                {
                    inicial.inicial_minuTareaPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_minuTareaPsi3 = null;
                }
                if (ckb_altarespon3.Checked == true)
                {
                    inicial.inicial_altaResponPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_altaResponPsi3 = null;
                }
                if (ckb_automadesiciones3.Checked == true)
                {
                    inicial.inicial_autoTomaDesiPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_autoTomaDesiPsi3 = null;
                }
                if (ckb_supyestdireficiente3.Checked == true)
                {
                    inicial.inicial_supEstDirecDefiPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_supEstDirecDefiPsi3 = null;
                }
                if (ckb_conflictorol3.Checked == true)
                {
                    inicial.inicial_conflicRolPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_conflicRolPsi3 = null;
                }
                if (ckb_faltaclarfunciones3.Checked == true)
                {
                    inicial.inicial_falClariFunPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_falClariFunPsi3 = null;
                }
                if (ckb_incorrdistrabajo3.Checked == true)
                {
                    inicial.inicial_incoDistriTrabPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_incoDistriTrabPsi3 = null;
                }
                if (ckb_turnorotat3.Checked == true)
                {
                    inicial.inicial_turnosRotaPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_turnosRotaPsi3 = null;
                }
                if (ckb_relacinterpersonales3.Checked == true)
                {
                    inicial.inicial_relInterperPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_relInterperPsi3 = null;
                }
                if (ckb_inestalaboral3.Checked == true)
                {
                    inicial.inicial_inesLabPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_inesLabPsi3 = null;
                }
                if (ckb_otrosPsicosocial3.Checked == true)
                {
                    inicial.inicial_otrosPsi3 = "SI";
                }
                else
                {
                    inicial.inicial_otrosPsi3 = null;
                }
                if (ckb_montrabajo4.Checked == true)
                {
                    inicial.inicial_monoTrabPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_monoTrabPsi4 = null;
                }
                if (ckb_sobrecargalaboral4.Checked == true)
                {
                    inicial.inicial_sobrecarLabPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_sobrecarLabPsi4 = null;
                }
                if (ckb_minustarea4.Checked == true)
                {
                    inicial.inicial_minuTareaPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_minuTareaPsi4 = null;
                }
                if (ckb_altarespon4.Checked == true)
                {
                    inicial.inicial_altaResponPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_altaResponPsi4 = null;
                }
                if (ckb_automadesiciones4.Checked == true)
                {
                    inicial.inicial_autoTomaDesiPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_autoTomaDesiPsi4 = null;
                }
                if (ckb_supyestdireficiente4.Checked == true)
                {
                    inicial.inicial_supEstDirecDefiPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_supEstDirecDefiPsi4 = null;
                }
                if (ckb_conflictorol4.Checked == true)
                {
                    inicial.inicial_conflicRolPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_conflicRolPsi4 = null;
                }
                if (ckb_faltaclarfunciones4.Checked == true)
                {
                    inicial.inicial_falClariFunPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_falClariFunPsi4 = null;
                }
                if (ckb_incorrdistrabajo4.Checked == true)
                {
                    inicial.inicial_incoDistriTrabPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_incoDistriTrabPsi4 = null;
                }
                if (ckb_turnorotat4.Checked == true)
                {
                    inicial.inicial_turnosRotaPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_turnosRotaPsi4 = null;
                }
                if (ckb_relacinterpersonales4.Checked == true)
                {
                    inicial.inicial_relInterperPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_relInterperPsi4 = null;
                }
                if (ckb_inestalaboral4.Checked == true)
                {
                    inicial.inicial_inesLabPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_inesLabPsi4 = null;
                }
                if (ckb_otrosPsicosocial4.Checked == true)
                {
                    inicial.inicial_otrosPsi4 = "SI";
                }
                else
                {
                    inicial.inicial_otrosPsi4 = null;
                }
                if (ckb_pielanexos.Checked == true)
                {
                    inicial.inicial_pielAnexos = "SI";
                }
                else
                {
                    inicial.inicial_pielAnexos = null;
                }
                if (ckb_respiratorio.Checked == true)
                {
                    inicial.inicial_respiratorio = "SI";
                }
                else
                {
                    inicial.inicial_respiratorio = null;
                }
                if (ckb_digestivo.Checked == true)
                {
                    inicial.inicial_digestivo = "SI";
                }
                else
                {
                    inicial.inicial_digestivo = null;
                }
                if (ckb_musculosesqueleticos.Checked == true)
                {
                    inicial.inicial_muscEsqueletico = "SI";
                }
                else
                {
                    inicial.inicial_muscEsqueletico = null;
                }
                if (ckb_hemolinfatico.Checked == true)
                {
                    inicial.inicial_hemoLimfa = "SI";
                }
                else
                {
                    inicial.inicial_hemoLimfa = null;
                }
                if (ckb_organossentidos.Checked == true)
                {
                    inicial.inicial_orgSentidos = "SI";
                }
                else
                {
                    inicial.inicial_orgSentidos = null;
                }
                if (ckb_cardiovascular.Checked == true)
                {
                    inicial.inicial_cardVascular = "SI";
                }
                else
                {
                    inicial.inicial_cardVascular = null;
                }
                if (ckb_genitourinario.Checked == true)
                {
                    inicial.inicial_genUrinario = "SI";
                }
                else
                {
                    inicial.inicial_genUrinario = null;
                }
                if (ckb_endocrino.Checked == true)
                {
                    inicial.inicial_endocrino = "SI";
                }
                else
                {
                    inicial.inicial_endocrino = null;
                }
                if (ckb_nervioso.Checked == true)
                {
                    inicial.inicial_nervioso = "SI";
                }
                else
                {
                    inicial.inicial_nervioso = null;
                }
                if (ckb_cicatrices.Checked == true)
                {
                    inicial.inicial_cicatricesPiel = "SI";
                }
                else
                {
                    inicial.inicial_cicatricesPiel = null;
                }
                if (ckb_auditivoexterno.Checked == true)
                {
                    inicial.inicial_cAudiExtreOido = "SI";
                }
                else
                {
                    inicial.inicial_cAudiExtreOido = null;
                }
                if (ckb_tabique.Checked == true)
                {
                    inicial.inicial_tabiqueNariz = "SI";
                }
                else
                {
                    inicial.inicial_tabiqueNariz = null;
                }
                if (ckb_pulmones.Checked == true)
                {
                    inicial.inicial_pulmonesTorax2 = "SI";
                }
                else
                {
                    inicial.inicial_pulmonesTorax2 = null;
                }
                if (ckb_pelvis.Checked == true)
                {
                    inicial.inicial_pelvisPelvis = "SI";
                }
                else
                {
                    inicial.inicial_pelvisPelvis = null;
                }
                if (ckb_tatuajes.Checked == true)
                {
                    inicial.inicial_tatuajesPiel = "SI";
                }
                else
                {
                    inicial.inicial_tatuajesPiel = null;
                }
                if (ckb_pabellon.Checked == true)
                {
                    inicial.inicial_pabellonOido = "SI";
                }
                else
                {
                    inicial.inicial_pabellonOido = null;
                }
                if (ckb_cornetes.Checked == true)
                {
                    inicial.inicial_cornetesNariz = "SI";
                }
                else
                {
                    inicial.inicial_cornetesNariz = null;
                }
                if (ckb_parrillacostal.Checked == true)
                {
                    inicial.inicial_parriCostalTorax2 = "SI";
                }
                else
                {
                    inicial.inicial_parriCostalTorax2 = null;
                }
                if (ckb_genitales.Checked == true)
                {
                    inicial.inicial_genitalesPelvis = "SI";
                }
                else
                {
                    inicial.inicial_genitalesPelvis = null;
                }
                if (ckb_pielyfaneras.Checked == true)
                {
                    inicial.inicial_pielFacerasPiel = "SI";
                }
                else
                {
                    inicial.inicial_pielFacerasPiel = null;
                }
                if (ckb_timpanos.Checked == true)
                {
                    inicial.inicial_timpanosOido = "SI";
                }
                else
                {
                    inicial.inicial_timpanosOido = null;
                }
                if (ckb_mucosa.Checked == true)
                {
                    inicial.inicial_mucosasNariz = "SI";
                }
                else
                {
                    inicial.inicial_mucosasNariz = null;
                }
                if (ckb_visceras.Checked == true)
                {
                    inicial.inicial_viscerasAbdomen = "SI";
                }
                else
                {
                    inicial.inicial_viscerasAbdomen = null;
                }
                if (ckb_vascular.Checked == true)
                {
                    inicial.inicial_vascularExtre = "SI";
                }
                else
                {
                    inicial.inicial_vascularExtre = null;
                }
                if (ckb_parpados.Checked == true)
                {
                    inicial.inicial_parpadosOjos = "SI";
                }
                else
                {
                    inicial.inicial_parpadosOjos = null;
                }
                if (ckb_labios.Checked == true)
                {
                    inicial.inicial_labiosOroFa = "SI";
                }
                else
                {
                    inicial.inicial_labiosOroFa = null;
                }
                if (ckb_senosparanasales.Checked == true)
                {
                    inicial.inicial_senosParanaNariz = "SI";
                }
                else
                {
                    inicial.inicial_senosParanaNariz = null;
                }
                if (ckb_paredabdominal.Checked == true)
                {
                    inicial.inicial_paredAbdomiAbdomen = "SI";
                }
                else
                {
                    inicial.inicial_paredAbdomiAbdomen = null;
                }
                if (ckb_miembrosuperiores.Checked == true)
                {
                    inicial.inicial_miemSupeExtre = "SI";
                }
                else
                {
                    inicial.inicial_miemSupeExtre = null;
                }
                if (ckb_conjuntivas.Checked == true)
                {
                    inicial.inicial_conjuntuvasOjos = "SI";
                }
                else
                {
                    inicial.inicial_conjuntuvasOjos = null;
                }
                if (ckb_lengua.Checked == true)
                {
                    inicial.inicial_lenguaOroFa = "SI";
                }
                else
                {
                    inicial.inicial_lenguaOroFa = null;
                }
                if (ckb_tiroides.Checked == true)
                {
                    inicial.inicial_tiroiMasasCuello = "SI";
                }
                else
                {
                    inicial.inicial_tiroiMasasCuello = null;
                }
                if (ckb_flexibilidad.Checked == true)
                {
                    inicial.inicial_flexibilidadColumna = "SI";
                }
                else
                {
                    inicial.inicial_flexibilidadColumna = null;
                }
                if (ckb_miembrosinferiores.Checked == true)
                {
                    inicial.inicial_miemInfeExtre = "SI";
                }
                else
                {
                    inicial.inicial_miemInfeExtre = null;
                }
                if (ckb_pupilas.Checked == true)
                {
                    inicial.inicial_pupilasOjos = "SI";
                }
                else
                {
                    inicial.inicial_pupilasOjos = null;
                }
                if (ckb_faringe.Checked == true)
                {
                    inicial.inicial_faringeOroFa = "SI";
                }
                else
                {
                    inicial.inicial_faringeOroFa = null;
                }
                if (ckb_movilidad.Checked == true)
                {
                    inicial.inicial_movilidadCuello = "SI";
                }
                else
                {
                    inicial.inicial_movilidadCuello = null;
                }
                if (ckb_desviacion.Checked == true)
                {
                    inicial.inicial_desviacionColumna = "SI";
                }
                else
                {
                    inicial.inicial_desviacionColumna = null;
                }
                if (ckb_fuerza.Checked == true)
                {
                    inicial.inicial_fuerzaNeuro = "SI";
                }
                else
                {
                    inicial.inicial_fuerzaNeuro = null;
                }
                if (ckb_cornea.Checked == true)
                {
                    inicial.inicial_corneaOjos = "SI";
                }
                else
                {
                    inicial.inicial_corneaOjos = null;
                }
                if (ckb_amigdalas.Checked == true)
                {
                    inicial.inicial_amigdalasOroFa = "SI";
                }
                else
                {
                    inicial.inicial_amigdalasOroFa = null;
                }
                if (ckb_mamas.Checked == true)
                {
                    inicial.inicial_mamasTorax = "SI";
                }
                else
                {
                    inicial.inicial_mamasTorax = null;
                }
                if (ckb_sensibilidad.Checked == true)
                {
                    inicial.inicial_sensibiNeuro = "SI";
                }
                else
                {
                    inicial.inicial_sensibiNeuro = null;
                }
                if (ckb_motilidad.Checked == true)
                {
                    inicial.inicial_motilidadOjos = "SI";
                }
                else
                {
                    inicial.inicial_motilidadOjos = null;
                }
                if (ckb_dentadura.Checked == true)
                {
                    inicial.inicial_dentaduraOroFa = "SI";
                }
                else
                {
                    inicial.inicial_dentaduraOroFa = null;
                }
                if (ckb_corazon.Checked == true)
                {
                    inicial.inicial_corazonTorax = "SI";
                }
                else
                {
                    inicial.inicial_corazonTorax = null;
                }
                if (ckb_dolor.Checked == true)
                {
                    inicial.inicial_dolorColumna = "SI";
                }
                else
                {
                    inicial.inicial_dolorColumna = null;
                }
                if (ckb_marcha.Checked == true)
                {
                    inicial.inicial_marchaNeuro = "SI";
                }
                else
                {
                    inicial.inicial_marchaNeuro = null;
                }
                if (ckb_reflejos.Checked == true)
                {
                    inicial.inicial_refleNeuro = "SI";
                }
                else
                {
                    inicial.inicial_refleNeuro = null;
                }
                if (ckb_pre.Checked == true)
                {
                    inicial.inicial_pre = "SI";
                }
                else
                {
                    inicial.inicial_pre = null;
                }
                if (ckb_def.Checked == true)
                {
                    inicial.inicial_def = "SI";
                }
                else
                {
                    inicial.inicial_def = null;
                }
                if (ckb_pre2.Checked == true)
                {
                    inicial.inicial_pre2 = "SI";
                }
                else
                {
                    inicial.inicial_pre2 = null;
                }
                if (ckb_def2.Checked == true)
                {
                    inicial.inicial_def2 = "SI";
                }
                else
                {
                    inicial.inicial_def2 = null;
                }
                if (ckb_pre3.Checked == true)
                {
                    inicial.inicial_pre3 = "SI";
                }
                else
                {
                    inicial.inicial_pre3 = null;
                }
                if (ckb_def3.Checked == true)
                {
                    inicial.inicial_def3 = "SI";
                }
                else
                {
                    inicial.inicial_def3 = null;
                }
                if (ckb_apto.Checked == true)
                {
                    inicial.inicial_apto = "SI";
                }
                else
                {
                    inicial.inicial_apto = null;
                }
                if (ckb_aptoobservacion.Checked == true)
                {
                    inicial.inicial_aptoObserva = "SI";
                }
                else
                {
                    inicial.inicial_aptoObserva = null;
                }
                if (ckb_aptolimitacion.Checked == true)
                {
                    inicial.inicial_NoApto = "SI";
                }
                else
                {
                    inicial.inicial_NoApto = null;
                }
                if (ckb_noapto.Checked == true)
                {
                    inicial.inicial_NoApto = "SI";
                }
                else
                {
                    inicial.inicial_NoApto = null;
                }

                //A
                inicial.inicial_ciiu = txt_ciiu.Text.ToUpper();
                inicial.inicial_numArchivo = txt_numArchivo.Text.ToUpper();
                inicial.inicial_groSanguineo = txt_gruposanguineo.Text.ToUpper();
                inicial.inicial_lateralidad = txt_lateralidad.Text.ToUpper();
                inicial.inicial_tipoDis = txt_tipodiscapacidad.Text.ToUpper();
                inicial.inicial_porcentDis = txt_porcentajediscapacidad.Text.ToUpper();
                inicial.inicial_actRelePuesTrabajo = txt_actividadesrelevantes.Text.ToUpper();

                //B
                inicial.inicial_descripcionMotivoConsulta = txt_motivoconsultainicial.Text.ToUpper();

                //C
                inicial.inicial_descripcionAnteceCliniQuirur = txt_antCliQuiDescripcion.Text.ToUpper();

                inicial.inicial_menarquia = txt_menarquiaAntGinObste.Text.ToUpper();
                inicial.inicial_ciclos = txt_ciclosAntGinObste.Text.ToUpper();
                inicial.inicial_fechUltiMenstrua = txt_fechUltiMensAntGinObste.Text.ToUpper();
                inicial.inicial_gestas = txt_gestasAntGinObste.Text.ToUpper();
                inicial.inicial_partos = txt_partosAntGinObste.Text.ToUpper();
                inicial.inicial_cesareas = txt_cesareasAntGinObste.Text.ToUpper();
                inicial.inicial_abortos = txt_abortosAntGinObste.Text.ToUpper();
                inicial.inicial_vivosHij = txt_vivosAntGinObste.Text.ToUpper();
                inicial.inicial_muertosHij = txt_muertosAntGinObste.Text.ToUpper();
                inicial.inicial_tipoMetPlanifiFamiliar = txt_tipoMetPlaniAntGinObste.Text.ToUpper();

                inicial.inicial_tiempoExaRealiPapanicolaou = txt_tiempoPapaniAntGinObste.Text.ToUpper();
                inicial.inicial_resultadoExaRealiPapanicolaou = txt_resultadoPapaniAntGinObste.Text.ToUpper();
                inicial.inicial_tiempoExaRealiEcoMamario = txt_tiempoEcoMamaAntGinObste.Text.ToUpper();
                inicial.inicial_resultadoExaRealiEcoMamario = txt_resultadoEcoMamaAntGinObste.Text.ToUpper();
                inicial.inicial_tiempoExaRealiColposcopia = txt_tiempoColposAntGinObste.Text.ToUpper();
                inicial.inicial_resultadoExaRealiColposcopia = txt_resultadoColposAntGinObste.Text.ToUpper();
                inicial.inicial_tiempoExaRealiMamografia = txt_tiempoMamograAntGinObste.Text.ToUpper();
                inicial.inicial_resultadoExaRealiMamografia = txt_resultadoMamograAntGinObste.Text.ToUpper();

                inicial.inicial_tiempoExaRealiAntiProstatico = txt_tiempoExaRealiAntProstaAntReproMascu.Text.ToUpper();
                inicial.inicial_resultadoExaRealiAntiProstatico = txt_resultadoExaRealiAntProstaAntReproMascu.Text.ToUpper();
                inicial.inicial_tipo1MetPlanifiFamiAntReproMascu = txt_tipo1MetPlaniAntReproMascu.Text.ToUpper();
                inicial.inicial_vivosHijAntReproMascu = txt_vivosHijosAntReproMascu.Text.ToUpper();
                inicial.inicial_muertosHijAntReproMascu = txt_muertosHijosAntReproMascu.Text.ToUpper();
                inicial.inicial_tiempoExaRealiEcoProstatico = txt_tiempoExaRealiEcoProstaAntReproMascu.Text.ToUpper();
                inicial.inicial_resultadoExaRealiEcoProstatico = txt_resultadoExaRealiEcoProstaAntReproMascu.Text.ToUpper();
                inicial.inicial_tipo2MetPlanifiFamiAntReproMascu = txt_tipo2MetPlaniAntReproMascu.Text.ToUpper();

                inicial.inicial_tiempoConsuConsuNocivosTabaco = txt_tiemConConsuNociTabaHabToxi.Text.ToUpper();
                inicial.inicial_cantidadConsuNocivosTabaco = txt_cantiConsuNociTabaHabToxi.Text.ToUpper();
                inicial.inicial_exConsumiConsuNocivosTabaco = txt_exConsumiConsuNociTabaHabToxi.Text.ToUpper();
                inicial.inicial_tiempoAbstiConsuNocivosTabaco = txt_tiemAbstiConsuNociTabaHabToxi.Text.ToUpper();
                inicial.inicial_tiempoConsuConsuNocivosAlcohol = txt_tiemConConsuNociAlcoHabToxi.Text.ToUpper();
                inicial.inicial_cantidadConsuNocivosAlcohol = txt_cantiConsuNociAlcoHabToxi.Text.ToUpper();
                inicial.inicial_exConsumiConsuNocivosAlcohol = txt_exConsumiConsuNociAlcoHabToxi.Text.ToUpper();
                inicial.inicial_tiempoAbstiConsuNocivosAlcohol = txt_tiemAbstiConsuNociAlcoHabToxi.Text.ToUpper();
                inicial.inicial_tiempoConsu1ConsuNocivosOtrasDrogas = txt_tiemCon1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_cantidad1ConsuNocivosOtrasDrogas = txt_canti1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_exConsumi1ConsuNocivosOtrasDrogas = txt_exConsumi1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_tiempoAbsti1ConsuNocivosOtrasDrogas = txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_otrasConsuNocivos = txt_otrasConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_tiempoConsu2ConsuNocivosOtrasDrogas = txt_tiemCon2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_cantidad2ConsuNocivosOtrasDrogas = txt_canti2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_exConsumi2ConsuNocivosOtrasDrogas = txt_exConsumi2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_tiempoAbsti2ConsuNocivosOtrasDrogas = txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                inicial.inicial_cualEstiVidaActFisica = txt_cualEstVidaActFisiEstVida.Text.ToUpper();
                inicial.inicial_tiem_cantEstiVidaActFisica = txt_tiemCanEstVidaActFisiEstVida.Text.ToUpper();
                inicial.inicial_cual2EstiVidaMediHabitual = txt_cual1EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_tiem_cant2EstiVidaMediHabitual = txt_tiemCan1EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_cual3EstiVidaMediHabitual = txt_cual2EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_tiem_cant3EstiVidaMediHabitual = txt_tiemCan2EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_cual4EstiVidaMediHabitual = txt_cual3EstVidaMedHabiEstVida.Text.ToUpper();
                inicial.inicial_tiem_cant4EstiVidaMediHabitual = txt_tiemCan3EstVidaMedHabiEstVida.Text.ToUpper();

                //D
                inicial.inicial_nomEmpresa = txt_empresa.Text.ToUpper();
                inicial.inicial_puestoTrabajo = txt_puestotrabajo.Text.ToUpper();
                inicial.inicial_actDesemp = txt_actdesempeña.Text.ToUpper();
                inicial.inicial_tiemTrabajo = txt_tiempotrabajo.Text.ToUpper();
                inicial.inicial_observacionesAnteEmpleAnteriores = txt_obseantempleanteriores.Text.ToUpper();
                inicial.inicial_nomEmpresa2 = txt_empresa2.Text.ToUpper();
                inicial.inicial_puestoTrabajo2 = txt_puestotrabajo2.Text.ToUpper();
                inicial.inicial_actDesemp2 = txt_actdesempeña2.Text.ToUpper();
                inicial.inicial_tiemTrabajo2 = txt_tiempotrabajo2.Text.ToUpper();
                inicial.inicial_observacionesAnteEmpleAnteriores2 = txt_obseantempleanteriores2.Text.ToUpper();
                inicial.inicial_nomEmpresa3 = txt_empresa3.Text.ToUpper();
                inicial.inicial_puestoTrabajo3 = txt_puestotrabajo3.Text.ToUpper();
                inicial.inicial_actDesemp3 = txt_actdesempeña3.Text.ToUpper();
                inicial.inicial_tiemTrabajo3 = txt_tiempotrabajo3.Text.ToUpper();
                inicial.inicial_observacionesAnteEmpleAnteriores3 = txt_obseantempleanteriores3.Text.ToUpper();
                inicial.inicial_nomEmpresa4 = txt_empresa4.Text.ToUpper();
                inicial.inicial_puestoTrabajo4 = txt_puestotrabajo4.Text.ToUpper();
                inicial.inicial_actDesemp4 = txt_actdesempeña4.Text.ToUpper();
                inicial.inicial_tiemTrabajo4 = txt_tiempotrabajo4.Text.ToUpper();
                inicial.inicial_observacionesAnteEmpleAnteriores4 = txt_obseantempleanteriores4.Text.ToUpper();

                inicial.inicial_especificarCalificadoIESSAcciTrabajo = txt_especificar.Text.ToUpper();
                inicial.inicial_fechaCalificadoIESSAcciTrabajo = txt_fecha.Text.ToUpper();
                inicial.inicial_obserAcciTrabajo = txt_observaciones2.Text.ToUpper();

                inicial.inicial_especificarCalificadoIESSEnfProfesionales = txt_espeprofesional.Text.ToUpper();
                inicial.inicial_fechaCalificadoIESSEnfProfesionales = txt_fechaprofesional.Text.ToUpper();
                inicial.inicial_obserEnfProfesionales = txt_observaciones3.Text.ToUpper();

                //E
                inicial.inicial_descripcionAnteFamiliares = txt_descripcionantefamiliares.Text.ToUpper();

                //F
                inicial.inicial_area = txt_puestodetrabajo.Text.ToUpper();
                inicial.inicial_actividades = txt_act.Text.ToUpper();
                inicial.inicial_area2 = txt_puestodetrabajo2.Text.ToUpper();
                inicial.inicial_actividades2 = txt_act2.Text.ToUpper();
                inicial.inicial_area3 = txt_puestodetrabajo3.Text.ToUpper();
                inicial.inicial_actividades3 = txt_act3.Text.ToUpper();
                inicial.inicial_area4 = txt_puestodetrabajo4.Text.ToUpper();
                inicial.inicial_actividades4 = txt_act4.Text.ToUpper();
                inicial.inicial_medPreventivas = txt_medpreventivas.Text.ToUpper();
                inicial.inicial_medPreventivas2 = txt_medpreventivas2.Text.ToUpper();
                inicial.inicial_medPreventivas3 = txt_medpreventivas3.Text.ToUpper();
                inicial.inicial_medPreventivas4 = txt_medpreventivas4.Text.ToUpper();

                //G
                inicial.inicial_descripActExtLab = txt_descrextralaborales.Text.ToUpper();

                //H
                inicial.inicial_descripEnfActual = txt_enfermedadactualinicial.Text.ToUpper();

                //I
                inicial.inicial_descripRevActOrgSis = txt_descrorganosysistemas.Text.ToUpper();

                //J
                inicial.inicial_preArterial = txt_preArterial.Text.ToUpper();
                inicial.inicial_temperatura = txt_temperatura.Text.ToUpper();
                inicial.inicial_frecCardiacan = txt_freCardica.Text.ToUpper();
                inicial.inicial_satOxigenon = txt_satOxigeno.Text.ToUpper();
                inicial.inicial_frecRespiratorian = txt_freRespiratoria.Text.ToUpper();
                inicial.inicial_peson = txt_peso.Text.ToUpper();
                inicial.inicial_tallan = txt_talla.Text.ToUpper();
                inicial.inicial_indMasCorporaln = txt_indMasCorporal.Text.ToUpper();
                inicial.inicial_perAbdominaln = txt_perAbdominal.Text.ToUpper();

                //K
                inicial.inicial_observaExaFisRegInicial = txt_obervexamenfisicoregional.Text.ToUpper();

                //L
                inicial.inicial_examen = txt_examen.Text.ToUpper();
                inicial.inicial_fecha = txt_fechaexamen.Text.ToUpper();
                inicial.inicial_resultados = txt_resultadoexamen.Text.ToUpper();
                inicial.inicial_examen2 = txt_examen2.Text.ToUpper();
                inicial.inicial_fecha2 = txt_fechaexamen2.Text.ToUpper();
                inicial.inicial_resultados2 = txt_resultadoexamen2.Text.ToUpper();
                inicial.inicial_examen3 = txt_examen3.Text.ToUpper();
                inicial.inicial_fecha3 = txt_fechaexamen3.Text.ToUpper();
                inicial.inicial_resultados3 = txt_resultadoexamen3.Text.ToUpper();
                inicial.inicial_examen4 = txt_examen4.Text.ToUpper();
                inicial.inicial_fecha4 = txt_fechaexamen4.Text.ToUpper();
                inicial.inicial_resultados4 = txt_resultadoexamen4.Text.ToUpper();
                inicial.inicial_observacionesResExaGenEspRiesTrabajo = txt_observacionexamen.Text.ToUpper();

                //M
                inicial.inicial_descripciondiagnostico = txt_descripdiagnostico.Text.ToUpper();
                inicial.inicial_cie = txt_cie.Text.ToUpper();
                inicial.inicial_descripcioninicialnostico2 = txt_descripdiagnostico2.Text.ToUpper();
                inicial.inicial_cie2 = txt_cie2.Text.ToUpper();
                inicial.inicial_descripcioninicialnostico3 = txt_descripdiagnostico3.Text.ToUpper();
                inicial.inicial_cie3 = txt_cie3.Text.ToUpper();

                //N
                inicial.inicial_ObservAptMed = txt_observacionaptitud.Text.ToUpper();
                inicial.inicial_LimitAptMed = txt_limitacionaptitud.Text.ToUpper();

                //O
                inicial.inicial_descripcionRecTra = txt_descripciontratamiento.Text.ToUpper();

                //P
                inicial.inicial_fecha_horaModificacion = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                inicial.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                inicial.inicial_cod = txt_codigoDatProf.Text.ToUpper();

                CN_Inicial.ModificarInicial(inicial);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }

        }

        private void Guardar_modificar_datos(int ini)
        {
            if (ini == 0)
            {
                GuardarHistorial();
            }
            else
            {
                inicial = CN_Inicial.ObtenerInicialPorId(ini);
                if (inicial != null)
                {
                    ModificarInicial(inicial);
                }
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            bool camposCompletos = true;

            if (string.IsNullOrEmpty(txt_numHClinica.Text))
            {
                lbl_numHClinica.Text = "CAMPO OBLIGATORIO";
                camposCompletos = false;
            }
            else
            {
                lbl_numHClinica.Text = "";
            }

            if (string.IsNullOrEmpty(ddl_profesional.SelectedValue) || ddl_profesional.SelectedValue == "0")
            {
                lbl_profesional.Text = "CAMPO OBLIGATORIO";
                camposCompletos = false;
            }
            else
            {
                lbl_profesional.Text = "";
            }

            if (camposCompletos)
            {
                // Todos los campos están completos, continuar con el procesamiento
                Guardar_modificar_datos(Convert.ToInt32(Request["cod"]));
            }
            else
            {
                // Al menos uno de los campos está incompleto, enfocar el primer campo vacío
                if (string.IsNullOrEmpty(txt_numHClinica.Text))
                {
                    txt_numHClinica.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "ScrollToField", "window.scrollTo(0, document.getElementById('" + txt_numHClinica.ClientID + "').offsetTop);", true);
                }
                else if (string.IsNullOrEmpty(ddl_profesional.SelectedValue) || ddl_profesional.SelectedValue == "0")
                {
                    ddl_profesional.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "ScrollToField", "window.scrollTo(0, document.getElementById('" + ddl_profesional.ClientID + "').offsetTop);", true);
                }
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Administrador_Medico/Inicio.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Administrador_Medico/Inicio.aspx");
        }

        private void cargarProfesional()
        {
            List<Tbl_Profesional> listaProf = new List<Tbl_Profesional>();
            listaProf = CN_HistorialMedico.ObtenerProfesional();
            listaProf.Insert(0, new Tbl_Profesional() { prof_NomApe = "Seleccione ........" });

            ddl_profesional.DataSource = listaProf;
            ddl_profesional.DataTextField = "prof_NomApe";
            ddl_profesional.DataValueField = "prof_id";
            ddl_profesional.DataBind();
        }

        protected void txt_talla_TextChanged(object sender, EventArgs e)
        {
            if (txt_talla.Text != "")
            {
                txt_peso.Enabled = true;
            }
        }

        protected void txt_peso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int peso = Convert.ToInt32(txt_peso.Text);
                decimal talla = Convert.ToDecimal(txt_talla.Text);
                decimal toTalla = (talla * talla) / 10000;
                decimal calculo = peso / toTalla;
                calculo = decimal.Round(calculo, 2, MidpointRounding.AwayFromZero);

                txt_indMasCorporal.Text = calculo.ToString();

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Llenar primero la talla')", true);
                txt_peso.Text = "";
                txt_talla.Focus();
            }
        }

        private void defaultValidaciones()
        {
            txt_tipodiscapacidad.Enabled = false;
            txt_porcentajediscapacidad.Enabled = false;
            txt_tipoMetPlaniAntGinObste.Enabled = false;
            txt_tiempoPapaniAntGinObste.Enabled = false;
            txt_resultadoPapaniAntGinObste.Enabled = false;
            txt_tiempoEcoMamaAntGinObste.Enabled = false;
            txt_resultadoEcoMamaAntGinObste.Enabled = false;
            txt_tiempoColposAntGinObste.Enabled = false;
            txt_resultadoColposAntGinObste.Enabled = false;
            txt_tiempoMamograAntGinObste.Enabled = false;
            txt_resultadoMamograAntGinObste.Enabled = false;
            txt_tiempoExaRealiAntProstaAntReproMascu.Enabled = false;
            txt_resultadoExaRealiAntProstaAntReproMascu.Enabled = false;
            txt_tipo1MetPlaniAntReproMascu.Enabled = false;
            txt_tipo2MetPlaniAntReproMascu.Enabled = false;
            txt_tiempoExaRealiEcoProstaAntReproMascu.Enabled = false;
            txt_resultadoExaRealiEcoProstaAntReproMascu.Enabled = false;
            txt_tiemConConsuNociTabaHabToxi.Enabled = false;
            txt_cantiConsuNociTabaHabToxi.Enabled = false;
            txt_exConsumiConsuNociTabaHabToxi.Enabled = false;
            txt_tiemAbstiConsuNociTabaHabToxi.Enabled = false;
            txt_tiemConConsuNociAlcoHabToxi.Enabled = false;
            txt_cantiConsuNociAlcoHabToxi.Enabled = false;
            txt_exConsumiConsuNociAlcoHabToxi.Enabled = false;
            txt_tiemAbstiConsuNociAlcoHabToxi.Enabled = false;
            txt_tiemCon1ConsuNociOtrasDroHabToxi.Enabled = false;
            txt_canti1ConsuNociOtrasDroHabToxi.Enabled = false;
            txt_exConsumi1ConsuNociOtrasDroHabToxi.Enabled = false;
            txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Enabled = false;
            txt_otrasConsuNociOtrasDroHabToxi.Enabled = false;
            txt_tiemCon2ConsuNociOtrasDroHabToxi.Enabled = false;
            txt_canti2ConsuNociOtrasDroHabToxi.Enabled = false;
            txt_exConsumi2ConsuNociOtrasDroHabToxi.Enabled = false;
            txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Enabled = false;
            txt_cualEstVidaActFisiEstVida.Enabled = false;
            txt_tiemCanEstVidaActFisiEstVida.Enabled = false;
            txt_cual1EstVidaMedHabiEstVida.Enabled = false;
            txt_tiemCan1EstVidaMedHabiEstVida.Enabled = false;
            txt_cual2EstVidaMedHabiEstVida.Enabled = false;
            txt_tiemCan2EstVidaMedHabiEstVida.Enabled = false;
            txt_cual3EstVidaMedHabiEstVida.Enabled = false;
            txt_tiemCan3EstVidaMedHabiEstVida.Enabled = false;
            txt_especificar.Enabled = false;
            txt_fecha.Enabled = false;
            txt_observaciones2.Enabled = false;
            txt_espeprofesional.Enabled = false;
            txt_fechaprofesional.Enabled = false;
            txt_observaciones3.Enabled = false;
        }

        protected void ckb_catolica_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_catolica.Checked == true)
            {
                ckb_evangelica.Checked = false;
                ckb_testigo.Checked = false;
                ckb_mormona.Checked = false;
                ckb_otrareligion.Checked = false;
            }
        }

        protected void ckb_evangelica_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_evangelica.Checked == true)
            {
                ckb_catolica.Checked = false;
                ckb_testigo.Checked = false;
                ckb_mormona.Checked = false;
                ckb_otrareligion.Checked = false;
            }
        }

        protected void ckb_testigo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_testigo.Checked == true)
            {
                ckb_catolica.Checked = false;
                ckb_evangelica.Checked = false;
                ckb_mormona.Checked = false;
                ckb_otrareligion.Checked = false;
            }
        }

        protected void ckb_mormona_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_mormona.Checked == true)
            {
                ckb_catolica.Checked = false;
                ckb_evangelica.Checked = false;
                ckb_testigo.Checked = false;
                ckb_otrareligion.Checked = false;
            }
        }

        protected void ckb_otrareligion_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_otrareligion.Checked == true)
            {
                ckb_catolica.Checked = false;
                ckb_evangelica.Checked = false;
                ckb_testigo.Checked = false;
                ckb_mormona.Checked = false;
            }
        }

        protected void cbk_lesbiana_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_lesbiana.Checked == true)
            {
                cbk_gay.Checked = false;
                cbk_bisexual.Checked = false;
                cbk_heterosexual.Checked = false;
                cbk_noRespondeOriSex.Checked = false;
            }
        }

        protected void cbk_gay_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_gay.Checked == true)
            {
                cbk_lesbiana.Checked = false;
                cbk_bisexual.Checked = false;
                cbk_heterosexual.Checked = false;
                cbk_noRespondeOriSex.Checked = false;
            }
        }

        protected void cbk_bisexual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_bisexual.Checked == true)
            {
                cbk_gay.Checked = false;
                cbk_lesbiana.Checked = false;
                cbk_heterosexual.Checked = false;
                cbk_noRespondeOriSex.Checked = false;
            }
        }

        protected void cbk_heterosexual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_heterosexual.Checked == true)
            {
                cbk_gay.Checked = false;
                cbk_lesbiana.Checked = false;
                cbk_bisexual.Checked = false;
                cbk_noRespondeOriSex.Checked = false;
            }
        }

        protected void cbk_noRespondeOriSex_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_noRespondeOriSex.Checked == true)
            {
                cbk_gay.Checked = false;
                cbk_lesbiana.Checked = false;
                cbk_bisexual.Checked = false;
                cbk_heterosexual.Checked = false;
            }
        }

        protected void cbk_femenino_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_femenino.Checked == true)
            {
                cbk_masculino.Checked = false;
                cbk_transfemenino.Checked = false;
                cbk_transmasculino.Checked = false;
                cbk_noRespondeIdeGen.Checked = false;
            }
        }

        protected void cbk_masculino_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_masculino.Checked == true)
            {
                cbk_femenino.Checked = false;
                cbk_transfemenino.Checked = false;
                cbk_transmasculino.Checked = false;
                cbk_noRespondeIdeGen.Checked = false;
            }
        }

        protected void cbk_transfemenino_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_transfemenino.Checked == true)
            {
                cbk_femenino.Checked = false;
                cbk_masculino.Checked = false;
                cbk_transmasculino.Checked = false;
                cbk_noRespondeIdeGen.Checked = false;
            }
        }

        protected void cbk_transmasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_transmasculino.Checked == true)
            {
                cbk_femenino.Checked = false;
                cbk_masculino.Checked = false;
                cbk_transfemenino.Checked = false;
                cbk_noRespondeIdeGen.Checked = false;
            }
        }

        protected void cbk_noRespondeIdeGen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_noRespondeIdeGen.Checked == true)
            {
                cbk_femenino.Checked = false;
                cbk_masculino.Checked = false;
                cbk_transfemenino.Checked = false;
                cbk_transmasculino.Checked = false;
            }
        }

        protected void cbk_sidiscapacidad_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_sidiscapacidad.Checked == true)
            {
                cbk_nodiscapacidad.Checked = false;
                txt_tipodiscapacidad.Enabled = true;
                txt_porcentajediscapacidad.Enabled = true;
            }
        }

        protected void cbk_nodiscapacidad_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_nodiscapacidad.Checked == true)
            {
                cbk_sidiscapacidad.Checked = false;
                txt_tipodiscapacidad.Enabled = false;
                txt_tipodiscapacidad.Text = "";
                txt_porcentajediscapacidad.Enabled = false;
                txt_porcentajediscapacidad.Text = "";
            }
        }

        protected void ckb_siVidSexAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siVidSexAntGinObste.Checked == true)
            {
                ckb_noVidSexAntGinObste.Checked = false;
            }
        }

        protected void ckb_noVidSexAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noVidSexAntGinObste.Checked == true)
            {
                ckb_siVidSexAntGinObste.Checked = false;
            }
        }

        protected void ckb_siMetPlaniAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siMetPlaniAntGinObste.Checked == true)
            {
                ckb_noMetPlaniAntGinObste.Checked = false;
                txt_tipoMetPlaniAntGinObste.Enabled = true;
            }
        }

        protected void ckb_noMetPlaniAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noMetPlaniAntGinObste.Checked == true)
            {
                ckb_siMetPlaniAntGinObste.Checked = false;
                txt_tipoMetPlaniAntGinObste.Enabled = false;
                txt_tipoMetPlaniAntGinObste.Text = "";
            }
        }

        protected void ckb_siPapaniAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siPapaniAntGinObste.Checked == true)
            {
                ckb_noPapaniAntGinObste.Checked = false;
                txt_tiempoPapaniAntGinObste.Enabled = true;
                txt_resultadoPapaniAntGinObste.Enabled = true;
            }
        }

        protected void ckb_noPapaniAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noPapaniAntGinObste.Checked == true)
            {
                ckb_siPapaniAntGinObste.Checked = false;
                txt_tiempoPapaniAntGinObste.Enabled = false;
                txt_tiempoPapaniAntGinObste.Text = "";
                txt_resultadoPapaniAntGinObste.Enabled = false;
                txt_resultadoPapaniAntGinObste.Text = "";
            }
        }

        protected void ckb_siEcoMamaAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siEcoMamaAntGinObste.Checked == true)
            {
                ckb_noEcoMamaAntGinObste.Checked = false;
                txt_tiempoEcoMamaAntGinObste.Enabled = true;
                txt_resultadoEcoMamaAntGinObste.Enabled = true;
            }
        }

        protected void ckb_noEcoMamaAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noEcoMamaAntGinObste.Checked == true)
            {
                ckb_siEcoMamaAntGinObste.Checked = false;
                txt_tiempoEcoMamaAntGinObste.Enabled = false;
                txt_tiempoEcoMamaAntGinObste.Text = "";
                txt_resultadoEcoMamaAntGinObste.Enabled = false;
                txt_resultadoEcoMamaAntGinObste.Text = "";
            }
        }

        protected void ckb_siColposAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siColposAntGinObste.Checked == true)
            {
                ckb_noColposAntGinObste.Checked = false;
                txt_tiempoColposAntGinObste.Enabled = true;
                txt_resultadoColposAntGinObste.Enabled = true;
            }
        }

        protected void ckb_noColposAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noColposAntGinObste.Checked == true)
            {
                ckb_siColposAntGinObste.Checked = false;
                txt_tiempoColposAntGinObste.Enabled = false;
                txt_tiempoColposAntGinObste.Text = "";
                txt_resultadoColposAntGinObste.Enabled = false;
                txt_resultadoColposAntGinObste.Text = "";
            }
        }

        protected void ckb_siMamograAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siMamograAntGinObste.Checked == true)
            {
                ckb_noMamograAntGinObste.Checked = false;
                txt_tiempoMamograAntGinObste.Enabled = true;
                txt_resultadoMamograAntGinObste.Enabled = true;
            }
        }

        protected void ckb_noMamograAntGinObste_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noMamograAntGinObste.Checked == true)
            {
                ckb_siMamograAntGinObste.Checked = false;
                txt_tiempoMamograAntGinObste.Enabled = false;
                txt_tiempoMamograAntGinObste.Text = "";
                txt_resultadoMamograAntGinObste.Enabled = false;
                txt_resultadoMamograAntGinObste.Text = "";
            }
        }

        protected void ckb_siExaRealiAntProstaAntReproMascu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siExaRealiAntProstaAntReproMascu.Checked == true)
            {
                ckb_noExaRealiAntProstaAntReproMascu.Checked = false;
                txt_tiempoExaRealiAntProstaAntReproMascu.Enabled = true;
                txt_resultadoExaRealiAntProstaAntReproMascu.Enabled = true;
            }
        }

        protected void ckb_noExaRealiAntProstaAntReproMascu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noExaRealiAntProstaAntReproMascu.Checked == true)
            {
                ckb_siExaRealiAntProstaAntReproMascu.Checked = false;
                txt_tiempoExaRealiAntProstaAntReproMascu.Enabled = false;
                txt_tiempoExaRealiAntProstaAntReproMascu.Text = "";
                txt_resultadoExaRealiAntProstaAntReproMascu.Enabled = false;
                txt_resultadoExaRealiAntProstaAntReproMascu.Text = "";
            }
        }

        protected void ckb_siMetPlaniAntReproMascu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siMetPlaniAntReproMascu.Checked == true)
            {
                ckb_noMetPlaniAntReproMascu.Checked = false;
                txt_tipo1MetPlaniAntReproMascu.Enabled = true;
                txt_tipo2MetPlaniAntReproMascu.Enabled = true;
            }
        }

        protected void ckb_noMetPlaniAntReproMascu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noMetPlaniAntReproMascu.Checked == true)
            {
                ckb_siMetPlaniAntReproMascu.Checked = false;
                txt_tipo1MetPlaniAntReproMascu.Enabled = false;
                txt_tipo1MetPlaniAntReproMascu.Text = "";
                txt_tipo2MetPlaniAntReproMascu.Enabled = false;
                txt_tipo2MetPlaniAntReproMascu.Text = "";
            }
        }

        protected void ckb_siExaRealiEcoProstaAntReproMascu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siExaRealiEcoProstaAntReproMascu.Checked == true)
            {
                ckb_noExaRealiEcoProstaAntReproMascu.Checked = false;
                txt_tiempoExaRealiEcoProstaAntReproMascu.Enabled = true;
                txt_resultadoExaRealiEcoProstaAntReproMascu.Enabled = true;
                txt_tipo2MetPlaniAntReproMascu.Enabled = true;
            }
        }

        protected void ckb_noExaRealiEcoProstaAntReproMascu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noExaRealiEcoProstaAntReproMascu.Checked == true)
            {
                ckb_siExaRealiEcoProstaAntReproMascu.Checked = false;
                txt_tiempoExaRealiEcoProstaAntReproMascu.Enabled = false;
                txt_tiempoExaRealiEcoProstaAntReproMascu.Text = "";
                txt_resultadoExaRealiEcoProstaAntReproMascu.Enabled = false;
                txt_resultadoExaRealiEcoProstaAntReproMascu.Text = "";
                txt_tipo2MetPlaniAntReproMascu.Enabled = false;
                txt_tipo2MetPlaniAntReproMascu.Text = "";
            }
        }

        protected void ckb_siConsuNociTabaHabToxi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siConsuNociTabaHabToxi.Checked == true)
            {
                txt_tiemConConsuNociTabaHabToxi.Enabled = true;
                txt_cantiConsuNociTabaHabToxi.Enabled = true;
                txt_exConsumiConsuNociTabaHabToxi.Enabled = true;
                txt_tiemAbstiConsuNociTabaHabToxi.Enabled = true;
                ckb_noConsuNociTabaHabToxi.Checked = false;
            }
        }

        protected void ckb_noConsuNociTabaHabToxi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noConsuNociTabaHabToxi.Checked == true)
            {
                txt_tiemConConsuNociTabaHabToxi.Enabled = false;
                txt_tiemConConsuNociTabaHabToxi.Text = "";
                txt_cantiConsuNociTabaHabToxi.Enabled = false;
                txt_cantiConsuNociTabaHabToxi.Text = "";
                txt_exConsumiConsuNociTabaHabToxi.Enabled = false;
                txt_exConsumiConsuNociTabaHabToxi.Text = "";
                txt_tiemAbstiConsuNociTabaHabToxi.Enabled = false;
                txt_tiemAbstiConsuNociTabaHabToxi.Text = "";
                ckb_siConsuNociTabaHabToxi.Checked = false;
            }
        }

        protected void ckb_siConsuNociAlcoHabToxi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siConsuNociAlcoHabToxi.Checked == true)
            {
                txt_tiemConConsuNociAlcoHabToxi.Enabled = true;
                txt_cantiConsuNociAlcoHabToxi.Enabled = true;
                txt_exConsumiConsuNociAlcoHabToxi.Enabled = true;
                txt_tiemAbstiConsuNociAlcoHabToxi.Enabled = true;
                ckb_noConsuNociAlcoHabToxi.Checked = false;
            }
        }

        protected void ckb_noConsuNociAlcoHabToxi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noConsuNociAlcoHabToxi.Checked == true)
            {
                txt_tiemConConsuNociAlcoHabToxi.Enabled = false;
                txt_tiemConConsuNociAlcoHabToxi.Text = "";
                txt_cantiConsuNociAlcoHabToxi.Enabled = false;
                txt_cantiConsuNociAlcoHabToxi.Text = "";
                txt_exConsumiConsuNociAlcoHabToxi.Enabled = false;
                txt_exConsumiConsuNociAlcoHabToxi.Text = "";
                txt_tiemAbstiConsuNociAlcoHabToxi.Enabled = false;
                txt_tiemAbstiConsuNociAlcoHabToxi.Text = "";
                ckb_siConsuNociAlcoHabToxi.Checked = false;
            }
        }

        protected void ckb_siConsuNociOtrasDroHabToxi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siConsuNociOtrasDroHabToxi.Checked == true)
            {
                txt_tiemCon1ConsuNociOtrasDroHabToxi.Enabled = true;
                txt_canti1ConsuNociOtrasDroHabToxi.Enabled = true;
                txt_exConsumi1ConsuNociOtrasDroHabToxi.Enabled = true;
                txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Enabled = true;
                txt_otrasConsuNociOtrasDroHabToxi.Enabled = true;
                txt_tiemCon2ConsuNociOtrasDroHabToxi.Enabled = true;
                txt_canti2ConsuNociOtrasDroHabToxi.Enabled = true;
                txt_exConsumi2ConsuNociOtrasDroHabToxi.Enabled = true;
                txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Enabled = true;
                ckb_noConsuNociOtrasDroHabToxi.Checked = false;
            }
        }

        protected void ckb_noConsuNociOtrasDroHabToxi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noConsuNociOtrasDroHabToxi.Checked == true)
            {
                txt_tiemCon1ConsuNociOtrasDroHabToxi.Enabled = false;
                txt_tiemCon1ConsuNociOtrasDroHabToxi.Text = "";
                txt_canti1ConsuNociOtrasDroHabToxi.Enabled = false;
                txt_canti1ConsuNociOtrasDroHabToxi.Text = "";
                txt_exConsumi1ConsuNociOtrasDroHabToxi.Enabled = false;
                txt_exConsumi1ConsuNociOtrasDroHabToxi.Text = "";
                txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Enabled = false;
                txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text = "";
                txt_otrasConsuNociOtrasDroHabToxi.Enabled = false;
                txt_otrasConsuNociOtrasDroHabToxi.Text = "";
                txt_tiemCon2ConsuNociOtrasDroHabToxi.Enabled = false;
                txt_tiemCon2ConsuNociOtrasDroHabToxi.Text = "";
                txt_canti2ConsuNociOtrasDroHabToxi.Enabled = false;
                txt_canti2ConsuNociOtrasDroHabToxi.Text = "";
                txt_exConsumi2ConsuNociOtrasDroHabToxi.Enabled = false;
                txt_exConsumi2ConsuNociOtrasDroHabToxi.Text = "";
                txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Enabled = false;
                txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text = "";
                ckb_siConsuNociOtrasDroHabToxi.Checked = false;
            }
        }

        protected void ckb_siEstVidaActFisiEstVida_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siEstVidaActFisiEstVida.Checked == true)
            {
                txt_cualEstVidaActFisiEstVida.Enabled = true;
                txt_tiemCanEstVidaActFisiEstVida.Enabled = true;
                ckb_noEstVidaActFisiEstVida.Checked = false;
            }
        }

        protected void ckb_noEstVidaActFisiEstVida_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noEstVidaActFisiEstVida.Checked == true)
            {
                txt_cualEstVidaActFisiEstVida.Enabled = false;
                txt_cualEstVidaActFisiEstVida.Text = "";
                txt_tiemCanEstVidaActFisiEstVida.Enabled = false;
                txt_tiemCanEstVidaActFisiEstVida.Text = "";
                ckb_siEstVidaActFisiEstVida.Checked = false;
            }
        }

        protected void ckb_siEstVidaMedHabiEstVida_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siEstVidaMedHabiEstVida.Checked == true)
            {
                txt_cual1EstVidaMedHabiEstVida.Enabled = true;
                txt_tiemCan1EstVidaMedHabiEstVida.Enabled = true;
                txt_cual2EstVidaMedHabiEstVida.Enabled = true;
                txt_tiemCan2EstVidaMedHabiEstVida.Enabled = true;
                txt_cual3EstVidaMedHabiEstVida.Enabled = true;
                txt_tiemCan3EstVidaMedHabiEstVida.Enabled = true;
                ckb_noEstVidaMedHabiEstVida.Checked = false;
            }
        }

        protected void ckb_noEstVidaMedHabiEstVida_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noEstVidaMedHabiEstVida.Checked == true)
            {
                txt_cual1EstVidaMedHabiEstVida.Enabled = false;
                txt_cual1EstVidaMedHabiEstVida.Text = "";
                txt_tiemCan1EstVidaMedHabiEstVida.Enabled = false;
                txt_tiemCan1EstVidaMedHabiEstVida.Text = "";
                txt_cual2EstVidaMedHabiEstVida.Enabled = false;
                txt_cual2EstVidaMedHabiEstVida.Text = "";
                txt_tiemCan2EstVidaMedHabiEstVida.Enabled = false;
                txt_tiemCan2EstVidaMedHabiEstVida.Text = "";
                txt_cual3EstVidaMedHabiEstVida.Enabled = false;
                txt_cual3EstVidaMedHabiEstVida.Text = "";
                txt_tiemCan3EstVidaMedHabiEstVida.Enabled = false;
                txt_tiemCan3EstVidaMedHabiEstVida.Text = "";
                ckb_siEstVidaMedHabiEstVida.Checked = false;
            }
        }

        protected void ckb_siAccTrabDescrip_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siAccTrabDescrip.Checked == true)
            {
                txt_especificar.Enabled = true;
                txt_fecha.Enabled = true;
                txt_observaciones2.Enabled = true;
                ckb_noAccTrabDescrip.Checked = false;
            }
        }

        protected void ckb_noAccTrabDescrip_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noAccTrabDescrip.Checked == true)
            {
                txt_especificar.Enabled = false;
                txt_especificar.Text = "";
                txt_fecha.Enabled = false;
                txt_fecha.Text = "";
                txt_observaciones2.Enabled = false;
                txt_observaciones2.Text = "";
                ckb_siAccTrabDescrip.Checked = false;
            }
        }

        protected void ckb_siprofesional_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siprofesional.Checked == true)
            {
                txt_espeprofesional.Enabled = true;
                txt_fechaprofesional.Enabled = true;
                txt_observaciones3.Enabled = true;
                ckb_noprofesional.Checked = false;
            }
        }

        protected void ckb_noprofesional_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noprofesional.Checked == true)
            {
                txt_espeprofesional.Enabled = false;
                txt_espeprofesional.Text = "";
                txt_fechaprofesional.Enabled = false;
                txt_fechaprofesional.Text = "";
                txt_observaciones3.Enabled = false;
                txt_observaciones3.Text = "";
                ckb_siprofesional.Checked = false;
            }
        }

        protected void ckb_pre_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_pre.Checked == true)
            {
                ckb_def.Checked = false;
            }
        }

        protected void ckb_def_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_def.Checked == true)
            {
                ckb_pre.Checked = false;
            }
        }

        protected void ckb_pre2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_pre2.Checked == true)
            {
                ckb_def2.Checked = false;
            }
        }

        protected void ckb_def2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_def2.Checked == true)
            {
                ckb_pre2.Checked = false;
            }
        }

        protected void ckb_pre3_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_pre3.Checked == true)
            {
                ckb_def3.Checked = false;
            }
        }

        protected void ckb_def3_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_def3.Checked == true)
            {
                ckb_pre3.Checked = false;
            }
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            HtmlNode.ElementsFlags["img"] = HtmlElementFlag.Closed;
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Closed;
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            BaseFont fuente = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font titulo = new Font(fuente, 12f, Font.BOLD, new BaseColor(0, 0, 0));
            BaseFont fuente3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font cuadro = new Font(fuente3, 10f, Font.NORMAL, new BaseColor(0, 0, 0));

            pdfDoc.Open();

            //IMAGEN ENCABEZADO
            string imageURL = Server.MapPath("../Template Principal/images") + "/ecu911.jpg";
            iTextSharp.text.Image fotologo = iTextSharp.text.Image.GetInstance(imageURL);
            fotologo.ScalePercent(30f);

            //ENCABEZADO
            var tblEncabezado = new PdfPTable(new float[] { 100f, 200f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            var c1 = new PdfPCell(fotologo) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 5, Padding = 2 };
            var c2 = new PdfPCell(new Phrase("SERVICIO INTEGRADO DE SEGURIDAD SIS ECU 911", titulo)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2 };
            c1.Border = 0;
            tblEncabezado.AddCell(c1);
            tblEncabezado.AddCell(c2);
            c2.Phrase = new Phrase("GESTIÓN DE SEGURIDAD Y SALUD OCUPACIONAL", titulo);
            tblEncabezado.AddCell(c2);
            c2.Phrase = new Phrase("HISTORIA CLÍNICA OCUPACIONAL - PERIODICA", titulo);
            tblEncabezado.AddCell(c2);
            pdfDoc.Add(tblEncabezado);
            pdfDoc.Add(new Paragraph(" "));

            var tblinf = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblinf.AddCell(new PdfPCell(new Paragraph("A. DATOS DEL ESTABLECIMIENTO - EMPRESA Y USUARIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblinf);
            var tblinfTitulo = new PdfPTable(new float[] { 80f, 40f, 40f, 60f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("INSTITUCIÓN DEL SISTEMA O NOMBRE DE LA EMPRESA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("RUC", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("CIIU", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("ESTABLECIMIENTO DE SALUD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("NÚMERO DE HISTORIA CLÍNICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("NÚMERO DE ARCHIVO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            pdfDoc.Add(tblinfTitulo);
            var tblinfDatos = new PdfPTable(new float[] { 80f, 40f, 40f, 60f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_nomEmpresa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_rucEmp.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_ciiu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_estableSalud.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_numHClinica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_numArchivo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblinfDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblTitulo = new PdfPTable(new float[] { 40f, 40f, 40f, 40f, 30f, 30f, 10f, 10f, 10f, 10f, 10f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEXO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("EDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("RELIGIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("GRUPO SANGUÍNEO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("LATERALIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });

            tblTitulo.AddCell(new PdfPCell(new Paragraph("Católica", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("Evangélica", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("Testigos de Jehová", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("Mormona", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("Otras", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            pdfDoc.Add(tblTitulo);
            var tblDatos = new PdfPTable(new float[] { 40f, 40f, 40f, 40f, 30f, 30f, 10f, 10f, 10f, 10f, 10f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priApellido.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segApellido.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_sexo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_edad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_catolica.Checked == true)
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_evangelica.Checked == true)
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_testigo.Checked == true)
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_mormona.Checked == true)
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrareligion.Checked == true)
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_gruposanguineo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_lateralidad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblTitulo1 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 15f, 15f, 30f, 10f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("ORIENTACION SEXUAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("IDENTIDAD DE GENERO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("DISCAPACIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 4 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("FECHA DE INGRESO AL TRABAJO (DD / MM / AAAA)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("PUESTO DE TRABAJO (CIUO)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("ÁREA DE TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });

            tblTitulo1.AddCell(new PdfPCell(new Paragraph("Lesbiana", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("Gay", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("Bisexual", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("Heterosexual", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("No sabe/No responde", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("Femenino", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("Masculino", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("Trans-femenino", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("Trans-masculino", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("No sabe/No responde", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("TIPO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblTitulo1.AddCell(new PdfPCell(new Paragraph("%", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            pdfDoc.Add(tblTitulo1);
            var tblDatos1 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 15f, 15f, 30f, 10f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (cbk_lesbiana.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_gay.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_bisexual.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_heterosexual.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_noRespondeOriSex.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_femenino.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_masculino.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_transfemenino.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_transmasculino.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_noRespondeIdeGen.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_sidiscapacidad.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (cbk_nodiscapacidad.Checked == true)
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblDatos1.AddCell(new PdfPCell(new Paragraph(txt_tipodiscapacidad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblDatos1.AddCell(new PdfPCell(new Paragraph(txt_porcentajediscapacidad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblDatos1.AddCell(new PdfPCell(new Paragraph(txt_fechaingresotrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblDatos1.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajociuo.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblDatos1.AddCell(new PdfPCell(new Paragraph(txt_areadetrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            pdfDoc.Add(tblDatos1);
            pdfDoc.Add(new Paragraph(" "));
            var tblTitulo2 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTitulo2.AddCell(new PdfPCell(new Paragraph("ACTIVIDADES RELEVANTES AL PUESTO DE TRABAJO A OCUPAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblTitulo2);
            var tblDatos2 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatos2.AddCell(new PdfPCell(new Paragraph(txt_actividadesrelevantes.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblDatos2);
            pdfDoc.Add(new Paragraph(" "));
            var tblmc = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmc.AddCell(new PdfPCell(new Paragraph("B. MOTIVO DE CONSULTA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblmc.AddCell(new PdfPCell(new Paragraph("ANOTAR LA CAUSA DEL PROBLEMA EN LA VERSIÓN DEL INFORMANTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_RIGHT });
            pdfDoc.Add(tblmc);
            var tblmcDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmcDatos.AddCell(new PdfPCell(new Paragraph(txt_motivoconsultainicial.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblmcDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblap = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblap.AddCell(new PdfPCell(new Paragraph("C. ANTECEDENTES PERSONALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblap);
            var tblapTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapTitulo.AddCell(new PdfPCell(new Paragraph("ANTECEDENTES CLÍNICOS Y QUIRÚRGICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblapTitulo);
            var tblapDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapDatos.AddCell(new PdfPCell(new Paragraph(txt_antCliQuiDescripcion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapDatos);
            var tblapTitulo1 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapTitulo1.AddCell(new PdfPCell(new Paragraph("ANTECEDENTES GINECO OBSTÉTRICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblapTitulo1);
            var tblapTitulo2 = new PdfPTable(new float[] { 50f, 35f, 50f, 35f, 35f, 45f, 40f, 30f, 40f, 15f, 15f, 15f, 15f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("MENARQUÍA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("CICLOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("FECHA DE ULTIMA MENSTRUACIÓN DD / MM / AAAA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("GESTAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("PARTOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("CESÁREAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("ABORTOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("HIJOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("VIDA SEXUAL ACTIVA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("METODO DE PLANIFICACIÓN FAMILIAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE });

            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("VIVOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("MUERTOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo2.AddCell(new PdfPCell(new Paragraph("TIPO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapTitulo2);
            var tblapDatos1 = new PdfPTable(new float[] { 50f, 35f, 50f, 35f, 35f, 45f, 40f, 30f, 40f, 15f, 15f, 15f, 15f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_menarquiaAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_ciclosAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_fechUltiMensAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_gestasAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_partosAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_cesareasAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_abortosAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_vivosAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_muertosAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siVidSexAntGinObste.Checked == true)
            {
                tblapDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noVidSexAntGinObste.Checked == true)
            {
                tblapDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_siMetPlaniAntGinObste.Checked == true)
            {
                tblapDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noMetPlaniAntGinObste.Checked == true)
            {
                tblapDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblapDatos1.AddCell(new PdfPCell(new Paragraph(txt_tipoMetPlaniAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapDatos1);
            pdfDoc.Add(new Paragraph(" "));
            var tblapTitulo3 = new PdfPTable(new float[] { 50f, 10f, 10f, 20f, 40f, 50f, 10f, 10f, 20f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("EXAMENES REALIZADOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("TIEMPO (AÑOS)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("RESULTADO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("EXAMENES REALIZADOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("TIEMPO (AÑOS)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo3.AddCell(new PdfPCell(new Paragraph("RESULTADO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapTitulo3);
            var tblapDatos2 = new PdfPTable(new float[] { 50f, 10f, 10f, 20f, 40f, 50f, 10f, 10f, 20f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapDatos2.AddCell(new PdfPCell(new Paragraph("PAPANICOLAOU", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siPapaniAntGinObste.Checked == true)
            {
                tblapDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noPapaniAntGinObste.Checked == true)
            {
                tblapDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblapDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiempoPapaniAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos2.AddCell(new PdfPCell(new Paragraph(txt_resultadoPapaniAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos2.AddCell(new PdfPCell(new Paragraph("ECO MAMARIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siEcoMamaAntGinObste.Checked == true)
            {
                tblapDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noEcoMamaAntGinObste.Checked == true)
            {
                tblapDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblapDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiempoEcoMamaAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos2.AddCell(new PdfPCell(new Paragraph(txt_resultadoEcoMamaAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapDatos2);
            var tblapDatos3 = new PdfPTable(new float[] { 50f, 10f, 10f, 20f, 40f, 50f, 10f, 10f, 20f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapDatos3.AddCell(new PdfPCell(new Paragraph("COLPOSCOPIA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siColposAntGinObste.Checked == true)
            {
                tblapDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noColposAntGinObste.Checked == true)
            {
                tblapDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblapDatos3.AddCell(new PdfPCell(new Paragraph(txt_tiempoColposAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos3.AddCell(new PdfPCell(new Paragraph(txt_resultadoColposAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos3.AddCell(new PdfPCell(new Paragraph("MAMOGRAFÍA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siMamograAntGinObste.Checked == true)
            {
                tblapDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noMamograAntGinObste.Checked == true)
            {
                tblapDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblapDatos3.AddCell(new PdfPCell(new Paragraph(txt_tiempoMamograAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos3.AddCell(new PdfPCell(new Paragraph(txt_resultadoMamograAntGinObste.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapDatos3);
            pdfDoc.Add(new Paragraph(" "));
            var tblapTitulo4 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapTitulo4.AddCell(new PdfPCell(new Paragraph("ANTECEDENTES REPRODUCTIVOS MASCULINOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblapTitulo4);
            var tblapTitulo5 = new PdfPTable(new float[] { 50f, 10f, 10f, 20f, 40f, 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("EXAMENES REALIZADOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("TIEMPO (AÑOS)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("RESULTADO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("MÉTODO DE PLANIFICACIÓN FAMILIAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 3 });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("HIJOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2 });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("TIPO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("VIVOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo5.AddCell(new PdfPCell(new Paragraph("MUERTOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapTitulo5);
            var tblapDatos4 = new PdfPTable(new float[] { 50f, 10f, 10f, 20f, 40f, 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapDatos4.AddCell(new PdfPCell(new Paragraph("ANTÍGENO PROSTÁTICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siExaRealiAntProstaAntReproMascu.Checked == true)
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noExaRealiAntProstaAntReproMascu.Checked == true)
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblapDatos4.AddCell(new PdfPCell(new Paragraph(txt_tiempoExaRealiAntProstaAntReproMascu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos4.AddCell(new PdfPCell(new Paragraph(txt_resultadoExaRealiAntProstaAntReproMascu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siMetPlaniAntReproMascu.Checked == true)
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            if (ckb_noMetPlaniAntReproMascu.Checked == true)
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblapDatos4.AddCell(new PdfPCell(new Paragraph(txt_tipo1MetPlaniAntReproMascu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos4.AddCell(new PdfPCell(new Paragraph(txt_vivosHijosAntReproMascu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblapDatos4.AddCell(new PdfPCell(new Paragraph(txt_muertosHijosAntReproMascu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });

            tblapDatos4.AddCell(new PdfPCell(new Paragraph("ECO PROSTÁTICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siExaRealiEcoProstaAntReproMascu.Checked == true)
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noExaRealiEcoProstaAntReproMascu.Checked == true)
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblapDatos4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblapDatos4.AddCell(new PdfPCell(new Paragraph(txt_tiempoExaRealiEcoProstaAntReproMascu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos4.AddCell(new PdfPCell(new Paragraph(txt_resultadoExaRealiEcoProstaAntReproMascu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapDatos4.AddCell(new PdfPCell(new Paragraph(txt_tipo2MetPlaniAntReproMascu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapDatos4);
            pdfDoc.Add(new Paragraph(" "));
            var tblhb = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhb.AddCell(new PdfPCell(new Paragraph("HÁBITOS TÓXICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblhb);
            var tblhbTitulo = new PdfPTable(new float[] { 50f, 10f, 10f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhbTitulo.AddCell(new PdfPCell(new Paragraph("CONSUMOS NOCIVOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbTitulo.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbTitulo.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbTitulo.AddCell(new PdfPCell(new Paragraph("TIEMPO DE CONSUMO (MESES)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbTitulo.AddCell(new PdfPCell(new Paragraph("CANTIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbTitulo.AddCell(new PdfPCell(new Paragraph("EX CONSUMIDOR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbTitulo.AddCell(new PdfPCell(new Paragraph("TIEMPO DE ABSTINENCIA (MESES)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblhbTitulo);
            var tblhbDatos = new PdfPTable(new float[] { 50f, 10f, 10f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhbDatos.AddCell(new PdfPCell(new Paragraph("TABACO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siConsuNociTabaHabToxi.Checked == true)
            {
                tblhbDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblhbDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noConsuNociTabaHabToxi.Checked == true)
            {
                tblhbDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblhbDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblhbDatos.AddCell(new PdfPCell(new Paragraph(txt_tiemConConsuNociTabaHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos.AddCell(new PdfPCell(new Paragraph(txt_cantiConsuNociTabaHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos.AddCell(new PdfPCell(new Paragraph(txt_exConsumiConsuNociTabaHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos.AddCell(new PdfPCell(new Paragraph(txt_tiemAbstiConsuNociTabaHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblhbDatos);
            var tblhbDatos1 = new PdfPTable(new float[] { 50f, 10f, 10f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhbDatos1.AddCell(new PdfPCell(new Paragraph("ALCOHOL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siConsuNociAlcoHabToxi.Checked == true)
            {
                tblhbDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblhbDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noConsuNociAlcoHabToxi.Checked == true)
            {
                tblhbDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblhbDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblhbDatos1.AddCell(new PdfPCell(new Paragraph(txt_tiemConConsuNociAlcoHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos1.AddCell(new PdfPCell(new Paragraph(txt_cantiConsuNociAlcoHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos1.AddCell(new PdfPCell(new Paragraph(txt_exConsumiConsuNociAlcoHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos1.AddCell(new PdfPCell(new Paragraph(txt_tiemAbstiConsuNociAlcoHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblhbDatos1);
            var tblhbDatos2 = new PdfPTable(new float[] { 50f, 10f, 10f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph("OTRAS DROGAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siConsuNociOtrasDroHabToxi.Checked == true)
            {
                tblhbDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            }
            else
            {
                tblhbDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            }
            if (ckb_noConsuNociOtrasDroHabToxi.Checked == true)
            {
                tblhbDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            }
            else
            {
                tblhbDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            }
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiemCon1ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_canti1ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_exConsumi1ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_otrasConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiemCon2ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_canti2ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_exConsumi2ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhbDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblhbDatos2);
            pdfDoc.Add(new Paragraph(" "));
            var tblev = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblev.AddCell(new PdfPCell(new Paragraph("ESTILO DE VIDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblev);
            var tblevTitulo = new PdfPTable(new float[] { 50f, 10f, 10f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("ESTILO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("¿CUÁL?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("TIEMPO/CANTIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevTitulo);
            var tblevDatos = new PdfPTable(new float[] { 50f, 10f, 10f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevDatos.AddCell(new PdfPCell(new Paragraph("ACTIVIDAD FÍSICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siEstVidaActFisiEstVida.Checked == true)
            {
                tblevDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            }
            else
            {
                tblevDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            }
            if (ckb_noEstVidaActFisiEstVida.Checked == true)
            {
                tblevDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            }
            else
            {
                tblevDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            }
            tblevDatos.AddCell(new PdfPCell(new Paragraph(txt_cualEstVidaActFisiEstVida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevDatos.AddCell(new PdfPCell(new Paragraph(txt_tiemCanEstVidaActFisiEstVida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevDatos);
            var tblevDatos1 = new PdfPTable(new float[] { 50f, 10f, 10f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevDatos1.AddCell(new PdfPCell(new Paragraph("MEDICACIÓN HABITUAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 3, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_siEstVidaMedHabiEstVida.Checked == true)
            {
                tblevDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblevDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_noEstVidaMedHabiEstVida.Checked == true)
            {
                tblevDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblevDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            tblevDatos1.AddCell(new PdfPCell(new Paragraph(txt_cual1EstVidaMedHabiEstVida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevDatos1.AddCell(new PdfPCell(new Paragraph(txt_tiemCan1EstVidaMedHabiEstVida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevDatos1.AddCell(new PdfPCell(new Paragraph(txt_cual2EstVidaMedHabiEstVida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevDatos1.AddCell(new PdfPCell(new Paragraph(txt_tiemCan2EstVidaMedHabiEstVida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevDatos1.AddCell(new PdfPCell(new Paragraph(txt_cual3EstVidaMedHabiEstVida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevDatos1.AddCell(new PdfPCell(new Paragraph(txt_tiemCan3EstVidaMedHabiEstVida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevDatos1);
            pdfDoc.Add(new Paragraph(" "));
            var tblat = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblat.AddCell(new PdfPCell(new Paragraph("D. ANTECEDENTES DE TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblat);
            var tblaea = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaea.AddCell(new PdfPCell(new Paragraph("ESTILO DE VIDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblaea);
            var tblaeaTitulo = new PdfPTable(new float[] { 40f, 40f, 70f, 30f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("EMPRESA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("PUESTO DE TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("ACTVIDADES QUE DESEMPEÑA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("TIEMPO DE TRABAJO (MESES)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("RIESGO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 6 });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("OBSERVACIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("FÍSICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("MECÁNICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("QUÍMICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("BIÓLOGO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("ERGÓNOMICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblaeaTitulo.AddCell(new PdfPCell(new Paragraph("PSICOSOCIAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            pdfDoc.Add(tblaeaTitulo);
            var tblaeaDatos = new PdfPTable(new float[] { 40f, 40f, 70f, 30f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaeaDatos.AddCell(new PdfPCell(new Paragraph(txt_empresa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos.AddCell(new PdfPCell(new Paragraph(txt_actdesempeña.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos.AddCell(new PdfPCell(new Paragraph(txt_tiempotrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_fisico.Checked == true)
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_mecanico.Checked == true)
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_quimico.Checked == true)
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_biologico.Checked == true)
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_ergonomico.Checked == true)
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_psicosocial.Checked == true)
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            tblaeaDatos.AddCell(new PdfPCell(new Paragraph(txt_obseantempleanteriores.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblaeaDatos);
            var tblaeaDatos1 = new PdfPTable(new float[] { 40f, 40f, 70f, 30f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(txt_empresa2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(txt_actdesempeña2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(txt_tiempotrabajo2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_fisico2.Checked == true)
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_mecanico2.Checked == true)
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_quimico2.Checked == true)
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_biologico2.Checked == true)
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_ergonomico2.Checked == true)
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_psicosocial2.Checked == true)
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            tblaeaDatos1.AddCell(new PdfPCell(new Paragraph(txt_obseantempleanteriores2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblaeaDatos1);
            var tblaeaDatos2 = new PdfPTable(new float[] { 40f, 40f, 70f, 30f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(txt_empresa3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(txt_actdesempeña3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiempotrabajo3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_fisico3.Checked == true)
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_mecanico3.Checked == true)
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_quimico3.Checked == true)
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_biologico3.Checked == true)
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_ergonomico3.Checked == true)
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_psicosocial3.Checked == true)
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            tblaeaDatos2.AddCell(new PdfPCell(new Paragraph(txt_obseantempleanteriores3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblaeaDatos2);
            var tblaeaDatos3 = new PdfPTable(new float[] { 40f, 40f, 70f, 30f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(txt_empresa4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(txt_actdesempeña4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(txt_tiempotrabajo4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_fisico4.Checked == true)
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_mecanico4.Checked == true)
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_quimico4.Checked == true)
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_biologico4.Checked == true)
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_ergonomico4.Checked == true)
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            if (ckb_psicosocial4.Checked == true)
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            else
            {
                tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 3 });
            }
            tblaeaDatos3.AddCell(new PdfPCell(new Paragraph(txt_obseantempleanteriores3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblaeaDatos3);
            pdfDoc.Add(new Paragraph(" "));
            var tblatTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatTitulo.AddCell(new PdfPCell(new Paragraph("ACCIDENTES DE TRABAJO (DESCRIPCIÓN)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblatTitulo);
            var tblatDatos = new PdfPTable(new float[] { 90f, 10f, 10f, 40f, 50f, 10f, 10f, 20f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatDatos.AddCell(new PdfPCell(new Paragraph("FUE CALIFICADO POR EL INSTITUTO DE SEGURIDAD SOCIAL CORRESPONDIENTE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siAccTrabDescrip.Checked == true)
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblatDatos.AddCell(new PdfPCell(new Paragraph("ESPECIFICAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph(txt_especificar.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noAccTrabDescrip.Checked == true)
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblatDatos.AddCell(new PdfPCell(new Paragraph("FECHA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph(txt_fecha.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblatDatos);
            var tblatDatos1 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatDatos1.AddCell(new PdfPCell(new Paragraph(txt_observaciones2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT }); ;
            pdfDoc.Add(tblatDatos1);
            pdfDoc.Add(new Paragraph(" "));
            var tblefTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefTitulo.AddCell(new PdfPCell(new Paragraph("ENFERMEDADES PROFESIONALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefTitulo);
            var tblefDatos = new PdfPTable(new float[] { 90f, 10f, 10f, 40f, 50f, 10f, 10f, 20f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefDatos.AddCell(new PdfPCell(new Paragraph("FUE CALIFICADO POR EL INSTITUTO DE SEGURIDAD SOCIAL CORRESPONDIENTE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siprofesional.Checked == true)
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblefDatos.AddCell(new PdfPCell(new Paragraph("ESPECIFICAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph(txt_espeprofesional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noprofesional.Checked == true)
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblefDatos.AddCell(new PdfPCell(new Paragraph("FECHA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaprofesional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblefDatos);
            var tblefDatos1 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefDatos1.AddCell(new PdfPCell(new Paragraph(txt_observaciones3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefDatos1);

            pdfDoc.Add(new Paragraph(" "));
            var tblaf = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaf.AddCell(new PdfPCell(new Paragraph("E. ANTECEDENTES FAMILIARES (DETALLAR EL PARENTESCO)", cuadro)) { BorderColor = new BaseColor(204, 205, 254), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblaf.AddCell(new PdfPCell(new Paragraph("MARCAR Y DESCRIBIR ABAJO ANOTANDO EL NÚMERO", cuadro)) { BorderColor = new BaseColor(204, 205, 254), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_RIGHT });
            pdfDoc.Add(tblaf);
            var tblafTitulo = new PdfPTable(new float[] { 50f, 10f, 50f, 10f, 50f, 10f, 50f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafTitulo.AddCell(new PdfPCell(new Paragraph("1. ENFERMEDAD CARDIO-VASCULAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_enfermedadcardiovascular.Checked == true)
            {
                tblafTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblafTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblafTitulo.AddCell(new PdfPCell(new Paragraph("2. ENFERMEDAD METABÓLICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_enfermedadmetabolica.Checked == true)
            {
                tblafTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblafTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblafTitulo.AddCell(new PdfPCell(new Paragraph("3. ENFERMEDAD NEUROLÓGICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_enfermedadneurologica.Checked == true)
            {
                tblafTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblafTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblafTitulo.AddCell(new PdfPCell(new Paragraph("4. ENFERMEDAD ONCOLÓGICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_enfermedadoncologica.Checked == true)
            {
                tblafTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblafTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblafTitulo);
            var tblafTitulo1 = new PdfPTable(new float[] { 50f, 10f, 50f, 10f, 50f, 10f, 50f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafTitulo1.AddCell(new PdfPCell(new Paragraph("5. ENFERMEDAD INFECCIOSA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_enfermedadinfecciosa.Checked == true)
            {
                tblafTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblafTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblafTitulo1.AddCell(new PdfPCell(new Paragraph("6. ENFERMEDAD HEREDITARIA/CONGÉNITA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_enfermedadhereditaria.Checked == true)
            {
                tblafTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblafTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblafTitulo1.AddCell(new PdfPCell(new Paragraph("7. DISCAPACIDADES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_discapacidades.Checked == true)
            {
                tblafTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblafTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblafTitulo1.AddCell(new PdfPCell(new Paragraph("8. OTROS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_otrosenfer.Checked == true)
            {
                tblafTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblafTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblafTitulo1);
            var tblafTitulo2 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafTitulo2.AddCell(new PdfPCell(new Paragraph(txt_descripcionantefamiliares.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT }); ;
            pdfDoc.Add(tblafTitulo2);

            pdfDoc.Add(new Paragraph(" "));
            var tblfr = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfr.AddCell(new PdfPCell(new Paragraph("F. FACTORES DE RIESGOS DEL PUESTO DE TRABAJO ACTUAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblfr);
            var tblfrTitulo = new PdfPTable(new float[] { 70f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("PUESTO DE TRABAJO / ÁREA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("ACTIVIDADES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("FÍSICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 10 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("TEMPERATURAS ALTAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("TEMPERATURAS BAJAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("RADIACIÓN IONIZANTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("RADIACIÓN NO IONIZANTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("RUIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("VIBRACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("ILUMINACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("VENTILACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("FLUIDO ELÉCTRICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblfrTitulo.AddCell(new PdfPCell(new Paragraph("! OTROS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            pdfDoc.Add(tblfrTitulo);
            var tblfrDatos = new PdfPTable(new float[] { 10f, 60f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrDatos.AddCell(new PdfPCell(new Paragraph("1.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfrDatos.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfrDatos.AddCell(new PdfPCell(new Paragraph(txt_act.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_tempaltas.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_tempbajas.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_radiacion.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noradiacion.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_ruido.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_vibracion.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_iluminacion.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_ventilacion.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_fluidoelectrico.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosFisico.Checked == true)
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblfrDatos);
            var tblfrDatos1 = new PdfPTable(new float[] { 10f, 60f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrDatos1.AddCell(new PdfPCell(new Paragraph("2.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfrDatos1.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajo2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfrDatos1.AddCell(new PdfPCell(new Paragraph(txt_act2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_tempaltas2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_tempbajas2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_radiacion2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noradiacion2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_ruido2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_vibracion2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_iluminacion2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_ventilacion2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_fluidoelectrico2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosFisico2.Checked == true)
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblfrDatos1);
            var tblfrDatos2 = new PdfPTable(new float[] { 10f, 60f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrDatos2.AddCell(new PdfPCell(new Paragraph("3.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfrDatos2.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajo3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfrDatos2.AddCell(new PdfPCell(new Paragraph(txt_act3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_tempaltas3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_tempbajas3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_radiacion3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noradiacion3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_ruido3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_vibracion3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_iluminacion3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_ventilacion3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_fluidoelectrico3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosFisico3.Checked == true)
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblfrDatos2);
            var tblfrDatos3 = new PdfPTable(new float[] { 10f, 60f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrDatos3.AddCell(new PdfPCell(new Paragraph("4.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfrDatos3.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajo4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfrDatos3.AddCell(new PdfPCell(new Paragraph(txt_act4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_tempaltas4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_tempbajas4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_radiacion4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noradiacion4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_ruido4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_vibracion4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_iluminacion4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_ventilacion4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_fluidoelectrico4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosFisico4.Checked == true)
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblfrDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblfrDatos3);
            pdfDoc.Add(new Paragraph(" "));
            var tblmqTitulo = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("MECÁNICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 15 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("QUÍMICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 9 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("ATRAPAMIENTO ENTRE MÁQUINAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("ATRAPAMIENTO ENTRE SUPERFICIES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("ATRAPAMIENTO ENTRE OBJETOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("CAÍDA DE OBJETOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("CAÍDAS AL MISMO NIVEL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("CAÍDAS A DIFERENTE NIVEL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("CONTACTO ELÉCTRICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("CONTACTO CON SUPERFICIES DE TRABAJOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("PROYECCIÓN DE PARTÍCULAS – FRAGMENTOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("PROYECCIÓN DE FLUIDOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("PINCHAZOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("CORTES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("ATROPELLAMIENTOS POR VEHÍCULOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("CHOQUES /COLISIÓN VEHICULAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("OTROS __________", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("SÓLIDOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("POLVOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("HUMOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("LÍQUIDOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("VAPORES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("AEROSOLES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("NEBLINAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("GASEOSOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblmqTitulo.AddCell(new PdfPCell(new Paragraph("OTROS __________", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            pdfDoc.Add(tblmqTitulo);
            var tblmqDatos = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (ckb_atrapmaquinas.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atrapsuperficie.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atrapobjetos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidaobjetos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidamisnivel.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidadifnivel.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_contaelectrico.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_contasuptrabajo.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_proyparticulas.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_proyefluidos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_pinchazos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_cortes.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atroporvehiculos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_choques.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosMecanico.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_solidos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_polvos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_humos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_liquidos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_vapores.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_aerosoles.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_neblinas.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_gaseosos.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosQuimico.Checked == true)
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblmqDatos);
            var tblmqDatos1 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (ckb_atrapmaquinas2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atrapsuperficie2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atrapobjetos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidaobjetos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidamisnivel2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidadifnivel2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_contaelectrico2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_contasuptrabajo2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_proyparticulas2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_proyefluidos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_pinchazos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_cortes2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atroporvehiculos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_choques2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosMecanico2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_solidos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_polvos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_humos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_liquidos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_vapores2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_aerosoles2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_neblinas2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_gaseosos2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosQuimico2.Checked == true)
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblmqDatos1);
            var tblmqDatos2 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (ckb_atrapmaquinas3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atrapsuperficie3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atrapobjetos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidaobjetos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidamisnivel3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidadifnivel3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_contaelectrico3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_contasuptrabajo3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_proyparticulas3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_proyefluidos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_pinchazos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_cortes3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atroporvehiculos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_choques3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosMecanico3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_solidos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_polvos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_humos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_liquidos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_vapores3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_aerosoles3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_neblinas3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_gaseosos3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosQuimico3.Checked == true)
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblmqDatos2);
            var tblmqDatos3 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (ckb_atrapmaquinas4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atrapsuperficie4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atrapobjetos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidaobjetos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidamisnivel4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_caidadifnivel4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_contaelectrico4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_contasuptrabajo4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_proyparticulas4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_proyefluidos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_pinchazos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_cortes4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_atroporvehiculos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_choques4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosMecanico4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_solidos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_polvos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_humos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_liquidos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_vapores4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_aerosoles4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_neblinas4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_gaseosos4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosQuimico4.Checked == true)
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblmqDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblmqDatos3);
            pdfDoc.Add(new Paragraph(" "));
            var tblbeTitulo = new PdfPTable(new float[] { 70f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("PUESTO DE TRABAJO / ÁREA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("ACTIVIDADES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("BIÓLOGO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("ERGONÓMICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("VIRUS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("HONGOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("BACTERIAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("PARÁSITOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("EXPOSICIÓN A VECTORES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("EXPOSICIÓN A ANIMALES SELVÁTICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("OTROS __________", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("MANEJO MANUAL DE CARGAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("MOVIMIENTO REPETITIVOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("POSTURAS FORZADAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("TRABAJOS CON PVD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblbeTitulo.AddCell(new PdfPCell(new Paragraph("OTROS __________", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            pdfDoc.Add(tblbeTitulo);
            var tblbeDatos = new PdfPTable(new float[] { 10f, 60f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblbeDatos.AddCell(new PdfPCell(new Paragraph("1.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblbeDatos.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajo21.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblbeDatos.AddCell(new PdfPCell(new Paragraph(txt_act21.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_virus.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_hongos.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_bacterias.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_parasitos.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_expoavectores.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_expoanimselvaticos.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosBiologico.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_manmanualcargas.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_movrepetitivo.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_postforzadas.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_trabajopvd.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosErgonomico.Checked == true)
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblbeDatos);
            var tblbeDatos1 = new PdfPTable(new float[] { 10f, 60f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblbeDatos1.AddCell(new PdfPCell(new Paragraph("2.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblbeDatos1.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajo22.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblbeDatos1.AddCell(new PdfPCell(new Paragraph(txt_act22.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_virus2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_hongos2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_bacterias2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_parasitos2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_expoavectores2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_expoanimselvaticos2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosBiologico2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_manmanualcargas2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_movrepetitivo2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_postforzadas2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_trabajopvd2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosErgonomico2.Checked == true)
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblbeDatos1);
            var tblbeDatos2 = new PdfPTable(new float[] { 10f, 60f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblbeDatos2.AddCell(new PdfPCell(new Paragraph("3.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblbeDatos2.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajo23.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblbeDatos2.AddCell(new PdfPCell(new Paragraph(txt_act23.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_virus3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_hongos3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_bacterias3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_parasitos3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_expoavectores3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_expoanimselvaticos3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosBiologico3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_manmanualcargas3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_movrepetitivo3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_postforzadas3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_trabajopvd3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosErgonomico3.Checked == true)
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblbeDatos2);
            var tblbeDatos3 = new PdfPTable(new float[] { 10f, 60f, 70f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblbeDatos3.AddCell(new PdfPCell(new Paragraph("4.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblbeDatos3.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajo24.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblbeDatos3.AddCell(new PdfPCell(new Paragraph(txt_act24.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_virus4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_hongos4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_bacterias4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_parasitos4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_expoavectores4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_expoanimselvaticos4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosBiologico4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_manmanualcargas4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_movrepetitivo4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_postforzadas4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_trabajopvd4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosErgonomico4.Checked == true)
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblbeDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblbeDatos3);
            pdfDoc.Add(new Paragraph(" "));
            var tblpsTitulo = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("PSICOSOCIAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Colspan = 13 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("MEDIDAS PREVENTIVAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rowspan = 2 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("MONOTONÍA DEL TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("SOBRECARGA LABORAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("MINUCIOSIDAD DE LA TAREA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("ALTA RESPONSABILIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("AUTONOMÍA EN LA TOMA DE DECISIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("SUPERVISIÓN Y ESTILOS DE DIRECCIÓN DEFICIENTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("CONFLICTO DE ROL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("FALTA DE CLARIDAD EN LAS FUNCIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("INCORRECTA DISTRIBUCIÓN DEL TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("TURNOS ROTATIVOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("RELACIONES INTERPERSONALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("INESTABILIDAD LABORAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            tblpsTitulo.AddCell(new PdfPCell(new Paragraph("OTROS __________", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, Rotation = 90 });
            pdfDoc.Add(tblpsTitulo);
            var tblpsDatos = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (ckb_montrabajo.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_sobrecargalaboral.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_minustarea.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_altarespon.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_automadesiciones.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_supyestdireficiente.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_conflictorol.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_faltaclarfunciones.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_incorrdistrabajo.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_turnorotat.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_relacinterpersonales.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_inestalaboral.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosPsicosocial.Checked == true)
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblpsDatos.AddCell(new PdfPCell(new Paragraph(txt_medpreventivas.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblpsDatos);
            var tblpsDatos1 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (ckb_montrabajo2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_sobrecargalaboral2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_minustarea2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_altarespon2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_automadesiciones2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_supyestdireficiente2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_conflictorol2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_faltaclarfunciones2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_incorrdistrabajo2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_turnorotat2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_relacinterpersonales2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_inestalaboral2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosPsicosocial2.Checked == true)
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblpsDatos1.AddCell(new PdfPCell(new Paragraph(txt_medpreventivas2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblpsDatos1);
            var tblpsDatos2 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (ckb_montrabajo3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_sobrecargalaboral3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_minustarea3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_altarespon3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_automadesiciones3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_supyestdireficiente3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_conflictorol3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_faltaclarfunciones3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_incorrdistrabajo3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_turnorotat3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_relacinterpersonales3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_inestalaboral3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosPsicosocial3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblpsDatos2.AddCell(new PdfPCell(new Paragraph(txt_medpreventivas3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblpsDatos2);
            var tblpsDatos3 = new PdfPTable(new float[] { 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 10f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            if (ckb_montrabajo4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_sobrecargalaboral4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_minustarea4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_altarespon4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_automadesiciones4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_supyestdireficiente4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_conflictorol4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_faltaclarfunciones4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_incorrdistrabajo4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_turnorotat4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_relacinterpersonales4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_inestalaboral4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_otrosPsicosocial4.Checked == true)
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblpsDatos3.AddCell(new PdfPCell(new Paragraph(txt_medpreventivas4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblpsDatos3);
            pdfDoc.Add(new Paragraph(" "));
            var tblael = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblael.AddCell(new PdfPCell(new Paragraph("G. ACTIVIDADES EXTRA LABORALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblael);
            var tblaelDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaelDatos.AddCell(new PdfPCell(new Paragraph(txt_descrextralaborales.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblaelDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblea = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblea.AddCell(new PdfPCell(new Paragraph("H. ENFERMEDAD ACTUAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblea);
            var tbleaDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbleaDatos.AddCell(new PdfPCell(new Paragraph(txt_enfermedadactualinicial.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbleaDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblos = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblos.AddCell(new PdfPCell(new Paragraph("I. REVISIÓN ACTUAL DE ÓRGANOS Y SISTEMAS", cuadro)) { BorderColor = new BaseColor(204, 205, 254), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblos.AddCell(new PdfPCell(new Paragraph("EN CASO DE EXISTIR PATOLOGÍA MARCAR CON X Y DESCRIBIR ABAJO COLOCANDO EL NUMERAL", cuadro)) { BorderColor = new BaseColor(204, 205, 254), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_RIGHT });
            pdfDoc.Add(tblos);
            var tblosTitulo = new PdfPTable(new float[] { 50f, 10f, 50f, 10f, 50f, 10f, 50f, 10f, 50f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosTitulo.AddCell(new PdfPCell(new Paragraph("1. PIEL - ANEXOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_pielanexos.Checked == true)
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblosTitulo.AddCell(new PdfPCell(new Paragraph("3. RESPIRATORIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_respiratorio.Checked == true)
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblosTitulo.AddCell(new PdfPCell(new Paragraph("5. DIGESTIVO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_digestivo.Checked == true)
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblosTitulo.AddCell(new PdfPCell(new Paragraph("7. MÚSCULO ESQUELÉTICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_musculosesqueleticos.Checked == true)
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblosTitulo.AddCell(new PdfPCell(new Paragraph("9. HEMO LINFÁTICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_hemolinfatico.Checked == true)
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblosTitulo);
            var tblosTitulo1 = new PdfPTable(new float[] { 50f, 10f, 50f, 10f, 50f, 10f, 50f, 10f, 50f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosTitulo1.AddCell(new PdfPCell(new Paragraph("2. ÓRGANOS DE LOS SENTIDOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_organossentidos.Checked == true)
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblosTitulo1.AddCell(new PdfPCell(new Paragraph("4. CARDIO-VASCULAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_cardiovascular.Checked == true)
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblosTitulo1.AddCell(new PdfPCell(new Paragraph("6. GENITO - URINARIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_genitourinario.Checked == true)
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblosTitulo1.AddCell(new PdfPCell(new Paragraph("8. ENDOCRINO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_otrosenfer.Checked == true)
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblosTitulo1);
            tblosTitulo1.AddCell(new PdfPCell(new Paragraph("10. NERVIOSO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_nervioso.Checked == true)
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblosTitulo1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblosTitulo1);
            var tblosTitulo2 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosTitulo2.AddCell(new PdfPCell(new Paragraph(txt_descrorganosysistemas.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT }); ;
            pdfDoc.Add(tblafTitulo2);
            pdfDoc.Add(new Paragraph(" "));
            var tblcva = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcva.AddCell(new PdfPCell(new Paragraph("J. CONSTANTES VITALES Y ANTROPOMETRÍA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblcva);
            var tblcvaTitulo = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("PRESIÓN ARTERIAL (mmHg)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("TEMPERATURA (°C)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("FRECUENCIA CARDIACA (l/min)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("SATURACIÓN DE OXÍGENO (%)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("FRECUENCIA RESPIRATORIA (fr/min)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("PESO (Kg)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("TALLA (cm)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("ÍNDICE DE MASA CORPORAL (kg/m2)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("PERÍMETRO ABDOMINAL (cm)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblcvaTitulo);
            var tblcvaDatos = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_preArterial.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_temperatura.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_freCardica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_satOxigeno.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_freRespiratoria.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_peso.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_talla.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_indMasCorporal.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_perAbdominal.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblcvaDatos);

            pdfDoc.Add(new Paragraph(" "));
            var tblefr = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefr.AddCell(new PdfPCell(new Paragraph("K. EXAMEN FÍSICO REGIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefr);
            var tblrg = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrg.AddCell(new PdfPCell(new Paragraph("REGIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrg);
            var tblrgDatos = new PdfPTable(new float[] { 10f, 40f, 10f, 10f, 40f, 10f, 10f, 40f, 10f, 10f, 40f, 10f, 10f, 40f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("1. PIEL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 3, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. CICATRICES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_cicatrices.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("3. OÍDO", cuadro)) { BorderColor = new BaseColor(0238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 3, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. C. AUDITIVO EXTERNO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_auditivoexterno.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("5. NARIZ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. TABIQUE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_tabique.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("8. TÓRAX", cuadro)) { BorderColor = new BaseColor(0238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. PULMONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_pulmones.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("11. PELVIS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. PELVIS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_pelvis.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. TATUAJES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_tatuajes.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. PABELLÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_pabellon.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. CORNETES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_cornetes.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. PARRILLA COSTAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_parrillacostal.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. GENITALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_genitales.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("C. PIEL Y FANERAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_pielyfaneras.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("C. TÍMPANOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_timpanos.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("C. MUCOSAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_mucosa.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("9. ABDOMEN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. VÍSCERAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_visceras.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("12. EXTREMIDADES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 3, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. VASCULAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_vascular.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("2. OJOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 5, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. PÁRPADOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_parpados.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("4. ORO FARINGE", cuadro)) { BorderColor = new BaseColor(0238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 5, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. LABIOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_labios.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("D. SENOS PARANASALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_senosparanasales.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. PARED ABDOMINAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_paredabdominal.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. MIEMBROS SUPERIORES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_miembrosuperiores.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. CONJUNTIVAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_conjuntivas.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. LENGUA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_lengua.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("6. CUELLO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. TIROIDES / MASAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_tiroides.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("10. COLUMNA", cuadro)) { BorderColor = new BaseColor(0238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. FLEXIBILIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_flexibilidad.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("C. MIEMBROS INFERIORES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_miembrosinferiores.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("C. PUPILAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_pupilas.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("C. FARINGE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_faringe.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. MOVILIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_movilidad.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. DESVIACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_desviacion.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("13. NEUROLÓGICO", cuadro)) { BorderColor = new BaseColor(0238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 4, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. FUERZA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_fuerza.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("D. CÓRNEA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_cornea.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("D. AMÍGDALAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_amigdalas.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("7. TÓRAX", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2, Rotation = 90, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("A. MAMAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_mamas.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. SENSIBILIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_sensibilidad.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("E. MOTILIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_motilidad.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("E. DENTADURA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_dentadura.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("B. CORAZÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_corazon.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("C. DOLOR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_dolor.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("C. MARCHA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_marcha.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("CON EVIDENCIA DE PATOLOGÍA MARCAR CON X Y DESCRIBIR EN LA SIGUIENTE SECCIÓN ANOTANDO EL NUMERAL", cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 12, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("D. REFLEJOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            if (ckb_reflejos.Checked == true)
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            else
            {
                tblrgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            }
            pdfDoc.Add(tblrgDatos);
            var tblrgDatos1 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrgDatos1.AddCell(new PdfPCell(new Paragraph(txt_obervexamenfisicoregional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrgDatos1);

            pdfDoc.Add(new Paragraph(" "));
            var tbleg = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbleg.AddCell(new PdfPCell(new Paragraph("L. RESULTADOS DE EXÁMENES GENERALES Y ESPECÍFICOS DE ACUERDO AL RIESGO Y PUESTO DE TRABAJO (IMAGEN, LABORATORIO Y OTROS)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbleg);
            var tblegTitulo = new PdfPTable(new float[] { 40f, 20f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblegTitulo.AddCell(new PdfPCell(new Paragraph("EXAMEN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblegTitulo.AddCell(new PdfPCell(new Paragraph("FECHA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblegTitulo.AddCell(new PdfPCell(new Paragraph("RESULTADO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblegTitulo);
            var tblegDatos = new PdfPTable(new float[] { 40f, 20f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblegDatos.AddCell(new PdfPCell(new Paragraph(txt_examen.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblegDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaexamen.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblegDatos.AddCell(new PdfPCell(new Paragraph(txt_resultadoexamen.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblegDatos);
            var tblegDatos1 = new PdfPTable(new float[] { 40f, 20f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblegDatos1.AddCell(new PdfPCell(new Paragraph(txt_examen2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblegDatos1.AddCell(new PdfPCell(new Paragraph(txt_fechaexamen2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblegDatos1.AddCell(new PdfPCell(new Paragraph(txt_resultadoexamen2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblegDatos1);
            var tblegDatos2 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblegDatos2.AddCell(new PdfPCell(new Paragraph(txt_observacionexamen.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblegDatos2);

            pdfDoc.Add(new Paragraph(" "));
            var tbldg = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldg.AddCell(new PdfPCell(new Paragraph("M. DIAGNÓSTICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbldg);
            var tbldgTitulo = new PdfPTable(new float[] { 10f, 70f, 40f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("PRE= PRESUNTIVO DEF= DEFINITIVO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_RIGHT });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("CIE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("PRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("DEF", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tbldgTitulo);
            var tbldgDatos = new PdfPTable(new float[] { 10f, 70f, 40f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldgDatos.AddCell(new PdfPCell(new Paragraph("1", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgDatos.AddCell(new PdfPCell(new Paragraph(txt_descripdiagnostico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgDatos.AddCell(new PdfPCell(new Paragraph(txt_cie.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_pre.Checked == true)
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_def.Checked == true)
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tbldgDatos);
            var tbldgDatos1 = new PdfPTable(new float[] { 10f, 70f, 40f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldgDatos1.AddCell(new PdfPCell(new Paragraph("2", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgDatos1.AddCell(new PdfPCell(new Paragraph(txt_descripdiagnostico2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgDatos1.AddCell(new PdfPCell(new Paragraph(txt_cie2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_pre2.Checked == true)
            {
                tbldgDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_def2.Checked == true)
            {
                tbldgDatos1.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos1.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tbldgDatos1);
            var tbldgDatos2 = new PdfPTable(new float[] { 10f, 70f, 40f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldgDatos2.AddCell(new PdfPCell(new Paragraph("3", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgDatos2.AddCell(new PdfPCell(new Paragraph(txt_descripdiagnostico3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgDatos2.AddCell(new PdfPCell(new Paragraph(txt_cie3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_pre3.Checked == true)
            {
                tbldgDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_def3.Checked == true)
            {
                tbldgDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tbldgDatos2);

            pdfDoc.Add(new Paragraph(" "));
            var tblaml = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaml.AddCell(new PdfPCell(new Paragraph("N. APTITUD MÉDICA PARA EL TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblaml);
            var tblaptTitulo = new PdfPTable(new float[] { 50f, 10f, 70f, 10f, 70f, 10f, 50f, 10f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaptTitulo.AddCell(new PdfPCell(new Paragraph("APTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_apto.Checked == true)
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblaptTitulo.AddCell(new PdfPCell(new Paragraph("APTO EN OBSERVACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_aptoobservacion.Checked == true)
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblaptTitulo.AddCell(new PdfPCell(new Paragraph("APTO CON LIMITACIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_aptolimitacion.Checked == true)
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblaptTitulo.AddCell(new PdfPCell(new Paragraph("NO APTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noapto.Checked == true)
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblaptTitulo);
            var tblaptDatos = new PdfPTable(new float[] { 21.5f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaptDatos.AddCell(new PdfPCell(new Paragraph("Observación", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaptDatos.AddCell(new PdfPCell(new Paragraph(txt_observacionaptitud.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblaptDatos);
            var tblaptDatos1 = new PdfPTable(new float[] { 21.5f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaptDatos1.AddCell(new PdfPCell(new Paragraph("Limitación", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_CENTER });
            tblaptDatos1.AddCell(new PdfPCell(new Paragraph(txt_limitacionaptitud.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblaptDatos1);

            pdfDoc.Add(new Paragraph(" "));
            var tblryt = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblryt.AddCell(new PdfPCell(new Paragraph("O. RECOMENDACIONES Y/O TRATAMIENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblryt);
            var tblrytDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrytDatos.AddCell(new PdfPCell(new Paragraph(txt_descripciontratamiento.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrytDatos);

            pdfDoc.Add(new Paragraph(" "));
            var tblcm = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcm.AddCell(new PdfPCell(new Paragraph("CERTIFICO QUE LO ANTERIORMENTE EXPRESADO EN RELACIÓN A MI ESTADO DE SALUD ES VERDAD.SE ME HA INFORMADO LAS MEDIDAS PREVENTIVAS A TOMAR PARA DISMINUIR O MITIGAR LOS RIESGOS RELACIONADOS CON MI ACTIVIDAD LABORAL.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblcm);

            pdfDoc.Add(new Paragraph(" "));
            var tbldps = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldps.AddCell(new PdfPCell(new Paragraph("P. DATOS DEL PROFESIONAL DE SALUD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbldps);
            var tbldpsdatos = new PdfPTable(new float[] { 40f, 40f, 50f, 100f, 40f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph("FECHA Y HORA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph(txt_fechahora.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph("NOMBRES Y APELLIDOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ddl_profesional.SelectedItem.Value == "0")
            {
                tbldpsdatos.AddCell(new PdfPCell(new Paragraph("", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldpsdatos.AddCell(new PdfPCell(new Paragraph(ddl_profesional.SelectedItem.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            //tbldpsdatos.AddCell(new PdfPCell(new Paragraph(ddl_profesional.SelectedItem.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });            
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph("CÓDIGO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph(txt_codigoDatProf.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph("FIRMA Y SELLO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tbldpsdatos);

            pdfDoc.Add(new Paragraph(" "));
            var tblfrm = new PdfPTable(new float[] { 70f }) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrm.AddCell(new PdfPCell(new Paragraph("Q. FIRMA DEL USUARIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblfrm);
            var tblfrmDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrmDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblfrmDatos);

            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Inicial_" + txt_numHClinica.Text + "_" + DateTime.Today + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected void txt_puestodetrabajo_TextChanged(object sender, EventArgs e)
        {
            var valor = txt_puestodetrabajo.Text;
            txt_puestodetrabajo21.Text = valor;
        }

        protected void txt_puestodetrabajo2_TextChanged(object sender, EventArgs e)
        {
            var valor = txt_puestodetrabajo2.Text;
            txt_puestodetrabajo22.Text = valor;
        }

        protected void txt_puestodetrabajo3_TextChanged(object sender, EventArgs e)
        {
            var valor = txt_puestodetrabajo3.Text;
            txt_puestodetrabajo23.Text = valor;
        }

        protected void txt_puestodetrabajo4_TextChanged(object sender, EventArgs e)
        {
            var valor = txt_puestodetrabajo4.Text;
            txt_puestodetrabajo24.Text = valor;
        }

        protected void txt_act_TextChanged(object sender, EventArgs e)
        {
            var valor = txt_act.Text;
            txt_act21.Text = valor;
        }

        protected void txt_act2_TextChanged(object sender, EventArgs e)
        {
            var valor = txt_act2.Text;
            txt_act22.Text = valor;
        }

        protected void txt_act3_TextChanged(object sender, EventArgs e)
        {
            var valor = txt_act3.Text;
            txt_act23.Text = valor;
        }

        protected void txt_act4_TextChanged(object sender, EventArgs e)
        {
            var valor = txt_act4.Text;
            txt_act24.Text = valor;
        }

        //protected void txt_act23_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}