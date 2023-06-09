using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using HtmlAgilityPack;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Configuration;
using CapaNegocio;

namespace SistemaECU911.Template.Views
{
    public partial class Certificado_Covid : System.Web.UI.Page
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
            Response.Redirect("~/Template/Views/Inicio.aspx");
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
                SqlCommand cmd = new SqlCommand("select top(10) Per_Cedula from Tbl_Personas where Per_Cedula LIKE + @Cedula + '%'", con);
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

            var lista = from c in dc.Tbl_Person
                        where c.Per_cedula == cedula
                        select c;

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
            Font titulo = new Font(fuente, 13f, Font.BOLD, new BaseColor(0, 0, 0));
            BaseFont fuente2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font parrafo = new Font(fuente2, 11f, Font.NORMAL, new BaseColor(0, 0, 0));
            BaseFont fuente3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, true);
            Font cuadro = new Font(fuente3, 10f, Font.NORMAL, new BaseColor(0, 0, 0));

            pdfDoc.Open();
            string imageURL = Server.MapPath("../Template Principal/images") + "/Bandera.PNG";
            iTextSharp.text.Image bandera = iTextSharp.text.Image.GetInstance(imageURL);
            bandera.ScaleAbsolute(510, 50);
            pdfDoc.Add(bandera);
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Quito, " + DateTime.Now.ToString("dd 'de' MMMM 'del' yyyy "), parrafo) { Alignment = Element.ALIGN_RIGHT });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("CERTIFICADO MÉDICO", titulo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Por medio de la presente certifico haber atendido al señor "
                + nombre + " con número de cédula " + txt_cedula.Text + ", con número de Historia Clinica "
                + txt_cedula.Text + ", domiciliado en el sector " + txt_Domicilio.Text + ", telefono "
                + txt_Telefono.Text + ", paciente fue atendido en el dispensario médico institucional por presentar "
                + txt_Atencion.Text + ", el antes mencionado se desempeña como " + txt_Cargo.Text + " en " + txt_Institución.Text + ".", parrafo)
            { Alignment = Element.ALIGN_JUSTIFIED });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Tipo de contingencia: " + ddl_tipoContingencia.SelectedItem, parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
            pdfDoc.Add(new Paragraph("Diagnóstico: " + txt_diagnostico.Text + "  " + "CIE 10: " + txt_cie.Text, parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            var tblopciones = new PdfPTable(new float[] { 40f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_LEFT };
            tblopciones.AddCell(new PdfPCell(new Paragraph("Teletrabajo", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblopciones.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            if (ckb_teletrabajo.Checked == true)
            {
                tblopciones.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            else
            {
                tblopciones.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            tblopciones.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            if (ckb_teletrabajo.Checked == false)
            {
                tblopciones.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            else
            {
                tblopciones.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            pdfDoc.Add(tblopciones);

            var tblopciones2 = new PdfPTable(new float[] { 40f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_LEFT };
            tblopciones2.AddCell(new PdfPCell(new Paragraph("Enfermedad", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblopciones2.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            if (ckb_enfermedad.Checked == true)
            {
                tblopciones2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            else
            {
                tblopciones2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            tblopciones2.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            if (ckb_enfermedad.Checked == false)
            {
                tblopciones2.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            else
            {
                tblopciones2.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            pdfDoc.Add(tblopciones2);

            var tblopciones3 = new PdfPTable(new float[] { 40f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_LEFT };
            tblopciones3.AddCell(new PdfPCell(new Paragraph("Reposo:", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblopciones3.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            if (ckb_reposo.Checked == true)
            {
                tblopciones3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            else
            {
                tblopciones3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            tblopciones3.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            if (ckb_reposo.Checked == false)
            {
                tblopciones3.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            else
            {
                tblopciones3.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            pdfDoc.Add(tblopciones3);

            var tblopciones4 = new PdfPTable(new float[] { 40f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100, HorizontalAlignment = Element.ALIGN_LEFT };
            tblopciones4.AddCell(new PdfPCell(new Paragraph("Presenta Sintomas", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            tblopciones4.AddCell(new PdfPCell(new Paragraph("SI", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            if (ckb_sintomas.Checked == true)
            {
                tblopciones4.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            else
            {
                tblopciones4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            tblopciones4.AddCell(new PdfPCell(new Paragraph("NO", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            if (ckb_sintomas.Checked == false)
            {
                tblopciones4.AddCell(new PdfPCell(new Paragraph("x", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            else
            {
                tblopciones4.AddCell(new PdfPCell(new Paragraph(" ", cuadro)) { BorderColor = new BaseColor(255, 255, 255), HorizontalAlignment = Element.ALIGN_LEFT });
            }
            pdfDoc.Add(tblopciones4);
            pdfDoc.Add(new Chunk(Chunk.NEWLINE));
            pdfDoc.Add(new Paragraph("Descripción de Sintomatología: " + txt_sintomatologia.Text, parrafo) { Alignment = Element.ALIGN_JUSTIFIED });
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
            pdfDoc.Add(new Paragraph("Dra.Francy Helena Cobos Figueroa", parrafo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Paragraph("Médico General", parrafo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Paragraph("1711131415", parrafo) { Alignment = Element.ALIGN_CENTER });
            pdfDoc.Add(new Paragraph("cobitos2002.fc@gmail.com", parrafo) { Alignment = Element.ALIGN_CENTER });
            string imageURL2 = Server.MapPath("../Template Principal/images") + "/footer.png";
            iTextSharp.text.Image footer = iTextSharp.text.Image.GetInstance(imageURL2);
            footer.ScaleAbsolute(520, 50);
            footer.SetAbsolutePosition(41f, 5f);
            pdfDoc.Add(footer);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Certificado_Médico_Covid19_" + txt_cedula.Text + "_" + DateTime.Today + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }


    }
}