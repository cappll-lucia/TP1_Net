using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class GestionAlumnos : ApplicationForm
    {
        public GestionAlumnos()
        {
            InitializeComponent();
        }

        public void GestionAlumnos_Load(object sender, EventArgs e)
        {
            dgvGestionAlumnos.AutoGenerateColumns = false;
            Listar();
        }


        public void Listar()
        {
            AlumnoLogic al = new AlumnoLogic();
            this.dgvGestionAlumnos.DataSource = al.GetAll();
        }

        
        private void btnNew_Click(object sender, EventArgs e)
        {
            AlumnosDesktop FormAlu = new AlumnosDesktop(ModoForm.alta);
            FormAlu.ShowDialog();
            this.Listar();
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int legajo = ((Alumno)this.dgvGestionAlumnos.SelectedRows[0].DataBoundItem).Legajo;
            if (this.dgvGestionAlumnos.SelectedRows.Count == 1)
            {
                AlumnosDesktop formAlu = new AlumnosDesktop(legajo, ApplicationForm.ModoForm.baja);
                formAlu.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show(this.Text, "Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int legajo = ((Alumno)this.dgvGestionAlumnos.SelectedRows[0].DataBoundItem).Legajo;
            if (this.dgvGestionAlumnos.SelectedRows.Count == 1)
            {
                AlumnosDesktop formAlu = new AlumnosDesktop(legajo, ApplicationForm.ModoForm.modificacion);
                formAlu.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show(this.Text, "Debe seleccionar una fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
