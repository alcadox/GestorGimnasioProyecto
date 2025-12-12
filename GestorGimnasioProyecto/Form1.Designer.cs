namespace GestorGimnasioProyecto
{
    partial class FormularioInicioSesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelTituloInicioSesion = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.panelFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Font = new System.Drawing.Font("Segoe UI Variable Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsuario.Location = new System.Drawing.Point(86, 144);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(223, 29);
            this.textBoxUsuario.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI Variable Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(86, 209);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(223, 29);
            this.textBoxPassword.TabIndex = 1;
            // 
            // labelTituloInicioSesion
            // 
            this.labelTituloInicioSesion.AutoSize = true;
            this.labelTituloInicioSesion.Font = new System.Drawing.Font("Segoe UI Variable Display", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloInicioSesion.Location = new System.Drawing.Point(84, 67);
            this.labelTituloInicioSesion.Name = "labelTituloInicioSesion";
            this.labelTituloInicioSesion.Size = new System.Drawing.Size(231, 38);
            this.labelTituloInicioSesion.TabIndex = 2;
            this.labelTituloInicioSesion.Text = "Inicio de Sesión";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(86, 124);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(58, 17);
            this.labelUsuario.TabIndex = 3;
            this.labelUsuario.Text = "Usuario:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(86, 189);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(81, 17);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Contraseña:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Variable Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(124, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Iniciar Sesión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelFondo
            // 
            this.panelFondo.BackColor = System.Drawing.Color.Silver;
            this.panelFondo.Controls.Add(this.button1);
            this.panelFondo.Controls.Add(this.labelPassword);
            this.panelFondo.Controls.Add(this.labelUsuario);
            this.panelFondo.Controls.Add(this.labelTituloInicioSesion);
            this.panelFondo.Controls.Add(this.textBoxPassword);
            this.panelFondo.Controls.Add(this.textBoxUsuario);
            this.panelFondo.Location = new System.Drawing.Point(178, 65);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(394, 386);
            this.panelFondo.TabIndex = 0;
            // 
            // FormularioInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 546);
            this.Controls.Add(this.panelFondo);
            this.Name = "FormularioInicioSesion";
            this.Text = "Iniciar Sesión";
            this.panelFondo.ResumeLayout(false);
            this.panelFondo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelTituloInicioSesion;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelFondo;
    }
}

