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

        public static List<Sp_Grafico_AntecedentePerResult> Reporte_Sp_Grafico_AntecedentePer()
        {
            var olista = dc.Sp_Grafico_AntecedentePer().ToList();
            return olista.ToList();
        }

        public static List<Tbl_FichasMedicas> ObtenerEnfSinAntecedente()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "0");
            return listaFichMed.ToList();
        }
        public static List<Tbl_FichasMedicas> ObtenerEnfCardioVascular()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "1");
            return listaFichMed.ToList();
        }
        public static List<Tbl_FichasMedicas> ObtenerEnfMetabolica()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "2");
            return listaFichMed.ToList();
        }
        public static List<Tbl_FichasMedicas> ObtenerEnfNeurologica()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "3");
            return listaFichMed.ToList();
        }
        public static List<Tbl_FichasMedicas> ObtenerEnfOncologica()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "4");
            return listaFichMed.ToList();
        }
        public static List<Tbl_FichasMedicas> ObtenerEnfInfecciosa()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "5");
            return listaFichMed.ToList();
        }
        public static List<Tbl_FichasMedicas> ObtenerEnfHereditariaCongonita()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "6");
            return listaFichMed.ToList();
        }
        public static List<Tbl_FichasMedicas> ObtenerEnfDiscapacidad()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "7");
            return listaFichMed.ToList();
        }
        public static List<Tbl_FichasMedicas> ObtenerEnfOtros()
        {
            var listaFichMed = dc.Tbl_FichasMedicas.Where(fich => fich.tipAntecedentePer == "8");
            return listaFichMed.ToList();
        }

        public static List<Tbl_Person> ObtenerPersonasTotal()
        {
            var listaPer = dc.Tbl_Person.Where(per => per.Per_estado == "AP");
            return listaPer.ToList();
        }

    }
}
