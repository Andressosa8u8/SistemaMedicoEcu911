using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class PurebaEncabezado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_descargarImagen.Attributes["onclick"] = "cropImage(); downloadImage();";
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentType == "image/png")
            {
                string fileName = "ImagenEncabezado.png";
                string filePath = Server.MapPath("../../resources/images/encabezado/" + fileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Guardar la nueva imagen
                FileUpload1.SaveAs(filePath);

                // Mostrar la nueva imagen en el control de imagen
                UploadedImageView.ImageUrl = "../../resources/images/encabezado/" + fileName;

                // Limpiar el lienzo de fabric.js después de guardar la imagen
                ClientScript.RegisterStartupScript(this.GetType(), "clearCanvas", "clearCanvas();", true);
            }
        }
    }
}