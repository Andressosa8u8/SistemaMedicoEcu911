using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Administrador
    {
        private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        public static Tbl_Especialidad ObtenerEspecialidadPorId(int id)
        {
            var espeid = dc.Tbl_Especialidad.FirstOrDefault(espe => espe.espec_id.Equals(id));
            return espeid;
        }

        // Metodo para guardar datos de las especialidades
        public static void GuardarEspecialidad(Tbl_Especialidad espe)
        {
            try
            {
                dc.Tbl_Especialidad.InsertOnSubmit(espe);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique los datos de la especialidad" + ex.Message);
            }
        }

        // Metodo para modificar datos de las especialidades
        public static void ModificarEspecialidad(Tbl_Especialidad espe)
        {
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique los datos de la especialidad" + ex.Message);
            }
        }
    }
}
