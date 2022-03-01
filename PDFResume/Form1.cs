using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Aspose.Cells;
using GroupDocs.Assembly;
using GroupDocs.Assembly.Data;





namespace PDFResume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files(*.json)|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName.ToString();
                textBoxPath.Text = path;
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {

            //   string jsonInput = File.ReadAllText("resume.json");

            string readJson = new StreamReader(textBoxPath.Text).ReadToEnd();
            string serializeData = FormatJson(readJson);
            File.WriteAllText(@"C:\Users\63976\OOP\PDFResumeCreator\resume.txt", serializeData);

            string path = @"C:\Users\63976\OOP\PDFResumeCreator\resume.txt";
            StreamReader stream = new StreamReader(path);
            string filedata = stream.ReadToEnd();   
            richTextBoxData.Text = filedata.ToString();
            stream.Close();
        }


        private static string FormatJson(string json)
        {
            string jsonData = JsonConvert.SerializeObject(json);
            return jsonData;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

           


            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("C:/Users/63976/OOP/PDFResumeCreator/MALACURA_ALICEJANE.pdf", FileMode.Create));
            doc.Open();
            Paragraph p1 = new Paragraph(richTextBoxData.Text);
            doc.Add(p1);
            doc.Close();
            MessageBox.Show("PDF File Created Successfully");
        }
    }
}