using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Personas
    {

        private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        //metodo traer para todos los usuarios x ID
        public static Tbl_Person obtenerPersonasxCedula(string ced)
        {
            var usuid = dc.Tbl_Person.FirstOrDefault(per => per.Per_cedula.Equals(ced) && per.Per_estado == "AP");
            return usuid;
        }

        public static Tbl_Person ObtenerPersonaPorId(int id)
        {
            var perid = dc.Tbl_Person.FirstOrDefault(per => per.Per_id.Equals(id));
            return perid;
        }

        //metodo para traer empresa
        public static List<Tbl_Empresa> ObtenerEmpresa()
        {
            var lista = dc.Tbl_Empresa.Where(prof => prof.Emp_estado == "A");
            return lista.ToList();
        }
        public static List<Tbl_Centro> ObtenerCentros()
        {
            var lista = dc.Tbl_Centro.Where(prof => prof.cent_estado == "A");
            return lista.ToList();
        }

        //metodo para verificar si existe la cedula
        public static bool autentificarxCedula(string cedula)
        {
            var cedu = dc.Tbl_Person.Any(per => per.Per_estado == "AP" && per.Per_cedula.Equals(cedula));
            return cedu;
        }

        // Metodo para guardar datos de las persona
        public static void GuardarPersona(Tbl_Person per)
        {
            try
            {
                dc.Tbl_Person.InsertOnSubmit(per);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique los datos de la persona" + ex.Message);
            }
        }

        // Metodo para modificar datos de las personas
        public static void ModificarPersona(Tbl_Person per)
        {
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique los datos de la persona" + ex.Message);
            }
        }

        // Metodo para imagen
        //public static void GuardarImagen(Tbl_Image img)
        //{
        //    try
        //    {
        //        img.img_estado = "A";
        //        dc.Tbl_Image.InsertOnSubmit(img);
        //        dc.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Verifique los datos de la imagen" + ex.Message);
        //    }
        //}

    }
}
