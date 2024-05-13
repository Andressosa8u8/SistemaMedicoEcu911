using CapaDatos;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECU911.Template.Views
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private readonly DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Timer1.Enabled = false;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/views/Administrador_Medico/Inicio.aspx");
        }

        //Metodo obtener cedula por numero de historia clinica
        [WebMethod]
        [ScriptMethod]
        public static List<string> ObtenerNumHClinica(string prefixText)
        {
            List<string> lista = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("select top(10) Per_cedula from Tbl_Person where Per_cedula LIKE + @Cedula + '%'", con);
                cmd.Parameters.AddWithValue("@Cedula", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                IDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(lector.GetString(0));
                }

                lector.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        protected void txt_cedula_TextChanged(object sender, EventArgs e)
        {
            ObtenerCedula();
        }

        private void ObtenerCedula()
        {
            string cedula = txt_cedula.Text;

            if (!string.IsNullOrEmpty(cedula))
            {
                var query = from c in dc.Tbl_Person
                            where c.Per_cedula == cedula
                            select c.Per_id;

                int personaid = query.FirstOrDefault(); // Aquí obtenemos el primer ID que cumple con la condición

                if (personaid != 0)
                {
                    var lista = from c in dc.Tbl_Person
                                where c.Per_cedula == cedula
                                select new
                                {                                   
                                    c.Per_priNombre,
                                    c.Per_segNombre,
                                    c.Per_priApellido,
                                    c.Per_segApellido,  
                                };

                    if (lista.Any())
                    {
                        foreach (var item in lista)
                        {
                            string priNombre = item.Per_priNombre;
                            txt_priNombre.Text = priNombre;

                            string segNombre = item.Per_segNombre;
                            txt_segNombre.Text = segNombre;

                            string priApellido = item.Per_priApellido;
                            txt_priApellido.Text = priApellido;

                            string segApellido = item.Per_segApellido;
                            txt_segApellido.Text = segApellido;

                        }
                    }
                    else
                    {
                        Limpiar();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarSweetAlertSSO1", "swal('No se pudo encontrar a la persona ingresada.', 'Digitalice correctamente la cédula', 'warning')", true);
                    Limpiar();
                }
            }
        }

        private void Limpiar()
        {
           txt_cedula.Text = txt_priNombre.Text = txt_segNombre.Text = txt_priApellido.Text = txt_segApellido.Text = string.Empty;
        }

        //Metodo obtener codigo cie10
        [WebMethod]
        [ScriptMethod]
        public static List<string> ObtenerCie10(string prefixText)
        {
            List<string> lista = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("select top(10) dec10 from cie10 where dec10 LIKE + @Name + '%'", con);
                cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                IDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(lector.GetString(0));
                }

                lector.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        protected void txt_diagnostico_TextChanged(object sender, EventArgs e)
        {
            ObtenerCodigo();
        }

        private void ObtenerCodigo()
        {
            string descripcion = txt_diagnostico.Text;

            var lista = from c in dc.cie10
                        where c.dec10 == descripcion
                        select c;

            foreach (var item in lista)
            {
                string codigo = item.id10;
                txt_cie.Text = codigo;
            }
        }

        protected void btnCertificado_Click(object sender, EventArgs e)
        {
            string nombre = txt_priNombre.Text + " " + txt_segNombre.Text + " " + txt_priApellido.Text + " " + txt_segApellido.Text;
            HtmlNode.ElementsFlags["img"] = HtmlElementFlag.Closed;
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Closed;
            Document pdfDoc = new Document(PageSize.A4, 41f, 41f, 20f, 20f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            BaseFont fuente = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font titulo = new Font(fuente, 14f, Font.BOLD, new BaseColor(0, 0, 0));
            BaseFont fuente2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font parrafo = new Font(fuente2, 12f, Font.NORMAL, new BaseColor(0, 0, 0));
            BaseFont fuente3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font cuadro = new Font(fuente3, 10f, Font.NORMAL, new BaseColor(0, 0, 0));

            pdfDoc.Open();
            string imageURL = Server.MapPath("../../resources/images") + "/Encabezado.png";
            iTextSharp.text.Image bandera = iTextSharp.text.Image.GetInstance(imageURL);
            bandera.ScaleAbsolute(510, 50);
            pdfDoc.Add(bandera);
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Quito, " + DateTime.Now.ToString("dd 'de' MMMM 'del' yyyy "), parrafo) { Alignment = Element.ALIGN_RIGHT });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("CERTIFICADO MÉDICO", titulo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Por medio de la presente certifico haber atendido al señor "
                + nombre + " con número de cédula " + txt_cedula.Text + ", con número de Historia Clinica "
                + txt_cedula.Text + ", domiciliado en el sector " + txt_Domicilio.Text + ", telefono "
                + txt_Telefono.Text + ", paciente fue atendido en el dispensario médico institucional por presentar "
                + txt_Atencion.Text + ", el antes mencionado se desempeña como " + txt_Cargo.Text + " en " + txt_Institución.Text + "", parrafo)
            { Alignment = Element.ALIGN_JUSTIFIED });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            if (ddl_tipoContingencia.SelectedItem.Value == "0")
            {
                pdfDoc.Add(new Paragraph("Tipo de contingencia: " + "", parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
            }
            else
            {
                pdfDoc.Add(new Paragraph("Tipo de contingencia: " + ddl_tipoContingencia.SelectedItem, parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
            }

            //pdfDoc.Add(new Paragraph("Tipo de contingencia: " + ddl_tipoContingencia.SelectedItem, parrafo) { Alignment = Element.ALIGN_JUSTIFIED });            
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Diagnóstico: " + txt_diagnostico.Text + "  " + "CIE 10: " + txt_cie.Text, parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Por lo expuesto requiere:", parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph(txt_recomendacion.Text, parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Es todo en cuanto puedo certificar en honor a la verdad.", parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Atentamente,", parrafo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Dra.Francy Helena Cobos Figueroa", parrafo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Paragraph("Médico General", parrafo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Paragraph("1711131415", parrafo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Paragraph("cobitos2002.fc@gmail.com", parrafo) { Alignment = Element.ALIGN_CENTER });
            string imageURL2 = Server.MapPath("../../resources/images") + "/Pie_pagina.png";
            iTextSharp.text.Image footer = iTextSharp.text.Image.GetInstance(imageURL2);
            footer.ScaleAbsolute(520, 50);
            footer.SetAbsolutePosition(41f, 5f);
            pdfDoc.Add(footer);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Certificado_Médico_" + txt_cedula.Text + "_" + DateTime.Today + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

    }   
    
}