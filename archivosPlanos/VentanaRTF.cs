using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace archivosPlanos
{
    public partial class VentanaRTF : Form
    {
        public VentanaRTF()
        {
            InitializeComponent();
        }

        //Evento del comando Abrir del menú
        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtxtContenido.LoadFile(openFileDialog1.FileName);
            }
        }

        //Evento del comando Salvar del menú
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtxtContenido.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                MessageBox.Show("Archivo Guardado");
            }
        }

        //Evento del comando Fuente del menú
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtxtContenido.SelectionFont = fontDialog1.Font;
            }
        }

        //Evento del comando Color del menú
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtxtContenido.SelectionColor = colorDialog1.Color;
            }
        }

        //Evento del comando salir del menú
        private void salirRTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            btncrearTxt btncrear = new btncrearTxt();
            btncrear.Show();
        }

        //Evento del comando Eliminar menú (Archivo)
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        MessageBox.Show("Archivo Eliminado");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
