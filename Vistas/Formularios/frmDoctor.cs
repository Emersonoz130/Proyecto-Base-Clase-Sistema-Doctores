using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas.Formularios
{
    public partial class frmDoctor : Form
    {
        public frmDoctor()
        {
            InitializeComponent();
        }
        private void MostrarDoctores() {
            dgvDoctores.DataSource = null;
            dgvDoctores.DataSource = Doctor.CargarDoctores();
        }

        private void frmDoctor_Load(object sender, EventArgs e)
        {
            MostrarDoctores();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Aqui vamos a crear el objeto y vamos a capturar la informacion
            //por medio de los textbox
            Doctor doc = new Doctor();
            doc.Nombre=txtNombre.Text;
            doc.Apellido=txtApellido.Text;
            doc.Especialidad=txtEspecialidad.Text;
            doc.Cargo=txtCargo.Text;
            doc.InsertarDoctores();
            Limpiarcampos();
            MostrarDoctores();
        }
        private void Limpiarcampos() {
            MessageBox.Show("Registro exitoso");
            txtNombre.Clear();
            txtApellido.Clear();
            txtCargo.Clear();
            txtEspecialidad.Clear();
        }

    }
}
