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
    public partial class Evolucion : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        private Tbl_Empresa emp = new Tbl_Empresa();
        private Tbl_Centro cen = new Tbl_Centro();
        private Tbl_Evolucion evo = new Tbl_Evolucion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    evo = CN_Evolucion.ObtenerEvolucionPorId(codigo);
                    int personasid = Convert.ToInt32(evo.Per_id.ToString());
                    per = CN_HistorialMedico.ObtenerPersonasxId(personasid);
                    int empresaid = Convert.ToInt32(evo.Emp_id.ToString());
                    emp = CN_HistorialMedico.ObtenerEmpresaxId(empresaid);

                    btn_guardar.Text = "Actualizar";

                    if (per != null || emp != null)
                    {
                        txt_numHClinica.ReadOnly = true;

                        //A
                        txt_nomEmpresa.Text = emp.Emp_nombre.ToString();
                        txt_rucEmp.Text = cen.cent_ruc.ToString();
                        txt_priNombre.Text = per.Per_priNombre.ToString();
                        txt_segNombre.Text = per.Per_segNombre.ToString();
                        txt_priApellido.Text = per.Per_priApellido.ToString();
                        txt_segApellido.Text = per.Per_segApellido.ToString();
                        txt_sexo.Text = per.Per_genero.ToString();
                        txt_numHClinica.Text = per.Per_cedula.ToString();
                        txt_puestoTrabajo.Text = per.Per_puestoTrabajo.ToString();

                        if (evo != null)
                        {
                            //A
                            txt_ciiu.Text = evo.evo_ciiu.ToString();
                            txt_numArchivo.Text = evo.evo_numArchivo.ToString();

                            //B
                            if (evo.evo_fecha1 == "")
                            {
                                txt_fecha1.Text = evo.evo_fecha1.ToString();
                            }
                            else
                            {
                                txt_fecha1.Text = Convert.ToDateTime(evo.evo_fecha1).ToString("yyyy-MM-dd");
                            }
                            txt_hora1.Text = evo.evo_hora1.ToString();
                            txt_notas1.Text = evo.evo_notasEvolucion1.ToString();
                            if (evo.evo_fecha2 == "")
                            {
                                txt_fecha2.Text = evo.evo_fecha2.ToString();
                            }
                            else
                            {
                                txt_fecha2.Text = Convert.ToDateTime(evo.evo_fecha2).ToString("yyyy-MM-dd");
                            }
                            txt_hora2.Text = evo.evo_hora2.ToString();
                            txt_notas2.Text = evo.evo_notasEvolucion2.ToString();
                            if (evo.evo_fecha3 == "")
                            {
                                txt_fecha3.Text = evo.evo_fecha3.ToString();
                            }
                            else
                            {
                                txt_fecha3.Text = Convert.ToDateTime(evo.evo_fecha3).ToString("yyyy-MM-dd");
                            }
                            txt_hora3.Text = evo.evo_hora3.ToString();
                            txt_notas3.Text = evo.evo_notasEvolucion3.ToString();
                            if (evo.evo_fecha4 == "")
                            {
                                txt_fecha4.Text = evo.evo_fecha4.ToString();
                            }
                            else
                            {
                                txt_fecha4.Text = Convert.ToDateTime(evo.evo_fecha4).ToString("yyyy-MM-dd");
                            }
                            txt_hora4.Text = evo.evo_hora4.ToString();
                            txt_notas4.Text = evo.evo_notasEvolucion4.ToString();
                            if (evo.evo_fecha5 == "")
                            {
                                txt_fecha5.Text = evo.evo_fecha5.ToString();
                            }
                            else
                            {
                                txt_fecha5.Text = Convert.ToDateTime(evo.evo_fecha5).ToString("yyyy-MM-dd");
                            }
                            txt_hora5.Text = evo.evo_hora5.ToString();
                            txt_notas5.Text = evo.evo_notasEvolucion5.ToString();
                            if (evo.evo_fecha6 == "")
                            {
                                txt_fecha6.Text = evo.evo_fecha6.ToString();
                            }
                            else
                            {
                                txt_fecha6.Text = Convert.ToDateTime(evo.evo_fecha6).ToString("yyyy-MM-dd");
                            }
                            txt_hora6.Text = evo.evo_hora6.ToString();
                            txt_notas6.Text = evo.evo_notasEvolucion6.ToString();
                            if (evo.evo_fecha7 == "")
                            {
                                txt_fecha7.Text = evo.evo_fecha7.ToString();
                            }
                            else
                            {
                                txt_fecha7.Text = Convert.ToDateTime(evo.evo_fecha7).ToString("yyyy-MM-dd");
                            }
                            txt_hora7.Text = evo.evo_hora7.ToString();
                            txt_notas7.Text = evo.evo_notasEvolucion7.ToString();
                            if (evo.evo_fecha8 == "")
                            {
                                txt_fecha8.Text = evo.evo_fecha8.ToString();
                            }
                            else
                            {
                                txt_fecha8.Text = Convert.ToDateTime(evo.evo_fecha8).ToString("yyyy-MM-dd");
                            }
                            txt_hora8.Text = evo.evo_hora8.ToString();
                            txt_notas8.Text = evo.evo_notasEvolucion8.ToString();
                            if (evo.evo_fecha9 == "")
                            {
                                txt_fecha9.Text = evo.evo_fecha9.ToString();
                            }
                            else
                            {
                                txt_fecha9.Text = Convert.ToDateTime(evo.evo_fecha9).ToString("yyyy-MM-dd");
                            }
                            txt_hora9.Text = evo.evo_hora9.ToString();
                            txt_notas9.Text = evo.evo_notasEvolucion9.ToString();
                            if (evo.evo_fecha10 == "")
                            {
                                txt_fecha10.Text = evo.evo_fecha10.ToString();
                            }
                            else
                            {
                                txt_fecha10.Text = Convert.ToDateTime(evo.evo_fecha10).ToString("yyyy-MM-dd");
                            }
                            txt_hora10.Text = evo.evo_hora10.ToString();
                            txt_notas10.Text = evo.evo_notasEvolucion10.ToString();
                            if (evo.evo_fecha11 == "")
                            {
                                txt_fecha11.Text = evo.evo_fecha11.ToString();
                            }
                            else
                            {
                                txt_fecha11.Text = Convert.ToDateTime(evo.evo_fecha11).ToString("yyyy-MM-dd");
                            }
                            txt_hora11.Text = evo.evo_hora11.ToString();
                            txt_notas11.Text = evo.evo_notasEvolucion11.ToString();
                            if (evo.evo_fecha12 == "")
                            {
                                txt_fecha12.Text = evo.evo_fecha12.ToString();
                            }
                            else
                            {
                                txt_fecha12.Text = Convert.ToDateTime(evo.evo_fecha12).ToString("yyyy-MM-dd");
                            }
                            txt_hora12.Text = evo.evo_hora12.ToString();
                            txt_notas12.Text = evo.evo_notasEvolucion12.ToString();
                            if (evo.evo_fecha13 == "")
                            {
                                txt_fecha13.Text = evo.evo_fecha13.ToString();
                            }
                            else
                            {
                                txt_fecha13.Text = Convert.ToDateTime(evo.evo_fecha13).ToString("yyyy-MM-dd");
                            }
                            txt_hora13.Text = evo.evo_hora13.ToString();
                            txt_notas13.Text = evo.evo_notasEvolucion13.ToString();
                            if (evo.evo_fecha14 == "")
                            {
                                txt_fecha14.Text = evo.evo_fecha14.ToString();
                            }
                            else
                            {
                                txt_fecha14.Text = Convert.ToDateTime(evo.evo_fecha14).ToString("yyyy-MM-dd");
                            }
                            txt_hora14.Text = evo.evo_hora14.ToString();
                            txt_notas14.Text = evo.evo_notasEvolucion14.ToString();
                            if (evo.evo_fecha15 == "")
                            {
                                txt_fecha15.Text = evo.evo_fecha15.ToString();
                            }
                            else
                            {
                                txt_fecha15.Text = Convert.ToDateTime(evo.evo_fecha15).ToString("yyyy-MM-dd");
                            }
                            txt_hora15.Text = evo.evo_hora15.ToString();
                            txt_notas15.Text = evo.evo_notasEvolucion15.ToString();

                            //C
                            txt_farmacoterapia1.Text = evo.evo_farmacoIndicaciones1.ToString();
                            txt_administracion1.Text = evo.evo_adminisFarmacos1.ToString();
                            txt_farmacoterapia2.Text = evo.evo_farmacoIndicaciones2.ToString();
                            txt_administracion2.Text = evo.evo_adminisFarmacos2.ToString();
                            txt_farmacoterapia3.Text = evo.evo_farmacoIndicaciones3.ToString();
                            txt_administracion3.Text = evo.evo_adminisFarmacos3.ToString();
                            txt_farmacoterapia4.Text = evo.evo_farmacoIndicaciones4.ToString();
                            txt_administracion4.Text = evo.evo_adminisFarmacos4.ToString();
                            txt_farmacoterapia5.Text = evo.evo_farmacoIndicaciones5.ToString();
                            txt_administracion5.Text = evo.evo_adminisFarmacos5.ToString();
                            txt_farmacoterapia6.Text = evo.evo_farmacoIndicaciones6.ToString();
                            txt_administracion6.Text = evo.evo_adminisFarmacos6.ToString();
                            txt_farmacoterapia7.Text = evo.evo_farmacoIndicaciones7.ToString();
                            txt_administracion7.Text = evo.evo_adminisFarmacos7.ToString();
                            txt_farmacoterapia8.Text = evo.evo_farmacoIndicaciones8.ToString();
                            txt_administracion8.Text = evo.evo_adminisFarmacos8.ToString();
                            txt_farmacoterapia9.Text = evo.evo_farmacoIndicaciones9.ToString();
                            txt_administracion9.Text = evo.evo_adminisFarmacos9.ToString();
                            txt_farmacoterapia10.Text = evo.evo_farmacoIndicaciones10.ToString();
                            txt_administracion10.Text = evo.evo_adminisFarmacos10.ToString();
                            txt_farmacoterapia11.Text = evo.evo_farmacoIndicaciones11.ToString();
                            txt_administracion11.Text = evo.evo_adminisFarmacos11.ToString();
                            txt_farmacoterapia12.Text = evo.evo_farmacoIndicaciones12.ToString();
                            txt_administracion12.Text = evo.evo_adminisFarmacos12.ToString();
                            txt_farmacoterapia13.Text = evo.evo_farmacoIndicaciones13.ToString();
                            txt_administracion13.Text = evo.evo_adminisFarmacos13.ToString();
                            txt_farmacoterapia14.Text = evo.evo_farmacoIndicaciones14.ToString();
                            txt_administracion14.Text = evo.evo_adminisFarmacos14.ToString();
                            txt_farmacoterapia15.Text = evo.evo_farmacoIndicaciones15.ToString();
                            txt_administracion15.Text = evo.evo_adminisFarmacos15.ToString();
                        }
                    }
                }
                txt_numHClinica.MaxLength = 10;
                Timer1.Enabled = false;
                txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
            }
        }

        //protected void timerFechaHora_Tick(object sender, EventArgs e)
        //{
        //    this.txt_fechahora.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
        //}

        //Metodo obtener cedula por numero de HC EVOLUCION
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
                    txt_puestoTrabajo.Text = puestoTrabajo;

                }
            }
            else
            {
                txt_nomEmpresa.Text = txt_rucEmp.Text = txt_priNombre.Text = txt_segNombre.Text = txt_priApellido.Text = txt_segApellido.Text = txt_sexo.Text = txt_puestoTrabajo.Text = string.Empty;
            }
        }

        private void GuardarEvolucion()
        {
            try
            {
                per = CN_HistorialMedico.ObtenerIdPersonasxCedula(txt_numHClinica.Text);
                int perso = Convert.ToInt32(per.Per_id.ToString());

                per = CN_HistorialMedico.ObtenerIdEmpresaxCedula(txt_numHClinica.Text);
                int empre = Convert.ToInt32(per.Emp_id.ToString());

                evo = new Tbl_Evolucion();

                //Fecha y Hora
                evo.evo_fechaHoraGuardado = Convert.ToDateTime(txt_fechahora.Text);

                //A Captura de datos Establecimiento
                evo.evo_ciiu = txt_ciiu.Text.ToUpper();
                evo.evo_numArchivo = txt_numArchivo.Text.ToUpper();

                //B. Captura de datos Evolucion
                evo.evo_fecha1 = txt_fecha1.Text.ToUpper();
                evo.evo_hora1 = txt_hora1.Text.ToUpper();
                evo.evo_notasEvolucion1 = txt_notas1.Text.ToUpper();
                evo.evo_fecha2 = txt_fecha2.Text.ToUpper();
                evo.evo_hora2 = txt_hora2.Text.ToUpper();
                evo.evo_notasEvolucion2 = txt_notas2.Text.ToUpper();
                evo.evo_fecha3 = txt_fecha3.Text.ToUpper();
                evo.evo_hora3 = txt_hora3.Text.ToUpper();
                evo.evo_notasEvolucion3 = txt_notas3.Text.ToUpper();
                evo.evo_fecha4 = txt_fecha4.Text.ToUpper();
                evo.evo_hora4 = txt_hora4.Text.ToUpper();
                evo.evo_notasEvolucion4 = txt_notas4.Text.ToUpper();
                evo.evo_fecha5 = txt_fecha5.Text.ToUpper();
                evo.evo_hora5 = txt_hora5.Text.ToUpper();
                evo.evo_notasEvolucion5 = txt_notas5.Text.ToUpper();
                evo.evo_fecha6 = txt_fecha6.Text.ToUpper();
                evo.evo_hora6 = txt_hora6.Text.ToUpper();
                evo.evo_notasEvolucion6 = txt_notas6.Text.ToUpper();
                evo.evo_fecha7 = txt_fecha7.Text.ToUpper();
                evo.evo_hora7 = txt_hora7.Text.ToUpper();
                evo.evo_notasEvolucion7 = txt_notas7.Text.ToUpper();
                evo.evo_fecha8 = txt_fecha8.Text.ToUpper();
                evo.evo_hora8 = txt_hora8.Text.ToUpper();
                evo.evo_notasEvolucion8 = txt_notas8.Text.ToUpper();
                evo.evo_fecha9 = txt_fecha9.Text.ToUpper();
                evo.evo_hora9 = txt_hora9.Text.ToUpper();
                evo.evo_notasEvolucion9 = txt_notas9.Text.ToUpper();
                evo.evo_fecha10 = txt_fecha10.Text.ToUpper();
                evo.evo_hora10 = txt_hora10.Text.ToUpper();
                evo.evo_notasEvolucion10 = txt_notas10.Text.ToUpper();
                evo.evo_fecha11 = txt_fecha11.Text.ToUpper();
                evo.evo_hora11 = txt_hora11.Text.ToUpper();
                evo.evo_notasEvolucion11 = txt_notas11.Text.ToUpper();
                evo.evo_fecha12 = txt_fecha12.Text.ToUpper();
                evo.evo_hora12 = txt_hora12.Text.ToUpper();
                evo.evo_notasEvolucion12 = txt_notas12.Text.ToUpper();
                evo.evo_fecha13 = txt_fecha13.Text.ToUpper();
                evo.evo_hora13 = txt_hora13.Text.ToUpper();
                evo.evo_notasEvolucion13 = txt_notas13.Text.ToUpper();
                evo.evo_fecha14 = txt_fecha14.Text.ToUpper();
                evo.evo_hora14 = txt_hora14.Text.ToUpper();
                evo.evo_notasEvolucion14 = txt_notas14.Text.ToUpper();
                evo.evo_fecha15 = txt_fecha15.Text.ToUpper();
                evo.evo_hora15 = txt_hora15.Text.ToUpper();
                evo.evo_notasEvolucion15 = txt_notas15.Text.ToUpper();

                //C. Captura de Datos Prescripcion
                evo.evo_farmacoIndicaciones1 = txt_farmacoterapia1.Text.ToUpper();
                evo.evo_adminisFarmacos1 = txt_administracion1.Text.ToUpper();
                evo.evo_farmacoIndicaciones2 = txt_farmacoterapia2.Text.ToUpper();
                evo.evo_adminisFarmacos2 = txt_administracion2.Text.ToUpper();
                evo.evo_farmacoIndicaciones3 = txt_farmacoterapia3.Text.ToUpper();
                evo.evo_adminisFarmacos3 = txt_administracion3.Text.ToUpper();
                evo.evo_farmacoIndicaciones4 = txt_farmacoterapia4.Text.ToUpper();
                evo.evo_adminisFarmacos4 = txt_administracion4.Text.ToUpper();
                evo.evo_farmacoIndicaciones5 = txt_farmacoterapia5.Text.ToUpper();
                evo.evo_adminisFarmacos5 = txt_administracion5.Text.ToUpper();
                evo.evo_farmacoIndicaciones6 = txt_farmacoterapia6.Text.ToUpper();
                evo.evo_adminisFarmacos6 = txt_administracion6.Text.ToUpper();
                evo.evo_farmacoIndicaciones7 = txt_farmacoterapia7.Text.ToUpper();
                evo.evo_adminisFarmacos7 = txt_administracion7.Text.ToUpper();
                evo.evo_farmacoIndicaciones8 = txt_farmacoterapia8.Text.ToUpper();
                evo.evo_adminisFarmacos8 = txt_administracion8.Text.ToUpper();
                evo.evo_farmacoIndicaciones9 = txt_farmacoterapia9.Text.ToUpper();
                evo.evo_adminisFarmacos9 = txt_administracion9.Text.ToUpper();
                evo.evo_farmacoIndicaciones10 = txt_farmacoterapia10.Text.ToUpper();
                evo.evo_adminisFarmacos10 = txt_administracion10.Text.ToUpper();
                evo.evo_farmacoIndicaciones11 = txt_farmacoterapia11.Text.ToUpper();
                evo.evo_adminisFarmacos11 = txt_administracion11.Text.ToUpper();
                evo.evo_farmacoIndicaciones12 = txt_farmacoterapia12.Text.ToUpper();
                evo.evo_adminisFarmacos12 = txt_administracion12.Text.ToUpper();
                evo.evo_farmacoIndicaciones13 = txt_farmacoterapia13.Text.ToUpper();
                evo.evo_adminisFarmacos13 = txt_administracion13.Text.ToUpper();
                evo.evo_farmacoIndicaciones14 = txt_farmacoterapia14.Text.ToUpper();
                evo.evo_adminisFarmacos14 = txt_administracion14.Text.ToUpper();
                evo.evo_farmacoIndicaciones15 = txt_farmacoterapia15.Text.ToUpper();
                evo.evo_adminisFarmacos15 = txt_administracion15.Text.ToUpper();
                evo.Per_id = perso;
                evo.Emp_id = empre;

                CN_Evolucion.GuardarEvolucion(evo);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Guardados Exitosamente', 'success')", true);
                Timer1.Enabled = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Guardados', 'error')", true);
            }
        }

        private void ModificarEvolucion(Tbl_Evolucion evo)
        {
            try
            {
                //Fecha y Hora
                evo.evo_fecha_horaModificacion = Convert.ToDateTime(txt_fechahora.Text);

                //A Captura de datos Establecimiento
                evo.evo_ciiu = txt_ciiu.Text.ToUpper();
                evo.evo_numArchivo = txt_numArchivo.Text.ToUpper();

                //B. Captura de datos Evolucion
                evo.evo_fecha1 = txt_fecha1.Text.ToUpper();
                evo.evo_hora1 = txt_hora1.Text.ToUpper();
                evo.evo_notasEvolucion1 = txt_notas1.Text.ToUpper();
                evo.evo_fecha2 = txt_fecha2.Text.ToUpper();
                evo.evo_hora2 = txt_hora2.Text.ToUpper();
                evo.evo_notasEvolucion2 = txt_notas2.Text.ToUpper();
                evo.evo_fecha3 = txt_fecha3.Text.ToUpper();
                evo.evo_hora3 = txt_hora3.Text.ToUpper();
                evo.evo_notasEvolucion3 = txt_notas3.Text.ToUpper();
                evo.evo_fecha4 = txt_fecha4.Text.ToUpper();
                evo.evo_hora4 = txt_hora4.Text.ToUpper();
                evo.evo_notasEvolucion4 = txt_notas4.Text.ToUpper();
                evo.evo_fecha5 = txt_fecha5.Text.ToUpper();
                evo.evo_hora5 = txt_hora5.Text.ToUpper();
                evo.evo_notasEvolucion5 = txt_notas5.Text.ToUpper();
                evo.evo_fecha6 = txt_fecha6.Text.ToUpper();
                evo.evo_hora6 = txt_hora6.Text.ToUpper();
                evo.evo_notasEvolucion6 = txt_notas6.Text.ToUpper();
                evo.evo_fecha7 = txt_fecha7.Text.ToUpper();
                evo.evo_hora7 = txt_hora7.Text.ToUpper();
                evo.evo_notasEvolucion7 = txt_notas7.Text.ToUpper();
                evo.evo_fecha8 = txt_fecha8.Text.ToUpper();
                evo.evo_hora8 = txt_hora8.Text.ToUpper();
                evo.evo_notasEvolucion8 = txt_notas8.Text.ToUpper();
                evo.evo_fecha9 = txt_fecha9.Text.ToUpper();
                evo.evo_hora9 = txt_hora9.Text.ToUpper();
                evo.evo_notasEvolucion9 = txt_notas9.Text.ToUpper();
                evo.evo_fecha10 = txt_fecha10.Text.ToUpper();
                evo.evo_hora10 = txt_hora10.Text.ToUpper();
                evo.evo_notasEvolucion10 = txt_notas10.Text.ToUpper();
                evo.evo_fecha11 = txt_fecha11.Text.ToUpper();
                evo.evo_hora11 = txt_hora11.Text.ToUpper();
                evo.evo_notasEvolucion11 = txt_notas11.Text.ToUpper();
                evo.evo_fecha12 = txt_fecha12.Text.ToUpper();
                evo.evo_hora12 = txt_hora12.Text.ToUpper();
                evo.evo_notasEvolucion12 = txt_notas12.Text.ToUpper();
                evo.evo_fecha13 = txt_fecha13.Text.ToUpper();
                evo.evo_hora13 = txt_hora13.Text.ToUpper();
                evo.evo_notasEvolucion13 = txt_notas13.Text.ToUpper();
                evo.evo_fecha14 = txt_fecha14.Text.ToUpper();
                evo.evo_hora14 = txt_hora14.Text.ToUpper();
                evo.evo_notasEvolucion14 = txt_notas14.Text.ToUpper();
                evo.evo_fecha15 = txt_fecha15.Text.ToUpper();
                evo.evo_hora15 = txt_hora15.Text.ToUpper();
                evo.evo_notasEvolucion15 = txt_notas15.Text.ToUpper();

                //C. Captura de Datos Prescripcion
                evo.evo_farmacoIndicaciones1 = txt_farmacoterapia1.Text.ToUpper();
                evo.evo_adminisFarmacos1 = txt_administracion1.Text.ToUpper();
                evo.evo_farmacoIndicaciones2 = txt_farmacoterapia2.Text.ToUpper();
                evo.evo_adminisFarmacos2 = txt_administracion2.Text.ToUpper();
                evo.evo_farmacoIndicaciones3 = txt_farmacoterapia3.Text.ToUpper();
                evo.evo_adminisFarmacos3 = txt_administracion3.Text.ToUpper();
                evo.evo_farmacoIndicaciones4 = txt_farmacoterapia4.Text.ToUpper();
                evo.evo_adminisFarmacos4 = txt_administracion4.Text.ToUpper();
                evo.evo_farmacoIndicaciones5 = txt_farmacoterapia5.Text.ToUpper();
                evo.evo_adminisFarmacos5 = txt_administracion5.Text.ToUpper();
                evo.evo_farmacoIndicaciones6 = txt_farmacoterapia6.Text.ToUpper();
                evo.evo_adminisFarmacos6 = txt_administracion6.Text.ToUpper();
                evo.evo_farmacoIndicaciones7 = txt_farmacoterapia7.Text.ToUpper();
                evo.evo_adminisFarmacos7 = txt_administracion7.Text.ToUpper();
                evo.evo_farmacoIndicaciones8 = txt_farmacoterapia8.Text.ToUpper();
                evo.evo_adminisFarmacos8 = txt_administracion8.Text.ToUpper();
                evo.evo_farmacoIndicaciones9 = txt_farmacoterapia9.Text.ToUpper();
                evo.evo_adminisFarmacos9 = txt_administracion9.Text.ToUpper();
                evo.evo_farmacoIndicaciones10 = txt_farmacoterapia10.Text.ToUpper();
                evo.evo_adminisFarmacos10 = txt_administracion10.Text.ToUpper();
                evo.evo_farmacoIndicaciones11 = txt_farmacoterapia11.Text.ToUpper();
                evo.evo_adminisFarmacos11 = txt_administracion11.Text.ToUpper();
                evo.evo_farmacoIndicaciones12 = txt_farmacoterapia12.Text.ToUpper();
                evo.evo_adminisFarmacos12 = txt_administracion12.Text.ToUpper();
                evo.evo_farmacoIndicaciones13 = txt_farmacoterapia13.Text.ToUpper();
                evo.evo_adminisFarmacos13 = txt_administracion13.Text.ToUpper();
                evo.evo_farmacoIndicaciones14 = txt_farmacoterapia14.Text.ToUpper();
                evo.evo_adminisFarmacos14 = txt_administracion14.Text.ToUpper();
                evo.evo_farmacoIndicaciones15 = txt_farmacoterapia15.Text.ToUpper();
                evo.evo_adminisFarmacos15 = txt_administracion15.Text.ToUpper();

                CN_Evolucion.ModificarEvolucion(evo);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modifcados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }

        private void guardar_modificar_datos(int evolucion)
        {
            if (evolucion == 0)
            {
                GuardarEvolucion();
            }
            else
            {
                evo = CN_Evolucion.ObtenerEvolucionPorId(evolucion);

                if (evo != null)
                {
                    ModificarEvolucion(evo);
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
            c2.Phrase = new Phrase("HOJA DE EVOLUCION", titulo);
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
            var tblevpr = new PdfPTable(new float[] { 80f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevpr.AddCell(new PdfPCell(new Paragraph("B. EVOLUCIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            tblevpr.AddCell(new PdfPCell(new Paragraph("C. PRESCRIPCIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT });
            pdfDoc.Add(tblevpr);
            var tblevprTitulo = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprTitulo.AddCell(new PdfPCell(new Paragraph("FECHA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprTitulo.AddCell(new PdfPCell(new Paragraph("HORA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprTitulo.AddCell(new PdfPCell(new Paragraph("NOTAS DE EVOLUCION", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprTitulo.AddCell(new PdfPCell(new Paragraph("FARMACOTERAPIA INDICACIONES PARA ENFERMERIA Y OTRAS PERSONAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprTitulo.AddCell(new PdfPCell(new Paragraph("ADMINISTRACIÓN FARMACOS Y OTROS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprTitulo);
            var tblevprDatos = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos.AddCell(new PdfPCell(new Paragraph(txt_fecha1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos.AddCell(new PdfPCell(new Paragraph(txt_hora1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos.AddCell(new PdfPCell(new Paragraph(txt_notas1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia1.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos.AddCell(new PdfPCell(new Paragraph(txt_administracion1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos);
            var tblevprDatos1 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos1.AddCell(new PdfPCell(new Paragraph(txt_fecha2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos1.AddCell(new PdfPCell(new Paragraph(txt_hora2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos1.AddCell(new PdfPCell(new Paragraph(txt_notas2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos1.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia2.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos1.AddCell(new PdfPCell(new Paragraph(txt_administracion2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos1);
            var tblevprDatos2 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos2.AddCell(new PdfPCell(new Paragraph(txt_fecha3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos2.AddCell(new PdfPCell(new Paragraph(txt_hora3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos2.AddCell(new PdfPCell(new Paragraph(txt_notas3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos2.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia3.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos2.AddCell(new PdfPCell(new Paragraph(txt_administracion3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos2);
            var tblevprDatos3 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos3.AddCell(new PdfPCell(new Paragraph(txt_fecha4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos3.AddCell(new PdfPCell(new Paragraph(txt_hora4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos3.AddCell(new PdfPCell(new Paragraph(txt_notas4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos3.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia4.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos3.AddCell(new PdfPCell(new Paragraph(txt_administracion4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos3);
            var tblevprDatos4 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos4.AddCell(new PdfPCell(new Paragraph(txt_fecha5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos4.AddCell(new PdfPCell(new Paragraph(txt_hora5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos4.AddCell(new PdfPCell(new Paragraph(txt_notas5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos4.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia5.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos4.AddCell(new PdfPCell(new Paragraph(txt_administracion5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos4);
            var tblevprDatos5 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos5.AddCell(new PdfPCell(new Paragraph(txt_fecha6.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos5.AddCell(new PdfPCell(new Paragraph(txt_hora6.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos5.AddCell(new PdfPCell(new Paragraph(txt_notas6.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos5.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia6.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos5.AddCell(new PdfPCell(new Paragraph(txt_administracion6.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos5);
            var tblevprDatos6 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos6.AddCell(new PdfPCell(new Paragraph(txt_fecha7.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos6.AddCell(new PdfPCell(new Paragraph(txt_hora7.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos6.AddCell(new PdfPCell(new Paragraph(txt_notas7.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos6.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia7.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos6.AddCell(new PdfPCell(new Paragraph(txt_administracion7.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos6);
            var tblevprDatos7 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos7.AddCell(new PdfPCell(new Paragraph(txt_fecha8.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos7.AddCell(new PdfPCell(new Paragraph(txt_hora8.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos7.AddCell(new PdfPCell(new Paragraph(txt_notas8.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos7.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia8.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos7.AddCell(new PdfPCell(new Paragraph(txt_administracion8.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos7);
            var tblevprDatos8 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos8.AddCell(new PdfPCell(new Paragraph(txt_fecha9.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos8.AddCell(new PdfPCell(new Paragraph(txt_hora9.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos8.AddCell(new PdfPCell(new Paragraph(txt_notas9.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos8.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia9.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos8.AddCell(new PdfPCell(new Paragraph(txt_administracion9.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos8);
            var tblevprDatos9 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos9.AddCell(new PdfPCell(new Paragraph(txt_fecha10.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos9.AddCell(new PdfPCell(new Paragraph(txt_hora10.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos9.AddCell(new PdfPCell(new Paragraph(txt_notas10.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos9.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia10.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos9.AddCell(new PdfPCell(new Paragraph(txt_administracion10.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos9);
            var tblevprDatos10 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos10.AddCell(new PdfPCell(new Paragraph(txt_fecha11.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos10.AddCell(new PdfPCell(new Paragraph(txt_hora11.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos10.AddCell(new PdfPCell(new Paragraph(txt_notas11.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos10.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia11.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos10.AddCell(new PdfPCell(new Paragraph(txt_administracion11.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos10);
            var tblevprDatos11 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos11.AddCell(new PdfPCell(new Paragraph(txt_fecha12.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos11.AddCell(new PdfPCell(new Paragraph(txt_hora12.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos11.AddCell(new PdfPCell(new Paragraph(txt_notas12.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos11.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia12.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos11.AddCell(new PdfPCell(new Paragraph(txt_administracion12.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos11);
            var tblevprDatos12 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos12.AddCell(new PdfPCell(new Paragraph(txt_fecha13.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos12.AddCell(new PdfPCell(new Paragraph(txt_hora13.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos12.AddCell(new PdfPCell(new Paragraph(txt_notas13.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos12.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia13.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos12.AddCell(new PdfPCell(new Paragraph(txt_administracion13.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos12);
            var tblevprDatos13 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos13.AddCell(new PdfPCell(new Paragraph(txt_fecha14.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos13.AddCell(new PdfPCell(new Paragraph(txt_hora14.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos13.AddCell(new PdfPCell(new Paragraph(txt_notas14.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos13.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia14.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos13.AddCell(new PdfPCell(new Paragraph(txt_administracion14.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos13);
            var tblevprDatos14 = new PdfPTable(new float[] { 20f, 20f, 40f, 25f, 25f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblevprDatos14.AddCell(new PdfPCell(new Paragraph(txt_fecha15.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos14.AddCell(new PdfPCell(new Paragraph(txt_hora15.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos14.AddCell(new PdfPCell(new Paragraph(txt_notas15.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos14.AddCell(new PdfPCell(new Paragraph(txt_farmacoterapia15.Text, cuadro)) { BorderColor = new BaseColor(0238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            tblevprDatos14.AddCell(new PdfPCell(new Paragraph(txt_administracion15.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER });
            pdfDoc.Add(tblevprDatos14);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Evolución_" + txt_numHClinica.Text + "_" + DateTime.Today + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

    }
}