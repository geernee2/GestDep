using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestDep.Entities;
using GestDep.Services;

namespace GestDepGUI
{
    public partial class AñadirMonitorActividad : Form
    {
        private IGestDepService service;

        Days activityDays = Days.None;
        String description = "";
        TimeSpan duration = new TimeSpan();
        DateTime finishDate = new DateTime();
        int maximumEnrollments = 0;
        int minimumEnrollments = 0;
        double price = 0.00;
        DateTime startDate = new DateTime();
        DateTime startHour = new DateTime();
        ICollection<int> enrollmentIds = new List<int>();
        String instructorId = "";
        ICollection<int> roomIds = new List<int>();

        String address = "";
        String IBAN = "";
        String name = "";
        int  zipCode = 0;
        String ssn = "";
        ICollection<int> activitiesIds = new List<int>();

        int eleccion;
        String id;
        public AñadirMonitorActividad(IGestDepService service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void seleccionarActividad(object sender, EventArgs e){
            
            comboBoxSeleccionarActividad.Items.Clear();
            List<int> idsActs = service.GetAllActivitiesIds().ToList();
            if (idsActs.Count() != 0)
            {
                foreach (int id in idsActs){
                    service.GetActivityDataFromId(id, out activityDays, out description, out duration, out finishDate, out maximumEnrollments,
                        out minimumEnrollments, out price, out startDate, out startHour, out enrollmentIds, out instructorId, out roomIds);

                    comboBoxSeleccionarActividad.Items.Add(id);

                }
            }
           
        }

        private void actividadSeleccionada(object sender, EventArgs e)
        {
            eleccion = (int) comboBoxSeleccionarActividad.SelectedItem;
            service.GetActivityDataFromId(eleccion, out activityDays, out description, out duration, out finishDate, out maximumEnrollments,
                        out minimumEnrollments, out price, out startDate, out startHour, out enrollmentIds, out instructorId, out roomIds);
            richTextBox1.Text = description;
            if (instructorId == "") {
                textBox1.Text = "No asignado";
            }
            else{
            
                textBox1.Text = "Ya asignado";
            }
            

        }

        private void mostrarMonitoresDisponibles(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            ICollection<String> listaMonitores = service.GetAvailableInstructorsIds(activityDays, duration,  finishDate,  startDate,  startHour);
            foreach (String id in listaMonitores)
            {
                service.GetInstructorDataFromId(id, out address, out IBAN, out name, out zipCode, out ssn, out activitiesIds);
                comboBox2.Items.Add(id);

            }
            
        }

        private void monitorDisponibleSeleccionado(object sender, EventArgs e){
       
            id = comboBox2.SelectedItem.ToString();
        }

        private void aceptar_Click(object sender, EventArgs e){
            Console.WriteLine(eleccion +" "+ id);
            try
            {
                service.AssignInstructorToActivity(eleccion, id);
                DialogResult answer = MessageBox.Show(this,
                    "Instructor asignado a la actividad con éxito",
                    "¡Perfecto!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                this.Close();
            }
            catch (ServiceException excep)
            {
                DialogResult answer = MessageBox.Show(this,
                 "Error: Hubo un error\n",
                 "Error",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
                  );

            }
        }

        private void verMas_Click(object sender, EventArgs e)
        {
            verInformacionActividad formulario = new verInformacionActividad(service, eleccion);
            formulario.Show();
        }
    }
}
