namespace GestorGimnasioProyecto
{
    partial class FormularioRenovarEntrenadores
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.labelConfirmacion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelAviso = new System.Windows.Forms.Label();
            this.dateTimePickerFechaFin = new System.Windows.Forms.DateTimePicker();
            this.labelFechaFin = new System.Windows.Forms.Label();
            this.dateTimePickerFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTipoPago = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonCancelar);
            this.panel5.Controls.Add(this.buttonConfirmar);
            this.panel5.Controls.Add(this.labelConfirmacion);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(716, 61);
            this.panel5.TabIndex = 6;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(629, 18);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 30);
            this.buttonCancelar.TabIndex = 27;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirmar.Location = new System.Drawing.Point(548, 18);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 30);
            this.buttonConfirmar.TabIndex = 26;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // labelConfirmacion
            // 
            this.labelConfirmacion.AutoSize = true;
            this.labelConfirmacion.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 14.75F, System.Drawing.FontStyle.Bold);
            this.labelConfirmacion.Location = new System.Drawing.Point(10, 16);
            this.labelConfirmacion.Name = "labelConfirmacion";
            this.labelConfirmacion.Size = new System.Drawing.Size(311, 27);
            this.labelConfirmacion.TabIndex = 25;
            this.labelConfirmacion.Text = "¿Confirma la renovación a --- ---?";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelAviso);
            this.panel2.Controls.Add(this.dateTimePickerFechaFin);
            this.panel2.Controls.Add(this.labelFechaFin);
            this.panel2.Controls.Add(this.dateTimePickerFechaInicio);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBoxTipoPago);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 65);
            this.panel2.TabIndex = 5;
            // 
            // labelAviso
            // 
            this.labelAviso.AutoSize = true;
            this.labelAviso.Location = new System.Drawing.Point(249, 49);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(35, 13);
            this.labelAviso.TabIndex = 28;
            this.labelAviso.Text = "label1";
            // 
            // dateTimePickerFechaFin
            // 
            this.dateTimePickerFechaFin.Location = new System.Drawing.Point(486, 24);
            this.dateTimePickerFechaFin.Name = "dateTimePickerFechaFin";
            this.dateTimePickerFechaFin.Size = new System.Drawing.Size(220, 20);
            this.dateTimePickerFechaFin.TabIndex = 24;
            this.dateTimePickerFechaFin.Value = new System.DateTime(2025, 12, 13, 0, 43, 19, 0);
            // 
            // labelFechaFin
            // 
            this.labelFechaFin.AutoSize = true;
            this.labelFechaFin.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelFechaFin.Location = new System.Drawing.Point(483, 8);
            this.labelFechaFin.Name = "labelFechaFin";
            this.labelFechaFin.Size = new System.Drawing.Size(68, 17);
            this.labelFechaFin.TabIndex = 23;
            this.labelFechaFin.Text = "Fecha Fin:";
            // 
            // dateTimePickerFechaInicio
            // 
            this.dateTimePickerFechaInicio.Location = new System.Drawing.Point(252, 25);
            this.dateTimePickerFechaInicio.Name = "dateTimePickerFechaInicio";
            this.dateTimePickerFechaInicio.Size = new System.Drawing.Size(217, 20);
            this.dateTimePickerFechaInicio.TabIndex = 22;
            this.dateTimePickerFechaInicio.Value = new System.DateTime(2025, 12, 13, 0, 43, 26, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(249, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Fecha Inicio:";
            // 
            // comboBoxTipoPago
            // 
            this.comboBoxTipoPago.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoPago.FormattingEnabled = true;
            this.comboBoxTipoPago.Items.AddRange(new object[] {
            "SEMANAL",
            "MENSUAL",
            "ANUAL"});
            this.comboBoxTipoPago.Location = new System.Drawing.Point(15, 25);
            this.comboBoxTipoPago.Name = "comboBoxTipoPago";
            this.comboBoxTipoPago.Size = new System.Drawing.Size(133, 24);
            this.comboBoxTipoPago.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(12, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tipo De Pago:";
            // 
            // FormularioRenovarEntrenadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 126);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Name = "FormularioRenovarEntrenadores";
            this.Text = "GymTasks - Renovación Entrenadores";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Label labelConfirmacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelAviso;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaFin;
        private System.Windows.Forms.Label labelFechaFin;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxTipoPago;
        private System.Windows.Forms.Label label8;
    }
}