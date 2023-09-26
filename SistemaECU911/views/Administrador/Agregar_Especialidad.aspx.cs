using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador
{
    public partial class Agregar_Especialidad : System.Web.UI.Page
    {
        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Especialidad espe = new Tbl_Especialidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    espe = CN_Administrador.ObtenerEspecialidadPorId(codigo);

                    btn_guardar.Text = "Actualizar";

                    if (espe != null)
                    {
                        txt_especialidad.Text = espe.espec_nombre.ToString();                     
                        ddl_estado.Text = espe.espec_estado.ToString();                     
                    }
                }
                else
                {
                    ddl_estado.Enabled = false;
                }   

                Timer1.Enabled = false;
            }
        }

        private void GuardarEspecialidad()
        {
            try
            {
                espe = new Tbl_Especialidad();

                //Datos Tbl_Especialidad
                espe.espec_nombre = txt_especialidad.Text.ToUpper();
                espe.espec_estado = ddl_estado.Text.ToUpper();

                CN_Administrador.GuardarEspecialidad(espe);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Especialidad registrada exitosamente', 'success')", true);
                Timer1.Enabled = true;


            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'La especialidad no fue registrada', 'error')", true);
            }
        }

        private void ModificarEspecialidad(Tbl_Especialidad espe)
        {
            try
            {
                //Datos Update Tbl_Especialidad
                espe.espec_nombre = txt_especialidad.Text.ToUpper();                
                espe.espec_estado = ddl_estado.SelectedValue;

                CN_Administrador.ModificarEspecialidad(espe);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos modificados exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos no modificados', 'error')", true);
            }
        }

        private void Guardar_modificar_datos(int espec)
        {
            if (espec == 0)
            {
                GuardarEspecialidad();
            }
            else
            {
                espe = CN_Administrador.ObtenerEspecialidadPorId(espec);

                if (espe != null)
                {
                    ModificarEspecialidad(espe);
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrador/Inicio.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Guardar_modificar_datos(Convert.ToInt32(Request["cod"]));
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrador/Inicio.aspx");
        }        

        protected void txt_especialidad_TextChanged(object sender, EventArgs e)
        {
            ExisteEspecialidad();
        }

        private void ExisteEspecialidad()
        {

            string especialidad = txt_especialidad.Text;

            var query = from e in dc.Tbl_Especialidad
                        where e.espec_nombre == especialidad
                        select e;

            if (query.Any())
            {
                lbl_especialidad.Text = "La especialidad ya existe !!!";
                lbl_especialidad.Enabled = true;               
                ddl_estado.Enabled = false;

                ddl_estado.Text = default(string);
            }
            else
            {
                lbl_especialidad.Text = "";
                lbl_especialidad.Enabled = false;              
                ddl_estado.Enabled = true;
            }
        }

    }
}