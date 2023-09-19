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

                    btn_guardar.Text = "Actualizar";
                    txt_cedula.ReadOnly = true;

                    if (pro != null)
                    {
                        txt_cedula.Text = pro.prof_cedula.ToString();
                        txt_Nombre.Text = pro.prof_NomApe.ToString();
                        ddl_especialidad.Text = pro.espec_id.ToString();
                        ddl_centro.Text = pro.cent_id.ToString();
                        ddl_estado.Text = pro.prof_estado.ToString();

                    }
                }
                else
                {
                    txt_Nombre.Enabled = false;
                    ddl_especialidad.Enabled = false;
                    ddl_centro.Enabled = false;
                    ddl_estado.Enabled = false;
                }

                Timer1.Enabled = false;
                cargarEspecialidad();
                CargarCentros();
                ddl_estado.Text = "A";
                txt_cedula.MaxLength = 10;
            }
        }

        private void CargarCentros()
        {
            List<Tbl_Centro> listacen = new List<Tbl_Centro>();
            listacen = CN_Personas.ObtenerCentros();
            listacen.Insert(0, new Tbl_Centro() { cent_nombre = "Seleccione...." });

            ddl_centro.DataSource = listacen;
            ddl_centro.DataTextField = "cent_nombre";
            ddl_centro.DataValueField = "cent_id";
            ddl_centro.DataBind();

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
                    pro.espec_id = Convert.ToInt32(ddl_especialidad.SelectedValue);
                    pro.cent_id = Convert.ToInt32(ddl_centro.SelectedValue);
                    pro.prof_estado = ddl_estado.SelectedValue;

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
                pro.prof_NomApe = txt_Nombre.Text.ToUpper().Trim();
                pro.prof_cedula = txt_cedula.Text.Trim();
                pro.espec_id = Convert.ToInt32(ddl_especialidad.SelectedValue);
                pro.espec_id = Convert.ToInt32(ddl_centro.SelectedValue);
                pro.prof_estado = ddl_estado.SelectedValue;

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

        protected void txt_cedula_TextChanged(object sender, EventArgs e)
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
                lbl_cedula.Text = "El Doctor ya existe !!";
                lbl_cedula.Enabled = true;
                txt_Nombre.Enabled = false;
                ddl_especialidad.Enabled = false;
                ddl_centro.Enabled = false;
                ddl_estado.Enabled = false;

                txt_Nombre.Text = string.Empty;
                ddl_especialidad.Text = ddl_centro.Text = ddl_estado.Text = default(string);
            }
            else
            {
                lbl_cedula.Text = "";
                lbl_cedula.Enabled = false;                
                txt_Nombre.Enabled = true;
                ddl_especialidad.Enabled = true;
                ddl_centro.Enabled = true;
                ddl_estado.Enabled = true;
            }
        }
        
    }
}