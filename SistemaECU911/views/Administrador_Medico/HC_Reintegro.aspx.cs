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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SistemaECU911.Template.Views
{
    public partial class Reintegro : System.Web.UI.Page
    {
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        private Tbl_Empresa emp = new Tbl_Empresa();
        private Tbl_Centro cen = new Tbl_Centro();
        private Tbl_Reintegro reinte = new Tbl_Reintegro();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    reinte = CN_Reintegro.ObtenerReintegroPorId(codigo);
                    int personasid = Convert.ToInt32(reinte.Per_id.ToString());
                    per = CN_HistorialMedico.ObtenerPersonasxId(personasid);
                    int empresaid = Convert.ToInt32(reinte.Emp_id.ToString());
                    emp = CN_HistorialMedico.ObtenerEmpresaxId(empresaid);


                    btn_guardar.Text = "Actualizar";

                    if (per != null || emp != null)
                    {

                        txt_numHClinica.ReadOnly = true;
                        cargarProfesional();
                        ddl_profesional.Enabled = false;

                        //Regiones
                        if (reinte.rein_cicatricesPiel == null)
                        {
                            ckb_cicatrices.Checked = false;
                        }
                        else
                        {
                            ckb_cicatrices.Checked = true;

                        }
                        if (reinte.rein_tatuajesPiel == null)
                        {
                            ckb_tatuajes.Checked = false;
                        }
                        else
                        {
                            ckb_tatuajes.Checked = true;

                        }
                        if (reinte.rein_pielFacerasPiel == null)
                        {
                            ckb_pielyfaneras.Checked = false;
                        }
                        else
                        {
                            ckb_pielyfaneras.Checked = true;

                        }
                        if (reinte.rein_parpadosOjos == null)
                        {
                            ckb_parpados.Checked = false;
                        }
                        else
                        {
                            ckb_parpados.Checked = true;

                        }
                        if (reinte.rein_conjuntuvasOjos == null)
                        {
                            ckb_conjuntivas.Checked = false;
                        }
                        else
                        {
                            ckb_conjuntivas.Checked = true;

                        }
                        if (reinte.rein_pupilasOjos == null)
                        {
                            ckb_pupilas.Checked = false;
                        }
                        else
                        {
                            ckb_pupilas.Checked = true;

                        }
                        if (reinte.rein_corneaOjos == null)
                        {
                            ckb_cornea.Checked = false;
                        }
                        else
                        {
                            ckb_cornea.Checked = true;

                        }
                        if (reinte.rein_motilidadOjos == null)
                        {
                            ckb_motilidad.Checked = false;
                        }
                        else
                        {
                            ckb_motilidad.Checked = true;

                        }
                        if (reinte.rein_cAudiExtreOido == null)
                        {
                            ckb_auditivoexterno.Checked = false;
                        }
                        else
                        {
                            ckb_auditivoexterno.Checked = true;

                        }
                        if (reinte.rein_pabellonOido == null)
                        {
                            ckb_pabellon.Checked = false;
                        }
                        else
                        {
                            ckb_pabellon.Checked = true;

                        }
                        if (reinte.rein_timpanosOido == null)
                        {
                            ckb_timpanos.Checked = false;
                        }
                        else
                        {
                            ckb_timpanos.Checked = true;

                        }
                        if (reinte.rein_labiosOroFa == null)
                        {
                            ckb_labios.Checked = false;
                        }
                        else
                        {
                            ckb_labios.Checked = true;

                        }
                        if (reinte.rein_lenguaOroFa == null)
                        {
                            ckb_lengua.Checked = false;
                        }
                        else
                        {
                            ckb_lengua.Checked = true;

                        }
                        if (reinte.rein_faringeOroFa == null)
                        {
                            ckb_faringe.Checked = false;
                        }
                        else
                        {
                            ckb_faringe.Checked = true;

                        }
                        if (reinte.rein_amigdalasOroFa == null)
                        {
                            ckb_amigdalas.Checked = false;
                        }
                        else
                        {
                            ckb_amigdalas.Checked = true;

                        }
                        if (reinte.rein_dentaduraOroFa == null)
                        {
                            ckb_dentadura.Checked = false;
                        }
                        else
                        {
                            ckb_dentadura.Checked = true;

                        }
                        if (reinte.rein_tabiqueNariz == null)
                        {
                            ckb_tabique.Checked = false;
                        }
                        else
                        {
                            ckb_tabique.Checked = true;

                        }
                        if (reinte.rein_cornetesNariz == null)
                        {
                            ckb_cornetes.Checked = false;
                        }
                        else
                        {
                            ckb_cornetes.Checked = true;

                        }
                        if (reinte.rein_mucosasNariz == null)
                        {
                            ckb_mucosa.Checked = false;
                        }
                        else
                        {
                            ckb_mucosa.Checked = true;

                        }
                        if (reinte.rein_senosParanaNariz == null)
                        {
                            ckb_senosparanasales.Checked = false;
                        }
                        else
                        {
                            ckb_senosparanasales.Checked = true;

                        }
                        if (reinte.rein_tiroiMasasCuello == null)
                        {
                            ckb_tiroides.Checked = false;
                        }
                        else
                        {
                            ckb_tiroides.Checked = true;

                        }
                        if (reinte.rein_movilidadCuello == null)
                        {
                            ckb_movilidad.Checked = false;
                        }
                        else
                        {
                            ckb_movilidad.Checked = true;

                        }
                        if (reinte.rein_mamasTorax == null)
                        {
                            ckb_mamas.Checked = false;
                        }
                        else
                        {
                            ckb_mamas.Checked = true;

                        }
                        if (reinte.rein_corazonTorax == null)
                        {
                            ckb_corazon.Checked = false;
                        }
                        else
                        {
                            ckb_corazon.Checked = true;

                        }
                        if (reinte.rein_pulmonesTorax2 == null)
                        {
                            ckb_pulmones.Checked = false;
                        }
                        else
                        {
                            ckb_pulmones.Checked = true;

                        }
                        if (reinte.rein_parriCostalTorax2 == null)
                        {
                            ckb_parrillacostal.Checked = false;
                        }
                        else
                        {
                            ckb_parrillacostal.Checked = true;

                        }
                        if (reinte.rein_viscerasAbdomen == null)
                        {
                            ckb_visceras.Checked = false;
                        }
                        else
                        {
                            ckb_visceras.Checked = true;

                        }
                        if (reinte.rein_paredAbdomiAbdomen == null)
                        {
                            ckb_paredabdominal.Checked = false;
                        }
                        else
                        {
                            ckb_paredabdominal.Checked = true;

                        }
                        if (reinte.rein_flexibilidadColumna == null)
                        {
                            ckb_flexibilidad.Checked = false;
                        }
                        else
                        {
                            ckb_flexibilidad.Checked = true;

                        }
                        if (reinte.rein_desviacionColumna == null)
                        {
                            ckb_desviacion.Checked = false;
                        }
                        else
                        {
                            ckb_desviacion.Checked = true;

                        }
                        if (reinte.rein_dolorColumna == null)
                        {
                            ckb_dolor.Checked = false;
                        }
                        else
                        {
                            ckb_dolor.Checked = true;

                        }
                        if (reinte.rein_pelvisPelvis == null)
                        {
                            ckb_pelvis.Checked = false;
                        }
                        else
                        {
                            ckb_pelvis.Checked = true;

                        }
                        if (reinte.rein_genitalesPelvis == null)
                        {
                            ckb_genitales.Checked = false;
                        }
                        else
                        {
                            ckb_genitales.Checked = true;

                        }
                        if (reinte.rein_vascularExtre == null)
                        {
                            ckb_vascular.Checked = false;
                        }
                        else
                        {
                            ckb_vascular.Checked = true;

                        }
                        if (reinte.rein_miemSupeExtre == null)
                        {
                            ckb_miembrosuperiores.Checked = false;
                        }
                        else
                        {
                            ckb_miembrosuperiores.Checked = true;

                        }
                        if (reinte.rein_miemInfeExtre == null)
                        {
                            ckb_miembrosinferiores.Checked = false;
                        }
                        else
                        {
                            ckb_miembrosinferiores.Checked = true;

                        }
                        if (reinte.rein_fuerzaNeuro == null)
                        {
                            ckb_fuerza.Checked = false;
                        }
                        else
                        {
                            ckb_fuerza.Checked = true;

                        }
                        if (reinte.rein_sensibiNeuro == null)
                        {
                            ckb_sensibilidad.Checked = false;
                        }
                        else
                        {
                            ckb_sensibilidad.Checked = true;

                        }
                        if (reinte.rein_marchaNeuro == null)
                        {
                            ckb_marcha.Checked = false;
                        }
                        else
                        {
                            ckb_marcha.Checked = true;

                        }
                        if (reinte.rein_refleNeuro == null)
                        {
                            ckb_reflejos.Checked = false;
                        }
                        else
                        {
                            ckb_reflejos.Checked = true;

                        }

                        //Diagnostco
                        if (reinte.rein_pre == null)
                        {
                            ckb_pre.Checked = false;
                        }
                        else
                        {
                            ckb_pre.Checked = true;

                        }
                        if (reinte.rein_pre2 == null)
                        {
                            ckb_pre2.Checked = false;
                        }
                        else
                        {
                            ckb_pre2.Checked = true;

                        }
                        if (reinte.rein_pre3 == null)
                        {
                            ckb_pre3.Checked = false;
                        }
                        else
                        {
                            ckb_pre3.Checked = true;

                        }
                        if (reinte.rein_def == null)
                        {
                            ckb_def.Checked = false;
                        }
                        else
                        {
                            ckb_def.Checked = true;

                        }
                        if (reinte.rein_def2 == null)
                        {
                            ckb_def2.Checked = false;
                        }
                        else
                        {
                            ckb_def2.Checked = true;

                        }
                        if (reinte.rein_def3 == null)
                        {
                            ckb_def3.Checked = false;
                        }
                        else
                        {
                            ckb_def3.Checked = true;

                        }

                        //Aptitud Medica para el trabajo
                        if (reinte.rein_apto == null)
                        {
                            ckb_apto.Checked = false;
                        }
                        else
                        {
                            ckb_apto.Checked = true;

                        }
                        if (reinte.rein_aptoObserva == null)
                        {
                            ckb_aptoobservacion.Checked = false;
                        }
                        else
                        {
                            ckb_aptoobservacion.Checked = true;

                        }
                        if (reinte.rein_aptoLimi == null)
                        {
                            ckb_aptolimitacion.Checked = false;
                        }
                        else
                        {
                            ckb_aptolimitacion.Checked = true;

                        }
                        if (reinte.rein_NoApto == null)
                        {
                            ckb_noapto.Checked = false;
                        }
                        else
                        {
                            ckb_noapto.Checked = true;

                        }

                        //A
                        txt_nomEmpresa.Text = emp.Emp_nombre.ToString();
                        txt_rucEmp.Text = per.Tbl_Centro.cent_ruc.ToString();
                        txt_priNombre.Text = per.Per_priNombre.ToString();
                        txt_segNombre.Text = per.Per_segNombre.ToString();
                        txt_priApellido.Text = per.Per_priApellido.ToString();
                        txt_segApellido.Text = per.Per_segApellido.ToString();
                        txt_sexo.Text = per.Per_genero.ToString();
                        DateTime edad = Convert.ToDateTime(per.Per_fechaNacimiento);
                        DateTime naci = Convert.ToDateTime(edad);
                        DateTime actual = DateTime.Now;
                        Calculo(naci, actual);
                        txt_numHClinica.Text = per.Per_cedula.ToString();
                        txt_puestoTrabajo.Text = per.Per_puestoTrabajo.ToString();

                        if (reinte != null)
                        {
                            //A
                            txt_ciiu.Text = reinte.rein_ciiu.ToString();
                            txt_numArchivo.Text = reinte.rein_numArchivo.ToString();
                            if (reinte.rein__fechUltDiaLaboral == "")
                            {
                                txt_fechaUltiDiaLaboral.Text = reinte.rein__fechUltDiaLaboral.ToString();
                            }
                            else
                            {
                                txt_fechaUltiDiaLaboral.Text = Convert.ToDateTime(reinte.rein__fechUltDiaLaboral).ToString("yyyy-MM-dd");
                            }
                            if (reinte.rein_fechReingreso == "")
                            {
                                txt_fechaReingreso.Text = reinte.rein_fechReingreso.ToString();
                            }
                            else
                            {
                                txt_fechaReingreso.Text = Convert.ToDateTime(reinte.rein_fechReingreso).ToString("yyyy-MM-dd");
                            }
                            txt_total.Text = reinte.rein_total.ToString();
                            txt_causaSalida.Text = reinte.rein_causaSalida.ToString();

                            //B
                            txt_motivoconsultareintegro.Text = reinte.rein_descripmotCon.ToString();

                            //C
                            txt_enfermedadactualreintegro.Text = reinte.rein_descripenfActual.ToString();

                            //D
                            txt_preArterial.Text = reinte.rein_preArterial.ToString();
                            txt_temperatura.Text = reinte.rein_temperatura.ToString();
                            txt_freCardica.Text = reinte.rein_frecCardiacan.ToString();
                            txt_satOxigeno.Text = reinte.rein_satOxigenon.ToString();
                            txt_freRespiratoria.Text = reinte.rein_frecRespiratorian.ToString();
                            txt_peso.Text = reinte.rein_peson.ToString();
                            txt_talla.Text = reinte.rein_tallan.ToString();
                            txt_indMasCorporal.Text = reinte.rein_indMasCorporaln.ToString();
                            txt_perAbdominal.Text = reinte.rein_perAbdominaln.ToString();

                            //E                            
                            txt_observexamenfisicoregional.Text = reinte.rein_observaexaFisRegional.ToString();

                            //F
                            txt_examen.Text = reinte.rein_examen.ToString();
                            if (reinte.rein_fecha == "")
                            {
                                txt_fechaexamen.Text = reinte.rein_fecha.ToString();
                            }
                            else
                            {
                                txt_fechaexamen.Text = Convert.ToDateTime(reinte.rein_fecha).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen.Text = reinte.rein_resultados.ToString();
                            txt_examen2.Text = reinte.rein_examen2.ToString();
                            if (reinte.rein_fecha2 == "")
                            {
                                txt_fechaexamen2.Text = reinte.rein_fecha2.ToString();
                            }
                            else
                            {
                                txt_fechaexamen2.Text = Convert.ToDateTime(reinte.rein_fecha2).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen2.Text = reinte.rein_resultados2.ToString();
                            txt_examen3.Text = reinte.rein_examen3.ToString();
                            if (reinte.rein_fecha3 == "")
                            {
                                txt_fechaexamen3.Text = reinte.rein_fecha3.ToString();
                            }
                            else
                            {
                                txt_fechaexamen3.Text = Convert.ToDateTime(reinte.rein_fecha3).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen3.Text = reinte.rein_resultados3.ToString();
                            txt_observacionexamen.Text = reinte.rein_observacionesResExaGenEspRiesTrabajo.ToString();

                            //G
                            txt_descripdiagnostico.Text = reinte.rein_descripcionDiagnostico.ToString();
                            txt_cie.Text = reinte.rein_cie.ToString();
                            txt_descripdiagnostico2.Text = reinte.rein_descripcionDiagnostico2.ToString();
                            txt_cie2.Text = reinte.rein_cie2.ToString();
                            txt_descripdiagnostico3.Text = reinte.rein_descripcionDiagnostico3.ToString();
                            txt_cie3.Text = reinte.rein_cie3.ToString();

                            //H
                            txt_observacionaptitud.Text = reinte.rein_ObservAptMedica.ToString();
                            txt_limitacionaptitud.Text = reinte.rein_LimitAptMedica.ToString();
                            txt_reubicacionaptitud.Text = reinte.rein_ReubicaAptMedica.ToString();

                            //I
                            txt_descripciontratamientoreintegro.Text = reinte.rein_descripcionRecoTratamiento.ToString();

                            //J                           
                            ddl_profesional.SelectedValue = reinte.prof_id.ToString();
                            txt_codigoDatProf.Text = reinte.rein_cod.ToString();
                        }
                    }
                }
                txt_numHClinica.MaxLength = 10;
                txt_total.MaxLength = 4;

                Timer1.Enabled = false;
                cargarProfesional();
                //defaultValidaciones();

                txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
            }
        }

        //protected void timerFechaHora_Tick(object sender, EventArgs e)
        //{
        //    if (reinte.rein_fecha_hora == null)
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

        //Metodo obtener numero de cedula
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
                            join ce in dc.Tbl_Centro on c.Emp_id equals ce.cent_id
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

                    string puestoTrabajo = item.Per_puestoTrabajo;
                    txt_puestoTrabajo.Text = puestoTrabajo;

                }
            }
            else
            {
                txt_nomEmpresa.Text = txt_rucEmp.Text = txt_priNombre.Text = txt_segNombre.Text = txt_priApellido.Text = txt_segApellido.Text = txt_sexo.Text = txt_edad.Text = txt_puestoTrabajo.Text = string.Empty;
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

        private void GuardarReintegro()
        {
            try
            {
                per = CN_HistorialMedico.ObtenerIdPersonasxCedula(txt_numHClinica.Text);
                int perso = Convert.ToInt32(per.Per_id.ToString());

                per = CN_HistorialMedico.ObtenerIdEmpresaxCedula(txt_numHClinica.Text);
                int empre = Convert.ToInt32(per.Emp_id.ToString());

                reinte = new Tbl_Reintegro();

                //Regiones
                if (ckb_cicatrices.Checked == true)
                {
                    reinte.rein_cicatricesPiel = "SI";
                }
                if (ckb_tatuajes.Checked == true)
                {
                    reinte.rein_tatuajesPiel = "SI";
                }
                if (ckb_pielyfaneras.Checked == true)
                {
                    reinte.rein_pielFacerasPiel = "SI";
                }
                if (ckb_parpados.Checked == true)
                {
                    reinte.rein_parpadosOjos = "SI";
                }
                if (ckb_conjuntivas.Checked == true)
                {
                    reinte.rein_conjuntuvasOjos = "SI";
                }
                if (ckb_pupilas.Checked == true)
                {
                    reinte.rein_pupilasOjos = "SI";
                }
                if (ckb_cornea.Checked == true)
                {
                    reinte.rein_corneaOjos = "SI";
                }
                if (ckb_motilidad.Checked == true)
                {
                    reinte.rein_motilidadOjos = "SI";
                }
                if (ckb_auditivoexterno.Checked == true)
                {
                    reinte.rein_cAudiExtreOido = "SI";
                }
                if (ckb_pabellon.Checked == true)
                {
                    reinte.rein_pabellonOido = "SI";
                }
                if (ckb_timpanos.Checked == true)
                {
                    reinte.rein_timpanosOido = "SI";
                }
                if (ckb_labios.Checked == true)
                {
                    reinte.rein_labiosOroFa = "SI";
                }
                if (ckb_lengua.Checked == true)
                {
                    reinte.rein_lenguaOroFa = "SI";
                }
                if (ckb_faringe.Checked == true)
                {
                    reinte.rein_faringeOroFa = "SI";
                }
                if (ckb_amigdalas.Checked == true)
                {
                    reinte.rein_amigdalasOroFa = "SI";
                }
                if (ckb_dentadura.Checked == true)
                {
                    reinte.rein_dentaduraOroFa = "SI";
                }
                if (ckb_tabique.Checked == true)
                {
                    reinte.rein_tabiqueNariz = "SI";
                }
                if (ckb_cornetes.Checked == true)
                {
                    reinte.rein_cornetesNariz = "SI";
                }
                if (ckb_mucosa.Checked == true)
                {
                    reinte.rein_mucosasNariz = "SI";
                }
                if (ckb_senosparanasales.Checked == true)
                {
                    reinte.rein_senosParanaNariz = "SI";
                }
                if (ckb_tiroides.Checked == true)
                {
                    reinte.rein_tiroiMasasCuello = "SI";
                }
                if (ckb_movilidad.Checked == true)
                {
                    reinte.rein_movilidadCuello = "SI";
                }
                if (ckb_mamas.Checked == true)
                {
                    reinte.rein_mamasTorax = "SI";
                }
                if (ckb_corazon.Checked == true)
                {
                    reinte.rein_corazonTorax = "SI";
                }
                if (ckb_pulmones.Checked == true)
                {
                    reinte.rein_pulmonesTorax2 = "SI";
                }
                if (ckb_parrillacostal.Checked == true)
                {
                    reinte.rein_parriCostalTorax2 = "SI";
                }
                if (ckb_visceras.Checked == true)
                {
                    reinte.rein_viscerasAbdomen = "SI";
                }
                if (ckb_paredabdominal.Checked == true)
                {
                    reinte.rein_paredAbdomiAbdomen = "SI";
                }
                if (ckb_flexibilidad.Checked == true)
                {
                    reinte.rein_flexibilidadColumna = "SI";
                }
                if (ckb_desviacion.Checked == true)
                {
                    reinte.rein_desviacionColumna = "SI";
                }
                if (ckb_dolor.Checked == true)
                {
                    reinte.rein_dolorColumna = "SI";
                }
                if (ckb_pelvis.Checked == true)
                {
                    reinte.rein_pelvisPelvis = "SI";
                }
                if (ckb_genitales.Checked == true)
                {
                    reinte.rein_genitalesPelvis = "SI";
                }
                if (ckb_vascular.Checked == true)
                {
                    reinte.rein_vascularExtre = "SI";
                }
                if (ckb_miembrosuperiores.Checked == true)
                {
                    reinte.rein_miemSupeExtre = "SI";
                }
                if (ckb_miembrosinferiores.Checked == true)
                {
                    reinte.rein_miemInfeExtre = "SI";
                }
                if (ckb_fuerza.Checked == true)
                {
                    reinte.rein_fuerzaNeuro = "SI";
                }
                if (ckb_sensibilidad.Checked == true)
                {
                    reinte.rein_sensibiNeuro = "SI";
                }
                if (ckb_marcha.Checked == true)
                {
                    reinte.rein_marchaNeuro = "SI";
                }
                if (ckb_reflejos.Checked == true)
                {
                    reinte.rein_refleNeuro = "SI";
                }

                //Diagnostco
                if (ckb_pre.Checked == true)
                {
                    reinte.rein_pre = "SI";
                }
                if (ckb_pre2.Checked == true)
                {
                    reinte.rein_pre2 = "SI";
                }
                if (ckb_pre3.Checked == true)
                {
                    reinte.rein_pre3 = "SI";
                }
                if (ckb_def.Checked == true)
                {
                    reinte.rein_def = "SI";
                }
                if (ckb_def2.Checked == true)
                {
                    reinte.rein_def2 = "SI";
                }
                if (ckb_def3.Checked == true)
                {
                    reinte.rein_def3 = "SI";
                }

                //Aptitud Medica para el trabajo
                if (ckb_apto.Checked == true)
                {
                    reinte.rein_apto = "SI";
                }
                if (ckb_aptoobservacion.Checked == true)
                {
                    reinte.rein_aptoObserva = "SI";
                }
                if (ckb_aptolimitacion.Checked == true)
                {
                    reinte.rein_aptoLimi = "SI";
                }
                if (ckb_noapto.Checked == true)
                {
                    reinte.rein_NoApto = "SI";
                }

                //A
                reinte.rein_ciiu = txt_ciiu.Text.ToUpper();
                reinte.rein_numArchivo = txt_numArchivo.Text.ToUpper();
                reinte.rein__fechUltDiaLaboral = txt_fechaUltiDiaLaboral.Text.ToUpper();
                reinte.rein_fechReingreso = txt_fechaReingreso.Text.ToUpper();
                reinte.rein_total = txt_total.Text.ToUpper();
                reinte.rein_causaSalida = txt_causaSalida.Text.ToUpper();

                //B.
                reinte.rein_descripmotCon = txt_motivoconsultareintegro.Text.ToUpper();

                //C.
                reinte.rein_descripenfActual = txt_enfermedadactualreintegro.Text.ToUpper();

                //D
                reinte.rein_preArterial = txt_preArterial.Text.ToUpper();
                reinte.rein_temperatura = txt_temperatura.Text.ToUpper();
                reinte.rein_frecCardiacan = txt_freCardica.Text.ToUpper();
                reinte.rein_satOxigenon = txt_satOxigeno.Text.ToUpper();
                reinte.rein_frecRespiratorian = txt_freRespiratoria.Text.ToUpper();
                reinte.rein_peson = txt_peso.Text.ToUpper();
                reinte.rein_tallan = txt_talla.Text.ToUpper();
                reinte.rein_indMasCorporaln = txt_indMasCorporal.Text.ToUpper();
                reinte.rein_perAbdominaln = txt_perAbdominal.Text.ToUpper();

                //E.                    
                reinte.rein_observaexaFisRegional = txt_observexamenfisicoregional.Text.ToUpper();

                //F.
                reinte.rein_examen = txt_examen.Text.ToUpper();
                reinte.rein_fecha = txt_fechaexamen.Text.ToUpper();
                reinte.rein_resultados = txt_resultadoexamen.Text.ToUpper();
                reinte.rein_examen2 = txt_examen2.Text.ToUpper();
                reinte.rein_fecha2 = txt_fechaexamen2.Text.ToUpper();
                reinte.rein_resultados2 = txt_resultadoexamen2.Text.ToUpper();
                reinte.rein_examen3 = txt_examen3.Text.ToUpper();
                reinte.rein_fecha3 = txt_fechaexamen3.Text.ToUpper();
                reinte.rein_resultados3 = txt_resultadoexamen3.Text.ToUpper();
                reinte.rein_observacionesResExaGenEspRiesTrabajo = txt_observacionexamen.Text.ToUpper();

                //G.
                reinte.rein_descripcionDiagnostico = txt_descripdiagnostico.Text.ToUpper();
                reinte.rein_cie = txt_cie.Text.ToUpper();
                reinte.rein_descripcionDiagnostico2 = txt_descripdiagnostico2.Text.ToUpper();
                reinte.rein_cie2 = txt_cie2.Text.ToUpper();
                reinte.rein_descripcionDiagnostico3 = txt_descripdiagnostico3.Text.ToUpper();
                reinte.rein_cie3 = txt_cie3.Text.ToUpper();

                //H.
                reinte.rein_ObservAptMedica = txt_observacionaptitud.Text.ToUpper();
                reinte.rein_LimitAptMedica = txt_limitacionaptitud.Text.ToUpper();
                reinte.rein_ReubicaAptMedica = txt_reubicacionaptitud.Text.ToUpper();

                //I.
                reinte.rein_descripcionRecoTratamiento = txt_descripciontratamientoreintegro.Text.ToUpper();

                //J.
                reinte.rein_fechaHoraGuardado = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                reinte.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                reinte.rein_cod = txt_codigoDatProf.Text.ToUpper();
                reinte.Per_id = perso;
                reinte.Emp_id = empre;

                CN_Reintegro.GuardarReintegro(reinte);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Guardados Exitosamente', 'success')", true);
                Timer1.Enabled = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Guardados', 'error')", true);
            }

        }

        private void ModificarReintegro(Tbl_Reintegro reinte)
        {
            try
            {
                //Regiones
                if (ckb_cicatrices.Checked == true)
                {
                    reinte.rein_cicatricesPiel = "SI";
                }
                else
                {
                    reinte.rein_cicatricesPiel = null;
                }
                if (ckb_tatuajes.Checked == true)
                {
                    reinte.rein_tatuajesPiel = "SI";
                }
                else
                {
                    reinte.rein_tatuajesPiel = null;
                }
                if (ckb_pielyfaneras.Checked == true)
                {
                    reinte.rein_pielFacerasPiel = "SI";
                }
                else
                {
                    reinte.rein_pielFacerasPiel = null;
                }
                if (ckb_parpados.Checked == true)
                {
                    reinte.rein_parpadosOjos = "SI";
                }
                else
                {
                    reinte.rein_parpadosOjos = null;
                }
                if (ckb_conjuntivas.Checked == true)
                {
                    reinte.rein_conjuntuvasOjos = "SI";
                }
                else
                {
                    reinte.rein_conjuntuvasOjos = null;
                }
                if (ckb_pupilas.Checked == true)
                {
                    reinte.rein_pupilasOjos = "SI";
                }
                else
                {
                    reinte.rein_pupilasOjos = null;
                }
                if (ckb_cornea.Checked == true)
                {
                    reinte.rein_corneaOjos = "SI";
                }
                else
                {
                    reinte.rein_corneaOjos = null;
                }
                if (ckb_motilidad.Checked == true)
                {
                    reinte.rein_motilidadOjos = "SI";
                }
                else
                {
                    reinte.rein_motilidadOjos = null;
                }
                if (ckb_auditivoexterno.Checked == true)
                {
                    reinte.rein_cAudiExtreOido = "SI";
                }
                else
                {
                    reinte.rein_cAudiExtreOido = null;
                }
                if (ckb_pabellon.Checked == true)
                {
                    reinte.rein_pabellonOido = "SI";
                }
                else
                {
                    reinte.rein_pabellonOido = null;
                }
                if (ckb_timpanos.Checked == true)
                {
                    reinte.rein_timpanosOido = "SI";
                }
                else
                {
                    reinte.rein_timpanosOido = null;
                }
                if (ckb_labios.Checked == true)
                {
                    reinte.rein_labiosOroFa = "SI";
                }
                else
                {
                    reinte.rein_labiosOroFa = null;
                }
                if (ckb_lengua.Checked == true)
                {
                    reinte.rein_lenguaOroFa = "SI";
                }
                else
                {
                    reinte.rein_lenguaOroFa = null;
                }
                if (ckb_faringe.Checked == true)
                {
                    reinte.rein_faringeOroFa = "SI";
                }
                else
                {
                    reinte.rein_faringeOroFa = null;
                }
                if (ckb_amigdalas.Checked == true)
                {
                    reinte.rein_amigdalasOroFa = "SI";
                }
                else
                {
                    reinte.rein_amigdalasOroFa = null;
                }
                if (ckb_dentadura.Checked == true)
                {
                    reinte.rein_dentaduraOroFa = "SI";
                }
                else
                {
                    reinte.rein_dentaduraOroFa = null;
                }
                if (ckb_tabique.Checked == true)
                {
                    reinte.rein_tabiqueNariz = "SI";
                }
                else
                {
                    reinte.rein_tabiqueNariz = null;
                }
                if (ckb_cornetes.Checked == true)
                {
                    reinte.rein_cornetesNariz = "SI";
                }
                else
                {
                    reinte.rein_cornetesNariz = null;
                }
                if (ckb_mucosa.Checked == true)
                {
                    reinte.rein_mucosasNariz = "SI";
                }
                else
                {
                    reinte.rein_mucosasNariz = null;
                }
                if (ckb_senosparanasales.Checked == true)
                {
                    reinte.rein_senosParanaNariz = "SI";
                }
                else
                {
                    reinte.rein_senosParanaNariz = null;
                }
                if (ckb_tiroides.Checked == true)
                {
                    reinte.rein_tiroiMasasCuello = "SI";
                }
                else
                {
                    reinte.rein_tiroiMasasCuello = null;
                }
                if (ckb_movilidad.Checked == true)
                {
                    reinte.rein_movilidadCuello = "SI";
                }
                else
                {
                    reinte.rein_movilidadCuello = null;
                }
                if (ckb_mamas.Checked == true)
                {
                    reinte.rein_mamasTorax = "SI";
                }
                else
                {
                    reinte.rein_mamasTorax = null;
                }
                if (ckb_corazon.Checked == true)
                {
                    reinte.rein_corazonTorax = "SI";
                }
                else
                {
                    reinte.rein_corazonTorax = null;
                }
                if (ckb_pulmones.Checked == true)
                {
                    reinte.rein_pulmonesTorax2 = "SI";
                }
                else
                {
                    reinte.rein_pulmonesTorax2 = null;
                }
                if (ckb_parrillacostal.Checked == true)
                {
                    reinte.rein_parriCostalTorax2 = "SI";
                }
                else
                {
                    reinte.rein_parriCostalTorax2 = null;
                }
                if (ckb_visceras.Checked == true)
                {
                    reinte.rein_viscerasAbdomen = "SI";
                }
                else
                {
                    reinte.rein_viscerasAbdomen = null;
                }
                if (ckb_paredabdominal.Checked == true)
                {
                    reinte.rein_paredAbdomiAbdomen = "SI";
                }
                else
                {
                    reinte.rein_paredAbdomiAbdomen = null;
                }
                if (ckb_flexibilidad.Checked == true)
                {
                    reinte.rein_flexibilidadColumna = "SI";
                }
                else
                {
                    reinte.rein_flexibilidadColumna = null;
                }
                if (ckb_desviacion.Checked == true)
                {
                    reinte.rein_desviacionColumna = "SI";
                }
                else
                {
                    reinte.rein_desviacionColumna = null;
                }
                if (ckb_dolor.Checked == true)
                {
                    reinte.rein_dolorColumna = "SI";
                }
                else
                {
                    reinte.rein_dolorColumna = null;
                }
                if (ckb_pelvis.Checked == true)
                {
                    reinte.rein_pelvisPelvis = "SI";
                }
                else
                {
                    reinte.rein_pelvisPelvis = null;
                }
                if (ckb_genitales.Checked == true)
                {
                    reinte.rein_genitalesPelvis = "SI";
                }
                else
                {
                    reinte.rein_genitalesPelvis = null;
                }
                if (ckb_vascular.Checked == true)
                {
                    reinte.rein_vascularExtre = "SI";
                }
                else
                {
                    reinte.rein_vascularExtre = null;
                }
                if (ckb_miembrosuperiores.Checked == true)
                {
                    reinte.rein_miemSupeExtre = "SI";
                }
                else
                {
                    reinte.rein_miemSupeExtre = null;
                }
                if (ckb_miembrosinferiores.Checked == true)
                {
                    reinte.rein_miemInfeExtre = "SI";
                }
                else
                {
                    reinte.rein_miemInfeExtre = null;
                }
                if (ckb_fuerza.Checked == true)
                {
                    reinte.rein_fuerzaNeuro = "SI";
                }
                else
                {
                    reinte.rein_fuerzaNeuro = null;
                }
                if (ckb_sensibilidad.Checked == true)
                {
                    reinte.rein_sensibiNeuro = "SI";
                }
                else
                {
                    reinte.rein_sensibiNeuro = null;
                }
                if (ckb_marcha.Checked == true)
                {
                    reinte.rein_marchaNeuro = "SI";
                }
                else
                {
                    reinte.rein_marchaNeuro = null;
                }
                if (ckb_reflejos.Checked == true)
                {
                    reinte.rein_refleNeuro = "SI";
                }
                else
                {
                    reinte.rein_refleNeuro = null;
                }

                //Diagnostco
                if (ckb_pre.Checked == true)
                {
                    reinte.rein_pre = "SI";
                }
                else
                {
                    reinte.rein_pre = null;
                }
                if (ckb_pre2.Checked == true)
                {
                    reinte.rein_pre2 = "SI";
                }
                else
                {
                    reinte.rein_pre2 = null;
                }
                if (ckb_pre3.Checked == true)
                {
                    reinte.rein_pre3 = "SI";
                }
                else
                {
                    reinte.rein_pre3 = null;
                }
                if (ckb_def.Checked == true)
                {
                    reinte.rein_def = "SI";
                }
                else
                {
                    reinte.rein_def = null;
                }
                if (ckb_def2.Checked == true)
                {
                    reinte.rein_def2 = "SI";
                }
                else
                {
                    reinte.rein_def2 = null;
                }
                if (ckb_def3.Checked == true)
                {
                    reinte.rein_def3 = "SI";
                }
                else
                {
                    reinte.rein_def3 = null;
                }

                //Aptitud Medica para el trabajo
                if (ckb_apto.Checked == true)
                {
                    reinte.rein_apto = "SI";
                }
                else
                {
                    reinte.rein_apto = null;
                }
                if (ckb_aptoobservacion.Checked == true)
                {
                    reinte.rein_aptoObserva = "SI";
                }
                else
                {
                    reinte.rein_aptoObserva = null;
                }
                if (ckb_aptolimitacion.Checked == true)
                {
                    reinte.rein_aptoLimi = "SI";
                }
                else
                {
                    reinte.rein_aptoLimi = null;
                }
                if (ckb_noapto.Checked == true)
                {
                    reinte.rein_NoApto = "SI";
                }
                else
                {
                    reinte.rein_NoApto = null;
                }

                //A
                reinte.rein_ciiu = txt_ciiu.Text.ToUpper();
                reinte.rein_numArchivo = txt_numArchivo.Text.ToUpper();
                reinte.rein__fechUltDiaLaboral = txt_fechaUltiDiaLaboral.Text.ToUpper();
                reinte.rein_fechReingreso = txt_fechaReingreso.Text.ToUpper();
                reinte.rein_total = txt_total.Text.ToUpper();
                reinte.rein_causaSalida = txt_causaSalida.Text.ToUpper();

                //B.
                reinte.rein_descripmotCon = txt_motivoconsultareintegro.Text.ToUpper();

                //C.
                reinte.rein_descripenfActual = txt_enfermedadactualreintegro.Text.ToUpper();

                //D
                reinte.rein_preArterial = txt_preArterial.Text.ToUpper();
                reinte.rein_temperatura = txt_temperatura.Text.ToUpper();
                reinte.rein_frecCardiacan = txt_freCardica.Text.ToUpper();
                reinte.rein_satOxigenon = txt_satOxigeno.Text.ToUpper();
                reinte.rein_frecRespiratorian = txt_freRespiratoria.Text.ToUpper();
                reinte.rein_peson = txt_peso.Text.ToUpper();
                reinte.rein_tallan = txt_talla.Text.ToUpper();
                reinte.rein_indMasCorporaln = txt_indMasCorporal.Text.ToUpper();
                reinte.rein_perAbdominaln = txt_perAbdominal.Text.ToUpper();

                //E.                    
                reinte.rein_observaexaFisRegional = txt_observexamenfisicoregional.Text.ToUpper();

                //F.
                reinte.rein_examen = txt_examen.Text.ToUpper();
                reinte.rein_fecha = txt_fechaexamen.Text.ToUpper();
                reinte.rein_resultados = txt_resultadoexamen.Text.ToUpper();
                reinte.rein_examen2 = txt_examen2.Text.ToUpper();
                reinte.rein_fecha2 = txt_fechaexamen2.Text.ToUpper();
                reinte.rein_resultados2 = txt_resultadoexamen2.Text.ToUpper();
                reinte.rein_examen3 = txt_examen3.Text.ToUpper();
                reinte.rein_fecha3 = txt_fechaexamen3.Text.ToUpper();
                reinte.rein_resultados3 = txt_resultadoexamen3.Text.ToUpper();
                reinte.rein_observacionesResExaGenEspRiesTrabajo = txt_observacionexamen.Text.ToUpper();

                //G.
                reinte.rein_descripcionDiagnostico = txt_descripdiagnostico.Text.ToUpper();
                reinte.rein_cie = txt_cie.Text.ToUpper();
                reinte.rein_descripcionDiagnostico2 = txt_descripdiagnostico2.Text.ToUpper();
                reinte.rein_cie2 = txt_cie2.Text.ToUpper();
                reinte.rein_descripcionDiagnostico3 = txt_descripdiagnostico3.Text.ToUpper();
                reinte.rein_cie3 = txt_cie3.Text.ToUpper();

                //H.
                reinte.rein_ObservAptMedica = txt_observacionaptitud.Text.ToUpper();
                reinte.rein_LimitAptMedica = txt_limitacionaptitud.Text.ToUpper();
                reinte.rein_ReubicaAptMedica = txt_reubicacionaptitud.Text.ToUpper();

                //I.
                reinte.rein_descripcionRecoTratamiento = txt_descripciontratamientoreintegro.Text.ToUpper();

                //J.
                reinte.rein_fecha_horaModificacion = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                reinte.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                reinte.rein_cod = txt_codigoDatProf.Text.ToUpper();

                CN_Reintegro.ModificarReintegro(reinte);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }

        private void guardar_modificar_datos(int reintegro)
        {
            if (reintegro == 0)
            {
                GuardarReintegro();
            }
            else
            {
                reinte = CN_Reintegro.ObtenerReintegroPorId(reintegro);

                if (per != null)
                {
                    ModificarReintegro(reinte);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Llenar primero la talla')", true);
                txt_peso.Text = "";
                txt_talla.Focus();
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

        protected void ckb_def3_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_def3.Checked == true)
            {
                ckb_pre3.Checked = false;
            }
        }

        protected void ckb_pre3_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_pre3.Checked == true)
            {
                ckb_def3.Checked = false;
            }
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            BaseFont fuente = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font titulo = new Font(fuente, 12f, Font.BOLD, new BaseColor(0, 0, 0));
            BaseFont fuente3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font cuadro = new Font(fuente3, 10f, Font.NORMAL, new BaseColor(0, 0, 0));

            pdfDoc.Open();

            //IMAGEN ENCABEZADO
            string imageURL = Server.MapPath("../../resources/images") + "/ic1.png";
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
            c2.Phrase = new Phrase("HISTORIA CLÍNICA OCUPACIONAL - REINTEGRO", titulo);
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
            var tblTitulo = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 10f, 25f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEXO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("EDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PUESTO DE TRABAJO (CIUO)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblTitulo);
            var tblDatos = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 10f, 25f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priApellido.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segApellido.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_sexo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_edad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_puestoTrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblCSTitulo = new PdfPTable(new float[] { 50f, 50f, 20f, 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblCSTitulo.AddCell(new PdfPCell(new Paragraph("FECHA DEL ÚLTIMO DÍA LABORAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblCSTitulo.AddCell(new PdfPCell(new Paragraph("FECHA DE REINGRESO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblCSTitulo.AddCell(new PdfPCell(new Paragraph("TOTAL (DIAS)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblCSTitulo.AddCell(new PdfPCell(new Paragraph("CAUSA DE SALIDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblCSTitulo);
            var tblCSDatos = new PdfPTable(new float[] { 50f, 50f, 20f, 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblCSDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaUltiDiaLaboral.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblCSDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaReingreso.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblCSDatos.AddCell(new PdfPCell(new Paragraph(txt_total.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblCSDatos.AddCell(new PdfPCell(new Paragraph(txt_causaSalida.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblCSDatos);

            //B. MOTIVO DE CONSULTA / CONDICIÓN DE REINTEGRO
            pdfDoc.Add(new Paragraph(" "));
            var tblMotCon = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblMotCon.AddCell(new PdfPCell(new Paragraph("B. MOTIVO DE CONSULTA / CONDICIÓN DE REINTEGRO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblMotCon);
            var tblMconsul = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblMconsul.AddCell(new PdfPCell(new Paragraph(txt_motivoconsultareintegro.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblMconsul);

            //C. ENFERMEDAD ACTUAL
            pdfDoc.Add(new Paragraph(" "));
            var tblEnfAct = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblEnfAct.AddCell(new PdfPCell(new Paragraph("C. ENFERMEDAD ACTUAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblEnfAct);
            var tblEactual = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblEactual.AddCell(new PdfPCell(new Paragraph(txt_enfermedadactualreintegro.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblEactual);

            //D. CONSTANTES VITALES Y ANTROPOMETRÍA
            pdfDoc.Add(new Paragraph(" "));
            var tblcva = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcva.AddCell(new PdfPCell(new Paragraph("D. CONSTANTES VITALES Y ANTROPOMETRÍA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblcva);
            var tblcvaTitulo = new PdfPTable(new float[] { 50f, 70, 65f, 65f, 70f, 30f, 30f, 60f, 60f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("PRESIÓN ARTERIAL (mmHg)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("TEMPERATURA (°C)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("FRECUENCIA CARDIACA (Lat/min)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("SATURACIÓN DE OXÍGENO (O2%)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("FRECUENCIA RESPIRATORIA (fr/min)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("PESO (Kg)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("TALLA (cm)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("INDICE DE MASA CORPORAL (kg/m2)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaTitulo.AddCell(new PdfPCell(new Paragraph("PERÍMETRO ABDOMINAL(cm)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblcvaTitulo);
            var tblcvaDatos = new PdfPTable(new float[] { 45f, 70, 65f, 65f, 70f, 25f, 25f, 60f, 65f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_preArterial.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_temperatura.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_freCardica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_satOxigeno.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_freRespiratoria.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_peso.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_talla.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_indMasCorporal.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcvaDatos.AddCell(new PdfPCell(new Paragraph(txt_perAbdominal.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblcvaDatos);

            // E. EXAMEN FÍSICO REGIONAL
            pdfDoc.Add(new Paragraph(" "));
            var tblefr = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefr.AddCell(new PdfPCell(new Paragraph("E. EXAMEN FÍSICO REGIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("CP = CON EVIDENCIA DE PATOLOGÍA:  MARCAR X Y DESCRIBIR EN LA SIGUIENTE SECCIÓN", cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7, VerticalAlignment = Element.ALIGN_MIDDLE });
            tblrgDatos.AddCell(new PdfPCell(new Paragraph("SP = SIN EVIDENCIA DE PATOLOGÍA:  MARCAR X Y NO DESCRIBIR", cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 5, VerticalAlignment = Element.ALIGN_MIDDLE });
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

            //F. RESULTADOS DE EXÁMENES (IMAGEN, LABORATORIO Y OTROS)
            pdfDoc.Add(new Paragraph(" "));
            var tblre = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblre.AddCell(new PdfPCell(new Paragraph("F. RESULTADOS DE EXÁMENES (IMAGEN, LABORATORIO Y OTROS)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblre);
            var tblreTitulo = new PdfPTable(new float[] { 200f, 150f, 400f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblreTitulo.AddCell(new PdfPCell(new Paragraph("EXAMEN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblreTitulo.AddCell(new PdfPCell(new Paragraph("FECHA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblreTitulo.AddCell(new PdfPCell(new Paragraph("RESULTADO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblreTitulo);
            var tblreDatos = new PdfPTable(new float[] { 200f, 150f, 400f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblreDatos.AddCell(new PdfPCell(new Paragraph(txt_examen.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblreDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaexamen.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblreDatos.AddCell(new PdfPCell(new Paragraph(txt_resultadoexamen.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblreDatos);
            var tblreDatos2 = new PdfPTable(new float[] { 200f, 150f, 400f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblreDatos2.AddCell(new PdfPCell(new Paragraph(txt_examen2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblreDatos2.AddCell(new PdfPCell(new Paragraph(txt_fechaexamen2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblreDatos2.AddCell(new PdfPCell(new Paragraph(txt_resultadoexamen2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblreDatos2);
            var tblreDatos3 = new PdfPTable(new float[] { 200f, 150f, 400f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblreDatos3.AddCell(new PdfPCell(new Paragraph(txt_examen3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblreDatos3.AddCell(new PdfPCell(new Paragraph(txt_fechaexamen3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblreDatos3.AddCell(new PdfPCell(new Paragraph(txt_resultadoexamen3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblreDatos3);
            var tblreObserva = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblreObserva.AddCell(new PdfPCell(new Paragraph(txt_observacionexamen.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblreObserva);

            //G. DIAGNÓSTICO
            pdfDoc.Add(new Paragraph(" "));
            var tblDiag = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDiag.AddCell(new PdfPCell(new Paragraph("G. DIAGNÓSTICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblDiag);
            var tblDiagPD = new PdfPTable(new float[] { 15f, 485f, 60f, 30f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDiagPD.AddCell(new PdfPCell(new Paragraph("PRE= PRESUNTIVO DEF= DEFINITIVO	", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
            tblDiagPD.AddCell(new PdfPCell(new Paragraph("CIE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDiagPD.AddCell(new PdfPCell(new Paragraph("PRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDiagPD.AddCell(new PdfPCell(new Paragraph("DEF", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblDiagPD);
            var tbldiagDatos = new PdfPTable(new float[] { 15f, 485f, 60f, 30f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldiagDatos.AddCell(new PdfPCell(new Paragraph("1", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldiagDatos.AddCell(new PdfPCell(new Paragraph(txt_descripdiagnostico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldiagDatos.AddCell(new PdfPCell(new Paragraph(txt_cie.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_pre.Checked == true)
            {
                tbldiagDatos.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldiagDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_def.Checked == true)
            {
                tbldiagDatos.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldiagDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tbldiagDatos);
            var tbldiagDatos2 = new PdfPTable(new float[] { 15f, 485f, 60f, 30f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldiagDatos2.AddCell(new PdfPCell(new Paragraph("2", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldiagDatos2.AddCell(new PdfPCell(new Paragraph(txt_descripdiagnostico2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldiagDatos2.AddCell(new PdfPCell(new Paragraph(txt_cie2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_pre2.Checked == true)
            {
                tbldiagDatos2.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldiagDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_def2.Checked == true)
            {
                tbldiagDatos2.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldiagDatos2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tbldiagDatos2);
            var tbldiagDatos3 = new PdfPTable(new float[] { 15f, 485f, 60f, 30f, 30f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldiagDatos3.AddCell(new PdfPCell(new Paragraph("3", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldiagDatos3.AddCell(new PdfPCell(new Paragraph(txt_descripdiagnostico3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldiagDatos3.AddCell(new PdfPCell(new Paragraph(txt_cie3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_pre3.Checked == true)
            {
                tbldiagDatos3.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldiagDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_def3.Checked == true)
            {
                tbldiagDatos3.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldiagDatos3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tbldiagDatos3);

            //H.APTITUD MÉDICA PARA EL TRABAJO
            pdfDoc.Add(new Paragraph(" "));
            var tblAm = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblAm.AddCell(new PdfPCell(new Paragraph("H. APTITUD MÉDICA PARA EL TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblAm);
            var tblamTitulo = new PdfPTable(new float[] { 100f, 15f, 150f, 15f, 150f, 15f, 100f, 15f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblamTitulo.AddCell(new PdfPCell(new Paragraph("APTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_apto.Checked == true)
            {
                tblamTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblamTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblamTitulo.AddCell(new PdfPCell(new Paragraph("APTO EN OBSERVACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_aptoobservacion.Checked == true)
            {
                tblamTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblamTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblamTitulo.AddCell(new PdfPCell(new Paragraph("APTO CON LIMITACIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_aptolimitacion.Checked == true)
            {
                tblamTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblamTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblamTitulo.AddCell(new PdfPCell(new Paragraph("NO APTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noapto.Checked == true)
            {
                tblamTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblamTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblamTitulo);
            var tblamDatos = new PdfPTable(new float[] { 100f, 460f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblamDatos.AddCell(new PdfPCell(new Paragraph("OBSERVACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblamDatos.AddCell(new PdfPCell(new Paragraph(txt_observacionaptitud.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7 });
            pdfDoc.Add(tblamDatos);
            var tblamDatos2 = new PdfPTable(new float[] { 100f, 460f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblamDatos2.AddCell(new PdfPCell(new Paragraph("LIMITACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblamDatos2.AddCell(new PdfPCell(new Paragraph(txt_limitacionaptitud.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7 });
            pdfDoc.Add(tblamDatos2);
            var tblamDatos3 = new PdfPTable(new float[] { 100f, 460f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblamDatos3.AddCell(new PdfPCell(new Paragraph("REUBICACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblamDatos3.AddCell(new PdfPCell(new Paragraph(txt_reubicacionaptitud.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 7 });
            pdfDoc.Add(tblamDatos3);

            //I. RECOMENDACIONES Y/O TRATAMIENTO
            pdfDoc.Add(new Paragraph(" "));
            var tblRecTrata = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblRecTrata.AddCell(new PdfPCell(new Paragraph("I. RECOMENDACIONES Y/O TRATAMIENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblRecTrata);
            var tblRTrata = new PdfPTable(new float[] { 300f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblRTrata.AddCell(new PdfPCell(new Paragraph(txt_descripciontratamientoreintegro.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblRTrata);

            //-------------------------------------------------------
            pdfDoc.Add(new Paragraph(" "));
            var tblcomen = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcomen.AddCell(new PdfPCell(new Paragraph("CERTIFICO QUE LO ANTERIORMENTE EXPRESADO EN RELACIÓN A MI ESTADO DE SALUD ES VERDAD. SE ME HA INFORMADO LAS MEDIDAS PREVENTIVAS A TOMAR PARA DISMINUIR O MITIGAR LOS RIESGOS RELACIONADOS CON MI ACTIVIDAD LABORAL.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Paragraph(" "));

            //J. DATOS DEL PROFESIONAL
            var tbldps = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldps.AddCell(new PdfPCell(new Paragraph("J. DATOS DEL PROFESIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbldps);
            var tbldpsdatos = new PdfPTable(new float[] { 50f, 100f, 75f, 200f, 60f, 75f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
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

            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Reintegro_" + txt_numHClinica.Text + "_" + DateTime.Today + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

        }

        protected void ddl_profesional_TextChanged(object sender, EventArgs e)
        {
            string nombre;
            nombre = ddl_profesional.SelectedItem.Text;
            var cedula = dc.Tbl_Profesional.Where(prof => prof.prof_NomApe == nombre)
                                           .Select(prof => prof.prof_cedula)
                                           .FirstOrDefault();
            if (cedula == null)
            {
                txt_codigoDatProf.Text = "";
            }
            else
            {
                txt_codigoDatProf.Text = cedula;
            }
        }
    }
}