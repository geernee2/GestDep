using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestDepGUI
{
    public partial class GestDepApp : Form
    {

        public GestDepApp()
        {
            
            InitializeComponent();

        }
    
        private void GestDepApp_Load(object sender, EventArgs e)
        {
            
        }


        private void añadirActividad_Click(object sender, EventArgs e)
        {
            FormAñadirActividad myForm = new FormAñadirActividad(service);
            myForm.Show();
        }

        private void ActividadBoton_Ocultar(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            boton.Size = new Size(0, 0);

              boton.Hide();
        }

        private void ActividadBoton_Mostrar(object sender, EventArgs e)
        {
            Button boton = (Button)sender;          
            boton.Show();
        }
        private void ActividadBoton_Bt1(object sender, EventArgs e)
        {
            Button boton = ActividadBoton;
            boton.Size = new Size(280, 160);
            boton.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void ActividadBoton_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void añadirActividadBoton_MouseHover(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
           // boton.BackColor = Color.FromArgb(47,47,47);
            boton.Cursor = System.Windows.Forms.Cursors.Hand;

        }

        private void añadirActividadBoton_MouseLeave(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
          
            boton.Cursor = System.Windows.Forms.Cursors.Default;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void listar_salas_Click(object sender, EventArgs e)
        {
            new GetListAvalibleRoomsPerWeekForm(service).Show();
        }

        private void botonUsuario_Leave(object sender, EventArgs e)
        {
            Button boton = botonUsuario;
            boton.Size = new Size(280, 160);
            boton.Show();
        }

        private void botonMonitor_Leave(object sender, EventArgs e)
        {
            Button boton = botonMonitor;
            boton.Size = new Size(280, 160);
            boton.Show();
        }

        private void botonSalas_Leave(object sender, EventArgs e)
        {
            Button boton = botonSalas;
            boton.Size = new Size(280, 160);
            boton.Show();
        }

    }
}
