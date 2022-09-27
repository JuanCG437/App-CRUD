using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace archivosPlanos
{
    public partial class btncrearTxt : Form
    {
        public btncrearTxt()
        {
            InitializeComponent();
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            VentanaTxt ventanaTxt = new VentanaTxt();
            ventanaTxt.Show();
            this.Hide();
        }

        private void btnCsv_Click(object sender, EventArgs e)
        {
            VentanaCsv ventanacsv = new VentanaCsv();
            ventanacsv.Show();
            this.Hide();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            VentanaXml ventanaXml = new VentanaXml();
            ventanaXml.Show();
            this.Hide();
        }

        private void btnRtf_Click(object sender, EventArgs e)
        {
            VentanaRTF ventanaRTF = new VentanaRTF();
            ventanaRTF.Show();
            this.Hide();
        }
    }
}
