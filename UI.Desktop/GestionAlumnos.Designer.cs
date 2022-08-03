
namespace UI.Desktop
{
    partial class GestionAlumnos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionAlumnos));
            this.tcGestionAlumnos = new System.Windows.Forms.ToolStripContainer();
            this.tsGestionAlumnos = new System.Windows.Forms.ToolStrip();
            this.tlGestionAlumnos = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvGestionAlumnos = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcGestionAlumnos.ContentPanel.SuspendLayout();
            this.tcGestionAlumnos.TopToolStripPanel.SuspendLayout();
            this.tcGestionAlumnos.SuspendLayout();
            this.tsGestionAlumnos.SuspendLayout();
            this.tlGestionAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestionAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // tcGestionAlumnos
            // 
            // 
            // tcGestionAlumnos.ContentPanel
            // 
            this.tcGestionAlumnos.ContentPanel.Controls.Add(this.tlGestionAlumnos);
            this.tcGestionAlumnos.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tcGestionAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcGestionAlumnos.Location = new System.Drawing.Point(0, 0);
            this.tcGestionAlumnos.Name = "tcGestionAlumnos";
            this.tcGestionAlumnos.Size = new System.Drawing.Size(800, 450);
            this.tcGestionAlumnos.TabIndex = 0;
            this.tcGestionAlumnos.Text = "toolStripContainer1";
            // 
            // tcGestionAlumnos.TopToolStripPanel
            // 
            this.tcGestionAlumnos.TopToolStripPanel.Controls.Add(this.tsGestionAlumnos);
            // 
            // tsGestionAlumnos
            // 
            this.tsGestionAlumnos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsGestionAlumnos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEditar,
            this.btnEliminar});
            this.tsGestionAlumnos.Location = new System.Drawing.Point(3, 0);
            this.tsGestionAlumnos.Name = "tsGestionAlumnos";
            this.tsGestionAlumnos.Size = new System.Drawing.Size(81, 25);
            this.tsGestionAlumnos.TabIndex = 0;
            // 
            // tlGestionAlumnos
            // 
            this.tlGestionAlumnos.ColumnCount = 2;
            this.tlGestionAlumnos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlGestionAlumnos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlGestionAlumnos.Controls.Add(this.btnActualizar, 0, 1);
            this.tlGestionAlumnos.Controls.Add(this.dgvGestionAlumnos, 0, 0);
            this.tlGestionAlumnos.Controls.Add(this.btnSalir, 1, 1);
            this.tlGestionAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlGestionAlumnos.Location = new System.Drawing.Point(0, 0);
            this.tlGestionAlumnos.Name = "tlGestionAlumnos";
            this.tlGestionAlumnos.RowCount = 2;
            this.tlGestionAlumnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlGestionAlumnos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlGestionAlumnos.Size = new System.Drawing.Size(800, 425);
            this.tlGestionAlumnos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(641, 399);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // dgvGestionAlumnos
            // 
            this.dgvGestionAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlGestionAlumnos.SetColumnSpan(this.dgvGestionAlumnos, 2);
            this.dgvGestionAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGestionAlumnos.Location = new System.Drawing.Point(3, 3);
            this.dgvGestionAlumnos.Name = "dgvGestionAlumnos";
            this.dgvGestionAlumnos.Size = new System.Drawing.Size(794, 390);
            this.dgvGestionAlumnos.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "Nuevo";
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(23, 22);
            this.btnEditar.Text = "Editar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(23, 22);
            this.btnEliminar.Text = "Eliminar";
            // 
            // GestionAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcGestionAlumnos);
            this.Name = "GestionAlumnos";
            this.Text = "GestionAlumnos";
            this.Load += new System.EventHandler(this.GestionAlumnos_Load);
            this.tcGestionAlumnos.ContentPanel.ResumeLayout(false);
            this.tcGestionAlumnos.TopToolStripPanel.ResumeLayout(false);
            this.tcGestionAlumnos.TopToolStripPanel.PerformLayout();
            this.tcGestionAlumnos.ResumeLayout(false);
            this.tcGestionAlumnos.PerformLayout();
            this.tsGestionAlumnos.ResumeLayout(false);
            this.tsGestionAlumnos.PerformLayout();
            this.tlGestionAlumnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestionAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcGestionAlumnos;
        private System.Windows.Forms.TableLayoutPanel tlGestionAlumnos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvGestionAlumnos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsGestionAlumnos;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
    }
}