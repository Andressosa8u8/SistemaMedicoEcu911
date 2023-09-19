using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Profesionales
    {
        private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        public static Tbl_Profesional ObtenerProfesionalPorId(int id)
        {
            var perid = dc.Tbl_Profesional.FirstOrDefault(per => per.prof_id.Equals(id));
            return perid;
        }
        public static bool autentificarxCedula(string cedula)
        {
            var cedu = dc.Tbl_Profesional.Any(pro => pro.prof_estado == "A" && pro.prof_cedula.Equals(cedula));
            return cedu;
        }
        // Metodo para guardar datos de los profesionales
        public static void GuardarProfesional(Tbl_Profesional pro)
        {
            try
            {
                dc.Tbl_Profesional.InsertOnSubmit(pro);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique los datos de la persona" + ex.Message);
            }
        }
        // Metodo para modificar datos de las personas
        public static void ModificarPersona(Tbl_Profesional pro)
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
    }
}
