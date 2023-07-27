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
    public partial class Periodica : System.Web.UI.Page
    {

        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        private Tbl_Empresa emp = new Tbl_Empresa();
        private Tbl_Centro cen = new Tbl_Centro();
        private Tbl_Periodica perio = new Tbl_Periodica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    perio = CN_Periodica.ObtenerPeriodicaPorId(codigo);
                    int personasid = Convert.ToInt32(perio.Per_id.ToString());
                    per = CN_HistorialMedico.ObtenerPersonasxId(personasid);
                    int empresaid = Convert.ToInt32(perio.Emp_id.ToString());
                    emp = CN_HistorialMedico.ObtenerEmpresaxId(empresaid);

                    btn_guardar.Text = "Actualizar";

                    if (per != null || emp != null)
                    {
                        txt_numHClinica.ReadOnly = true;
                        cargarProfesional();
                        ddl_profesional.Enabled = false;

                        //Habitos Toxicos
                        if (perio.perio_siConsuNocivosTabaco == null)
                        {
                            ckb_siConsuNociTabaHabToxi.Checked = false;
                        }
                        else
                        {
                            ckb_siConsuNociTabaHabToxi.Checked = true;
                        }
                        if (perio.perio_noConsuNocivosTabaco == null)
                        {
                            ckb_noConsuNociTabaHabToxi.Checked = false;
                        }
                        else
                        {
                            ckb_noConsuNociTabaHabToxi.Checked = true;
                        }
                        if (perio.perio_siConsuNocivosAlcohol == null)
                        {
                            ckb_siConsuNociAlcoHabToxi.Checked = false;
                        }
                        else
                        {
                            ckb_siConsuNociAlcoHabToxi.Checked = true;
                        }
                        if (perio.perio_noConsuNocivosAlcohol == null)
                        {
                            ckb_noConsuNociAlcoHabToxi.Checked = false;
                        }
                        else
                        {
                            ckb_noConsuNociAlcoHabToxi.Checked = true;
                        }
                        if (perio.perio_siConsuNocivosOtrasDrogas == null)
                        {
                            ckb_siConsuNociOtrasDroHabToxi.Checked = false;
                        }
                        else
                        {
                            ckb_siConsuNociOtrasDroHabToxi.Checked = true;
                        }
                        if (perio.perio_noConsuNocivosOtrasDrogas == null)
                        {

                            ckb_noConsuNociOtrasDroHabToxi.Checked = false;
                        }
                        else
                        {
                            ckb_noConsuNociOtrasDroHabToxi.Checked = true;
                        }

                        //Estilo de Vida
                        if (perio.perio_siEstiVidaActFisica == null)
                        {
                            ckb_siEstVidaActFisiEstVida.Checked = false;
                        }
                        else
                        {
                            ckb_siEstVidaActFisiEstVida.Checked = true;
                        }
                        if (perio.perio_noEstiVidaActFisica == null)
                        {
                            ckb_noEstVidaActFisiEstVida.Checked = false;
                        }
                        else
                        {
                            ckb_noEstVidaActFisiEstVida.Checked = true;
                        }
                        if (perio.perio_siEstiVidaMediHabitual == null)
                        {
                            ckb_siEstVidaMedHabiEstVida.Checked = false;
                        }
                        else
                        {
                            ckb_siEstVidaMedHabiEstVida.Checked = true;
                        }
                        if (perio.perio_noEstiVidaMediHabitual == null)
                        {
                            ckb_noEstVidaMedHabiEstVida.Checked = false;
                        }
                        else
                        {
                            ckb_noEstVidaMedHabiEstVida.Checked = true;
                        }

                        //Accidentes de Trabajo (Descripcion)
                        if (perio.perio_siCalificadoIESSAcciTrabajo == null)
                        {
                            ckb_sicalificadotrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_sicalificadotrabajo.Checked = true;
                        }
                        if (perio.perio_noCalificadoIESSAcciTrabajo == null)
                        {
                            ckb_nocalificadotrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_nocalificadotrabajo.Checked = true;
                        }

                        //Enfermedades Profesionales
                        if (perio.perio_siCalificadoIESSEnferProfesionales == null)
                        {
                            ckb_sicalificadoprofesional.Checked = false;
                        }
                        else
                        {
                            ckb_sicalificadoprofesional.Checked = true;
                        }
                        if (perio.perio_noCalificadoIESSEnferProfesionales == null)
                        {
                            ckb_nocalificadoprofesional.Checked = false;
                        }
                        else
                        {
                            ckb_nocalificadoprofesional.Checked = true;
                        }

                        //Antecedentes Familiares (Detallar el Parentesco)
                        if (perio.perio_cardVascular == null)
                        {
                            ckb_enfermedadcardiovascular.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadcardiovascular.Checked = true;

                        }
                        if (perio.perio_enfMeta == null)
                        {
                            ckb_enfermedadmetabolica.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadmetabolica.Checked = true;

                        }
                        if (perio.perio_enfNeuro == null)
                        {
                            ckb_enfermedadneurologica.Checked = false; ;
                        }
                        else
                        {
                            ckb_enfermedadneurologica.Checked = true;

                        }
                        if (perio.perio_enfOnco == null)
                        {
                            ckb_enfermedadoncologica.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadoncologica.Checked = true;

                        }
                        if (perio.perio_enfInfe == null)
                        {
                            ckb_enfermedadinfecciosa.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadinfecciosa.Checked = true;

                        }
                        if (perio.perio_enfHereConge == null)
                        {
                            ckb_enfermedadhereditaria.Checked = false;
                        }
                        else
                        {
                            ckb_enfermedadhereditaria.Checked = true;

                        }
                        if (perio.perio_discapa == null)
                        {
                            ckb_discapacidades.Checked = false;
                        }
                        else
                        {
                            ckb_discapacidades.Checked = true;

                        }
                        if (perio.perio_otros == null)
                        {
                            ckb_otrosenfer.Checked = false;
                        }
                        else
                        {
                            ckb_otrosenfer.Checked = true;

                        }

                        //Factores de riesgo del puesto de trabajo
                        //----------- Fisico -----------
                        if (perio.perio_temAltasFis == null)
                        {
                            ckb_tempaltas.Checked = false;
                        }
                        else
                        {
                            ckb_tempaltas.Checked = true;
                        }
                        if (perio.perio_temAltasFis2 == null)
                        {
                            ckb_tempaltas2.Checked = false;
                        }
                        else
                        {
                            ckb_tempaltas2.Checked = true;
                        }
                        if (perio.perio_temAltasFis3 == null)
                        {
                            ckb_tempaltas3.Checked = false;
                        }
                        else
                        {
                            ckb_tempaltas3.Checked = true;
                        }
                        if (perio.perio_temBajasFis == null)
                        {
                            ckb_tempbajas.Checked = false;
                        }
                        else
                        {
                            ckb_tempbajas.Checked = true;
                        }
                        if (perio.perio_temBajasFis2 == null)
                        {
                            ckb_tempbajas2.Checked = false;
                        }
                        else
                        {
                            ckb_tempbajas2.Checked = true;
                        }
                        if (perio.perio_temBajasFis3 == null)
                        {
                            ckb_tempbajas3.Checked = false;
                        }
                        else
                        {
                            ckb_tempbajas3.Checked = true;
                        }
                        if (perio.perio_radIonizanteFis == null)
                        {
                            ckb_radiacion.Checked = false;
                        }
                        else
                        {
                            ckb_radiacion.Checked = true;

                        }
                        if (perio.perio_radIonizanteFis2 == null)
                        {
                            ckb_radiacion2.Checked = false;
                        }
                        else
                        {
                            ckb_radiacion2.Checked = true;

                        }
                        if (perio.perio_radIonizanteFis3 == null)
                        {
                            ckb_radiacion3.Checked = false;
                        }
                        else
                        {
                            ckb_radiacion3.Checked = true;

                        }
                        if (perio.perio_radNoIonizanteFis == null)
                        {
                            ckb_noradiacion.Checked = false;
                        }
                        else
                        {
                            ckb_noradiacion.Checked = true;

                        }
                        if (perio.perio_radNoIonizanteFis2 == null)
                        {
                            ckb_noradiacion2.Checked = false;
                        }
                        else
                        {
                            ckb_noradiacion2.Checked = true;

                        }
                        if (perio.perio_radNoIonizanteFis3 == null)
                        {
                            ckb_noradiacion3.Checked = false;
                        }
                        else
                        {
                            ckb_noradiacion3.Checked = true;

                        }
                        if (perio.perio_ruidoFis == null)
                        {
                            ckb_ruido.Checked = false;
                        }
                        else
                        {
                            ckb_ruido.Checked = true;

                        }
                        if (perio.perio_ruidoFis2 == null)
                        {
                            ckb_ruido2.Checked = false;
                        }
                        else
                        {
                            ckb_ruido2.Checked = true;

                        }
                        if (perio.perio_ruidoFis3 == null)
                        {
                            ckb_ruido3.Checked = false;
                        }
                        else
                        {
                            ckb_ruido3.Checked = true;

                        }
                        if (perio.perio_vibracionFis == null)
                        {
                            ckb_vibracion.Checked = false;
                        }
                        else
                        {
                            ckb_vibracion.Checked = true;

                        }
                        if (perio.perio_vibracionFis2 == null)
                        {
                            ckb_vibracion2.Checked = false;
                        }
                        else
                        {
                            ckb_vibracion2.Checked = true;

                        }
                        if (perio.perio_vibracionFis3 == null)
                        {
                            ckb_vibracion3.Checked = false;
                        }
                        else
                        {
                            ckb_vibracion3.Checked = true;

                        }
                        if (perio.perio_iluminacionFis == null)
                        {
                            ckb_iluminacion.Checked = false;
                        }
                        else
                        {
                            ckb_iluminacion.Checked = true;

                        }
                        if (perio.perio_iluminacionFis2 == null)
                        {
                            ckb_iluminacion2.Checked = false;
                        }
                        else
                        {
                            ckb_iluminacion2.Checked = true;

                        }
                        if (perio.perio_iluminacionFis3 == null)
                        {
                            ckb_iluminacion3.Checked = false;
                        }
                        else
                        {
                            ckb_iluminacion3.Checked = true;

                        }
                        if (perio.perio_ventilacionFis == null)
                        {
                            ckb_ventilacion.Checked = false;
                        }
                        else
                        {
                            ckb_ventilacion.Checked = true;

                        }
                        if (perio.perio_ventilacionFis2 == null)
                        {
                            ckb_ventilacion2.Checked = false;
                        }
                        else
                        {
                            ckb_ventilacion2.Checked = true;

                        }
                        if (perio.perio_ventilacionFis3 == null)
                        {
                            ckb_ventilacion3.Checked = false;
                        }
                        else
                        {
                            ckb_ventilacion3.Checked = true;

                        }
                        if (perio.perio_fluElectricoFis == null)
                        {
                            ckb_fluidoelectrico.Checked = false;
                        }
                        else
                        {
                            ckb_fluidoelectrico.Checked = true;

                        }
                        if (perio.perio_fluElectricoFis2 == null)
                        {
                            ckb_fluidoelectrico2.Checked = false;
                        }
                        else
                        {
                            ckb_fluidoelectrico2.Checked = true;

                        }
                        if (perio.perio_fluElectricoFis3 == null)
                        {
                            ckb_fluidoelectrico3.Checked = false;
                        }
                        else
                        {
                            ckb_fluidoelectrico3.Checked = true;

                        }
                        if (perio.perio_otrosFis == null)
                        {
                            ckb_otrosFisico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosFisico.Checked = true;

                        }
                        if (perio.perio_otrosFis2 == null)
                        {
                            ckb_otrosFisico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosFisico2.Checked = true;

                        }
                        if (perio.perio_otrosFis3 == null)
                        {
                            ckb_otrosFisico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosFisico3.Checked = true;

                        }
                        //----------- Mecanico -----------
                        if (perio.perio_atraMaquinasMec == null)
                        {
                            ckb_atrapmaquinas.Checked = false;
                        }
                        else
                        {
                            ckb_atrapmaquinas.Checked = true;

                        }
                        if (perio.perio_atraMaquinasMec2 == null)
                        {
                            ckb_atrapmaquinas2.Checked = false;
                        }
                        else
                        {
                            ckb_atrapmaquinas2.Checked = true;

                        }
                        if (perio.perio_atraMaquinasMec3 == null)
                        {
                            ckb_atrapmaquinas3.Checked = false;
                        }
                        else
                        {
                            ckb_atrapmaquinas3.Checked = true;

                        }
                        if (perio.perio_atraSuperfiiesMec == null)
                        {
                            ckb_atrapsuperficie.Checked = false;
                        }
                        else
                        {
                            ckb_atrapsuperficie.Checked = true;

                        }
                        if (perio.perio_atraSuperfiiesMec2 == null)
                        {
                            ckb_atrapsuperficie2.Checked = false;
                        }
                        else
                        {
                            ckb_atrapsuperficie2.Checked = true;

                        }
                        if (perio.perio_atraSuperfiiesMec3 == null)
                        {
                            ckb_atrapsuperficie3.Checked = false;
                        }
                        else
                        {
                            ckb_atrapsuperficie3.Checked = true;

                        }
                        if (perio.perio_atraObjetosMec == null)
                        {
                            ckb_atrapobjetos.Checked = false;
                        }
                        else
                        {
                            ckb_atrapobjetos.Checked = true;

                        }
                        if (perio.perio_atraObjetosMec2 == null)
                        {
                            ckb_atrapobjetos2.Checked = false;
                        }
                        else
                        {
                            ckb_atrapobjetos2.Checked = true;

                        }
                        if (perio.perio_atraObjetosMec3 == null)
                        {
                            ckb_atrapobjetos3.Checked = false;
                        }
                        else
                        {
                            ckb_atrapobjetos3.Checked = true;

                        }
                        if (perio.perio_caidaObjetosMec == null)
                        {
                            ckb_caidaobjetos.Checked = false;
                        }
                        else
                        {
                            ckb_caidaobjetos.Checked = true;

                        }
                        if (perio.perio_caidaObjetosMec2 == null)
                        {
                            ckb_caidaobjetos2.Checked = false;
                        }
                        else
                        {
                            ckb_caidaobjetos2.Checked = true;

                        }
                        if (perio.perio_caidaObjetosMec3 == null)
                        {
                            ckb_caidaobjetos3.Checked = false;
                        }
                        else
                        {
                            ckb_caidaobjetos3.Checked = true;

                        }
                        if (perio.perio_caidaMisNivelMec == null)
                        {
                            ckb_caidamisnivel.Checked = false;
                        }
                        else
                        {
                            ckb_caidamisnivel.Checked = true;

                        }
                        if (perio.perio_caidaMisNivelMec2 == null)
                        {
                            ckb_caidamisnivel2.Checked = false;
                        }
                        else
                        {
                            ckb_caidamisnivel2.Checked = true;

                        }
                        if (perio.perio_caidaMisNivelMec3 == null)
                        {
                            ckb_caidamisnivel3.Checked = false;
                        }
                        else
                        {
                            ckb_caidamisnivel3.Checked = true;

                        }
                        if (perio.perio_caidaDifNivelMec == null)
                        {
                            ckb_caidadifnivel.Checked = false;
                        }
                        else
                        {
                            ckb_caidadifnivel.Checked = true;

                        }
                        if (perio.perio_caidaDifNivelMec2 == null)
                        {
                            ckb_caidadifnivel2.Checked = false;
                        }
                        else
                        {
                            ckb_caidadifnivel2.Checked = true;

                        }
                        if (perio.perio_caidaDifNivelMec3 == null)
                        {
                            ckb_caidadifnivel3.Checked = false;
                        }
                        else
                        {
                            ckb_caidadifnivel3.Checked = true;

                        }
                        if (perio.perio_contactoElecMec == null)
                        {
                            ckb_contaelectrico.Checked = false;
                        }
                        else
                        {
                            ckb_contaelectrico.Checked = true;

                        }
                        if (perio.perio_contactoElecMec2 == null)
                        {
                            ckb_contaelectrico2.Checked = false;
                        }
                        else
                        {
                            ckb_contaelectrico2.Checked = true;

                        }
                        if (perio.perio_contactoElecMec3 == null)
                        {
                            ckb_contaelectrico3.Checked = false;
                        }
                        else
                        {
                            ckb_contaelectrico3.Checked = true;

                        }
                        if (perio.perio_conSuperTrabaMec == null)
                        {
                            ckb_contasuptrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_contasuptrabajo.Checked = true;

                        }
                        if (perio.perio_conSuperTrabaMec2 == null)
                        {
                            ckb_contasuptrabajo2.Checked = false;
                        }
                        else
                        {
                            ckb_contasuptrabajo2.Checked = true;

                        }
                        if (perio.perio_conSuperTrabaMec3 == null)
                        {
                            ckb_contasuptrabajo3.Checked = false;
                        }
                        else
                        {
                            ckb_contasuptrabajo3.Checked = true;

                        }
                        if (perio.perio_proPartiFragMec == null)
                        {
                            ckb_proyparticulas.Checked = false;
                        }
                        else
                        {
                            ckb_proyparticulas.Checked = true;

                        }
                        if (perio.perio_proPartiFragMec2 == null)
                        {
                            ckb_proyparticulas2.Checked = false;
                        }
                        else
                        {
                            ckb_proyparticulas2.Checked = true;

                        }
                        if (perio.perio_proPartiFragMec3 == null)
                        {
                            ckb_proyparticulas3.Checked = false;
                        }
                        else
                        {
                            ckb_proyparticulas3.Checked = true;

                        }
                        if (perio.perio_proFluidosMec == null)
                        {
                            ckb_proyefluidos.Checked = false;
                        }
                        else
                        {
                            ckb_proyefluidos.Checked = true;

                        }
                        if (perio.perio_proFluidosMec2 == null)
                        {
                            ckb_proyefluidos2.Checked = false;
                        }
                        else
                        {
                            ckb_proyefluidos2.Checked = true;

                        }
                        if (perio.perio_proFluidosMec3 == null)
                        {
                            ckb_proyefluidos3.Checked = false;
                        }
                        else
                        {
                            ckb_proyefluidos3.Checked = true;

                        }
                        if (perio.perio_pinchazosMec == null)
                        {
                            ckb_pinchazos.Checked = false;
                        }
                        else
                        {
                            ckb_pinchazos.Checked = true;

                        }
                        if (perio.perio_pinchazosMec2 == null)
                        {
                            ckb_pinchazos2.Checked = false;
                        }
                        else
                        {
                            ckb_pinchazos2.Checked = true;

                        }
                        if (perio.perio_pinchazosMec3 == null)
                        {
                            ckb_pinchazos3.Checked = false;
                        }
                        else
                        {
                            ckb_pinchazos3.Checked = true;

                        }
                        if (perio.perio_cortesMec == null)
                        {
                            ckb_cortes.Checked = false;
                        }
                        else
                        {
                            ckb_cortes.Checked = true;

                        }
                        if (perio.perio_cortesMec2 == null)
                        {
                            ckb_cortes2.Checked = false;
                        }
                        else
                        {
                            ckb_cortes2.Checked = true;

                        }
                        if (perio.perio_cortesMec3 == null)
                        {
                            ckb_cortes3.Checked = false;
                        }
                        else
                        {
                            ckb_cortes3.Checked = true;

                        }
                        if (perio.perio_atropeVehiMec == null)
                        {
                            ckb_atroporvehiculos.Checked = false;
                        }
                        else
                        {
                            ckb_atroporvehiculos.Checked = true;

                        }
                        if (perio.perio_atropeVehiMec2 == null)
                        {
                            ckb_atroporvehiculos2.Checked = false;
                        }
                        else
                        {
                            ckb_atroporvehiculos2.Checked = true;

                        }
                        if (perio.perio_atropeVehiMec3 == null)
                        {
                            ckb_atroporvehiculos3.Checked = false;
                        }
                        else
                        {
                            ckb_atroporvehiculos3.Checked = true;

                        }
                        if (perio.perio_coliVehiMec == null)
                        {
                            ckb_choques.Checked = false;
                        }
                        else
                        {
                            ckb_choques.Checked = true;

                        }
                        if (perio.perio_coliVehiMec2 == null)
                        {
                            ckb_choques2.Checked = false;
                        }
                        else
                        {
                            ckb_choques2.Checked = true;

                        }
                        if (perio.perio_coliVehiMec3 == null)
                        {
                            ckb_choques3.Checked = false;
                        }
                        else
                        {
                            ckb_choques3.Checked = true;

                        }
                        if (perio.perio_otrosMec == null)
                        {
                            ckb_otrosMecanico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosMecanico.Checked = true;

                        }
                        if (perio.perio_otrosMec2 == null)
                        {
                            ckb_otrosMecanico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosMecanico2.Checked = true;

                        }
                        if (perio.perio_otrosMec3 == null)
                        {
                            ckb_otrosMecanico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosMecanico3.Checked = true;

                        }
                        //----------- Quimico -----------
                        if (perio.perio_solidosQui == null)
                        {
                            ckb_solidos.Checked = false;
                        }
                        else
                        {
                            ckb_solidos.Checked = true;

                        }
                        if (perio.perio_solidosQui2 == null)
                        {
                            ckb_solidos2.Checked = false;
                        }
                        else
                        {
                            ckb_solidos2.Checked = true;

                        }
                        if (perio.perio_solidosQui3 == null)
                        {
                            ckb_solidos3.Checked = false;
                        }
                        else
                        {
                            ckb_solidos3.Checked = true;

                        }
                        if (perio.perio_polvosQui == null)
                        {
                            ckb_polvos.Checked = false;
                        }
                        else
                        {
                            ckb_polvos.Checked = true;

                        }
                        if (perio.perio_polvosQui2 == null)
                        {
                            ckb_polvos2.Checked = false;
                        }
                        else
                        {
                            ckb_polvos2.Checked = true;

                        }
                        if (perio.perio_polvosQui3 == null)
                        {
                            ckb_polvos3.Checked = false;
                        }
                        else
                        {
                            ckb_polvos3.Checked = true;

                        }
                        if (perio.perio_humosQui == null)
                        {
                            ckb_humos.Checked = false;
                        }
                        else
                        {
                            ckb_humos.Checked = true;

                        }
                        if (perio.perio_humosQui2 == null)
                        {
                            ckb_humos2.Checked = false;
                        }
                        else
                        {
                            ckb_humos2.Checked = true;

                        }
                        if (perio.perio_humosQui3 == null)
                        {
                            ckb_humos3.Checked = false;
                        }
                        else
                        {
                            ckb_humos3.Checked = true;

                        }
                        if (perio.perio_liquidosQui == null)
                        {
                            ckb_liquidos.Checked = false;
                        }
                        else
                        {
                            ckb_liquidos.Checked = true;

                        }
                        if (perio.perio_liquidosQui2 == null)
                        {
                            ckb_liquidos2.Checked = false;
                        }
                        else
                        {
                            ckb_liquidos2.Checked = true;

                        }
                        if (perio.perio_liquidosQui3 == null)
                        {
                            ckb_liquidos3.Checked = false;
                        }
                        else
                        {
                            ckb_liquidos3.Checked = true;

                        }
                        if (perio.perio_vaporesQui == null)
                        {
                            ckb_vapores.Checked = false;
                        }
                        else
                        {
                            ckb_vapores.Checked = true;

                        }
                        if (perio.perio_vaporesQui2 == null)
                        {
                            ckb_vapores2.Checked = false;
                        }
                        else
                        {
                            ckb_vapores2.Checked = true;

                        }
                        if (perio.perio_vaporesQui3 == null)
                        {
                            ckb_vapores3.Checked = false;
                        }
                        else
                        {
                            ckb_vapores3.Checked = true;

                        }
                        if (perio.perio_aerosolesQui == null)
                        {
                            ckb_aerosoles.Checked = false;
                        }
                        else
                        {
                            ckb_aerosoles.Checked = true;

                        }
                        if (perio.perio_aerosolesQui2 == null)
                        {
                            ckb_aerosoles2.Checked = false;
                        }
                        else
                        {
                            ckb_aerosoles2.Checked = true;

                        }
                        if (perio.perio_aerosolesQui3 == null)
                        {
                            ckb_aerosoles3.Checked = false;
                        }
                        else
                        {
                            ckb_aerosoles3.Checked = true;

                        }
                        if (perio.perio_neblinasQui == null)
                        {
                            ckb_neblinas.Checked = false;
                        }
                        else
                        {
                            ckb_neblinas.Checked = true;

                        }
                        if (perio.perio_neblinasQui2 == null)
                        {
                            ckb_neblinas2.Checked = false;
                        }
                        else
                        {
                            ckb_neblinas2.Checked = true;

                        }
                        if (perio.perio_neblinasQui3 == null)
                        {
                            ckb_neblinas3.Checked = false;
                        }
                        else
                        {
                            ckb_neblinas3.Checked = true;

                        }
                        if (perio.perio_gaseososQui == null)
                        {
                            ckb_gaseosos.Checked = false;
                        }
                        else
                        {
                            ckb_gaseosos.Checked = true;

                        }
                        if (perio.perio_gaseososQui2 == null)
                        {
                            ckb_gaseosos2.Checked = false;
                        }
                        else
                        {
                            ckb_gaseosos2.Checked = true;

                        }
                        if (perio.perio_gaseososQui3 == null)
                        {
                            ckb_gaseosos3.Checked = false;
                        }
                        else
                        {
                            ckb_gaseosos3.Checked = true;

                        }
                        if (perio.perio_otrosQui == null)
                        {
                            ckb_otrosQuimico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosQuimico.Checked = true;

                        }
                        if (perio.perio_otrosQui2 == null)
                        {
                            ckb_otrosQuimico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosQuimico2.Checked = true;

                        }
                        if (perio.perio_otrosQui3 == null)
                        {
                            ckb_otrosQuimico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosQuimico3.Checked = true;

                        }
                        //----------- Biologico -----------
                        if (perio.perio_virusBio == null)
                        {
                            ckb_virus.Checked = false;
                        }
                        else
                        {
                            ckb_virus.Checked = true;

                        }
                        if (perio.perio_virusBio2 == null)
                        {
                            ckb_virus2.Checked = false;
                        }
                        else
                        {
                            ckb_virus2.Checked = true;

                        }
                        if (perio.perio_virusBio3 == null)
                        {
                            ckb_virus3.Checked = false;
                        }
                        else
                        {
                            ckb_virus3.Checked = true;

                        }
                        if (perio.perio_hongosBio == null)
                        {
                            ckb_hongos.Checked = false;
                        }
                        else
                        {
                            ckb_hongos.Checked = true;

                        }
                        if (perio.perio_hongosBio2 == null)
                        {
                            ckb_hongos2.Checked = false;
                        }
                        else
                        {
                            ckb_hongos2.Checked = true;

                        }
                        if (perio.perio_hongosBio3 == null)
                        {
                            ckb_hongos3.Checked = false;
                        }
                        else
                        {
                            ckb_hongos3.Checked = true;

                        }
                        if (perio.perio_bacteriasBio == null)
                        {
                            ckb_bacterias.Checked = false;
                        }
                        else
                        {
                            ckb_bacterias.Checked = true;

                        }
                        if (perio.perio_bacteriasBio2 == null)
                        {
                            ckb_bacterias2.Checked = false;
                        }
                        else
                        {
                            ckb_bacterias2.Checked = true;

                        }
                        if (perio.perio_bacteriasBio3 == null)
                        {
                            ckb_bacterias3.Checked = false;
                        }
                        else
                        {
                            ckb_bacterias3.Checked = true;

                        }
                        if (perio.perio_parasitosBio == null)
                        {
                            ckb_parasitos.Checked = false;
                        }
                        else
                        {
                            ckb_parasitos.Checked = true;

                        }
                        if (perio.perio_parasitosBio2 == null)
                        {
                            ckb_parasitos2.Checked = false;
                        }
                        else
                        {
                            ckb_parasitos2.Checked = true;

                        }
                        if (perio.perio_parasitosBio3 == null)
                        {
                            ckb_parasitos3.Checked = false;
                        }
                        else
                        {
                            ckb_parasitos3.Checked = true;

                        }
                        if (perio.perio_expVectBio == null)
                        {
                            ckb_expoavectores.Checked = false;
                        }
                        else
                        {
                            ckb_expoavectores.Checked = true;

                        }
                        if (perio.perio_expVectBio2 == null)
                        {
                            ckb_expoavectores2.Checked = false;
                        }
                        else
                        {
                            ckb_expoavectores2.Checked = true;

                        }
                        if (perio.perio_expVectBio3 == null)
                        {
                            ckb_expoavectores3.Checked = false;
                        }
                        else
                        {
                            ckb_expoavectores3.Checked = true;

                        }
                        if (perio.perio_expAniSelvaBio == null)
                        {
                            ckb_expoanimselvaticos.Checked = false;
                        }
                        else
                        {
                            ckb_expoanimselvaticos.Checked = true;

                        }
                        if (perio.perio_expAniSelvaBio2 == null)
                        {
                            ckb_expoanimselvaticos2.Checked = false;
                        }
                        else
                        {
                            ckb_expoanimselvaticos2.Checked = true;

                        }
                        if (perio.perio_expAniSelvaBio3 == null)
                        {
                            ckb_expoanimselvaticos3.Checked = false;
                        }
                        else
                        {
                            ckb_expoanimselvaticos3.Checked = true;

                        }
                        if (perio.perio_otrosBio == null)
                        {
                            ckb_otrosBiologico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosBiologico.Checked = true;

                        }
                        if (perio.perio_otrosBio2 == null)
                        {
                            ckb_otrosBiologico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosBiologico2.Checked = true;

                        }
                        if (perio.perio_otrosBio3 == null)
                        {
                            ckb_otrosBiologico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosBiologico3.Checked = true;

                        }
                        //----------- Ergonomico -----------
                        if (perio.perio_maneManCarErg == null)
                        {
                            ckb_manmanualcargas.Checked = false;
                        }
                        else
                        {
                            ckb_manmanualcargas.Checked = true;

                        }
                        if (perio.perio_maneManCarErg2 == null)
                        {
                            ckb_manmanualcargas2.Checked = false;
                        }
                        else
                        {
                            ckb_manmanualcargas2.Checked = true;

                        }
                        if (perio.perio_maneManCarErg3 == null)
                        {
                            ckb_manmanualcargas3.Checked = false;
                        }
                        else
                        {
                            ckb_manmanualcargas3.Checked = true;

                        }
                        if (perio.perio_movRepeErg == null)
                        {
                            ckb_movrepetitivo.Checked = false;
                        }
                        else
                        {
                            ckb_movrepetitivo.Checked = true;
                        }
                        if (perio.perio_movRepeErg2 == null)
                        {
                            ckb_movrepetitivo2.Checked = false;
                        }
                        else
                        {
                            ckb_movrepetitivo2.Checked = true;
                        }
                        if (perio.perio_movRepeErg3 == null)
                        {
                            ckb_movrepetitivo3.Checked = false;
                        }
                        else
                        {
                            ckb_movrepetitivo3.Checked = true;
                        }
                        if (perio.perio_posForzaErg == null)
                        {
                            ckb_postforzadas.Checked = false;
                        }
                        else
                        {
                            ckb_postforzadas.Checked = true;
                        }
                        if (perio.perio_posForzaErg2 == null)
                        {
                            ckb_postforzadas2.Checked = false;
                        }
                        else
                        {
                            ckb_postforzadas2.Checked = true;
                        }
                        if (perio.perio_posForzaErg3 == null)
                        {
                            ckb_postforzadas3.Checked = false;
                        }
                        else
                        {
                            ckb_postforzadas3.Checked = true;
                        }
                        if (perio.perio_trabPvdErg == null)
                        {
                            ckb_trabajopvd.Checked = false;
                        }
                        else
                        {
                            ckb_trabajopvd.Checked = true;

                        }
                        if (perio.perio_trabPvdErg2 == null)
                        {
                            ckb_trabajopvd2.Checked = false;
                        }
                        else
                        {
                            ckb_trabajopvd2.Checked = true;

                        }
                        if (perio.perio_trabPvdErg3 == null)
                        {
                            ckb_trabajopvd3.Checked = false;
                        }
                        else
                        {
                            ckb_trabajopvd3.Checked = true;

                        }
                        if (perio.perio_otrosErg == null)
                        {
                            ckb_otrosErgonomico.Checked = false;
                        }
                        else
                        {
                            ckb_otrosErgonomico.Checked = true;

                        }
                        if (perio.perio_otrosErg2 == null)
                        {
                            ckb_otrosErgonomico2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosErgonomico2.Checked = true;

                        }
                        if (perio.perio_otrosErg3 == null)
                        {
                            ckb_otrosErgonomico3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosErgonomico3.Checked = true;

                        }
                        //----------- Psicosocial -----------
                        if (perio.perio_monoTrabPsi == null)
                        {
                            ckb_montrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_montrabajo.Checked = true;

                        }
                        if (perio.perio_monoTrabPsi2 == null)
                        {
                            ckb_montrabajo2.Checked = false;
                        }
                        else
                        {
                            ckb_montrabajo2.Checked = true;

                        }
                        if (perio.perio_monoTrabPsi3 == null)
                        {
                            ckb_montrabajo3.Checked = false;
                        }
                        else
                        {
                            ckb_montrabajo3.Checked = true;

                        }
                        if (perio.perio_sobrecarLabPsi == null)
                        {
                            ckb_sobrecargalaboral.Checked = false;
                        }
                        else
                        {
                            ckb_sobrecargalaboral.Checked = true;

                        }
                        if (perio.perio_sobrecarLabPsi2 == null)
                        {
                            ckb_sobrecargalaboral2.Checked = false;
                        }
                        else
                        {
                            ckb_sobrecargalaboral2.Checked = true;

                        }
                        if (perio.perio_sobrecarLabPsi3 == null)
                        {
                            ckb_sobrecargalaboral3.Checked = false;
                        }
                        else
                        {
                            ckb_sobrecargalaboral3.Checked = true;

                        }
                        if (perio.perio_minuTareaPsi == null)
                        {
                            ckb_minustarea.Checked = false;
                        }
                        else
                        {
                            ckb_minustarea.Checked = true;

                        }
                        if (perio.perio_minuTareaPsi2 == null)
                        {
                            ckb_minustarea2.Checked = false;
                        }
                        else
                        {
                            ckb_minustarea2.Checked = true;

                        }
                        if (perio.perio_minuTareaPsi3 == null)
                        {
                            ckb_minustarea3.Checked = false;
                        }
                        else
                        {
                            ckb_minustarea3.Checked = true;

                        }
                        if (perio.perio_altaResponPsi == null)
                        {
                            ckb_altarespon.Checked = false;
                        }
                        else
                        {
                            ckb_altarespon.Checked = true;

                        }
                        if (perio.perio_altaResponPsi2 == null)
                        {
                            ckb_altarespon2.Checked = false;
                        }
                        else
                        {
                            ckb_altarespon2.Checked = true;

                        }
                        if (perio.perio_altaResponPsi3 == null)
                        {
                            ckb_altarespon3.Checked = false;
                        }
                        else
                        {
                            ckb_altarespon3.Checked = true;

                        }
                        if (perio.perio_autoTomaDesiPsi == null)
                        {
                            ckb_automadesiciones.Checked = false;
                        }
                        else
                        {
                            ckb_automadesiciones.Checked = true;

                        }
                        if (perio.perio_autoTomaDesiPsi2 == null)
                        {
                            ckb_automadesiciones2.Checked = false;
                        }
                        else
                        {
                            ckb_automadesiciones2.Checked = true;

                        }
                        if (perio.perio_autoTomaDesiPsi3 == null)
                        {
                            ckb_automadesiciones3.Checked = false;
                        }
                        else
                        {
                            ckb_automadesiciones3.Checked = true;

                        }
                        if (perio.perio_supEstDirecDefiPsi == null)
                        {
                            ckb_supyestdireficiente.Checked = false;
                        }
                        else
                        {
                            ckb_supyestdireficiente.Checked = true;

                        }
                        if (perio.perio_supEstDirecDefiPsi2 == null)
                        {
                            ckb_supyestdireficiente2.Checked = false; ;
                        }
                        else
                        {
                            ckb_supyestdireficiente2.Checked = true;

                        }
                        if (perio.perio_supEstDirecDefiPsi3 == null)
                        {
                            ckb_supyestdireficiente3.Checked = false;
                        }
                        else
                        {
                            ckb_supyestdireficiente3.Checked = true;

                        }
                        if (perio.perio_conflicRolPsi == null)
                        {
                            ckb_conflictorol.Checked = false;
                        }
                        else
                        {
                            ckb_conflictorol.Checked = true;

                        }
                        if (perio.perio_conflicRolPsi2 == null)
                        {
                            ckb_conflictorol2.Checked = false;
                        }
                        else
                        {
                            ckb_conflictorol2.Checked = true;

                        }
                        if (perio.perio_conflicRolPsi3 == null)
                        {
                            ckb_conflictorol3.Checked = false;
                        }
                        else
                        {
                            ckb_conflictorol3.Checked = true;

                        }
                        if (perio.perio_falClariFunPsi == null)
                        {
                            ckb_faltaclarfunciones.Checked = false;
                        }
                        else
                        {
                            ckb_faltaclarfunciones.Checked = true;

                        }
                        if (perio.perio_falClariFunPsi2 == null)
                        {
                            ckb_faltaclarfunciones2.Checked = false;
                        }
                        else
                        {
                            ckb_faltaclarfunciones2.Checked = true;

                        }
                        if (perio.perio_falClariFunPsi3 == null)
                        {
                            ckb_faltaclarfunciones3.Checked = false;
                        }
                        else
                        {
                            ckb_faltaclarfunciones3.Checked = true;

                        }
                        if (perio.perio_incoDistriTrabPsi == null)
                        {
                            ckb_incorrdistrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_incorrdistrabajo.Checked = true;

                        }
                        if (perio.perio_incoDistriTrabPsi2 == null)
                        {
                            ckb_incorrdistrabajo2.Checked = false;
                        }
                        else
                        {
                            ckb_incorrdistrabajo2.Checked = true;

                        }
                        if (perio.perio_incoDistriTrabPsi3 == null)
                        {
                            ckb_incorrdistrabajo3.Checked = false;
                        }
                        else
                        {
                            ckb_incorrdistrabajo3.Checked = true;

                        }
                        if (perio.perio_turnosRotaPsi == null)
                        {
                            ckb_turnorotat.Checked = false;
                        }
                        else
                        {
                            ckb_turnorotat.Checked = true;

                        }
                        if (perio.perio_turnosRotaPsi2 == null)
                        {
                            ckb_turnorotat2.Checked = false;
                        }
                        else
                        {
                            ckb_turnorotat2.Checked = true;

                        }
                        if (perio.perio_turnosRotaPsi3 == null)
                        {
                            ckb_turnorotat3.Checked = false;
                        }
                        else
                        {
                            ckb_turnorotat3.Checked = true;

                        }
                        if (perio.perio_relInterperPsi == null)
                        {
                            ckb_relacinterpersonales.Checked = false;
                        }
                        else
                        {
                            ckb_relacinterpersonales.Checked = true;

                        }
                        if (perio.perio_relInterperPsi2 == null)
                        {
                            ckb_relacinterpersonales2.Checked = false;
                        }
                        else
                        {
                            ckb_relacinterpersonales2.Checked = true;

                        }
                        if (perio.perio_relInterperPsi3 == null)
                        {
                            ckb_relacinterpersonales3.Checked = false;
                        }
                        else
                        {
                            ckb_relacinterpersonales3.Checked = true;

                        }
                        if (perio.perio_inesLabPsi == null)
                        {
                            ckb_inestalaboral.Checked = false;
                        }
                        else
                        {
                            ckb_inestalaboral.Checked = true;

                        }
                        if (perio.perio_inesLabPsi2 == null)
                        {
                            ckb_inestalaboral2.Checked = false;
                        }
                        else
                        {
                            ckb_inestalaboral2.Checked = true;

                        }
                        if (perio.perio_inesLabPsi3 == null)
                        {
                            ckb_inestalaboral3.Checked = false;
                        }
                        else
                        {
                            ckb_inestalaboral3.Checked = true;

                        }
                        if (perio.perio_otrosPsi == null)
                        {
                            ckb_otrosPsisocial.Checked = false;
                        }
                        else
                        {
                            ckb_otrosPsisocial.Checked = true;

                        }
                        if (perio.perio_otrosPsi2 == null)
                        {
                            ckb_otrosPsisocial2.Checked = false;
                        }
                        else
                        {
                            ckb_otrosPsisocial2.Checked = true;

                        }
                        if (perio.perio_otrosPsi3 == null)
                        {
                            ckb_otrosPsisocial3.Checked = false;
                        }
                        else
                        {
                            ckb_otrosPsisocial3.Checked = true;

                        }

                        //Revision de Organos y Sistemas
                        if (perio.perio_pielAnexos == null)
                        {
                            ckb_pielanexos.Checked = false;
                        }
                        else
                        {
                            ckb_pielanexos.Checked = true;

                        }
                        if (perio.perio_orgSentidos == null)
                        {
                            ckb_organossentidos.Checked = false;
                        }
                        else
                        {
                            ckb_organossentidos.Checked = true;

                        }
                        if (perio.perio_respiratorio == null)
                        {
                            ckb_respiratorio.Checked = false;
                        }
                        else
                        {
                            ckb_respiratorio.Checked = true;

                        }
                        if (perio.perio_cardVascular == null)
                        {
                            ckb_cardiovascular.Checked = false;
                        }
                        else
                        {
                            ckb_cardiovascular.Checked = true;

                        }
                        if (perio.perio_digestivo == null)
                        {
                            ckb_digestivo.Checked = false;
                        }
                        else
                        {
                            ckb_digestivo.Checked = true;

                        }
                        if (perio.perio_genUrinario == null)
                        {
                            ckb_genitourinario.Checked = false;
                        }
                        else
                        {
                            ckb_genitourinario.Checked = true;

                        }
                        if (perio.perio_muscEsqueletico == null)
                        {
                            ckb_musculosesqueleticos.Checked = false;
                        }
                        else
                        {
                            ckb_musculosesqueleticos.Checked = true;

                        }
                        if (perio.perio_endocrino == null)
                        {
                            ckb_endocrino.Checked = false;
                        }
                        else
                        {
                            ckb_endocrino.Checked = true;

                        }
                        if (perio.perio_hemoLimfa == null)
                        {
                            ckb_hemolinfatico.Checked = false;
                        }
                        else
                        {
                            ckb_hemolinfatico.Checked = true;

                        }
                        if (perio.perio_nervioso == null)
                        {
                            ckb_nervioso.Checked = false;
                        }
                        else
                        {
                            ckb_nervioso.Checked = true;

                        }

                        //Regiones
                        if (perio.perio_cicatricesPiel == null)
                        {
                            ckb_cicatrices.Checked = false;
                        }
                        else
                        {
                            ckb_cicatrices.Checked = true;

                        }
                        if (perio.perio_tatuajesPiel == null)
                        {
                            ckb_tatuajes.Checked = false;
                        }
                        else
                        {
                            ckb_tatuajes.Checked = true;

                        }
                        if (perio.perio_pielFacerasPiel == null)
                        {
                            ckb_pielyfaneras.Checked = false;
                        }
                        else
                        {
                            ckb_pielyfaneras.Checked = true;

                        }
                        if (perio.perio_parpadosOjos == null)
                        {
                            ckb_parpados.Checked = false;
                        }
                        else
                        {
                            ckb_parpados.Checked = true;

                        }
                        if (perio.perio_conjuntuvasOjos == null)
                        {
                            ckb_conjuntivas.Checked = false;
                        }
                        else
                        {
                            ckb_conjuntivas.Checked = true;

                        }
                        if (perio.perio_pupilasOjos == null)
                        {
                            ckb_pupilas.Checked = false;
                        }
                        else
                        {
                            ckb_pupilas.Checked = true;

                        }
                        if (perio.perio_corneaOjos == null)
                        {
                            ckb_cornea.Checked = false;
                        }
                        else
                        {
                            ckb_cornea.Checked = true;

                        }
                        if (perio.perio_motilidadOjos == null)
                        {
                            ckb_motilidad.Checked = false;
                        }
                        else
                        {
                            ckb_motilidad.Checked = true;

                        }
                        if (perio.perio_cAudiExtreOido == null)
                        {
                            ckb_auditivoexterno.Checked = false;
                        }
                        else
                        {
                            ckb_auditivoexterno.Checked = true;

                        }
                        if (perio.perio_pabellonOido == null)
                        {
                            ckb_pabellon.Checked = false;
                        }
                        else
                        {
                            ckb_pabellon.Checked = true;

                        }
                        if (perio.perio_timpanosOido == null)
                        {
                            ckb_timpanos.Checked = false;
                        }
                        else
                        {
                            ckb_timpanos.Checked = true;

                        }
                        if (perio.perio_labiosOroFa == null)
                        {
                            ckb_labios.Checked = false;
                        }
                        else
                        {
                            ckb_labios.Checked = true;

                        }
                        if (perio.perio_lenguaOroFa == null)
                        {
                            ckb_lengua.Checked = false;
                        }
                        else
                        {
                            ckb_lengua.Checked = true;

                        }
                        if (perio.perio_faringeOroFa == null)
                        {
                            ckb_faringe.Checked = false;
                        }
                        else
                        {
                            ckb_faringe.Checked = true;

                        }
                        if (perio.perio_amigdalasOroFa == null)
                        {
                            ckb_amigdalas.Checked = false;
                        }
                        else
                        {
                            ckb_amigdalas.Checked = true;

                        }
                        if (perio.perio_dentaduraOroFa == null)
                        {
                            ckb_dentadura.Checked = false;
                        }
                        else
                        {
                            ckb_dentadura.Checked = true;

                        }
                        if (perio.perio_tabiqueNariz == null)
                        {
                            ckb_tabique.Checked = false;
                        }
                        else
                        {
                            ckb_tabique.Checked = true;

                        }
                        if (perio.perio_cornetesNariz == null)
                        {
                            ckb_cornetes.Checked = false;
                        }
                        else
                        {
                            ckb_cornetes.Checked = true;

                        }
                        if (perio.perio_mucosasNariz == null)
                        {
                            ckb_mucosa.Checked = false;
                        }
                        else
                        {
                            ckb_mucosa.Checked = true;

                        }
                        if (perio.perio_senosParanaNariz == null)
                        {
                            ckb_senosparanasales.Checked = false;
                        }
                        else
                        {
                            ckb_senosparanasales.Checked = true;

                        }
                        if (perio.perio_tiroiMasasCuello == null)
                        {
                            ckb_tiroides.Checked = false;
                        }
                        else
                        {
                            ckb_tiroides.Checked = true;

                        }
                        if (perio.perio_movilidadCuello == null)
                        {
                            ckb_movilidad.Checked = false;
                        }
                        else
                        {
                            ckb_movilidad.Checked = true;

                        }
                        if (perio.perio_mamasTorax == null)
                        {
                            ckb_mamas.Checked = false;
                        }
                        else
                        {
                            ckb_mamas.Checked = true;

                        }
                        if (perio.perio_corazonTorax == null)
                        {
                            ckb_corazon.Checked = false;
                        }
                        else
                        {
                            ckb_corazon.Checked = true;

                        }
                        if (perio.perio_pulmonesTorax2 == null)
                        {
                            ckb_pulmones.Checked = false;
                        }
                        else
                        {
                            ckb_pulmones.Checked = true;

                        }
                        if (perio.perio_parriCostalTorax2 == null)
                        {
                            ckb_parrillacostal.Checked = false;
                        }
                        else
                        {
                            ckb_parrillacostal.Checked = true;

                        }
                        if (perio.perio_viscerasAbdomen == null)
                        {
                            ckb_visceras.Checked = false;
                        }
                        else
                        {
                            ckb_visceras.Checked = true;

                        }
                        if (perio.perio_paredAbdomiAbdomen == null)
                        {
                            ckb_paredabdominal.Checked = false;
                        }
                        else
                        {
                            ckb_paredabdominal.Checked = true;

                        }
                        if (perio.perio_flexibilidadColumna == null)
                        {
                            ckb_flexibilidad.Checked = false;
                        }
                        else
                        {
                            ckb_flexibilidad.Checked = true;

                        }
                        if (perio.perio_desviacionColumna == null)
                        {
                            ckb_desviacion.Checked = false;
                        }
                        else
                        {
                            ckb_desviacion.Checked = true;

                        }
                        if (perio.perio_dolorColumna == null)
                        {
                            ckb_dolor.Checked = false;
                        }
                        else
                        {
                            ckb_dolor.Checked = true;

                        }
                        if (perio.perio_pelvisPelvis == null)
                        {
                            ckb_pelvis.Checked = false;
                        }
                        else
                        {
                            ckb_pelvis.Checked = true;

                        }
                        if (perio.perio_genitalesPelvis == null)
                        {
                            ckb_genitales.Checked = false;
                        }
                        else
                        {
                            ckb_genitales.Checked = true;

                        }
                        if (perio.perio_vascularExtre == null)
                        {
                            ckb_vascular.Checked = false;
                        }
                        else
                        {
                            ckb_vascular.Checked = true;

                        }
                        if (perio.perio_miemSupeExtre == null)
                        {
                            ckb_miembrosuperiores.Checked = false;
                        }
                        else
                        {
                            ckb_miembrosuperiores.Checked = true;

                        }
                        if (perio.perio_miemInfeExtre == null)
                        {
                            ckb_miembrosinferiores.Checked = false;
                        }
                        else
                        {
                            ckb_miembrosinferiores.Checked = true;

                        }
                        if (perio.perio_fuerzaNeuro == null)
                        {
                            ckb_fuerza.Checked = false;
                        }
                        else
                        {
                            ckb_fuerza.Checked = true;

                        }
                        if (perio.perio_sensibiNeuro == null)
                        {
                            ckb_sensibilidad.Checked = false;
                        }
                        else
                        {
                            ckb_sensibilidad.Checked = true;

                        }
                        if (perio.perio_marchaNeuro == null)
                        {
                            ckb_marcha.Checked = false;
                        }
                        else
                        {
                            ckb_marcha.Checked = true;

                        }
                        if (perio.perio_refleNeuro == null)
                        {
                            ckb_reflejos.Checked = false;
                        }
                        else
                        {
                            ckb_reflejos.Checked = true;

                        }

                        //Diagnostco
                        if (perio.perio_pre == null)
                        {
                            ckb_pre.Checked = false;
                        }
                        else
                        {
                            ckb_pre.Checked = true;

                        }
                        if (perio.perio_pre2 == null)
                        {
                            ckb_pre2.Checked = false;
                        }
                        else
                        {
                            ckb_pre2.Checked = true;

                        }
                        if (perio.perio_pre3 == null)
                        {
                            ckb_pre3.Checked = false;
                        }
                        else
                        {
                            ckb_pre3.Checked = true;

                        }
                        if (perio.perio_def == null)
                        {
                            ckb_def.Checked = false;
                        }
                        else
                        {
                            ckb_def.Checked = true;

                        }
                        if (perio.perio_def2 == null)
                        {
                            ckb_def2.Checked = false;
                        }
                        else
                        {
                            ckb_def2.Checked = true;

                        }
                        if (perio.perio_def3 == null)
                        {
                            ckb_def3.Checked = false;
                        }
                        else
                        {
                            ckb_def3.Checked = true;

                        }

                        //Aptitud Medica para el trabajo
                        if (perio.perio_apto == null)
                        {
                            ckb_apto.Checked = false;
                        }
                        else
                        {
                            ckb_apto.Checked = true;

                        }
                        if (perio.perio_aptoObserva == null)
                        {
                            ckb_aptoobservacion.Checked = false;
                        }
                        else
                        {
                            ckb_aptoobservacion.Checked = true;

                        }
                        if (perio.perio_aptoLimi == null)
                        {
                            ckb_aptolimitacion.Checked = false;
                        }
                        else
                        {
                            ckb_aptolimitacion.Checked = true;

                        }
                        if (perio.perio_NoApto == null)
                        {
                            ckb_noapto.Checked = false;
                        }
                        else
                        {
                            ckb_noapto.Checked = true;

                        }

                        //A
                        txt_nomEmpresa.Text = emp.Emp_nombre.ToString();
                        //txt_rucEmp.Text = cen.cent_ruc.ToString();
                        txt_priNombre.Text = per.Per_priNombre.ToString();
                        txt_segNombre.Text = per.Per_segNombre.ToString();
                        txt_priApellido.Text = per.Per_priApellido.ToString();
                        txt_segApellido.Text = per.Per_segApellido.ToString();
                        txt_sexo.Text = per.Per_genero.ToString();
                        txt_numHClinica.Text = per.Per_cedula.ToString();
                        txt_puestodetrabajoperiodica.Text = per.Per_puestoTrabajo.ToString();

                        if (perio != null)
                        {
                            //A
                            txt_ciiu.Text = perio.perio_ciiu.ToString();
                            txt_numArchivo.Text = perio.perio_numArchivo.ToString();

                            //B
                            txt_motivoconsultaperiodica.Text = perio.perio_descripMotiConsulta.ToString();

                            //C
                            txt_antCliQuiDescripcion.Text = perio.perio_descripcionAntCliQuirurgicos.ToString();

                            txt_tiemConConsuNociTabaHabToxi.Text = perio.perio_tiempoConsuConsuNocivosTabaco.ToString();
                            txt_cantiConsuNociTabaHabToxi.Text = perio.perio_cantidadConsuNocivosTabaco.ToString();
                            txt_exConsumiConsuNociTabaHabToxi.Text = perio.perio_exConsumiConsuNocivosTabaco.ToString();
                            txt_tiemAbstiConsuNociTabaHabToxi.Text = perio.perio_tiempoAbstiConsuNocivosTabaco.ToString();

                            txt_tiemConConsuNociAlcoHabToxi.Text = perio.perio_tiempoConsuConsuNocivosAlcohol.ToString();
                            txt_cantiConsuNociAlcoHabToxi.Text = perio.perio_cantidadConsuNocivosAlcohol.ToString();
                            txt_exConsumiConsuNociAlcoHabToxi.Text = perio.perio_exConsumiConsuNocivosAlcohol.ToString();
                            txt_tiemAbstiConsuNociAlcoHabToxi.Text = perio.perio_tiempoAbstiConsuNocivosAlcohol.ToString();

                            txt_tiemCon1ConsuNociOtrasDroHabToxi.Text = perio.perio_tiempoConsu1ConsuNocivosOtrasDrogas.ToString();
                            txt_canti1ConsuNociOtrasDroHabToxi.Text = perio.perio_cantidad1ConsuNocivosOtrasDrogas.ToString();
                            txt_exConsumi1ConsuNociOtrasDroHabToxi.Text = perio.perio_exConsumi1ConsuNocivosOtrasDrogas.ToString();
                            txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text = perio.perio_tiempoAbsti1ConsuNocivosOtrasDrogas.ToString();
                            txt_otrasConsuNociOtrasDroHabToxi.Text = perio.perio_otrasConsuNocivos.ToString();
                            txt_tiemCon2ConsuNociOtrasDroHabToxi.Text = perio.perio_tiempoConsu2ConsuNocivosOtrasDrogas.ToString();
                            txt_canti2ConsuNociOtrasDroHabToxi.Text = perio.perio_cantidad2ConsuNocivosOtrasDrogas.ToString();
                            txt_exConsumi2ConsuNociOtrasDroHabToxi.Text = perio.perio_exConsumi2ConsuNocivosOtrasDrogas.ToString();
                            txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text = perio.perio_tiempoAbsti2ConsuNocivosOtrasDrogas.ToString();

                            txt_cualEstVidaActFisiEstVida.Text = perio.perio_cualEstiVidaActFisica.ToString();
                            txt_tiemCanEstVidaActFisiEstVida.Text = perio.perio_tiem_cantEstiVidaActFisica.ToString();
                            txt_cual1EstVidaMedHabiEstVida.Text = perio.perio_cual1EstiVidaMediHabitual.ToString();
                            txt_tiemCan1EstVidaMedHabiEstVida.Text = perio.perio_tiem_cant1EstiVidaMediHabitual.ToString();
                            txt_cual2EstVidaMedHabiEstVida.Text = perio.perio_cual2EstiVidaMediHabitual.ToString();
                            txt_tiemCan2EstVidaMedHabiEstVida.Text = perio.perio_tiem_cant2EstiVidaMediHabitual.ToString();
                            txt_cual3EstVidaMedHabiEstVida.Text = perio.perio_cual3EstiVidaMediHabitual.ToString();
                            txt_tiemCan3EstVidaMedHabiEstVida.Text = perio.perio_tiem_cant3EstiVidaMediHabitual.ToString();

                            txt_incidentesperiodica.Text = perio.perio_descripIncidentes.ToString();

                            txt_especificarcalificadotrabajo.Text = perio.perio_EspecifiCalificadoIESSAcciTrabajo.ToString();
                            if (perio.perio_fechaCalificadoIESSAcciTrabajo == "")
                            {
                                txt_fechacalificadotrabajo.Text = perio.perio_fechaCalificadoIESSAcciTrabajo.ToString();
                            }
                            else
                            {
                                txt_fechacalificadotrabajo.Text = Convert.ToDateTime(perio.perio_fechaCalificadoIESSAcciTrabajo).ToString("yyyy-MM-dd");
                            }
                            txt_obsercalificadotrabajo.Text = perio.perio_observacionesAcciTrabajo.ToString();

                            txt_especificarcalificadoprofesional.Text = perio.perio_EspecifiCalificadoIESSEnferProfesionales.ToString();
                            if (perio.perio_fechaCalificadoIESSEnferProfesionales == "")
                            {
                                txt_fechacalificadoprofesional.Text = perio.perio_fechaCalificadoIESSEnferProfesionales.ToString();
                            }
                            else
                            {
                                txt_fechacalificadoprofesional.Text = Convert.ToDateTime(perio.perio_fechaCalificadoIESSEnferProfesionales).ToString("yyyy-MM-dd");
                            }
                            txt_obsercalificadoprofesional.Text = perio.perio_observacionesEnferProfesionales.ToString();

                            //D
                            txt_descripcionantefamiliares.Text = perio.perio_descripcionAntFamiliares.ToString();

                            //E
                            txt_puestotrabajo.Text = perio.perio_area.ToString();
                            txt_puestotrabajo2.Text = perio.perio_area2.ToString();
                            txt_puestotrabajo3.Text = perio.perio_area3.ToString();
                            txt_act.Text = perio.perio_actividades.ToString();
                            txt_act2.Text = perio.perio_actividades2.ToString();
                            txt_act3.Text = perio.perio_actividades3.ToString();
                            txt_tiempotrabajo.Text = perio.perio_tiemTrabajo.ToString();
                            txt_tiempotrabajo2.Text = perio.perio_tiemTrabajo2.ToString();
                            txt_tiempotrabajo3.Text = perio.perio_tiemTrabajo3.ToString();
                            txt_medpreventivas.Text = perio.perio_medPreventivas.ToString();
                            txt_medpreventivas2.Text = perio.perio_medPreventivas2.ToString();
                            txt_medpreventivas3.Text = perio.perio_medPreventivas3.ToString();

                            //F
                            txt_enfermedadactualperiodica.Text = perio.perio_descripEnfActual.ToString();

                            //G                            
                            txt_descrorganosysistemasperiodica.Text = perio.perio_descripRevOrgaSistemas.ToString();

                            //H
                            txt_preArterial.Text = perio.perio_preArterial.ToString();
                            txt_temperatura.Text = perio.perio_temperatura.ToString();
                            txt_freCardica.Text = perio.perio_frecCardiacan.ToString();
                            txt_satOxigeno.Text = perio.perio_satOxigenon.ToString();
                            txt_freRespiratoria.Text = perio.perio_frecRespiratorian.ToString();
                            txt_peso.Text = perio.perio_peson.ToString();
                            txt_talla.Text = perio.perio_tallan.ToString();
                            txt_indMasCorporal.Text = perio.perio_indMasCorporaln.ToString();
                            txt_perAbdominal.Text = perio.perio_perAbdominaln.ToString();

                            //I                            
                            txt_observexamenfisicoregional.Text = perio.perio_observaExaFisRegional.ToString();

                            //J
                            txt_examen.Text = perio.perio_examen.ToString();
                            txt_examen2.Text = perio.perio_examen2.ToString();
                            if (perio.perio_fecha == "")
                            {
                                txt_fechaexamen.Text = perio.perio_fecha.ToString();
                            }
                            else
                            {
                                txt_fechaexamen.Text = Convert.ToDateTime(perio.perio_fecha).ToString("yyyy-MM-dd");
                            }
                            if (perio.perio_fecha2 == "")
                            {
                                txt_fechaexamen2.Text = perio.perio_fecha2.ToString();
                            }
                            else
                            {
                                txt_fechaexamen2.Text = Convert.ToDateTime(perio.perio_fecha2).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen.Text = perio.perio_resultado.ToString();
                            txt_resultadoexamen2.Text = perio.perio_resultado2.ToString();
                            txt_observacionexamen.Text = perio.perio_observacionesResExaGenEspPuesTrabajo.ToString();

                            //K
                            txt_descripdiagnostico.Text = perio.perio_descripcionDiagnostico.ToString();
                            txt_descripdiagnostico2.Text = perio.perio_descripcionDiagnostico2.ToString();
                            txt_descripdiagnostico3.Text = perio.perio_descripcionDiagnostico3.ToString();
                            txt_cie.Text = perio.perio_cie.ToString();
                            txt_cie2.Text = perio.perio_cie2.ToString();
                            txt_cie3.Text = perio.perio_cie3.ToString();

                            //L                            
                            txt_observacionaptitud.Text = perio.perio_ObservAptMedTrabajo.ToString();
                            txt_limitacionaptitud.Text = perio.perio_LimitAptMedTrabajo.ToString();

                            //M
                            txt_descripciontratamientoperiodica.Text = perio.perio_descripcionRecoTratamiento.ToString();

                            //N                           
                            ddl_profesional.SelectedValue = perio.prof_id.ToString();
                            txt_codigoDatProf.Text = perio.perio_cod.ToString();
                        }
                    }
                }
                txt_numHClinica.MaxLength = 10;
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
                txt_tiempotrabajo21.MaxLength = 2;
                txt_tiempotrabajo22.MaxLength = 2;
                txt_tiempotrabajo23.MaxLength = 2;

                Timer1.Enabled = false;
                cargarProfesional();
                defaultValidaciones();

                txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");

            }
        }

        //protected void timerFechaHora_Tick(object sender, EventArgs e)
        //{
        //    if (perio.perio_fecha_hora == null)
        //    {
        //        txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
        //    }
        //}

        //Metodo obtener cedula por numero de HC PERIODICA
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

                    string puestoTrabajo = item.Per_puestoTrabajo;
                    txt_puestodetrabajoperiodica.Text = puestoTrabajo;
                }
            }
            else
            {
                txt_nomEmpresa.Text = txt_rucEmp.Text = txt_priNombre.Text = txt_segNombre.Text = txt_priApellido.Text = txt_segApellido.Text = txt_sexo.Text = txt_puestodetrabajoperiodica.Text = string.Empty;
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

        protected void txt_descripdiagnostico2_TextChanged(object sender, EventArgs e)
        {
            ObtenerCodigo2();
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

        protected void txt_descripdiagnostico3_TextChanged(object sender, EventArgs e)
        {
            ObtenerCodigo3();
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

        private void GuardarPeriodica()
        {

            try
            {
                per = CN_HistorialMedico.ObtenerIdPersonasxCedula(txt_numHClinica.Text);
                int perso = Convert.ToInt32(per.Per_id.ToString());

                per = CN_HistorialMedico.ObtenerIdEmpresaxCedula(txt_numHClinica.Text);
                int empre = Convert.ToInt32(per.Emp_id.ToString());

                perio = new Tbl_Periodica();



                //Habitos Toxicos
                if (ckb_siConsuNociTabaHabToxi.Checked == true)
                {
                    perio.perio_siConsuNocivosTabaco = "SI";
                }
                if (ckb_noConsuNociTabaHabToxi.Checked == true)
                {
                    perio.perio_noConsuNocivosTabaco = "SI";
                }
                if (ckb_siConsuNociAlcoHabToxi.Checked == true)
                {
                    perio.perio_siConsuNocivosAlcohol = "SI";
                }
                if (ckb_noConsuNociAlcoHabToxi.Checked == true)
                {
                    perio.perio_noConsuNocivosAlcohol = "SI";
                }
                if (ckb_siConsuNociOtrasDroHabToxi.Checked == true)
                {
                    perio.perio_siConsuNocivosOtrasDrogas = "SI";
                }
                if (ckb_noConsuNociOtrasDroHabToxi.Checked == true)
                {
                    perio.perio_noConsuNocivosOtrasDrogas = "SI";
                }

                //Estilo de Vida
                if (ckb_siEstVidaActFisiEstVida.Checked == true)
                {
                    perio.perio_siEstiVidaActFisica = "SI";
                }
                if (ckb_noEstVidaActFisiEstVida.Checked == true)
                {
                    perio.perio_noEstiVidaActFisica = "SI";
                }
                if (ckb_siEstVidaMedHabiEstVida.Checked == true)
                {
                    perio.perio_siEstiVidaMediHabitual = "SI";
                }
                if (ckb_noEstVidaMedHabiEstVida.Checked == true)
                {
                    perio.perio_noEstiVidaMediHabitual = "SI";
                }

                //Accidentes de Trabajo (Descripcion)
                if (ckb_sicalificadotrabajo.Checked == true)
                {
                    perio.perio_siCalificadoIESSAcciTrabajo = "SI";
                }
                if (ckb_nocalificadotrabajo.Checked == true)
                {
                    perio.perio_noCalificadoIESSAcciTrabajo = "SI";
                }

                //Enfermedades Profesionales
                if (ckb_sicalificadoprofesional.Checked == true)
                {
                    perio.perio_siCalificadoIESSEnferProfesionales = "SI";
                }
                if (ckb_nocalificadoprofesional.Checked == true)
                {
                    perio.perio_noCalificadoIESSEnferProfesionales = "SI";
                }

                //Antecedentes familiares (Detallar el Parentesco)
                if (ckb_enfermedadcardiovascular.Checked == true)
                {
                    perio.perio_cardVascular = "SI";
                }
                if (ckb_enfermedadmetabolica.Checked == true)
                {
                    perio.perio_enfMeta = "SI";
                }
                if (ckb_enfermedadneurologica.Checked == true)
                {
                    perio.perio_enfNeuro = "SI";
                }
                if (ckb_enfermedadoncologica.Checked == true)
                {
                    perio.perio_enfOnco = "SI";
                }
                if (ckb_enfermedadinfecciosa.Checked == true)
                {
                    perio.perio_enfInfe = "SI";
                }
                if (ckb_enfermedadhereditaria.Checked == true)
                {
                    perio.perio_enfHereConge = "SI";
                }
                if (ckb_discapacidades.Checked == true)
                {
                    perio.perio_discapa = "SI";
                }
                if (ckb_otrosenfer.Checked == true)
                {
                    perio.perio_otros = "SI";
                }

                //Factores de riesgo del puesto de trabajo
                //----------- Fisico -----------
                if (ckb_tempaltas.Checked == true)
                {
                    perio.perio_temAltasFis = "SI";
                }
                if (ckb_tempaltas2.Checked == true)
                {
                    perio.perio_temAltasFis2 = "SI";
                }
                if (ckb_tempaltas3.Checked == true)
                {
                    perio.perio_temAltasFis3 = "SI";
                }
                if (ckb_tempbajas.Checked == true)
                {
                    perio.perio_temBajasFis = "SI";
                }
                if (ckb_tempbajas2.Checked == true)
                {
                    perio.perio_temBajasFis2 = "SI";
                }
                if (ckb_tempbajas3.Checked == true)
                {
                    perio.perio_temBajasFis3 = "SI";
                }
                if (ckb_radiacion.Checked == true)
                {
                    perio.perio_radIonizanteFis = "SI";
                }
                if (ckb_radiacion2.Checked == true)
                {
                    perio.perio_radIonizanteFis2 = "SI";
                }
                if (ckb_radiacion3.Checked == true)
                {
                    perio.perio_radIonizanteFis3 = "SI";
                }
                if (ckb_noradiacion.Checked == true)
                {
                    perio.perio_radNoIonizanteFis = "SI";
                }
                if (ckb_noradiacion2.Checked == true)
                {
                    perio.perio_radNoIonizanteFis2 = "SI";
                }
                if (ckb_noradiacion3.Checked == true)
                {
                    perio.perio_radNoIonizanteFis3 = "SI";
                }
                if (ckb_ruido.Checked == true)
                {
                    perio.perio_ruidoFis = "SI";
                }
                if (ckb_ruido2.Checked == true)
                {
                    perio.perio_ruidoFis2 = "SI";
                }
                if (ckb_ruido3.Checked == true)
                {
                    perio.perio_ruidoFis3 = "SI";
                }
                if (ckb_vibracion.Checked == true)
                {
                    perio.perio_vibracionFis = "SI";
                }
                if (ckb_vibracion2.Checked == true)
                {
                    perio.perio_vibracionFis2 = "SI";
                }
                if (ckb_vibracion3.Checked == true)
                {
                    perio.perio_vibracionFis3 = "SI";
                }
                if (ckb_iluminacion.Checked == true)
                {
                    perio.perio_iluminacionFis = "SI";
                }
                if (ckb_iluminacion2.Checked == true)
                {
                    perio.perio_iluminacionFis2 = "SI";
                }
                if (ckb_iluminacion3.Checked == true)
                {
                    perio.perio_iluminacionFis3 = "SI";
                }
                if (ckb_ventilacion.Checked == true)
                {
                    perio.perio_ventilacionFis = "SI";
                }
                if (ckb_ventilacion2.Checked == true)
                {
                    perio.perio_ventilacionFis2 = "SI";
                }
                if (ckb_ventilacion3.Checked == true)
                {
                    perio.perio_ventilacionFis3 = "SI";
                }
                if (ckb_fluidoelectrico.Checked == true)
                {
                    perio.perio_fluElectricoFis = "SI";
                }
                if (ckb_fluidoelectrico2.Checked == true)
                {
                    perio.perio_fluElectricoFis2 = "SI";
                }
                if (ckb_fluidoelectrico3.Checked == true)
                {
                    perio.perio_fluElectricoFis3 = "SI";
                }
                if (ckb_otrosFisico.Checked == true)
                {
                    perio.perio_otrosFis = "SI";
                }
                if (ckb_otrosFisico2.Checked == true)
                {
                    perio.perio_otrosFis2 = "SI";
                }
                if (ckb_otrosFisico3.Checked == true)
                {
                    perio.perio_otrosFis3 = "SI";
                }
                //----------- Mecanico -----------
                if (ckb_atrapmaquinas.Checked == true)
                {
                    perio.perio_atraMaquinasMec = "SI";
                }
                if (ckb_atrapmaquinas2.Checked == true)
                {
                    perio.perio_atraMaquinasMec2 = "SI";
                }
                if (ckb_atrapmaquinas3.Checked == true)
                {
                    perio.perio_atraMaquinasMec3 = "SI";
                }
                if (ckb_atrapsuperficie.Checked == true)
                {
                    perio.perio_atraSuperfiiesMec = "SI";
                }
                if (ckb_atrapsuperficie2.Checked == true)
                {
                    perio.perio_atraSuperfiiesMec2 = "SI";
                }
                if (ckb_atrapsuperficie3.Checked == true)
                {
                    perio.perio_atraSuperfiiesMec3 = "SI";
                }
                if (ckb_atrapobjetos.Checked == true)
                {
                    perio.perio_atraObjetosMec = "SI";
                }
                if (ckb_atrapobjetos2.Checked == true)
                {
                    perio.perio_atraObjetosMec2 = "SI";
                }
                if (ckb_atrapobjetos3.Checked == true)
                {
                    perio.perio_atraObjetosMec3 = "SI";
                }
                if (ckb_caidaobjetos.Checked == true)
                {
                    perio.perio_caidaObjetosMec = "SI";
                }
                if (ckb_caidaobjetos2.Checked == true)
                {
                    perio.perio_caidaObjetosMec2 = "SI";
                }
                if (ckb_caidaobjetos3.Checked == true)
                {
                    perio.perio_caidaObjetosMec3 = "SI";
                }
                if (ckb_caidamisnivel.Checked == true)
                {
                    perio.perio_caidaMisNivelMec = "SI";
                }
                if (ckb_caidamisnivel2.Checked == true)
                {
                    perio.perio_caidaMisNivelMec2 = "SI";
                }
                if (ckb_caidamisnivel3.Checked == true)
                {
                    perio.perio_caidaMisNivelMec3 = "SI";
                }
                if (ckb_caidadifnivel.Checked == true)
                {
                    perio.perio_caidaDifNivelMec = "SI";
                }
                if (ckb_caidadifnivel2.Checked == true)
                {
                    perio.perio_caidaDifNivelMec2 = "SI";
                }
                if (ckb_caidadifnivel3.Checked == true)
                {
                    perio.perio_caidaDifNivelMec3 = "SI";
                }
                if (ckb_contaelectrico.Checked == true)
                {
                    perio.perio_contactoElecMec = "SI";
                }
                if (ckb_contaelectrico2.Checked == true)
                {
                    perio.perio_contactoElecMec2 = "SI";
                }
                if (ckb_contaelectrico3.Checked == true)
                {
                    perio.perio_contactoElecMec3 = "SI";
                }
                if (ckb_contasuptrabajo.Checked == true)
                {
                    perio.perio_conSuperTrabaMec = "SI";
                }
                if (ckb_contasuptrabajo2.Checked == true)
                {
                    perio.perio_conSuperTrabaMec2 = "SI";
                }
                if (ckb_contasuptrabajo3.Checked == true)
                {
                    perio.perio_conSuperTrabaMec3 = "SI";
                }
                if (ckb_proyparticulas.Checked == true)
                {
                    perio.perio_proPartiFragMec = "SI";
                }
                if (ckb_proyparticulas2.Checked == true)
                {
                    perio.perio_proPartiFragMec2 = "SI";
                }
                if (ckb_proyparticulas3.Checked == true)
                {
                    perio.perio_proPartiFragMec3 = "SI";
                }
                if (ckb_proyefluidos.Checked == true)
                {
                    perio.perio_proFluidosMec = "SI";
                }
                if (ckb_proyefluidos2.Checked == true)
                {
                    perio.perio_proFluidosMec2 = "SI";
                }
                if (ckb_proyefluidos3.Checked == true)
                {
                    perio.perio_proFluidosMec3 = "SI";
                }
                if (ckb_pinchazos.Checked == true)
                {
                    perio.perio_pinchazosMec = "SI";
                }
                if (ckb_pinchazos2.Checked == true)
                {
                    perio.perio_pinchazosMec2 = "SI";
                }
                if (ckb_pinchazos3.Checked == true)
                {
                    perio.perio_pinchazosMec3 = "SI";
                }
                if (ckb_cortes.Checked == true)
                {
                    perio.perio_cortesMec = "SI";
                }
                if (ckb_cortes2.Checked == true)
                {
                    perio.perio_cortesMec2 = "SI";
                }
                if (ckb_cortes3.Checked == true)
                {
                    perio.perio_cortesMec3 = "SI";
                }
                if (ckb_atroporvehiculos.Checked == true)
                {
                    perio.perio_atropeVehiMec = "SI";
                }
                if (ckb_atroporvehiculos2.Checked == true)
                {
                    perio.perio_atropeVehiMec2 = "SI";
                }
                if (ckb_atroporvehiculos3.Checked == true)
                {
                    perio.perio_atropeVehiMec3 = "SI";
                }
                if (ckb_choques.Checked == true)
                {
                    perio.perio_coliVehiMec = "SI";
                }
                if (ckb_choques2.Checked == true)
                {
                    perio.perio_coliVehiMec2 = "SI";
                }
                if (ckb_choques3.Checked == true)
                {
                    perio.perio_coliVehiMec3 = "SI";
                }
                if (ckb_otrosMecanico.Checked == true)
                {
                    perio.perio_otrosMec = "SI";
                }
                if (ckb_otrosMecanico2.Checked == true)
                {
                    perio.perio_otrosMec2 = "SI";
                }
                if (ckb_otrosMecanico3.Checked == true)
                {
                    perio.perio_otrosMec3 = "SI";
                }
                //----------- Quimico -----------
                if (ckb_solidos.Checked == true)
                {
                    perio.perio_solidosQui = "SI";
                }
                if (ckb_solidos2.Checked == true)
                {
                    perio.perio_solidosQui2 = "SI";
                }
                if (ckb_solidos3.Checked == true)
                {
                    perio.perio_solidosQui3 = "SI";
                }
                if (ckb_polvos.Checked == true)
                {
                    perio.perio_polvosQui = "SI";
                }
                if (ckb_polvos2.Checked == true)
                {
                    perio.perio_polvosQui2 = "SI";
                }
                if (ckb_polvos3.Checked == true)
                {
                    perio.perio_polvosQui3 = "SI";
                }
                if (ckb_humos.Checked == true)
                {
                    perio.perio_humosQui = "SI";
                }
                if (ckb_humos2.Checked == true)
                {
                    perio.perio_humosQui2 = "SI";
                }
                if (ckb_humos3.Checked == true)
                {
                    perio.perio_humosQui3 = "SI";
                }
                if (ckb_liquidos.Checked == true)
                {
                    perio.perio_liquidosQui = "SI";
                }
                if (ckb_liquidos2.Checked == true)
                {
                    perio.perio_liquidosQui2 = "SI";
                }
                if (ckb_liquidos3.Checked == true)
                {
                    perio.perio_liquidosQui3 = "SI";
                }
                if (ckb_vapores.Checked == true)
                {
                    perio.perio_vaporesQui = "SI";
                }
                if (ckb_vapores2.Checked == true)
                {
                    perio.perio_vaporesQui2 = "SI";
                }
                if (ckb_vapores3.Checked == true)
                {
                    perio.perio_vaporesQui3 = "SI";
                }
                if (ckb_aerosoles.Checked == true)
                {
                    perio.perio_aerosolesQui = "SI";
                }
                if (ckb_aerosoles2.Checked == true)
                {
                    perio.perio_aerosolesQui2 = "SI";
                }
                if (ckb_aerosoles3.Checked == true)
                {
                    perio.perio_aerosolesQui3 = "SI";
                }
                if (ckb_neblinas.Checked == true)
                {
                    perio.perio_neblinasQui = "SI";
                }
                if (ckb_neblinas2.Checked == true)
                {
                    perio.perio_neblinasQui2 = "SI";
                }
                if (ckb_neblinas3.Checked == true)
                {
                    perio.perio_neblinasQui3 = "SI";
                }
                if (ckb_gaseosos.Checked == true)
                {
                    perio.perio_gaseososQui = "SI";
                }
                if (ckb_gaseosos2.Checked == true)
                {
                    perio.perio_gaseososQui2 = "SI";
                }
                if (ckb_gaseosos3.Checked == true)
                {
                    perio.perio_gaseososQui3 = "SI";
                }
                if (ckb_otrosQuimico.Checked == true)
                {
                    perio.perio_otrosQui = "SI";
                }
                if (ckb_otrosQuimico2.Checked == true)
                {
                    perio.perio_otrosQui2 = "SI";
                }
                if (ckb_otrosQuimico3.Checked == true)
                {
                    perio.perio_otrosQui3 = "SI";
                }
                //----------- Biologico -----------
                if (ckb_virus.Checked == true)
                {
                    perio.perio_virusBio = "SI";
                }
                if (ckb_virus2.Checked == true)
                {
                    perio.perio_virusBio2 = "SI";
                }
                if (ckb_virus3.Checked == true)
                {
                    perio.perio_virusBio3 = "SI";
                }
                if (ckb_hongos.Checked == true)
                {
                    perio.perio_hongosBio = "SI";
                }
                if (ckb_hongos2.Checked == true)
                {
                    perio.perio_hongosBio2 = "SI";
                }
                if (ckb_hongos3.Checked == true)
                {
                    perio.perio_hongosBio3 = "SI";
                }
                if (ckb_bacterias.Checked == true)
                {
                    perio.perio_bacteriasBio = "SI";
                }
                if (ckb_bacterias2.Checked == true)
                {
                    perio.perio_bacteriasBio2 = "SI";
                }
                if (ckb_bacterias3.Checked == true)
                {
                    perio.perio_bacteriasBio3 = "SI";
                }
                if (ckb_parasitos.Checked == true)
                {
                    perio.perio_parasitosBio = "SI";
                }
                if (ckb_parasitos2.Checked == true)
                {
                    perio.perio_parasitosBio2 = "SI";
                }
                if (ckb_parasitos3.Checked == true)
                {
                    perio.perio_parasitosBio3 = "SI";
                }
                if (ckb_expoavectores.Checked == true)
                {
                    perio.perio_expVectBio = "SI";
                }
                if (ckb_expoavectores2.Checked == true)
                {
                    perio.perio_expVectBio2 = "SI";
                }
                if (ckb_expoavectores3.Checked == true)
                {
                    perio.perio_expVectBio3 = "SI";
                }
                if (ckb_expoanimselvaticos.Checked == true)
                {
                    perio.perio_expAniSelvaBio = "SI";
                }
                if (ckb_expoanimselvaticos2.Checked == true)
                {
                    perio.perio_expAniSelvaBio2 = "SI";
                }
                if (ckb_expoanimselvaticos3.Checked == true)
                {
                    perio.perio_expAniSelvaBio3 = "SI";
                }
                if (ckb_otrosBiologico.Checked == true)
                {
                    perio.perio_otrosBio = "SI";
                }
                if (ckb_otrosBiologico2.Checked == true)
                {
                    perio.perio_otrosBio2 = "SI";
                }
                if (ckb_otrosBiologico3.Checked == true)
                {
                    perio.perio_otrosBio3 = "SI";
                }
                //----------- Ergonomico -----------
                if (ckb_manmanualcargas.Checked == true)
                {
                    perio.perio_maneManCarErg = "SI";
                }
                if (ckb_manmanualcargas2.Checked == true)
                {
                    perio.perio_maneManCarErg2 = "SI";
                }
                if (ckb_manmanualcargas3.Checked == true)
                {
                    perio.perio_maneManCarErg3 = "SI";
                }
                if (ckb_movrepetitivo.Checked == true)
                {
                    perio.perio_movRepeErg = "SI";
                }
                if (ckb_movrepetitivo2.Checked == true)
                {
                    perio.perio_movRepeErg2 = "SI";
                }
                if (ckb_movrepetitivo3.Checked == true)
                {
                    perio.perio_movRepeErg3 = "SI";
                }
                if (ckb_postforzadas.Checked == true)
                {
                    perio.perio_posForzaErg = "SI";
                }
                if (ckb_postforzadas2.Checked == true)
                {
                    perio.perio_posForzaErg2 = "SI";
                }
                if (ckb_postforzadas3.Checked == true)
                {
                    perio.perio_posForzaErg3 = "SI";
                }
                if (ckb_trabajopvd.Checked == true)
                {
                    perio.perio_trabPvdErg = "SI";
                }
                if (ckb_trabajopvd2.Checked == true)
                {
                    perio.perio_trabPvdErg2 = "SI";
                }
                if (ckb_trabajopvd3.Checked == true)
                {
                    perio.perio_trabPvdErg3 = "SI";
                }
                if (ckb_otrosErgonomico.Checked == true)
                {
                    perio.perio_otrosErg = "SI";
                }
                if (ckb_otrosErgonomico2.Checked == true)
                {
                    perio.perio_otrosErg2 = "SI";
                }
                if (ckb_otrosErgonomico3.Checked == true)
                {
                    perio.perio_otrosErg3 = "SI";
                }
                //----------- Psicosocial -----------
                if (ckb_montrabajo.Checked == true)
                {
                    perio.perio_monoTrabPsi = "SI";
                }
                if (ckb_montrabajo2.Checked == true)
                {
                    perio.perio_monoTrabPsi2 = "SI";
                }
                if (ckb_montrabajo3.Checked == true)
                {
                    perio.perio_monoTrabPsi3 = "SI";
                }
                if (ckb_sobrecargalaboral.Checked == true)
                {
                    perio.perio_sobrecarLabPsi = "SI";
                }
                if (ckb_sobrecargalaboral2.Checked == true)
                {
                    perio.perio_sobrecarLabPsi2 = "SI";
                }
                if (ckb_sobrecargalaboral3.Checked == true)
                {
                    perio.perio_sobrecarLabPsi3 = "SI";
                }
                if (ckb_minustarea.Checked == true)
                {
                    perio.perio_minuTareaPsi = "SI";
                }
                if (ckb_minustarea2.Checked == true)
                {
                    perio.perio_minuTareaPsi2 = "SI";
                }
                if (ckb_minustarea3.Checked == true)
                {
                    perio.perio_minuTareaPsi3 = "SI";
                }
                if (ckb_altarespon.Checked == true)
                {
                    perio.perio_altaResponPsi = "SI";
                }
                if (ckb_altarespon2.Checked == true)
                {
                    perio.perio_altaResponPsi2 = "SI";
                }
                if (ckb_altarespon3.Checked == true)
                {
                    perio.perio_altaResponPsi3 = "SI";
                }
                if (ckb_automadesiciones.Checked == true)
                {
                    perio.perio_autoTomaDesiPsi = "SI";
                }
                if (ckb_automadesiciones2.Checked == true)
                {
                    perio.perio_autoTomaDesiPsi2 = "SI";
                }
                if (ckb_automadesiciones3.Checked == true)
                {
                    perio.perio_autoTomaDesiPsi3 = "SI";
                }
                if (ckb_supyestdireficiente.Checked == true)
                {
                    perio.perio_supEstDirecDefiPsi = "SI";
                }
                if (ckb_supyestdireficiente2.Checked == true)
                {
                    perio.perio_supEstDirecDefiPsi2 = "SI";
                }
                if (ckb_supyestdireficiente3.Checked == true)
                {
                    perio.perio_supEstDirecDefiPsi3 = "SI";
                }
                if (ckb_conflictorol.Checked == true)
                {
                    perio.perio_conflicRolPsi = "SI";
                }
                if (ckb_conflictorol2.Checked == true)
                {
                    perio.perio_conflicRolPsi2 = "SI";
                }
                if (ckb_conflictorol3.Checked == true)
                {
                    perio.perio_conflicRolPsi3 = "SI";
                }
                if (ckb_faltaclarfunciones.Checked == true)
                {
                    perio.perio_falClariFunPsi = "SI";
                }
                if (ckb_faltaclarfunciones2.Checked == true)
                {
                    perio.perio_falClariFunPsi2 = "SI";
                }
                if (ckb_faltaclarfunciones3.Checked == true)
                {
                    perio.perio_falClariFunPsi3 = "SI";
                }
                if (ckb_incorrdistrabajo.Checked == true)
                {
                    perio.perio_incoDistriTrabPsi = "SI";
                }
                if (ckb_incorrdistrabajo2.Checked == true)
                {
                    perio.perio_incoDistriTrabPsi2 = "SI";
                }
                if (ckb_incorrdistrabajo3.Checked == true)
                {
                    perio.perio_incoDistriTrabPsi3 = "SI";
                }
                if (ckb_turnorotat.Checked == true)
                {
                    perio.perio_turnosRotaPsi = "SI";
                }
                if (ckb_turnorotat2.Checked == true)
                {
                    perio.perio_turnosRotaPsi2 = "SI";
                }
                if (ckb_turnorotat3.Checked == true)
                {
                    perio.perio_turnosRotaPsi3 = "SI";
                }
                if (ckb_relacinterpersonales.Checked == true)
                {
                    perio.perio_relInterperPsi = "SI";
                }
                if (ckb_relacinterpersonales2.Checked == true)
                {
                    perio.perio_relInterperPsi2 = "SI";
                }
                if (ckb_relacinterpersonales3.Checked == true)
                {
                    perio.perio_relInterperPsi3 = "SI";
                }
                if (ckb_inestalaboral.Checked == true)
                {
                    perio.perio_inesLabPsi = "SI";
                }
                if (ckb_inestalaboral2.Checked == true)
                {
                    perio.perio_inesLabPsi2 = "SI";
                }
                if (ckb_inestalaboral3.Checked == true)
                {
                    perio.perio_inesLabPsi3 = "SI";
                }
                if (ckb_otrosPsisocial.Checked == true)
                {
                    perio.perio_otrosPsi = "SI";
                }
                if (ckb_otrosPsisocial2.Checked == true)
                {
                    perio.perio_otrosPsi2 = "SI";
                }
                if (ckb_otrosPsisocial3.Checked == true)
                {
                    perio.perio_otrosPsi3 = "SI";
                }

                //Revision de Organos y Sistemas
                if (ckb_pielanexos.Checked == true)
                {
                    perio.perio_pielAnexos = "SI";
                }
                if (ckb_organossentidos.Checked == true)
                {
                    perio.perio_orgSentidos = "SI";
                }
                if (ckb_respiratorio.Checked == true)
                {
                    perio.perio_respiratorio = "SI";
                }
                if (ckb_cardiovascular.Checked == true)
                {
                    perio.perio_cardVascular = "SI";
                }
                if (ckb_digestivo.Checked == true)
                {
                    perio.perio_digestivo = "SI";
                }
                if (ckb_genitourinario.Checked == true)
                {
                    perio.perio_genUrinario = "SI";
                }
                if (ckb_musculosesqueleticos.Checked == true)
                {
                    perio.perio_muscEsqueletico = "SI";
                }
                if (ckb_endocrino.Checked == true)
                {
                    perio.perio_endocrino = "SI";
                }
                if (ckb_hemolinfatico.Checked == true)
                {
                    perio.perio_hemoLimfa = "SI";
                }
                if (ckb_nervioso.Checked == true)
                {
                    perio.perio_nervioso = "SI";
                }

                //Regiones
                if (ckb_cicatrices.Checked == true)
                {
                    perio.perio_cicatricesPiel = "SI";
                }
                if (ckb_tatuajes.Checked == true)
                {
                    perio.perio_tatuajesPiel = "SI";
                }
                if (ckb_pielyfaneras.Checked == true)
                {
                    perio.perio_pielFacerasPiel = "SI";
                }
                if (ckb_parpados.Checked == true)
                {
                    perio.perio_parpadosOjos = "SI";
                }
                if (ckb_conjuntivas.Checked == true)
                {
                    perio.perio_conjuntuvasOjos = "SI";
                }
                if (ckb_pupilas.Checked == true)
                {
                    perio.perio_pupilasOjos = "SI";
                }
                if (ckb_cornea.Checked == true)
                {
                    perio.perio_corneaOjos = "SI";
                }
                if (ckb_motilidad.Checked == true)
                {
                    perio.perio_motilidadOjos = "SI";
                }
                if (ckb_auditivoexterno.Checked == true)
                {
                    perio.perio_cAudiExtreOido = "SI";
                }
                if (ckb_pabellon.Checked == true)
                {
                    perio.perio_pabellonOido = "SI";
                }
                if (ckb_timpanos.Checked == true)
                {
                    perio.perio_timpanosOido = "SI";
                }
                if (ckb_labios.Checked == true)
                {
                    perio.perio_labiosOroFa = "SI";
                }
                if (ckb_lengua.Checked == true)
                {
                    perio.perio_lenguaOroFa = "SI";
                }
                if (ckb_faringe.Checked == true)
                {
                    perio.perio_faringeOroFa = "SI";
                }
                if (ckb_amigdalas.Checked == true)
                {
                    perio.perio_amigdalasOroFa = "SI";
                }
                if (ckb_dentadura.Checked == true)
                {
                    perio.perio_dentaduraOroFa = "SI";
                }
                if (ckb_tabique.Checked == true)
                {
                    perio.perio_tabiqueNariz = "SI";
                }
                if (ckb_cornetes.Checked == true)
                {
                    perio.perio_cornetesNariz = "SI";
                }
                if (ckb_mucosa.Checked == true)
                {
                    perio.perio_mucosasNariz = "SI";
                }
                if (ckb_senosparanasales.Checked == true)
                {
                    perio.perio_senosParanaNariz = "SI";
                }
                if (ckb_tiroides.Checked == true)
                {
                    perio.perio_tiroiMasasCuello = "SI";
                }
                if (ckb_movilidad.Checked == true)
                {
                    perio.perio_movilidadCuello = "SI";
                }
                if (ckb_mamas.Checked == true)
                {
                    perio.perio_mamasTorax = "SI";
                }
                if (ckb_corazon.Checked == true)
                {
                    perio.perio_corazonTorax = "SI";
                }
                if (ckb_pulmones.Checked == true)
                {
                    perio.perio_pulmonesTorax2 = "SI";
                }
                if (ckb_parrillacostal.Checked == true)
                {
                    perio.perio_parriCostalTorax2 = "SI";
                }
                if (ckb_visceras.Checked == true)
                {
                    perio.perio_viscerasAbdomen = "SI";
                }
                if (ckb_paredabdominal.Checked == true)
                {
                    perio.perio_paredAbdomiAbdomen = "SI";
                }
                if (ckb_flexibilidad.Checked == true)
                {
                    perio.perio_flexibilidadColumna = "SI";
                }
                if (ckb_desviacion.Checked == true)
                {
                    perio.perio_desviacionColumna = "SI";
                }
                if (ckb_dolor.Checked == true)
                {
                    perio.perio_dolorColumna = "SI";
                }
                if (ckb_pelvis.Checked == true)
                {
                    perio.perio_pelvisPelvis = "SI";
                }
                if (ckb_genitales.Checked == true)
                {
                    perio.perio_genitalesPelvis = "SI";
                }
                if (ckb_vascular.Checked == true)
                {
                    perio.perio_vascularExtre = "SI";
                }
                if (ckb_miembrosuperiores.Checked == true)
                {
                    perio.perio_miemSupeExtre = "SI";
                }
                if (ckb_miembrosinferiores.Checked == true)
                {
                    perio.perio_miemInfeExtre = "SI";
                }
                if (ckb_fuerza.Checked == true)
                {
                    perio.perio_fuerzaNeuro = "SI";
                }
                if (ckb_sensibilidad.Checked == true)
                {
                    perio.perio_sensibiNeuro = "SI";
                }
                if (ckb_marcha.Checked == true)
                {
                    perio.perio_marchaNeuro = "SI";
                }
                if (ckb_reflejos.Checked == true)
                {
                    perio.perio_refleNeuro = "SI";
                }

                //Diagnostco
                if (ckb_pre.Checked == true)
                {
                    perio.perio_pre = "SI";
                }
                if (ckb_pre2.Checked == true)
                {
                    perio.perio_pre2 = "SI";
                }
                if (ckb_pre3.Checked == true)
                {
                    perio.perio_pre3 = "SI";
                }
                if (ckb_def.Checked == true)
                {
                    perio.perio_def = "SI";
                }
                if (ckb_def2.Checked == true)
                {
                    perio.perio_def2 = "SI";
                }
                if (ckb_def3.Checked == true)
                {
                    perio.perio_def3 = "SI";
                }

                //Aptitud Medica para el trabajo
                if (ckb_apto.Checked == true)
                {
                    perio.perio_apto = "SI";
                }
                if (ckb_aptoobservacion.Checked == true)
                {
                    perio.perio_aptoObserva = "SI";
                }
                if (ckb_aptolimitacion.Checked == true)
                {
                    perio.perio_aptoLimi = "SI";
                }
                if (ckb_noapto.Checked == true)
                {
                    perio.perio_NoApto = "SI";
                }

                //A
                perio.perio_ciiu = txt_ciiu.Text.ToUpper();
                perio.perio_numArchivo = txt_numArchivo.Text.ToUpper();

                //B.
                perio.perio_descripMotiConsulta = txt_motivoconsultaperiodica.Text.ToUpper();

                //C.
                perio.perio_descripcionAntCliQuirurgicos = txt_antCliQuiDescripcion.Text.ToUpper();

                perio.perio_tiempoConsuConsuNocivosTabaco = txt_tiemConConsuNociTabaHabToxi.Text.ToUpper();
                perio.perio_cantidadConsuNocivosTabaco = txt_cantiConsuNociTabaHabToxi.Text.ToUpper();
                perio.perio_exConsumiConsuNocivosTabaco = txt_exConsumiConsuNociTabaHabToxi.Text.ToUpper();
                perio.perio_tiempoAbstiConsuNocivosTabaco = txt_tiemAbstiConsuNociTabaHabToxi.Text.ToUpper();

                perio.perio_tiempoConsuConsuNocivosAlcohol = txt_tiemConConsuNociAlcoHabToxi.Text.ToUpper();
                perio.perio_cantidadConsuNocivosAlcohol = txt_cantiConsuNociAlcoHabToxi.Text.ToUpper();
                perio.perio_exConsumiConsuNocivosAlcohol = txt_exConsumiConsuNociAlcoHabToxi.Text.ToUpper();
                perio.perio_tiempoAbstiConsuNocivosAlcohol = txt_tiemAbstiConsuNociAlcoHabToxi.Text.ToUpper();

                perio.perio_tiempoConsu1ConsuNocivosOtrasDrogas = txt_tiemCon1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_cantidad1ConsuNocivosOtrasDrogas = txt_canti1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_exConsumi1ConsuNocivosOtrasDrogas = txt_exConsumi1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_tiempoAbsti1ConsuNocivosOtrasDrogas = txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_otrasConsuNocivos = txt_otrasConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_tiempoConsu2ConsuNocivosOtrasDrogas = txt_tiemCon2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_cantidad2ConsuNocivosOtrasDrogas = txt_canti2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_exConsumi2ConsuNocivosOtrasDrogas = txt_exConsumi2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_tiempoAbsti2ConsuNocivosOtrasDrogas = txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text.ToUpper();

                perio.perio_cualEstiVidaActFisica = txt_cualEstVidaActFisiEstVida.Text.ToUpper();
                perio.perio_tiem_cantEstiVidaActFisica = txt_tiemCanEstVidaActFisiEstVida.Text.ToUpper();

                perio.perio_cual1EstiVidaMediHabitual = txt_cual1EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_tiem_cant1EstiVidaMediHabitual = txt_tiemCan1EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_cual2EstiVidaMediHabitual = txt_cual2EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_tiem_cant2EstiVidaMediHabitual = txt_tiemCan2EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_cual3EstiVidaMediHabitual = txt_cual3EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_tiem_cant3EstiVidaMediHabitual = txt_tiemCan3EstVidaMedHabiEstVida.Text.ToUpper();

                perio.perio_descripIncidentes = txt_incidentesperiodica.Text.ToUpper();

                perio.perio_EspecifiCalificadoIESSAcciTrabajo = txt_especificarcalificadotrabajo.Text.ToUpper();
                perio.perio_fechaCalificadoIESSAcciTrabajo = txt_fechacalificadotrabajo.Text.ToUpper();
                perio.perio_observacionesAcciTrabajo = txt_obsercalificadotrabajo.Text.ToUpper();

                perio.perio_EspecifiCalificadoIESSEnferProfesionales = txt_especificarcalificadoprofesional.Text.ToUpper();
                perio.perio_fechaCalificadoIESSEnferProfesionales = txt_fechacalificadoprofesional.Text.ToUpper();
                perio.perio_observacionesEnferProfesionales = txt_obsercalificadoprofesional.Text.ToUpper();

                //D.
                perio.perio_descripcionAntFamiliares = txt_descripcionantefamiliares.Text.ToUpper();

                //E.
                perio.perio_area = txt_puestotrabajo.Text.ToUpper();
                perio.perio_area2 = txt_puestotrabajo2.Text.ToUpper();
                perio.perio_area3 = txt_puestotrabajo3.Text.ToUpper();
                perio.perio_actividades = txt_act.Text.ToUpper();
                perio.perio_actividades2 = txt_act2.Text.ToUpper();
                perio.perio_actividades3 = txt_act3.Text.ToUpper();
                perio.perio_tiemTrabajo = txt_tiempotrabajo.Text.ToUpper();
                perio.perio_tiemTrabajo2 = txt_tiempotrabajo2.Text.ToUpper();
                perio.perio_tiemTrabajo3 = txt_tiempotrabajo3.Text.ToUpper();
                perio.perio_medPreventivas = txt_medpreventivas.Text.ToUpper();
                perio.perio_medPreventivas2 = txt_medpreventivas2.Text.ToUpper();
                perio.perio_medPreventivas3 = txt_medpreventivas3.Text.ToUpper();

                //F.
                perio.perio_descripEnfActual = txt_enfermedadactualperiodica.Text.ToUpper();

                //G.
                perio.perio_descripRevOrgaSistemas = txt_descrorganosysistemasperiodica.Text.ToUpper();

                //H.
                perio.perio_preArterial = txt_preArterial.Text.ToUpper();
                perio.perio_temperatura = txt_temperatura.Text.ToUpper();
                perio.perio_frecCardiacan = txt_freCardica.Text.ToUpper();
                perio.perio_satOxigenon = txt_satOxigeno.Text.ToUpper();
                perio.perio_frecRespiratorian = txt_freRespiratoria.Text.ToUpper();
                perio.perio_peson = txt_peso.Text.ToUpper();
                perio.perio_tallan = txt_talla.Text.ToUpper();
                perio.perio_indMasCorporaln = txt_indMasCorporal.Text.ToUpper();
                perio.perio_perAbdominaln = txt_perAbdominal.Text.ToUpper();

                //I.
                perio.perio_observaExaFisRegional = txt_observexamenfisicoregional.Text.ToUpper();

                //J.
                perio.perio_examen = txt_examen.Text.ToUpper();
                perio.perio_examen2 = txt_examen2.Text.ToUpper();
                perio.perio_fecha = txt_fechaexamen.Text.ToUpper();
                perio.perio_fecha2 = txt_fechaexamen2.Text.ToUpper();
                perio.perio_resultado = txt_resultadoexamen.Text.ToUpper();
                perio.perio_resultado2 = txt_resultadoexamen2.Text.ToUpper();
                perio.perio_observacionesResExaGenEspPuesTrabajo = txt_observacionexamen.Text.ToUpper();

                //K.
                perio.perio_descripcionDiagnostico = txt_descripdiagnostico.Text.ToUpper();
                perio.perio_descripcionDiagnostico2 = txt_descripdiagnostico2.Text.ToUpper();
                perio.perio_descripcionDiagnostico3 = txt_descripdiagnostico3.Text.ToUpper();
                perio.perio_cie = txt_cie.Text.ToUpper();
                perio.perio_cie2 = txt_cie2.Text.ToUpper();
                perio.perio_cie3 = txt_cie3.Text.ToUpper();

                //L.
                perio.perio_ObservAptMedTrabajo = txt_observacionaptitud.Text.ToUpper();
                perio.perio_LimitAptMedTrabajo = txt_limitacionaptitud.Text.ToUpper();

                //M.
                perio.perio_descripcionRecoTratamiento = txt_descripciontratamientoperiodica.Text.ToUpper();

                //N.
                perio.perio_fechaHoraGuardado = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                perio.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                perio.perio_cod = txt_codigoDatProf.Text.ToUpper();
                perio.Per_id = perso;
                perio.Emp_id = empre;

                CN_Periodica.GuardarPeriodica(perio);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Guardados Exitosamente', 'success')", true);
                Timer1.Enabled = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Guardados', 'error')", true);
            }
        }

        private void ModificarPeriodica(Tbl_Periodica perio)
        {
            try
            {
                //Habitos Toxicos
                if (ckb_siConsuNociTabaHabToxi.Checked == true)
                {
                    perio.perio_siConsuNocivosTabaco = "SI";
                }
                else
                {
                    perio.perio_siConsuNocivosTabaco = null;
                }
                if (ckb_noConsuNociTabaHabToxi.Checked == true)
                {
                    perio.perio_noConsuNocivosTabaco = "SI";
                }
                else
                {
                    perio.perio_noConsuNocivosTabaco = null;
                }
                if (ckb_siConsuNociAlcoHabToxi.Checked == true)
                {
                    perio.perio_siConsuNocivosAlcohol = "SI";
                }
                else
                {
                    perio.perio_siConsuNocivosAlcohol = null;
                }
                if (ckb_noConsuNociAlcoHabToxi.Checked == true)
                {
                    perio.perio_noConsuNocivosAlcohol = "SI";
                }
                else
                {
                    perio.perio_noConsuNocivosAlcohol = null;
                }
                if (ckb_siConsuNociOtrasDroHabToxi.Checked == true)
                {
                    perio.perio_siConsuNocivosOtrasDrogas = "SI";
                }
                else
                {
                    perio.perio_siConsuNocivosOtrasDrogas = null;
                }
                if (ckb_noConsuNociOtrasDroHabToxi.Checked == true)
                {
                    perio.perio_noConsuNocivosOtrasDrogas = "SI";
                }
                else
                {
                    perio.perio_noConsuNocivosOtrasDrogas = null;
                }

                //Estilo de Vida
                if (ckb_siEstVidaActFisiEstVida.Checked == true)
                {
                    perio.perio_siEstiVidaActFisica = "SI";
                }
                else
                {
                    perio.perio_siEstiVidaActFisica = null;
                }
                if (ckb_noEstVidaActFisiEstVida.Checked == true)
                {
                    perio.perio_noEstiVidaActFisica = "SI";
                }
                else
                {
                    perio.perio_noEstiVidaActFisica = null;
                }
                if (ckb_siEstVidaMedHabiEstVida.Checked == true)
                {
                    perio.perio_siEstiVidaMediHabitual = "SI";
                }
                else
                {
                    perio.perio_siEstiVidaMediHabitual = null;
                }
                if (ckb_noEstVidaMedHabiEstVida.Checked == true)
                {
                    perio.perio_noEstiVidaMediHabitual = "SI";
                }
                else
                {
                    perio.perio_noEstiVidaMediHabitual = null;
                }

                //Accidentes de Trabajo (Descripcion)
                if (ckb_sicalificadotrabajo.Checked == true)
                {
                    perio.perio_siCalificadoIESSAcciTrabajo = "SI";
                }
                else
                {
                    perio.perio_siCalificadoIESSAcciTrabajo = null;
                }
                if (ckb_nocalificadotrabajo.Checked == true)
                {
                    perio.perio_noCalificadoIESSAcciTrabajo = "SI";
                }
                else
                {
                    perio.perio_noCalificadoIESSAcciTrabajo = null;
                }

                //Enfermedades Profesionales
                if (ckb_sicalificadoprofesional.Checked == true)
                {
                    perio.perio_siCalificadoIESSEnferProfesionales = "SI";
                }
                else
                {
                    perio.perio_siCalificadoIESSEnferProfesionales = null;
                }
                if (ckb_nocalificadoprofesional.Checked == true)
                {
                    perio.perio_noCalificadoIESSEnferProfesionales = "SI";
                }
                else
                {
                    perio.perio_noCalificadoIESSEnferProfesionales = null;
                }

                //Antecedentes Familiares (Detallar el Parentesco)
                if (ckb_enfermedadcardiovascular.Checked == true)
                {
                    perio.perio_cardVascular = "SI";
                }
                else
                {
                    perio.perio_cardVascular = null;
                }
                if (ckb_enfermedadmetabolica.Checked == true)
                {
                    perio.perio_enfMeta = "SI";
                }
                else
                {
                    perio.perio_enfMeta = null;
                }
                if (ckb_enfermedadneurologica.Checked == true)
                {
                    perio.perio_enfNeuro = "SI";
                }
                else
                {
                    perio.perio_enfNeuro = null;
                }
                if (ckb_enfermedadoncologica.Checked == true)
                {
                    perio.perio_enfOnco = "SI";
                }
                else
                {
                    perio.perio_enfOnco = null;
                }
                if (ckb_enfermedadinfecciosa.Checked == true)
                {
                    perio.perio_enfInfe = "SI";
                }
                else
                {
                    perio.perio_enfInfe = null;
                }
                if (ckb_enfermedadhereditaria.Checked == true)
                {
                    perio.perio_enfHereConge = "SI";
                }
                else
                {
                    perio.perio_enfHereConge = null;
                }
                if (ckb_discapacidades.Checked == true)
                {
                    perio.perio_discapa = "SI";
                }
                else
                {
                    perio.perio_discapa = null;
                }
                if (ckb_otrosenfer.Checked == true)
                {
                    perio.perio_otros = "SI";
                }
                else
                {
                    perio.perio_otros = null;
                }

                //Factores de riesgo del puesto de trabajo
                //----------- Fisico -----------
                if (ckb_tempaltas.Checked == true)
                {
                    perio.perio_temAltasFis = "SI";
                }
                else
                {
                    perio.perio_temAltasFis = null;
                }
                if (ckb_tempaltas2.Checked == true)
                {
                    perio.perio_temAltasFis2 = "SI";
                }
                else
                {
                    perio.perio_temAltasFis2 = null;
                }
                if (ckb_tempaltas3.Checked == true)
                {
                    perio.perio_temAltasFis3 = "SI";
                }
                else
                {
                    perio.perio_temAltasFis3 = null;
                }
                if (ckb_tempbajas.Checked == true)
                {
                    perio.perio_temBajasFis = "SI";
                }
                else
                {
                    perio.perio_temBajasFis = null;
                }
                if (ckb_tempbajas2.Checked == true)
                {
                    perio.perio_temBajasFis2 = "SI";
                }
                else
                {
                    perio.perio_temBajasFis2 = null;
                }
                if (ckb_tempbajas3.Checked == true)
                {
                    perio.perio_temBajasFis3 = "SI";
                }
                else
                {
                    perio.perio_temBajasFis3 = null;
                }
                if (ckb_radiacion.Checked == true)
                {
                    perio.perio_radIonizanteFis = "SI";
                }
                else
                {
                    perio.perio_radIonizanteFis = null;
                }
                if (ckb_radiacion2.Checked == true)
                {
                    perio.perio_radIonizanteFis2 = "SI";
                }
                else
                {
                    perio.perio_radIonizanteFis2 = null;
                }
                if (ckb_radiacion3.Checked == true)
                {
                    perio.perio_radIonizanteFis3 = "SI";
                }
                else
                {
                    perio.perio_radIonizanteFis3 = null;
                }
                if (ckb_noradiacion.Checked == true)
                {
                    perio.perio_radNoIonizanteFis = "SI";
                }
                else
                {
                    perio.perio_radNoIonizanteFis = null;
                }
                if (ckb_noradiacion2.Checked == true)
                {
                    perio.perio_radNoIonizanteFis2 = "SI";
                }
                else
                {
                    perio.perio_radNoIonizanteFis2 = null;
                }
                if (ckb_noradiacion3.Checked == true)
                {
                    perio.perio_radNoIonizanteFis3 = "SI";
                }
                else
                {
                    perio.perio_radNoIonizanteFis3 = null;
                }
                if (ckb_ruido.Checked == true)
                {
                    perio.perio_ruidoFis = "SI";
                }
                else
                {
                    perio.perio_ruidoFis = null;
                }
                if (ckb_ruido2.Checked == true)
                {
                    perio.perio_ruidoFis2 = "SI";
                }
                else
                {
                    perio.perio_ruidoFis2 = null;
                }
                if (ckb_ruido3.Checked == true)
                {
                    perio.perio_ruidoFis3 = "SI";
                }
                else
                {
                    perio.perio_ruidoFis3 = null;
                }
                if (ckb_vibracion.Checked == true)
                {
                    perio.perio_vibracionFis = "SI";
                }
                else
                {
                    perio.perio_vibracionFis = null;
                }
                if (ckb_vibracion2.Checked == true)
                {
                    perio.perio_vibracionFis2 = "SI";
                }
                else
                {
                    perio.perio_vibracionFis2 = null;
                }
                if (ckb_vibracion3.Checked == true)
                {
                    perio.perio_vibracionFis3 = "SI";
                }
                else
                {
                    perio.perio_vibracionFis3 = null;
                }
                if (ckb_iluminacion.Checked == true)
                {
                    perio.perio_iluminacionFis = "SI";
                }
                else
                {
                    perio.perio_iluminacionFis = null;
                }
                if (ckb_iluminacion2.Checked == true)
                {
                    perio.perio_iluminacionFis2 = "SI";
                }
                else
                {
                    perio.perio_iluminacionFis2 = null;
                }
                if (ckb_iluminacion3.Checked == true)
                {
                    perio.perio_iluminacionFis3 = "SI";
                }
                else
                {
                    perio.perio_iluminacionFis3 = null;
                }
                if (ckb_ventilacion.Checked == true)
                {
                    perio.perio_ventilacionFis = "SI";
                }
                else
                {
                    perio.perio_ventilacionFis = null;
                }
                if (ckb_ventilacion2.Checked == true)
                {
                    perio.perio_ventilacionFis2 = "SI";
                }
                else
                {
                    perio.perio_ventilacionFis2 = null;
                }
                if (ckb_ventilacion3.Checked == true)
                {
                    perio.perio_ventilacionFis3 = "SI";
                }
                else
                {
                    perio.perio_ventilacionFis3 = null;
                }
                if (ckb_fluidoelectrico.Checked == true)
                {
                    perio.perio_fluElectricoFis = "SI";
                }
                else
                {
                    perio.perio_fluElectricoFis = null;
                }
                if (ckb_fluidoelectrico2.Checked == true)
                {
                    perio.perio_fluElectricoFis2 = "SI";
                }
                else
                {
                    perio.perio_fluElectricoFis2 = null;
                }
                if (ckb_fluidoelectrico3.Checked == true)
                {
                    perio.perio_fluElectricoFis3 = "SI";
                }
                else
                {
                    perio.perio_fluElectricoFis3 = null;
                }
                if (ckb_otrosFisico.Checked == true)
                {
                    perio.perio_otrosFis = "SI";
                }
                else
                {
                    perio.perio_otrosFis = null;
                }
                if (ckb_otrosFisico2.Checked == true)
                {
                    perio.perio_otrosFis2 = "SI";
                }
                else
                {
                    perio.perio_otrosFis2 = null;
                }
                if (ckb_otrosFisico3.Checked == true)
                {
                    perio.perio_otrosFis3 = "SI";
                }
                else
                {
                    perio.perio_otrosFis3 = null;
                }
                //----------- Mecanico -----------
                if (ckb_atrapmaquinas.Checked == true)
                {
                    perio.perio_atraMaquinasMec = "SI";
                }
                else
                {
                    perio.perio_atraMaquinasMec = null;
                }
                if (ckb_atrapmaquinas2.Checked == true)
                {
                    perio.perio_atraMaquinasMec2 = "SI";
                }
                else
                {
                    perio.perio_atraMaquinasMec2 = null;
                }
                if (ckb_atrapmaquinas3.Checked == true)
                {
                    perio.perio_atraMaquinasMec3 = "SI";
                }
                else
                {
                    perio.perio_atraMaquinasMec3 = null;
                }
                if (ckb_atrapsuperficie.Checked == true)
                {
                    perio.perio_atraSuperfiiesMec = "SI";
                }
                else
                {
                    perio.perio_atraSuperfiiesMec = null;
                }
                if (ckb_atrapsuperficie2.Checked == true)
                {
                    perio.perio_atraSuperfiiesMec2 = "SI";
                }
                else
                {
                    perio.perio_atraSuperfiiesMec2 = null;
                }
                if (ckb_atrapsuperficie3.Checked == true)
                {
                    perio.perio_atraSuperfiiesMec3 = "SI";
                }
                else
                {
                    perio.perio_atraSuperfiiesMec3 = null;
                }
                if (ckb_atrapobjetos.Checked == true)
                {
                    perio.perio_atraObjetosMec = "SI";
                }
                else
                {
                    perio.perio_atraObjetosMec = null;
                }
                if (ckb_atrapobjetos2.Checked == true)
                {
                    perio.perio_atraObjetosMec2 = "SI";
                }
                else
                {
                    perio.perio_atraObjetosMec2 = null;
                }
                if (ckb_atrapobjetos3.Checked == true)
                {
                    perio.perio_atraObjetosMec3 = "SI";
                }
                else
                {
                    perio.perio_atraObjetosMec3 = null;
                }
                if (ckb_caidaobjetos.Checked == true)
                {
                    perio.perio_caidaObjetosMec = "SI";
                }
                else
                {
                    perio.perio_caidaObjetosMec = null;
                }
                if (ckb_caidaobjetos2.Checked == true)
                {
                    perio.perio_caidaObjetosMec2 = "SI";
                }
                else
                {
                    perio.perio_caidaObjetosMec2 = null;
                }
                if (ckb_caidaobjetos3.Checked == true)
                {
                    perio.perio_caidaObjetosMec3 = "SI";
                }
                else
                {
                    perio.perio_caidaObjetosMec3 = null;
                }
                if (ckb_caidamisnivel.Checked == true)
                {
                    perio.perio_caidaMisNivelMec = "SI";
                }
                else
                {
                    perio.perio_caidaMisNivelMec = null;
                }
                if (ckb_caidamisnivel2.Checked == true)
                {
                    perio.perio_caidaMisNivelMec2 = "SI";
                }
                else
                {
                    perio.perio_caidaMisNivelMec2 = null;
                }
                if (ckb_caidamisnivel3.Checked == true)
                {
                    perio.perio_caidaMisNivelMec3 = "SI";
                }
                else
                {
                    perio.perio_caidaMisNivelMec3 = null;
                }
                if (ckb_caidadifnivel.Checked == true)
                {
                    perio.perio_caidaDifNivelMec = "SI";
                }
                else
                {
                    perio.perio_caidaDifNivelMec = null;
                }
                if (ckb_caidadifnivel2.Checked == true)
                {
                    perio.perio_caidaDifNivelMec2 = "SI";
                }
                else
                {
                    perio.perio_caidaDifNivelMec2 = null;
                }
                if (ckb_caidadifnivel3.Checked == true)
                {
                    perio.perio_caidaDifNivelMec3 = "SI";
                }
                else
                {
                    perio.perio_caidaDifNivelMec3 = null;
                }
                if (ckb_contaelectrico.Checked == true)
                {
                    perio.perio_contactoElecMec = "SI";
                }
                else
                {
                    perio.perio_contactoElecMec = null;
                }
                if (ckb_contaelectrico2.Checked == true)
                {
                    perio.perio_contactoElecMec2 = "SI";
                }
                else
                {
                    perio.perio_contactoElecMec2 = null;
                }
                if (ckb_contaelectrico3.Checked == true)
                {
                    perio.perio_contactoElecMec3 = "SI";
                }
                else
                {
                    perio.perio_contactoElecMec3 = null;
                }
                if (ckb_contasuptrabajo.Checked == true)
                {
                    perio.perio_conSuperTrabaMec = "SI";
                }
                else
                {
                    perio.perio_conSuperTrabaMec = null;
                }
                if (ckb_contasuptrabajo2.Checked == true)
                {
                    perio.perio_conSuperTrabaMec2 = "SI";
                }
                else
                {
                    perio.perio_conSuperTrabaMec2 = null;
                }
                if (ckb_contasuptrabajo3.Checked == true)
                {
                    perio.perio_conSuperTrabaMec3 = "SI";
                }
                else
                {
                    perio.perio_conSuperTrabaMec3 = null;
                }
                if (ckb_proyparticulas.Checked == true)
                {
                    perio.perio_proPartiFragMec = "SI";
                }
                else
                {
                    perio.perio_proPartiFragMec = null;
                }
                if (ckb_proyparticulas2.Checked == true)
                {
                    perio.perio_proPartiFragMec2 = "SI";
                }
                else
                {
                    perio.perio_proPartiFragMec2 = null;
                }
                if (ckb_proyparticulas3.Checked == true)
                {
                    perio.perio_proPartiFragMec3 = "SI";
                }
                else
                {
                    perio.perio_proPartiFragMec3 = null;
                }
                if (ckb_proyefluidos.Checked == true)
                {
                    perio.perio_proFluidosMec = "SI";
                }
                else
                {
                    perio.perio_proFluidosMec = null;
                }
                if (ckb_proyefluidos2.Checked == true)
                {
                    perio.perio_proFluidosMec2 = "SI";
                }
                else
                {
                    perio.perio_proFluidosMec2 = null;
                }
                if (ckb_proyefluidos3.Checked == true)
                {
                    perio.perio_proFluidosMec3 = "SI";
                }
                else
                {
                    perio.perio_proFluidosMec3 = null;
                }
                if (ckb_pinchazos.Checked == true)
                {
                    perio.perio_pinchazosMec = "SI";
                }
                else
                {
                    perio.perio_pinchazosMec = null;
                }
                if (ckb_pinchazos2.Checked == true)
                {
                    perio.perio_pinchazosMec2 = "SI";
                }
                else
                {
                    perio.perio_pinchazosMec2 = null;
                }
                if (ckb_pinchazos3.Checked == true)
                {
                    perio.perio_pinchazosMec3 = "SI";
                }
                else
                {
                    perio.perio_pinchazosMec3 = null;
                }
                if (ckb_cortes.Checked == true)
                {
                    perio.perio_cortesMec = "SI";
                }
                else
                {
                    perio.perio_cortesMec = null;
                }
                if (ckb_cortes2.Checked == true)
                {
                    perio.perio_cortesMec2 = "SI";
                }
                else
                {
                    perio.perio_cortesMec2 = null;
                }
                if (ckb_cortes3.Checked == true)
                {
                    perio.perio_cortesMec3 = "SI";
                }
                else
                {
                    perio.perio_cortesMec3 = null;
                }
                if (ckb_atroporvehiculos.Checked == true)
                {
                    perio.perio_atropeVehiMec = "SI";
                }
                else
                {
                    perio.perio_atropeVehiMec = null;
                }
                if (ckb_atroporvehiculos2.Checked == true)
                {
                    perio.perio_atropeVehiMec2 = "SI";
                }
                else
                {
                    perio.perio_atropeVehiMec2 = null;
                }
                if (ckb_atroporvehiculos3.Checked == true)
                {
                    perio.perio_atropeVehiMec3 = "SI";
                }
                else
                {
                    perio.perio_atropeVehiMec3 = null;
                }
                if (ckb_choques.Checked == true)
                {
                    perio.perio_coliVehiMec = "SI";
                }
                else
                {
                    perio.perio_coliVehiMec = null;
                }
                if (ckb_choques2.Checked == true)
                {
                    perio.perio_coliVehiMec2 = "SI";
                }
                else
                {
                    perio.perio_coliVehiMec2 = null;
                }
                if (ckb_choques3.Checked == true)
                {
                    perio.perio_coliVehiMec3 = "SI";
                }
                else
                {
                    perio.perio_coliVehiMec3 = null;
                }
                if (ckb_otrosMecanico.Checked == true)
                {
                    perio.perio_otrosMec = "SI";
                }
                else
                {
                    perio.perio_otrosMec = null;
                }
                if (ckb_otrosMecanico2.Checked == true)
                {
                    perio.perio_otrosMec2 = "SI";
                }
                else
                {
                    perio.perio_otrosMec2 = null;
                }
                if (ckb_otrosMecanico3.Checked == true)
                {
                    perio.perio_otrosMec3 = "SI";
                }
                else
                {
                    perio.perio_otrosMec3 = null;
                }
                //----------- Quimico -----------
                if (ckb_solidos.Checked == true)
                {
                    perio.perio_solidosQui = "SI";
                }
                else
                {
                    perio.perio_solidosQui = null;
                }
                if (ckb_solidos2.Checked == true)
                {
                    perio.perio_solidosQui2 = "SI";
                }
                else
                {
                    perio.perio_solidosQui2 = null;
                }
                if (ckb_solidos3.Checked == true)
                {
                    perio.perio_solidosQui3 = "SI";
                }
                else
                {
                    perio.perio_solidosQui3 = null;
                }
                if (ckb_polvos.Checked == true)
                {
                    perio.perio_polvosQui = "SI";
                }
                else
                {
                    perio.perio_polvosQui = null;
                }
                if (ckb_polvos2.Checked == true)
                {
                    perio.perio_polvosQui2 = "SI";
                }
                else
                {
                    perio.perio_polvosQui2 = null;
                }
                if (ckb_polvos3.Checked == true)
                {
                    perio.perio_polvosQui3 = "SI";
                }
                else
                {
                    perio.perio_polvosQui3 = null;
                }
                if (ckb_humos.Checked == true)
                {
                    perio.perio_humosQui = "SI";
                }
                else
                {
                    perio.perio_humosQui = null;
                }
                if (ckb_humos2.Checked == true)
                {
                    perio.perio_humosQui2 = "SI";
                }
                else
                {
                    perio.perio_humosQui2 = null;
                }
                if (ckb_humos3.Checked == true)
                {
                    perio.perio_humosQui3 = "SI";
                }
                else
                {
                    perio.perio_humosQui3 = null;
                }
                if (ckb_liquidos.Checked == true)
                {
                    perio.perio_liquidosQui = "SI";
                }
                else
                {
                    perio.perio_liquidosQui = null;
                }
                if (ckb_liquidos2.Checked == true)
                {
                    perio.perio_liquidosQui2 = "SI";
                }
                else
                {
                    perio.perio_liquidosQui2 = null;
                }
                if (ckb_liquidos3.Checked == true)
                {
                    perio.perio_liquidosQui3 = "SI";
                }
                else
                {
                    perio.perio_liquidosQui3 = null;
                }
                if (ckb_vapores.Checked == true)
                {
                    perio.perio_vaporesQui = "SI";
                }
                else
                {
                    perio.perio_vaporesQui = null;
                }
                if (ckb_vapores2.Checked == true)
                {
                    perio.perio_vaporesQui2 = "SI";
                }
                else
                {
                    perio.perio_vaporesQui2 = null;
                }
                if (ckb_vapores3.Checked == true)
                {
                    perio.perio_vaporesQui3 = "SI";
                }
                else
                {
                    perio.perio_vaporesQui3 = null;
                }
                if (ckb_aerosoles.Checked == true)
                {
                    perio.perio_aerosolesQui = "SI";
                }
                else
                {
                    perio.perio_aerosolesQui = null;
                }
                if (ckb_aerosoles2.Checked == true)
                {
                    perio.perio_aerosolesQui2 = "SI";
                }
                else
                {
                    perio.perio_aerosolesQui2 = null;
                }
                if (ckb_aerosoles3.Checked == true)
                {
                    perio.perio_aerosolesQui3 = "SI";
                }
                else
                {
                    perio.perio_aerosolesQui3 = null;
                }
                if (ckb_neblinas.Checked == true)
                {
                    perio.perio_neblinasQui = "SI";
                }
                else
                {
                    perio.perio_neblinasQui = null;
                }
                if (ckb_neblinas2.Checked == true)
                {
                    perio.perio_neblinasQui2 = "SI";
                }
                else
                {
                    perio.perio_neblinasQui2 = null;
                }
                if (ckb_neblinas3.Checked == true)
                {
                    perio.perio_neblinasQui3 = "SI";
                }
                else
                {
                    perio.perio_neblinasQui3 = null;
                }
                if (ckb_gaseosos.Checked == true)
                {
                    perio.perio_gaseososQui = "SI";
                }
                else
                {
                    perio.perio_gaseososQui = null;
                }
                if (ckb_gaseosos2.Checked == true)
                {
                    perio.perio_gaseososQui2 = "SI";
                }
                else
                {
                    perio.perio_gaseososQui2 = null;
                }
                if (ckb_gaseosos3.Checked == true)
                {
                    perio.perio_gaseososQui3 = "SI";
                }
                else
                {
                    perio.perio_gaseososQui3 = null;
                }
                if (ckb_otrosQuimico.Checked == true)
                {
                    perio.perio_otrosQui = "SI";
                }
                else
                {
                    perio.perio_otrosQui = null;
                }
                if (ckb_otrosQuimico2.Checked == true)
                {
                    perio.perio_otrosQui2 = "SI";
                }
                else
                {
                    perio.perio_otrosQui2 = null;
                }
                if (ckb_otrosQuimico3.Checked == true)
                {
                    perio.perio_otrosQui3 = "SI";
                }
                else
                {
                    perio.perio_otrosQui3 = null;
                }
                //----------- Biologico -----------
                if (ckb_virus.Checked == true)
                {
                    perio.perio_virusBio = "SI";
                }
                else
                {
                    perio.perio_virusBio = null;
                }
                if (ckb_virus2.Checked == true)
                {
                    perio.perio_virusBio2 = "SI";
                }
                else
                {
                    perio.perio_virusBio2 = null;
                }
                if (ckb_virus3.Checked == true)
                {
                    perio.perio_virusBio3 = "SI";
                }
                else
                {
                    perio.perio_virusBio3 = null;
                }
                if (ckb_hongos.Checked == true)
                {
                    perio.perio_hongosBio = "SI";
                }
                else
                {
                    perio.perio_hongosBio = null;
                }
                if (ckb_hongos2.Checked == true)
                {
                    perio.perio_hongosBio2 = "SI";
                }
                else
                {
                    perio.perio_hongosBio2 = null;
                }
                if (ckb_hongos3.Checked == true)
                {
                    perio.perio_hongosBio3 = "SI";
                }
                else
                {
                    perio.perio_hongosBio3 = null;
                }
                if (ckb_bacterias.Checked == true)
                {
                    perio.perio_bacteriasBio = "SI";
                }
                else
                {
                    perio.perio_bacteriasBio = null;
                }
                if (ckb_bacterias2.Checked == true)
                {
                    perio.perio_bacteriasBio2 = "SI";
                }
                else
                {
                    perio.perio_bacteriasBio2 = null;
                }
                if (ckb_bacterias3.Checked == true)
                {
                    perio.perio_bacteriasBio3 = "SI";
                }
                else
                {
                    perio.perio_bacteriasBio3 = null;
                }
                if (ckb_parasitos.Checked == true)
                {
                    perio.perio_parasitosBio = "SI";
                }
                else
                {
                    perio.perio_parasitosBio = null;
                }
                if (ckb_parasitos2.Checked == true)
                {
                    perio.perio_parasitosBio2 = "SI";
                }
                else
                {
                    perio.perio_parasitosBio2 = null;
                }
                if (ckb_parasitos3.Checked == true)
                {
                    perio.perio_parasitosBio3 = "SI";
                }
                else
                {
                    perio.perio_parasitosBio3 = null;
                }
                if (ckb_expoavectores.Checked == true)
                {
                    perio.perio_expVectBio = "SI";
                }
                else
                {
                    perio.perio_expVectBio = null;
                }
                if (ckb_expoavectores2.Checked == true)
                {
                    perio.perio_expVectBio2 = "SI";
                }
                else
                {
                    perio.perio_expVectBio2 = null;
                }
                if (ckb_expoavectores3.Checked == true)
                {
                    perio.perio_expVectBio3 = "SI";
                }
                else
                {
                    perio.perio_expVectBio3 = null;
                }
                if (ckb_expoanimselvaticos.Checked == true)
                {
                    perio.perio_expAniSelvaBio = "SI";
                }
                else
                {
                    perio.perio_expAniSelvaBio = null;
                }
                if (ckb_expoanimselvaticos2.Checked == true)
                {
                    perio.perio_expAniSelvaBio2 = "SI";
                }
                else
                {
                    perio.perio_expAniSelvaBio2 = null;
                }
                if (ckb_expoanimselvaticos3.Checked == true)
                {
                    perio.perio_expAniSelvaBio3 = "SI";
                }
                else
                {
                    perio.perio_expAniSelvaBio3 = null;
                }
                if (ckb_otrosBiologico.Checked == true)
                {
                    perio.perio_otrosBio = "SI";
                }
                else
                {
                    perio.perio_otrosBio = null;
                }
                if (ckb_otrosBiologico2.Checked == true)
                {
                    perio.perio_otrosBio2 = "SI";
                }
                else
                {
                    perio.perio_otrosBio2 = null;
                }
                if (ckb_otrosBiologico3.Checked == true)
                {
                    perio.perio_otrosBio3 = "SI";
                }
                else
                {
                    perio.perio_otrosBio3 = null;
                }
                //----------- Ergonomico -----------
                if (ckb_manmanualcargas.Checked == true)
                {
                    perio.perio_maneManCarErg = "SI";
                }
                else
                {
                    perio.perio_maneManCarErg = null;
                }
                if (ckb_manmanualcargas2.Checked == true)
                {
                    perio.perio_maneManCarErg2 = "SI";
                }
                else
                {
                    perio.perio_maneManCarErg2 = null;
                }
                if (ckb_manmanualcargas3.Checked == true)
                {
                    perio.perio_maneManCarErg3 = "SI";
                }
                else
                {
                    perio.perio_maneManCarErg3 = null;
                }
                if (ckb_movrepetitivo.Checked == true)
                {
                    perio.perio_movRepeErg = "SI";
                }
                else
                {
                    perio.perio_movRepeErg = null;
                }
                if (ckb_movrepetitivo2.Checked == true)
                {
                    perio.perio_movRepeErg2 = "SI";
                }
                else
                {
                    perio.perio_movRepeErg2 = null;
                }
                if (ckb_movrepetitivo3.Checked == true)
                {
                    perio.perio_movRepeErg3 = "SI";
                }
                else
                {
                    perio.perio_movRepeErg3 = null;
                }
                if (ckb_postforzadas.Checked == true)
                {
                    perio.perio_posForzaErg = "SI";
                }
                else
                {
                    perio.perio_posForzaErg = null;
                }
                if (ckb_postforzadas2.Checked == true)
                {
                    perio.perio_posForzaErg2 = "SI";
                }
                else
                {
                    perio.perio_posForzaErg2 = null;
                }
                if (ckb_postforzadas3.Checked == true)
                {
                    perio.perio_posForzaErg3 = "SI";
                }
                else
                {
                    perio.perio_posForzaErg3 = null;
                }
                if (ckb_trabajopvd.Checked == true)
                {
                    perio.perio_trabPvdErg = "SI";
                }
                else
                {
                    perio.perio_trabPvdErg = null;
                }
                if (ckb_trabajopvd2.Checked == true)
                {
                    perio.perio_trabPvdErg2 = "SI";
                }
                else
                {
                    perio.perio_trabPvdErg2 = null;
                }
                if (ckb_trabajopvd3.Checked == true)
                {
                    perio.perio_trabPvdErg3 = "SI";
                }
                else
                {
                    perio.perio_trabPvdErg3 = null;
                }
                if (ckb_otrosErgonomico.Checked == true)
                {
                    perio.perio_otrosErg = "SI";
                }
                else
                {
                    perio.perio_otrosErg = null;
                }
                if (ckb_otrosErgonomico2.Checked == true)
                {
                    perio.perio_otrosErg2 = "SI";
                }
                else
                {
                    perio.perio_otrosErg2 = null;
                }
                if (ckb_otrosErgonomico3.Checked == true)
                {
                    perio.perio_otrosErg3 = "SI";
                }
                else
                {
                    perio.perio_otrosErg3 = null;
                }
                //----------- Psicosocial -----------
                if (ckb_montrabajo.Checked == true)
                {
                    perio.perio_monoTrabPsi = "SI";
                }
                else
                {
                    perio.perio_monoTrabPsi = null;
                }
                if (ckb_montrabajo2.Checked == true)
                {
                    perio.perio_monoTrabPsi2 = "SI";
                }
                else
                {
                    perio.perio_monoTrabPsi2 = null;
                }
                if (ckb_montrabajo3.Checked == true)
                {
                    perio.perio_monoTrabPsi3 = "SI";
                }
                else
                {
                    perio.perio_monoTrabPsi3 = null;
                }
                if (ckb_sobrecargalaboral.Checked == true)
                {
                    perio.perio_sobrecarLabPsi = "SI";
                }
                else
                {
                    perio.perio_sobrecarLabPsi = null;
                }
                if (ckb_sobrecargalaboral2.Checked == true)
                {
                    perio.perio_sobrecarLabPsi2 = "SI";
                }
                else
                {
                    perio.perio_sobrecarLabPsi2 = null;
                }
                if (ckb_sobrecargalaboral3.Checked == true)
                {
                    perio.perio_sobrecarLabPsi3 = "SI";
                }
                else
                {
                    perio.perio_sobrecarLabPsi3 = null;
                }
                if (ckb_minustarea.Checked == true)
                {
                    perio.perio_minuTareaPsi = "SI";
                }
                else
                {
                    perio.perio_minuTareaPsi = null;
                }
                if (ckb_minustarea2.Checked == true)
                {
                    perio.perio_minuTareaPsi2 = "SI";
                }
                else
                {
                    perio.perio_minuTareaPsi2 = null;
                }
                if (ckb_minustarea3.Checked == true)
                {
                    perio.perio_minuTareaPsi3 = "SI";
                }
                else
                {
                    perio.perio_minuTareaPsi3 = null;
                }
                if (ckb_altarespon.Checked == true)
                {
                    perio.perio_altaResponPsi = "SI";
                }
                else
                {
                    perio.perio_altaResponPsi = null;
                }
                if (ckb_altarespon2.Checked == true)
                {
                    perio.perio_altaResponPsi2 = "SI";
                }
                else
                {
                    perio.perio_altaResponPsi2 = null;
                }
                if (ckb_altarespon3.Checked == true)
                {
                    perio.perio_altaResponPsi3 = "SI";
                }
                else
                {
                    perio.perio_altaResponPsi3 = null;
                }
                if (ckb_automadesiciones.Checked == true)
                {
                    perio.perio_autoTomaDesiPsi = "SI";
                }
                else
                {
                    perio.perio_autoTomaDesiPsi = null;
                }
                if (ckb_automadesiciones2.Checked == true)
                {
                    perio.perio_autoTomaDesiPsi2 = "SI";
                }
                else
                {
                    perio.perio_autoTomaDesiPsi2 = null;
                }
                if (ckb_automadesiciones3.Checked == true)
                {
                    perio.perio_autoTomaDesiPsi3 = "SI";
                }
                else
                {
                    perio.perio_autoTomaDesiPsi3 = null;
                }
                if (ckb_supyestdireficiente.Checked == true)
                {
                    perio.perio_supEstDirecDefiPsi = "SI";
                }
                else
                {
                    perio.perio_supEstDirecDefiPsi = null;
                }
                if (ckb_supyestdireficiente2.Checked == true)
                {
                    perio.perio_supEstDirecDefiPsi2 = "SI";
                }
                else
                {
                    perio.perio_supEstDirecDefiPsi2 = null;
                }
                if (ckb_supyestdireficiente3.Checked == true)
                {
                    perio.perio_supEstDirecDefiPsi3 = "SI";
                }
                else
                {
                    perio.perio_supEstDirecDefiPsi3 = null;
                }
                if (ckb_conflictorol.Checked == true)
                {
                    perio.perio_conflicRolPsi = "SI";
                }
                else
                {
                    perio.perio_conflicRolPsi = null;
                }
                if (ckb_conflictorol2.Checked == true)
                {
                    perio.perio_conflicRolPsi2 = "SI";
                }
                else
                {
                    perio.perio_conflicRolPsi2 = null;
                }
                if (ckb_conflictorol3.Checked == true)
                {
                    perio.perio_conflicRolPsi3 = "SI";
                }
                else
                {
                    perio.perio_conflicRolPsi3 = null;
                }
                if (ckb_faltaclarfunciones.Checked == true)
                {
                    perio.perio_falClariFunPsi = "SI";
                }
                else
                {
                    perio.perio_falClariFunPsi = null;
                }
                if (ckb_faltaclarfunciones2.Checked == true)
                {
                    perio.perio_falClariFunPsi2 = "SI";
                }
                else
                {
                    perio.perio_falClariFunPsi2 = null;
                }
                if (ckb_faltaclarfunciones3.Checked == true)
                {
                    perio.perio_falClariFunPsi3 = "SI";
                }
                else
                {
                    perio.perio_falClariFunPsi3 = null;
                }
                if (ckb_incorrdistrabajo.Checked == true)
                {
                    perio.perio_incoDistriTrabPsi = "SI";
                }
                else
                {
                    perio.perio_incoDistriTrabPsi = null;
                }
                if (ckb_incorrdistrabajo2.Checked == true)
                {
                    perio.perio_incoDistriTrabPsi2 = "SI";
                }
                else
                {
                    perio.perio_incoDistriTrabPsi2 = null;
                }
                if (ckb_incorrdistrabajo3.Checked == true)
                {
                    perio.perio_incoDistriTrabPsi3 = "SI";
                }
                else
                {
                    perio.perio_incoDistriTrabPsi3 = null;
                }
                if (ckb_turnorotat.Checked == true)
                {
                    perio.perio_turnosRotaPsi = "SI";
                }
                else
                {
                    perio.perio_turnosRotaPsi = null;
                }
                if (ckb_turnorotat2.Checked == true)
                {
                    perio.perio_turnosRotaPsi2 = "SI";
                }
                else
                {
                    perio.perio_turnosRotaPsi2 = null;
                }
                if (ckb_turnorotat3.Checked == true)
                {
                    perio.perio_turnosRotaPsi3 = "SI";
                }
                else
                {
                    perio.perio_turnosRotaPsi3 = null;
                }
                if (ckb_relacinterpersonales.Checked == true)
                {
                    perio.perio_relInterperPsi = "SI";
                }
                else
                {
                    perio.perio_relInterperPsi = null;
                }
                if (ckb_relacinterpersonales2.Checked == true)
                {
                    perio.perio_relInterperPsi2 = "SI";
                }
                else
                {
                    perio.perio_relInterperPsi2 = null;
                }
                if (ckb_relacinterpersonales3.Checked == true)
                {
                    perio.perio_relInterperPsi3 = "SI";
                }
                else
                {
                    perio.perio_relInterperPsi3 = null;
                }
                if (ckb_inestalaboral.Checked == true)
                {
                    perio.perio_inesLabPsi = "SI";
                }
                else
                {
                    perio.perio_inesLabPsi = null;
                }
                if (ckb_inestalaboral2.Checked == true)
                {
                    perio.perio_inesLabPsi2 = "SI";
                }
                else
                {
                    perio.perio_inesLabPsi2 = null;
                }
                if (ckb_inestalaboral3.Checked == true)
                {
                    perio.perio_inesLabPsi3 = "SI";
                }
                else
                {
                    perio.perio_inesLabPsi3 = null;
                }
                if (ckb_otrosPsisocial.Checked == true)
                {
                    perio.perio_otrosPsi = "SI";
                }
                else
                {
                    perio.perio_otrosPsi = null;
                }
                if (ckb_otrosPsisocial2.Checked == true)
                {
                    perio.perio_otrosPsi2 = "SI";
                }
                else
                {
                    perio.perio_otrosPsi2 = null;
                }
                if (ckb_otrosPsisocial3.Checked == true)
                {
                    perio.perio_otrosPsi3 = "SI";
                }
                else
                {
                    perio.perio_otrosPsi3 = null;
                }

                //Revision de Organos y Sistemas
                if (ckb_pielanexos.Checked == true)
                {
                    perio.perio_pielAnexos = "SI";
                }
                else
                {
                    perio.perio_pielAnexos = null;
                }
                if (ckb_organossentidos.Checked == true)
                {
                    perio.perio_orgSentidos = "SI";
                }
                else
                {
                    perio.perio_orgSentidos = null;
                }
                if (ckb_respiratorio.Checked == true)
                {
                    perio.perio_respiratorio = "SI";
                }
                else
                {
                    perio.perio_respiratorio = null;
                }
                if (ckb_cardiovascular.Checked == true)
                {
                    perio.perio_cardVascular = "SI";
                }
                else
                {
                    perio.perio_cardVascular = null;
                }
                if (ckb_digestivo.Checked == true)
                {
                    perio.perio_digestivo = "SI";
                }
                else
                {
                    perio.perio_digestivo = null;
                }
                if (ckb_genitourinario.Checked == true)
                {
                    perio.perio_genUrinario = "SI";
                }
                else
                {
                    perio.perio_genUrinario = null;
                }
                if (ckb_musculosesqueleticos.Checked == true)
                {
                    perio.perio_muscEsqueletico = "SI";
                }
                else
                {
                    perio.perio_muscEsqueletico = null;
                }
                if (ckb_endocrino.Checked == true)
                {
                    perio.perio_endocrino = "SI";
                }
                else
                {
                    perio.perio_endocrino = null;
                }
                if (ckb_hemolinfatico.Checked == true)
                {
                    perio.perio_hemoLimfa = "SI";
                }
                else
                {
                    perio.perio_hemoLimfa = null;
                }
                if (ckb_nervioso.Checked == true)
                {
                    perio.perio_nervioso = "SI";
                }
                else
                {
                    perio.perio_nervioso = null;
                }

                //Regiones
                if (ckb_cicatrices.Checked == true)
                {
                    perio.perio_cicatricesPiel = "SI";
                }
                else
                {
                    perio.perio_cicatricesPiel = null;
                }
                if (ckb_tatuajes.Checked == true)
                {
                    perio.perio_tatuajesPiel = "SI";
                }
                else
                {
                    perio.perio_tatuajesPiel = null;
                }
                if (ckb_pielyfaneras.Checked == true)
                {
                    perio.perio_pielFacerasPiel = "SI";
                }
                else
                {
                    perio.perio_pielFacerasPiel = null;
                }
                if (ckb_parpados.Checked == true)
                {
                    perio.perio_parpadosOjos = "SI";
                }
                else
                {
                    perio.perio_parpadosOjos = null;
                }
                if (ckb_conjuntivas.Checked == true)
                {
                    perio.perio_conjuntuvasOjos = "SI";
                }
                else
                {
                    perio.perio_conjuntuvasOjos = null;
                }
                if (ckb_pupilas.Checked == true)
                {
                    perio.perio_pupilasOjos = "SI";
                }
                else
                {
                    perio.perio_pupilasOjos = null;
                }
                if (ckb_cornea.Checked == true)
                {
                    perio.perio_corneaOjos = "SI";
                }
                else
                {
                    perio.perio_corneaOjos = null;
                }
                if (ckb_motilidad.Checked == true)
                {
                    perio.perio_motilidadOjos = "SI";
                }
                else
                {
                    perio.perio_motilidadOjos = null;
                }
                if (ckb_auditivoexterno.Checked == true)
                {
                    perio.perio_cAudiExtreOido = "SI";
                }
                else
                {
                    perio.perio_cAudiExtreOido = null;
                }
                if (ckb_pabellon.Checked == true)
                {
                    perio.perio_pabellonOido = "SI";
                }
                else
                {
                    perio.perio_pabellonOido = null;
                }
                if (ckb_timpanos.Checked == true)
                {
                    perio.perio_timpanosOido = "SI";
                }
                else
                {
                    perio.perio_timpanosOido = null;
                }
                if (ckb_labios.Checked == true)
                {
                    perio.perio_labiosOroFa = "SI";
                }
                else
                {
                    perio.perio_labiosOroFa = null;
                }
                if (ckb_lengua.Checked == true)
                {
                    perio.perio_lenguaOroFa = "SI";
                }
                else
                {
                    perio.perio_lenguaOroFa = null;
                }
                if (ckb_faringe.Checked == true)
                {
                    perio.perio_faringeOroFa = "SI";
                }
                else
                {
                    perio.perio_faringeOroFa = null;
                }
                if (ckb_amigdalas.Checked == true)
                {
                    perio.perio_amigdalasOroFa = "SI";
                }
                else
                {
                    perio.perio_amigdalasOroFa = null;
                }
                if (ckb_dentadura.Checked == true)
                {
                    perio.perio_dentaduraOroFa = "SI";
                }
                else
                {
                    perio.perio_dentaduraOroFa = null;
                }
                if (ckb_tabique.Checked == true)
                {
                    perio.perio_tabiqueNariz = "SI";
                }
                else
                {
                    perio.perio_tabiqueNariz = null;
                }
                if (ckb_cornetes.Checked == true)
                {
                    perio.perio_cornetesNariz = "SI";
                }
                else
                {
                    perio.perio_cornetesNariz = null;
                }
                if (ckb_mucosa.Checked == true)
                {
                    perio.perio_mucosasNariz = "SI";
                }
                else
                {
                    perio.perio_mucosasNariz = null;
                }
                if (ckb_senosparanasales.Checked == true)
                {
                    perio.perio_senosParanaNariz = "SI";
                }
                else
                {
                    perio.perio_senosParanaNariz = null;
                }
                if (ckb_tiroides.Checked == true)
                {
                    perio.perio_tiroiMasasCuello = "SI";
                }
                else
                {
                    perio.perio_tiroiMasasCuello = null;
                }
                if (ckb_movilidad.Checked == true)
                {
                    perio.perio_movilidadCuello = "SI";
                }
                else
                {
                    perio.perio_movilidadCuello = null;
                }
                if (ckb_mamas.Checked == true)
                {
                    perio.perio_mamasTorax = "SI";
                }
                else
                {
                    perio.perio_mamasTorax = null;
                }
                if (ckb_corazon.Checked == true)
                {
                    perio.perio_corazonTorax = "SI";
                }
                else
                {
                    perio.perio_corazonTorax = null;
                }
                if (ckb_pulmones.Checked == true)
                {
                    perio.perio_pulmonesTorax2 = "SI";
                }
                else
                {
                    perio.perio_pulmonesTorax2 = null;
                }
                if (ckb_parrillacostal.Checked == true)
                {
                    perio.perio_parriCostalTorax2 = "SI";
                }
                else
                {
                    perio.perio_parriCostalTorax2 = null;
                }
                if (ckb_visceras.Checked == true)
                {
                    perio.perio_viscerasAbdomen = "SI";
                }
                else
                {
                    perio.perio_viscerasAbdomen = null;
                }
                if (ckb_paredabdominal.Checked == true)
                {
                    perio.perio_paredAbdomiAbdomen = "SI";
                }
                else
                {
                    perio.perio_paredAbdomiAbdomen = null;
                }
                if (ckb_flexibilidad.Checked == true)
                {
                    perio.perio_flexibilidadColumna = "SI";
                }
                else
                {
                    perio.perio_flexibilidadColumna = null;
                }
                if (ckb_desviacion.Checked == true)
                {
                    perio.perio_desviacionColumna = "SI";
                }
                else
                {
                    perio.perio_desviacionColumna = null;
                }
                if (ckb_dolor.Checked == true)
                {
                    perio.perio_dolorColumna = "SI";
                }
                else
                {
                    perio.perio_dolorColumna = null;
                }
                if (ckb_pelvis.Checked == true)
                {
                    perio.perio_pelvisPelvis = "SI";
                }
                else
                {
                    perio.perio_pelvisPelvis = null;
                }
                if (ckb_genitales.Checked == true)
                {
                    perio.perio_genitalesPelvis = "SI";
                }
                else
                {
                    perio.perio_genitalesPelvis = null;
                }
                if (ckb_vascular.Checked == true)
                {
                    perio.perio_vascularExtre = "SI";
                }
                else
                {
                    perio.perio_vascularExtre = null;
                }
                if (ckb_miembrosuperiores.Checked == true)
                {
                    perio.perio_miemSupeExtre = "SI";
                }
                else
                {
                    perio.perio_miemSupeExtre = null;
                }
                if (ckb_miembrosinferiores.Checked == true)
                {
                    perio.perio_miemInfeExtre = "SI";
                }
                else
                {
                    perio.perio_miemInfeExtre = null;
                }
                if (ckb_fuerza.Checked == true)
                {
                    perio.perio_fuerzaNeuro = "SI";
                }
                else
                {
                    perio.perio_fuerzaNeuro = null;
                }
                if (ckb_sensibilidad.Checked == true)
                {
                    perio.perio_sensibiNeuro = "SI";
                }
                else
                {
                    perio.perio_sensibiNeuro = null;
                }
                if (ckb_marcha.Checked == true)
                {
                    perio.perio_marchaNeuro = "SI";
                }
                else
                {
                    perio.perio_marchaNeuro = null;
                }
                if (ckb_reflejos.Checked == true)
                {
                    perio.perio_refleNeuro = "SI";
                }
                else
                {
                    perio.perio_refleNeuro = null;
                }

                //Diagnostco
                if (ckb_pre.Checked == true)
                {
                    perio.perio_pre = "SI";
                }
                else
                {
                    perio.perio_pre = null;
                }
                if (ckb_pre2.Checked == true)
                {
                    perio.perio_pre2 = "SI";
                }
                else
                {
                    perio.perio_pre2 = null;
                }
                if (ckb_pre3.Checked == true)
                {
                    perio.perio_pre3 = "SI";
                }
                else
                {
                    perio.perio_pre3 = null;
                }
                if (ckb_def.Checked == true)
                {
                    perio.perio_def = "SI";
                }
                else
                {
                    perio.perio_def = null;
                }
                if (ckb_def2.Checked == true)
                {
                    perio.perio_def2 = "SI";
                }
                else
                {
                    perio.perio_def2 = null;
                }
                if (ckb_def3.Checked == true)
                {
                    perio.perio_def3 = "SI";
                }
                else
                {
                    perio.perio_def3 = null;
                }

                //Aptitud Medica para el trabajo
                if (ckb_apto.Checked == true)
                {
                    perio.perio_apto = "SI";
                }
                else
                {
                    perio.perio_apto = null;
                }
                if (ckb_aptoobservacion.Checked == true)
                {
                    perio.perio_aptoObserva = "SI";
                }
                else
                {
                    perio.perio_aptoObserva = null;
                }
                if (ckb_aptolimitacion.Checked == true)
                {
                    perio.perio_aptoLimi = "SI";
                }
                else
                {
                    perio.perio_aptoLimi = null;
                }
                if (ckb_noapto.Checked == true)
                {
                    perio.perio_NoApto = "SI";
                }
                else
                {
                    perio.perio_NoApto = null;
                }

                //A
                perio.perio_ciiu = txt_ciiu.Text.ToUpper();
                perio.perio_numArchivo = txt_numArchivo.Text.ToUpper();

                //B.
                perio.perio_descripMotiConsulta = txt_motivoconsultaperiodica.Text.ToUpper();

                //C.
                perio.perio_descripcionAntCliQuirurgicos = txt_antCliQuiDescripcion.Text.ToUpper();

                perio.perio_tiempoConsuConsuNocivosTabaco = txt_tiemConConsuNociTabaHabToxi.Text.ToUpper();
                perio.perio_cantidadConsuNocivosTabaco = txt_cantiConsuNociTabaHabToxi.Text.ToUpper();
                perio.perio_exConsumiConsuNocivosTabaco = txt_exConsumiConsuNociTabaHabToxi.Text.ToUpper();
                perio.perio_tiempoAbstiConsuNocivosTabaco = txt_tiemAbstiConsuNociTabaHabToxi.Text.ToUpper();

                perio.perio_tiempoConsuConsuNocivosAlcohol = txt_tiemConConsuNociAlcoHabToxi.Text.ToUpper();
                perio.perio_cantidadConsuNocivosAlcohol = txt_cantiConsuNociAlcoHabToxi.Text.ToUpper();
                perio.perio_exConsumiConsuNocivosAlcohol = txt_exConsumiConsuNociAlcoHabToxi.Text.ToUpper();
                perio.perio_tiempoAbstiConsuNocivosAlcohol = txt_tiemAbstiConsuNociAlcoHabToxi.Text.ToUpper();

                perio.perio_tiempoConsu1ConsuNocivosOtrasDrogas = txt_tiemCon1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_cantidad1ConsuNocivosOtrasDrogas = txt_canti1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_exConsumi1ConsuNocivosOtrasDrogas = txt_exConsumi1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_tiempoAbsti1ConsuNocivosOtrasDrogas = txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_otrasConsuNocivos = txt_otrasConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_tiempoConsu2ConsuNocivosOtrasDrogas = txt_tiemCon2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_cantidad2ConsuNocivosOtrasDrogas = txt_canti2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_exConsumi2ConsuNocivosOtrasDrogas = txt_exConsumi2ConsuNociOtrasDroHabToxi.Text.ToUpper();
                perio.perio_tiempoAbsti2ConsuNocivosOtrasDrogas = txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text.ToUpper();

                perio.perio_cualEstiVidaActFisica = txt_cualEstVidaActFisiEstVida.Text.ToUpper();
                perio.perio_tiem_cantEstiVidaActFisica = txt_tiemCanEstVidaActFisiEstVida.Text.ToUpper();

                perio.perio_cual1EstiVidaMediHabitual = txt_cual1EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_tiem_cant1EstiVidaMediHabitual = txt_tiemCan1EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_cual2EstiVidaMediHabitual = txt_cual2EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_tiem_cant2EstiVidaMediHabitual = txt_tiemCan2EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_cual3EstiVidaMediHabitual = txt_cual3EstVidaMedHabiEstVida.Text.ToUpper();
                perio.perio_tiem_cant3EstiVidaMediHabitual = txt_tiemCan3EstVidaMedHabiEstVida.Text.ToUpper();

                perio.perio_descripIncidentes = txt_incidentesperiodica.Text.ToUpper();

                perio.perio_EspecifiCalificadoIESSAcciTrabajo = txt_especificarcalificadotrabajo.Text.ToUpper();
                perio.perio_fechaCalificadoIESSAcciTrabajo = txt_fechacalificadotrabajo.Text.ToUpper();
                perio.perio_observacionesAcciTrabajo = txt_obsercalificadotrabajo.Text.ToUpper();

                perio.perio_EspecifiCalificadoIESSEnferProfesionales = txt_especificarcalificadoprofesional.Text.ToUpper();
                perio.perio_fechaCalificadoIESSEnferProfesionales = txt_fechacalificadoprofesional.Text.ToUpper();
                perio.perio_observacionesEnferProfesionales = txt_obsercalificadoprofesional.Text.ToUpper();

                //D.
                perio.perio_descripcionAntFamiliares = txt_descripcionantefamiliares.Text.ToUpper();

                //E.
                perio.perio_area = txt_puestotrabajo.Text.ToUpper();
                perio.perio_area2 = txt_puestotrabajo2.Text.ToUpper();
                perio.perio_area3 = txt_puestotrabajo3.Text.ToUpper();
                perio.perio_actividades = txt_act.Text.ToUpper();
                perio.perio_actividades2 = txt_act2.Text.ToUpper();
                perio.perio_actividades3 = txt_act3.Text.ToUpper();
                perio.perio_tiemTrabajo = txt_tiempotrabajo.Text.ToUpper();
                perio.perio_tiemTrabajo2 = txt_tiempotrabajo2.Text.ToUpper();
                perio.perio_tiemTrabajo3 = txt_tiempotrabajo3.Text.ToUpper();
                perio.perio_medPreventivas = txt_medpreventivas.Text.ToUpper();
                perio.perio_medPreventivas2 = txt_medpreventivas2.Text.ToUpper();
                perio.perio_medPreventivas3 = txt_medpreventivas3.Text.ToUpper();

                //F.
                perio.perio_descripEnfActual = txt_enfermedadactualperiodica.Text.ToUpper();

                //G.
                perio.perio_descripRevOrgaSistemas = txt_descrorganosysistemasperiodica.Text.ToUpper();

                //H.
                perio.perio_preArterial = txt_preArterial.Text.ToUpper();
                perio.perio_temperatura = txt_temperatura.Text.ToUpper();
                perio.perio_frecCardiacan = txt_freCardica.Text.ToUpper();
                perio.perio_satOxigenon = txt_satOxigeno.Text.ToUpper();
                perio.perio_frecRespiratorian = txt_freRespiratoria.Text.ToUpper();
                perio.perio_peson = txt_peso.Text.ToUpper();
                perio.perio_tallan = txt_talla.Text.ToUpper();
                perio.perio_indMasCorporaln = txt_indMasCorporal.Text.ToUpper();
                perio.perio_perAbdominaln = txt_perAbdominal.Text.ToUpper();

                //I.
                perio.perio_observaExaFisRegional = txt_observexamenfisicoregional.Text.ToUpper();

                //J.
                perio.perio_examen = txt_examen.Text.ToUpper();
                perio.perio_examen2 = txt_examen2.Text.ToUpper();
                perio.perio_fecha = txt_fechaexamen.Text.ToUpper();
                perio.perio_fecha2 = txt_fechaexamen2.Text.ToUpper();
                perio.perio_resultado = txt_resultadoexamen.Text.ToUpper();
                perio.perio_resultado2 = txt_resultadoexamen2.Text.ToUpper();
                perio.perio_observacionesResExaGenEspPuesTrabajo = txt_observacionexamen.Text.ToUpper();

                //K.
                perio.perio_descripcionDiagnostico = txt_descripdiagnostico.Text.ToUpper();
                perio.perio_descripcionDiagnostico2 = txt_descripdiagnostico2.Text.ToUpper();
                perio.perio_descripcionDiagnostico3 = txt_descripdiagnostico3.Text.ToUpper();
                perio.perio_cie = txt_cie.Text.ToUpper();
                perio.perio_cie2 = txt_cie2.Text.ToUpper();
                perio.perio_cie3 = txt_cie3.Text.ToUpper();

                //L.
                perio.perio_ObservAptMedTrabajo = txt_observacionaptitud.Text.ToUpper();
                perio.perio_LimitAptMedTrabajo = txt_limitacionaptitud.Text.ToUpper();


                //M.
                perio.perio_descripcionRecoTratamiento = txt_descripciontratamientoperiodica.Text.ToUpper();

                //N.
                perio.perio_fecha_horaModificacion = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                perio.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                perio.perio_cod = txt_codigoDatProf.Text.ToUpper();

                CN_Periodica.ModificarPeriodica(perio);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }

        private void guardar_modificar_datos(int periodica)
        {
            if (periodica == 0)
            {
                GuardarPeriodica();
            }
            else
            {
                perio = CN_Periodica.ObtenerPeriodicaPorId(periodica);

                if (perio != null)
                {
                    ModificarPeriodica(perio);
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
                // Mostrar el elemento de carga
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowLoading", "ShowLoadingElement();", true);

                // Ejecutar el procesamiento en el servidor
                guardar_modificar_datos(Convert.ToInt32(Request["cod"]));

                // Ocultar el elemento de carga
                ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "HideLoadingElement();", true);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Alerta!', 'Datos No Modificados', 'alrt')", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Llenar primero la talla')", true);
                txt_peso.Text = "";
                txt_talla.Focus();
            }
        }

        private void defaultValidaciones()
        {
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
            txt_especificarcalificadotrabajo.Enabled = false;
            txt_fechacalificadotrabajo.Enabled = false;
            txt_obsercalificadotrabajo.Enabled = false;
            txt_especificarcalificadoprofesional.Enabled = false;
            txt_fechacalificadoprofesional.Enabled = false;
            txt_obsercalificadoprofesional.Enabled = false;
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

        protected void ckb_sicalificadotrabajo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_sicalificadotrabajo.Checked == true)
            {
                txt_especificarcalificadotrabajo.Enabled = true;
                txt_fechacalificadotrabajo.Enabled = true;
                txt_obsercalificadotrabajo.Enabled = true;
                ckb_nocalificadotrabajo.Checked = false;
            }
        }

        protected void ckb_nocalificadotrabajo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_nocalificadotrabajo.Checked == true)
            {
                txt_especificarcalificadotrabajo.Enabled = false;
                txt_especificarcalificadotrabajo.Text = "";
                txt_fechacalificadotrabajo.Enabled = false;
                txt_fechacalificadotrabajo.Text = "";
                txt_obsercalificadotrabajo.Enabled = false;
                txt_obsercalificadotrabajo.Text = "";
                ckb_sicalificadotrabajo.Checked = false;
            }
        }

        protected void ckb_sicalificadoprofesional_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_sicalificadoprofesional.Checked == true)
            {
                txt_especificarcalificadoprofesional.Enabled = true;
                ckb_nocalificadoprofesional.Checked = false;
                txt_fechacalificadoprofesional.Enabled = true;
                txt_obsercalificadoprofesional.Enabled = true;
            }
        }

        protected void ckb_nocalificadoprofesional_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_nocalificadoprofesional.Checked == true)
            {
                txt_especificarcalificadoprofesional.Enabled = false;
                txt_especificarcalificadoprofesional.Text = "";
                ckb_sicalificadoprofesional.Checked = false;
                txt_fechacalificadoprofesional.Enabled = false;
                txt_fechacalificadoprofesional.Text = "";
                txt_obsercalificadoprofesional.Enabled = false;
                txt_obsercalificadoprofesional.Text = "";
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
            c2.Phrase = new Phrase("HISTORIA CLÍNICA OCUPACIONAL - INICIAL", titulo);
            tblEncabezado.AddCell(c2);
            pdfDoc.Add(tblEncabezado);
            pdfDoc.Add(new Paragraph(" "));

            //A. DATOS DEL ESTABLECIMIENTO - EMPRESA Y USUARIO
            var tblinf = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblinf.AddCell(new PdfPCell(new Paragraph("A. DATOS DEL ESTABLECIMIENTO - EMPRESA Y USUARIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblinf);
            var tblinfTitulo = new PdfPTable(new float[] { 80f, 40f, 40f, 60f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("INSTITUCIÓN DEL SISTEMA O NOMBRE DE LA EMPRESA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("RUC", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("CIIU", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("ESTABLECIMIENTO DE SALUD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("NÚMERO DE HISTORIA CLÍNICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblinfTitulo.AddCell(new PdfPCell(new Paragraph("NÚMERO DE ARCHIVO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblinfTitulo);
            var tblinfDatos = new PdfPTable(new float[] { 80f, 40f, 40f, 60f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_nomEmpresa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_rucEmp.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_ciiu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_estableSalud.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_numHClinica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblinfDatos.AddCell(new PdfPCell(new Paragraph(txt_numArchivo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblinfDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblTitulo = new PdfPTable(new float[] { 25f, 25f, 25f, 25f, 10f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEXO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PUESTO DE TRABAJO (CIUO)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblTitulo);
            var tblDatos = new PdfPTable(new float[] { 25f, 25f, 25f, 25f, 10f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priApellido.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segApellido.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_sexo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_puestodetrabajoperiodica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblDatos);

            //B. MOTIVO DE CONSULTA
            pdfDoc.Add(new Paragraph(" "));
            var tblMotCon = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblMotCon.AddCell(new PdfPCell(new Paragraph("B. MOTIVO DE CONSULTA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblMotCon);
            var tblMconsul = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblMconsul.AddCell(new PdfPCell(new Paragraph(txt_motivoconsultaperiodica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblMconsul);

            //C. ANTECEDENTES PERSONALES
            pdfDoc.Add(new Paragraph(" "));
            var tblAntPerso = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblAntPerso.AddCell(new PdfPCell(new Paragraph("C. ANTECEDENTES PERSONALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblAntPerso);
            var tblacqTitulo = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblacqTitulo.AddCell(new PdfPCell(new Paragraph("ANTECEDENTES CLÍNICOS Y QUIRÚRGICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblacqTitulo);
            var tblacqDatos = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblacqDatos.AddCell(new PdfPCell(new Paragraph(txt_antCliQuiDescripcion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblacqDatos);

            //HABITOS TOXICOS
            var tblhtTitulo = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblacqTitulo.AddCell(new PdfPCell(new Paragraph("HÁBITOS TÓXICOS ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblacqTitulo);
            var tblhtTitulo2 = new PdfPTable(new float[] { 100f, 20f, 20f, 50f, 60f, 60f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhtTitulo2.AddCell(new PdfPCell(new Paragraph("CONSUMOS NOCIVOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblhtTitulo2.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblhtTitulo2.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblhtTitulo2.AddCell(new PdfPCell(new Paragraph("TIEMPO DE CONSUMO (MESES)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblhtTitulo2.AddCell(new PdfPCell(new Paragraph("CANTIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblhtTitulo2.AddCell(new PdfPCell(new Paragraph("EX CONSUMIDOR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblhtTitulo2.AddCell(new PdfPCell(new Paragraph("TIEMPO DE ABSTINENCIA (MESES)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblhtTitulo2);
            var tblhtDatos = new PdfPTable(new float[] { 100f, 20f, 20f, 50f, 60f, 60f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhtDatos.AddCell(new PdfPCell(new Paragraph("TABACO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siConsuNociTabaHabToxi.Checked == true)
            {
                tblhtDatos.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblhtDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noConsuNociTabaHabToxi.Checked == true)
            {
                tblhtDatos.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblhtDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblhtDatos.AddCell(new PdfPCell(new Paragraph(txt_tiemConConsuNociTabaHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos.AddCell(new PdfPCell(new Paragraph(txt_cantiConsuNociTabaHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos.AddCell(new PdfPCell(new Paragraph(txt_exConsumiConsuNociTabaHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos.AddCell(new PdfPCell(new Paragraph(txt_tiemAbstiConsuNociTabaHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblhtDatos);
            var tblhtDatos2 = new PdfPTable(new float[] { 100f, 20f, 20f, 50f, 60f, 60f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhtDatos2.AddCell(new PdfPCell(new Paragraph("ALCOHOL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siConsuNociAlcoHabToxi.Checked == true)
            {
                tblhtDatos2.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblhtDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_noConsuNociAlcoHabToxi.Checked == true)
            {
                tblhtDatos2.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblhtDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblhtDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiemConConsuNociAlcoHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos2.AddCell(new PdfPCell(new Paragraph(txt_cantiConsuNociAlcoHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos2.AddCell(new PdfPCell(new Paragraph(txt_exConsumiConsuNociAlcoHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos2.AddCell(new PdfPCell(new Paragraph(txt_tiemAbstiConsuNociAlcoHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblhtDatos2);
            var tblhtDatos3 = new PdfPTable(new float[] { 100f, 20f, 20f, 50f, 60f, 60f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhtDatos3.AddCell(new PdfPCell(new Paragraph("OTRAS DROGAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siConsuNociOtrasDroHabToxi.Checked == true)
            {
                tblhtDatos3.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            }
            else
            {
                tblhtDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            }
            if (ckb_noConsuNociOtrasDroHabToxi.Checked == true)
            {
                tblhtDatos3.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            }
            else
            {
                tblhtDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 2 });
            }
            tblhtDatos3.AddCell(new PdfPCell(new Paragraph(txt_tiemCon1ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos3.AddCell(new PdfPCell(new Paragraph(txt_canti1ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos3.AddCell(new PdfPCell(new Paragraph(txt_exConsumi1ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos3.AddCell(new PdfPCell(new Paragraph(txt_tiemAbsti1ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblhtDatos3);

            var tblhtDatos4 = new PdfPTable(new float[] { 100f, 50f, 60f, 60f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblhtDatos4.AddCell(new PdfPCell(new Paragraph(txt_otrasConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos4.AddCell(new PdfPCell(new Paragraph(txt_otrasConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos4.AddCell(new PdfPCell(new Paragraph(txt_canti2ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos4.AddCell(new PdfPCell(new Paragraph(txt_exConsumi2ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblhtDatos4.AddCell(new PdfPCell(new Paragraph(txt_tiemAbsti2ConsuNociOtrasDroHabToxi.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblhtDatos4);

            //ESTILO DE VIDA
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

            //INCIDENTES 
            pdfDoc.Add(new Paragraph(" "));
            var tblacqTituloInci = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblacqTituloInci.AddCell(new PdfPCell(new Paragraph("INCIDENTES ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblacqTituloInci);
            var tblacqDatosInci = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblacqDatosInci.AddCell(new PdfPCell(new Paragraph(txt_incidentesperiodica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblacqDatosInci);

            // ACCIDENTES DE TRABAJO (DESCRIPCIÓN)
            pdfDoc.Add(new Paragraph(" "));
            var tblatTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatTitulo.AddCell(new PdfPCell(new Paragraph("ACCIDENTES DE TRABAJO (DESCRIPCIÓN)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblatTitulo);
            var tblatDatos = new PdfPTable(new float[] { 90f, 10f, 10f, 40f, 50f, 10f, 10f, 20f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatDatos.AddCell(new PdfPCell(new Paragraph("FUE CALIFICADO POR EL INSTITUTO DE SEGURIDAD SOCIAL CORRESPONDIENTE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_sicalificadotrabajo.Checked == true)
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblatDatos.AddCell(new PdfPCell(new Paragraph("ESPECIFICAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph(txt_especificarcalificadotrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_nocalificadotrabajo.Checked == true)
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblatDatos.AddCell(new PdfPCell(new Paragraph("FECHA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph(txt_fechacalificadotrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblatDatos);
            var tblatDatos1 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatDatos1.AddCell(new PdfPCell(new Paragraph(txt_obsercalificadotrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT }); ;
            pdfDoc.Add(tblatDatos1);

            //ENFERMEDADES PROFESIONALES
            pdfDoc.Add(new Paragraph(" "));
            var tblefTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefTitulo.AddCell(new PdfPCell(new Paragraph("ENFERMEDADES PROFESIONALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefTitulo);
            var tblefDatos = new PdfPTable(new float[] { 90f, 10f, 10f, 40f, 50f, 10f, 10f, 20f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefDatos.AddCell(new PdfPCell(new Paragraph("FUE CALIFICADO POR EL INSTITUTO DE SEGURIDAD SOCIAL CORRESPONDIENTE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_sicalificadoprofesional.Checked == true)
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblefDatos.AddCell(new PdfPCell(new Paragraph("ESPECIFICAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph(txt_especificarcalificadoprofesional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_nocalificadoprofesional.Checked == true)
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblefDatos.AddCell(new PdfPCell(new Paragraph("FECHA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph(txt_fechacalificadoprofesional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblefDatos);
            var tblefDatos1 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefDatos1.AddCell(new PdfPCell(new Paragraph(txt_obsercalificadoprofesional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefDatos1);

            //D. ANTECEDENTES FAMILIARES (DETALLAR EL PARENTESCO)
            pdfDoc.Add(new Paragraph(" "));
            var tblaf = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaf.AddCell(new PdfPCell(new Paragraph("D. ANTECEDENTES FAMILIARES (DETALLAR EL PARENTESCO)", cuadro)) { BorderColor = new BaseColor(204, 205, 254), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblaf.AddCell(new PdfPCell(new Paragraph("DESCRIBIR ABAJO ANOTANDO EL NÚMERO", cuadro)) { BorderColor = new BaseColor(204, 205, 254), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_RIGHT });
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

            //E.  FACTORES DE RIESGOS DEL PUESTO DE TRABAJO
            pdfDoc.Add(new Paragraph(" "));
            var tblfr = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfr.AddCell(new PdfPCell(new Paragraph("E.  FACTORES DE RIESGOS DEL PUESTO DE TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
            tblfrDatos.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
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
            tblfrDatos1.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
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
            tblfrDatos2.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
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
            tblbeDatos.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo21.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
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
            tblbeDatos1.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo22.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
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
            tblbeDatos2.AddCell(new PdfPCell(new Paragraph(txt_puestotrabajo23.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
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
            if (ckb_otrosPsisocial.Checked == true)
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
            if (ckb_otrosPsisocial2.Checked == true)
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
            if (ckb_otrosPsisocial3.Checked == true)
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblpsDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblpsDatos2.AddCell(new PdfPCell(new Paragraph(txt_medpreventivas3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblpsDatos2);

            //F. ENFERMEDAD ACTUAL
            pdfDoc.Add(new Paragraph(" "));
            var tblea = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblea.AddCell(new PdfPCell(new Paragraph("F. ENFERMEDAD ACTUAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblea);
            var tbleaDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbleaDatos.AddCell(new PdfPCell(new Paragraph(txt_enfermedadactualperiodica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbleaDatos);

            //G. REVISIÓN DE ÓRGANOS Y SISTEMAS 
            pdfDoc.Add(new Paragraph(" "));
            var tblos = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblos.AddCell(new PdfPCell(new Paragraph("G. REVISIÓN DE ÓRGANOS Y SISTEMAS ", cuadro)) { BorderColor = new BaseColor(204, 205, 254), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblos.AddCell(new PdfPCell(new Paragraph("EN CASO DE EXISTIR PATOLOGÍA, MARCAR CON \"X\"  Y DESCRIBIR ABAJO ANOTANDO EL NUMERAL", cuadro)) { BorderColor = new BaseColor(204, 205, 254), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_RIGHT });
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
            tblosTitulo2.AddCell(new PdfPCell(new Paragraph(txt_descrorganosysistemasperiodica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT }); ;
            pdfDoc.Add(tblafTitulo2);

            //H. CONSTANTES VITALES Y ANTROPOMETRÍA
            pdfDoc.Add(new Paragraph(" "));
            var tblcva = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcva.AddCell(new PdfPCell(new Paragraph("H. CONSTANTES VITALES Y ANTROPOMETRÍA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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

            //I. EXAMEN FÍSICO REGIONAL
            pdfDoc.Add(new Paragraph(" "));
            var tblefr = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefr.AddCell(new PdfPCell(new Paragraph("I. EXAMEN FÍSICO REGIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
            tblrgDatos1.AddCell(new PdfPCell(new Paragraph(txt_observexamenfisicoregional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrgDatos1);

            //J. RESULTADOS DE EXÁMENES GENERALES Y ESPECÍFICOS DE ACUERDO AL RIESGO Y PUESTO DE TRABAJO (IMAGEN, LABORATORIO Y OTROS)
            pdfDoc.Add(new Paragraph(" "));
            var tbleg = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbleg.AddCell(new PdfPCell(new Paragraph("J. RESULTADOS DE EXÁMENES GENERALES Y ESPECÍFICOS DE ACUERDO AL RIESGO Y PUESTO DE TRABAJO (IMAGEN, LABORATORIO Y OTROS)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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

            //K. DIAGNÓSTICO  
            pdfDoc.Add(new Paragraph(" "));
            var tbldg = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldg.AddCell(new PdfPCell(new Paragraph("K. DIAGNÓSTICO  ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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

            //L. APTITUD MÉDICA PARA EL TRABAJO
            pdfDoc.Add(new Paragraph(" "));
            var tblaml = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaml.AddCell(new PdfPCell(new Paragraph("L. APTITUD MÉDICA PARA EL TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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

            //M. RECOMENDACIONES Y/O TRATAMIENTO
            pdfDoc.Add(new Paragraph(" "));
            var tblryt = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblryt.AddCell(new PdfPCell(new Paragraph("O. RECOMENDACIONES Y/O TRATAMIENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblryt);
            var tblrytDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrytDatos.AddCell(new PdfPCell(new Paragraph(txt_descripciontratamientoperiodica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrytDatos);


            pdfDoc.Add(new Paragraph(" "));
            var tblcm = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcm.AddCell(new PdfPCell(new Paragraph("CERTIFICO QUE LO ANTERIORMENTE EXPRESADO EN RELACIÓN A MI ESTADO DE SALUD ES VERDAD. SE ME HA INFORMADO LAS MEDIDAS PREVENTIVAS A TOMAR PARA DISMINUIR O MITIGAR LOS RIESGOS RELACIONADOS CON MI ACTIVIDAD LABORAL.\r\n", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblcm);


            //N. DATOS DEL PROFESIONAL
            pdfDoc.Add(new Paragraph(" "));
            var tbldps = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldps.AddCell(new PdfPCell(new Paragraph("N. DATOS DEL PROFESIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
            Response.AddHeader("content-disposition", "attachment;filename=Periodica_" + txt_numHClinica.Text + "_" + DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm") + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}