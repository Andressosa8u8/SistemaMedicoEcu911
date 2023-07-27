using CapaDatos;
using CapaNegocio;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

namespace SistemaECU911.Template.Views
{
    public partial class Retiro : System.Web.UI.Page
    {
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        private Tbl_Empresa emp = new Tbl_Empresa();
        private Tbl_Centro cen = new Tbl_Centro();
        private Tbl_Retiro reti = new Tbl_Retiro();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    reti = CN_Retiro.ObtenerRetiroPorId(codigo);
                    int personasid = Convert.ToInt32(reti.Per_id.ToString());
                    per = CN_HistorialMedico.ObtenerPersonasxId(personasid);
                    int empresaid = Convert.ToInt32(reti.Emp_id.ToString());
                    emp = CN_HistorialMedico.ObtenerEmpresaxId(empresaid);


                    btn_guardar.Text = "Actualizar";

                    if (per != null || emp != null)
                    {

                        txt_numHClinica.ReadOnly = true;
                        cargarProfesional();
                        ddl_profesional.Enabled = false;


                        //ANTECEDENTES PERSONALES
                        //----------- ACCIDENTES DE TRABAJO ( DESCRIPCIÓN) -----------
                        if (reti.ret_siCalificadoIESSAcciTrabajo == null)
                        {
                            ckb_siCalificadoIESSAcciTrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_siCalificadoIESSAcciTrabajo.Checked = true;
                        }
                        if (reti.ret_noCalificadoIESSAcciTrabajo == null)
                        {
                            ckb_noCalificadoIESSAcciTrabajo.Checked = false;
                        }
                        else
                        {
                            ckb_noCalificadoIESSAcciTrabajo.Checked = true;
                        }
                        //----------- ENFERMEDADES PROFESIONALES -----------
                        if (reti.ret_siCalificadoIESSEnferProfesionales == null)
                        {
                            ckb_siCalificadoIESSEnferProfesionales.Checked = false;
                        }
                        else
                        {
                            ckb_siCalificadoIESSEnferProfesionales.Checked = true;
                        }
                        if (reti.ret_noCalificadoIESSEnferProfesionales == null)
                        {
                            ckb_noCalificadoIESSEnferProfesionales.Checked = false;
                        }
                        else
                        {
                            ckb_noCalificadoIESSEnferProfesionales.Checked = true;
                        }

                        //Regiones
                        if (reti.ret_cicatricesPiel == null)
                        {
                            ckb_cicatrices.Checked = false;
                        }
                        else
                        {
                            ckb_cicatrices.Checked = true;

                        }
                        if (reti.ret_tatuajesPiel == null)
                        {
                            ckb_tatuajes.Checked = false;
                        }
                        else
                        {
                            ckb_tatuajes.Checked = true;

                        }
                        if (reti.ret_pielFacerasPiel == null)
                        {
                            ckb_pielyfaneras.Checked = false;
                        }
                        else
                        {
                            ckb_pielyfaneras.Checked = true;

                        }
                        if (reti.ret_parpadosOjos == null)
                        {
                            ckb_parpados.Checked = false;
                        }
                        else
                        {
                            ckb_parpados.Checked = true;

                        }
                        if (reti.ret_conjuntuvasOjos == null)
                        {
                            ckb_conjuntivas.Checked = false;
                        }
                        else
                        {
                            ckb_conjuntivas.Checked = true;

                        }
                        if (reti.ret_pupilasOjos == null)
                        {
                            ckb_pupilas.Checked = false;
                        }
                        else
                        {
                            ckb_pupilas.Checked = true;

                        }
                        if (reti.ret_corneaOjos == null)
                        {
                            ckb_cornea.Checked = false;
                        }
                        else
                        {
                            ckb_cornea.Checked = true;

                        }
                        if (reti.ret_motilidadOjos == null)
                        {
                            ckb_motilidad.Checked = false;
                        }
                        else
                        {
                            ckb_motilidad.Checked = true;

                        }
                        if (reti.ret_cAudiExtreOido == null)
                        {
                            ckb_auditivoexterno.Checked = false;
                        }
                        else
                        {
                            ckb_auditivoexterno.Checked = true;

                        }
                        if (reti.ret_pabellonOido == null)
                        {
                            ckb_pabellon.Checked = false;
                        }
                        else
                        {
                            ckb_pabellon.Checked = true;

                        }
                        if (reti.ret_timpanosOido == null)
                        {
                            ckb_timpanos.Checked = false;
                        }
                        else
                        {
                            ckb_timpanos.Checked = true;

                        }
                        if (reti.ret_labiosOroFa == null)
                        {
                            ckb_labios.Checked = false;
                        }
                        else
                        {
                            ckb_labios.Checked = true;

                        }
                        if (reti.ret_lenguaOroFa == null)
                        {
                            ckb_lengua.Checked = false;
                        }
                        else
                        {
                            ckb_lengua.Checked = true;

                        }
                        if (reti.ret_faringeOroFa == null)
                        {
                            ckb_faringe.Checked = false;
                        }
                        else
                        {
                            ckb_faringe.Checked = true;

                        }
                        if (reti.ret_amigdalasOroFa == null)
                        {
                            ckb_amigdalas.Checked = false;
                        }
                        else
                        {
                            ckb_amigdalas.Checked = true;

                        }
                        if (reti.ret_dentaduraOroFa == null)
                        {
                            ckb_dentadura.Checked = false;
                        }
                        else
                        {
                            ckb_dentadura.Checked = true;

                        }
                        if (reti.ret_tabiqueNariz == null)
                        {
                            ckb_tabique.Checked = false;
                        }
                        else
                        {
                            ckb_tabique.Checked = true;

                        }
                        if (reti.ret_cornetesNariz == null)
                        {
                            ckb_cornetes.Checked = false;
                        }
                        else
                        {
                            ckb_cornetes.Checked = true;

                        }
                        if (reti.ret_mucosasNariz == null)
                        {
                            ckb_mucosa.Checked = false;
                        }
                        else
                        {
                            ckb_mucosa.Checked = true;

                        }
                        if (reti.ret_senosParanaNariz == null)
                        {
                            ckb_senosparanasales.Checked = false;
                        }
                        else
                        {
                            ckb_senosparanasales.Checked = true;

                        }
                        if (reti.ret_tiroiMasasCuello == null)
                        {
                            ckb_tiroides.Checked = false;
                        }
                        else
                        {
                            ckb_tiroides.Checked = true;

                        }
                        if (reti.ret_movilidadCuello == null)
                        {
                            ckb_movilidad.Checked = false;
                        }
                        else
                        {
                            ckb_movilidad.Checked = true;

                        }
                        if (reti.ret_mamasTorax == null)
                        {
                            ckb_mamas.Checked = false;
                        }
                        else
                        {
                            ckb_mamas.Checked = true;

                        }
                        if (reti.ret_corazonTorax == null)
                        {
                            ckb_corazon.Checked = false;
                        }
                        else
                        {
                            ckb_corazon.Checked = true;

                        }
                        if (reti.ret_pulmonesTorax2 == null)
                        {
                            ckb_pulmones.Checked = false;
                        }
                        else
                        {
                            ckb_pulmones.Checked = true;

                        }
                        if (reti.ret_parriCostalTorax2 == null)
                        {
                            ckb_parrillacostal.Checked = false;
                        }
                        else
                        {
                            ckb_parrillacostal.Checked = true;

                        }
                        if (reti.ret_viscerasAbdomen == null)
                        {
                            ckb_visceras.Checked = false;
                        }
                        else
                        {
                            ckb_visceras.Checked = true;

                        }
                        if (reti.ret_paredAbdomiAbdomen == null)
                        {
                            ckb_paredabdominal.Checked = false;
                        }
                        else
                        {
                            ckb_paredabdominal.Checked = true;

                        }
                        if (reti.ret_flexibilidadColumna == null)
                        {
                            ckb_flexibilidad.Checked = false;
                        }
                        else
                        {
                            ckb_flexibilidad.Checked = true;

                        }
                        if (reti.ret_desviacionColumna == null)
                        {
                            ckb_desviacion.Checked = false;
                        }
                        else
                        {
                            ckb_desviacion.Checked = true;

                        }
                        if (reti.ret_dolorColumna == null)
                        {
                            ckb_dolor.Checked = false;
                        }
                        else
                        {
                            ckb_dolor.Checked = true;

                        }
                        if (reti.ret_pelvisPelvis == null)
                        {
                            ckb_pelvis.Checked = false;
                        }
                        else
                        {
                            ckb_pelvis.Checked = true;

                        }
                        if (reti.ret_genitalesPelvis == null)
                        {
                            ckb_genitales.Checked = false;
                        }
                        else
                        {
                            ckb_genitales.Checked = true;

                        }
                        if (reti.ret_vascularExtre == null)
                        {
                            ckb_vascular.Checked = false;
                        }
                        else
                        {
                            ckb_vascular.Checked = true;

                        }
                        if (reti.ret_miemSupeExtre == null)
                        {
                            ckb_miembrosuperiores.Checked = false;
                        }
                        else
                        {
                            ckb_miembrosuperiores.Checked = true;

                        }
                        if (reti.ret_miemInfeExtre == null)
                        {
                            ckb_miembrosinferiores.Checked = false;
                        }
                        else
                        {
                            ckb_miembrosinferiores.Checked = true;

                        }
                        if (reti.ret_fuerzaNeuro == null)
                        {
                            ckb_fuerza.Checked = false;
                        }
                        else
                        {
                            ckb_fuerza.Checked = true;

                        }
                        if (reti.ret_sensibiNeuro == null)
                        {
                            ckb_sensibilidad.Checked = false;
                        }
                        else
                        {
                            ckb_sensibilidad.Checked = true;

                        }
                        if (reti.ret_marchaNeuro == null)
                        {
                            ckb_marcha.Checked = false;
                        }
                        else
                        {
                            ckb_marcha.Checked = true;

                        }
                        if (reti.ret_refleNeuro == null)
                        {
                            ckb_reflejos.Checked = false;
                        }
                        else
                        {
                            ckb_reflejos.Checked = true;

                        }

                        //Diagnostco
                        if (reti.ret_pre == null)
                        {
                            ckb_pre.Checked = false;
                        }
                        else
                        {
                            ckb_pre.Checked = true;

                        }
                        if (reti.ret_pre2 == null)
                        {
                            ckb_pre2.Checked = false;
                        }
                        else
                        {
                            ckb_pre2.Checked = true;

                        }
                        if (reti.ret_pre3 == null)
                        {
                            ckb_pre3.Checked = false;
                        }
                        else
                        {
                            ckb_pre3.Checked = true;

                        }
                        if (reti.ret_def == null)
                        {
                            ckb_def.Checked = false;
                        }
                        else
                        {
                            ckb_def.Checked = true;

                        }
                        if (reti.ret_def2 == null)
                        {
                            ckb_def2.Checked = false;
                        }
                        else
                        {
                            ckb_def2.Checked = true;

                        }
                        if (reti.ret_def3 == null)
                        {
                            ckb_def3.Checked = false;
                        }
                        else
                        {
                            ckb_def3.Checked = true;

                        }

                        //EVALUACIÓN MÉDICA DE RETIRO
                        if (reti.ret_si == null)
                        {
                            ckb_sievamed.Checked = false;
                        }
                        else
                        {
                            ckb_sievamed.Checked = true;
                        }
                        if (reti.ret_no == null)
                        {
                            ckb_noevamed.Checked = false;
                        }
                        else
                        {
                            ckb_noevamed.Checked = true;
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
                        txt_puestoTrabajo.Text = per.Per_puestoTrabajo.ToString();

                        if (reti != null)
                        {
                            //A
                            txt_ciiu.Text = reti.ret_ciiu.ToString();
                            txt_numArchivo.Text = reti.ret_numArchivo.ToString();
                            if (reti.ret_fechIniLaboral == "")
                            {
                                txt_fechaIniLabores.Text = reti.ret_fechIniLaboral.ToString();
                            }
                            else
                            {
                                txt_fechaIniLabores.Text = Convert.ToDateTime(reti.ret_fechIniLaboral).ToString("yyyy-MM-dd");
                            }
                            if (reti.ret_fechSalida == "")
                            {
                                txt_fechaSalida.Text = reti.ret_fechSalida.ToString();
                            }
                            else
                            {
                                txt_fechaSalida.Text = Convert.ToDateTime(reti.ret_fechSalida).ToString("yyyy-MM-dd");
                            }
                            txt_tiempo.Text = reti.ret_tiempo.ToString();
                            txt_actividades1.Text = reti.ret_actividades.ToString();
                            txt_facRiesgo1.Text = reti.ret_facRiesgo.ToString();
                            txt_actividades2.Text = reti.ret_actividades2.ToString();
                            txt_facRiesgo2.Text = reti.ret_facRiesgo2.ToString();
                            txt_actividades3.Text = reti.ret_actividades3.ToString();
                            txt_facRiesgo3.Text = reti.ret_facRiesgo3.ToString();

                            //B
                            txt_descripcionantiqui.Text = reti.ret_descripAntCliQuiru.ToString();

                            txt_EspecifiCalificadoIESSAcciTrabajo.Text = reti.ret_EspecifiCalificadoIESSAcciTrabajo.ToString();
                            if (reti.ret_fechaCalificadoIESSAcciTrabajo == "")
                            {
                                txt_fechaCalificadoIESSAcciTrabajo.Text = reti.ret_fechaCalificadoIESSAcciTrabajo.ToString();
                            }
                            else
                            {
                                txt_fechaCalificadoIESSAcciTrabajo.Text = Convert.ToDateTime(reti.ret_fechaCalificadoIESSAcciTrabajo).ToString("yyyy-MM-dd");
                            }
                            txt_observacionesAcciTrabajo.Text = reti.ret_observacionesAcciTrabajo.ToString();
                            txt_detalleAcciTrabajo.Text = reti.ret_detalleAcciTrabajo.ToString();

                            txt_EspecifiCalificadoIESSEnferProfesionales.Text = reti.ret_EspecifiCalificadoIESSEnferProfesionales.ToString();
                            if (reti.ret_fechaCalificadoIESSEnferProfesionales == "")
                            {
                                txt_fechaCalificadoIESSEnferProfesionales.Text = reti.ret_fechaCalificadoIESSEnferProfesionales.ToString();
                            }
                            else
                            {
                                txt_fechaCalificadoIESSEnferProfesionales.Text = Convert.ToDateTime(reti.ret_fechaCalificadoIESSEnferProfesionales).ToString("yyyy-MM-dd");
                            }
                            txt_observacionesEnferProfesionales.Text = reti.ret_observacionesEnferProfesionales.ToString();
                            txt_detalleEnferProfesionales.Text = reti.ret_detalleEnferProfesionales.ToString();

                            //C
                            txt_preArterial.Text = reti.ret_preArterial.ToString();
                            txt_temperatura.Text = reti.ret_temperatura.ToString();
                            txt_freCardica.Text = reti.ret_frecCardiacan.ToString();
                            txt_satOxigeno.Text = reti.ret_satOxigenon.ToString();
                            txt_freRespiratoria.Text = reti.ret_frecRespiratorian.ToString();
                            txt_peso.Text = reti.ret_peson.ToString();
                            txt_talla.Text = reti.ret_tallan.ToString();
                            txt_indMasCorporal.Text = reti.ret_indMasCorporaln.ToString();
                            txt_perAbdominal.Text = reti.ret_perAbdominaln.ToString();

                            //D
                            txt_obervexamenfisicoregional.Text = reti.ret_observaExaFisRegional.ToString();

                            //E
                            txt_examen.Text = reti.ret_examen.ToString();
                            if (reti.ret_fecha == "")
                            {
                                txt_fechaexamen.Text = reti.ret_fecha.ToString();
                            }
                            else
                            {
                                txt_fechaexamen.Text = Convert.ToDateTime(reti.ret_fecha).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen.Text = reti.ret_resultados.ToString();
                            txt_examen2.Text = reti.ret_examen2.ToString();
                            if (reti.ret_fecha2 == "")
                            {
                                txt_fechaexamen2.Text = reti.ret_fecha2.ToString();
                            }
                            else
                            {
                                txt_fechaexamen2.Text = Convert.ToDateTime(reti.ret_fecha2).ToString("yyyy-MM-dd");
                            }
                            txt_resultadoexamen2.Text = reti.ret_resultados2.ToString();
                            txt_observacionexamen.Text = reti.ret_observacionesResExaGenEspRiesTrabajo.ToString();

                            //F
                            txt_descripdiagnostico.Text = reti.ret_descripcionDiagnostico.ToString();
                            txt_cie.Text = reti.ret_cie.ToString();
                            txt_descripdiagnostico2.Text = reti.ret_descripcionDiagnostico2.ToString();
                            txt_cie2.Text = reti.ret_cie2.ToString();
                            txt_descripdiagnostico3.Text = reti.ret_descripcionDiagnostico3.ToString();
                            txt_cie3.Text = reti.ret_cie3.ToString();

                            //G
                            txt_obserevamed.Text = reti.ret_observacionesEvaMedRetiro.ToString();

                            //H
                            txt_descripciontratamientoretiro.Text = reti.ret_descripcionRecoTratamiento.ToString();

                            //I                           
                            ddl_profesional.SelectedValue = reti.prof_id.ToString();
                            txt_codigoDatProf.Text = reti.ret_cod.ToString();
                        }
                    }
                }
                txt_numHClinica.MaxLength = 10;
                txt_tiempo.MaxLength = 3;

                Timer1.Enabled = false;
                cargarProfesional();
                defaultValidaciones();

                txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");

            }
        }

        //protected void timerFechaHora_Tick(object sender, EventArgs e)
        //{
        //    if (reti.ret_fecha_hora == null)
        //    {
        //        txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
        //    }
        //}

        //Metodo obtener cedula por numero de HC RETIRO
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

                    string puestoTrabajo = item.Per_puestoTrabajo;
                    txt_puestoTrabajo.Text = puestoTrabajo;
                }
            }
            else
            {
                txt_nomEmpresa.Text = txt_rucEmp.Text = txt_priNombre.Text = txt_segNombre.Text = txt_priApellido.Text = txt_segApellido.Text = txt_sexo.Text = txt_puestoTrabajo.Text = string.Empty;
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

        private void GuardarRetiro()
        {
            try
            {
                per = CN_HistorialMedico.ObtenerIdPersonasxCedula(txt_numHClinica.Text);
                int perso = Convert.ToInt32(per.Per_id.ToString());

                per = CN_HistorialMedico.ObtenerIdEmpresaxCedula(txt_numHClinica.Text);
                int empre = Convert.ToInt32(per.Emp_id.ToString());

                reti = new Tbl_Retiro();

                //ANTECEDENTES PERSONALES
                //----------- ACCIDENTES DE TRABAJO ( DESCRIPCIÓN) -----------
                if (ckb_siCalificadoIESSAcciTrabajo.Checked == true)
                {
                    reti.ret_siCalificadoIESSAcciTrabajo = "SI";
                }
                if (ckb_noCalificadoIESSAcciTrabajo.Checked == true)
                {
                    reti.ret_noCalificadoIESSAcciTrabajo = "SI";

                }
                //----------- ACCIDENTES DE TRABAJO ( DESCRIPCIÓN) -----------
                if (ckb_siCalificadoIESSEnferProfesionales.Checked == true)
                {
                    reti.ret_siCalificadoIESSEnferProfesionales = "SI";
                }
                if (ckb_noCalificadoIESSEnferProfesionales.Checked == true)
                {
                    reti.ret_noCalificadoIESSEnferProfesionales = "SI";
                }

                //Regiones
                if (ckb_cicatrices.Checked == true)
                {
                    reti.ret_cicatricesPiel = "SI";
                }
                if (ckb_tatuajes.Checked == true)
                {
                    reti.ret_tatuajesPiel = "SI";
                }
                if (ckb_pielyfaneras.Checked == true)
                {
                    reti.ret_pielFacerasPiel = "SI";
                }
                if (ckb_parpados.Checked == true)
                {
                    reti.ret_parpadosOjos = "SI";
                }
                if (ckb_conjuntivas.Checked == true)
                {
                    reti.ret_conjuntuvasOjos = "SI";
                }
                if (ckb_pupilas.Checked == true)
                {
                    reti.ret_pupilasOjos = "SI";
                }
                if (ckb_cornea.Checked == true)
                {
                    reti.ret_corneaOjos = "SI";
                }
                if (ckb_motilidad.Checked == true)
                {
                    reti.ret_motilidadOjos = "SI";
                }
                if (ckb_auditivoexterno.Checked == true)
                {
                    reti.ret_cAudiExtreOido = "SI";
                }
                if (ckb_pabellon.Checked == true)
                {
                    reti.ret_pabellonOido = "SI";
                }
                if (ckb_timpanos.Checked == true)
                {
                    reti.ret_timpanosOido = "SI";
                }
                if (ckb_labios.Checked == true)
                {
                    reti.ret_labiosOroFa = "SI";
                }
                if (ckb_lengua.Checked == true)
                {
                    reti.ret_lenguaOroFa = "SI";
                }
                if (ckb_faringe.Checked == true)
                {
                    reti.ret_faringeOroFa = "SI";
                }
                if (ckb_amigdalas.Checked == true)
                {
                    reti.ret_amigdalasOroFa = "SI";
                }
                if (ckb_dentadura.Checked == true)
                {
                    reti.ret_dentaduraOroFa = "SI";
                }
                if (ckb_tabique.Checked == true)
                {
                    reti.ret_tabiqueNariz = "SI";
                }
                if (ckb_cornetes.Checked == true)
                {
                    reti.ret_cornetesNariz = "SI";
                }
                if (ckb_mucosa.Checked == true)
                {
                    reti.ret_mucosasNariz = "SI";
                }
                if (ckb_senosparanasales.Checked == true)
                {
                    reti.ret_senosParanaNariz = "SI";
                }
                if (ckb_tiroides.Checked == true)
                {
                    reti.ret_tiroiMasasCuello = "SI";
                }
                if (ckb_movilidad.Checked == true)
                {
                    reti.ret_movilidadCuello = "SI";
                }
                if (ckb_mamas.Checked == true)
                {
                    reti.ret_mamasTorax = "SI";
                }
                if (ckb_corazon.Checked == true)
                {
                    reti.ret_corazonTorax = "SI";
                }
                if (ckb_pulmones.Checked == true)
                {
                    reti.ret_pulmonesTorax2 = "SI";
                }
                if (ckb_parrillacostal.Checked == true)
                {
                    reti.ret_parriCostalTorax2 = "SI";
                }
                if (ckb_visceras.Checked == true)
                {
                    reti.ret_viscerasAbdomen = "SI";
                }
                if (ckb_paredabdominal.Checked == true)
                {
                    reti.ret_paredAbdomiAbdomen = "SI";
                }
                if (ckb_flexibilidad.Checked == true)
                {
                    reti.ret_flexibilidadColumna = "SI";
                }
                if (ckb_desviacion.Checked == true)
                {
                    reti.ret_desviacionColumna = "SI";
                }
                if (ckb_dolor.Checked == true)
                {
                    reti.ret_dolorColumna = "SI";
                }
                if (ckb_pelvis.Checked == true)
                {
                    reti.ret_pelvisPelvis = "SI";
                }
                if (ckb_genitales.Checked == true)
                {
                    reti.ret_genitalesPelvis = "SI";
                }
                if (ckb_vascular.Checked == true)
                {
                    reti.ret_vascularExtre = "SI";
                }
                if (ckb_miembrosuperiores.Checked == true)
                {
                    reti.ret_miemSupeExtre = "SI";
                }
                if (ckb_miembrosinferiores.Checked == true)
                {
                    reti.ret_miemInfeExtre = "SI";
                }
                if (ckb_fuerza.Checked == true)
                {
                    reti.ret_fuerzaNeuro = "SI";
                }
                if (ckb_sensibilidad.Checked == true)
                {
                    reti.ret_sensibiNeuro = "SI";
                }
                if (ckb_marcha.Checked == true)
                {
                    reti.ret_marchaNeuro = "SI";
                }
                if (ckb_reflejos.Checked == true)
                {
                    reti.ret_refleNeuro = "SI";
                }

                //Diagnostco
                if (ckb_pre.Checked == true)
                {
                    reti.ret_pre = "SI";
                }
                if (ckb_pre2.Checked == true)
                {
                    reti.ret_pre2 = "SI";
                }
                if (ckb_pre3.Checked == true)
                {
                    reti.ret_pre3 = "SI";
                }
                if (ckb_def.Checked == true)
                {
                    reti.ret_def = "SI";
                }
                if (ckb_def2.Checked == true)
                {
                    reti.ret_def2 = "SI";
                }
                if (ckb_def3.Checked == true)
                {
                    reti.ret_def3 = "SI";
                }

                //EVALUACIÓN MÉDICA DE RETIRO
                if (ckb_sievamed.Checked == true)
                {
                    reti.ret_si = "SI";
                }
                if (ckb_noevamed.Checked == true)
                {
                    reti.ret_no = "SI";
                }

                //A.
                reti.ret_ciiu = txt_ciiu.Text.ToUpper();
                reti.ret_numArchivo = txt_numArchivo.Text.ToUpper();
                reti.ret_fechSalida = txt_fechaSalida.Text.ToUpper();
                reti.ret_fechIniLaboral = txt_fechaIniLabores.Text.ToUpper();
                reti.ret_tiempo = txt_tiempo.Text.ToUpper();
                reti.ret_actividades = txt_actividades1.Text.ToUpper();
                reti.ret_facRiesgo = txt_facRiesgo1.Text.ToUpper();
                reti.ret_actividades2 = txt_actividades2.Text.ToUpper();
                reti.ret_facRiesgo2 = txt_facRiesgo2.Text.ToUpper();
                reti.ret_actividades3 = txt_actividades3.Text.ToUpper();
                reti.ret_facRiesgo3 = txt_facRiesgo3.Text.ToUpper();

                //B.
                reti.ret_descripAntCliQuiru = txt_descripcionantiqui.Text.ToUpper();
                reti.ret_EspecifiCalificadoIESSAcciTrabajo = txt_EspecifiCalificadoIESSAcciTrabajo.Text.ToUpper();
                reti.ret_fechaCalificadoIESSAcciTrabajo = txt_fechaCalificadoIESSAcciTrabajo.Text.ToUpper();
                reti.ret_observacionesAcciTrabajo = txt_observacionesAcciTrabajo.Text.ToUpper();
                reti.ret_detalleAcciTrabajo = txt_detalleAcciTrabajo.Text.ToUpper();

                reti.ret_EspecifiCalificadoIESSEnferProfesionales = txt_EspecifiCalificadoIESSEnferProfesionales.Text.ToUpper();
                reti.ret_fechaCalificadoIESSEnferProfesionales = txt_fechaCalificadoIESSEnferProfesionales.Text.ToUpper();
                reti.ret_observacionesEnferProfesionales = txt_observacionesEnferProfesionales.Text.ToUpper();
                reti.ret_detalleEnferProfesionales = txt_detalleEnferProfesionales.Text.ToUpper();

                //C
                reti.ret_preArterial = txt_preArterial.Text.ToUpper();
                reti.ret_temperatura = txt_temperatura.Text.ToUpper();
                reti.ret_frecCardiacan = txt_freCardica.Text.ToUpper();
                reti.ret_satOxigenon = txt_satOxigeno.Text.ToUpper();
                reti.ret_frecRespiratorian = txt_freRespiratoria.Text.ToUpper();
                reti.ret_peson = txt_peso.Text.ToUpper();
                reti.ret_tallan = txt_talla.Text.ToUpper();
                reti.ret_indMasCorporaln = txt_indMasCorporal.Text.ToUpper();
                reti.ret_perAbdominaln = txt_perAbdominal.Text.ToUpper();

                //D.                    
                reti.ret_observaExaFisRegional = txt_obervexamenfisicoregional.Text.ToUpper();

                //E.
                reti.ret_examen = txt_examen.Text.ToUpper();
                reti.ret_fecha = txt_fechaexamen.Text.ToUpper();
                reti.ret_resultados = txt_resultadoexamen.Text.ToUpper();
                reti.ret_examen2 = txt_examen2.Text.ToUpper();
                reti.ret_fecha2 = txt_fechaexamen2.Text.ToUpper();
                reti.ret_resultados2 = txt_resultadoexamen2.Text.ToUpper();
                reti.ret_observacionesResExaGenEspRiesTrabajo = txt_observacionexamen.Text.ToUpper();

                //F
                reti.ret_descripcionDiagnostico = txt_descripdiagnostico.Text.ToUpper();
                reti.ret_cie = txt_cie.Text.ToUpper();
                reti.ret_descripcionDiagnostico2 = txt_descripdiagnostico2.Text.ToUpper();
                reti.ret_cie2 = txt_cie2.Text.ToUpper();
                reti.ret_descripcionDiagnostico3 = txt_descripdiagnostico3.Text.ToUpper();
                reti.ret_cie3 = txt_cie3.Text.ToUpper();

                //G
                reti.ret_observacionesEvaMedRetiro = txt_obserevamed.Text.ToUpper();

                //H.
                reti.ret_descripcionRecoTratamiento = txt_descripciontratamientoretiro.Text.ToUpper();

                //I.
                reti.ret_fechaHoraGuardado = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                reti.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                reti.ret_cod = txt_codigoDatProf.Text.ToUpper();
                reti.Per_id = perso;
                reti.Emp_id = empre;

                CN_Retiro.GuardarrRetiro(reti);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Guardados Exitosamente', 'success')", true);
                Timer1.Enabled = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Guardados', 'error')", true);
            }

        }

        private void ModificarRetiro(Tbl_Retiro reti)
        {
            try
            {
                //ANTECEDENTES PERSONALES
                //----------- ACCIDENTES DE TRABAJO ( DESCRIPCIÓN) -----------
                if (ckb_siCalificadoIESSAcciTrabajo.Checked == true)
                {
                    reti.ret_siCalificadoIESSAcciTrabajo = "SI";
                }
                else
                {
                    reti.ret_siCalificadoIESSAcciTrabajo = null;
                }
                if (ckb_noCalificadoIESSAcciTrabajo.Checked == true)
                {
                    reti.ret_noCalificadoIESSAcciTrabajo = "SI";

                }
                else
                {
                    reti.ret_noCalificadoIESSAcciTrabajo = null;
                }
                //----------- ACCIDENTES DE TRABAJO ( DESCRIPCIÓN) -----------
                if (ckb_siCalificadoIESSEnferProfesionales.Checked == true)
                {
                    reti.ret_siCalificadoIESSEnferProfesionales = "SI";
                }
                else
                {
                    reti.ret_siCalificadoIESSEnferProfesionales = null;
                }
                if (ckb_noCalificadoIESSEnferProfesionales.Checked == true)
                {
                    reti.ret_noCalificadoIESSEnferProfesionales = "SI";
                }
                else
                {
                    reti.ret_noCalificadoIESSEnferProfesionales = null;
                }

                //Regiones
                if (ckb_cicatrices.Checked == true)
                {
                    reti.ret_cicatricesPiel = "SI";
                }
                else
                {
                    reti.ret_cicatricesPiel = null;
                }
                if (ckb_tatuajes.Checked == true)
                {
                    reti.ret_tatuajesPiel = "SI";
                }
                else
                {
                    reti.ret_tatuajesPiel = null;
                }
                if (ckb_pielyfaneras.Checked == true)
                {
                    reti.ret_pielFacerasPiel = "SI";
                }
                else
                {
                    reti.ret_pielFacerasPiel = null;
                }
                if (ckb_parpados.Checked == true)
                {
                    reti.ret_parpadosOjos = "SI";
                }
                else
                {
                    reti.ret_parpadosOjos = null;
                }
                if (ckb_conjuntivas.Checked == true)
                {
                    reti.ret_conjuntuvasOjos = "SI";
                }
                else
                {
                    reti.ret_conjuntuvasOjos = null;
                }
                if (ckb_pupilas.Checked == true)
                {
                    reti.ret_pupilasOjos = "SI";
                }
                else
                {
                    reti.ret_pupilasOjos = null;
                }
                if (ckb_cornea.Checked == true)
                {
                    reti.ret_corneaOjos = "SI";
                }
                else
                {
                    reti.ret_corneaOjos = null;
                }
                if (ckb_motilidad.Checked == true)
                {
                    reti.ret_motilidadOjos = "SI";
                }
                else
                {
                    reti.ret_motilidadOjos = null;
                }
                if (ckb_auditivoexterno.Checked == true)
                {
                    reti.ret_cAudiExtreOido = "SI";
                }
                else
                {
                    reti.ret_cAudiExtreOido = null;
                }
                if (ckb_pabellon.Checked == true)
                {
                    reti.ret_pabellonOido = "SI";
                }
                else
                {
                    reti.ret_pabellonOido = null;
                }
                if (ckb_timpanos.Checked == true)
                {
                    reti.ret_timpanosOido = "SI";
                }
                else
                {
                    reti.ret_timpanosOido = null;
                }
                if (ckb_labios.Checked == true)
                {
                    reti.ret_labiosOroFa = "SI";
                }
                else
                {
                    reti.ret_labiosOroFa = null;
                }
                if (ckb_lengua.Checked == true)
                {
                    reti.ret_lenguaOroFa = "SI";
                }
                else
                {
                    reti.ret_lenguaOroFa = null;
                }
                if (ckb_faringe.Checked == true)
                {
                    reti.ret_faringeOroFa = "SI";
                }
                else
                {
                    reti.ret_faringeOroFa = null;
                }
                if (ckb_amigdalas.Checked == true)
                {
                    reti.ret_amigdalasOroFa = "SI";
                }
                else
                {
                    reti.ret_amigdalasOroFa = null;
                }
                if (ckb_dentadura.Checked == true)
                {
                    reti.ret_dentaduraOroFa = "SI";
                }
                else
                {
                    reti.ret_dentaduraOroFa = null;
                }
                if (ckb_tabique.Checked == true)
                {
                    reti.ret_tabiqueNariz = "SI";
                }
                else
                {
                    reti.ret_tabiqueNariz = null;
                }
                if (ckb_cornetes.Checked == true)
                {
                    reti.ret_cornetesNariz = "SI";
                }
                else
                {
                    reti.ret_cornetesNariz = null;
                }
                if (ckb_mucosa.Checked == true)
                {
                    reti.ret_mucosasNariz = "SI";
                }
                else
                {
                    reti.ret_mucosasNariz = null;
                }
                if (ckb_senosparanasales.Checked == true)
                {
                    reti.ret_senosParanaNariz = "SI";
                }
                else
                {
                    reti.ret_senosParanaNariz = null;
                }
                if (ckb_tiroides.Checked == true)
                {
                    reti.ret_tiroiMasasCuello = "SI";
                }
                else
                {
                    reti.ret_tiroiMasasCuello = null;
                }
                if (ckb_movilidad.Checked == true)
                {
                    reti.ret_movilidadCuello = "SI";
                }
                else
                {
                    reti.ret_movilidadCuello = null;
                }
                if (ckb_mamas.Checked == true)
                {
                    reti.ret_mamasTorax = "SI";
                }
                else
                {
                    reti.ret_mamasTorax = null;
                }
                if (ckb_corazon.Checked == true)
                {
                    reti.ret_corazonTorax = "SI";
                }
                else
                {
                    reti.ret_corazonTorax = null;
                }
                if (ckb_pulmones.Checked == true)
                {
                    reti.ret_pulmonesTorax2 = "SI";
                }
                else
                {
                    reti.ret_pulmonesTorax2 = null;
                }
                if (ckb_parrillacostal.Checked == true)
                {
                    reti.ret_parriCostalTorax2 = "SI";
                }
                else
                {
                    reti.ret_parriCostalTorax2 = null;
                }
                if (ckb_visceras.Checked == true)
                {
                    reti.ret_viscerasAbdomen = "SI";
                }
                else
                {
                    reti.ret_viscerasAbdomen = null;
                }
                if (ckb_paredabdominal.Checked == true)
                {
                    reti.ret_paredAbdomiAbdomen = "SI";
                }
                else
                {
                    reti.ret_paredAbdomiAbdomen = null;
                }
                if (ckb_flexibilidad.Checked == true)
                {
                    reti.ret_flexibilidadColumna = "SI";
                }
                else
                {
                    reti.ret_flexibilidadColumna = null;
                }
                if (ckb_desviacion.Checked == true)
                {
                    reti.ret_desviacionColumna = "SI";
                }
                else
                {
                    reti.ret_desviacionColumna = null;
                }
                if (ckb_dolor.Checked == true)
                {
                    reti.ret_dolorColumna = "SI";
                }
                else
                {
                    reti.ret_dolorColumna = null;
                }
                if (ckb_pelvis.Checked == true)
                {
                    reti.ret_pelvisPelvis = "SI";
                }
                else
                {
                    reti.ret_pelvisPelvis = null;
                }
                if (ckb_genitales.Checked == true)
                {
                    reti.ret_genitalesPelvis = "SI";
                }
                else
                {
                    reti.ret_genitalesPelvis = null;
                }
                if (ckb_vascular.Checked == true)
                {
                    reti.ret_vascularExtre = "SI";
                }
                else
                {
                    reti.ret_vascularExtre = null;
                }
                if (ckb_miembrosuperiores.Checked == true)
                {
                    reti.ret_miemSupeExtre = "SI";
                }
                else
                {
                    reti.ret_miemSupeExtre = null;
                }
                if (ckb_miembrosinferiores.Checked == true)
                {
                    reti.ret_miemInfeExtre = "SI";
                }
                else
                {
                    reti.ret_miemInfeExtre = null;
                }
                if (ckb_fuerza.Checked == true)
                {
                    reti.ret_fuerzaNeuro = "SI";
                }
                else
                {
                    reti.ret_fuerzaNeuro = null;
                }
                if (ckb_sensibilidad.Checked == true)
                {
                    reti.ret_sensibiNeuro = "SI";
                }
                else
                {
                    reti.ret_sensibiNeuro = null;
                }
                if (ckb_marcha.Checked == true)
                {
                    reti.ret_marchaNeuro = "SI";
                }
                else
                {
                    reti.ret_marchaNeuro = null;
                }
                if (ckb_reflejos.Checked == true)
                {
                    reti.ret_refleNeuro = "SI";
                }
                else
                {
                    reti.ret_refleNeuro = null;
                }

                //Diagnostco
                if (ckb_pre.Checked == true)
                {
                    reti.ret_pre = "SI";
                }
                else
                {
                    reti.ret_pre = null;
                }
                if (ckb_pre2.Checked == true)
                {
                    reti.ret_pre2 = "SI";
                }
                else
                {
                    reti.ret_pre2 = null;
                }
                if (ckb_pre3.Checked == true)
                {
                    reti.ret_pre3 = "SI";
                }
                else
                {
                    reti.ret_pre3 = null;
                }
                if (ckb_def.Checked == true)
                {
                    reti.ret_def = "SI";
                }
                else
                {
                    reti.ret_def = null;
                }
                if (ckb_def2.Checked == true)
                {
                    reti.ret_def2 = "SI";
                }
                else
                {
                    reti.ret_def2 = null;
                }
                if (ckb_def3.Checked == true)
                {
                    reti.ret_def3 = "SI";
                }
                else
                {
                    reti.ret_def3 = null;
                }

                //EVALUACIÓN MÉDICA DE RETIRO
                if (ckb_sievamed.Checked == true)
                {
                    reti.ret_si = "SI";
                }
                else
                {
                    reti.ret_si = null;
                }
                if (ckb_noevamed.Checked == true)
                {
                    reti.ret_no = "SI";
                }
                else
                {
                    reti.ret_no = null;
                }

                //A.
                reti.ret_ciiu = txt_ciiu.Text.ToUpper();
                reti.ret_numArchivo = txt_numArchivo.Text.ToUpper();
                reti.ret_fechSalida = txt_fechaSalida.Text.ToUpper();
                reti.ret_fechIniLaboral = txt_fechaIniLabores.Text.ToUpper();
                reti.ret_tiempo = txt_tiempo.Text.ToUpper();
                reti.ret_actividades = txt_actividades1.Text.ToUpper();
                reti.ret_facRiesgo = txt_facRiesgo1.Text.ToUpper();
                reti.ret_actividades2 = txt_actividades2.Text.ToUpper();
                reti.ret_facRiesgo2 = txt_facRiesgo2.Text.ToUpper();
                reti.ret_actividades3 = txt_actividades3.Text.ToUpper();
                reti.ret_facRiesgo3 = txt_facRiesgo3.Text.ToUpper();

                //B.
                reti.ret_descripAntCliQuiru = txt_descripcionantiqui.Text.ToUpper();
                reti.ret_EspecifiCalificadoIESSAcciTrabajo = txt_EspecifiCalificadoIESSAcciTrabajo.Text.ToUpper();
                reti.ret_fechaCalificadoIESSAcciTrabajo = txt_fechaCalificadoIESSAcciTrabajo.Text.ToUpper();
                reti.ret_observacionesAcciTrabajo = txt_observacionesAcciTrabajo.Text.ToUpper();
                reti.ret_detalleAcciTrabajo = txt_detalleAcciTrabajo.Text.ToUpper();

                reti.ret_EspecifiCalificadoIESSEnferProfesionales = txt_EspecifiCalificadoIESSEnferProfesionales.Text.ToUpper();
                reti.ret_fechaCalificadoIESSEnferProfesionales = txt_fechaCalificadoIESSEnferProfesionales.Text.ToUpper();
                reti.ret_observacionesEnferProfesionales = txt_observacionesEnferProfesionales.Text.ToUpper();
                reti.ret_detalleEnferProfesionales = txt_detalleEnferProfesionales.Text.ToUpper();

                //C
                reti.ret_preArterial = txt_preArterial.Text.ToUpper();
                reti.ret_temperatura = txt_temperatura.Text.ToUpper();
                reti.ret_frecCardiacan = txt_freCardica.Text.ToUpper();
                reti.ret_satOxigenon = txt_satOxigeno.Text.ToUpper();
                reti.ret_frecRespiratorian = txt_freRespiratoria.Text.ToUpper();
                reti.ret_peson = txt_peso.Text.ToUpper();
                reti.ret_tallan = txt_talla.Text.ToUpper();
                reti.ret_indMasCorporaln = txt_indMasCorporal.Text.ToUpper();
                reti.ret_perAbdominaln = txt_perAbdominal.Text.ToUpper();

                //D.                    
                reti.ret_observaExaFisRegional = txt_obervexamenfisicoregional.Text.ToUpper();

                //E.
                reti.ret_examen = txt_examen.Text.ToUpper();
                reti.ret_fecha = txt_fechaexamen.Text.ToUpper();
                reti.ret_resultados = txt_resultadoexamen.Text.ToUpper();
                reti.ret_examen2 = txt_examen2.Text.ToUpper();
                reti.ret_fecha2 = txt_fechaexamen2.Text.ToUpper();
                reti.ret_resultados2 = txt_resultadoexamen2.Text.ToUpper();
                reti.ret_observacionesResExaGenEspRiesTrabajo = txt_observacionexamen.Text.ToUpper();

                //F
                reti.ret_descripcionDiagnostico = txt_descripdiagnostico.Text.ToUpper();
                reti.ret_cie = txt_cie.Text.ToUpper();
                reti.ret_descripcionDiagnostico2 = txt_descripdiagnostico2.Text.ToUpper();
                reti.ret_cie2 = txt_cie2.Text.ToUpper();
                reti.ret_descripcionDiagnostico3 = txt_descripdiagnostico3.Text.ToUpper();
                reti.ret_cie3 = txt_cie3.Text.ToUpper();

                //G
                reti.ret_observacionesEvaMedRetiro = txt_obserevamed.Text.ToUpper();

                //H.
                reti.ret_descripcionRecoTratamiento = txt_descripciontratamientoretiro.Text.ToUpper();

                //I.
                reti.ret_fecha_horaModificacion = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                reti.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                reti.ret_cod = txt_codigoDatProf.Text.ToUpper();

                CN_Retiro.ModificarRetiro(reti);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Timer1.Enabled = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }

        private void guardar_modificar_datos(int retiro)
        {
            if (retiro == 0)
            {
                GuardarRetiro();
            }
            else
            {
                reti = CN_Retiro.ObtenerRetiroPorId(retiro);

                if (per != null)
                {
                    ModificarRetiro(reti);
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

        private void defaultValidaciones()
        {
            txt_EspecifiCalificadoIESSAcciTrabajo.Enabled = false;
            txt_fechaCalificadoIESSAcciTrabajo.Enabled = false;
            txt_observacionesAcciTrabajo.Enabled = false;
            txt_EspecifiCalificadoIESSEnferProfesionales.Enabled = false;
            txt_fechaCalificadoIESSEnferProfesionales.Enabled = false;
            txt_observacionesEnferProfesionales.Enabled = false;
        }

        protected void ckb_siCalificadoIESSAcciTrabajo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siCalificadoIESSAcciTrabajo.Checked == true)
            {
                txt_EspecifiCalificadoIESSAcciTrabajo.Enabled = true;
                txt_fechaCalificadoIESSAcciTrabajo.Enabled = true;
                txt_observacionesAcciTrabajo.Enabled = true;
                ckb_noCalificadoIESSAcciTrabajo.Checked = false;
            }
        }

        protected void ckb_noCalificadoIESSAcciTrabajo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noCalificadoIESSAcciTrabajo.Checked == true)
            {
                txt_EspecifiCalificadoIESSAcciTrabajo.Enabled = false;
                txt_EspecifiCalificadoIESSAcciTrabajo.Text = "";
                txt_fechaCalificadoIESSAcciTrabajo.Enabled = false;
                txt_fechaCalificadoIESSAcciTrabajo.Text = "";
                txt_observacionesAcciTrabajo.Enabled = false;
                txt_observacionesAcciTrabajo.Text = "";
                ckb_siCalificadoIESSAcciTrabajo.Checked = false;
            }
        }

        protected void ckb_siCalificadoIESSEnferProfesionales_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siCalificadoIESSEnferProfesionales.Checked == true)
            {
                txt_EspecifiCalificadoIESSEnferProfesionales.Enabled = true;
                txt_fechaCalificadoIESSEnferProfesionales.Enabled = true;
                txt_observacionesEnferProfesionales.Enabled = true;
                ckb_noCalificadoIESSEnferProfesionales.Checked = false;
            }
        }
        protected void ckb_noCalificadoIESSEnferProfesionales_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noCalificadoIESSEnferProfesionales.Checked == true)
            {
                txt_EspecifiCalificadoIESSEnferProfesionales.Enabled = false;
                txt_EspecifiCalificadoIESSEnferProfesionales.Text = "";
                txt_fechaCalificadoIESSEnferProfesionales.Enabled = false;
                txt_fechaCalificadoIESSEnferProfesionales.Text = "";
                txt_observacionesEnferProfesionales.Enabled = false;
                txt_observacionesEnferProfesionales.Text = "";
                ckb_siCalificadoIESSEnferProfesionales.Checked = false;
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

        protected void ckb_sievamed_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_sievamed.Checked == true)
            {
                ckb_noevamed.Checked = false;
                txt_obserevamed.Enabled = true;
            }
        }

        protected void ckb_noevamed_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noevamed.Checked == true)
            {
                ckb_sievamed.Checked = false;
                txt_obserevamed.Text = "";
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
            c2.Phrase = new Phrase("HISTORIA CLÍNICA OCUPACIONAL - RETIRO", titulo);
            tblEncabezado.AddCell(c2);
            pdfDoc.Add(tblEncabezado);
            pdfDoc.Add(new Paragraph(" "));

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
            var tblTitulo = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEXO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("FECHA DE INICIO DE LABORES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("FECHA DE SALIDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("TIEMPO (meses)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PUESTO DE TRABAJO (CIUO)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblTitulo);
            var tblDatos = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priApellido.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segApellido.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_sexo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaIniLabores.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaSalida.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_tiempo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_puestoTrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblafrTitulo = new PdfPTable(new float[] { 30f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafrTitulo.AddCell(new PdfPCell(new Paragraph("ACTIVIDADES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblafrTitulo.AddCell(new PdfPCell(new Paragraph("FACTORES DE RIESGO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblafrTitulo);
            var tblafrDatos = new PdfPTable(new float[] { 30f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafrDatos.AddCell(new PdfPCell(new Paragraph(txt_actividades1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblafrDatos.AddCell(new PdfPCell(new Paragraph(txt_facRiesgo1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblafrDatos);
            var tblafrDatos1 = new PdfPTable(new float[] { 30f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafrDatos1.AddCell(new PdfPCell(new Paragraph(txt_actividades2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblafrDatos1.AddCell(new PdfPCell(new Paragraph(txt_facRiesgo2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblafrDatos1);
            var tblafrDatos2 = new PdfPTable(new float[] { 30f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafrDatos2.AddCell(new PdfPCell(new Paragraph(txt_actividades3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblafrDatos2.AddCell(new PdfPCell(new Paragraph(txt_facRiesgo3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblafrDatos2);
            pdfDoc.Add(new Paragraph(" "));
            var tblap = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblap.AddCell(new PdfPCell(new Paragraph("B. ANTECEDENTES PERSONALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblap);
            var tblapTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapTitulo.AddCell(new PdfPCell(new Paragraph("ANTECEDENTES CLÍNICOS Y QUIRÚRGICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblapTitulo);
            var tblapDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapDatos.AddCell(new PdfPCell(new Paragraph(txt_descripcionantiqui.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblapDatos);
            var tblatTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatTitulo.AddCell(new PdfPCell(new Paragraph("ACCIDENTES DE TRABAJO (DESCRIPCIÓN)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblatTitulo);
            var tblatDatos = new PdfPTable(new float[] { 70f, 15f, 15f, 40f, 50f, 15f, 15f, 20f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatDatos.AddCell(new PdfPCell(new Paragraph("FUE CALIFICADO POR EL INSTITUTO DE SEGURIDAD SOCIAL CORRESPONDIENTE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siCalificadoIESSAcciTrabajo.Checked == true)
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblatDatos.AddCell(new PdfPCell(new Paragraph("ESPECIFICAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph(txt_EspecifiCalificadoIESSAcciTrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noCalificadoIESSAcciTrabajo.Checked == true)
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblatDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblatDatos.AddCell(new PdfPCell(new Paragraph("FECHA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblatDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaCalificadoIESSAcciTrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblatDatos);
            var tblatDatos1 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatDatos1.AddCell(new PdfPCell(new Paragraph(txt_observacionesAcciTrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblatDatos1);
            var tblatDatos2 = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblatDatos2.AddCell(new PdfPCell(new Paragraph("Detallar aquí en caso se presuma de algún accidente de trabajo que no haya sido reportado o calificado:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblatDatos2.AddCell(new PdfPCell(new Paragraph(txt_detalleAcciTrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblatDatos2);
            pdfDoc.Add(new Paragraph(" "));
            var tblefTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefTitulo.AddCell(new PdfPCell(new Paragraph("ENFERMEDADES PROFESIONALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefTitulo);
            var tblefDatos = new PdfPTable(new float[] { 70f, 15f, 15f, 40f, 50f, 15f, 15f, 20f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefDatos.AddCell(new PdfPCell(new Paragraph("FUE CALIFICADO POR EL INSTITUTO DE SEGURIDAD SOCIAL CORRESPONDIENTE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siCalificadoIESSEnferProfesionales.Checked == true)
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblefDatos.AddCell(new PdfPCell(new Paragraph("ESPECIFICAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph(txt_EspecifiCalificadoIESSEnferProfesionales.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noCalificadoIESSEnferProfesionales.Checked == true)
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblefDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblefDatos.AddCell(new PdfPCell(new Paragraph("FECHA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefDatos.AddCell(new PdfPCell(new Paragraph(txt_fechaCalificadoIESSEnferProfesionales.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblefDatos);
            var tblefDatos1 = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefDatos1.AddCell(new PdfPCell(new Paragraph(txt_observacionesEnferProfesionales.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefDatos1);
            var tblefDatos2 = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefDatos2.AddCell(new PdfPCell(new Paragraph("Detallar aquí en caso se presuma de algún accidente de trabajo que no haya sido reportado o calificado:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblefDatos2.AddCell(new PdfPCell(new Paragraph(txt_detalleEnferProfesionales.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefDatos2);
            pdfDoc.Add(new Paragraph(" "));
            var tblcva = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcva.AddCell(new PdfPCell(new Paragraph("C. CONSTANTES VITALES Y ANTROPOMETRÍA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
            tblefr.AddCell(new PdfPCell(new Paragraph("D. EXAMEN FÍSICO REGIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
            tbleg.AddCell(new PdfPCell(new Paragraph("E. RESULTADOS DE EXÁMENES GENERALES Y ESPECÍFICOS DE ACUERDO AL RIESGO Y PUESTO DE TRABAJO (IMAGEN, LABORATORIO Y OTROS)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
            tbldg.AddCell(new PdfPCell(new Paragraph("F. DIAGNÓSTICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
                tbldgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_def2.Checked == true)
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tbldgDatos1);
            var tbldgDatos2 = new PdfPTable(new float[] { 10f, 70f, 40f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldgDatos2.AddCell(new PdfPCell(new Paragraph("3", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgDatos2.AddCell(new PdfPCell(new Paragraph(txt_descripdiagnostico3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgDatos2.AddCell(new PdfPCell(new Paragraph(txt_cie3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_pre3.Checked == true)
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            if (ckb_def3.Checked == true)
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tbldgDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tbldgDatos2);
            pdfDoc.Add(new Paragraph(" "));
            var tblemr = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblemr.AddCell(new PdfPCell(new Paragraph("G. EVALUACIÓN MÉDICA DE RETIRO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblemr);
            var tblemrTitulo = new PdfPTable(new float[] { 80f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph("SE REALIZÓ LA EVALUACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_LEFT });
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph(ckb_sievamed.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph(ckb_noevamed.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblemrTitulo);
            var tblemrDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblemrDatos.AddCell(new PdfPCell(new Paragraph(txt_obserevamed.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblemrDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblrt = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrt.AddCell(new PdfPCell(new Paragraph("H. RECOMENDACIONES Y/O TRATAMIENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrt);
            var tblrtDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrtDatos.AddCell(new PdfPCell(new Paragraph(txt_descripciontratamientoretiro.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrtDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblifDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblifDatos.AddCell(new PdfPCell(new Paragraph("CERTIFICO QUE LO ANTERIORMENTE EXPRESADO EN RELACIÓN A MI ESTADO DE SALUD ES VERDAD. SE ME HA INFORMADO MI ESTADO ACTUAL DE SALUD Y LAS RECOMENDACIONES PERTINENTES.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblifDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tbldps = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldps.AddCell(new PdfPCell(new Paragraph("I. DATOS DEL PROFESIONAL DE SALUD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
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
            tblfrm.AddCell(new PdfPCell(new Paragraph("J. FIRMA DEL USUARIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblfrm);
            var tblfrmDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrmDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblfrmDatos);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Retiro_" + txt_numHClinica.Text + "_" + DateTime.Now.ToString("dd/MM/yy_hh:mm") + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}