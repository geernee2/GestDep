using GestDep.Services;

namespace GestDepGUI
{
    partial class GestDepApp
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private IGestDepService service;

        public GestDepApp(IGestDepService service)
        {
            InitializeComponent();
            this.service = service;           

        }

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
            System.Windows.Forms.Button listar_salas;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestDepApp));
            this.ActividadBoton = new System.Windows.Forms.Button();
            this.añadirActividadBoton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.botonUsuario = new System.Windows.Forms.Button();
            this.añadirUsuarioBoton = new System.Windows.Forms.Button();
            this.inscribirUsuarioBoton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.botonMonitor = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.botonSalas = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            listar_salas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listar_salas
            // 
            listar_salas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            listar_salas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(129)))));
            listar_salas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            listar_salas.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold);
            listar_salas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            listar_salas.Location = new System.Drawing.Point(3, 3);
            listar_salas.Name = "listar_salas";
            listar_salas.Size = new System.Drawing.Size(274, 64);
            listar_salas.TabIndex = 1;
            listar_salas.Text = "Listar salas libres";
            listar_salas.UseVisualStyleBackColor = false;
            listar_salas.Click += new System.EventHandler(this.listar_salas_Click);
            // 
            // ActividadBoton
            // 
            this.ActividadBoton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ActividadBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.ActividadBoton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ActividadBoton.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActividadBoton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ActividadBoton.Location = new System.Drawing.Point(0, 0);
            this.ActividadBoton.Name = "ActividadBoton";
            this.ActividadBoton.Size = new System.Drawing.Size(286, 160);
            this.ActividadBoton.TabIndex = 1;
            this.ActividadBoton.Text = "Actividad";
            this.ActividadBoton.UseVisualStyleBackColor = false;
            this.ActividadBoton.MouseEnter += new System.EventHandler(this.ActividadBoton_Ocultar);
            // 
            // añadirActividadBoton
            // 
            this.añadirActividadBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(129)))));
            this.añadirActividadBoton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.añadirActividadBoton.FlatAppearance.BorderSize = 0;
            this.añadirActividadBoton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.añadirActividadBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.añadirActividadBoton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.añadirActividadBoton.Location = new System.Drawing.Point(3, 3);
            this.añadirActividadBoton.Name = "añadirActividadBoton";
            this.añadirActividadBoton.Size = new System.Drawing.Size(274, 64);
            this.añadirActividadBoton.TabIndex = 2;
            this.añadirActividadBoton.Text = "Añadir Actividad";
            this.añadirActividadBoton.UseVisualStyleBackColor = false;
            this.añadirActividadBoton.Click += new System.EventHandler(this.añadirActividad_Click);
            this.añadirActividadBoton.MouseLeave += new System.EventHandler(this.añadirActividadBoton_MouseLeave);
            this.añadirActividadBoton.MouseHover += new System.EventHandler(this.añadirActividadBoton_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.ActividadBoton);
            this.panel1.Controls.Add(this.añadirActividadBoton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 160);
            this.panel1.TabIndex = 5;
            this.panel1.MouseLeave += new System.EventHandler(this.ActividadBoton_Bt1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.panel2.Controls.Add(this.botonUsuario);
            this.panel2.Controls.Add(this.añadirUsuarioBoton);
            this.panel2.Controls.Add(this.inscribirUsuarioBoton);
            this.panel2.Location = new System.Drawing.Point(289, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 160);
            this.panel2.TabIndex = 6;
            this.panel2.MouseLeave += new System.EventHandler(this.botonUsuario_Leave);
            // 
            // botonUsuario
            // 
            this.botonUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.botonUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botonUsuario.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold);
            this.botonUsuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.botonUsuario.Location = new System.Drawing.Point(0, 0);
            this.botonUsuario.Name = "botonUsuario";
            this.botonUsuario.Size = new System.Drawing.Size(280, 160);
            this.botonUsuario.TabIndex = 1;
            this.botonUsuario.Text = "Usuario";
            this.botonUsuario.UseVisualStyleBackColor = false;
            this.botonUsuario.MouseEnter += new System.EventHandler(this.ActividadBoton_Ocultar);
            // 
            // añadirUsuarioBoton
            // 
            this.añadirUsuarioBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(129)))));
            this.añadirUsuarioBoton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.añadirUsuarioBoton.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold);
            this.añadirUsuarioBoton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.añadirUsuarioBoton.Location = new System.Drawing.Point(3, 3);
            this.añadirUsuarioBoton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.añadirUsuarioBoton.Name = "añadirUsuarioBoton";
            this.añadirUsuarioBoton.Size = new System.Drawing.Size(274, 64);
            this.añadirUsuarioBoton.TabIndex = 2;
            this.añadirUsuarioBoton.Text = "Añadir usuario";
            this.añadirUsuarioBoton.UseVisualStyleBackColor = false;
            this.añadirUsuarioBoton.Click += new System.EventHandler(this.button2_Click);
            // 
            // inscribirUsuarioBoton
            // 
            this.inscribirUsuarioBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(129)))));
            this.inscribirUsuarioBoton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inscribirUsuarioBoton.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold);
            this.inscribirUsuarioBoton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.inscribirUsuarioBoton.Location = new System.Drawing.Point(3, 67);
            this.inscribirUsuarioBoton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.inscribirUsuarioBoton.Name = "inscribirUsuarioBoton";
            this.inscribirUsuarioBoton.Size = new System.Drawing.Size(274, 68);
            this.inscribirUsuarioBoton.TabIndex = 3;
            this.inscribirUsuarioBoton.Text = "Inscribir usuario";
            this.inscribirUsuarioBoton.UseVisualStyleBackColor = false;
            this.inscribirUsuarioBoton.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.panel3.Controls.Add(this.botonMonitor);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(575, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 160);
            this.panel3.TabIndex = 6;
            this.panel3.MouseLeave += new System.EventHandler(this.botonMonitor_Leave);
            // 
            // botonMonitor
            // 
            this.botonMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.botonMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botonMonitor.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold);
            this.botonMonitor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.botonMonitor.Location = new System.Drawing.Point(0, 0);
            this.botonMonitor.Name = "botonMonitor";
            this.botonMonitor.Size = new System.Drawing.Size(280, 160);
            this.botonMonitor.TabIndex = 2;
            this.botonMonitor.Text = "Monitor";
            this.botonMonitor.UseVisualStyleBackColor = false;
            this.botonMonitor.MouseEnter += new System.EventHandler(this.ActividadBoton_Ocultar);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(181)))), ((int)(((byte)(129)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(274, 64);
            this.button2.TabIndex = 3;
            this.button2.Text = "Añadir monitor a una actividad";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.panel4.Controls.Add(this.botonSalas);
            this.panel4.Controls.Add(listar_salas);
            this.panel4.Location = new System.Drawing.Point(861, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(280, 160);
            this.panel4.TabIndex = 7;
            this.panel4.MouseLeave += new System.EventHandler(this.botonSalas_Leave);
            // 
            // botonSalas
            // 
            this.botonSalas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.botonSalas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botonSalas.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold);
            this.botonSalas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.botonSalas.Location = new System.Drawing.Point(0, 0);
            this.botonSalas.Name = "botonSalas";
            this.botonSalas.Size = new System.Drawing.Size(280, 160);
            this.botonSalas.TabIndex = 2;
            this.botonSalas.Text = "Salas";
            this.botonSalas.UseVisualStyleBackColor = false;
            this.botonSalas.MouseEnter += new System.EventHandler(this.ActividadBoton_Ocultar);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(90, 340);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1145, 188);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GestDepGUI.Properties.Resources.brus_buena_calidad;
            this.pictureBox1.Location = new System.Drawing.Point(241, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(855, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // GestDepApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1316, 725);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GestDepApp";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GestDepGUI";
            this.Load += new System.EventHandler(this.GestDepApp_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ActividadBoton;
        private System.Windows.Forms.Button añadirActividadBoton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button botonUsuario;
        private System.Windows.Forms.Button añadirUsuarioBoton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button botonSalas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button inscribirUsuarioBoton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button botonMonitor;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

