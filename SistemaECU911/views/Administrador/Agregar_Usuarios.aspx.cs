using CapaDatos;
using CapaNegocio;
using Org.BouncyCastle.Math;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Numerics;
using System.IO;

namespace SistemaECU911.views.Administrador
{
    public partial class Agregar_Usuarios : System.Web.UI.Page
    {
        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();
        private Tbl_TipoUsuario tipUsu = new Tbl_TipoUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    per = CN_Personas.ObtenerPersonaPorId(codigo);

                    btn_guardar.Text = "Actualizar";
                    txt_cedula.ReadOnly = true;
                    ddl_tipoUsuario.Enabled = false;

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
                        ddl_estado.Text = per.Per_estado.ToString();
                        ddl_tipoUsuario.Text = per.tusu_id.ToString();
                        txt_usuario.Text = per.Per_nomlogin.ToString();
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

                    txt_usuario.Enabled = false;
                    txt_pass.Enabled = false;
                }

                Timer1.Enabled = false;
                CargarInstitucion();
                CargarCentros();
                CargarTipoUsuario();
                txt_cedula.MaxLength = 10;
            }
        }

        private void GuardarPersona()
        {
            try
            {
                per = new Tbl_Person();

                if (Convert.ToInt32(ddl_tipoUsuario.SelectedValue) == 3)
                {
                    per.tusu_id = 3;
                    per.Per_cedula = txt_cedula.Text.ToUpper();

                    per.Per_priNombre = txt_priNombre.Text.ToUpper();
                    per.Per_segNombre = txt_segNombre.Text.ToUpper();
                    per.Per_priApellido = txt_priApellido.Text.ToUpper();
                    per.Per_segApellido = txt_segApellido.Text.ToUpper();
                    per.Per_cedula = txt_cedula.Text.ToUpper();
                    per.Per_fechaNacimiento = txt_fechaNacimiento.Text.ToUpper();
                    per.Per_genero = ddl_genero.Text.ToUpper();
                    per.Emp_id = Convert.ToInt32(ddl_zonal.Text.ToUpper());
                    per.cent_id = Convert.ToInt32(ddl_centro.Text.ToUpper());
                    per.Per_fechInicioTrabajo = txt_fechaIngresoTrabajo.Text.ToUpper();
                    per.Per_puestoTrabajo = ddl_puestoTrabajo.Text.ToUpper();
                    per.Per_cargoOcupacion = ddl_cargo.Text.ToUpper();
                    per.Per_areaTrabajo = ddl_area.Text.ToUpper();
                    per.Per_estado = ddl_estado.Text.ToUpper();

                    per.Per_nomlogin = txt_cedula.Text.ToUpper();
                    per.Per_pass = GetMD5(txt_pass.Text);
                }
                else
                {
                    per.tusu_id = Convert.ToInt32(ddl_tipoUsuario.SelectedValue);
                    per.Per_cedula = txt_cedula.Text.ToUpper();

                    per.Per_priNombre = txt_priNombre.Text.ToUpper();
                    per.Per_segNombre = txt_segNombre.Text.ToUpper();
                    per.Per_priApellido = txt_priApellido.Text.ToUpper();
                    per.Per_segApellido = txt_segApellido.Text.ToUpper();
                    per.Per_cedula = txt_cedula.Text.ToUpper();
                    per.Per_fechaNacimiento = txt_fechaNacimiento.Text.ToUpper();
                    per.Per_genero = ddl_genero.Text.ToUpper();
                    per.Emp_id = Convert.ToInt32(ddl_zonal.Text.ToUpper());
                    per.cent_id = Convert.ToInt32(ddl_centro.Text.ToUpper());
                    per.Per_fechInicioTrabajo = txt_fechaIngresoTrabajo.Text.ToUpper();
                    per.Per_puestoTrabajo = ddl_puestoTrabajo.Text.ToUpper();
                    per.Per_cargoOcupacion = ddl_cargo.Text.ToUpper();
                    per.Per_areaTrabajo = ddl_area.Text.ToUpper();
                    per.Per_estado = ddl_estado.Text.ToUpper();

                    per.Per_nomlogin = txt_usuario.Text;
                    per.Per_pass = GetMD5(txt_pass.Text);
                }

                CN_Personas.GuardarPersona(per);

                //Mensaje de confirmacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Usuario registrado exitosamente', 'success')", true);
                Timer1.Enabled = true;


            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'La usuario no fue registrado', 'error')", true);
            }
        }

        private void ModificarPersona(Tbl_Person per)
        {
            try
            {
                //Datos Update Tbl_Person
                per.tusu_id = Convert.ToInt32(ddl_tipoUsuario.SelectedValue);


                per.Per_priNombre = txt_priNombre.Text.ToUpper();
                per.Per_segNombre = txt_segNombre.Text.ToUpper();
                per.Per_priApellido = txt_priApellido.Text.ToUpper();
                per.Per_segApellido = txt_segApellido.Text.ToUpper();
                per.Per_cedula = txt_cedula.Text.ToUpper();
                per.Per_fechaNacimiento = txt_fechaNacimiento.Text.ToUpper();
                per.Per_genero = ddl_genero.Text.ToUpper();
                per.Emp_id = Convert.ToInt32(ddl_zonal.SelectedValue);
                per.cent_id = Convert.ToInt32(ddl_centro.SelectedValue);
                per.Per_fechInicioTrabajo = txt_fechaIngresoTrabajo.Text.ToUpper();
                per.Per_puestoTrabajo = ddl_puestoTrabajo.Text.ToUpper();
                per.Per_cargoOcupacion = ddl_cargo.Text.ToUpper();
                per.Per_areaTrabajo = ddl_area.Text.ToUpper();
                per.Per_estado = ddl_estado.SelectedValue;

                per.Per_nomlogin = txt_usuario.Text;
                per.Per_pass = GetMD5(txt_pass.Text);

                CN_Personas.ModificarPersona(per);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Exito!', 'Datos modificados exitosamente', 'success')", true);
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Datos no modificados', 'error')", true);
            }
        }

        protected void ddl_tipoUsuario_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_tipoUsuario.SelectedValue) == 3 && txt_cedula.Text != null)
            {
                var cedula = txt_cedula.Text;

                txt_usuario.Text = cedula;
                txt_usuario.Enabled = false;
                txt_pass.Text = cedula;
                txt_pass.Enabled = false;
            }
            else
            {
                txt_usuario.Enabled = true;
                txt_pass.Enabled = true;

                txt_usuario.Text = txt_pass.Text = string.Empty;
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

        private void CargarInstitucion()
        {
            // Consulta LINQ para obtener la lista de empresas
            var query = from empresa in dc.Tbl_Empresa
                        orderby empresa.Emp_nombre
                        select new
                        {
                            empresa.Emp_id,
                            empresa.Emp_nombre
                        };

            // Asigna la lista de empresas al DropDownList
            ddl_zonal.DataSource = query.ToList();
            ddl_zonal.DataTextField = "Emp_nombre";
            ddl_zonal.DataValueField = "Emp_id";
            ddl_zonal.DataBind();

            // Elemento predeterminado Seleccione ....
            ddl_zonal.Items.Insert(0, new ListItem("Seleccione....", "0"));

        }

        private void CargarCentros()
        {
            // Consulta LINQ para obtener la lista de centros
            var query = from c in dc.Tbl_Centro
                        orderby c.cent_nombre
                        select new
                        {
                            c.cent_id,
                            c.cent_nombre
                        };

            // Asigna la lista de centros al DropDownList
            ddl_centro.DataSource = query.ToList();
            ddl_centro.DataTextField = "cent_nombre";
            ddl_centro.DataValueField = "cent_id";
            ddl_centro.DataBind();

            // Elemento predeterminado Seleccione ...
            ddl_centro.Items.Insert(0, new ListItem("Seleccione....", "0"));

        }

        public void CargarTipoUsuario()
        {
            var query = from tp in dc.Tbl_TipoUsuario
                        orderby tp.tusu_nombre
                        select new
                        {
                            tp.tusu_id,
                            tp.tusu_nombre
                        };

            // Asigna la lista de centros al DropDownList
            ddl_tipoUsuario.DataSource = query.ToList();
            ddl_tipoUsuario.DataTextField = "tusu_nombre";
            ddl_tipoUsuario.DataValueField = "tusu_id";
            ddl_tipoUsuario.DataBind();

            // Elemento predeterminado Seleccione ...
            ddl_tipoUsuario.Items.Insert(0, new ListItem("Seleccione....", "0"));
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Guardar_modificar_datos(Convert.ToInt32(Request["cod"]));
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrador/Inicio.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Administrador/Inicio.aspx");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
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
                lbl_cedula.Text = "La persona ya existe !!!";
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

                txt_usuario.Enabled = false;
                txt_pass.Enabled = false;

                txt_priNombre.Text = txt_priApellido.Text = txt_segNombre.Text = txt_segApellido.Text = txt_fechaNacimiento.Text = txt_fechaIngresoTrabajo.Text = string.Empty;
                ddl_genero.Text = ddl_zonal.Text = ddl_centro.Text = ddl_puestoTrabajo.Text = ddl_cargo.Text = ddl_area.Text = ddl_estado.Text = default(string);
            
            } else if (txt_cedula.Text == "")
            {
                lbl_cedula.Text = "";
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

                txt_usuario.Enabled = false;
                txt_pass.Enabled = false;

                txt_priNombre.Text = txt_priApellido.Text = txt_segNombre.Text = txt_segApellido.Text = txt_fechaNacimiento.Text = txt_fechaIngresoTrabajo.Text = string.Empty;
                ddl_genero.Text = ddl_zonal.Text = ddl_centro.Text = ddl_puestoTrabajo.Text = ddl_cargo.Text = ddl_area.Text = ddl_estado.Text = default(string);
            
            } else if (txt_cedula.Text.Length == 10)
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

                txt_usuario.Enabled = true;
                txt_pass.Enabled = true;
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