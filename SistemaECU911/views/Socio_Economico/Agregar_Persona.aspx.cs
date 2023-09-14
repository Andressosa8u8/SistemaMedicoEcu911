using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views_Socio_Economico
{
    public partial class Personas : System.Web.UI.Page
    {

        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    per = CN_Personas.ObtenerPersonaPorId(codigo);
                    //int personasid = Convert.ToInt32(per.Per_id.ToString());
                    //per = CN_Personas.ObtenerPersonaPorId(personasid);

                    btn_guardar.Text = "Actualizar";

                    if (per != null)
                    {
                        txt_priNombre.Text = per.Per_priNombre.ToString();
                        txt_segNombre.Text = per.Per_segNombre.ToString();
                        txt_priApellido.Text = per.Per_priApellido.ToString();
                        txt_segApellido.Text = per.Per_segApellido.ToString();
                        txt_cedula.Text = per.Per_cedula.ToString();
                        if (per.Per_fechaNacimiento == "")
                        {
                            txt_fechaNacimiento.Text = per.Per_fechaNacimiento.ToString();
                        }
                        else
                        {
                            txt_fechaNacimiento.Text = Convert.ToDateTime(per.Per_fechaNacimiento).ToString("yyyy-MM-dd");
                        }
                        ddl_genero.Text = per.Per_genero.ToString();
                        ddl_zonal.Text = per.Emp_id.ToString();
                        ddl_centro.Text = per.cent_id.ToString();
                        if (per.Per_fechInicioTrabajo == "")
                        {
                            txt_fechaIngresoTrabajo.Text = per.Per_fechInicioTrabajo.ToString();
                        }
                        else
                        {
                            txt_fechaIngresoTrabajo.Text = Convert.ToDateTime(per.Per_fechInicioTrabajo).ToString("yyyy-MM-dd");
                        }
                        ddl_puestoTrabajo.Text = per.Per_puestoTrabajo.ToString();
                        ddl_cargo.Text = per.Per_cargoOcupacion.ToString();
                        ddl_area.Text = per.Per_areaTrabajo.ToString();
                        ddl_estado.Text = per.Per_estado.ToString();//cambiar
                    }
                }
                else
                {
                    txt_priNombre.Enabled = false;
                    txt_segNombre.Enabled = false;
                    txt_priApellido.Enabled = false;
                    txt_segApellido.Enabled = false;
                    txt_fechaNacimiento.Enabled = false;
                    ddl_genero.Enabled = false;
                    ddl_zonal.Enabled = false;
                    ddl_centro.Enabled = false;
                    txt_fechaIngresoTrabajo.Enabled = false;
                    ddl_puestoTrabajo.Enabled = false;
                    ddl_cargo.Enabled = false;
                    ddl_area.Enabled = false;
                    ddl_estado.Enabled = false;
                }
                Timer1.Enabled = false;
                CargarZonales();
                CargarCentros();
                ddl_estado.Text = "AP";
            }
        }

        private void Validaciones()
        {
            ddl_estado.Text = "ACTIVO";
        }

        private void GuardarPersona()
        {
            try
            {
                bool existeCedula = CN_Personas.autentificarxCedula(txt_cedula.Text);

                if (existeCedula)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!','El paciente ya existe !! Verifique el número de cedula', 'error')", true);
                }
                else
                {
                    per = new Tbl_Person();

                    per.Per_priNombre = txt_priNombre.Text.ToUpper();
                    per.Per_segNombre = txt_segNombre.Text.ToUpper();
                    per.Per_priApellido = txt_priApellido.Text.ToUpper();
                    per.Per_segApellido = txt_segApellido.Text.ToUpper();
                    per.Per_cedula = txt_cedula.Text.ToUpper();
                    per.Per_fechaNacimiento = txt_fechaNacimiento.Text.ToUpper();
                    per.Per_genero = ddl_genero.Text.ToUpper();
                    per.Emp_id = Convert.ToInt32(ddl_zonal.Text.ToUpper());
                    per.Per_fechInicioTrabajo = txt_fechaIngresoTrabajo.Text.ToUpper();
                    per.Per_puestoTrabajo = ddl_puestoTrabajo.Text.ToUpper();
                    per.Per_cargoOcupacion = ddl_cargo.Text.ToUpper();
                    per.Per_areaTrabajo = ddl_area.Text.ToUpper();
                    per.Per_estado = ddl_estado.Text.ToUpper();

                    CN_Personas.GuardarPersona(per);

                    //Mensaje de confirmacion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Paciente Registrado Exitosamente', 'success')", true);

                    Response.Redirect("~/Template/Views/Inicio.aspx");
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'El Paciente No Fue Registrado', 'error')", true);
            }
        }

        private void ModificarPersona(Tbl_Person per)
        {
            try
            {
                per.Per_priNombre = txt_priNombre.Text.ToUpper();
                per.Per_segNombre = txt_segNombre.Text.ToUpper();
                per.Per_priApellido = txt_priApellido.Text.ToUpper();
                per.Per_segApellido = txt_segApellido.Text.ToUpper();
                per.Per_cedula = txt_cedula.Text.ToUpper();
                per.Per_fechaNacimiento = txt_fechaNacimiento.Text.ToUpper();
                per.Per_genero = ddl_genero.Text.ToUpper();
                per.Emp_id = Convert.ToInt32(ddl_zonal.SelectedValue);
                per.Per_fechInicioTrabajo = txt_fechaIngresoTrabajo.Text.ToUpper();
                per.Per_puestoTrabajo = ddl_puestoTrabajo.Text.ToUpper();
                per.Per_cargoOcupacion = ddl_cargo.Text.ToUpper();
                per.Per_areaTrabajo = ddl_area.Text.ToUpper();
                per.Per_estado = ddl_estado.SelectedValue;

                CN_Personas.ModificarPersona(per);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Response.Redirect("~/views/Socio_Economico/Inicio.aspx");
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }

        private void Guardar_modificar_datos(int perso)
        {
            if (perso == 0)
            {
                GuardarPersona();
            }
            else
            {
                per = CN_Personas.ObtenerPersonaPorId(perso);

                if (per != null)
                {
                    ModificarPersona(per);
                }
            }
        }
        private void CargarZonales()
        {
            List<Tbl_Empresa> listaEmp = new List<Tbl_Empresa>();
            listaEmp = CN_Personas.ObtenerEmpresa();
            listaEmp.Insert(0, new Tbl_Empresa() { Emp_nombre = "Seleccione...." });

            ddl_zonal.DataSource = listaEmp;
            ddl_zonal.DataTextField = "Emp_nombre";
            ddl_zonal.DataValueField = "Emp_id";
            ddl_zonal.DataBind();

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

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Guardar_modificar_datos(Convert.ToInt32(Request["cod"]));
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Socio_Economico/Inicio.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Socio_Economico/Inicio.aspx");
        }

        protected void txt_cedula_TextChanged(object sender, EventArgs e)
        {
            ExisteCedula();
        }
        private void ExisteCedula()
        {

            string cedula = txt_cedula.Text;

            var query = from c in dc.Tbl_Person
                        where c.Per_cedula == cedula
                        select c;
            if (query.Any())
            {
                lbl_cedula.Text = "El persona ya esta registrada !!!";
                lbl_cedula.Enabled = true;
                txt_priNombre.Enabled = false;
                txt_priApellido.Enabled = false;
                txt_segNombre.Enabled = false;
                txt_segApellido.Enabled = false;
                txt_fechaNacimiento.Enabled = false;
                ddl_genero.Enabled = false;
                ddl_zonal.Enabled = false;
                ddl_centro.Enabled = false;
                txt_fechaIngresoTrabajo.Enabled = false;
                ddl_puestoTrabajo.Enabled = false;
                ddl_cargo.Enabled = false;
                ddl_area.Enabled = false;
                ddl_estado.Enabled = false;
                txt_priNombre.Text = txt_priApellido.Text = txt_segNombre.Text = txt_segApellido.Text = txt_fechaNacimiento.Text = txt_fechaIngresoTrabajo.Text = string.Empty;
                ddl_genero.Text = ddl_zonal.Text = ddl_centro.Text = ddl_puestoTrabajo.Text = ddl_cargo.Text = ddl_area.Text = ddl_estado.Text = default(string);
            }
            else
            {
                lbl_cedula.Text = "";
                lbl_cedula.Enabled = false;
                txt_priNombre.Enabled = true;
                txt_priApellido.Enabled = true;
                txt_segNombre.Enabled = true;
                txt_segApellido.Enabled = true;
                txt_fechaNacimiento.Enabled = true;
                ddl_genero.Enabled = true;
                ddl_zonal.Enabled = true;
                ddl_centro.Enabled = true;
                txt_fechaIngresoTrabajo.Enabled = true;
                ddl_puestoTrabajo.Enabled = true;
                ddl_cargo.Enabled = true;
                ddl_area.Enabled = true;
                ddl_estado.Enabled = true;
            }
        }

        //private void CargarZonales()
        //{
        //    List<Tbl_Empresa> listaEmp = new List<Tbl_Empresa>();
        //    listaEmp = CN_Personas.ObtenerEmpresa();
        //    listaEmp.Insert(0, new Tbl_Empresa() { Emp_zonal = "Seleccione...." });

        //    ddl_zonal.DataSource = listaEmp;
        //    ddl_zonal.DataTextField = "Emp_zonal";
        //    ddl_zonal.DataValueField = "Emp_id";
        //    ddl_zonal.DataBind();
        //}
    }
}