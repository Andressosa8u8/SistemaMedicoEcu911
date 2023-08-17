using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.views.Administrador_Medico
{
    public partial class Lista_Cantidad_Puesto_Trabajo : System.Web.UI.Page
    {
        DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }
        private void obtenerDatos()
        {
            //string puestoTrabajo = ddl_puestoTrabajo.Text;
            int centro = Convert.ToInt32(ddl_centro.SelectedValue);

            var query = from per in dc.Tbl_Person
                        where per.cent_id == centro
                        group per by new { per.Per_puestoTrabajo, per.cent_id } into g
                        select new
                        {
                            per_ids = g.Max(f => f.Per_id),
                            Per_puestoTrabajos = g.Key.Per_puestoTrabajo,
                            cent_ids = g.Key.cent_id == 1 ? "ECU QUITO" :
                                       g.Key.cent_id == 2 ? "ECU 911 CUENCA" :
                                       g.Key.cent_id == 3 ? "ECU 911 PORTOVIEJO" :
                                       g.Key.cent_id == 4 ? "ECU 911 MACHALA" :
                                       g.Key.cent_id == 5 ? "ECU 911 IBARRA" :
                                       g.Key.cent_id == 6 ? "ECU 911 AMBATO" :
                                       g.Key.cent_id == 7 ? "ECU 911 ESMERALDAS" :
                                       g.Key.cent_id == 8 ? "ECU 911 TULCAN" :
                                       g.Key.cent_id == 9 ? "ECU 911 NUEVA LOJA" :
                                       g.Key.cent_id == 10 ? "ECU 911 SANTO DOMINGO " :
                                       g.Key.cent_id == 11 ? "ECU 911 RIOBAMBA" :
                                       g.Key.cent_id == 12 ? "ECU 911 LOJA" :
                                       g.Key.cent_id == 13 ? "ECU 911 BABAHOYO" :
                                       g.Key.cent_id == 14 ? "ECU 911 MACAS" :
                                       g.Key.cent_id == 15 ? "ECU 911 SAN CRISTOBAL" :
                                       g.Key.cent_id == 16 ? "ECU 911 SAMBORONDON" :
                                       "SIN CENTRO",
                            valor = g.Count()
                        };
            grvDatos.DataSource = query.ToList();
            grvDatos.DataBind();
        }

        protected void btn_calcular_Click(object sender, EventArgs e)
        {
            obtenerDatos();
        }
    }
}