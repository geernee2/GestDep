
namespace GestDepGUI
{
    partial class FormAñadirActividad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAñadirActividad));
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.maskedTextBoxHora = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMin = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBoxMax = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkedListBoxDS = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.checkedListBoxSalasDisponibles = new System.Windows.Forms.CheckedListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBoxDuracion = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxPrecio = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.descripcionBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(198, 67);
            this.dateTimePicker2.MinDate = new System.DateTime(2021, 1, 5, 10, 28, 1, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 0;
            this.dateTimePicker2.Value = new System.DateTime(2021, 1, 5, 10, 28, 1, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de comienzo:";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(198, 94);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 2;
            this.dateTimePicker3.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de finalización:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lato", 8.999999F);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(242, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "€";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hora de inicio: (hh/mm)";
            // 
            // botonAceptar
            // 
            this.botonAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.botonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botonAceptar.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAceptar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.botonAceptar.Location = new System.Drawing.Point(367, 617);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(75, 23);
            this.botonAceptar.TabIndex = 11;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = false;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // maskedTextBoxHora
            // 
            this.maskedTextBoxHora.BeepOnError = true;
            this.maskedTextBoxHora.Location = new System.Drawing.Point(198, 41);
            this.maskedTextBoxHora.Mask = "00:00";
            this.maskedTextBoxHora.Name = "maskedTextBoxHora";
            this.maskedTextBoxHora.ResetOnSpace = false;
            this.maskedTextBoxHora.Size = new System.Drawing.Size(38, 20);
            this.maskedTextBoxHora.TabIndex = 12;
            this.maskedTextBoxHora.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxHora.Click += new System.EventHandler(this.clickToBegining);
            // 
            // maskedTextBoxMin
            // 
            this.maskedTextBoxMin.BeepOnError = true;
            this.maskedTextBoxMin.Location = new System.Drawing.Point(198, 444);
            this.maskedTextBoxMin.Mask = "000";
            this.maskedTextBoxMin.Name = "maskedTextBoxMin";
            this.maskedTextBoxMin.ResetOnSpace = false;
            this.maskedTextBoxMin.Size = new System.Drawing.Size(38, 20);
            this.maskedTextBoxMin.TabIndex = 13;
            this.maskedTextBoxMin.ValidatingType = typeof(int);
            this.maskedTextBoxMin.Click += new System.EventHandler(this.clickToBegining);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(3, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Mínimo de inscritos:";
            // 
            // maskedTextBoxMax
            // 
            this.maskedTextBoxMax.BeepOnError = true;
            this.maskedTextBoxMax.Location = new System.Drawing.Point(198, 470);
            this.maskedTextBoxMax.Mask = "000";
            this.maskedTextBoxMax.Name = "maskedTextBoxMax";
            this.maskedTextBoxMax.ResetOnSpace = false;
            this.maskedTextBoxMax.Size = new System.Drawing.Size(38, 20);
            this.maskedTextBoxMax.TabIndex = 15;
            this.maskedTextBoxMax.ValidatingType = typeof(int);
            this.maskedTextBoxMax.Click += new System.EventHandler(this.clickToBegining);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(3, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Máximo de inscritos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(3, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Días de la semana:";
            // 
            // checkedListBoxDS
            // 
            this.checkedListBoxDS.FormattingEnabled = true;
            this.checkedListBoxDS.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.checkedListBoxDS.Location = new System.Drawing.Point(198, 120);
            this.checkedListBoxDS.Name = "checkedListBoxDS";
            this.checkedListBoxDS.Size = new System.Drawing.Size(142, 109);
            this.checkedListBoxDS.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.buttonBuscar);
            this.panel1.Controls.Add(this.checkedListBoxSalasDisponibles);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.maskedTextBoxDuracion);
            this.panel1.Controls.Add(this.maskedTextBoxPrecio);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.descripcionBox);
            this.panel1.Controls.Add(this.botonAceptar);
            this.panel1.Controls.Add(this.checkedListBoxDS);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dateTimePicker3);
            this.panel1.Controls.Add(this.maskedTextBoxMax);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.maskedTextBoxMin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.maskedTextBoxHora);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(35, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 651);
            this.panel1.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label15.Location = new System.Drawing.Point(3, 261);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(161, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "Buscar salas disponibles:";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(198, 261);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 28;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // checkedListBoxSalasDisponibles
            // 
            this.checkedListBoxSalasDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxSalasDisponibles.FormattingEnabled = true;
            this.checkedListBoxSalasDisponibles.Location = new System.Drawing.Point(198, 295);
            this.checkedListBoxSalasDisponibles.Name = "checkedListBoxSalasDisponibles";
            this.checkedListBoxSalasDisponibles.Size = new System.Drawing.Size(142, 92);
            this.checkedListBoxSalasDisponibles.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.Location = new System.Drawing.Point(3, 295);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(190, 15);
            this.label14.TabIndex = 26;
            this.label14.Text = "Seleccionar salas disponibles:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(3, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "Duración: (hh/mm)";
            // 
            // maskedTextBoxDuracion
            // 
            this.maskedTextBoxDuracion.BeepOnError = true;
            this.maskedTextBoxDuracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxDuracion.Location = new System.Drawing.Point(198, 15);
            this.maskedTextBoxDuracion.Mask = "00:00";
            this.maskedTextBoxDuracion.Name = "maskedTextBoxDuracion";
            this.maskedTextBoxDuracion.ResetOnSpace = false;
            this.maskedTextBoxDuracion.Size = new System.Drawing.Size(38, 20);
            this.maskedTextBoxDuracion.TabIndex = 24;
            this.maskedTextBoxDuracion.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxDuracion.Click += new System.EventHandler(this.clickToBegining);
            // 
            // maskedTextBoxPrecio
            // 
            this.maskedTextBoxPrecio.BeepOnError = true;
            this.maskedTextBoxPrecio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBoxPrecio.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.maskedTextBoxPrecio.Location = new System.Drawing.Point(198, 418);
            this.maskedTextBoxPrecio.Mask = "000,00";
            this.maskedTextBoxPrecio.Name = "maskedTextBoxPrecio";
            this.maskedTextBoxPrecio.ResetOnSpace = false;
            this.maskedTextBoxPrecio.Size = new System.Drawing.Size(38, 20);
            this.maskedTextBoxPrecio.TabIndex = 23;
            this.maskedTextBoxPrecio.Click += new System.EventHandler(this.clickToBegining);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(3, 498);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Descripción:";
            // 
            // descripcionBox
            // 
            this.descripcionBox.Location = new System.Drawing.Point(198, 496);
            this.descripcionBox.Name = "descripcionBox";
            this.descripcionBox.Size = new System.Drawing.Size(157, 96);
            this.descripcionBox.TabIndex = 21;
            this.descripcionBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(3, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Precio:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lato", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(32, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 17);
            this.label12.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lato", 8.999999F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(15, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(330, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "Introduzca los datos de la actividad que desea crear:";
            // 
            // FormAñadirActividad
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(511, 709);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAñadirActividad";
            this.Text = "Añadir Actividad";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHora;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox checkedListBoxDS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox descripcionBox;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDuracion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox checkedListBoxSalasDisponibles;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonBuscar;
    }
}