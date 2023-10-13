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

namespace SistemaECU911.Template.Views_Pacientes
{
    public partial class SocioEconomico : System.Web.UI.Page
    {

        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();

        private Tbl_SocioEconomico sso = new Tbl_SocioEconomico();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Paciente"] != null)
                {
                
                    int usulogueado = Convert.ToInt32(Session["Paciente"].ToString());
                    sso = CN_SocioEconomico.ObtenerSocioEconomicoPer(usulogueado);

                    per = CN_HistorialMedico.ObtenerPersonasxId(usulogueado);

                    if (per != null )
                    {
                        txt_cedula.ReadOnly = true;
                        txt_cedula.Text = per.Per_cedula.ToString();
                        txt_priapellido.Text = per.Per_priApellido.ToString();
                        txt_segapellido.Text = per.Per_segApellido.ToString();
                        txt_prinombre.Text = per.Per_priNombre.ToString();
                        txt_segnombre.Text = per.Per_segNombre.ToString();
                        txt_areatrabajo.Text = per.Per_areaTrabajo.ToString();
                        txt_cargoinstitucional.Text = per.Per_cargoOcupacion.ToString();
                        txt_fechaingresoalsisecu.Text = Convert.ToDateTime(per.Per_fechInicioTrabajo).ToString("yyyy-MM-dd");
                        txt_fechanacimiento.Text = Convert.ToDateTime(per.Per_fechaNacimiento).ToString("yyyy-MM-dd");
                        DateTime edad = Convert.ToDateTime(per.Per_fechaNacimiento);
                        DateTime naci = Convert.ToDateTime(edad);
                        DateTime actual = DateTime.Now;
                        Calculo(naci, actual); 

                        if (sso != null)
                        {
                            

                            //imgPreview.ImageUrl = "~/resources/images/croquis.png";
                            //Datos código y versión
                            txt_codigoinicio.Text = sso.Socio_economico_codigo_inicial.ToString();
                            txt_version.Text = sso.Socio_economico_version.ToString();
                            txt_tipodesangre.Text = sso.Socio_economico_tipo_de_sangre.ToString();

                            //Datos Generales

                            txt_telconvecional.Text = sso.Socio_economico_telefono_convencional.ToString();
                            txt_telcelular.Text = sso.Socio_economico_telefono_celular.ToString();
                            txt_email.Text = sso.Socio_economico_email.ToString();

                            txt_lugarnacimiento.Text = sso.Socio_economico_lugar_nacimiento.ToString();

                            txt_provincia.Text = sso.Socio_economico_direcciondomicilio_provincia.ToString();
                            txt_canton.Text = sso.Socio_economico_direcciondomicilio_canton.ToString();
                            txt_parroquia.Text = sso.Socio_economico_direcciondomicilio_parroquia.ToString();
                            txt_barrio.Text = sso.Socio_economico_direcciondomicilio_barrio.ToString();

                            txt_calleprincipal.Text = sso.Socio_economico_direcciondomicilio_calle_principal.ToString();
                            txt_mumerodecasa.Text = sso.Socio_economico_direcciondomicilio_numero.ToString();
                            txt_callesecundaria.Text = sso.Socio_economico_direcciondomicilio_calle_secundaria.ToString();
                            txt_refubicardomicilio.Text = sso.Socio_economico_direcciondomicilio_referencia.ToString();

                            txt_tipoviviendaotro.Text = sso.Socio_economico_tipovivienda_otro_indique.ToString();

                            txt_emernomyape.Text = sso.Socio_economico_contacto_emergencia_nombres_apellidos.ToString();
                            txt_emeparentesco.Text = sso.Socio_economico_contacto_emergencia_parentesco.ToString();
                            txt_emetelefono.Text = sso.Socio_economico_contacto_emergencia_telefono.ToString();
                            txt_emecalleprincipal.Text = sso.Socio_economico_contacto_emergencia_calle_principal.ToString();
                            txt_emenumdomicilio.Text = sso.Socio_economico_contacto_emergencia_numero_domicilio.ToString();
                            txt_emecallesecun.Text = sso.Socio_economico_contacto_emergencia_calle_secundaria.ToString();
                            txt_emerefubicardomicilio.Text = sso.Socio_economico_contacto_emergencia_referencia_domicilio.ToString();

                            //Salud
                            txt_poseeenfermedadprexistente.Text = sso.Socio_economico_posee_enfermedad.ToString();
                            txt_tipodiscapacidad.Text = sso.Socio_economico_discapacidad_tipo.ToString();
                            txt_porcentajediscapacidad.Text = sso.Socio_economico_discapacidad_porcentaje.ToString();
                            txt_numcarnetconadis.Text = sso.Socio_economico_discapacidad_carnet_conadis.ToString();
                            if (sso.Socio_economico_discapacidad_fecha_caducidad_carnet == "")
                            {
                                txt_fechacaducidadcarnet.Text = sso.Socio_economico_discapacidad_fecha_caducidad_carnet.ToString();
                            }
                            else
                            {
                                txt_fechacaducidadcarnet.Text = Convert.ToDateTime(sso.Socio_economico_discapacidad_fecha_caducidad_carnet).ToString("yyyy-MM-dd");
                            }

                            txt_gestacióntiempo.Text = sso.Socio_economico_estado_gestacion_tiempo.ToString();
                            if (sso.Socio_economico_fecha_tentativa_parto == "")
                            {
                                txt_fechatentativaparto.Text = sso.Socio_economico_fecha_tentativa_parto.ToString();
                            }
                            else
                            {
                                txt_fechatentativaparto.Text = Convert.ToDateTime(sso.Socio_economico_fecha_tentativa_parto).ToString("yyyy-MM-dd");
                            }
                            if (sso.Socio_economico_periodo_lactancia_fecha_culminacion == "")
                            {
                                txt_fechaculmicacionlactancia.Text = sso.Socio_economico_periodo_lactancia_fecha_culminacion.ToString();
                            }
                            else
                            {
                                txt_fechaculmicacionlactancia.Text = Convert.ToDateTime(sso.Socio_economico_periodo_lactancia_fecha_culminacion).ToString("yyyy-MM-dd");
                            }

                            txt_cualcatastrofica.Text = sso.Socio_economico_enfermedad_cronica_cual.ToString();
                            txt_enfermedadraracual.Text = sso.Socio_economico_enfermedad_rara_cual.ToString();

                            txt_causaconsumoalcohol.Text = sso.Socio_economico_consume_alcohol_frecuencia.ToString();
                            txt_tiempoconsumoalcohol.Text = sso.Socio_economico_consume_alcohol_tiempo_consumo.ToString();
                            txt_frecuenciaconsumotabaco.Text = sso.Socio_economico_consume_tabaco_frecuencia_consumo.ToString();
                            txt_tiempoconsumotabaco.Text = sso.Socio_economico_consume_tabaco_tiempo_consumo.ToString();
                            txt_sustanciapsicotropicatipo.Text = sso.Socio_economico_consume_sustancia_psicotropica_tipo.ToString();
                            txt_sustanciapsicotropicafrecuencia.Text = sso.Socio_economico_consume_sustancia_psicotropica_frecuencia_consumo.ToString();

                            //Situacion económica del servidor
                            txt_miembroactivoseconomicamente.Text = sso.Socio_economico_numero_miembro_economicamente_activos.ToString();
                            txt_situacionlaboralconyugue.Text = sso.Socio_economico_situación_laboral_del_conyugue.ToString();

                            txt_totalingresos1.Text = sso.Socio_economico_total_ingresos_mensuales_proyectados_1.ToString();
                            txt_ayuda1.Text = sso.Socio_economico_ayuda1.ToString();
                            txt_otros1.Text = sso.Socio_economico_otros1.ToString();
                            txt_alimentación.Text = sso.Socio_economico_total_egresos_alimentacion.ToString();

                            txt_totalingresos2.Text = sso.Socio_economico_total_ingresos_mensuales_proyectados_2.ToString();
                            txt_ayuda2.Text = sso.Socio_economico_ayuda2.ToString();
                            txt_otros2.Text = sso.Socio_economico_otros2.ToString();
                            txt_vivienda.Text = sso.Socio_economico_total_egresos_vivienda.ToString();

                            txt_totalingresos3.Text = sso.Socio_economico_total_ingresos_mensuales_proyectados_3.ToString();
                            txt_ayuda3.Text = sso.Socio_economico_ayuda3.ToString();
                            txt_otros3.Text = sso.Socio_economico_otros3.ToString();
                            txt_educación.Text = sso.Socio_economico_total_egresos_educacion.ToString();

                            txt_totalingresos4.Text = sso.Socio_economico_total_ingresos_mensuales_proyectados_4.ToString();
                            txt_ayuda4.Text = sso.Socio_economico_ayuda4.ToString();
                            txt_otros4.Text = sso.Socio_economico_otros4.ToString();
                            txt_serviciosbasicos.Text = sso.Socio_economico_total_egresos_servicios_basicos.ToString();

                            txt_totalingresos5.Text = sso.Socio_economico_total_ingresos_mensuales_proyectados_5.ToString();
                            txt_ayuda5.Text = sso.Socio_economico_ayuda5.ToString();
                            txt_otros5.Text = sso.Socio_economico_otros5.ToString();
                            txt_salud.Text = sso.Socio_economico_total_egresos_salud.ToString();

                            txt_totalingresos6.Text = sso.Socio_economico_total_ingresos_mensuales_proyectados_6.ToString();
                            txt_ayuda6.Text = sso.Socio_economico_ayuda6.ToString();
                            txt_otros6.Text = sso.Socio_economico_otros6.ToString();
                            txt_movilización.Text = sso.Socio_economico_total_egresos_movilizacion.ToString();

                            txt_totalingresos7.Text = sso.Socio_economico_total_ingresos_mensuales_proyectados_7.ToString();
                            txt_ayuda7.Text = sso.Socio_economico_ayuda7.ToString();
                            txt_otros7.Text = sso.Socio_economico_otros7.ToString();
                            txt_deudas.Text = sso.Socio_economico_total_egresos_deudas.ToString();

                            txt_totalingresos8.Text = sso.Socio_economico_total_ingresos_mensuales_proyectados_8.ToString();
                            txt_ayuda8.Text = sso.Socio_economico_ayuda8.ToString();
                            txt_otros8.Text = sso.Socio_economico_otros8.ToString();
                            txt_otrospensiones.Text = sso.Socio_economico_total_egresos_pensiones_otros.ToString();

                            txt_biencasa.Text = sso.Socio_economico_descripcion_mueble_valor_casa.ToString();
                            txt_biendepartamento.Text = sso.Socio_economico_descripcion_mueble_valor_departamento.ToString();
                            txt_bienvehiculo.Text = sso.Socio_economico_descripcion_mueble_valor_vehiculo.ToString();
                            txt_bienterreno.Text = sso.Socio_economico_descripcion_mueble_valor_terreno.ToString();
                            txt_bienegocio.Text = sso.Socio_economico_descripcion_mueble_valor_negocio.ToString();
                            txt_bienmueblesyenseres.Text = sso.Socio_economico_descripcion_mueble_valor_muebles_enseres.ToString();

                            txt_otrodescripcionviviendafamilia.Text = sso.Socio_economico_caracteristica_vivienda_descripcion_otra_especifique.ToString();
                            txt_otratenencia.Text = sso.Socio_economico_caracteristica_vivienda_tenencia_otra_especifique.ToString();
                            txt_otrotipodecasa.Text = sso.Socio_economico_caracteristica_vivienda_tipo_otro_especifique.ToString();
                            txt_otradistribucioncasa.Text = sso.Socio_economico_caracteristica_vivienda_distribucion_otro_especifique.ToString();

                            //Información Familiar
                            txt_nomapellidos1.Text = sso.Socio_economico_nombres_apellidos_familiar1.ToString();
                            txt_parentesco1.Text = sso.Socio_economico_parentesco_familiar1.ToString();
                            if (sso.Socio_economico_fecha_nacimiento_familiar1 == "")
                            {
                                txt_fechanacimiento1.Text = sso.Socio_economico_fecha_nacimiento_familiar1.ToString();
                            }
                            else
                            {
                                txt_fechanacimiento1.Text = Convert.ToDateTime(sso.Socio_economico_fecha_nacimiento_familiar1).ToString("yyyy-MM-dd");
                            }
                            txt_edad1.Text = sso.Socio_economico_edad_familiar1.ToString();

                            txt_nomapellidos2.Text = sso.Socio_economico_nombres_apellidos_familiar2.ToString();
                            txt_parentesco2.Text = sso.Socio_economico_parentesco_familiar2.ToString();
                            if (sso.Socio_economico_fecha_nacimiento_familiar2 == "")
                            {
                                txt_fechanacimiento2.Text = sso.Socio_economico_fecha_nacimiento_familiar2.ToString();
                            }
                            else
                            {
                                txt_fechanacimiento2.Text = Convert.ToDateTime(sso.Socio_economico_fecha_nacimiento_familiar2).ToString("yyyy-MM-dd");
                            }
                            txt_edad2.Text = sso.Socio_economico_edad_familiar2.ToString();

                            txt_nomapellidos3.Text = sso.Socio_economico_nombres_apellidos_familiar3.ToString();
                            txt_parentesco3.Text = sso.Socio_economico_parentesco_familiar3.ToString();
                            if (sso.Socio_economico_fecha_nacimiento_familiar3 == "")
                            {
                                txt_fechanacimiento3.Text = sso.Socio_economico_fecha_nacimiento_familiar3.ToString();
                            }
                            else
                            {
                                txt_fechanacimiento3.Text = Convert.ToDateTime(sso.Socio_economico_fecha_nacimiento_familiar3).ToString("yyyy-MM-dd");
                            }
                            txt_edad3.Text = sso.Socio_economico_edad_familiar3.ToString();

                            txt_nomapellidos4.Text = sso.Socio_economico_nombres_apellidos_familiar4.ToString();
                            txt_parentesco4.Text = sso.Socio_economico_parentesco_familiar4.ToString();
                            if (sso.Socio_economico_fecha_nacimiento_familiar4 == "")
                            {
                                txt_fechanacimiento4.Text = sso.Socio_economico_fecha_nacimiento_familiar4.ToString();
                            }
                            else
                            {
                                txt_fechanacimiento4.Text = Convert.ToDateTime(sso.Socio_economico_fecha_nacimiento_familiar4).ToString("yyyy-MM-dd");
                            }
                            txt_edad4.Text = sso.Socio_economico_edad_familiar4.ToString();

                            txt_nomapellidos5.Text = sso.Socio_economico_nombres_apellidos_familiar5.ToString();
                            txt_parentesco5.Text = sso.Socio_economico_parentesco_familiar5.ToString();
                            if (sso.Socio_economico_fecha_nacimiento_familiar5 == "")
                            {
                                txt_fechanacimiento5.Text = sso.Socio_economico_fecha_nacimiento_familiar5.ToString();
                            }
                            else
                            {
                                txt_fechanacimiento5.Text = Convert.ToDateTime(sso.Socio_economico_fecha_nacimiento_familiar5).ToString("yyyy-MM-dd");
                            }
                            txt_edad5.Text = sso.Socio_economico_edad_familiar5.ToString();

                            txt_familiardiscapacitadonomape1.Text = sso.Socio_economico_nombres_apellidos_familiar_discapacidad1.ToString();
                            if (sso.Socio_economico_fecha_caducidad_carnet_familiar_discapacidad1 == "")
                            {
                                txt_familiardiscapacitadofechacaducidadcarnet1.Text = sso.Socio_economico_fecha_caducidad_carnet_familiar_discapacidad1.ToString();
                            }
                            else
                            {
                                txt_familiardiscapacitadofechacaducidadcarnet1.Text = Convert.ToDateTime(sso.Socio_economico_fecha_caducidad_carnet_familiar_discapacidad1).ToString("yyyy-MM-dd");
                            }
                            txt_familiardiscapacitadotipodiscapacidad1.Text = sso.Socio_economico_familiar_discapacidad_tipo1.ToString();
                            txt_familiardiscapacitadoporcentajediscapacidad1.Text = sso.Socio_economico_familiar_discapacidad_porcentaje1.ToString();
                            txt_familiardiscapacitadoparentesco1.Text = sso.Socio_economico_familiar_discapacidad_parentesco1.ToString();
                            if (sso.Socio_economico_familiar_discapacidad_fecha_nacimiento1 == "")
                            {
                                txt_familiardiscapacitadofechanacimiento1.Text = sso.Socio_economico_familiar_discapacidad_fecha_nacimiento1.ToString();
                            }
                            else
                            {
                                txt_familiardiscapacitadofechanacimiento1.Text = Convert.ToDateTime(sso.Socio_economico_familiar_discapacidad_fecha_nacimiento1).ToString("yyyy-MM-dd");
                            }

                            txt_familiardiscapacitadonomape2.Text = sso.Socio_economico_nombres_apellidos_familiar_discapacidad2.ToString();
                            if (sso.Socio_economico_fecha_caducidad_carnet_familiar_discapacidad2 == "")
                            {
                                txt_familiardiscapacitadofechacaducidadcarnet2.Text = sso.Socio_economico_fecha_caducidad_carnet_familiar_discapacidad2.ToString();
                            }
                            else
                            {
                                txt_familiardiscapacitadofechacaducidadcarnet2.Text = Convert.ToDateTime(sso.Socio_economico_fecha_caducidad_carnet_familiar_discapacidad2).ToString("yyyy-MM-dd");
                            }
                            txt_familiardiscapacitadotipodiscapacidad2.Text = sso.Socio_economico_familiar_discapacidad_tipo2.ToString();
                            txt_familiardiscapacitadoporcentajediscapacidad2.Text = sso.Socio_economico_familiar_discapacidad_porcentaje2.ToString();
                            txt_familiardiscapacitadoparentesco2.Text = sso.Socio_economico_familiar_discapacidad_parentesco2.ToString();
                            if (sso.Socio_economico_familiar_discapacidad_fecha_nacimiento2 == "")
                            {
                                txt_familiardiscapacitadofechanacimiento2.Text = sso.Socio_economico_familiar_discapacidad_fecha_nacimiento2.ToString();
                            }
                            else
                            {
                                txt_familiardiscapacitadofechanacimiento2.Text = Convert.ToDateTime(sso.Socio_economico_familiar_discapacidad_fecha_nacimiento2).ToString("yyyy-MM-dd");
                            }

                            txt_dependenciaministeriotrabajotiempo.Text = sso.Socio_economico_registrar_dependencia_familiar_MT_tiempo.ToString();
                            txt_numcarnetMSP.Text = sso.Socio_economico_registrar_dependencia_familiar_MT_numero_carnetMSP.ToString();
                            txt_acargofamiliarenfermedadraratiempo.Text = sso.Socio_economico_a_cargo_familiar_enfermedad_catastrofica_rara_tiempo.ToString();
                            txt_familiarenfermedadraratipo.Text = sso.Socio_economico_a_cargo_familiar_enfermedad_catastrofica_rara_tipoenfermedad.ToString();

                            //Actividad tiempo libre
                            txt_otraactividad.Text = sso.Socio_economico_otro_especifique.ToString();
                            txt_actividadeconomicadetalle.Text = sso.Socio_economico_actividad_economica_adicional_detalle.ToString();
                            txt_actividadeconomicatiempodestina.Text = sso.Socio_economico_actividad_economica_adicional_tiempo_destina.ToString();
                            txt_actividadeconomicatiemporealiza.Text = sso.Socio_economico_actividad_economica_adicional_hace_tiempo.ToString();
                            txt_especifiquedeporte.Text = sso.Socio_economico_actividad_deportiva_especificar.ToString();
                            txt_frecuenciadeporte.Text = sso.Socio_economico_actividad_deportiva_frecuencia.ToString();
                            txt_edadpracticadeporte.Text = sso.Socio_economico_actividad_deportiva_edad.ToString();
                            txt_tipolesion.Text = sso.Socio_economico_lesion_tipo.ToString();
                            txt_edadlesion.Text = sso.Socio_economico_lesion_edad.ToString();

                            //Informacion para uso de bienestar familiar
                            txt_relacionfamiliarporque.Text = sso.Socio_economico_evaluacion_relacion_familiar_porque.ToString();
                            txt_relacionparejaporque.Text = sso.Socio_economico_evaluacion_relacion_pareja_porque.ToString();
                            txt_relacionconhijosporque.Text = sso.Socio_economico_evaluacion_relacion_hijos_porque.ToString();
                            txt_observacionesfamiliares.Text = sso.Socio_economico_problemas_familiares_observaciones.ToString();
                            txt_nivelsaludfamiliarporque.Text = sso.Socio_economico_nivel_salud_familia_porque.ToString();
                            txt_observacionesgenerales.Text = sso.Socio_economico_familia_observaciones.ToString();
                            txt_informacionadicional.Text = sso.Socio_economico_informacion_adicional.ToString();

                            //INFORMACIÓN DE LA PERSONA QUE GUARDO
                            txt_firmadelservidor.Text = sso.Socio_economico_GuardadoPor.ToString();

                            //DATOS GENERALES
                            //Modalidad de Trabajo
                            if (sso.Socio_economico_modalidadvinculacion_leyorgserpublico == null)
                            {
                                cb_modalidadvinculacionlosep.Checked = false;
                            }
                            else
                            {
                                cb_modalidadvinculacionlosep.Checked = true;
                            }
                            if (sso.Socio_economico_modalidadvinculacion_codigotrabajo == null)
                            {
                                cb_modalidadvinculacioncodigotrabajo.Checked = false;
                            }
                            else
                            {
                                cb_modalidadvinculacioncodigotrabajo.Checked = true;
                            }
                            //Estado Civil
                            if (sso.Socio_economico_estadocivil_soltero == null)
                            {
                                cb_soltero.Checked = false;
                            }
                            else
                            {
                                cb_soltero.Checked = true;
                            }
                            if (sso.Socio_economico_estadocivil_casado == null)
                            {
                                cb_casado.Checked = false;
                            }
                            else
                            {
                                cb_casado.Checked = true;
                            }
                            if (sso.Socio_economico_estadocivil_viudo == null)
                            {
                                cb_viudo.Checked = false;
                            }
                            else
                            {
                                cb_viudo.Checked = true;
                            }
                            if (sso.Socio_economico_estadocivil_unionlibre == null)
                            {
                                cb_unionlibre.Checked = false;
                            }
                            else
                            {
                                cb_unionlibre.Checked = true;
                            }
                            if (sso.Socio_economico_estadocivil_divorciado == null)
                            {
                                cb_divorciado.Checked = false;
                            }
                            else
                            {
                                cb_divorciado.Checked = true;
                            }
                            //Genero
                            if (sso.Socio_economico_genero_masculino == null)
                            {
                                cb_genmasculino.Checked = false;
                            }
                            else
                            {
                                cb_genmasculino.Checked = true;
                            }
                            if (sso.Socio_economico_genero_femenino == null)
                            {
                                cb_genfemenino.Checked = false;
                            }
                            else
                            {
                                cb_genfemenino.Checked = true;
                            }
                            //Donante
                            if (sso.Socio_economico_es_donante_si == null)
                            {
                                cb_donantesi.Checked = false;
                            }
                            else
                            {
                                cb_donantesi.Checked = true;
                            }
                            if (sso.Socio_economico_es_donante_no == null)
                            {
                                cb_donanteno.Checked = false;
                            }
                            else
                            {
                                cb_donanteno.Checked = true;
                            }
                            //Nivel de Educación
                            if (sso.Socio_economico_titulo_primaria == null)
                            {
                                cb_primaria.Checked = false;
                            }
                            else
                            {
                                cb_primaria.Checked = true;
                            }
                            if (sso.Socio_economico_titulo_secundaria == null)
                            {
                                cb_secundaria.Checked = false;
                            }
                            else
                            {
                                cb_secundaria.Checked = true;
                            }
                            if (sso.Socio_economico_titulo_superior == null)
                            {
                                cb_superior.Checked = false;
                            }
                            else
                            {
                                cb_superior.Checked = true;
                            }
                            if (sso.Socio_economico_titulo_especializacion == null)
                            {
                                cb_especializacion.Checked = false;
                            }
                            else
                            {
                                cb_especializacion.Checked = true;
                            }
                            if (sso.Socio_economico_titulo_diplomado == null)
                            {
                                cb_diplomado.Checked = false;
                            }
                            else
                            {
                                cb_diplomado.Checked = true;
                            }
                            if (sso.Socio_economico_titulo_maestria == null)
                            {
                                cb_maestria.Checked = false;
                            }
                            else
                            {
                                cb_maestria.Checked = true;
                            }
                            //Autoidentificacion Étnica
                            if (sso.Socio_economico_autoidentificacionetnica_blanco == null)
                            {
                                cb_blanco.Checked = false;
                            }
                            else
                            {
                                cb_blanco.Checked = true;
                            }
                            if (sso.Socio_economico_autoidentificacionetnica_mestizo == null)
                            {
                                cb_mestizo.Checked = false;
                            }
                            else
                            {
                                cb_mestizo.Checked = true;
                            }
                            if (sso.Socio_economico_autoidentificacionetnica_afrodescendiente == null)
                            {
                                cb_afro.Checked = false;
                            }
                            else
                            {
                                cb_afro.Checked = true;
                            }
                            if (sso.Socio_economico_autoidentificacionetnica_indigena == null)
                            {
                                cb_indigena.Checked = false;
                            }
                            else
                            {
                                cb_indigena.Checked = true;
                            }
                            if (sso.Socio_economico_autoidentificacionetnica_montubio == null)
                            {
                                cb_montubio.Checked = false;
                            }
                            else
                            {
                                cb_montubio.Checked = true;
                            }
                            //Sector donde vive
                            if (sso.Socio_economico_sectorvive_norte == null)
                            {
                                cb_norte.Checked = false;
                            }
                            else
                            {
                                cb_norte.Checked = true;
                            }
                            if (sso.Socio_economico_sectorvive_centro == null)
                            {
                                cb_centro.Checked = false;
                            }
                            else
                            {
                                cb_centro.Checked = true;
                            }
                            if (sso.Socio_economico_sectorvive_sur == null)
                            {
                                cb_sur.Checked = false;
                            }
                            else
                            {
                                cb_sur.Checked = true;
                            }

                            if (sso.Socio_economico_sectorvive_valle == null)
                            {
                                cb_valle.Checked = false;
                            }
                            else
                            {
                                cb_valle.Checked = true;
                            }
                            if (sso.Socio_economico_sectorvive_valledeloschillos == null)
                            {
                                cb_valledeloschillos.Checked = false;
                            }
                            else
                            {
                                cb_valledeloschillos.Checked = true;
                            }
                            //Tipo de vivienda
                            if (sso.Socio_economico_tipovivienda_casa == null)
                            {
                                cb_casa.Checked = false;
                            }
                            else
                            {
                                cb_casa.Checked = true;
                            }
                            if (sso.Socio_economico_tipovivienda_departamento == null)
                            {
                                cb_departamento.Checked = false;
                            }
                            else
                            {
                                cb_departamento.Checked = true;
                            }
                            //Riesgo Delincuencial
                            if (sso.Socio_economico_riesgo_delincuencial_alto == null)
                            {
                                cb_riesgoalto.Checked = false;
                            }
                            else
                            {
                                cb_riesgoalto.Checked = true;
                            }
                            if (sso.Socio_economico_riesgo_delincuencial_medio == null)
                            {
                                cb_riesgomedio.Checked = false;
                            }
                            else
                            {
                                cb_riesgomedio.Checked = true;
                            }
                            if (sso.Socio_economico_riesgo_delincuencial_bajo == null)
                            {
                                cb_riesgobajo.Checked = false;
                            }
                            else
                            {
                                cb_riesgobajo.Checked = true;
                            }
                            //Dinero ahorro
                            if (sso.Socio_economico_dinero_ahorro_si == null)
                            {
                                cb_dineroahorrosi.Checked = false;
                            }
                            else
                            {
                                cb_dineroahorrosi.Checked = true;
                            }
                            if (sso.Socio_economico_dinero_ahorro_no == null)
                            {
                                cb_dineroahorrono.Checked = false;
                            }
                            else
                            {
                                cb_dineroahorrono.Checked = true;
                            }
                            //Vehiculo propio
                            if (sso.Socio_economico_vehiculo_propio_si == null)
                            {
                                cb_vehiculosi.Checked = false;
                            }
                            else
                            {
                                cb_vehiculosi.Checked = true;
                            }
                            if (sso.Socio_economico_vehiculo_propio_no == null)
                            {
                                cb_vehiculono.Checked = false;
                            }
                            else
                            {
                                cb_vehiculono.Checked = true;
                            }
                            //Recorrido Institucional
                            if (sso.Socio_economico_recorrido_institucional_si == null)
                            {
                                cb_recorridosi.Checked = false;
                            }
                            else
                            {
                                cb_recorridosi.Checked = true;
                            }
                            if (sso.Socio_economico_recorrido_institucional_no == null)
                            {
                                cb_recorridono.Checked = false;
                            }
                            else
                            {
                                cb_recorridono.Checked = true;
                            }
                            //SALUD
                            //Enfermedad preexistente
                            if (sso.Socio_economico_posee_enfermedad_si == null)
                            {
                                cb_sienfermedad.Checked = false;
                            }
                            else
                            {
                                cb_sienfermedad.Checked = true;
                            }
                            if (sso.Socio_economico_posee_enfermedad_no == null)
                            {
                                cb_noenfermedad.Checked = false;
                            }
                            else
                            {
                                cb_noenfermedad.Checked = true;
                            }
                            //Posee Discapacidad
                            if (sso.Socio_economico_discapacidad_si == null)
                            {
                                cb_discapacidadsi.Checked = false;
                            }
                            else
                            {
                                cb_discapacidadsi.Checked = true;
                            }
                            if (sso.Socio_economico_discapacidad_no == null)
                            {
                                cb_discapacidadno.Checked = false;
                            }
                            else
                            {
                                cb_discapacidadno.Checked = true;
                            }
                            //Gestacion 
                            if (sso.Socio_economico_estado_gestacion_si == null)
                            {
                                cb_gestaciónsi.Checked = false;
                            }
                            else
                            {
                                cb_gestaciónsi.Checked = true;
                            }
                            if (sso.Socio_economico_estado_gestacion_no == null)
                            {
                                cb_gestaciónno.Checked = false;
                            }
                            else
                            {
                                cb_gestaciónno.Checked = true;
                            }
                            //Periodo Lactancia
                            if (sso.Socio_economico_periodo_lactancia_si == null)
                            {
                                cb_lactaciasi.Checked = false;
                            }
                            else
                            {
                                cb_lactaciasi.Checked = true;
                            }
                            if (sso.Socio_economico_periodo_lactancia_no == null)
                            {
                                cb_lactaciano.Checked = false;
                            }
                            else
                            {
                                cb_lactaciano.Checked = true;
                            }
                            //Enfermedad catastrófica
                            if (sso.Socio_economico_enfermedad_cronica_si == null)
                            {
                                cb_catastroficasi.Checked = false;
                            }
                            else
                            {
                                cb_catastroficasi.Checked = true;
                            }
                            if (sso.Socio_economico_enfermedad_cronica_no == null)
                            {
                                cb_catastroficano.Checked = false;
                            }
                            else
                            {
                                cb_catastroficano.Checked = true;
                            }
                            //Enfermedad rara
                            if (sso.Socio_economico_enfermedad_rara_si == null)
                            {
                                cb_enfermedadrarasi.Checked = false;
                            }
                            else
                            {
                                cb_enfermedadrarasi.Checked = true;
                            }
                            if (sso.Socio_economico_enfermedad_rara_no == null)
                            {
                                cb_enfermedadrarano.Checked = false;
                            }
                            else
                            {
                                cb_enfermedadrarano.Checked = true;
                            }
                            //Consumo alcohol
                            if (sso.Socio_economico_consume_alcohol_si == null)
                            {
                                cb_alcoholsi.Checked = false;
                            }
                            else
                            {
                                cb_alcoholsi.Checked = true;
                            }
                            if (sso.Socio_economico_consume_alcohol_no == null)
                            {
                                cb_alcoholno.Checked = false;
                            }
                            else
                            {
                                cb_alcoholno.Checked = true;
                            }
                            //Consumo tabaco
                            if (sso.Socio_economico_consume_tabaco_si == null)
                            {
                                cb_tabacosi.Checked = false;
                            }
                            else
                            {
                                cb_tabacosi.Checked = true;
                            }
                            if (sso.Socio_economico_consume_tabaco_no == null)
                            {
                                cb_tabacono.Checked = false;
                            }
                            else
                            {
                                cb_tabacono.Checked = true;
                            }
                            //Consumo sustancia psicotrópica
                            if (sso.Socio_economico_consume_sustancia_psicotropica_si == null)
                            {
                                cb_sustanciapsicotropicasi.Checked = false;
                            }
                            else
                            {
                                cb_sustanciapsicotropicasi.Checked = true;
                            }
                            if (sso.Socio_economico_consume_sustancia_psicotropica_no == null)
                            {
                                cb_sustanciapsicotropicano.Checked = false;
                            }
                            else
                            {
                                cb_sustanciapsicotropicano.Checked = true;
                            }
                            //Problemas relacionados al consumo
                            if (sso.Socio_economico_problemas_consumo_familiares == null)
                            {
                                cb_familiares.Checked = false;
                            }
                            else
                            {
                                cb_familiares.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_consumo_laborales == null)
                            {
                                cb_laborales.Checked = false;
                            }
                            else
                            {
                                cb_laborales.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_consumo_economicos == null)
                            {
                                cb_economicos.Checked = false;
                            }
                            else
                            {
                                cb_economicos.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_consumo_salud == null)
                            {
                                cb_salud.Checked = false;
                            }
                            else
                            {
                                cb_salud.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_consumo_legales == null)
                            {
                                cb_legales.Checked = false;
                            }
                            else
                            {
                                cb_legales.Checked = true;
                            }

                            //CARACTERISTICA DE LA VIVIENDA
                            //Descripcion
                            if (sso.Socio_economico_caracteristica_vivienda_descripcion_unifamiliar == null)
                            {
                                cb_unifamiliar.Checked = false;
                            }
                            else
                            {
                                cb_unifamiliar.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_descripcion_multifamiliar == null)
                            {
                                cb_multifamiliar.Checked = false;
                            }
                            else
                            {
                                cb_multifamiliar.Checked = true;
                            }
                            //Tenencia
                            if (sso.Socio_economico_caracteristica_vivienda_tenencia_propia_sin_deuda == null)
                            {
                                cb_propiasindeuda.Checked = false;
                            }
                            else
                            {
                                cb_propiasindeuda.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tenencia_arrendada == null)
                            {
                                cb_arrendada.Checked = false;
                            }
                            else
                            {
                                cb_arrendada.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tenencia_de_familia == null)
                            {
                                cb_defamilia.Checked = false;
                            }
                            else
                            {
                                cb_defamilia.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tenencia_hipotecada == null)
                            {
                                cb_hipotecada.Checked = false;
                            }
                            else
                            {
                                cb_hipotecada.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tenencia_prestada == null)
                            {
                                cb_prestada.Checked = false;
                            }
                            else
                            {
                                cb_prestada.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tenencia_anticreces == null)
                            {
                                cb_anticreces.Checked = false;
                            }
                            else
                            {
                                cb_anticreces.Checked = true;
                            }
                            //Tipo
                            if (sso.Socio_economico_caracteristica_vivienda_tipo_casa == null)
                            {
                                cb_tipocasa.Checked = false;
                            }
                            else
                            {
                                cb_tipocasa.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tipo_suit == null)
                            {
                                cb_tiposuit.Checked = false;
                            }
                            else
                            {
                                cb_tiposuit.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tipo_mediagua == null)
                            {
                                cb_tipomediagua.Checked = false;
                            }
                            else
                            {
                                cb_tipomediagua.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tipo_departamento == null)
                            {
                                cb_tipodepartamento.Checked = false;
                            }
                            else
                            {
                                cb_tipodepartamento.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_tipo_pieza == null)
                            {
                                cb_tipopieza.Checked = false;
                            }
                            else
                            {
                                cb_tipopieza.Checked = true;
                            }
                            //Distribucion
                            if (sso.Socio_economico_caracteristica_vivienda_distribucion_habitacion == null)
                            {
                                cb_habitacion.Checked = false;
                            }
                            else
                            {
                                cb_habitacion.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_distribucion_sala == null)
                            {
                                cb_sala.Checked = false;
                            }
                            else
                            {
                                cb_sala.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_distribucion_baño == null)
                            {
                                cb_baño.Checked = false;
                            }
                            else
                            {
                                cb_baño.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_distribucion_garage == null)
                            {
                                cb_garage.Checked = false;
                            }
                            else
                            {
                                cb_garage.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_distribucion_comedor == null)
                            {
                                cb_comedor.Checked = false;
                            }
                            else
                            {
                                cb_comedor.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_distribucion_cocina == null)
                            {
                                cb_cocina.Checked = false;
                            }
                            else
                            {
                                cb_cocina.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_distribucion_patio == null)
                            {
                                cb_patio.Checked = false;
                            }
                            else
                            {
                                cb_patio.Checked = true;
                            }
                            if (sso.Socio_economico_caracteristica_vivienda_distribucion_bodega == null)
                            {
                                cb_bodega.Checked = false;
                            }
                            else
                            {
                                cb_bodega.Checked = true;
                            }

                            //INFORMACION FAMILIAR
                            //Persona discapacidad
                            if (sso.Socio_economico_nucleofamiliar_persona_discapacidad_si == null)
                            {
                                cb_nucleodiscapacidadsi.Checked = false;
                            }
                            else
                            {
                                cb_nucleodiscapacidadsi.Checked = true;
                            }
                            if (sso.Socio_economico_nucleofamiliar_persona_discapacidad_no == null)
                            {
                                cb_nucleodiscapacidadno.Checked = false;
                            }
                            else
                            {
                                cb_nucleodiscapacidadno.Checked = true;
                            }
                            if (sso.Socio_economico_acargo_de_persona_discapacidad_si == null)
                            {
                                cb_acargofamiliardiacapacitadosi.Checked = false;
                            }
                            else
                            {
                                cb_acargofamiliardiacapacitadosi.Checked = true;
                            }
                            if (sso.Socio_economico_acargo_de_persona_discapacidad_no == null)
                            {
                                cb_acargofamiliardiacapacitadono.Checked = false;
                            }
                            else
                            {
                                cb_acargofamiliardiacapacitadono.Checked = true;
                            }
                            //Dependencia ministerio de trabajo
                            if (sso.Socio_economico_registrar_dependencia_familiar_MT_si == null)
                            {
                                cb_dependenciaministeriotrabajosi.Checked = false;
                            }
                            else
                            {
                                cb_dependenciaministeriotrabajosi.Checked = true;
                            }
                            if (sso.Socio_economico_registrar_dependencia_familiar_MT_no == null)
                            {
                                cb_dependenciaministeriotrabajono.Checked = false;
                            }
                            else
                            {
                                cb_dependenciaministeriotrabajono.Checked = true;
                            }
                            //A cargo de persona con enfermedad catastrófica
                            if (sso.Socio_economico_a_cargo_familiar_enfermedad_catastrofica_rara_si == null)
                            {
                                cb_acargofamiliarenfermedadrarasi.Checked = false;
                            }
                            else
                            {
                                cb_acargofamiliarenfermedadrarasi.Checked = true;
                            }
                            if (sso.Socio_economico_a_cargo_familiar_enfermedad_catastrofica_rara_no == null)
                            {
                                cb_acargofamiliarenfermedadrarano.Checked = false;
                            }
                            else
                            {
                                cb_acargofamiliarenfermedadrarano.Checked = true;
                            }

                            //ACTIVIDAD EN TIEMPO LIBRE
                            //Actividad inicial
                            if (sso.Socio_economico_hogar == null)
                            {
                                cb_hogar.Checked = false;
                            }
                            else
                            {
                                cb_hogar.Checked = true;
                            }
                            if (sso.Socio_economico_paseos_familiares == null)
                            {
                                cb_paseosfamiliares.Checked = false;
                            }
                            else
                            {
                                cb_paseosfamiliares.Checked = true;
                            }
                            if (sso.Socio_economico_estudios == null)
                            {
                                cb_estudios.Checked = false;
                            }
                            else
                            {
                                cb_estudios.Checked = true;
                            }
                            if (sso.Socio_economico_actividades_artisticas == null)
                            {
                                cb_actividadesartisticas.Checked = false;
                            }
                            else
                            {
                                cb_actividadesartisticas.Checked = true;
                            }
                            //Actividad economica adicional
                            if (sso.Socio_economico_actividad_economica_adicional_si == null)
                            {
                                cb_actividadeconomicasi.Checked = false;
                            }
                            else
                            {
                                cb_actividadeconomicasi.Checked = true;
                            }
                            if (sso.Socio_economico_actividad_economica_adicional_no == null)
                            {
                                cb_actividadeconomicano.Checked = false;
                            }
                            else
                            {
                                cb_actividadeconomicano.Checked = true;
                            }
                            //Actividad deportiva
                            if (sso.Socio_economico_actividad_deportiva_si == null)
                            {
                                cb_deportesi.Checked = false;
                            }
                            else
                            {
                                cb_deportesi.Checked = true;
                            }
                            if (sso.Socio_economico_actividad_deportiva_no == null)
                            {
                                cb_deporteno.Checked = false;
                            }
                            else
                            {
                                cb_deporteno.Checked = true;
                            }
                            //Lesión
                            if (sso.Socio_economico_lesion_si == null)
                            {
                                cb_lesionsi.Checked = false;
                            }
                            else
                            {
                                cb_lesionsi.Checked = true;
                            }
                            if (sso.Socio_economico_lesion_no == null)
                            {
                                cb_lesionno.Checked = false;
                            }
                            else
                            {
                                cb_lesionno.Checked = true;
                            }
                            //Tratamiento
                            if (sso.Socio_economico_lesion_tratamiento_si == null)
                            {
                                cb_tratamientosi.Checked = false;
                            }
                            else
                            {
                                cb_tratamientosi.Checked = true;
                            }
                            if (sso.Socio_economico_lesion_tratamiento_no == null)
                            {
                                cb_tratamientono.Checked = false;
                            }
                            else
                            {
                                cb_tratamientono.Checked = true;
                            }

                            //INFORMACION BIENESTAR FAMILIAR
                            //Tipo familia
                            if (sso.Socio_economico_tipo_familia_nuclear == null)
                            {
                                cb_nuclear.Checked = false;
                            }
                            else
                            {
                                cb_nuclear.Checked = true;
                            }
                            if (sso.Socio_economico_tipo_familia_ampliada == null)
                            {
                                cb_ampliada.Checked = false;
                            }
                            else
                            {
                                cb_ampliada.Checked = true;
                            }
                            if (sso.Socio_economico_tipo_familia_monoparental == null)
                            {
                                cb_monoparental.Checked = false;
                            }
                            else
                            {
                                cb_monoparental.Checked = true;
                            }
                            if (sso.Socio_economico_tipo_familia_vive_solo == null)
                            {
                                cb_vivesolo.Checked = false;
                            }
                            else
                            {
                                cb_vivesolo.Checked = true;
                            }
                            if (sso.Socio_economico_tipo_familia_vive_amigos == null)
                            {
                                cb_viveconamigos.Checked = false;
                            }
                            else
                            {
                                cb_viveconamigos.Checked = true;
                            }
                            if (sso.Socio_economico_tipo_familia_sin_hijos == null)
                            {
                                cb_familiasinhijos.Checked = false;
                            }
                            else
                            {
                                cb_familiasinhijos.Checked = true;
                            }
                            //Relacion familiar
                            if (sso.Socio_economico_evaluacion_relacion_familiar_muybueno == null)
                            {
                                cb_relacionfamiliarmuybuena.Checked = false;
                            }
                            else
                            {
                                cb_relacionfamiliarmuybuena.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_familiar_bueno == null)
                            {
                                cb_relacionfamiliarbuena.Checked = false;
                            }
                            else
                            {
                                cb_relacionfamiliarbuena.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_familiar_regular == null)
                            {
                                cb_relacionfamiliarregular.Checked = false;
                            }
                            else
                            {
                                cb_relacionfamiliarregular.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_familiar_mala == null)
                            {
                                cb_relacionfamiliarmala.Checked = false;
                            }
                            else
                            {
                                cb_relacionfamiliarmala.Checked = true;
                            }
                            //Relacion pareja
                            if (sso.Socio_economico_evaluacion_relacion_pareja_muybueno == null)
                            {
                                cb_relacionparejamuybuena.Checked = false;
                            }
                            else
                            {
                                cb_relacionparejamuybuena.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_pareja_bueno == null)
                            {
                                cb_relacionparejabuena.Checked = false;
                            }
                            else
                            {
                                cb_relacionparejabuena.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_pareja_regular == null)
                            {
                                cb_relacionparejaregular.Checked = false;
                            }
                            else
                            {
                                cb_relacionparejaregular.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_pareja_mala == null)
                            {
                                cb_relacionparejamala.Checked = false;
                            }
                            else
                            {
                                cb_relacionparejamala.Checked = true;
                            }
                            //Relacion con hijos
                            if (sso.Socio_economico_evaluacion_relacion_hijos_muybueno == null)
                            {
                                cb_relacionconhijosmuybuena.Checked = false;
                            }
                            else
                            {
                                cb_relacionconhijosmuybuena.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_hijos_bueno == null)
                            {
                                cb_relacionconhijosbuena.Checked = false;
                            }
                            else
                            {
                                cb_relacionconhijosbuena.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_hijos_regular == null)
                            {
                                cb_relacionconhijosregular.Checked = false;
                            }
                            else
                            {
                                cb_relacionconhijosregular.Checked = true;
                            }
                            if (sso.Socio_economico_evaluacion_relacion_hijos_mala == null)
                            {
                                cb_relacionconhijosmala.Checked = false;
                            }
                            else
                            {
                                cb_relacionconhijosmala.Checked = true;
                            }
                            //Problemas familiares
                            if (sso.Socio_economico_problemas_familiares_economicos == null)
                            {
                                cb_economico.Checked = false;
                            }
                            else
                            {
                                cb_economico.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_familiares_comunicacion == null)
                            {
                                cb_comunicacion.Checked = false;
                            }
                            else
                            {
                                cb_comunicacion.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_familiares_conyugales == null)
                            {
                                cb_conyugales.Checked = false;
                            }
                            else
                            {
                                cb_conyugales.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_familiares_crianza_hijos == null)
                            {
                                cb_crianzadehijos.Checked = false;
                            }
                            else
                            {
                                cb_crianzadehijos.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_familiares_adicciones == null)
                            {
                                cb_adicciones.Checked = false;
                            }
                            else
                            {
                                cb_adicciones.Checked = true;
                            }
                            //Violencia
                            if (sso.Socio_economico_problemas_familiares_violencia_fisica == null)
                            {
                                cb_fisica.Checked = false;
                            }
                            else
                            {
                                cb_fisica.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_familiares_violencia_psicologica == null)
                            {
                                cb_psicologica.Checked = false;
                            }
                            else
                            {
                                cb_psicologica.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_familiares_violencia_verbal == null)
                            {
                                cb_verbal.Checked = false;
                            }
                            else
                            {
                                cb_verbal.Checked = true;
                            }
                            if (sso.Socio_economico_problemas_familiares_violencia_sexual == null)
                            {
                                cb_sexual.Checked = false;
                            }
                            else
                            {
                                cb_sexual.Checked = true;
                            }
                            //Rol
                            if (sso.Socio_economico_miembro_familiar_rol_si == null)
                            {
                                cb_rolfamiliarsi.Checked = false;
                            }
                            else
                            {
                                cb_rolfamiliarsi.Checked = true;
                            }
                            if (sso.Socio_economico_miembro_familiar_rol_no == null)
                            {
                                cb_rolfamiliarno.Checked = false;
                            }
                            else
                            {
                                cb_rolfamiliarno.Checked = true;
                            }
                            //Nivel de salud de la familia
                            if (sso.Socio_economico_nivel_salud_familia_muybueno == null)
                            {
                                cb_nivelsaludfamiliarmuybuena.Checked = false;
                            }
                            else
                            {
                                cb_nivelsaludfamiliarmuybuena.Checked = true;
                            }
                            if (sso.Socio_economico_nivel_salud_familia_bueno == null)
                            {
                                cb_nivelsaludfamiliarbuena.Checked = false;
                            }
                            else
                            {
                                cb_nivelsaludfamiliarbuena.Checked = true;
                            }
                            if (sso.Socio_economico_nivel_salud_familia_regular == null)
                            {
                                cb_nivelsaludfamiliarregular.Checked = false;
                            }
                            else
                            {
                                cb_nivelsaludfamiliarregular.Checked = true;
                            }
                            if (sso.Socio_economico_nivel_salud_familia_mala == null)
                            {
                                cb_nivelsaludfamiliarmala.Checked = false;
                            }
                            else
                            {
                                cb_nivelsaludfamiliarmala.Checked = true;
                            }
                            //La familia es
                            if (sso.Socio_economico_familia_funcional == null)
                            {
                                cb_funcional.Checked = false;
                            }
                            else
                            {
                                cb_funcional.Checked = true;
                            }
                            if (sso.Socio_economico_familia_disfuncional == null)
                            {
                                cb_disfuncional.Checked = false;
                            }
                            else
                            {
                                cb_disfuncional.Checked = true;
                            }
                            //Certifico
                            if (sso.Socio_economico_informacion_general_real_si == null)
                            {
                                cb_certificosi.Checked = false;
                            }
                            else
                            {
                                cb_certificosi.Checked = true;
                            }
                            if (sso.Socio_economico_informacion_general_real_no == null)
                            {
                                cb_certificono.Checked = false;
                            }
                            else
                            {
                                cb_certificono.Checked = true;
                            }  
                        }
                    }

                }
                txt_fecharegistro.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Timer1.Enabled = false;

                //string previewImageSrc = (string)localStorage.getItem('previewImageSrc');
                //if (!string.IsNullOrEmpty(previewImageSrc))
                //{
                //    imgPreview.Src = previewImageSrc;
                //    imgPreview.Style.Add("display", "block");
                //}

            }



        }

        //protected void timerFechaHora_Tick(object sender, EventArgs e)
        //{
        //    this.txt_fecharegistro.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd");
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

            txt_edad.Text = año + " AÑOS, " + mes + " MESES, " + dia + " DIAS";
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Pacientes/Inicio.aspx");
        }





        //protected void FileUploadImageGeo_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (FileUploadImageGeo.FileContent != null)
        //        {
        //            //Obtener datos de la iagen
        //            int tamanio = FileUploadImageGeo.PostedFile.ContentLength;
        //            byte[] ImagenOriginal = new byte[tamanio];
        //            FileUploadImageGeo.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
        //            System.Drawing.Bitmap ImagenOriginalBinaria = new System.Drawing.Bitmap(FileUploadImageGeo.PostedFile.InputStream);

        //            string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
        //            Image1.ImageUrl = ImagenDataURL64;
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Por favor, cargue su imagen')", true);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Por favor, cargue su imagen')", true);
        //    }
        //}

        //protected void btn_mostrarimagen_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Obtener datos de la iagen
        //        int tamanio = FileUploadImageGeo.PostedFile.ContentLength;
        //        byte[] ImagenOriginal = new byte[tamanio];
        //        FileUploadImageGeo.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
        //        System.Drawing.Bitmap ImagenOriginalBinaria = new System.Drawing.Bitmap(FileUploadImageGeo.PostedFile.InputStream);

        //        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
        //        Image1.ImageUrl = ImagenDataURL64;
        //    }
        //    catch (Exception)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Por favor, cargue su imagen')", true);
        //    }
        //}

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            HtmlNode.ElementsFlags["img"] = HtmlElementFlag.Closed;
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Closed;
            Document pdfDoc = new Document(PageSize.A4, 20F, 20F, 20F, 20F);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            BaseFont fuente = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, true);
            Font titulo = new Font(fuente, 8f, Font.BOLD, new BaseColor(0, 0, 0));
            BaseFont fuente2 = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, true);
            Font certificacion = new Font(fuente2, 8f, Font.BOLD, new BaseColor(0, 0, 0));
            BaseFont fuente3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font cuadro = new Font(fuente3, 8f, Font.NORMAL, new BaseColor(0, 0, 0));
            BaseFont fuente4 = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, true);
            Font informacion = new Font(fuente4, 8f, Font.NORMAL, new BaseColor(0, 0, 0));

            pdfDoc.Open();

            //IMAGEN ENCABEZADO
            string imageURL = Server.MapPath("../../resources/images") + "/ic1.png";
            iTextSharp.text.Image fotologo = iTextSharp.text.Image.GetInstance(imageURL);
            fotologo.ScalePercent(40f);

            //ENCABEZADO
            var tblEncabezado = new PdfPTable(new float[] { 150f, 125f, 125f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            var c1 = new PdfPCell(fotologo) { HorizontalAlignment = Element.ALIGN_CENTER, Rowspan = 5, Padding = 2 };
            var c2 = new PdfPCell(new Phrase("GESTION DEL TALENTO HUMANO", titulo)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Colspan = 2, Padding = 3 };
            c1.Border = 0;
            tblEncabezado.AddCell(c1);
            tblEncabezado.AddCell(c2);
            c2.Phrase = new Phrase("GESTION DE BIENESTAR LABORAL Y SALUD OCUPACIONAL", titulo);
            tblEncabezado.AddCell(c2);
            c2.Phrase = new Phrase("FICHA SOCIOECONOMICA", titulo);
            tblEncabezado.AddCell(c2);
            var c3 = new PdfPCell(new Phrase("CODIGO", titulo)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 };
            var c4 = new PdfPCell(new Phrase("VERSION", titulo)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 };
            tblEncabezado.AddCell(c3);
            tblEncabezado.AddCell(c4);
            c3.Phrase = new Phrase("GTH_FOR_21", cuadro);
            c4.Phrase = new Phrase("2", cuadro);
            tblEncabezado.AddCell(c3);
            tblEncabezado.AddCell(c4);
            pdfDoc.Add(tblEncabezado);

            //FECHA DE REGISTRO
            pdfDoc.Add(new Paragraph(" "));
            var tblfechaInicio = new PdfPTable(new float[] { 325f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblfechaInicio.AddCell(new PdfPCell(new Paragraph("FECHA DE REGISTRO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 3 });
            tblfechaInicio.AddCell(new PdfPCell(new Paragraph(txt_fecharegistro.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblfechaInicio);
            pdfDoc.Add(new Paragraph(" "));

            //I.DATOS PERSONALES DEL SERVIDOR/ A
            var tbldatospersonales = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldatospersonales.AddCell(new PdfPCell(new Paragraph("I. DATOS PERSONALES DEL SERVIDOR/A", titulo)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
            pdfDoc.Add(tbldatospersonales);
            pdfDoc.Add(new Paragraph(" "));
            var tbldpTitulo = new PdfPTable(new float[] { 100f, 50f, 50f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldpTitulo.AddCell(new PdfPCell(new Paragraph("NOMBRES Y APELLIDOS:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldpTitulo.AddCell(new PdfPCell(new Paragraph(txt_prinombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldpTitulo.AddCell(new PdfPCell(new Paragraph(txt_segnombre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldpTitulo.AddCell(new PdfPCell(new Paragraph(txt_priapellido.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldpTitulo.AddCell(new PdfPCell(new Paragraph(txt_segapellido.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldpTitulo.AddCell(new PdfPCell(new Paragraph("CEDULA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldpTitulo.AddCell(new PdfPCell(new Paragraph(txt_cedula.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tbldpTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tbldaTitulo = new PdfPTable(new float[] { 100f, 200f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldaTitulo.AddCell(new PdfPCell(new Paragraph("AREA A LA QUE PERTENECE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldaTitulo.AddCell(new PdfPCell(new Paragraph(txt_areatrabajo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tbldaTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblciTitulo = new PdfPTable(new float[] { 100f, 250f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblciTitulo.AddCell(new PdfPCell(new Paragraph("CARGO INSTITUCIONAL:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblciTitulo.AddCell(new PdfPCell(new Paragraph(txt_cargoinstitucional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblciTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblmvTitulo = new PdfPTable(new float[] { 70f, 70f, 6f, 60f, 6f, 60f, 35f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmvTitulo.AddCell(new PdfPCell(new Paragraph("MODALIDAD DE VINCULACION:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblmvTitulo.AddCell(new PdfPCell(new Paragraph("LEY ORGANICA DEL SECTOR PUBLICO (LOSEP)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_modalidadvinculacionlosep.Checked == true)
            {
                tblmvTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblmvTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblmvTitulo.AddCell(new PdfPCell(new Paragraph("CODIGO DE TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_modalidadvinculacioncodigotrabajo.Checked == true)
            {
                tblmvTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblmvTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblmvTitulo.AddCell(new PdfPCell(new Paragraph("FECHA DE INGRESO AL ECU:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblmvTitulo.AddCell(new PdfPCell(new Paragraph(txt_fechaingresoalsisecu.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblmvTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblecTitulo = new PdfPTable(new float[] { 40f, 40f, 6f, 40f, 6f, 40f, 6f, 40f, 6f, 40f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblecTitulo.AddCell(new PdfPCell(new Paragraph("ESTADO CIVIL:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblecTitulo.AddCell(new PdfPCell(new Paragraph("SOLTERO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_soltero.Checked == true)
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblecTitulo.AddCell(new PdfPCell(new Paragraph("CASADO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_casado.Checked == true)
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblecTitulo.AddCell(new PdfPCell(new Paragraph("VIUDO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_viudo.Checked == true)
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblecTitulo.AddCell(new PdfPCell(new Paragraph("UNION LIBRE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_unionlibre.Checked == true)
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblecTitulo.AddCell(new PdfPCell(new Paragraph("DIVORCIADO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_divorciado.Checked == true)
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblecTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblecTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblgTitulo = new PdfPTable(new float[] { 30f, 30f, 6f, 30f, 6f, 40f, 10f, 30f, 10f, 6f, 10f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblgTitulo.AddCell(new PdfPCell(new Paragraph("GENERO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblgTitulo.AddCell(new PdfPCell(new Paragraph("MASCULINO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_genmasculino.Checked == true)
            {
                tblgTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblgTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblgTitulo.AddCell(new PdfPCell(new Paragraph("FEMENINO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_genfemenino.Checked == true)
            {
                tblgTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblgTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblgTitulo.AddCell(new PdfPCell(new Paragraph("TIPO DE SANGRE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblgTitulo.AddCell(new PdfPCell(new Paragraph(txt_tipodesangre.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblgTitulo.AddCell(new PdfPCell(new Paragraph("¿ES DONANTE?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblgTitulo.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_donantesi.Checked == true)
            {
                tblgTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblgTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblgTitulo.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_donanteno.Checked == true)
            {
                tblgTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblgTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblgTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tbltelfTitulo = new PdfPTable(new float[] { 150f, 75f, 100f, 75f, 50f, 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbltelfTitulo.AddCell(new PdfPCell(new Paragraph("TELEFONO CONVENCIONAL:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbltelfTitulo.AddCell(new PdfPCell(new Paragraph(txt_telconvecional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbltelfTitulo.AddCell(new PdfPCell(new Paragraph("TELEFONO CELULAR:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbltelfTitulo.AddCell(new PdfPCell(new Paragraph(txt_telcelular.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbltelfTitulo.AddCell(new PdfPCell(new Paragraph("EMAIL:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbltelfTitulo.AddCell(new PdfPCell(new Paragraph(txt_email.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tbltelfTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tbllnTitulo = new PdfPTable(new float[] { 150f, 100f, 150f, 100f, 50, 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbllnTitulo.AddCell(new PdfPCell(new Paragraph("LUGAR DE NACIMIENTO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbllnTitulo.AddCell(new PdfPCell(new Paragraph(txt_lugarnacimiento.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbllnTitulo.AddCell(new PdfPCell(new Paragraph("FECHA DE NACIMIENTO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbllnTitulo.AddCell(new PdfPCell(new Paragraph(txt_fechanacimiento.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbllnTitulo.AddCell(new PdfPCell(new Paragraph("EDAD:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbllnTitulo.AddCell(new PdfPCell(new Paragraph(txt_edad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tbllnTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblneTitulo = new PdfPTable(new float[] { 40f, 30f, 6f, 30f, 6f, 25f, 6f, 40f, 6f, 30f, 6f, 25f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblneTitulo.AddCell(new PdfPCell(new Paragraph("NIVEL DE EDUCACION:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblneTitulo.AddCell(new PdfPCell(new Paragraph("PRIMARIA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_primaria.Checked == true)
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblneTitulo.AddCell(new PdfPCell(new Paragraph("SECUNDARIA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_secundaria.Checked == true)
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblneTitulo.AddCell(new PdfPCell(new Paragraph("SUPERIOR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_superior.Checked == true)
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblneTitulo.AddCell(new PdfPCell(new Paragraph("ESPECIALIZACION", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_especializacion.Checked == true)
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblneTitulo.AddCell(new PdfPCell(new Paragraph("DIPLOMADO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_diplomado.Checked == true)
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblneTitulo.AddCell(new PdfPCell(new Paragraph("MAESTRIA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_maestria.Checked == true)
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblneTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblneTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblaiTitulo = new PdfPTable(new float[] { 45f, 30f, 6f, 30f, 6f, 50f, 6f, 30f, 6f, 30f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblaiTitulo.AddCell(new PdfPCell(new Paragraph("AUTOIDENTIFICACION ETNICA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblaiTitulo.AddCell(new PdfPCell(new Paragraph("BLANCO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_blanco.Checked == true)
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblaiTitulo.AddCell(new PdfPCell(new Paragraph("MESTIZO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_mestizo.Checked == true)
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblaiTitulo.AddCell(new PdfPCell(new Paragraph("AFRODESCENDIENTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_afro.Checked == true)
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblaiTitulo.AddCell(new PdfPCell(new Paragraph("INDIGENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_indigena.Checked == true)
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblaiTitulo.AddCell(new PdfPCell(new Paragraph("MONTUBIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_montubio.Checked == true)
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblaiTitulo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblaiTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblddTitulo = new PdfPTable(new float[] { 150f, 100f, 100f, 75f, 100f, 100f, 100f, 75f, 125f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblddTitulo.AddCell(new PdfPCell(new Paragraph("DIRECCION DEL DOMICILIO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblddTitulo.AddCell(new PdfPCell(new Paragraph("PROVINCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblddTitulo.AddCell(new PdfPCell(new Paragraph(txt_provincia.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblddTitulo.AddCell(new PdfPCell(new Paragraph("CANTON:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblddTitulo.AddCell(new PdfPCell(new Paragraph(txt_canton.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblddTitulo.AddCell(new PdfPCell(new Paragraph("PARROQUIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblddTitulo.AddCell(new PdfPCell(new Paragraph(txt_parroquia.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblddTitulo.AddCell(new PdfPCell(new Paragraph("BARRIO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblddTitulo.AddCell(new PdfPCell(new Paragraph(txt_barrio.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblddTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblccTitulo = new PdfPTable(new float[] { 150f, 150f, 50f, 75f, 150f, 150f, 100f, 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblccTitulo.AddCell(new PdfPCell(new Paragraph("CALLE PRINCIPAL:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblccTitulo.AddCell(new PdfPCell(new Paragraph(txt_calleprincipal.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblccTitulo.AddCell(new PdfPCell(new Paragraph("N:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblccTitulo.AddCell(new PdfPCell(new Paragraph(txt_mumerodecasa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblccTitulo.AddCell(new PdfPCell(new Paragraph("CALLE SECUNDARIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblccTitulo.AddCell(new PdfPCell(new Paragraph(txt_callesecundaria.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblccTitulo.AddCell(new PdfPCell(new Paragraph("REFERENCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblccTitulo.AddCell(new PdfPCell(new Paragraph(txt_refubicardomicilio.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblccTitulo);
            pdfDoc.Add(new Paragraph(" "));
            var tblSectorVive = new PdfPTable(new float[] { 100f, 30f, 6f, 30f, 6f, 30f, 6f, 30f, 6f, 60f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblSectorVive.AddCell(new PdfPCell(new Paragraph("SECTOR DONDE VIVE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblSectorVive.AddCell(new PdfPCell(new Paragraph("NORTE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_norte.Checked == true)
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSectorVive.AddCell(new PdfPCell(new Paragraph("CENTRO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_centro.Checked == true)
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSectorVive.AddCell(new PdfPCell(new Paragraph("SUR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_sur.Checked == true)
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSectorVive.AddCell(new PdfPCell(new Paragraph("VALLE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_valle.Checked == true)
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSectorVive.AddCell(new PdfPCell(new Paragraph("VALLE DE LOS CHILLOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_valledeloschillos.Checked == true)
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSectorVive.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblSectorVive);
            pdfDoc.Add(new Paragraph(" "));
            var tblTipoVivienda = new PdfPTable(new float[] { 40f, 30f, 6f, 50f, 6f, 30f, 30f, 50f, 30f, 6f, 30f, 6f, 30f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("TIPO DE VIVIENDA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("CASA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_casa.Checked == true)
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("DEPARTAMENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_departamento.Checked == true)
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("OTRO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph(txt_tipoviviendaotro.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("RIESGO DELINCUENCIAL:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("ALTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_riesgoalto.Checked == true)
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("MEDIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_riesgomedio.Checked == true)
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("BAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_riesgobajo.Checked == true)
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoVivienda.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblTipoVivienda);
            pdfDoc.Add(new Paragraph(" "));
            var tblContacEmergencia = new PdfPTable(new float[] { 100f, 75f, 100f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblContacEmergencia.AddCell(new PdfPCell(new Paragraph("CONTACTO DE EMERGENCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblContacEmergencia.AddCell(new PdfPCell(new Paragraph("NOMBRE Y APELLIDO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblContacEmergencia.AddCell(new PdfPCell(new Paragraph(txt_emernomyape.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblContacEmergencia.AddCell(new PdfPCell(new Paragraph("PARENTESCO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblContacEmergencia.AddCell(new PdfPCell(new Paragraph(txt_emeparentesco.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblContacEmergencia.AddCell(new PdfPCell(new Paragraph("TELF:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblContacEmergencia.AddCell(new PdfPCell(new Paragraph(txt_emetelefono.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblContacEmergencia);
            pdfDoc.Add(new Paragraph(" "));
            var tblDatosEmergencia = new PdfPTable(new float[] { 150f, 150f, 150f, 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatosEmergencia.AddCell(new PdfPCell(new Paragraph("CALLE PRINCIPAL:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosEmergencia.AddCell(new PdfPCell(new Paragraph(txt_emecalleprincipal.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosEmergencia.AddCell(new PdfPCell(new Paragraph("Nº DEL DOMICILIO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosEmergencia.AddCell(new PdfPCell(new Paragraph(txt_emenumdomicilio.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblDatosEmergencia);
            pdfDoc.Add(new Paragraph(" "));
            var tblDatoEmergencia = new PdfPTable(new float[] { 150f, 150f, 150f, 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatoEmergencia.AddCell(new PdfPCell(new Paragraph("CALLE SECUNDARIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatoEmergencia.AddCell(new PdfPCell(new Paragraph(txt_emecallesecun.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatoEmergencia.AddCell(new PdfPCell(new Paragraph("REFERENCIA DEL DOMICILIO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatoEmergencia.AddCell(new PdfPCell(new Paragraph(txt_emerefubicardomicilio.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblDatoEmergencia);
            pdfDoc.Add(new Paragraph(" "));

            //II. SITUACIÓN MÉDICA Y DE SALUD DEL SERVIDOR/A
            var tbldatosmedicos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldatosmedicos.AddCell(new PdfPCell(new Paragraph("II. SITUACIÓN MÉDICA Y DE SALUD DEL SERVIDOR/A", titulo)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
            pdfDoc.Add(tbldatosmedicos);
            pdfDoc.Add(new Paragraph(" "));
            var tblenferprexistente = new PdfPTable(new float[] { 100f, 10f, 6f, 10f, 6f, 25f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblenferprexistente.AddCell(new PdfPCell(new Paragraph("¿POSEE ALGUNA ENFERMEDAD PRE-EXISTENTE?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblenferprexistente.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_sienfermedad.Checked == true)
            {
                tblenferprexistente.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblenferprexistente.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblenferprexistente.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_noenfermedad.Checked == true)
            {
                tblenferprexistente.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblenferprexistente.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblenferprexistente.AddCell(new PdfPCell(new Paragraph("INDIQUE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblenferprexistente.AddCell(new PdfPCell(new Paragraph(txt_poseeenfermedadprexistente.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblenferprexistente);
            pdfDoc.Add(new Paragraph(" "));
            var tbldiscapacidad = new PdfPTable(new float[] { 75f, 10f, 6f, 10f, 6f, 75f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldiscapacidad.AddCell(new PdfPCell(new Paragraph("¿POSEE ALGUNA DISCAPACIDAD?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldiscapacidad.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_discapacidadsi.Checked == true)
            {
                tbldiscapacidad.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tbldiscapacidad.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tbldiscapacidad.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_discapacidadno.Checked == true)
            {
                tbldiscapacidad.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tbldiscapacidad.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tbldiscapacidad.AddCell(new PdfPCell(new Paragraph("TIPO DE DISCAPACIDAD:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldiscapacidad.AddCell(new PdfPCell(new Paragraph(txt_tipodiscapacidad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tbldiscapacidad);
            pdfDoc.Add(new Paragraph(" "));
            var tblDatosDiscapacidad = new PdfPTable(new float[] { 125f, 50f, 175f, 75f, 175, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatosDiscapacidad.AddCell(new PdfPCell(new Paragraph("PORCENTAJE DE DISCAPACIDAD:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosDiscapacidad.AddCell(new PdfPCell(new Paragraph(txt_porcentajediscapacidad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosDiscapacidad.AddCell(new PdfPCell(new Paragraph("Nº DE CARNET OTORGADO POR MSP o CONADIS:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosDiscapacidad.AddCell(new PdfPCell(new Paragraph(txt_numcarnetconadis.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosDiscapacidad.AddCell(new PdfPCell(new Paragraph("FECHA CADUCIDAD DEL CARNET:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosDiscapacidad.AddCell(new PdfPCell(new Paragraph(txt_fechacaducidadcarnet.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblDatosDiscapacidad);
            pdfDoc.Add(new Paragraph(" "));
            var tblGestacion = new PdfPTable(new float[] { 100f, 10f, 6f, 15f, 6f, 50f, 50f, 75f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblGestacion.AddCell(new PdfPCell(new Paragraph("¿SE ENCUENTRA EN ESTADO DE GESTACION? (ADJUNTAR CERTIFICADO MEDICO)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblGestacion.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_gestaciónsi.Checked == true)
            {
                tblGestacion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblGestacion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblGestacion.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_gestaciónno.Checked == true)
            {
                tblGestacion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblGestacion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblGestacion.AddCell(new PdfPCell(new Paragraph("TIEMPO DE GESTACION:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblGestacion.AddCell(new PdfPCell(new Paragraph(txt_gestacióntiempo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblGestacion.AddCell(new PdfPCell(new Paragraph("FECHA TENTATIVA DE PARTO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblGestacion.AddCell(new PdfPCell(new Paragraph(txt_fechatentativaparto.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblGestacion);
            pdfDoc.Add(new Paragraph(" "));
            var tblLactancia = new PdfPTable(new float[] { 100f, 10f, 6f, 10f, 6f, 125f, 40f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblLactancia.AddCell(new PdfPCell(new Paragraph("¿SE ENCUENTRA EN PERIODO DE LACTANCIA?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblLactancia.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_lactaciasi.Checked == true)
            {
                tblLactancia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblLactancia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblLactancia.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_lactaciano.Checked == true)
            {
                tblLactancia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblLactancia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblLactancia.AddCell(new PdfPCell(new Paragraph("FECHA DE CULMINACION DE PERIODO DE LACTANCIA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblLactancia.AddCell(new PdfPCell(new Paragraph(txt_fechaculmicacionlactancia.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblLactancia);
            pdfDoc.Add(new Paragraph(" "));
            var tblCatastrofica = new PdfPTable(new float[] { 150f, 10f, 6f, 10f, 6f, 50f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblCatastrofica.AddCell(new PdfPCell(new Paragraph("¿POSEE ALGUNA ENFERMEDAD CRONICA Y/O CATASTROFICA? (ADJUNTAR CERTIFICADO MEDICO)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblCatastrofica.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_catastroficasi.Checked == true)
            {
                tblCatastrofica.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblCatastrofica.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblCatastrofica.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_catastroficano.Checked == true)
            {
                tblCatastrofica.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblCatastrofica.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblCatastrofica.AddCell(new PdfPCell(new Paragraph("NOMBRE DE LA ENFERMEDAD:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblCatastrofica.AddCell(new PdfPCell(new Paragraph(txt_cualcatastrofica.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblCatastrofica);
            pdfDoc.Add(new Paragraph(" "));
            var tblHuerfana = new PdfPTable(new float[] { 150f, 10f, 6f, 10f, 6f, 50f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblHuerfana.AddCell(new PdfPCell(new Paragraph("¿POSEE ALGUNA ENFERMEDAD RARA O HUERFANA, SEGUN EL ENTE RECTOR QUE LO DETERMINE? (ADJUNTAR CERTIFICADO MEDICO)", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblHuerfana.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_enfermedadrarasi.Checked == true)
            {
                tblHuerfana.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblHuerfana.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblHuerfana.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_enfermedadrarano.Checked == true)
            {
                tblHuerfana.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblHuerfana.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblHuerfana.AddCell(new PdfPCell(new Paragraph("NOMBRE DE LA ENFERMEDAD:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblHuerfana.AddCell(new PdfPCell(new Paragraph(txt_enfermedadraracual.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblHuerfana);
            pdfDoc.Add(new Paragraph(" "));
            var tblAlcohol = new PdfPTable(new float[] { 40f, 10f, 6f, 10f, 6f, 40f, 75f, 75f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblAlcohol.AddCell(new PdfPCell(new Paragraph("¿CONSUME ALCOHOL?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblAlcohol.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_alcoholsi.Checked == true)
            {
                tblAlcohol.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblAlcohol.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblAlcohol.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_alcoholno.Checked == true)
            {
                tblAlcohol.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblAlcohol.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblAlcohol.AddCell(new PdfPCell(new Paragraph("FRECUENCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblAlcohol.AddCell(new PdfPCell(new Paragraph(txt_causaconsumoalcohol.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblAlcohol.AddCell(new PdfPCell(new Paragraph("¿HACE CUANTO TIEMPO CONSUME?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblAlcohol.AddCell(new PdfPCell(new Paragraph(txt_tiempoconsumoalcohol.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblAlcohol);
            pdfDoc.Add(new Paragraph(" "));
            var tblTabaco = new PdfPTable(new float[] { 40f, 10f, 6f, 10f, 6f, 40f, 75f, 75f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTabaco.AddCell(new PdfPCell(new Paragraph("¿CONSUME TABACO?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTabaco.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tabacosi.Checked == true)
            {
                tblTabaco.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTabaco.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTabaco.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tabacono.Checked == true)
            {
                tblTabaco.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTabaco.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTabaco.AddCell(new PdfPCell(new Paragraph("FRECUENCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTabaco.AddCell(new PdfPCell(new Paragraph(txt_frecuenciaconsumotabaco.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTabaco.AddCell(new PdfPCell(new Paragraph("¿HACE CUANTO TIEMPO CONSUME?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTabaco.AddCell(new PdfPCell(new Paragraph(txt_tiempoconsumotabaco.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblTabaco);
            pdfDoc.Add(new Paragraph(" "));
            var tblSustancia = new PdfPTable(new float[] { 65f, 10f, 6f, 10f, 6f, 40f, 50f, 50f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblSustancia.AddCell(new PdfPCell(new Paragraph("¿CONSUME ALGUNA SUSTANCIA PSICOTROPICA?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblSustancia.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_sustanciapsicotropicasi.Checked == true)
            {
                tblSustancia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSustancia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSustancia.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_sustanciapsicotropicano.Checked == true)
            {
                tblSustancia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSustancia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSustancia.AddCell(new PdfPCell(new Paragraph("TIPO DE SUSTANCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblSustancia.AddCell(new PdfPCell(new Paragraph(txt_sustanciapsicotropicatipo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblSustancia.AddCell(new PdfPCell(new Paragraph("FRECUENCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblSustancia.AddCell(new PdfPCell(new Paragraph(txt_sustanciapsicotropicafrecuencia.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblSustancia);
            pdfDoc.Add(new Paragraph(" "));
            var tblproblemas = new PdfPTable(new float[] { 100f, 40f, 6f, 40f, 6f, 40f, 6f, 40f, 6f, 40f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblproblemas.AddCell(new PdfPCell(new Paragraph("PROBLEMAS RELACIONADOS CON EL CONSUMO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblproblemas.AddCell(new PdfPCell(new Paragraph("FAMILIARES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_familiares.Checked == true)
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblproblemas.AddCell(new PdfPCell(new Paragraph("LABORALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_familiares.Checked == true)
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblproblemas.AddCell(new PdfPCell(new Paragraph("ECONOMICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_economicos.Checked == true)
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblproblemas.AddCell(new PdfPCell(new Paragraph("SALUD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_salud.Checked == true)
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblproblemas.AddCell(new PdfPCell(new Paragraph("LEGAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_legales.Checked == true)
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblproblemas.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblproblemas);
            pdfDoc.Add(new Paragraph(" "));

            //III. SITUACIÓN ECONÓMICA DEL SERVIDOR/A
            var tbldatoseconomicos = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldatoseconomicos.AddCell(new PdfPCell(new Paragraph("III. SITUACIÓN ECONÓMICA DEL SERVIDOR/A", titulo)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
            pdfDoc.Add(tbldatoseconomicos);
            pdfDoc.Add(new Paragraph(" "));
            var tblmiembrosactivos = new PdfPTable(new float[] { 200f, 100f, 150f, 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmiembrosactivos.AddCell(new PdfPCell(new Paragraph("NUMERO DE MIEMBROS ECONOMICAMENTE ACTIVOS CON LOS QUE VIVE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblmiembrosactivos.AddCell(new PdfPCell(new Paragraph(txt_miembroactivoseconomicamente.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblmiembrosactivos.AddCell(new PdfPCell(new Paragraph("SITUACION LABOAL DEL CONYUGE:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblmiembrosactivos.AddCell(new PdfPCell(new Paragraph(txt_situacionlaboralconyugue.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblmiembrosactivos);
            pdfDoc.Add(new Paragraph(" "));
            var tblencabezadodatos = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblencabezadodatos.AddCell(new PdfPCell(new Paragraph("TOTAL DE INGRESOS MENSUALES PROYECTADOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblencabezadodatos.AddCell(new PdfPCell(new Paragraph("AYUDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblencabezadodatos.AddCell(new PdfPCell(new Paragraph("OTROS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblencabezadodatos.AddCell(new PdfPCell(new Paragraph("TOTAL EGRESOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3, Colspan = 2 });
            tblencabezadodatos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblencabezadodatos);
            var tblvalores1 = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvalores1.AddCell(new PdfPCell(new Paragraph(txt_totalingresos1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores1.AddCell(new PdfPCell(new Paragraph(txt_ayuda1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores1.AddCell(new PdfPCell(new Paragraph(txt_otros1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores1.AddCell(new PdfPCell(new Paragraph("ALIMENTACION", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores1.AddCell(new PdfPCell(new Paragraph(txt_alimentación.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvalores1);
            var tblvalores2 = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvalores2.AddCell(new PdfPCell(new Paragraph(txt_totalingresos2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores2.AddCell(new PdfPCell(new Paragraph(txt_ayuda2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores2.AddCell(new PdfPCell(new Paragraph(txt_otros2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores2.AddCell(new PdfPCell(new Paragraph("VIVIENDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores2.AddCell(new PdfPCell(new Paragraph(txt_vivienda.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvalores2);
            var tblvalores3 = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvalores3.AddCell(new PdfPCell(new Paragraph(txt_totalingresos3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores3.AddCell(new PdfPCell(new Paragraph(txt_ayuda3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores3.AddCell(new PdfPCell(new Paragraph(txt_otros3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores3.AddCell(new PdfPCell(new Paragraph("EDUCACION", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores3.AddCell(new PdfPCell(new Paragraph(txt_educación.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvalores3);
            var tblvalores4 = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvalores4.AddCell(new PdfPCell(new Paragraph(txt_totalingresos4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores4.AddCell(new PdfPCell(new Paragraph(txt_ayuda4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores4.AddCell(new PdfPCell(new Paragraph(txt_otros4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores4.AddCell(new PdfPCell(new Paragraph("SERVICIOS BASICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores4.AddCell(new PdfPCell(new Paragraph(txt_serviciosbasicos.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvalores4);
            var tblvalores5 = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvalores5.AddCell(new PdfPCell(new Paragraph(txt_totalingresos5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores5.AddCell(new PdfPCell(new Paragraph(txt_ayuda5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores5.AddCell(new PdfPCell(new Paragraph(txt_otros5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores5.AddCell(new PdfPCell(new Paragraph("SALUD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores5.AddCell(new PdfPCell(new Paragraph(txt_salud.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvalores5);
            var tblvalores6 = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvalores6.AddCell(new PdfPCell(new Paragraph(txt_totalingresos6.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores6.AddCell(new PdfPCell(new Paragraph(txt_ayuda6.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores6.AddCell(new PdfPCell(new Paragraph(txt_otros6.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores6.AddCell(new PdfPCell(new Paragraph("MOVILIZACION", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores6.AddCell(new PdfPCell(new Paragraph(txt_movilización.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvalores6);
            var tblvalores7 = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvalores7.AddCell(new PdfPCell(new Paragraph(txt_totalingresos7.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores7.AddCell(new PdfPCell(new Paragraph(txt_ayuda7.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores7.AddCell(new PdfPCell(new Paragraph(txt_otros7.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores7.AddCell(new PdfPCell(new Paragraph("DEUDAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores7.AddCell(new PdfPCell(new Paragraph(txt_deudas.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvalores7);
            var tblvalores8 = new PdfPTable(new float[] { 200f, 50f, 50f, 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvalores8.AddCell(new PdfPCell(new Paragraph(txt_totalingresos8.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores8.AddCell(new PdfPCell(new Paragraph(txt_ayuda8.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores8.AddCell(new PdfPCell(new Paragraph(txt_otros8.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores8.AddCell(new PdfPCell(new Paragraph("OTROS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvalores8.AddCell(new PdfPCell(new Paragraph(txt_otrospensiones.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvalores8);
            pdfDoc.Add(new Paragraph(" "));
            var tblencabezadodescripcion = new PdfPTable(new float[] { 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblencabezadodescripcion.AddCell(new PdfPCell(new Paragraph("DESCRIPCION DE LOS BIENES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3, Colspan = 2 });
            tblencabezadodescripcion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblencabezadodescripcion);
            var tblencabezadobienvalor = new PdfPTable(new float[] { 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblencabezadobienvalor.AddCell(new PdfPCell(new Paragraph("BIEN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblencabezadobienvalor.AddCell(new PdfPCell(new Paragraph("VALOR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblencabezadobienvalor);
            var tblcasa = new PdfPTable(new float[] { 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcasa.AddCell(new PdfPCell(new Paragraph("CASA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblcasa.AddCell(new PdfPCell(new Paragraph(txt_biencasa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblcasa);
            var tbldepa = new PdfPTable(new float[] { 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldepa.AddCell(new PdfPCell(new Paragraph("DEPARTAMENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldepa.AddCell(new PdfPCell(new Paragraph(txt_biendepartamento.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tbldepa);
            var tblvehi = new PdfPTable(new float[] { 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblvehi.AddCell(new PdfPCell(new Paragraph("VEHICULO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblvehi.AddCell(new PdfPCell(new Paragraph(txt_bienvehiculo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblvehi);
            var tblterre = new PdfPTable(new float[] { 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblterre.AddCell(new PdfPCell(new Paragraph("TERRENO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblterre.AddCell(new PdfPCell(new Paragraph(txt_bienterreno.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblterre);
            var tblnego = new PdfPTable(new float[] { 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblnego.AddCell(new PdfPCell(new Paragraph("NEGOCIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblnego.AddCell(new PdfPCell(new Paragraph(txt_bienegocio.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblnego);
            var tblmueble = new PdfPTable(new float[] { 75f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblmueble.AddCell(new PdfPCell(new Paragraph("MUEBLES Y ENSERES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblmueble.AddCell(new PdfPCell(new Paragraph(txt_bienmueblesyenseres.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblmueble);
            pdfDoc.Add(new Paragraph(" "));

            var tbldineroahorro = new PdfPTable(new float[] { 150f, 10f, 6f, 10f, 6f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tbldineroahorro.AddCell(new PdfPCell(new Paragraph("¿DESTINA ALGUN DINERO PARA EL AHORRO?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tbldineroahorro.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_dineroahorrosi.Checked == true)
            {
                tbldineroahorro.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tbldineroahorro.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tbldineroahorro.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_dineroahorrono.Checked == true)
            {
                tbldineroahorro.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tbldineroahorro.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tbldineroahorro.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tbldineroahorro);
            pdfDoc.Add(new Paragraph(" "));

            var tblCaracteristicasvivienda = new PdfPTable(new float[] { 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblCaracteristicasvivienda.AddCell(new PdfPCell(new Paragraph("CARACTERISTICAS DE LA VIVIENDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblCaracteristicasvivienda);
            pdfDoc.Add(new Paragraph(" "));
            var tblFamiliar = new PdfPTable(new float[] { 50f, 50f, 6f, 50f, 6f, 50f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblFamiliar.AddCell(new PdfPCell(new Paragraph("DESCRIPCION:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblFamiliar.AddCell(new PdfPCell(new Paragraph("UNIFAMILIAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_unifamiliar.Checked == true)
            {
                tblFamiliar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblFamiliar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblFamiliar.AddCell(new PdfPCell(new Paragraph("MULTIFAMILIAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_multifamiliar.Checked == true)
            {
                tblFamiliar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblFamiliar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblFamiliar.AddCell(new PdfPCell(new Paragraph("OTRO ESPECIFIQUE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblFamiliar.AddCell(new PdfPCell(new Paragraph(txt_otrodescripcionviviendafamilia.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblFamiliar);
            pdfDoc.Add(new Paragraph(" "));
            var tblTenencia = new PdfPTable(new float[] { 50f, 60f, 6f, 40f, 6f, 40f, 6f, 40f, 6f, 40F, 6f, 40f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTenencia.AddCell(new PdfPCell(new Paragraph("TENENCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTenencia.AddCell(new PdfPCell(new Paragraph("PROPIA SIN DEUDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_propiasindeuda.Checked == true)
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTenencia.AddCell(new PdfPCell(new Paragraph("ARRENDADA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_arrendada.Checked == true)
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTenencia.AddCell(new PdfPCell(new Paragraph("DE FAMILIA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_defamilia.Checked == true)
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTenencia.AddCell(new PdfPCell(new Paragraph("HIPOTECADA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_hipotecada.Checked == true)
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTenencia.AddCell(new PdfPCell(new Paragraph("PRESTADA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_prestada.Checked == true)
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTenencia.AddCell(new PdfPCell(new Paragraph("ANTICRESIS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_anticreces.Checked == true)
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTenencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblTenencia);
            var tblTenencia2 = new PdfPTable(new float[] { 40f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTenencia2.AddCell(new PdfPCell(new Paragraph("OTRO ESPECIFIQUE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTenencia2.AddCell(new PdfPCell(new Paragraph(txt_otratenencia.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3, Rowspan = 2 });
            pdfDoc.Add(tblTenencia2);
            pdfDoc.Add(new Paragraph(" "));

            var tblTipoHogar = new PdfPTable(new float[] { 20f, 20f, 6f, 20f, 6f, 30f, 6f, 40f, 6f, 20F, 6f, 40f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTipoHogar.AddCell(new PdfPCell(new Paragraph("TIPO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTipoHogar.AddCell(new PdfPCell(new Paragraph("CASA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tipocasa.Checked == true)
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoHogar.AddCell(new PdfPCell(new Paragraph("SUIT", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tiposuit.Checked == true)
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoHogar.AddCell(new PdfPCell(new Paragraph("MEDIAGUA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tipomediagua.Checked == true)
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoHogar.AddCell(new PdfPCell(new Paragraph("DEPARTAMENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tipodepartamento.Checked == true)
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoHogar.AddCell(new PdfPCell(new Paragraph("PIEZA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tipopieza.Checked == true)
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoHogar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoHogar.AddCell(new PdfPCell(new Paragraph("OTRO ESPECIFIQUE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTipoHogar.AddCell(new PdfPCell(new Paragraph(txt_otrotipodecasa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3, Rowspan = 2 });
            pdfDoc.Add(tblTipoHogar);
            pdfDoc.Add(new Paragraph(" "));

            var tblDistribucion = new PdfPTable(new float[] { 40f, 30f, 6f, 15f, 6f, 15f, 6f, 25f, 6f, 25F, 6f, 20f, 6f, 15f, 6f, 25f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("DISTRIBUCION:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("HABITACION", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_habitacion.Checked == true)
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("SALA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_sala.Checked == true)
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("BAÑO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_baño.Checked == true)
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("GARAGE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_garage.Checked == true)
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("COMEDOR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_comedor.Checked == true)
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("COCINA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_cocina.Checked == true)
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("PATIO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_patio.Checked == true)
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblDistribucion.AddCell(new PdfPCell(new Paragraph("BODEGA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_bodega.Checked == true)
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblDistribucion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblDistribucion);
            var tblDistribucion2 = new PdfPTable(new float[] { 40f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDistribucion2.AddCell(new PdfPCell(new Paragraph("OTRO ESPECIFIQUE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDistribucion2.AddCell(new PdfPCell(new Paragraph(txt_otradistribucioncasa.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3, Rowspan = 2 });
            pdfDoc.Add(tblDistribucion2);
            pdfDoc.Add(new Paragraph(" "));

            var tblVehiculo = new PdfPTable(new float[] { 50f, 10f, 6f, 10f, 6f, 100f, 10f, 6f, 10f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblVehiculo.AddCell(new PdfPCell(new Paragraph("¿DISPONE VEHICULO?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblVehiculo.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_vehiculosi.Checked == true)
            {
                tblVehiculo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblVehiculo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblVehiculo.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_vehiculono.Checked == true)
            {
                tblVehiculo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblVehiculo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblVehiculo.AddCell(new PdfPCell(new Paragraph("¿HACE USO DEL RECORRIDO INSTITUCIONAL?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblVehiculo.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_recorridosi.Checked == true)
            {
                tblVehiculo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblVehiculo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblVehiculo.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_recorridono.Checked == true)
            {
                tblVehiculo.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblVehiculo.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblVehiculo);
            pdfDoc.Add(new Paragraph(" "));

            var tblinfogeneral = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblinfogeneral.AddCell(new PdfPCell(new Paragraph("IV. INFORMACION GENERAL DEL SERVIDOR/A", titulo)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
            pdfDoc.Add(tblinfogeneral);
            pdfDoc.Add(new Paragraph(" "));
            var tblComposicionFamiliar = new PdfPTable(new float[] { 250f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblComposicionFamiliar.AddCell(new PdfPCell(new Paragraph("COMPOSICIÓN FAMILIAR DEL SERVIDOR/A, TRABAJADOR/A CON LOS QUE CONVIVE DE FORMA PERMANENTE EN EL MISMO LUGAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblComposicionFamiliar);
            pdfDoc.Add(new Paragraph(" "));

            var tblComposicionFamiliarDatos = new PdfPTable(new float[] { 200f, 100f, 100f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblComposicionFamiliarDatos.AddCell(new PdfPCell(new Paragraph("APELLIDOS Y NOMBRES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos.AddCell(new PdfPCell(new Paragraph("PARENTESCO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos.AddCell(new PdfPCell(new Paragraph("FECHA DE NACIMIENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos.AddCell(new PdfPCell(new Paragraph("EDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3, Colspan = 2 });
            pdfDoc.Add(tblComposicionFamiliarDatos);
            var tblComposicionFamiliarDatos1 = new PdfPTable(new float[] { 200f, 100f, 100f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblComposicionFamiliarDatos1.AddCell(new PdfPCell(new Paragraph(txt_nomapellidos1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos1.AddCell(new PdfPCell(new Paragraph(txt_parentesco1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos1.AddCell(new PdfPCell(new Paragraph(txt_fechanacimiento1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos1.AddCell(new PdfPCell(new Paragraph(txt_edad1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblComposicionFamiliarDatos1);
            var tblComposicionFamiliarDatos2 = new PdfPTable(new float[] { 200f, 100f, 100f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblComposicionFamiliarDatos2.AddCell(new PdfPCell(new Paragraph(txt_nomapellidos2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos2.AddCell(new PdfPCell(new Paragraph(txt_parentesco2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos2.AddCell(new PdfPCell(new Paragraph(txt_fechanacimiento2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos2.AddCell(new PdfPCell(new Paragraph(txt_edad2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblComposicionFamiliarDatos2);
            var tblComposicionFamiliarDatos3 = new PdfPTable(new float[] { 200f, 100f, 100f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblComposicionFamiliarDatos3.AddCell(new PdfPCell(new Paragraph(txt_nomapellidos3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos3.AddCell(new PdfPCell(new Paragraph(txt_parentesco3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos3.AddCell(new PdfPCell(new Paragraph(txt_fechanacimiento3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos3.AddCell(new PdfPCell(new Paragraph(txt_edad3.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblComposicionFamiliarDatos3);
            var tblComposicionFamiliarDatos4 = new PdfPTable(new float[] { 200f, 100f, 100f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblComposicionFamiliarDatos4.AddCell(new PdfPCell(new Paragraph(txt_nomapellidos4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos4.AddCell(new PdfPCell(new Paragraph(txt_parentesco4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos4.AddCell(new PdfPCell(new Paragraph(txt_fechanacimiento4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos4.AddCell(new PdfPCell(new Paragraph(txt_edad4.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblComposicionFamiliarDatos4);
            var tblComposicionFamiliarDatos5 = new PdfPTable(new float[] { 200f, 100f, 100f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblComposicionFamiliarDatos5.AddCell(new PdfPCell(new Paragraph(txt_nomapellidos5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos5.AddCell(new PdfPCell(new Paragraph(txt_parentesco5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos5.AddCell(new PdfPCell(new Paragraph(txt_fechanacimiento5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblComposicionFamiliarDatos5.AddCell(new PdfPCell(new Paragraph(txt_edad5.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblComposicionFamiliarDatos5);
            pdfDoc.Add(new Paragraph(" "));

            var tblPersonaDiscapacidad = new PdfPTable(new float[] { 100f, 10f, 6f, 10f, 6f, 100f, 10f, 6f, 10f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("¿TIENE EN SU NUCLEO FAMILIAR UNA PERSONA CON DISCAPACIDAD?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_nucleodiscapacidadsi.Checked == true)
            {
                tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_nucleodiscapacidadno.Checked == true)
            {
                tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("¿SE ENCUENTRA A CARGO DE ESTA PERSONA CON DISPACIDAD? CALIFICADA POR EL MSP O CONADIS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_acargofamiliardiacapacitadosi.Checked == true)
            {
                tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_acargofamiliardiacapacitadono.Checked == true)
            {
                tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblPersonaDiscapacidad.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblPersonaDiscapacidad);
            pdfDoc.Add(new Paragraph(" "));

            var tblDatosPersonaD = new PdfPTable(new float[] { 125f, 75f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatosPersonaD.AddCell(new PdfPCell(new Paragraph("APELLIDOS Y NOMBRES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaD.AddCell(new PdfPCell(new Paragraph("FECHA CADUCIDAD CARNET", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaD.AddCell(new PdfPCell(new Paragraph("TIPO DE DISCAPACIDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaD.AddCell(new PdfPCell(new Paragraph("PORCENTAJE", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaD.AddCell(new PdfPCell(new Paragraph("PARENTESCO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaD.AddCell(new PdfPCell(new Paragraph("FECHA DE NACIMIENTO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblDatosPersonaD);
            var tblDatosPersonaDis1 = new PdfPTable(new float[] { 125f, 75f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatosPersonaDis1.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadonomape1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis1.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadofechacaducidadcarnet1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis1.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadotipodiscapacidad1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis1.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadoporcentajediscapacidad1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis1.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadoparentesco1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis1.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadofechanacimiento1.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblDatosPersonaDis1);
            var tblDatosPersonaDis2 = new PdfPTable(new float[] { 125f, 75f, 50f, 50f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblDatosPersonaDis2.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadonomape2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis2.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadofechacaducidadcarnet2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis2.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadotipodiscapacidad2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis2.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadoporcentajediscapacidad2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis2.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadoparentesco2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblDatosPersonaDis2.AddCell(new PdfPCell(new Paragraph(txt_familiardiscapacitadofechanacimiento2.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblDatosPersonaDis2);
            pdfDoc.Add(new Paragraph(" "));

            var tblRegistroFamiliar = new PdfPTable(new float[] { 100f, 10f, 6f, 10f, 6f, 30f, 30f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph("¿SE ENCUENTRA REGISTRADA LA DEPENDENCIA FAMILIAR EN EL MINISTERIO DE TRABAJO?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_dependenciaministeriotrabajosi.Checked == true)
            {
                tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_dependenciaministeriotrabajono.Checked == true)
            {
                tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph("TIEMPO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph(txt_dependenciaministeriotrabajotiempo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph("Nº DE CARNET DEL MINISTERIO DE TRABAJO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblRegistroFamiliar.AddCell(new PdfPCell(new Paragraph(txt_numcarnetMSP.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblRegistroFamiliar);
            pdfDoc.Add(new Paragraph(" "));

            var tblRegistroFamiliar2 = new PdfPTable(new float[] { 100f, 10f, 6f, 10f, 6f, 30f, 30f, 50f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph("¿SE ENCUENTRA A CARGO DE UN FAMILIAR CON ENFERMEDAD CATASTROFICA O RARA?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_acargofamiliarenfermedadrarasi.Checked == true)
            {
                tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_acargofamiliarenfermedadrarano.Checked == true)
            {
                tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph("TIEMPO:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph(txt_acargofamiliarenfermedadraratiempo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph("TIPO DE ENFERMEDAD", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblRegistroFamiliar2.AddCell(new PdfPCell(new Paragraph(txt_familiarenfermedadraratipo.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblRegistroFamiliar2);
            pdfDoc.Add(new Paragraph(" "));

            var tblActLibre = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblActLibre.AddCell(new PdfPCell(new Paragraph("V. ACTIVIDADES QUE REALIZA EN TIEMPO LIBRE EL SERVIDOR/A", titulo)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
            pdfDoc.Add(tblActLibre);
            pdfDoc.Add(new Paragraph(" "));

            var tblActividades = new PdfPTable(new float[] { 25f, 6f, 50f, 6f, 25f, 6f, 50f, 6f, 25f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblActividades.AddCell(new PdfPCell(new Paragraph("HOGAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_hogar.Checked == true)
            {
                tblActividades.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblActividades.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblActividades.AddCell(new PdfPCell(new Paragraph("PASEOS FAMILIARES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_paseosfamiliares.Checked == true)
            {
                tblActividades.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblActividades.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblActividades.AddCell(new PdfPCell(new Paragraph("ESTUDIOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_estudios.Checked == true)
            {
                tblActividades.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblActividades.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblActividades.AddCell(new PdfPCell(new Paragraph("ACTIVIDADES ARTISTICAS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_actividadesartisticas.Checked == true)
            {
                tblActividades.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblActividades.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblActividades.AddCell(new PdfPCell(new Paragraph("OTROS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActividades.AddCell(new PdfPCell(new Paragraph(txt_otraactividad.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblActividades);
            pdfDoc.Add(new Paragraph(" "));

            var tblActEconomica = new PdfPTable(new float[] { 100f, 10f, 6f, 10f, 6f, 100f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblActEconomica.AddCell(new PdfPCell(new Paragraph("¿REALIZA ALGUNA ACTIVIDAD ECONOMICA ADICIONAL?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActEconomica.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_actividadeconomicasi.Checked == true)
            {
                tblActEconomica.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblActEconomica.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblActEconomica.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_actividadeconomicano.Checked == true)
            {
                tblActEconomica.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblActEconomica.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblActEconomica.AddCell(new PdfPCell(new Paragraph("DETALLE LA ACTIVIDAD QUE REALIZA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActEconomica.AddCell(new PdfPCell(new Paragraph(txt_actividadeconomicadetalle.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblActEconomica);
            var tblActEconomica2 = new PdfPTable(new float[] { 66f, 65.5f, 100f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblActEconomica2.AddCell(new PdfPCell(new Paragraph("TIEMPO QUE DESTINA A LA ACTIVIDAD:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActEconomica2.AddCell(new PdfPCell(new Paragraph(txt_actividadeconomicatiempodestina.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActEconomica2.AddCell(new PdfPCell(new Paragraph("¿HACE CUANTO TIEMPO REALIZA LA ACTIVIDAD?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActEconomica2.AddCell(new PdfPCell(new Paragraph(txt_actividadeconomicatiemporealiza.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblActEconomica2);
            pdfDoc.Add(new Paragraph(" "));

            var tblActDeportiva = new PdfPTable(new float[] { 100f, 10f, 6f, 10f, 6f, 100f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblActDeportiva.AddCell(new PdfPCell(new Paragraph("¿REALIZA ALGUNA ACTIVIDAD DEPORTIVA?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActDeportiva.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_deportesi.Checked == true)
            {
                tblActDeportiva.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblActDeportiva.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblActDeportiva.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_deporteno.Checked == true)
            {
                tblActDeportiva.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblActDeportiva.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblActDeportiva.AddCell(new PdfPCell(new Paragraph("DETALLE LA ACTIVIDAD QUE REALIZA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActDeportiva.AddCell(new PdfPCell(new Paragraph(txt_especifiquedeporte.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblActDeportiva);
            var tblActDeportiva2 = new PdfPTable(new float[] { 66f, 65.5f, 100f, 75f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblActDeportiva2.AddCell(new PdfPCell(new Paragraph("FRECUENCIA:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActDeportiva2.AddCell(new PdfPCell(new Paragraph(txt_frecuenciadeporte.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActDeportiva2.AddCell(new PdfPCell(new Paragraph("¿DESDE QUE EDAD PRACTICA ESTA ACTIVIDAD?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblActDeportiva2.AddCell(new PdfPCell(new Paragraph(txt_edadpracticadeporte.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblActDeportiva2);
            pdfDoc.Add(new Paragraph(" "));

            var tblLesion = new PdfPTable(new float[] { 100f, 10f, 6f, 10f, 6f, 75f, 100f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblLesion.AddCell(new PdfPCell(new Paragraph("¿HA SUFRIDO ALGUNA LESION?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblLesion.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_lesionsi.Checked == true)
            {
                tblLesion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblLesion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblLesion.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_lesionno.Checked == true)
            {
                tblLesion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblLesion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblLesion.AddCell(new PdfPCell(new Paragraph("TIPO DE LESION:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblLesion.AddCell(new PdfPCell(new Paragraph(txt_tipolesion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblLesion);
            var tblLesion2 = new PdfPTable(new float[] { 66f, 65.5f, 75f, 10f, 6f, 10f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblLesion2.AddCell(new PdfPCell(new Paragraph("EDAD A LA QUE SUFRIO LA LESION:", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblLesion2.AddCell(new PdfPCell(new Paragraph(txt_edadlesion.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblLesion2.AddCell(new PdfPCell(new Paragraph("¿RECIBIO ALGUN TRATAMIENTO O REHABILITACION?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblLesion2.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tratamientosi.Checked == true)
            {
                tblLesion2.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblLesion2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblLesion2.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_tratamientono.Checked == true)
            {
                tblLesion2.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblLesion2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblLesion2);
            pdfDoc.Add(new Paragraph(" "));

            var tblInfoLaboral = new PdfPTable(new float[] { 70f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblInfoLaboral.AddCell(new PdfPCell(new Paragraph("VI. INFORMACIÓN PARA USO DE BIENESTAR LABORAL DEL SERVIDOR/A", titulo)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(204, 205, 254), HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
            pdfDoc.Add(tblInfoLaboral);
            pdfDoc.Add(new Paragraph(" "));

            var tblTipoFamilia = new PdfPTable(new float[] { 50f, 25f, 6f, 25f, 6f, 50f, 6f, 25f, 6f, 25f, 6f, 50f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("TIPO DE FAMILIA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("NUCLEAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_nuclear.Checked == true)
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("AMPLIADA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_ampliada.Checked == true)
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("MONOPARENTAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_monoparental.Checked == true)
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("VIVE SOLO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_vivesolo.Checked == true)
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("VIVE CON AMIGOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_viveconamigos.Checked == true)
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("FAMILIA SIN HIJOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_familiasinhijos.Checked == true)
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblTipoFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblTipoFamilia);
            pdfDoc.Add(new Paragraph(" "));

            var tblrelacion = new PdfPTable(new float[] { 50f, 25f, 6f, 20f, 6f, 20f, 6f, 20f, 6f, 25f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrelacion.AddCell(new PdfPCell(new Paragraph("EVALUACION DEL NIVEL DE RELACION FAMILIAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblrelacion.AddCell(new PdfPCell(new Paragraph("MUY BUENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionfamiliarmuybuena.Checked == true)
            {
                tblrelacion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacion.AddCell(new PdfPCell(new Paragraph("BUENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionfamiliarbuena.Checked == true)
            {
                tblrelacion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacion.AddCell(new PdfPCell(new Paragraph("REGULAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionfamiliarregular.Checked == true)
            {
                tblrelacion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacion.AddCell(new PdfPCell(new Paragraph("MALA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionparejamala.Checked == true)
            {
                tblrelacion.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacion.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacion.AddCell(new PdfPCell(new Paragraph("¿POR QUE?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblrelacion.AddCell(new PdfPCell(new Paragraph(txt_relacionfamiliarporque.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblrelacion);
            pdfDoc.Add(new Paragraph(" "));

            var tblrelacionpareja = new PdfPTable(new float[] { 50f, 25f, 6f, 20f, 6f, 20f, 6f, 20f, 6f, 25f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("EVALUACION DEL NIVEL DE RELACION DE PAREJA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("MUY BUENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionparejamuybuena.Checked == true)
            {
                tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacionpareja.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("BUENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionparejabuena.Checked == true)
            {
                tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacionpareja.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("REGULAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionparejaregular.Checked == true)
            {
                tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacionpareja.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("MALA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionparejamala.Checked == true)
            {
                tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacionpareja.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacionpareja.AddCell(new PdfPCell(new Paragraph("¿POR QUE?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblrelacionpareja.AddCell(new PdfPCell(new Paragraph(txt_relacionparejaporque.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblrelacionpareja);
            pdfDoc.Add(new Paragraph(" "));

            var tblrelacionhijos = new PdfPTable(new float[] { 50f, 25f, 6f, 20f, 6f, 20f, 6f, 20f, 6f, 25f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("EVALUACION DEL NIVEL DE RELACION CON LOS HIJOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("MUY BUENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionconhijosmuybuena.Checked == true)
            {
                tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacionhijos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("BUENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionconhijosbuena.Checked == true)
            {
                tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacionhijos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("REGULAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionconhijosregular.Checked == true)
            {
                tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacionhijos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("MALA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_relacionconhijosmala.Checked == true)
            {
                tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblrelacionhijos.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblrelacionhijos.AddCell(new PdfPCell(new Paragraph("¿POR QUE?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblrelacionhijos.AddCell(new PdfPCell(new Paragraph(txt_relacionconhijosporque.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblrelacionhijos);
            pdfDoc.Add(new Paragraph(" "));

            var tblProblemasFam = new PdfPTable(new float[] { 50f, 25f, 6f, 30f, 6f, 25f, 6f, 25f, 6f, 25f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblProblemasFam.AddCell(new PdfPCell(new Paragraph("PROBLEMAS FAMILIARES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblProblemasFam.AddCell(new PdfPCell(new Paragraph("ECONOMICOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_economico.Checked == true)
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblProblemasFam.AddCell(new PdfPCell(new Paragraph("COMUNICACION", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_comunicacion.Checked == true)
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblProblemasFam.AddCell(new PdfPCell(new Paragraph("CONYUGALES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_conyugales.Checked == true)
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblProblemasFam.AddCell(new PdfPCell(new Paragraph("CRIANZA DE HIJOS", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_crianzadehijos.Checked == true)
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblProblemasFam.AddCell(new PdfPCell(new Paragraph("ADICCIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_adicciones.Checked == true)
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblProblemasFam.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblProblemasFam);
            var tblViolencia = new PdfPTable(new float[] { 46.5f, 6f, 46.5f, 6f, 46.5f, 6f, 46.5f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblViolencia.AddCell(new PdfPCell(new Paragraph("VIOLENCIA FISICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_fisica.Checked == true)
            {
                tblViolencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblViolencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblViolencia.AddCell(new PdfPCell(new Paragraph("VIOLENCIA PSICOLOGICA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_psicologica.Checked == true)
            {
                tblViolencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblViolencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblViolencia.AddCell(new PdfPCell(new Paragraph("VIOLENCIA VERBAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_verbal.Checked == true)
            {
                tblViolencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblViolencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblViolencia.AddCell(new PdfPCell(new Paragraph("VIOLENCIA SEXUAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_sexual.Checked == true)
            {
                tblViolencia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblViolencia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblViolencia);
            pdfDoc.Add(new Paragraph(" "));

            var tblObservaciones = new PdfPTable(new float[] { 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblObservaciones.AddCell(new PdfPCell(new Paragraph("OBSERVACIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblObservaciones);
            var tblObservaciones1 = new PdfPTable(new float[] { 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblObservaciones1.AddCell(new PdfPCell(new Paragraph(txt_observacionesfamiliares.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblObservaciones1);
            pdfDoc.Add(new Paragraph(" "));

            var tblMiembroRol = new PdfPTable(new float[] { 150f, 10f, 6f, 10f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblMiembroRol.AddCell(new PdfPCell(new Paragraph("¿CADA MIEMBRO CUMPLE CON SU ROL?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblMiembroRol.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_rolfamiliarsi.Checked == true)
            {
                tblMiembroRol.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblMiembroRol.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblMiembroRol.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_rolfamiliarno.Checked == true)
            {
                tblMiembroRol.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblMiembroRol.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblMiembroRol);
            pdfDoc.Add(new Paragraph(" "));

            var tblSaludFamilia = new PdfPTable(new float[] { 50f, 25f, 6f, 20f, 6f, 20f, 6f, 20f, 6f, 25f, 50f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("NIVEL DE SALUD DE LA FAMILIA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("MUY BUENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_nivelsaludfamiliarmuybuena.Checked == true)
            {
                tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSaludFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("BUENA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_nivelsaludfamiliarbuena.Checked == true)
            {
                tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSaludFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("REGULAR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_nivelsaludfamiliarregular.Checked == true)
            {
                tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSaludFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("MALA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_nivelsaludfamiliarmala.Checked == true)
            {
                tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblSaludFamilia.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblSaludFamilia.AddCell(new PdfPCell(new Paragraph("¿POR QUE?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblSaludFamilia.AddCell(new PdfPCell(new Paragraph(txt_nivelsaludfamiliarporque.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblSaludFamilia);
            pdfDoc.Add(new Paragraph(" "));

            var tblFamiliaes = new PdfPTable(new float[] { 150f, 25f, 6f, 25f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblFamiliaes.AddCell(new PdfPCell(new Paragraph("¿CONSIDERA QUE SU FAMILIA ES?", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            tblFamiliaes.AddCell(new PdfPCell(new Paragraph("FUNCIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_funcional.Checked == true)
            {
                tblFamiliaes.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblFamiliaes.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblFamiliaes.AddCell(new PdfPCell(new Paragraph("DISFUNCIONAL", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_disfuncional.Checked == true)
            {
                tblFamiliaes.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblFamiliaes.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblFamiliaes);
            pdfDoc.Add(new Paragraph(" "));

            var tblObservacionesSalud = new PdfPTable(new float[] { 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblObservacionesSalud.AddCell(new PdfPCell(new Paragraph("OBSERVACIONES", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblObservacionesSalud);
            var tblObservacionesSalud1 = new PdfPTable(new float[] { 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblObservacionesSalud1.AddCell(new PdfPCell(new Paragraph(txt_observacionesgenerales.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblObservacionesSalud1);
            pdfDoc.Add(new Paragraph(" "));

            var tblObservacionesAdicional = new PdfPTable(new float[] { 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblObservacionesAdicional.AddCell(new PdfPCell(new Paragraph("ALGUNA INFORMACION ADICIONAL QUE LA INSTITUCION DEBA CONOCER", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblObservacionesAdicional);
            var tblObservacionesAdicional1 = new PdfPTable(new float[] { 150f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblObservacionesAdicional1.AddCell(new PdfPCell(new Paragraph(txt_informacionadicional.Text, cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblObservacionesAdicional1);
            pdfDoc.Add(new Paragraph(" "));

            var tblCertifico = new PdfPTable(new float[] { 250f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblCertifico.AddCell(new PdfPCell(new Paragraph("CERTIFICO QUE LA INFORMACION AQUI SUMINISTRADA ES VERAZ, REAL, COMPLETA Y PODRA SER VERIFICADA EN EL MOMENTO QUE LA INSTITUCION CREA NECESARIO", certificacion)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblCertifico);
            pdfDoc.Add(new Paragraph(" "));
            var tblcertificoOpciones = new PdfPTable(new float[] { 10f, 6f, 10f, 6f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblcertificoOpciones.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_certificosi.Checked == true)
            {
                tblcertificoOpciones.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblcertificoOpciones.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            tblcertificoOpciones.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            if (cb_certificono.Checked == true)
            {
                tblcertificoOpciones.AddCell(new PdfPCell(new Paragraph("X", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            else
            {
                tblcertificoOpciones.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            }
            pdfDoc.Add(tblcertificoOpciones);
            pdfDoc.Add(new Paragraph(" "));

            var tblInfo = new PdfPTable(new float[] { 250f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblInfo.AddCell(new PdfPCell(new Paragraph("ESTA INFORMACION ES SOLICITADA CON EL FIN DE ACTUALIZAR NUESTROS REGISTROS SOCIOECONOMICOS Y DE BIENESTAR LABORAL DE LOS SERVIDORES DEL SERVICIO INTEGRADO DE SEGURIDAD ECU 911.", informacion)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblInfo);
            pdfDoc.Add(new Paragraph(" "));

            var tblAgradecimiento = new PdfPTable(new float[] { 250f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblAgradecimiento.AddCell(new PdfPCell(new Paragraph("GRACIAS POR SU COLABORACIÓN", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblAgradecimiento);
            pdfDoc.Add(new Paragraph(" "));

            var tblFirma = new PdfPTable(new float[] { 250f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblFirma.AddCell(new PdfPCell(new Paragraph("FIRMA DEL SERVIDOR", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblFirma);
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));
            pdfDoc.Add(new Paragraph(" "));

            var tblGeoReferencia = new PdfPTable(new float[] { 250f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblGeoReferencia.AddCell(new PdfPCell(new Paragraph("GEOREFERENCIA DE LA VIVIENDA", cuadro)) { BorderColor = new BaseColor(238, 240, 242), BackgroundColor = new BaseColor(205, 254, 204), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblGeoReferencia);
            var tblGeoReferencia1 = new PdfPTable(new float[] { 250f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_CENTER };
            tblGeoReferencia1.AddCell(new PdfPCell(new Paragraph("", cuadro)) { BorderColor = new BaseColor(238, 240, 242), HorizontalAlignment = Element.ALIGN_CENTER, Padding = 3 });
            pdfDoc.Add(tblGeoReferencia1);

            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Ficha_Socio_Económica" + txt_cedula.Text + "_" + DateTime.Now.ToString("dd/MM/yy_hh:mm") + ".pdf"); ;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Pacientes/Inicio.aspx");
        }
    }
}