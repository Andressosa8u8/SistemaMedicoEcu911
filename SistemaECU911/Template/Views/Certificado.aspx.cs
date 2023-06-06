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
    public partial class Certificado : System.Web.UI.Page
    {

        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        private Tbl_Empresa emp = new Tbl_Empresa();
        private Tbl_Centro cen = new Tbl_Centro();
        private Tbl_Certificado certi = new Tbl_Certificado();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    certi = CN_Certificado.ObtenerCertificadoPorId(codigo);
                    int personasid = Convert.ToInt32(certi.Per_id.ToString());
                    per = CN_HistorialMedico.ObtenerPersonasxId(personasid);
                    int empresaid = Convert.ToInt32(certi.Emp_id.ToString());
                    emp = CN_HistorialMedico.ObtenerEmpresaxId(empresaid);

                    btn_guardar.Text = "Actualizar";

                    if (per != null || emp != null)
                    {

                        txt_numHClinica.ReadOnly = true;

                        //Datos Generales
                        if (certi.certi_ingreso == null)
                        {
                            ckb_ingreso.Checked = false;
                        }
                        else
                        {
                            ckb_ingreso.Checked = true;
                        }
                        if (certi.certi_periodico == null)
                        {
                            ckb_periodico.Checked = false;
                        }
                        else
                        {
                            ckb_periodico.Checked = true;
                        }
                        if (certi.certi_reintegro == null)
                        {
                            ckb_reintegro.Checked = false;
                        }
                        else
                        {
                            ckb_reintegro.Checked = true;
                        }
                        if (certi.certi_retiro == null)
                        {
                            ckb_retiro.Checked = false;
                        }
                        else
                        {
                            ckb_retiro.Checked = true;
                        }

                        //Aptitud Medica para el trabajo
                        if (certi.certi_apto == null)
                        {
                            ckb_apto.Checked = false;
                        }
                        else
                        {
                            ckb_apto.Checked = true;

                        }
                        if (certi.certi_aptoObserva == null)
                        {
                            ckb_aptoObservacion.Checked = false;
                        }
                        else
                        {
                            ckb_aptoObservacion.Checked = true;

                        }
                        if (certi.certi_aptoLimi == null)
                        {
                            ckb_aptoLimitaciones.Checked = false;
                        }
                        else
                        {
                            ckb_aptoLimitaciones.Checked = true;

                        }
                        if (certi.certi_NoApto == null)
                        {
                            ckb_noApto.Checked = false;
                        }
                        else
                        {
                            ckb_noApto.Checked = true;

                        }

                        // Evaluación Médica de retiro
                        if (certi.certi_siUsuEvaMed == null)
                        {
                            ckb_siEvaMedRetiro.Checked = false;
                        }
                        else
                        {
                            ckb_siEvaMedRetiro.Checked = true;

                        }
                        if (certi.certi_noUsuEvaMed == null)
                        {
                            ckb_noEvaMedRetiro.Checked = false;
                        }
                        else
                        {
                            ckb_noEvaMedRetiro.Checked = true;

                        }
                        if (certi.certi_presunCondiDiag == null)
                        {
                            ckb_presuntivaCondiDiag.Checked = false;
                        }
                        else
                        {
                            ckb_presuntivaCondiDiag.Checked = true;

                        }
                        if (certi.certi_defiCondiDiag == null)
                        {
                            ckb_definitivaCondiDiag.Checked = false;
                        }
                        else
                        {
                            ckb_definitivaCondiDiag.Checked = true;

                        }
                        if (certi.certi_noAplicaCondiDiag == null)
                        {
                            ckb_noAplicaCondiDiag.Checked = false;
                        }
                        else
                        {
                            ckb_noAplicaCondiDiag.Checked = true;

                        }
                        if (certi.certi_siCondiSalud == null)
                        {
                            ckb_siCondiSalud.Checked = false;
                        }
                        else
                        {
                            ckb_siCondiSalud.Checked = true;

                        }
                        if (certi.certi_noCondiSalud == null)
                        {
                            ckb_noCondiSalud.Checked = false;
                        }
                        else
                        {
                            ckb_noCondiSalud.Checked = true;

                        }
                        if (certi.certi_noAplicaCondiSalud == null)
                        {
                            ckb_noAplicaCondiSalud.Checked = false;
                        }
                        else
                        {
                            ckb_noAplicaCondiSalud.Checked = true;
                        }

                        txt_nomEmpresa.Text = emp.Emp_nombre.ToString(); 
                        txt_rucEmp.Text = cen.cent_ruc.ToString();
                        txt_priNombre.Text = per.Per_priNombre.ToString();
                        txt_segNombre.Text = per.Per_segNombre.ToString();
                        txt_priApellido.Text = per.Per_priApellido.ToString();
                        txt_segApellido.Text = per.Per_segApellido.ToString();
                        txt_sexo.Text = per.Per_genero.ToString();
                        txt_numHClinica.Text = per.Per_cedula.ToString();
                        txt_puestoTrabajo.Text = per.Per_puestoTrabajo.ToString();

                        if (certi != null)
                        {

                            //A
                            txt_ciiu.Text = certi.certi_ciiu.ToString();
                            txt_numArchivo.Text = certi.certi_numArchivo.ToString();

                            //B
                            if (certi.certi_fechEmision == "")
                            {
                                txt_fechaEmision.Text = certi.certi_fechEmision.ToString();
                            }
                            else
                            {
                                txt_fechaEmision.Text = Convert.ToDateTime(certi.certi_fechEmision).ToString("yyyy-MM-dd");
                            }

                            //C
                            txt_valoraMedicaOcupacional.Text = certi.certi_calificada.ToString();
                            txt_detaObservaAptiMedLaboral.Text = certi.certi_ObservAptiMedLaboral.ToString();

                            //E
                            txt_descripRecomendaciones.Text = certi.certi_descripcionRecomendaciones.ToString();

                            //F
                            ddl_profesional.SelectedValue = certi.prof_id.ToString();
                            txt_codigo.Text = certi.certi_cod.ToString();
                        }
                    }
                }
                Timer1.Enabled = false;
                cargarProfesional();
                txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");                
            }
        }

        //protected void timerFechaHora_Tick(object sender, EventArgs e)
        //{
        //    this.txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
        //}

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

        protected void txt_numHistoCli_TextChanged(object sender, EventArgs e)
        {
            ObtenerCedula();
        }

        private void ObtenerCedula()
        {
            string cedula = txt_numHClinica.Text;

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
                txt_puestoTrabajo.Text = puestoTrabajo;

            }
        }

        private void GuardarCertificado()
        {
            try
            {
                per = CN_HistorialMedico.ObtenerIdPersonasxCedula(txt_numHClinica.Text);
                int perso = Convert.ToInt32(per.Per_id.ToString());

                per = CN_HistorialMedico.ObtenerIdEmpresaxCedula(txt_numHClinica.Text);
                int empre = Convert.ToInt32(per.Emp_id.ToString());

                certi = new Tbl_Certificado();

                //Fecha y Hora
                certi.certi_fechaHoraGuardado = Convert.ToDateTime(txt_fechahora.Text);

                //Datos Generales
                if (ckb_ingreso.Checked == true)
                {
                    certi.certi_ingreso = "SI";                    
                }
                if (ckb_periodico.Checked == true)
                {
                    certi.certi_periodico = "SI";                    
                }
                if (ckb_reintegro.Checked == true)
                {
                    certi.certi_reintegro = "SI";                    
                }
                if (ckb_retiro.Checked == true)
                {
                    certi.certi_retiro = "SI";                    
                }

                //Aptitud Medica para el trabajo
                if (ckb_apto.Checked == true)
                {
                    certi.certi_apto = "SI";                    
                }

                if (ckb_aptoObservacion.Checked == true)
                {
                    certi.certi_aptoObserva = "SI";                    
                }

                if (ckb_aptoLimitaciones.Checked == true)
                {
                    certi.certi_aptoLimi = "SI";                    
                }

                if (ckb_noApto.Checked == true)
                {
                    certi.certi_NoApto = "SI";                    
                }


                // Evaluación Médica de retiro
                if (ckb_siEvaMedRetiro.Checked == true)
                {
                    certi.certi_siUsuEvaMed = "SI";                    
                }
                if (ckb_noEvaMedRetiro.Checked == true)
                {
                    certi.certi_noUsuEvaMed = "SI";                    
                }
                if (ckb_presuntivaCondiDiag.Checked == true)
                {
                    certi.certi_presunCondiDiag = "SI";                    
                }
                if (ckb_definitivaCondiDiag.Checked == true)
                {
                    certi.certi_defiCondiDiag = "SI";                    
                }
                if (ckb_noAplicaCondiDiag.Checked == true)
                {
                    certi.certi_noAplicaCondiDiag = "SI";                    
                }
                if (ckb_siCondiSalud.Checked == true)
                {
                    certi.certi_siCondiSalud = "SI";                    
                }
                if (ckb_noCondiSalud.Checked == true)
                {
                    certi.certi_noCondiSalud = "SI";                    ;
                }
                if (ckb_noAplicaCondiSalud.Checked == true)
                {
                    certi.certi_noAplicaCondiSalud = "SI";                    
                }

                //A
                certi.certi_ciiu = txt_ciiu.Text.ToUpper();
                certi.certi_numArchivo = txt_numArchivo.Text.ToUpper();

                //B.
                certi.certi_fechEmision = txt_fechaEmision.Text.ToUpper();

                //C.
                certi.certi_calificada = txt_valoraMedicaOcupacional.Text.ToUpper();
                certi.certi_ObservAptiMedLaboral = txt_detaObservaAptiMedLaboral.Text.ToUpper();

                //E.
                certi.certi_descripcionRecomendaciones = txt_descripRecomendaciones.Text.ToUpper();

                //F.
                certi.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                certi.certi_cod = txt_codigo.Text.ToUpper();
                certi.Per_id = perso;
                certi.Emp_id = empre;

                CN_Certificado.GuardarCertificado(certi);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Guardados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch(Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Guardados', 'error')", true);
            }
        }

        private void ModificarHistorial(Tbl_Certificado certi)
        {
            try
            {
                //Fecha y Hora
                certi.certi_fecha_horaModificacion = Convert.ToDateTime(txt_fechahora.Text.ToUpper());

                //Datos Generales
                if (ckb_ingreso.Checked == true)
                {
                    certi.certi_ingreso = "SI";
                }
                else
                {
                    certi.certi_ingreso = null;
                }
                if (ckb_periodico.Checked == true)
                {
                    certi.certi_periodico = "SI";
                }
                else
                {
                    certi.certi_periodico = null;
                }
                if (ckb_reintegro.Checked == true)
                {
                    certi.certi_reintegro = "SI";
                }
                else
                {
                    certi.certi_reintegro = null;
                }
                if (ckb_retiro.Checked == true)
                {
                    certi.certi_retiro = "SI";
                }
                else
                {
                    certi.certi_retiro = null;
                }

                //Aptitud Medica para el trabajo
                if (ckb_apto.Checked == true)
                {
                    certi.certi_apto = "SI";
                }
                else
                {
                    certi.certi_apto = null;
                }
                if (ckb_aptoObservacion.Checked == true)
                {
                    certi.certi_aptoObserva = "SI";
                }
                else
                {
                    certi.certi_aptoObserva = null;
                }
                if (ckb_aptoLimitaciones.Checked == true)
                {
                    certi.certi_aptoLimi = "SI";
                }
                else
                {
                    certi.certi_aptoLimi = null;
                }
                if (ckb_noApto.Checked == true)
                {
                    certi.certi_NoApto = "SI";
                }
                else
                {
                    certi.certi_NoApto = null;
                }


                // Evaluación Médica de retiro
                if (ckb_siEvaMedRetiro.Checked == true)
                {
                    certi.certi_siUsuEvaMed = "SI";
                }
                else
                {
                    certi.certi_siUsuEvaMed = null;
                }
                if (ckb_noEvaMedRetiro.Checked == true)
                {
                    certi.certi_noUsuEvaMed = "SI";
                }
                else
                {
                    certi.certi_noUsuEvaMed = null;
                }
                if (ckb_presuntivaCondiDiag.Checked == true)
                {
                    certi.certi_presunCondiDiag = "SI";
                }
                else
                {
                    certi.certi_presunCondiDiag = null;
                }
                if (ckb_definitivaCondiDiag.Checked == true)
                {
                    certi.certi_defiCondiDiag = "SI";
                }
                else
                {
                    certi.certi_defiCondiDiag = null;
                }
                if (ckb_noAplicaCondiDiag.Checked == true)
                {
                    certi.certi_noAplicaCondiDiag = "SI";
                }
                else
                {
                    certi.certi_noAplicaCondiDiag = null;
                }
                if (ckb_siCondiSalud.Checked == true)
                {
                    certi.certi_siCondiSalud = "SI";
                }
                else
                {
                    certi.certi_siCondiSalud = null;
                }
                if (ckb_noCondiSalud.Checked == true)
                {
                    certi.certi_noCondiSalud = "SI";
                }
                else
                {
                    certi.certi_noCondiSalud = null;
                }
                if (ckb_noAplicaCondiSalud.Checked == true)
                {
                    certi.certi_noAplicaCondiSalud = "SI";
                }
                else
                {
                    certi.certi_noAplicaCondiSalud = null;
                }

                //A
                certi.certi_ciiu = txt_ciiu.Text.ToUpper();
                certi.certi_numArchivo = txt_numArchivo.Text.ToUpper();

                //B.
                certi.certi_fechEmision = txt_fechaEmision.Text.ToUpper();

                //C.
                certi.certi_calificada = txt_valoraMedicaOcupacional.Text.ToUpper();
                certi.certi_ObservAptiMedLaboral = txt_detaObservaAptiMedLaboral.Text.ToUpper();

                //E.
                certi.certi_descripcionRecomendaciones = txt_descripRecomendaciones.Text.ToUpper();

                //F.
                certi.prof_id = Convert.ToInt32(ddl_profesional.SelectedValue);
                certi.certi_cod = txt_codigo.Text.ToUpper();

                CN_Certificado.ModificarCertificado(certi);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }


        private void Guardar_modificar_datos(int certifi)
        {
            if (certifi == 0)
            {
                GuardarCertificado();
            }
            else
            {
                certi = CN_Certificado.ObtenerCertificadoPorId(certifi);

                if (certi != null)
                {
                    ModificarHistorial(certi);
                }

            }
        }

        

        protected void btn_guardacertificado_Click(object sender, EventArgs e)
        {
            Guardar_modificar_datos(Convert.ToInt32(Request["cod"]));
        }

        protected void btn_cancelacertificado_Click(object sender, EventArgs e)
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

        protected void ckb_siEvaMedRetiro_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siEvaMedRetiro.Checked == true)
            {
                ckb_noEvaMedRetiro.Checked = false;
            }
        }

        protected void ckb_noEvaMedRetiro_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noEvaMedRetiro.Checked == true)
            {
                ckb_siEvaMedRetiro.Checked = false;
            }
        }

        protected void ckb_presuntivaCondiDiag_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_presuntivaCondiDiag.Checked == true)
            {
                ckb_definitivaCondiDiag.Checked = false;
                ckb_noAplicaCondiDiag.Checked = false;
            }
        }

        protected void ckb_definitivaCondiDiag_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_definitivaCondiDiag.Checked == true)
            {
                ckb_presuntivaCondiDiag.Checked = false;
                ckb_noAplicaCondiDiag.Checked = false;
            }
        }

        protected void ckb_noAplicaCondiDiag_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noAplicaCondiDiag.Checked == true)
            {
                ckb_presuntivaCondiDiag.Checked = false;
                ckb_definitivaCondiDiag.Checked = false;
            }
        }

        protected void ckb_siCondiSalud_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_siCondiSalud.Checked == true)
            {
                ckb_noCondiSalud.Checked = false;
                ckb_noAplicaCondiSalud.Checked = false;
            }
        }

        protected void ckb_noCondiSalud_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noCondiSalud.Checked == true)
            {
                ckb_siCondiSalud.Checked = false;
                ckb_noAplicaCondiSalud.Checked = false;
            }
        }

        protected void ckb_noAplicaCondiSalud_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_noAplicaCondiSalud.Checked == true)
            {
                ckb_siCondiSalud.Checked = false;
                ckb_noCondiSalud.Checked = false;
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
            c2.Phrase = new Phrase("HISTORIA CLÍNICA OCUPACIONAL - CERTIFICADO", titulo);
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
            var tblTitulo = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO NOMBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PRIMER APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEGUNDO APELLIDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("SEXO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblTitulo.AddCell(new PdfPCell(new Paragraph("PUESTO DE TRABAJO (CIUO)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblTitulo);
            var tblDatos = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segNombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_priApellido.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_segApellido.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_sexo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblDatos.AddCell(new PdfPCell(new Paragraph(txt_puestoTrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tbldg = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldg.AddCell(new PdfPCell(new Paragraph("B. DATOS GENERALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbldg);
            var tblfeTitulo = new PdfPTable(new float[] { 20f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfeTitulo.AddCell(new PdfPCell(new Paragraph("FECHA DE EMISIÓN:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblfeTitulo.AddCell(new PdfPCell(new Paragraph(txt_fechaEmision.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblfeTitulo);
            var tblevTitulo = new PdfPTable(new float[] { 70f, 50f, 20f, 50f, 20f, 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("EVALUACIÓN:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("INGRESO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_ingreso.Checked == true)
            {
                tblevTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblevTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }

            tblevTitulo.AddCell(new PdfPCell(new Paragraph("PERIÓDICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_periodico.Checked == true)
            {
                tblevTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblevTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("REINTEGRO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_reintegro.Checked == true)
            {
                tblevTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblevTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblevTitulo.AddCell(new PdfPCell(new Paragraph("RETIRO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_retiro.Checked == true)
            {
                tblevTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblevTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblevTitulo);
            var tblaml = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaml.AddCell(new PdfPCell(new Paragraph("C. APTITUD MÉDICA LABORAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblaml);
            var tblamlTitulo = new PdfPTable(new float[] { 70f, 23f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblamlTitulo.AddCell(new PdfPCell(new Paragraph("DESPUÉS DE LA VALORACIÓN MÉDICA OCUPACIONAL SE CERTIFICA QUE LA PERSONA EN MENCIÓN, ES CALIFICADA COMO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblamlTitulo.AddCell(new PdfPCell(new Paragraph(txt_valoraMedicaOcupacional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblamlTitulo);
            var tblaptTitulo = new PdfPTable(new float[] { 50f, 20f, 50f, 20f, 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
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
            if (ckb_aptoObservacion.Checked == true)
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblaptTitulo.AddCell(new PdfPCell(new Paragraph("APTO CON LIMITACIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_aptoLimitaciones.Checked == true)
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblaptTitulo.AddCell(new PdfPCell(new Paragraph("NO APTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noApto.Checked == true)
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblaptTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblaptTitulo);
            var tblobTitulo = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblobTitulo.AddCell(new PdfPCell(new Paragraph(txt_detaObservaAptiMedLaboral.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblobTitulo);
            var tblemr = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblemr.AddCell(new PdfPCell(new Paragraph("D. EVALUACIÓN MÉDICA DE RETIRO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblemr);
            var tblemrTitulo = new PdfPTable(new float[] { 100f, 50f, 20f, 50f, 20f, 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph("EL USUARIO SE REALIZÓ LA EVALUACIÓN MÉDICA DE RETIRO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siEvaMedRetiro.Checked == true)
            {
                tblemrTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblemrTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noEvaMedRetiro.Checked == true)
            {
                tblemrTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblemrTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblemrTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblemrTitulo);
            var tblcdTitulo = new PdfPTable(new float[] { 100f, 50f, 20f, 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcdTitulo.AddCell(new PdfPCell(new Paragraph("CONDICIÓN DEL DIAGNÓSTICO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcdTitulo.AddCell(new PdfPCell(new Paragraph("PRESUNTIVA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_presuntivaCondiDiag.Checked == true)
            {
                tblcdTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblcdTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblcdTitulo.AddCell(new PdfPCell(new Paragraph("DEFINITIVA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_definitivaCondiDiag.Checked == true)
            {
                tblcdTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblcdTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblcdTitulo.AddCell(new PdfPCell(new Paragraph("NO APLICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noAplicaCondiDiag.Checked == true)
            {
                tblcdTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblcdTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblcdTitulo);
            var tblcsTitulo = new PdfPTable(new float[] { 100f, 50f, 20f, 50f, 20f, 50f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcsTitulo.AddCell(new PdfPCell(new Paragraph("LA CONDICIÓN DE SALUD ESTA RELACIONADA CON EL TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblcsTitulo.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_siCondiSalud.Checked == true)
            {
                tblcsTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblcsTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblcsTitulo.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noCondiSalud.Checked == true)
            {
                tblcsTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblcsTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            tblcsTitulo.AddCell(new PdfPCell(new Paragraph("NO APLICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            if (ckb_noAplicaCondiSalud.Checked == true)
            {
                tblcsTitulo.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            else
            {
                tblcsTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            }
            pdfDoc.Add(tblcsTitulo);
            var tblrm = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrm.AddCell(new PdfPCell(new Paragraph("E.RECOMENDACIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrm);
            var tblrmDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrmDatos.AddCell(new PdfPCell(new Paragraph(txt_descripRecomendaciones.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblrmDatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblcomen = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcomen.AddCell(new PdfPCell(new Paragraph("CON ESTE DOCUMENTO CERTIFICO QUE EL TRABAJADOR SE HA SOMETIDO A LA EVALUACIÓN MÉDICA REQUERIDA PARA(EL INGRESO / LA EJECUCIÓN / EL REINTEGRO Y RETIRO) AL PUESTO LABORAL Y SE HA INFORMADO SOBRE LOS RIESGOS RELACIONADOS CON EL TRABAJO EMITIENDO RECOMENDACIONES RELACIONADAS CON SU ESTADO DE SALUD.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Paragraph(" "));
            tblcomen.AddCell(new PdfPCell(new Paragraph("La presente certificación se expide con base en la historia ocupacional del usuario (a), la cual tiene carácter de confidencial.", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblcomen);
            pdfDoc.Add(new Paragraph(" "));
            var tbldps = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldps.AddCell(new PdfPCell(new Paragraph("F. DATOS DEL PROFESIONAL DE SALUD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tbldps);
            var tbldpsdatos = new PdfPTable(new float[] { 50f, 100f, 40f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph("NOMBRES Y APELLIDOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph(ddl_profesional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph("CÓDIGO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph(txt_codigo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph("FIRMA Y SELLO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tbldpsdatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tbldpsdatos);
            pdfDoc.Add(new Paragraph(" "));
            var tblfrm = new PdfPTable(new float[] { 70f }) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrm.AddCell(new PdfPCell(new Paragraph("G. FIRMA DEL USUARIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblfrm);
            var tblfrmDatos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfrmDatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblfrmDatos);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Certificado_" + txt_numHClinica.Text + "_" + DateTime.Now.ToString("dd/MM/yy_hh:mm") + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        
    }
   
}