using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        public ModoForm _Modo;
        public ApplicationForm()
        {
            InitializeComponent();
        }
        public enum ModoForm
        {
            alta, baja, modificacion, consulta
        }
        private void ApplicationForm_Load(object sender, EventArgs e)
        {
                
        }

        public virtual void MapearDeDatos()
        {

        }
        public virtual void MapearADatos()
        {

        }
        public virtual void GuardarCambios()
        {

        }

        public void Notificar( string mensaje, string titulo, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public virtual bool Validar()
        {
            return false;
        }
    }
}
