using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views_Socio_Economico
{
    public partial class Configuracion : System.Web.UI.Page
    {

        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        private Tbl_Person per = new Tbl_Person();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["Trabajo Social"] != null)
                {
                    int usulogueado = Convert.ToInt32(Session["Trabajo Social"].ToString());
                    per = CN_Usuarios.obtenerUsuariosxId(usulogueado);

                    if (per != null)
                    {
                        string priNom = Session["prinombre"].ToString();
                        string segNom = Session["segnombre"].ToString();
                        string priApe = Session["priapellido"].ToString();
                        string segApe = Session["segapellido"].ToString();
                        string correo = Session["correo"].ToString();
                        string tel = Session["telefono"].ToString();
                        string dir = Session["direccion"].ToString();

                        //---------------------Datos precargados-------------------- -
                        txt_priNombre.Text = priNom;
                        txt_segNombre.Text = segNom;
                        txt_priApellido.Text = priApe;
                        txt_segApellido.Text = segApe;
                        txt_correo.Text = correo;
                        txt_telefono.Text = tel;
                        txt_direccion.Text = dir;

                        // Cargar la imagen del usuario si está disponible
                        if (!string.IsNullOrEmpty(per.Per_imgNombre) && per.Per_imgByte != null)
                        {
                            string base64Image = Convert.ToBase64String(per.Per_imgByte.ToArray());
                            imgPreview.ImageUrl = "data:image/png;base64," + base64Image;
                        }
                    }
                }

                Timer1.Enabled = false;
            }
        }

        private void ActualizarInformacionUsurio(Tbl_Person per)
        {
            try
            {
                if (FileUploadProfilePic.HasFile)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                    string fileExtension = Path.GetExtension(FileUploadProfilePic.FileName).ToLower();

                    if (allowedExtensions.Contains(fileExtension))
                    {
                        string filename = Path.GetFileName(FileUploadProfilePic.FileName);

                        byte[] imageData;
                        using (Stream fs = FileUploadProfilePic.PostedFile.InputStream)
                        {
                            imageData = new byte[fs.Length];
                            fs.Read(imageData, 0, imageData.Length);
                        }

                        // Datos de imagen
                        per.Per_imgNombre = filename;
                        per.Per_imgByte = imageData;
                        //---------------------------

                        per.Per_direccion = txt_direccion.Text;
                        per.Per_telefono = txt_telefono.Text;
                        per.Per_correo = txt_correo.Text;

                        CN_Usuarios.ModificarUsuarios(per);

                        // Mostrar el mensaje de éxito
                        string script = "Swal.fire('Exito!', 'Datos Guardados Exitosamente', 'success');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", script, true);
                        Timer1.Enabled = true;
                    }
                    else
                    {
                        string script = "Swal.fire('Error!', 'Solo se admiten archivos ( .jpg / .jpeg / .png / .gif )', 'error');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", script, true);
                    }
                }
                else
                {
                    per.Per_direccion = txt_direccion.Text;
                    per.Per_telefono = txt_telefono.Text;
                    per.Per_correo = txt_correo.Text;

                    CN_Usuarios.ModificarUsuarios(per);

                    // Mostrar el mensaje de éxito
                    string script = "Swal.fire('Exito!', 'Datos Guardados Exitosamente', 'success');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", script, true);
                    Timer1.Enabled = true;
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "Swal.fire('Error!', 'No se pudo actualizar la informacion del usuario', 'error');", true);
            }
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            Tbl_Person usu = new Tbl_Person();
            int usulogueado = Convert.ToInt32(Session["Trabajo Social"].ToString());
            usu = CN_Usuarios.obtenerUsuariosxId(usulogueado);

            if (usu != null)
            {
                ActualizarInformacionUsurio(usu);
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../../index.aspx");
        }
    }
}