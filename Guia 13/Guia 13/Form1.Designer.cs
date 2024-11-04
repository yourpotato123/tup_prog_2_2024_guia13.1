namespace Guia_13
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTpo = new System.Windows.Forms.ComboBox();
            this.tbPatente = new System.Windows.Forms.TextBox();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.rbDenuncia = new System.Windows.Forms.RadioButton();
            this.btTicket = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTurnos = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btDenuncias = new System.Windows.Forms.Button();
            this.btCliente = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(82, 10);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(152, 20);
            this.tbDNI.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTpo);
            this.groupBox1.Controls.Add(this.tbPatente);
            this.groupBox1.Controls.Add(this.rbCliente);
            this.groupBox1.Controls.Add(this.rbDenuncia);
            this.groupBox1.Location = new System.Drawing.Point(21, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 116);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del CLiente";
            // 
            // cbTpo
            // 
            this.cbTpo.FormattingEnabled = true;
            this.cbTpo.Items.AddRange(new object[] {
            "1-Auto",
            "2-Moto",
            "3-Equipo de Trabajo",
            "4-Bicicleta"});
            this.cbTpo.Location = new System.Drawing.Point(131, 77);
            this.cbTpo.Name = "cbTpo";
            this.cbTpo.Size = new System.Drawing.Size(82, 21);
            this.cbTpo.TabIndex = 4;
            // 
            // tbPatente
            // 
            this.tbPatente.Location = new System.Drawing.Point(131, 42);
            this.tbPatente.Name = "tbPatente";
            this.tbPatente.Size = new System.Drawing.Size(115, 20);
            this.tbPatente.TabIndex = 3;
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Location = new System.Drawing.Point(6, 77);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(92, 17);
            this.rbCliente.TabIndex = 2;
            this.rbCliente.TabStop = true;
            this.rbCliente.Text = "Nuevo Cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            // 
            // rbDenuncia
            // 
            this.rbDenuncia.AutoSize = true;
            this.rbDenuncia.Location = new System.Drawing.Point(6, 42);
            this.rbDenuncia.Name = "rbDenuncia";
            this.rbDenuncia.Size = new System.Drawing.Size(71, 17);
            this.rbDenuncia.TabIndex = 1;
            this.rbDenuncia.TabStop = true;
            this.rbDenuncia.Text = "Denuncia";
            this.rbDenuncia.UseVisualStyleBackColor = true;
            // 
            // btTicket
            // 
            this.btTicket.Location = new System.Drawing.Point(303, 47);
            this.btTicket.Name = "btTicket";
            this.btTicket.Size = new System.Drawing.Size(87, 105);
            this.btTicket.TabIndex = 3;
            this.btTicket.Text = "Ticket";
            this.btTicket.UseVisualStyleBackColor = true;
            this.btTicket.Click += new System.EventHandler(this.btTicket_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Turno";
            // 
            // lbTurnos
            // 
            this.lbTurnos.FormattingEnabled = true;
            this.lbTurnos.Location = new System.Drawing.Point(21, 180);
            this.lbTurnos.Name = "lbTurnos";
            this.lbTurnos.Size = new System.Drawing.Size(262, 108);
            this.lbTurnos.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(303, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 46);
            this.button2.TabIndex = 6;
            this.button2.Text = "Exportar tickets";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(303, 242);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 46);
            this.button3.TabIndex = 7;
            this.button3.Text = "Importar vehiculos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btImportar_Click);
            // 
            // btDenuncias
            // 
            this.btDenuncias.Location = new System.Drawing.Point(21, 294);
            this.btDenuncias.Name = "btDenuncias";
            this.btDenuncias.Size = new System.Drawing.Size(106, 51);
            this.btDenuncias.TabIndex = 8;
            this.btDenuncias.Text = "Atender Denuncia";
            this.btDenuncias.UseVisualStyleBackColor = true;
            this.btDenuncias.Click += new System.EventHandler(this.btDenuncias_Click);
            // 
            // btCliente
            // 
            this.btCliente.Location = new System.Drawing.Point(157, 294);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(126, 51);
            this.btCliente.TabIndex = 9;
            this.btCliente.Text = "Atender Nuevo Cliente";
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 364);
            this.Controls.Add(this.btCliente);
            this.Controls.Add(this.btDenuncias);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbTurnos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btTicket);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbPatente;
        private System.Windows.Forms.RadioButton rbCliente;
        private System.Windows.Forms.RadioButton rbDenuncia;
        private System.Windows.Forms.Button btTicket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbTurnos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btDenuncias;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.ComboBox cbTpo;
    }
}

