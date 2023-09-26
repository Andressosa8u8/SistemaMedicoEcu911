using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador
{
    public partial class Agregar_Instituciones : System.Web.UI.Page
    {

        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Empresa emp = new Tbl_Empresa();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);

                    emp = CN_Empresa.ObtenerEmpresaPorId(codigo);
                    int empresasId = Convert.ToInt32(emp.Emp_id.ToString());
                    emp = CN_Empresa.ObtenerEmpresaPorId(empresasId);

                    btn_guardar.Text = "Actualizar";

                    if (emp != null)
                    {
                        txt_institucion.Text = emp.Emp_nombre.ToString();
                        if (emp.Emp_descripcion == null)
                        {
                            txt_descripcion.Text = "";
                        }
                        else
                        {
                            txt_descripcion.Text = emp.Emp_descripcion.ToString();
                        }                        
                        ddl_estado.Text = emp.Emp_estado.ToString();
                    }
                }
                else
                {
                    ddl_estado.Enabled = false;
                }

                Timer1.Enabled = false;
            }
        }

        private void GuardarInstituciones()
        {
            try
            {
                emp = new Tbl_Empresa();

                emp.Emp_nombre = txt_institucion.Text.ToUpper();
                emp.Emp_descripcion = txt_descripcion.Text.ToUpper();
                emp.Emp_estado = ddl_estado.SelectedValue;

                CN_Empresa.GuardarInstitucion(emp);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Institucion registrada exitosamente', 'success')", true);
                Timer1.Enabled = true;

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'El Paciente No Fue Registrado', 'error')", true);
            }
        }

        private void ModificarInsituciones(Tbl_Empresa emp)
        {
            try
            {
                emp.Emp_nombre = txt_institucion.Text.ToUpper().Trim();
                emp.Emp_descripcion = txt_descripcion.Text.ToUpper().Trim();
                emp.Emp_estado = ddl_estado.SelectedValue;

                CN_Empresa.ModificarInstitucion(emp);


                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos Modificados Exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos No Modificados', 'error')", true);
            }
        }

        private void Guardar_modificar_datos(int empr)
        {
            if (empr == 0)
            {
                GuardarInstituciones();
            }
            else
            {
                emp = CN_Empresa.ObtenerEmpresaPorId(empr);

                if (emp != null)
                {
                    ModificarInsituciones(emp);
                }
            }
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Administrador/Inicio.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Guardar_modificar_datos(Convert.ToInt32(Request["cod"]));
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Administrador/Inicio.aspx");
        }

        protected void txt_institucion_TextChanged(object sender, EventArgs e)
        {
            ExisteInstitucion();
        }

        private void ExisteInstitucion()
        {
            string nombre = txt_institucion.Text;

            var query = from e in dc.Tbl_Empresa
                        where e.Emp_nombre == nombre
                        select e;

            if (query.Any())
            {
                lbl_institucion.Text = "La institucion ya existe !!";
                lbl_institucion.Enabled = true;
                txt_descripcion.Enabled = false;
                ddl_estado.Enabled = false;

                txt_descripcion.Text = string.Empty;
                ddl_estado.Text = default(string);
            }
            else
            {
                lbl_institucion.Text = "";
                lbl_institucion.Enabled = false;
                txt_descripcion.Enabled = true;
                ddl_estado.Enabled = true;
            }
        }
    }
}