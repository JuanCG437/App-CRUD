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
    public partial class VentanaCsv : Form
    {
        public VentanaCsv()
        {
            InitializeComponent();
        }

        //Creamos una lista de la clase Usuario para almacenar los datos.
        //List<Usuario> datosusuario = new List<Usuario>();

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
            //definimos un condicional para cuando el usuario vaya a crear el archivo, si haya brindado los datos al programa.
            if (txtnombre.Text != "" && txtapellido.Text != "" && txtedad.Text != "")
            {
                //instanciamos la clase Usuario con sus respectivas funciones o métodos para trabajar con la información del usuario.
                Usuario persona = new Usuario();
                persona.nombre = txtnombre.Text;
                persona.apellido = txtapellido.Text;
                persona.edad = txtedad.Text;

                //datosusuario.Add(persona);

                //inicializamos una variable con la posible ubicación del archivo.
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.csv";

                if (File.Exists(path))
                {
                    //Utilizamos el elemento errorProvider del windows forms, para mostrarle una alerta al usuario.
                    errorProvider1.SetError(btnCrear, "el archivo ya existe, intente abrir el archivo");
                    btnCrear.Focus();
                    btnCrear.Enabled = false;
                    return;
                }
                else
                {
                    //instanciamos la clase filestream para poder crear, leer, y escribir en un archivo.
                    FileStream archivo = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.csv", FileMode.Create);
                    archivo.Close();

                    //instanciamos la clase Streamwriter para agregar texto, o contenido a un archivo.
                    StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.csv");
                    writer.WriteLine(persona.nombre + ";" + persona.apellido + ";" + persona.edad);
                    writer.Flush();
                    writer.Close();
                    MessageBox.Show("Arhivo creado");
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
            //Limpiamos el contenido del datagrid.
            dtGmostrar.Rows.Clear();

            //Instanciamos la clase DataGridViewTextBoxColumn para configurar el datagrid, para la lectura del archivo 
            //y poder mostrar su contenido correctamente.
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Nombre";
            column1.Width = 130;
            column1.ReadOnly = true;
            dtGmostrar.Columns.Add(column1);

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Apellido";
            column2.Width = 130;
            column2.ReadOnly = true;
            dtGmostrar.Columns.Add(column2);

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Edad";
            column3.Width = 130;
            column3.ReadOnly = true;
            dtGmostrar.Columns.Add(column3);

            //instanciamos la clase OpenFileDialog para aplicar diferentes métodos como filtrado, iniciar o abrir un directorio
            //y tener el nombre o la ruta de acceso a un archivo, etc.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.Filter = "datos (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 1;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    char delimitador = ';';
                    string path = openFileDialog1.FileName;
                    string line;
                    string[] valores;
                    Stream mystream;

                    if ((mystream = openFileDialog1.OpenFile()) != null)
                    {
                        using (mystream)
                        {
                            StreamReader leer = new StreamReader(File.OpenRead(path));

                            while ((line = leer.ReadLine()) != null)
                            {
                                valores = line.Split(delimitador);
                                dtGmostrar.Rows.Add(valores.ToArray());
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
            Usuario persona2 = new Usuario();
            persona2.nombre = txtnombre.Text;
            persona2.apellido = txtapellido.Text;
            persona2.edad = txtedad.Text;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\datos.csv";

            //datosusuario.Add(persona2);

            try
            {
                if (File.Exists(path))
                {
                    if (txtnombre.Text != "" && txtapellido.Text != "" && txtedad.Text != "")
                    {
                        StreamWriter nuevo = File.AppendText(path);
                        nuevo.WriteLine(persona2.nombre + ";" + persona2.apellido + ";" + persona2.edad + ";");
                        nuevo.Flush();
                        nuevo.Close();
                        MessageBox.Show("los datos fueron actualizados...");
                        dtGmostrar.Rows.Clear();
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

        /*--------------------------------------- SALIR ---------------------------------------*/
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            btncrearTxt btncrear = new btncrearTxt();
            btncrear.Show();
        }

        /*--------------------------------------- ELIMINAR ---------------------------------------*/
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            fileDialog.Filter = "datos (*.csv)|*.csv";
            fileDialog.FilterIndex = 1;

            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = fileDialog.FileName;

                    if (File.Exists(path))
                    {
                        //Utilizamos la clase File y su método Delete con la ubicación para eliminar el archivo 
                        File.Delete(path);
                        dtGmostrar.Rows.Clear();
                        MessageBox.Show("Archivo Eliminado...");
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
