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
    public partial class AlumnosDesktop :ApplicationForm
    {

        public Alumno _AlumnoActual;
        public ModoForm _Modo;

        public AlumnosDesktop()
        {
            InitializeComponent();
        }
        
        public AlumnosDesktop(ModoForm modo) : this()
        {

        }

        public AlumnosDesktop(int legajo, ModoForm modo) : this()
        {
            
            _Modo = modo;
            if (_Modo != ModoForm.alta)
            {
                AlumnoLogic al = new AlumnoLogic();
                _AlumnoActual = al.GetOne(legajo);
                MapearDeDatos();
            }
            if (_Modo == ModoForm.alta || _Modo == ModoForm.modificacion)
            {
                this.btnAceptar.Text = "Guardar";

            }
            else if (_Modo == ModoForm.baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtLegajo.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtNombre.ReadOnly = true;
                this.cbCarrera.AllowDrop = false;
                this.cbEstado.AllowDrop = false;


            }
            else if (_Modo == ModoForm.consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
            
        }


        public override void MapearDeDatos()
        {
            base.MapearDeDatos();
            this.txtLegajo.Text = this._AlumnoActual.Legajo.ToString();
            this.txtApellido.Text = this._AlumnoActual.Apellido;
            this.txtNombre.Text = this._AlumnoActual.Nombre;

            //ComboBox de Carrera FALTA
            

            if (this._AlumnoActual.Estado == "Activo")
            {
                this.cbEstado.SelectedIndex = 1;
            }
            else if (this._AlumnoActual.Estado == "Inactivo")
            {
                this.cbEstado.SelectedIndex = 2;
            }
            else if (this._AlumnoActual.Estado == "Graduado")
            {
                this.cbEstado.SelectedIndex = 3;
            }
        }

        public override void MapearADatos()
        {
            base.MapearDeDatos();
            if (_Modo == ModoForm.alta)
            {
                _AlumnoActual = new Alumno();
            }

            if (_Modo == ModoForm.modificacion || _Modo == ModoForm.alta)
            {
                _AlumnoActual.Legajo = int.Parse(this.txtLegajo.Text);
                _AlumnoActual.Nombre = this.txtNombre.Text;
                _AlumnoActual.Apellido = this.txtApellido.Text;
                _AlumnoActual.Estado = this.cbEstado.SelectedItem.ToString();
                _AlumnoActual.IdCarrera = this.cbCarrera.SelectedItem.ToString();

                if (_Modo == ModoForm.alta)
                {
                    _AlumnoActual.State = Entidades.States.New;
                }
                else if (_Modo == ModoForm.modificacion)
                {
                    _AlumnoActual.State = Entidades.States.Modified;
                }


            }

        }

        public override bool Validar()
        {
            base.Validar();
            if (this.txtNombre.Text != "" && this.txtApellido.Text != "" && this.txtLegajo.Text != "" && this.cbCarrera.SelectedIndex != 0 && this.cbEstado.SelectedIndex != 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show(this.Text, "Ninguno de los campos puede estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override void GuardarCambios()
        {
            base.GuardarCambios();
            MapearADatos();
            AlumnoLogic al = new AlumnoLogic();
            al.Save(_AlumnoActual);
        }

        private void txtLegajo_Enter(object sender, EventArgs e)
        {
            TextBox txtB = (TextBox)sender;
            if ((txtB.Text) == txtB.Tag.ToString())
            {
                txtB.Text = string.Empty;
                txtB.ForeColor = Color.Black;
            }
        }

        private void txtLegajo_Leave(object sender, EventArgs e)
        {
            TextBox txtB = (TextBox)sender;
            if (string.IsNullOrEmpty(txtB.Text))
            {
                txtB.Text = txtB.Tag.ToString();
                txtB.ForeColor = Color.DimGray;
            }
        }

        private void txtBox_Enter(object sender, EventArgs e)
        {
            TextBox txtB = (TextBox)sender;
            if ((txtB.Text) == txtB.Tag.ToString())
            {
                txtB.Text = string.Empty;
                txtB.ForeColor = Color.Black;
            }
        }

        private void txtBox_Leave(object sender, EventArgs e)
        {
            TextBox txtB = (TextBox)sender;
            if (string.IsNullOrEmpty(txtB.Text))
            {
                txtB.Text = txtB.Tag.ToString();
                txtB.ForeColor = Color.DimGray;
            }
        }

        private void pnContolAlumnos_Paint(object sender, PaintEventArgs e)
        {
            cbEstado.SelectedIndex = 0;
            cbCarrera.SelectedIndex = 0;
        }

        private void AlumnosDesktop_Load(object sender, EventArgs e)
        {
            CarrerasLogic carreralg = new CarrerasLogic();
            cbCarrera.DataSource = carreralg.GetAll(); 
            cbCarrera.DisplayMember = "DescCarrera";
            cbCarrera.ValueMember = "IdCarrera";
        }

    }
}
