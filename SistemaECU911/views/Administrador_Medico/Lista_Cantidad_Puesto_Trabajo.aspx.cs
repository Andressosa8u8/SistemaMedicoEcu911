using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Lista_Cantidad_Puesto_Trabajo : System.Web.UI.Page
    {
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }
        }
        private void cargarDatos()
        {
            var query = from fm in dc.Tbl_Person
                        let puestoTrabajo = fm.Per_puestoTrabajo == "0" ? "SIN ENFERMEDAD"
                        : fm.Per_puestoTrabajo == "CENTRO OPERATIVO LOCAL" ? "CENTRO OPERATIVO LOCAL"
                        : fm.Per_puestoTrabajo == "COORDINACION GENERAL ADMINISTRATIVA FINANCIERA" ? "COORDINACION GENERAL ADMINISTRATIVA FINANCIERA"
                        : fm.Per_puestoTrabajo == "COORDINACION GENERAL DE PLANIFICACION Y GESTION ESTRATEGICA" ? "COORDINACION GENERAL DE PLANIFICACION Y GESTION ESTRATEGICA"
                        : fm.Per_puestoTrabajo == "COORDINACION ZONAL" ? "COORDINACION ZONAL"
                        : fm.Per_puestoTrabajo == "DIRECCION ADMINISTRATIVA" ? "DIRECCION ADMINISTRATIVA"
                        : fm.Per_puestoTrabajo == "DIRECCION ASESORIA JURIDICA" ? "DIRECCION ASESORIA JURIDICA"
                        : fm.Per_puestoTrabajo == "DIRECCION DE ADMINISTRACION DE RECURSOS HUMANOS" ? "DIRECCION DE ADMINISTRACION DE RECURSOS HUMANOS"
                        : fm.Per_puestoTrabajo == "DIRECCION DE COMUNICACION SOCIAL" ? "DIRECCION DE COMUNICACION SOCIAL"
                        : fm.Per_puestoTrabajo == "DIRECCION DE GESTION DEL CAMBIO DE CULTURA ORGANIZATIVA" ? "DIRECCION DE GESTION DEL CAMBIO DE CULTURA ORGANIZATIVA"
                        : fm.Per_puestoTrabajo == "DIRECCION DE GESTION DOCUMENTAL Y ARCHIVO" ? "DIRECCION DE GESTION DOCUMENTAL Y ARCHIVO"
                        : fm.Per_puestoTrabajo == "DIRECCION DE PLANIFICACION E INVERSION" ? "DIRECCION DE PLANIFICACION E INVERSION"
                        : fm.Per_puestoTrabajo == "DIRECCION DE SEGUIMIENTO DE PLANES PROGRAMAS Y PROYECTOS" ? "DIRECCION DE SEGUIMIENTO DE PLANES PROGRAMAS Y PROYECTOS"
                        : fm.Per_puestoTrabajo == "DIRECCION DE SERVICIOS PROCESOS Y CALIDAD" ? "DIRECCION DE SERVICIOS PROCESOS Y CALIDAD"
                        : fm.Per_puestoTrabajo == "DIRECCION FINANCIERA" ? "DIRECCION FINANCIERA"
                        : fm.Per_puestoTrabajo == "DIRECCION GENERAL" ? "DIRECCION GENERAL"
                        : fm.Per_puestoTrabajo == "DIRECCION NACIONAL ACADEMICO PARA EMERGENCIAS" ? "DIRECCION NACIONAL ACADEMICO PARA EMERGENCIAS"
                        : fm.Per_puestoTrabajo == "DIRECCION NACIONAL DE ANALISIS DE DATOS" ? "DIRECCION NACIONAL DE ANALISIS DE DATOS"
                        : fm.Per_puestoTrabajo == "DIRECCION NACIONAL DE COORDINACION INTERINSTITUCIONAL" ? "DIRECCION NACIONAL DE COORDINACION INTERINSTITUCIONAL"
                        : fm.Per_puestoTrabajo == "DIRECCION NACIONAL DE GESTION DE INFRAESTRUCTURA TECNOLOGICA PARA EMERGENCIAS" ? "DIRECCION NACIONAL DE GESTION DE INFRAESTRUCTURA TECNOLOGICA PARA EMERGENCIAS"
                        : fm.Per_puestoTrabajo == "DIRECCION NACIONAL DE OPERACIONES" ? "DIRECCION NACIONAL DE OPERACIONES"
                        : fm.Per_puestoTrabajo == "DIRECCION NACIONAL DE PROYECTOS E INNOVACION TECNOLOGICA" ? "DIRECCION NACIONAL DE PROYECTOS E INNOVACION TECNOLOGICA"
                        : fm.Per_puestoTrabajo == "DIRECCION NACIONAL REGULATORIO EN EMERGENCIAS" ? "DIRECCION NACIONAL REGULATORIO EN EMERGENCIAS"
                        : fm.Per_puestoTrabajo == "DIRECCION ZONAL ADMINISTRATIVA FINANCIERA Y DE ADMINISTRACION DE RECURSOS HUMANOS" ? "DIRECCION ZONAL ADMINISTRATIVA FINANCIERA Y DE ADMINISTRACION DE RECURSOS HUMANOS"
                        : fm.Per_puestoTrabajo == "DIRECCION ZONAL DE ASESORIA JURIDICA" ? "DIRECCION ZONAL DE ASESORIA JURIDICA"
                        : fm.Per_puestoTrabajo == "DIRECCION ZONAL DE COMUNICACION SOCIAL" ? "DIRECCION ZONAL DE COMUNICACION SOCIAL"
                        : fm.Per_puestoTrabajo == "DIRECCION ZONAL DE ESTADISTICAS" ? "DIRECCION ZONAL DE ESTADISTICAS"
                        : fm.Per_puestoTrabajo == "DIRECCION ZONAL DE OPERACIONES" ? "DIRECCION ZONAL DE OPERACIONES"
                        : fm.Per_puestoTrabajo == "DIRECCION ZONAL DE PLANIFICACION Y GESTION ESTRATEGICA" ? "DIRECCION ZONAL DE PLANIFICACION Y GESTION ESTRATEGICA"
                        : fm.Per_puestoTrabajo == "DIRECCION ZONAL DE TECNOLOGIA Y SOPORTE" ? "DIRECCION ZONAL DE TECNOLOGIA Y SOPORTE"
                        : fm.Per_puestoTrabajo == "GESTION LOCAL ADMINISTRATIVA FINANCIERA Y DE ADMINISTRACION DE RECURSOS HUMANOS" ? "GESTION LOCAL ADMINISTRATIVA FINANCIERA Y DE ADMINISTRACION DE RECURSOS HUMANOS"
                        : fm.Per_puestoTrabajo == "GESTION LOCAL DE ASESORIA JURIDICA" ? "GESTION LOCAL DE ASESORIA JURIDICA"
                        : fm.Per_puestoTrabajo == "GESTION LOCAL DE ASESORIA JURIDICA" ? "GESTION LOCAL DE ASESORIA JURIDICA"
                        : fm.Per_puestoTrabajo == "GESTION LOCAL DE COMUNICACION SOCIAL" ? "GESTION LOCAL DE COMUNICACION SOCIAL"
                        : fm.Per_puestoTrabajo == "GESTION LOCAL DE ESTADISTICA" ? "GESTION LOCAL DE ESTADISTICA"
                        : fm.Per_puestoTrabajo == "GESTION LOCAL DE OPERACIONES" ? "GESTION LOCAL DE OPERACIONES"
                        : fm.Per_puestoTrabajo == "GESTION LOCAL DE PLANIFICACION Y GESTION ESTRATEGICA" ? "GESTION LOCAL DE PLANIFICACION Y GESTION ESTRATEGICA"
                        : fm.Per_puestoTrabajo == "GESTION LOCAL DE SOPORTE TECNOLOGICO" ? "GESTION LOCAL DE SOPORTE TECNOLOGICO"
                        : fm.Per_puestoTrabajo == "SUBDIRECCION GENERAL" ? "SUBDIRECCION GENERAL"
                        : fm.Per_puestoTrabajo == "SUBDIRECCION TECNICA DE DOCTRINA" ? "SUBDIRECCION TECNICA DE DOCTRINA"
                        : fm.Per_puestoTrabajo == "SUBDIRECCION TECNICA DE OPERACIONES SIS" ? "SUBDIRECCION TECNICA DE OPERACIONES SIS"
                        : fm.Per_puestoTrabajo == "SUBDIRECCION TECNICA DE TECNOLOGIA E INNOVACION" ? "SUBDIRECCION TECNICA DE TECNOLOGIA E INNOVACION" : null
                        where puestoTrabajo != null
                        group fm by puestoTrabajo into g
                        select new
                        {
                            idPersonas = g.Max(f => f.Per_id),
                            puestoTrabajo = g.Key,
                            valor = g.Count(),
                        };

            grvDatos.DataSource = query.ToList();
            grvDatos.DataBind();
        }
    }
}