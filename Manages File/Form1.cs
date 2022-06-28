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

namespace Manages_File
{
    public partial class Form1 : Form
    {
        private String path = @"../../files";
        private String path_file = @"../../files/archivo.xyz";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {

                if (File.Exists(path_file))
                {
                    using (StreamReader file = new StreamReader(path_file))
                    {
                        String line;
                        while ((line = file.ReadLine()) != null)
                        {
                            txtMessage.Text += line + Environment.NewLine;
                        }

                        file.Close();
                    }
                }

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {

                if (File.Exists(path_file))
                {
                    File.Delete(path_file);
                }

                File.WriteAllText(path_file, txtMessage.Text);

            }
        }
    }
}
