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
using System.Xml.Serialization;

namespace archivosPlanos
{
    public partial class VentanaXml : Form
    {
        public VentanaXml()
        {
            InitializeComponent();
        }

        //Definimos un método limpiar el contenido del textbox.
        private void Limpiar()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtedad.Clear();
        }

        /*--------------------------------------- CREAR ---------------------------------------*/
        private void btnCrear_Click(object sender, EventArgs e)
        {
            //definimos un condicional para cuando el usuario vaya a crear el archivo, si haya brindado los datos al programa.
            if (txtnombre.Text != "" && txtapellido.Text != "" && txtedad.Text != "")
            {
                //Creamos una lista donde almacenaremos los datos del usuario.
                List<Usuario> usuarios = new List<Usuario>();
                //Instanciamos la clase xmlSerializer para serializar los datos del usuario en el archivo XML.
                XmlSerializer writer = new XmlSerializer(typeof(List<Usuario>));
                //Añadimos los datos del usuario a la lista.
                usuarios.Add(new Usuario { nombre = txtnombre.Text, apellido = txtapellido.Text, edad = txtedad.Text });

                //Definimos una variable con la ruta o ubicación del archivo.
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.xml";

                //Instanciamos la clase fileStream para crear, escribir y leer archivos.
                FileStream archivo = new FileStream(path, FileMode.Create);
                writer.Serialize(archivo, usuarios);
                archivo.Flush();
                archivo.Close();
                MessageBox.Show("Archivo Creado");
                //Instanciamos el método o función Limpiar.
                Limpiar();
            }
            else if (txtnombre.Text == null || txtapellido.Text == null || txtedad.Text == null)
            {
                errorProvider1.SetError(btnCrear, "Ingrese los datos en los campos");
                btnCrear.Focus();
                return;
            }
            
        }

        /*--------------------------------------- LEER ---------------------------------------*/
        private void btnLeer_Click(object sender, EventArgs e)
        {
            //Limpiamos el contenido del datagrid.
            dtgMostrar.Rows.Clear();

            //instanciamos la clase OpenFileDialog para aplicar diferentes métodos como filtrado, iniciar o abrir un directorio
            //y tener el nombre o la ruta de acceso a un archivo, etc.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.Filter = "Archivo (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog1.FileName;


                    if (openFileDialog1.OpenFile() != null)
                    {
                        List<Usuario> usuarios = new List<Usuario>();
                        XmlSerializer read = new XmlSerializer(typeof(List<Usuario>));
                        StreamReader leer = new StreamReader(File.OpenRead(path));
                        usuarios = read.Deserialize(leer) as List<Usuario>;
                        leer.Close();
                        dtgMostrar.DataSource = usuarios;

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        /*--------------------------------------- ELIMINAR ---------------------------------------*/
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            fileDialog.Filter = "Archivo (*.xml)|*.xml";
            fileDialog.FilterIndex = 1;

            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = fileDialog.FileName;

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        Limpiar();
                        MessageBox.Show("Archivo Eliminado");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        /*--------------------------------------- SALIR ---------------------------------------*/
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            btncrearTxt btncrear = new btncrearTxt();
            btncrear.Show();
        }

        /*--------------------------------------- ESCRIBIR ---------------------------------------*/
        private void btnEscribir_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.xml";

            try
            {
                if (File.Exists(path))
                {
                    if (txtnombre.Text != "" && txtapellido.Text != "" && txtedad.Text != "")
                    {
                        List<Usuario> usuarios = new List<Usuario>();
                        XmlSerializer xml = new XmlSerializer(typeof(List<Usuario>));
                        usuarios.Add(new Usuario { nombre = txtnombre.Text, apellido = txtapellido.Text, edad = txtedad.Text });
                        FileStream stream = new FileStream(path, FileMode.Truncate);
                        xml.Serialize(stream, usuarios);
                        stream.Close();
                        MessageBox.Show("Se agregó contenido al archivo ");

                        Limpiar();
                    }
                    else if (txtnombre.Text == null || txtapellido.Text == null || txtedad.Text == null)
                    {
                        errorProvider1.SetError(btnEscribir, "Ingrese los datos en los campos");
                        btnEscribir.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
    }
}
