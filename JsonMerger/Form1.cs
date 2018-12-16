using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonMerger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Multiselect = true;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Read the files

                    string content = "{";

                    foreach (string file in dlg.FileNames)
                    {

                        var txt = File.ReadAllText(file);
                        var name = Path.GetFileNameWithoutExtension(file);

                        if(content != "")
                        {
                            content += ",";
                        }

                        content += "\n" + '\u0022' +name+ '\u0022' + ":" + txt;


                    }

                    content += "}";

                    File.WriteAllText(@"d:\videogames.json", content);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string et = end.Text.Replace(".", ",");
            string st = start.Text.Replace(".", ",");
            float stf = float.Parse(st);
            float etf = float.Parse(et); ;
            float length = etf - stf;
  
            for (int i = 0; i < Math.Round(length / 1.2) + 1; i++)
            {
                float val = (float)Math.Round((stf + i * 1.2f) * 10f) / 10f;
                var txt = "<option value=\"" + val + "\" >" + val + " meter </option>\n";
                txt = txt.Replace(",", ".");
                
                textBox1.AppendText(txt);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string[] files;
        List<Image> images = new List<Image>();

        private void mergeImages_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Multiselect = true;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Read the files

                    files = dlg.FileNames;
                    foreach (string file in dlg.FileNames)
                    {



                        images.Add(Image.FromFile(file));


                    }

                }
            }



        }
    }
}
