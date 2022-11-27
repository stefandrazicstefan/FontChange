using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenjanjeFonta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string FONT;
        
        private void ExecuteFont(string font)
        {
            string PATH = Environment.CurrentDirectory;
            PATH += "\\Font.reg";
            using (FileStream fs = File.Create(PATH)) ;
            using (StreamWriter fw = new StreamWriter(PATH))
            {
                fw.WriteLine("Windows Registry Editor Version 5.00");
                fw.WriteLine("[HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts]");
                fw.WriteLine("\"Segoe UI(TrueType)\" = \"\"");
                fw.WriteLine("\"Segoe UI Bold(TrueType)\" = \"\"");
                fw.WriteLine("\"Segoe UI Bold Italic (TrueType)\" = \"\"");
                fw.WriteLine("\"Segoe UI Italic(TrueType)\" = \"\"");
                fw.WriteLine("\"Segoe UI Light(TrueType)\" = \"\"");
                fw.WriteLine("\"Segoe UI Semibold(TrueType)\" = \"\"");
                fw.WriteLine("\"Segoe UI Symbol(TrueType)\" = \"\"");
                fw.WriteLine("[HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\FontSubstitutes]");
                fw.WriteLine("\"Segoe UI\" = \"{0}\"", font);
                fw.Close();
            }
            Process.Start(PATH);
            MessageBox.Show("Uspesno menjanje fonta!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                FONT = Convert.ToString(fontDialog1.Font.Name);
                ExecuteFont(FONT);
            }
        }
    }
}