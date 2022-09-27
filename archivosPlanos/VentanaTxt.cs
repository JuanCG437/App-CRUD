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

namespace archivosPlanos
{
    public partial class VentanaTxt : Form
    {
        public VentanaTxt()
        {
            InitializeComponent();
            
        }

        //Creamos una lista de la clase Usuario para almacenar los datos.
        List<Usuario> datosusuarios = new List<Usuario>();

        //Definimos un método limpiar para vaciar los contenidos de las cajas de texto de la interfaz gráfica.
        private void Limpiar()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtedad.Clear();
        }

        /*--------------------------------------- CREAR ---------------------------------------*/
        private void btnCrear_Click(object sender, EventArgs e)
        {
            //definimos un condicional para cuando el usuario vaya crear el archivo, si haya brindado los datos al programa.
            if (txtnombre.Text != "" && txtapellido.Text != "" && txtedad.Text != "")
            {
                //instanciamos la clase Usuario con sus respectivas propiedades para trabajar con la información del usuario.
                Usuario persona = new Usuario();
                persona.nombre = txtnombre.Text;
                persona.apellido = txtapellido.Text;
                persona.edad = txtedad.Text;

                datosusuarios.Add(persona);

                //inicializamos una variable con la posible ubicación del archivo.
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.txt";

                if (File.Exists(path))
                {
                    errorProvider1.SetError(btnCrear, "el archivo ya existe, intente abrir el archivo");
                    btnCrear.Focus();
                    btnCrear.Enabled = false;
                    return;
                }
                else
                {
                    //instanciamos la clase filestream para poder crear, leer, y escribir en un archivo.
                    FileStream archivo = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.txt", FileMode.Create, FileAccess.Write);
                    archivo.Close();

                    //instanciamos la clase Streamwriter para agregar texto, o contenido a un archivo.
                    StreamWriter agregar = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.txt");
                    agregar.WriteLine(persona.nombre + " | " + persona.apellido + " | " + persona.edad);
                    agregar.Flush();
                    agregar.Close();
                    MessageBox.Show("El archivo fue creado...");
                    btnCrear.Enabled = false;
                    Limpiar();
                }                
            }
            else if (txtnombre.Text == "" || txtapellido.Text == "" || txtedad.Text == "")
            {
                errorProvider1.SetError(btnCrear, "ingrese los datos que se le piden en los campos");
                btnCrear.Focus();
                return;
            }
        }

        /*--------------------------------------- LEER ---------------------------------------*/
        private void btnLeer_Click(object sender, EventArgs e)
        {
            txtmostrar.Clear();
            //instanciamos la clase OpenFileDialog para aplicar diferentes métodos como filtrado, iniciar o abrir un directorio
            //y tener el nombre o la ruta de acceso a un archivo, etc.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.Filter = "datos (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;

            try
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Variable con la ruta y/o nombre del archivo
                    string path = openFileDialog1.FileName;

                    string[] info;
                    string line;
                    char delimitador = '\n';
                    int count = 0;
                    Stream stream;

                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            TextReader leer = new StreamReader(path);
                            while ((line = leer.ReadLine()) != null)
                            {
                                info = line.Split(delimitador);
                                txtmostrar.Text = txtmostrar.Text + line + Environment.NewLine;
                                count++;
                            }
                            leer.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        /*--------------------------------------- AGREGAR ---------------------------------------*/
        private void btnEscribir_Click(object sender, EventArgs e)
        {
            Usuario persona = new Usuario();
            persona.nombre = txtnombre.Text;
            persona.apellido = txtapellido.Text;
            persona.edad = txtedad.Text;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.txt";

            datosusuarios.Add(persona);

            try
            {
                if (File.Exists(path))
                {
                    if (txtnombre.Text != "" && txtapellido.Text != "" && txtedad.Text != "")
                    {
                        StreamWriter textoNuevo = File.AppendText(path);
                        textoNuevo.WriteLine(persona.nombre + " | " + persona.apellido + " | " + persona.edad);
                        textoNuevo.Flush();
                        textoNuevo.Close();
                        MessageBox.Show("Se agregó texto al archivo");
                        txtmostrar.Clear();
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

        /*--------------------------------------- ELIMINAR ---------------------------------------*/
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.Filter = "Archivos (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog1.FileName;

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        txtmostrar.Clear();
                        MessageBox.Show("Archivo Eliminado...");
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
            btncrearTxt btncrearTxt = new btncrearTxt();
            btncrearTxt.Show();
        }
    }
}
