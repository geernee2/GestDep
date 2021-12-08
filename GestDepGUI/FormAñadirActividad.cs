using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GestDep.Entities;
using GestDep.Services;

namespace GestDepGUI
{
    public partial class FormAñadirActividad : Form
    {
        DateTime startDate;
        DateTime finishDate;
        double price;
        DateTime startHour;
        int minimumEnrollments;
        int maximumEnrollments;
        Days activityDays;
        string description;
        TimeSpan duration;
        //ICollection<int> roomsIds;
        List<int> roomsIds;
        ICollection<int> salasDisponibles;
        private IGestDepService service;
        

        public FormAñadirActividad(IGestDepService service)
        {
            this.service = service;
            InitializeComponent();
            dateTimePicker2.MinDate = DateTime.Now;
            dateTimePicker3.MinDate = DateTime.Now;
            roomsIds = new List<int>();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = (DateTimePicker) sender;
            startDate = dateTimePicker.Value;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = (DateTimePicker)sender;
            finishDate = dateTimePicker.Value;
        }
        

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            String mensaje="";
            //comprueba que el campo de precio no esté vacío
            char[] charsToTrim = {' '};
            if (maskedTextBoxPrecio.Text.Trim(charsToTrim).Length > 1) {
                String valor = maskedTextBoxPrecio.Text;
                char[] charsToTrim2 = {'0'};
                valor = valor.TrimStart(charsToTrim2);
                price = Convert.ToDouble(valor);
            }else{
                mensaje = "Error: Precio es un campo obligatorio\n";
            }

            //comprueba que la hora sea valida
            if (maskedTextBoxHora.Text.Length == 5)
            {
                String hora = maskedTextBoxHora.Text;
                String hh = hora.Substring(0, 2);
                String mm = hora.Substring(3, 2);
                int horaInt = Int32.Parse(hh);
                int minsInt = Int32.Parse(mm);
                if (horaInt < 24 && minsInt < 60){
                    startHour = new DateTime(startDate.Year, startDate.Month, startDate.Day, horaInt, minsInt, 00);
                }
                else{
                    mensaje += "Error: Hora de inicio no valida\n";
                }

            }else{
                mensaje += "Error: Hora de inicio es un campo obligatorio\n";
            }

            //comprueba que minimo (y máximo) de inscritos no este vacío
            if (maskedTextBoxMin.Text.Length>0) {
                String valor = maskedTextBoxMin.Text;
                char[] charsToTrim2 = { '0' };
                valor = valor.TrimStart(charsToTrim2);
                minimumEnrollments = Int32.Parse(valor.Trim());

            }else{
                mensaje += "Error: Mínimo de inscritos es un campo obligatorio\n";
            }
            if (maskedTextBoxMax.Text.Length>0){
                String valor = maskedTextBoxMax.Text;
                char[] charsToTrim2 = { '0' };
                valor = valor.TrimStart(charsToTrim2);
                maximumEnrollments = Int32.Parse(valor.Trim());
            }
            else{
                mensaje += "Error: Máximo de inscritos es un campo obligatorio\n";
            }

            //comprueba que minimo de inscritos sea menor que maximo de inscritos
            if (minimumEnrollments > maximumEnrollments) mensaje += "Error: Mínimo de inscritos no puede ser mayor que máximo de inscritos";

            //comprueba los dias checkeados
            activityDays = Days.None;
            foreach (object o in checkedListBoxDS.CheckedItems) {
                String dia = (String)o;
                if (dia.Equals("Lunes")) {
                    activityDays |= Days.Mon;
                } else if (dia.Equals("Martes")) {
                    activityDays |= Days.Tue;
                } else if (dia.Equals("Miércoles")) {
                    activityDays |= Days.Wed;
                } else if (dia.Equals("Jueves")) {
                    activityDays |= Days.Thu;
                } else if (dia.Equals("Viernes")) {
                    activityDays |= Days.Fri;
                } else if (dia.Equals("Sábado")) {
                    activityDays |= Days.Sat;
                } else if (dia.Equals("Domingo")) {
                    activityDays |= Days.Sun;
                }
            }
            if (checkedListBoxDS.CheckedItems.Count == 0){
            
               activityDays = Days.None;
                mensaje += "Error: Debe seleccionar un  dia de la semana\n";
            }

            //comprueba que la descripcion no este vacia
            if (descripcionBox.TextLength > 0){
                description = descripcionBox.Text;
                Console.WriteLine(description);
            }
            else{
                mensaje += "Error: Descripción es un campo obligatorio\n";
            }

            //comprueba que la duración no esté vacía
            String aux = maskedTextBoxDuracion.Text.Replace(" ", "");
            if (aux.Length == 5) {
                String duracion = maskedTextBoxDuracion.Text;
                int horas = Int32.Parse(duracion.Substring(0,2));
                int mins = Int32.Parse(duracion.Substring(3,2));
                if(horas < 24 && mins < 60){
                    duration = new TimeSpan(horas, mins, 00);
                }
                else{
                    mensaje += "Error: La duracion debe ser menor que 24 horas";
                }
            }
            else{
                mensaje += "Error: Duración es un campo obligatorio\n";
            }

            //coge las ids de las salas que esten checked y los mete en roomsIds
            if (checkedListBoxSalasDisponibles.CheckedItems.Count > 0){
                foreach (int id in checkedListBoxSalasDisponibles.CheckedItems){
                    
                    roomsIds.Add(id);
                }
            }
            else{
                mensaje += "Error: No hay salas disponibles seleccionadas\n";
            }

            //comprueba que startDate es fecha valida
            mensaje += compruebaFechas();
            if (startDate > finishDate) mensaje += "Error: Fecha de finalización es anterior a fecha de comienzo\n";
           

            //creacion dialogo de error
            if (mensaje.Length > 0){
                DialogResult answer = MessageBox.Show(this,
                mensaje,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
            else{
                try {
                    int id = service.AddNewActivity(activityDays, description, duration, finishDate, maximumEnrollments, minimumEnrollments, price, startDate, startHour, roomsIds);
                    DialogResult answer = MessageBox.Show(this,
                        "¡Su actividad con id: "+id+" se ha almacenado correctamente!\n",
                        "¡Perfecto!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    this.Dispose();
                }
                catch (ServiceException excep)
                {
                    DialogResult answer = MessageBox.Show(this,
                    "Error: Ya hay una actividad en curso en el rango horario indicado, cambie las salas o el horario\n",
                     "Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error
                      );
                    
                }
                
            }
            
        }

        private void clickToBegining(object sender, EventArgs e)
        {
            MaskedTextBox obj = (MaskedTextBox) sender;
            obj.Select(0,0);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            String mensaje = "";

//comprueba que la hora sea valida ----------------------------
            if (maskedTextBoxHora.Text.Length == 5)
            {
                String hora = maskedTextBoxHora.Text;
                String hh = hora.Substring(0, 2);
                String mm = hora.Substring(3, 2);
                int horaInt = Int32.Parse(hh);
                int minsInt = Int32.Parse(mm);
                if (horaInt < 24 && minsInt < 60){
                
                    startHour = new DateTime(startDate.Year, startDate.Month, startDate.Day, horaInt, minsInt, 00);
                }
                else{
                    mensaje += "Error: Hora de inicio no valida\n";
                }

            }
            else
            {
                mensaje += "Error: Hora de inicio es un campo obligatorio\n";
            }
//--------------------------------------------------------------------------------

//comprueba que la duración no esté vacía ----------------------------
            String aux = maskedTextBoxDuracion.Text.Replace(" ", "");
            if (aux.Length == 5)
            {
                String duracion = maskedTextBoxDuracion.Text;
                int horas = Int32.Parse(duracion.Substring(0, 2));
                int mins = Int32.Parse(duracion.Substring(3, 2));
                duration = new TimeSpan(horas, mins, 00);
            }
            else
            {
                mensaje += "Error: Duración es un campo obligatorio\n";
            }
            //-----------------------------------------------------------------

//comprueba los dias checkeados ------------------------------------
            activityDays = Days.None;
            foreach (object o in checkedListBoxDS.CheckedItems)
            {
                String dia = (String)o;
                if (dia.Equals("Lunes"))
                {
                    activityDays |= Days.Mon;
                }
                else if (dia.Equals("Martes"))
                {
                    activityDays |= Days.Tue;
                }
                else if (dia.Equals("Miércoles"))
                {
                    activityDays |= Days.Wed;
                }
                else if (dia.Equals("Jueves"))
                {
                    activityDays |= Days.Thu;
                }
                else if (dia.Equals("Viernes"))
                {
                    activityDays |= Days.Fri;
                }
                else if (dia.Equals("Sábado"))
                {
                    activityDays |= Days.Sat;
                }
                else if (dia.Equals("Domingo"))
                {
                    activityDays |= Days.Sun;
                }
            }
            if (checkedListBoxDS.CheckedItems.Count == 0)
            {
                activityDays = Days.None;
                mensaje += "Error: Debe seleccionar un  dia de la semana\n";
            }
            //-----------------------------------------------------------------
            mensaje += compruebaFechas();
            if (startDate > finishDate) mensaje += "Error: Fecha de finalización es anterior a fecha de comienzo\n";

            if (mensaje.Length == 0){
               salasDisponibles = service.GetListAvailableRoomsIds(activityDays, duration, finishDate, startDate, startHour);
               foreach (int id in salasDisponibles){

                    checkedListBoxSalasDisponibles.Items.Add(id, false);
                }
            }
            else{

                DialogResult answer = MessageBox.Show(this,
                mensaje,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }

        }

        public String compruebaFechas() {
            String mensaje = "";
            if (startDate.Day == DateTime.Now.Day && startDate.Year == DateTime.Now.Year && startDate.Month == DateTime.Now.Month)
                mensaje = "Error: La fecha de comienzo no puede ser hoy\n";
            return mensaje;
        }

    }
} 

