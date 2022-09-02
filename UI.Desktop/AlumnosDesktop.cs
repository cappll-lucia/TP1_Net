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
                this.txtLegajo.Enabled = false;
                this.txtApellido.Enabled = false;
                this.txtNombre.Enabled = false;
                this.cbCarrera.DropDownStyle = ComboBoxStyle.Simple;
                this.cbCarrera.Enabled = false;
                this.cbEstado.DropDownStyle = ComboBoxStyle.Simple;
                this.cbEstado.Enabled = false;
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
            this.cbCarrera.SelectedValue = this._AlumnoActual.Carrera.IdCarrera;
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
                _AlumnoActual.Nombre = this.txtNombre.Text;
                _AlumnoActual.Apellido = this.txtApellido.Text;
                _AlumnoActual.Estado = this.cbEstado.SelectedItem.ToString();
                Carrera c = new Carrera(this.cbCarrera.SelectedIndex + 1);
                _AlumnoActual.Carrera = c;
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

        public override void GuardarCambios()
        {
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
            List<Carrera> listaCarreras = new List<Carrera>();
            listaCarreras = carreralg.GetAll();
            var car = new Carrera();
            car.DescCarrera = "Carrera";
            car.IdCarrera = 0;
            listaCarreras.Add(car);
            cbCarrera.DataSource = listaCarreras;
            cbCarrera.DisplayMember = "DescCarrera";
            cbCarrera.ValueMember = "IdCarrera";
            if(_AlumnoActual == null)
            {
                cbCarrera.SelectedIndex = listaCarreras.Count() - 1;
            }
            else 
            {
                cbCarrera.SelectedIndex = _AlumnoActual.Carrera.IdCarrera - 1;
            }
            cbEstado.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        public override bool Validar()
        {
            base.Validar();
            if (this._Modo == ModoForm.baja)
            {
                return true;
            }
            else if (this.txtNombre.Text != this.txtNombre.Tag.ToString() && this.txtApellido.Text != this.txtApellido.Tag.ToString() && this.txtLegajo.Text != this.txtLegajo.Tag.ToString())
            {
                if(cbCarrera.SelectedIndex != 3)
                {
                    if (cbEstado.SelectedIndex != 0 )
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Debes elegir un estado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    } 
                }
                else
                {
                    MessageBox.Show("Debes elegir una carrera", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show("Ninguno de los campos puede estar vacío", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
