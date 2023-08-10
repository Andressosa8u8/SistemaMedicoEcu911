using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace SistemaECU911.views.Administrador
{
    public partial class Imagen : System.Web.UI.Page
    {

        //private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        //private Tbl_Image img = new Tbl_Image();

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        // Obtener la última imagen guardada desde la base de datos
        //        Tbl_Image lastImage = Class1.ObtenerUltimaImagen();

        //        if (lastImage != null)
        //        {
        //            // Asignar la imagen directamente al control ImageUrl
        //            imgPreview.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(lastImage.img_imagenByte.ToArray());
        //        }
        //    }
        //}

        //protected void btnUpload_Click(object sender, EventArgs e)
        //{
        //    if (FileUploadProfilePic.HasFile)
        //    {
        //        try
        //        {
        //            string filename = Path.GetFileName(FileUploadProfilePic.FileName);

        //            byte[] imageData;
        //            using (Stream fs = FileUploadProfilePic.PostedFile.InputStream)
        //            {
        //                imageData = new byte[fs.Length];
        //                fs.Read(imageData, 0, imageData.Length);
        //            }

        //            img = new Tbl_Image();

        //            img.img_nombre = filename;
        //            img.img_imagenByte = imageData;

        //            Class1.GuardarImagen(img);

        //            // Mostrar el mensaje de éxito
        //            string script = "Swal.fire('Exito!', 'Datos Guardados Exitosamente', 'success');";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", script, true);

        //        }
        //        catch (Exception ex)
        //        {
        //            string script = $"Swal.fire('Error!', 'Error al guardar los datos: {ex.Message}', 'error');";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", script, true);
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "Swal.fire('Error!', 'Seleccione una Imagen', 'error');", true);
        //    }
        //}


        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/views/Administrador/Inicio.aspx");
        //}
    }
}