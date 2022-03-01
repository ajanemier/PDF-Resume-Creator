using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;



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
            richTextBoxData.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
        }   

        
        private void btnGenerate_Click(object sender, EventArgs e)
            {
            string info = textBoxPath.Text;
            string openfile = File.ReadAllText(info);
            jsonreader jsonfile = JsonConvert.DeserializeObject<jsonreader>(openfile);
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("C:/Users/63976/OOP/PDFResume/MALACURA_ALICEJANE.pdf", FileMode.Create));       

            
            Paragraph personalinfo = new Paragraph("Personal Information:\n\n" + "Name:" + jsonfile.Name + "\n" + "Age:" + jsonfile.age + "\n" + "City Location:" + jsonfile.City_Location + "\n" + "Email:" + jsonfile.Email + "\n" + "Citizenship:" + jsonfile.Citizenship + "\n\n\n\n");
            Paragraph education = new Paragraph("Educational Attainment:\n\n" + "College:" +  jsonfile.College + "\n" + "High School:" + jsonfile.High_School + "\n" + "Elementary:" + jsonfile.Elementary + "\n\n\n\n");
            Paragraph workexperience = new Paragraph("Work Experience:\n\n" + jsonfile.Company1 + "\n" + jsonfile.Position1 + "\n" + jsonfile.Duration1 + "\n\n\n"  + jsonfile.Company2 + "\n" + jsonfile.Position2 + "\n" + jsonfile.Duration2 + "\n\n\n" + jsonfile.Company3 + "\n"  + jsonfile.Position3 + "\n" + jsonfile.Duration3+ "\n\n\n");
          

            doc.Open();
            doc.Add(personalinfo);
            doc.Add(education);
            doc.Add(workexperience);
            doc.Close();
            MessageBox.Show("PDF File Created Successfully");


        }

        public class jsonreader
        {
            public string Name
            {
                get; set;
            }
            public string age
            {
                get; set;
            }
            public string City_Location
            {
                get; set;
            }
            public string Email
            {
                get; set;
            }
            public string Citizenship
            {
                get; set;
            }
            public string College
            {
                get; set;
            }
            public string High_School
            {
                get; set;
            }
         
            public string Elementary
            {
                get; set;
            }
            
            public string Company1
            {
                get; set;
            }
            public string Position1
            {
                get; set;
            }
            public string Duration1
            {
                get; set;
            }
            public string Company2
            {
                get; set;
            }
            public string Position2
            {
                get; set;
            }
            public string Duration2
            {
                get; set;
            }
            public string Company3
            {
                get; set;
            }
            public string Position3
            {
                get; set;
            }
            public string Duration3
            {
                get; set;
            }


        }

    }
    }
