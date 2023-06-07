using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using HtmlAgilityPack;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using ListItem = System.Web.UI.WebControls.ListItem;
using iTextSharp.text.html.simpleparser;
using System.Configuration;

namespace SistemaECU911.views.Doctores
{
    public partial class FichaMedica : System.Web.UI.Page
    {
        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        private Tbl_Empresa emp = new Tbl_Empresa();
        private Tbl_FichasMedicas fichasmedicas = new Tbl_FichasMedicas();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    fichasmedicas = CN_HistorialMedico.ObtenerFichasMedicasPorId(codigo);
                    int personasid = Convert.ToInt32(fichasmedicas.Per_id.ToString());
                    per = CN_HistorialMedico.ObtenerPersonasxId(personasid);
                    int empresaid = Convert.ToInt32(fichasmedicas.Emp_id.ToString());
                    emp = CN_HistorialMedico.ObtenerEmpresaxId(empresaid);

                    btn_guardar.Text = "Actualizar";

                    if (per != null || emp != null)
                    {
                        txt_numHClinica.ReadOnly = true;

                        txt_nomEmpresa.Text = emp.Emp_nombre.ToString();
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

                        if (fichasmedicas != null)
                        {
                            txt_moConsulta.Text = fichasmedicas.moConsulta.ToString();
                            txt_segAcompa.Text = fichasmedicas.seAcompañanteMc.ToString();
                            ddl_tipoAntPer.SelectedValue = fichasmedicas.idTipAntecedentePer.ToString();
                            txt_antePersonales.Text = fichasmedicas.antecedentePer.ToString();
                            txt_antePerDescripcion.Text = fichasmedicas.descripcionPer.ToString();
                            ddl_tipoAntFam.SelectedValue = fichasmedicas.idTipAntecedenteFam.ToString();
                            txt_anteFamiliares.Text = fichasmedicas.antecedenteFam.ToString();
                            txt_anteFamDescripcion.Text = fichasmedicas.descripcionFam.ToString();
                            txt_enfeActual.Text = fichasmedicas.descripcionEA.ToString();
                            ddl_orgSistemas.SelectedValue = fichasmedicas.orgSentido.ToString();
                            txt_descOrgSistemas.Text = fichasmedicas.descripcionOS.ToString();
                            ddl_respiratorio.SelectedValue = fichasmedicas.respiratorio.ToString();
                            txt_descRespiratorio.Text = fichasmedicas.descripcionRes.ToString();
                            ddl_carVascular.SelectedValue = fichasmedicas.cardioVascular.ToString();
                            txt_descCarVascular.Text = fichasmedicas.descripcionCV.ToString();
                            ddl_digestivo.SelectedValue = fichasmedicas.digestivo.ToString();
                            txt_descDigestivo.Text = fichasmedicas.descripcionDig.ToString();
                            ddl_genital.SelectedValue = fichasmedicas.genital.ToString();
                            txt_descGenital.Text = fichasmedicas.descripcionGen.ToString();
                            ddl_urinario.SelectedValue = fichasmedicas.urinario.ToString();
                            txt_descUrinario.Text = fichasmedicas.descripcionUri.ToString();
                            ddl_muscular.SelectedValue = fichasmedicas.muscular.ToString();
                            txt_descMuscular.Text = fichasmedicas.descripcionMus.ToString();
                            ddl_esqueletico.SelectedValue = fichasmedicas.esqueletico.ToString();
                            txt_descEsqueletico.Text = fichasmedicas.descripcionEsq.ToString();
                            ddl_nervioso.SelectedValue = fichasmedicas.nervioso.ToString();
                            txt_descNervioso.Text = fichasmedicas.descripcionNer.ToString();
                            ddl_endocrino.SelectedValue = fichasmedicas.endocrino.ToString();
                            txt_descEndocrino.Text = fichasmedicas.descripcionEnd.ToString();
                            ddl_hemoLinfatico.SelectedValue = fichasmedicas.hemoLinfatico.ToString();
                            txt_descHemoLinfatico.Text = fichasmedicas.descripcionHL.ToString();
                            ddl_tegumentario.SelectedValue = fichasmedicas.tegumentario.ToString();
                            txt_descTegumentario.Text = fichasmedicas.descripcionTeg.ToString();
                            txt_presArterial.Text = fichasmedicas.persionArterial.ToString();
                            txt_temperatura.Text = fichasmedicas.temperatura.ToString();
                            txt_frecCardiaca.Text = fichasmedicas.frecuenciaCardica.ToString();
                            txt_satOxigeno.Text = fichasmedicas.saturacionOxigeno.ToString();
                            txt_frecRespiratoria.Text = fichasmedicas.frecuenciaRespiratoria.ToString();
                            txt_peso.Text = fichasmedicas.peso.ToString();
                            txt_talla.Text = fichasmedicas.talla.ToString();
                            txt_indMasCorporal.Text = fichasmedicas.indMasaCorporal.ToString();
                            txt_perAbdominal.Text = fichasmedicas.perimetroAbdominal.ToString();
                            txt_region.Text = fichasmedicas.regionAnatomica.ToString();
                            txt_tipoRegion.Text = fichasmedicas.evidenciaPatologica.ToString();
                            txt_exafisdescripcion.Text = fichasmedicas.descripcionEF.ToString();
                            txt_region2.Text = fichasmedicas.regionAnatomica2.ToString();
                            txt_tipoRegion2.Text = fichasmedicas.evidenciaPatologica2.ToString();
                            txt_exafisdescripcion2.Text = fichasmedicas.descripcionEF2.ToString();
                            txt_diagnosticosDiagnostico.Text = fichasmedicas.diagnostico.ToString();
                            txt_codigoDiagnostico.Text = fichasmedicas.codigoDiag.ToString();
                            txt_tipoDiagnostico.Text = fichasmedicas.tipoDiag.ToString();
                            txt_condicionDiagnostico.Text = fichasmedicas.condicionDiag.ToString();
                            txt_cronologiaDiagnostico.Text = fichasmedicas.cronologiaDiag.ToString();
                            txt_descripcionDiagnostico.Text = fichasmedicas.descripcionDiag.ToString();
                            txt_tratamiento.Text = fichasmedicas.planTratamiento.ToString();
                            txt_evolucion.Text = fichasmedicas.evolucion.ToString();
                            txt_prescipciones.Text = fichasmedicas.prescripciones.ToString();
                            ddl_especialidad.SelectedValue = fichasmedicas.espec_id.ToString();
                            ddl_profesional.SelectedValue = fichasmedicas.prof_id.ToString();
                            txt_codigo.Text = fichasmedicas.codigoPro.ToString();
                        }
                    }
                }
                Timer1.Enabled = false;
                cargarEspecialidad();
                cargarProfesional();

                txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
            }
        }

        //protected void timerFechaHora_Tick(object sender, EventArgs e)
        //{
        //    this.txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
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
                SqlCommand cmd = new SqlCommand("select top(10) Per_Cedula from Tbl_Personas where Per_Cedula LIKE + @Cedula + '%'", con);
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
            ObtenerCedula();
        }

        private void ObtenerCedula()
        {
            string cedula = txt_numHClinica.Text;

            var lista = from c in dc.Tbl_Person
                        join e in dc.Tbl_Empresa on c.Emp_id equals e.Emp_id
                        where c.Per_cedula == cedula
                        select new
                        {
                            e.Emp_nombre,
                            c.Per_priNombre,
                            c.Per_segNombre,
                            c.Per_priApellido,
                            c.Per_segApellido,
                            c.Per_genero,
                            c.Per_fechaNacimiento
                        };

            foreach (var item in lista)
            {
                string nomEmpresa = item.Emp_nombre;
                txt_nomEmpresa.Text = nomEmpresa;

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

        protected void txt_diagnosticosDiagnostico_TextChanged(object sender, EventArgs e)
        {
            ObtenerCodigo();
        }

        private void ObtenerCodigo()
        {
            string descripcion = txt_diagnosticosDiagnostico.Text;

            var lista = from c in dc.cie10
                        where c.dec10 == descripcion
                        select c;

            foreach (var item in lista)
            {
                string codigo = item.id10;
                txt_codigoDiagnostico.Text = codigo;
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

                fichasmedicas = new Tbl_FichasMedicas();

                //1
                fichasmedicas.moConsulta = txt_moConsulta.Text.ToUpper();
                fichasmedicas.seAcompañanteMc = txt_segAcompa.Text.ToUpper();
                //2
                fichasmedicas.idTipAntecedentePer = Convert.ToInt32(ddl_tipoAntPer.SelectedValue);
                fichasmedicas.antecedentePer = txt_antePersonales.Text.ToUpper();
                fichasmedicas.descripcionPer = txt_antePerDescripcion.Text.ToUpper();
                //3
                fichasmedicas.idTipAntecedenteFam = Convert.ToInt32(ddl_tipoAntFam.SelectedValue);
                fichasmedicas.antecedenteFam = txt_anteFamiliares.Text.ToUpper();
                fichasmedicas.descripcionFam = txt_anteFamDescripcion.Text.ToUpper();
                //4
                fichasmedicas.descripcionEA = txt_enfeActual.Text.ToUpper();
                //5
                fichasmedicas.orgSentido = Convert.ToInt32(ddl_orgSistemas.SelectedValue);
                fichasmedicas.descripcionOS = txt_descOrgSistemas.Text.ToUpper();
                fichasmedicas.respiratorio = Convert.ToInt32(ddl_respiratorio.SelectedValue);
                fichasmedicas.descripcionRes = txt_descRespiratorio.Text.ToUpper();
                fichasmedicas.cardioVascular = Convert.ToInt32(ddl_carVascular.SelectedValue);
                fichasmedicas.descripcionCV = txt_descCarVascular.Text.ToUpper();
                fichasmedicas.digestivo = Convert.ToInt32(ddl_digestivo.SelectedValue);
                fichasmedicas.descripcionDig = txt_descDigestivo.Text.ToUpper();
                fichasmedicas.genital = Convert.ToInt32(ddl_genital.SelectedValue);
                fichasmedicas.descripcionGen = txt_descGenital.Text.ToUpper();
                fichasmedicas.urinario = Convert.ToInt32(ddl_urinario.SelectedValue);
                fichasmedicas.descripcionUri = txt_descUrinario.Text.ToUpper();
                fichasmedicas.muscular = Convert.ToInt32(ddl_muscular.SelectedValue);
                fichasmedicas.descripcionMus = txt_descMuscular.Text.ToUpper();
                fichasmedicas.esqueletico = Convert.ToInt32(ddl_esqueletico.SelectedValue);
                fichasmedicas.descripcionEsq = txt_descEsqueletico.Text.ToUpper();
                fichasmedicas.nervioso = Convert.ToInt32(ddl_nervioso.SelectedValue);
                fichasmedicas.descripcionNer = txt_descNervioso.Text.ToUpper();
                fichasmedicas.endocrino = Convert.ToInt32(ddl_endocrino.SelectedValue);
                fichasmedicas.descripcionEnd = txt_descEndocrino.Text.ToUpper();
                fichasmedicas.hemoLinfatico = Convert.ToInt32(ddl_hemoLinfatico.SelectedValue);
                fichasmedicas.descripcionHL = txt_descHemoLinfatico.Text.ToUpper();
                fichasmedicas.tegumentario = Convert.ToInt32(ddl_tegumentario.SelectedValue);
                fichasmedicas.descripcionTeg = txt_descTegumentario.Text.ToUpper();
                //6
                fichasmedicas.persionArterial = txt_presArterial.Text.ToUpper();
                fichasmedicas.temperatura = txt_temperatura.Text.ToUpper();
                fichasmedicas.frecuenciaCardica = txt_frecCardiaca.Text.ToUpper();
                fichasmedicas.saturacionOxigeno = txt_satOxigeno.Text.ToUpper();
                fichasmedicas.frecuenciaRespiratoria = txt_frecRespiratoria.Text.ToUpper();
                fichasmedicas.peso = txt_peso.Text.ToUpper();
                fichasmedicas.talla = txt_talla.Text.ToUpper();
                fichasmedicas.indMasaCorporal = txt_indMasCorporal.Text.ToUpper();
                fichasmedicas.perimetroAbdominal = txt_perAbdominal.Text.ToUpper();
                //7
                fichasmedicas.regionAnatomica = txt_region.Text.ToUpper();
                fichasmedicas.evidenciaPatologica = txt_tipoRegion.Text.ToUpper();
                fichasmedicas.descripcionEF = txt_exafisdescripcion.Text.ToUpper();
                fichasmedicas.regionAnatomica2 = txt_region2.Text.ToUpper();
                fichasmedicas.evidenciaPatologica2 = txt_tipoRegion2.Text.ToUpper();
                fichasmedicas.descripcionEF2 = txt_exafisdescripcion2.Text.ToUpper();
                //8
                fichasmedicas.diagnostico = txt_diagnosticosDiagnostico.Text.ToUpper();
                fichasmedicas.codigoDiag = txt_codigoDiagnostico.Text.ToUpper();
                fichasmedicas.tipoDiag = txt_tipoDiagnostico.Text.ToUpper();
                fichasmedicas.condicionDiag = txt_condicionDiagnostico.Text.ToUpper();
                fichasmedicas.cronologiaDiag = txt_cronologiaDiagnostico.Text.ToUpper();
                fichasmedicas.descripcionDiag = txt_descripcionDiagnostico.Text.ToUpper();
                //9
                fichasmedicas.planTratamiento = txt_tratamiento.Text.ToUpper();
                //10
                fichasmedicas.evolucion = txt_evolucion.Text.ToUpper();
                //11
                fichasmedicas.prescripciones = txt_prescipciones.Text.ToUpper();
                //Final
                fichasmedicas.fechaHoraGuardado = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                fichasmedicas.espec_id = Convert.ToInt32(ddl_especialidad.SelectedValue);
                fichasmedicas.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                fichasmedicas.codigoPro = txt_codigo.Text.ToUpper();
                fichasmedicas.Per_id = perso;
                fichasmedicas.Emp_id = empre;


                CN_HistorialMedico.GuardarFichaMedica(fichasmedicas);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Guardados Exitosamente', 'success')", true);
                Timer1.Enabled = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Guardados', 'error')", true);
            }
        }

        private void ModificarHistorial(Tbl_FichasMedicas fichasmedicas)
        {
            try
            {
                fichasmedicas.moConsulta = txt_moConsulta.Text.ToUpper();
                fichasmedicas.seAcompañanteMc = txt_segAcompa.Text.ToUpper();
                fichasmedicas.idTipAntecedentePer = Convert.ToInt32(ddl_tipoAntPer.SelectedValue);
                fichasmedicas.antecedentePer = txt_antePersonales.Text.ToUpper();
                fichasmedicas.descripcionPer = txt_antePerDescripcion.Text.ToUpper();
                fichasmedicas.idTipAntecedenteFam = Convert.ToInt32(ddl_tipoAntFam.SelectedValue);
                fichasmedicas.antecedenteFam = txt_anteFamiliares.Text.ToUpper();
                fichasmedicas.descripcionFam = txt_anteFamDescripcion.Text.ToUpper();
                fichasmedicas.descripcionEA = txt_enfeActual.Text.ToUpper();
                fichasmedicas.orgSentido = Convert.ToInt32(ddl_orgSistemas.SelectedValue);
                fichasmedicas.descripcionOS = txt_descOrgSistemas.Text.ToUpper();
                fichasmedicas.respiratorio = Convert.ToInt32(ddl_respiratorio.SelectedValue);
                fichasmedicas.descripcionRes = txt_descRespiratorio.Text.ToUpper();
                fichasmedicas.cardioVascular = Convert.ToInt32(ddl_carVascular.SelectedValue);
                fichasmedicas.descripcionCV = txt_descCarVascular.Text.ToUpper();
                fichasmedicas.digestivo = Convert.ToInt32(ddl_digestivo.SelectedValue);
                fichasmedicas.descripcionDig = txt_descDigestivo.Text.ToUpper();
                fichasmedicas.genital = Convert.ToInt32(ddl_genital.SelectedValue);
                fichasmedicas.descripcionGen = txt_descGenital.Text.ToUpper();
                fichasmedicas.urinario = Convert.ToInt32(ddl_urinario.SelectedValue);
                fichasmedicas.descripcionUri = txt_descUrinario.Text.ToUpper();
                fichasmedicas.muscular = Convert.ToInt32(ddl_muscular.SelectedValue);
                fichasmedicas.descripcionMus = txt_descMuscular.Text.ToUpper();
                fichasmedicas.esqueletico = Convert.ToInt32(ddl_esqueletico.SelectedValue);
                fichasmedicas.descripcionEsq = txt_descEsqueletico.Text.ToUpper();
                fichasmedicas.nervioso = Convert.ToInt32(ddl_nervioso.SelectedValue);
                fichasmedicas.descripcionNer = txt_descNervioso.Text.ToUpper();
                fichasmedicas.endocrino = Convert.ToInt32(ddl_endocrino.SelectedValue);
                fichasmedicas.descripcionEnd = txt_descEndocrino.Text.ToUpper();
                fichasmedicas.hemoLinfatico = Convert.ToInt32(ddl_hemoLinfatico.SelectedValue);
                fichasmedicas.descripcionHL = txt_descHemoLinfatico.Text.ToUpper();
                fichasmedicas.tegumentario = Convert.ToInt32(ddl_tegumentario.SelectedValue);
                fichasmedicas.descripcionTeg = txt_descTegumentario.Text.ToUpper();
                fichasmedicas.persionArterial = txt_presArterial.Text.ToUpper();
                fichasmedicas.temperatura = txt_temperatura.Text.ToUpper();
                fichasmedicas.frecuenciaCardica = txt_frecCardiaca.Text.ToUpper();
                fichasmedicas.saturacionOxigeno = txt_satOxigeno.Text.ToUpper();
                fichasmedicas.frecuenciaRespiratoria = txt_frecRespiratoria.Text.ToUpper();
                fichasmedicas.peso = txt_peso.Text.ToUpper();
                fichasmedicas.talla = txt_talla.Text.ToUpper();
                fichasmedicas.indMasaCorporal = txt_indMasCorporal.Text.ToUpper();
                fichasmedicas.perimetroAbdominal = txt_perAbdominal.Text.ToUpper();
                fichasmedicas.regionAnatomica = txt_region.Text.ToUpper();
                fichasmedicas.evidenciaPatologica = txt_tipoRegion.Text.ToUpper();
                fichasmedicas.descripcionEF = txt_exafisdescripcion.Text.ToUpper();
                fichasmedicas.regionAnatomica2 = txt_region2.Text.ToUpper();
                fichasmedicas.evidenciaPatologica2 = txt_tipoRegion2.Text.ToUpper();
                fichasmedicas.descripcionEF2 = txt_exafisdescripcion2.Text.ToUpper();
                fichasmedicas.diagnostico = txt_diagnosticosDiagnostico.Text.ToUpper();
                fichasmedicas.codigoDiag = txt_codigoDiagnostico.Text.ToUpper();
                fichasmedicas.tipoDiag = txt_tipoDiagnostico.Text.ToUpper();
                fichasmedicas.condicionDiag = txt_condicionDiagnostico.Text.ToUpper();
                fichasmedicas.cronologiaDiag = txt_cronologiaDiagnostico.Text.ToUpper();
                fichasmedicas.descripcionDiag = txt_descripcionDiagnostico.Text.ToUpper();
                fichasmedicas.planTratamiento = txt_tratamiento.Text.ToUpper();
                fichasmedicas.evolucion = txt_evolucion.Text.ToUpper();
                fichasmedicas.prescripciones = txt_prescipciones.Text.ToUpper();
                fichasmedicas.fechaHoraModificacion = Convert.ToDateTime(txt_fechahora.Text.ToUpper());
                fichasmedicas.espec_id = Convert.ToInt32(ddl_especialidad.SelectedValue);
                fichasmedicas.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                fichasmedicas.codigoPro = txt_codigo.Text.ToUpper();

                CN_HistorialMedico.ModificarFichaMedica(fichasmedicas);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }

        private void Guardar_modificar_datos(int fichamedica)
        {
            if (fichamedica == 0)
            {
                GuardarHistorial();
            }
            else
            {
                fichasmedicas = CN_HistorialMedico.ObtenerFichasMedicasPorId(fichamedica);

                if (fichasmedicas != null)
                {
                    ModificarHistorial(fichasmedicas);
                }
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Guardar_modificar_datos(Convert.ToInt32(Request["cod"]));
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Template/Views/Inicio.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/Template/Views/Inicio.aspx");
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

        private void cargarEspecialidad()
        {
            List<Tbl_Especialidad> listaEspec = new List<Tbl_Especialidad>();
            listaEspec = CN_HistorialMedico.ObtenerEspecialidad();
            listaEspec.Insert(0, new Tbl_Especialidad() { espec_nombre = "Seleccione ........" });

            ddl_especialidad.DataSource = listaEspec;
            ddl_especialidad.DataTextField = "espec_nombre";
            ddl_especialidad.DataValueField = "espec_id";
            ddl_especialidad.DataBind();
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

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            HtmlNode.ElementsFlags["img"] = HtmlElementFlag.Closed;
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Closed;
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            BaseFont fuente = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font titulo = new Font(fuente, 18f, Font.BOLD, new BaseColor(0, 0, 0));
            BaseFont fuente2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font parrafo = new Font(fuente2, 12f, Font.NORMAL, new BaseColor(0, 0, 0));
            BaseFont fuente3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font cuadro = new Font(fuente3, 10f, Font.NORMAL, new BaseColor(0, 0, 0));

            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("FICHA MÉDICA", titulo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            string imageURL = Server.MapPath("../Template Principal/images") + "/Foto_Perfil.png";
            iTextSharp.text.Image fotoperfil = iTextSharp.text.Image.GetInstance(imageURL);
            fotoperfil.ScaleAbsolute(75, 75);
            fotoperfil.SetAbsolutePosition(260, 700);
            pdfDoc.Add(fotoperfil);
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            var tblTitulo = new PdfPTable(new float[] { 70f, 50f, 50f, 50f, 50f, 30f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTitulo.AddCell(new PdfPCell(new Paragraph("ESTABLECIMIENTO DE SALUD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEXO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("EDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("N° HISTORIA CLÍNICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblTitulo);
            var tblDatos = new PdfPTable(new float[] { 70f, 50f, 50f, 50f, 50f, 30f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_nomEmpresa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priApellido.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segApellido.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_sexo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_edad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_numHClinica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblmc = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmc.AddCell(new PdfPCell(new Paragraph("1. MOTIVO DE CONSULTA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblmc);
            var tblmcTitulo = new PdfPTable(new float[] { 80f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmcTitulo.AddCell(new PdfPCell(new Paragraph("MOTIVO DE CONSULTA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblmcTitulo.AddCell(new PdfPCell(new Paragraph("MOTIVO DE CONSULTA (según acompañante)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblmcTitulo);
            var tblmcDatos = new PdfPTable(new float[] { 80f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmcDatos.AddCell(new PdfPCell(new Paragraph(txt_moConsulta.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblmcDatos.AddCell(new PdfPCell(new Paragraph(txt_segAcompa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblmcDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblap = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblap.AddCell(new PdfPCell(new Paragraph("2. ANTECEDENTES PERSONALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblap);
            var tblapTitulo = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapTitulo.AddCell(new PdfPCell(new Paragraph("TIPO DE ANTECEDENTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo.AddCell(new PdfPCell(new Paragraph("ANTECEDENTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblapTitulo.AddCell(new PdfPCell(new Paragraph("DESCRIPCIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblapTitulo);
            var tblapDatos = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblapDatos.AddCell(new PdfPCell(new Paragraph(ddl_tipoAntPer.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblapDatos.AddCell(new PdfPCell(new Paragraph(txt_antePersonales.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblapDatos.AddCell(new PdfPCell(new Paragraph(txt_antePerDescripcion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblapDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblaf = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaf.AddCell(new PdfPCell(new Paragraph("3. ANTECEDENTES FAMILIARES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblaf);
            var tblafTitulo = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafTitulo.AddCell(new PdfPCell(new Paragraph("TIPO DE ANTECEDENTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblafTitulo.AddCell(new PdfPCell(new Paragraph("ANTECEDENTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblafTitulo.AddCell(new PdfPCell(new Paragraph("DESCRIPCIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblafTitulo);
            var tblafDatos = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblafDatos.AddCell(new PdfPCell(new Paragraph(ddl_tipoAntFam.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblafDatos.AddCell(new PdfPCell(new Paragraph(txt_anteFamiliares.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblafDatos.AddCell(new PdfPCell(new Paragraph(txt_anteFamDescripcion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblafDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblea = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblea.AddCell(new PdfPCell(new Paragraph("4. ENFERMEDAD ACTUAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblea);
            var tbleaDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbleaDatos.AddCell(new PdfPCell(new Paragraph(txt_enfeActual.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbleaDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblos.AddCell(new PdfPCell(new Paragraph("5. REVISIÓN DE ÓRGANOS Y SISTEMAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblos);
            var tblosTitulo = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosTitulo.AddCell(new PdfPCell(new Paragraph("ÓRGANOS  Y SISTEMAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblosTitulo.AddCell(new PdfPCell(new Paragraph("EVIDENCIA PATOLÓGICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblosTitulo.AddCell(new PdfPCell(new Paragraph("DESCRIPCIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblosTitulo);
            var tblosDatos = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos.AddCell(new PdfPCell(new Paragraph("Órganos de los Sentido", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos.AddCell(new PdfPCell(new Paragraph(ddl_orgSistemas.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos.AddCell(new PdfPCell(new Paragraph(txt_descOrgSistemas.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos);
            var tblosDatos1 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos1.AddCell(new PdfPCell(new Paragraph("Respiratorio", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos1.AddCell(new PdfPCell(new Paragraph(ddl_respiratorio.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos1.AddCell(new PdfPCell(new Paragraph(txt_descRespiratorio.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos1);
            var tblosDatos2 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos2.AddCell(new PdfPCell(new Paragraph("Cardio Vascular", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos2.AddCell(new PdfPCell(new Paragraph(ddl_carVascular.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos2.AddCell(new PdfPCell(new Paragraph(txt_descCarVascular.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos2);
            var tblosDatos3 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos3.AddCell(new PdfPCell(new Paragraph("Digestivo", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos3.AddCell(new PdfPCell(new Paragraph(ddl_digestivo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos3.AddCell(new PdfPCell(new Paragraph(txt_descDigestivo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos3);
            var tblosDatos4 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos4.AddCell(new PdfPCell(new Paragraph("Genital", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos4.AddCell(new PdfPCell(new Paragraph(ddl_genital.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos4.AddCell(new PdfPCell(new Paragraph(txt_descGenital.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos4);
            var tblosDatos5 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos5.AddCell(new PdfPCell(new Paragraph("Urinario", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos5.AddCell(new PdfPCell(new Paragraph(ddl_urinario.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos5.AddCell(new PdfPCell(new Paragraph(txt_descUrinario.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos5);
            var tblosDatos6 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos6.AddCell(new PdfPCell(new Paragraph("Muscular", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos6.AddCell(new PdfPCell(new Paragraph(ddl_muscular.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos6.AddCell(new PdfPCell(new Paragraph(txt_descMuscular.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos6);
            var tblosDatos7 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos7.AddCell(new PdfPCell(new Paragraph("Esquelético", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos7.AddCell(new PdfPCell(new Paragraph(ddl_esqueletico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos7.AddCell(new PdfPCell(new Paragraph(txt_descEsqueletico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos7);
            var tblosDatos8 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos8.AddCell(new PdfPCell(new Paragraph("Nervioso", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos8.AddCell(new PdfPCell(new Paragraph(ddl_nervioso.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos8.AddCell(new PdfPCell(new Paragraph(txt_descNervioso.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos8);
            var tblosDatos9 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos9.AddCell(new PdfPCell(new Paragraph("Endocrino", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos9.AddCell(new PdfPCell(new Paragraph(ddl_endocrino.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos9.AddCell(new PdfPCell(new Paragraph(txt_descEndocrino.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos9);
            var tblosDatos10 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos10.AddCell(new PdfPCell(new Paragraph("Hemo Linfático", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos10.AddCell(new PdfPCell(new Paragraph(ddl_hemoLinfatico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos10.AddCell(new PdfPCell(new Paragraph(txt_descHemoLinfatico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos10);
            var tblosDatos11 = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblosDatos11.AddCell(new PdfPCell(new Paragraph("Tegumentario (Piel y Faneras)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos11.AddCell(new PdfPCell(new Paragraph(ddl_tegumentario.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblosDatos11.AddCell(new PdfPCell(new Paragraph(txt_descTegumentario.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblosDatos11);
            pdfDoc.Add(new Paragraph(" "));
            var tblsv = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblsv.AddCell(new PdfPCell(new Paragraph("6. SIGNOS VITALES Y ANTROPOMÉTRICOS ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblsv);
            var tblsvDatos = new PdfPTable(new float[] { 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblsvDatos.AddCell(new PdfPCell(new Paragraph("Presión Arterial (mmHg)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos.AddCell(new PdfPCell(new Paragraph(txt_presArterial.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos.AddCell(new PdfPCell(new Paragraph("Temperatura (°C)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos.AddCell(new PdfPCell(new Paragraph(txt_temperatura.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblsvDatos);
            var tblsvDatos1 = new PdfPTable(new float[] { 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblsvDatos1.AddCell(new PdfPCell(new Paragraph("Frecuencia Cardiaca (Lat/min)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos1.AddCell(new PdfPCell(new Paragraph(txt_frecCardiaca.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos1.AddCell(new PdfPCell(new Paragraph("Saturación de Oxígeno (O2%)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos1.AddCell(new PdfPCell(new Paragraph(txt_satOxigeno.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblsvDatos1);
            var tblsvDatos2 = new PdfPTable(new float[] { 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblsvDatos2.AddCell(new PdfPCell(new Paragraph("Frecuencia Respiratoria (fr/min)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos2.AddCell(new PdfPCell(new Paragraph(txt_frecRespiratoria.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos2.AddCell(new PdfPCell(new Paragraph("Peso (Kg)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos2.AddCell(new PdfPCell(new Paragraph(txt_peso.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblsvDatos2);
            var tblsvDatos3 = new PdfPTable(new float[] { 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblsvDatos3.AddCell(new PdfPCell(new Paragraph("Talla (cm)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos3.AddCell(new PdfPCell(new Paragraph(txt_talla.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos3.AddCell(new PdfPCell(new Paragraph("Indice de Masa Corporal (kg/m2)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos3.AddCell(new PdfPCell(new Paragraph(txt_indMasCorporal.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblsvDatos3);
            var tblsvDatos4 = new PdfPTable(new float[] { 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblsvDatos4.AddCell(new PdfPCell(new Paragraph("Perímetro Abdominal (cm)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos4.AddCell(new PdfPCell(new Paragraph(txt_perAbdominal.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblsvDatos4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblsvDatos4);
            pdfDoc.Add(new Paragraph(" "));
            var tblef = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblef.AddCell(new PdfPCell(new Paragraph("7. EXAMEN FÍSICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblef);
            var tblefTitulo = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefTitulo.AddCell(new PdfPCell(new Paragraph("EXAMEN/REGIÓN ANATÓMICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefTitulo.AddCell(new PdfPCell(new Paragraph("EVIDENCIA PATOLÓGICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblefTitulo.AddCell(new PdfPCell(new Paragraph("DESCRIPCIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblefTitulo);
            var tblefDatos = new PdfPTable(new float[] { 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblefDatos.AddCell(new PdfPCell(new Paragraph(ddl_tipoAntFam.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblefDatos.AddCell(new PdfPCell(new Paragraph(txt_anteFamiliares.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tblefDatos.AddCell(new PdfPCell(new Paragraph(txt_anteFamDescripcion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblefDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tbldg = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldg.AddCell(new PdfPCell(new Paragraph("8. DIAGNÓSTICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbldg);
            var tbldgTitulo = new PdfPTable(new float[] { 80f, 30f, 20f, 40f, 40f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("DIAGNÓSTICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("CÓDIGO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("TIPO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("CONDICIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("CRONOLOGÍA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldgTitulo.AddCell(new PdfPCell(new Paragraph("DESCRIPCIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tbldgTitulo);
            var tbldgDatos = new PdfPTable(new float[] { 80f, 30f, 20f, 40f, 40f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldgDatos.AddCell(new PdfPCell(new Paragraph(txt_diagnosticosDiagnostico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldgDatos.AddCell(new PdfPCell(new Paragraph(txt_codigoDiagnostico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldgDatos.AddCell(new PdfPCell(new Paragraph(txt_tipoDiagnostico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldgDatos.AddCell(new PdfPCell(new Paragraph(txt_condicionDiagnostico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldgDatos.AddCell(new PdfPCell(new Paragraph(txt_cronologiaDiagnostico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldgDatos.AddCell(new PdfPCell(new Paragraph(txt_descripcionDiagnostico.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbldgDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblpt = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblpt.AddCell(new PdfPCell(new Paragraph("9. PLAN DE TRATAMIENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblpt);
            var tblptDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblptDatos.AddCell(new PdfPCell(new Paragraph(txt_tratamiento.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblptDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblev = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblev.AddCell(new PdfPCell(new Paragraph("10. EVOLUCIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblev);
            var tblevDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevDatos.AddCell(new PdfPCell(new Paragraph(txt_evolucion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblevDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblpp = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblpp.AddCell(new PdfPCell(new Paragraph("11. PRESCRIPCIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblpp);
            var tblppDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblppDatos.AddCell(new PdfPCell(new Paragraph(txt_evolucion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblppDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tbldatTitulo = new PdfPTable(new float[] { 50f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldatTitulo.AddCell(new PdfPCell(new Paragraph("FECHA y HORA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldatTitulo.AddCell(new PdfPCell(new Paragraph("ESPECIALIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldatTitulo.AddCell(new PdfPCell(new Paragraph("NOMBRE DEL PROFESIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldatTitulo.AddCell(new PdfPCell(new Paragraph("CÓDIGO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldatTitulo.AddCell(new PdfPCell(new Paragraph("FIRMA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tbldatTitulo);
            var tbldatDatos = new PdfPTable(new float[] { 50f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldatDatos.AddCell(new PdfPCell(new Paragraph(txt_fechahora.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldatDatos.AddCell(new PdfPCell(new Paragraph(ddl_especialidad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldatDatos.AddCell(new PdfPCell(new Paragraph(ddl_profesional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldatDatos.AddCell(new PdfPCell(new Paragraph(txt_codigo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            tbldatDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbldatDatos);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=FichaMedica_" + txt_numHClinica.Text + "_" + DateTime.Today + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}