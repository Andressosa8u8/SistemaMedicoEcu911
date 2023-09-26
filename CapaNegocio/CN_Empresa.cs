using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Empresa
    {
        private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();

        public static Tbl_Empresa ObtenerEmpresaPorId(int id)
        {
            var empid = dc.Tbl_Empresa.FirstOrDefault(emp => emp.Emp_id.Equals(id));
            return empid;
        }

        public static void GuardarInstitucion(Tbl_Empresa emp)
        {
            try
            {
                dc.Tbl_Empresa.InsertOnSubmit(emp);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique los datos de la institucion" + ex.Message);
            }
        }
        // Metodo para modificar datos de las personas
        public static void ModificarInstitucion(Tbl_Empresa emp)
        {
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Verifique los datos de la institucion" + ex.Message);
            }
        }
    }
}
