using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using CapaDatos;
using CapaNegocio;

namespace SistemaECU911
{
    public partial class index : System.Web.UI.Page
    {

        private static int con = 1;

        //Instanciamos la BD
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Timer1.Enabled = false;
            }
            Session["con"] = Session["Conantiguo"];
        }

        private void logear()
        {
            bool existeUsu = CN_Usuarios.autentificarxUsuario(txt_user.Text);
            bool existeUsuPass = CN_Usuarios.autentificarUsuarioPassword(txt_user.Text, GetMD5(txt_pass.Text));
            {
                if (String.IsNullOrEmpty(txt_user.Text) || String.IsNullOrEmpty(txt_pass.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Complete los campos', 'error')", true);
                }
                else
                {
                    if (existeUsu)
                    {
                        if (existeUsuPass)
                        {
                            Tbl_Person person = new Tbl_Person();
                            Tbl_TipoUsuario tusu = new Tbl_TipoUsuario();

                            person = CN_Usuarios.autentificarxUnicoUsuPass(txt_user.Text, GetMD5(txt_pass.Text));
                            int rol = Convert.ToInt32(person.tusu_id.ToString());
                            tusu = CN_TipoUsuario.obtenerTusuarioxUsuario(Convert.ToInt32(rol));
                            int tusuario = Convert.ToInt32(person.tusu_id);
                            if (tusuario == 1)
                            {
                                Session["Administrador"] = person.Per_id.ToString();
                                Session["prinombre"] = person.Per_priNombre.ToString();
                                Session["segnombre"] = person.Per_segNombre.ToString();
                                Session["priapellido"] = person.Per_priApellido.ToString();
                                Session["segapellido"] = person.Per_segApellido.ToString();                                
                                Session["rol"] = tusu.tusu_nombre.ToString();

                                //--------------------Datos Cambiar Usuario--------------------

                                Session["correo"] = person.Per_correo.ToString();
                                Session["telefono"] = person.Per_telefono.ToString();
                                Session["direccion"] = person.Per_direccion.ToString();

                                Response.Redirect("~/views/Administrador/Inicio.aspx");
                                limpiar();
                            }
                            else if (tusuario == 2)
                            {
                                Session["Medico"] = person.Per_id.ToString();
                                Session["prinombre"] = person.Per_priNombre.ToString();
                                Session["segnombre"] = person.Per_segNombre.ToString();
                                Session["priapellido"] = person.Per_priApellido.ToString();
                                Session["segapellido"] = person.Per_segApellido.ToString();
                                Session["rol"] = tusu.tusu_nombre.ToString();

                                //--------------------Datos Cambiar Usuario--------------------

                                Session["correo"] = person.Per_correo.ToString();
                                Session["telefono"] = person.Per_telefono.ToString();
                                Session["direccion"] = person.Per_direccion.ToString();

                                Response.Redirect("~/views/Administrador_Medico/Inicio.aspx");
                                limpiar();
                            }
                            else if (tusuario == 3)
                            {
                                Session["Paciente"] = person.Per_id.ToString();
                                Session["Cedula"] = person.Per_cedula.ToString();
                                Session["prinombre"] = person.Per_priNombre.ToString();
                                Session["segnombre"] = person.Per_segNombre.ToString();
                                Session["priapellido"] = person.Per_priApellido.ToString();
                                Session["segapellido"] = person.Per_segApellido.ToString();
                                Session["rol"] = tusu.tusu_nombre.ToString();

                                //--------------------Datos Cambiar Usuario--------------------

                                Session["correo"] = person.Per_correo.ToString();
                                Session["telefono"] = person.Per_telefono.ToString();
                                Session["direccion"] = person.Per_direccion.ToString();
                                
                                Response.Redirect("~/views/Pacientes/Inicio.aspx");
                                limpiar();
                            }
                            else if (tusuario == 4)
                            {
                                Session["Trabajo Social"] = person.Per_id.ToString();
                                Session["prinombre"] = person.Per_priNombre.ToString();
                                Session["segnombre"] = person.Per_segNombre.ToString();
                                Session["priapellido"] = person.Per_priApellido.ToString();
                                Session["segapellido"] = person.Per_segApellido.ToString();
                                Session["rol"] = tusu.tusu_nombre.ToString();

                                //--------------------Datos Cambiar Usuario--------------------

                                Session["correo"] = person.Per_correo.ToString();
                                Session["telefono"] = person.Per_telefono.ToString();
                                Session["direccion"] = person.Per_direccion.ToString();
                                
                                Response.Redirect("~/views/Socio_Economico/Inicio.aspx");
                                limpiar();
                            }
                        }
                        else
                        {
                            string intentos = (con + (Convert.ToInt32(Session["con"]))).ToString();
                            Session["Conantiguo"] = intentos.ToString();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'Credenciales Incorrectas! Intento #" + intentos + "', 'error')", true);
                            txt_pass.Text = "";
                            if (Convert.ToInt32(intentos) == 3)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'A superado el limite de intentos', 'error')", true);
                                btn_ingresar.Visible = false;
                                Session.RemoveAll();
                                Timer1.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "swal('Error!', 'El usuario no existe', 'error')", true);
                        limpiar();
                    }
                }
                
            }
        }

        protected void btn_ingresar_Click(object sender, EventArgs e)
        {
            logear();
        }

        private void limpiar()
        {
            txt_user.Text = txt_pass.Text = "";
        }

        string encriptar(string cadena)
        {
            string resultado = string.Empty;
            byte[] encriptar = System.Text.Encoding.Unicode.GetBytes(cadena);
            resultado = Convert.ToBase64String(encriptar);
            return resultado;
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("Autentificacion/Recuperar.aspx");
        }
        
    }
}