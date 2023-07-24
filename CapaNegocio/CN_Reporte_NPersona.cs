using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Reporte_NPersona
    {
        private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        public static List<Sp_Npersona_puestoTrabajoResult> Reporte_NPersona()
        {
            var olista = dc.Sp_Npersona_puestoTrabajo();
            return olista.ToList();
        }

        public static List<Sp_Grafico_OrganosYSistemasResult> Reporte_Sp_Grafico_OrganosYSistemas()
        {
            var olista = dc.Sp_Grafico_OrganosYSistemas().ToList();
            return olista.ToList();
        }
    }
}
