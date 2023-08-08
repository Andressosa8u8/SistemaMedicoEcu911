using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Class1
    {

        //private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();


        // Metodo para guardar Imagen
        public static void GuardarImagen(Tbl_Image imagen)
        {
            try
            {
                imagen.img_estado = "A";
                dc.Tbl_Image.InsertOnSubmit(imagen);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique la imagen" + ex.Message);
            }
        }

        public static Tbl_Image ObtenerUltimaImagen()
        {
            try
            {
                // Obtener la última imagen guardada (puedes ajustar el criterio según tu estructura de datos)
                Tbl_Image lastImage = dc.Tbl_Image.OrderByDescending(i => i.img_id).FirstOrDefault();
                return lastImage;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener la última imagen: " + ex.Message);
            }
        }

    }
}
