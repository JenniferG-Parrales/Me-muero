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

namespace BlocNotas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Va a borrar todo lo que este en el RichTextbox
            richTextBox1.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clase que se encarga de mostrar un cuadro de dialogo que pide al usuario que abra un archivo y no puede heredarse (busqueda)
            OpenFileDialog myOpen = new OpenFileDialog();  //inicializar el constructor
            StreamReader myLectura = null;

            //filter establece la cadena de filtros de nombres de archivos, que determine las opciones como "guardar como" en el cuadro de dialogo y define que tipo de archivo puede ver
            myOpen.Filter = "Archivos de Textos (.txt)|*.txt|Todos los archivos (*.*)|*.*"; //en el cuadro de dialogo va a mostrar ese texto y el restro es para que solo muestre los aqrchivos de es mismo tipo
            myOpen.Title = "Abrir archivo "; //poner titulo
            myOpen.ShowDialog(); //cuadro de dialogo
            myOpen.OpenFile(); //abre el archivo seleccionado
            string RutArchivo = myOpen.FileName;

            //para obtener la ruta se necesita abrir la ventana e indicar que tipo de archivos se va a leer
            //Se le asigna al objbeto myLectura todos los componentes necesarios con la clase file

            myLectura = File.OpenText(RutArchivo);
            //OpenTxt abre un archivo existente con codificacion UTF8 para lectura pero necesita la direcion del archivo
            //myLectura contiene todo los parametros y funciones de StreamREAder

            richTextBox1.Text = myLectura.ReadToEnd(); //para leer todo el texto que esta en myLectura
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySave = new SaveFileDialog(); //el objeto esta preparado para recibir la infromacion del archivpque se va abrir y se inicializa el contruxtor
            StreamWriter myEscritura = null; //se creo el objeto streamwriter que va obtener todo el texto del archivo txt y lo obtiene mediante el objeto mysave(permite vincular toda infromacion de la ventana de dialogo y va para escrityura

            mySave.Filter = "Archivos de Textos (.txt)|*.txt|Todos los archivos (*.*)|*.*";
            mySave.Title = "Guardar como...";
            mySave.ShowDialog();
            string Ruta = mySave.FileName; //aqui mysave ya sabe la ruta del archivo
            //file name es la ruta que se le asigna a la variable
            myEscritura = File.AppendText(Ruta); //este ultimo  crea un streamwriter que anexa el texto codificado a un archivo existente o un nuevo
            myEscritura.Write(richTextBox1.Text);
            myEscritura.Flush(); //Para escribir y borrar los buferes del sistema
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void horaYFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime Fecha = DateTime.Now;
            richTextBox1.Text = Fecha.ToString(); //para convertir en string
        }

        private void estiloDeFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog myFont = new FontDialog(); //inicializar un construtcir
            myFont.Font = richTextBox1.Font; //pasar la fuente actual del rich al objeto


        if (myFont.ShowDialog() == DialogResult.OK) //la fuente se asigna al rich

            richTextBox1.Font = myFont.Font;
        }

        private void colorDeFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog myColor = new ColorDialog();
            if (myColor.ShowDialog() == DialogResult.OK) ;
            richTextBox1.ForeColor = myColor.Color;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias por su tiempo");
        }
    }
}
