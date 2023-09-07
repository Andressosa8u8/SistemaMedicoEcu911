using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Agregar_Doctores : System.Web.UI.Page
    {
        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Profesional pro = new Tbl_Profesional();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);

                    pro = CN_Profesionales.ObtenerProfesionalPorId(codigo);
                    int profesionalesId = Convert.ToInt32(pro.prof_id.ToString());
                    pro = CN_Profesionales.ObtenerProfesionalPorId(profesionalesId);
                    //per = CN_Personas.ObtenerPersonaPorId(codigo);
                    //int personasid = Convert.ToInt32(per.Per_id.ToString());
                    //per = CN_Personas.ObtenerPersonaPorId(personasid);

                    btn_guardar.Text = "Actualizar";

                    if (pro != null)
                    {
                        txt_Nombre.Text = pro.prof_NomApe.ToString();
                        txt_cedula.Text = pro.prof_cedula.ToString();
                        ddl_estado.Text = pro.prof_estado.ToString();
                        //ddl_especialidad.Text = pro.Espec_id.ToString();

                    }
                }
                Timer1.Enabled = false;
                Validaciones();
                ddl_estado.Text = "A";
                cargarEspecialidad();
                txt_cedula.MaxLength = 10;

                txt_Nombre.Enabled = false;
                ddl_especialidad.Enabled = false;
                ddl_estado.Enabled = false;
            }
        }

        private void Validaciones()
        {
            //ddl_estado.Text = "ACTIVO";
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
        private void GuardarProfesional()
        {
            try
            {
                //bool existeCedula = CN_Personas.autentificarxCedula(txt_cedula.Text);
                bool existeCedula = CN_Profesionales.autentificarxCedula(txt_cedula.Text);

                if (existeCedula)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!','El paciente ya existe !! Verifique el número de cedula', 'error')", true);
                }
                else
                {
                    pro = new Tbl_Profesional();
                    pro.prof_NomApe = txt_Nombre.Text.ToUpper();
                    pro.prof_cedula = txt_cedula.Text.ToUpper();
                    pro.prof_estado = ddl_estado.Text.ToUpper();
                    //pro.Espec_id = ddl_especialidad.Text.ToUpper();

                    //per = new Tbl_Person();

                    CN_Profesionales.GuardarProfesional(pro);

                    //Mensaje de confirmacion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Paciente Registrado Exitosamente', 'success')", true);
                    Timer1.Enabled = true;
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'El Paciente No Fue Registrado', 'error')", true);
            }
        }

        private void ModificarProfesional(Tbl_Profesional pro)
        {
            try
            {
                //Datos Update Tbl_Profesional
                pro.prof_NomApe = txt_Nombre.Text.ToUpper().Trim();
                pro.prof_cedula = txt_cedula.Text.Trim();
                pro.prof_estado = ddl_estado.SelectedValue;
                //pro.Espec_id = ddl_especialidad.SelectedValue;

                CN_Profesionales.ModificarPersona(pro);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }

        private void Guardar_modificar_datos(int prof)
        {
            if (prof == 0)
            {
                GuardarProfesional();
            }
            else
            {
                pro = CN_Profesionales.ObtenerProfesionalPorId(prof);
                if (pro != null)
                {
                    ModificarProfesional(pro);
                }
            }
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Administrador_Medico/Inicio.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Guardar_modificar_datos(Convert.ToInt32(Request["cod"]));
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Administrador_Medico/Inicio.aspx");
        }
        protected void txt_Nombre_TextChanged(object sender, EventArgs e)
        {
            ExisteCedula();
        }
        private void ExisteCedula()
        {
            string cedula = txt_cedula.Text;

            var query = from c in dc.Tbl_Profesional
                        where c.prof_cedula == cedula
                        select c;
            if (query.Any())
            {
                lbl_cedula.Enabled = true;
                lbl_cedula.Text = "El Doctor ya existe !!";
                txt_Nombre.Enabled = false;
                ddl_especialidad.Enabled = false;
                ddl_estado.Enabled = false;
            }
            else
            {
                lbl_cedula.Text = "";
                lbl_cedula.Enabled = false;
                txt_Nombre.Enabled = true;
                ddl_especialidad.Enabled = true;
                ddl_estado.Enabled = true;
            }
        }        
    }
}