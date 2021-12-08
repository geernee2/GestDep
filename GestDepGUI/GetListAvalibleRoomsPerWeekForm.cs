using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestDep.Services;


namespace GestDepGUI
{
    public partial class GetListAvalibleRoomsPerWeekForm : Form
    {
        private IGestDepService service;
        private Dictionary<DateTime, int> avalibleRooms;
        DateTime lunes;

        List<string[]> dataForDataGrid;


        public GetListAvalibleRoomsPerWeekForm(IGestDepService service)
        {
         
            this.service = service;  

            

            DateTime fecha_actual = DateTime.Now;
            if (fecha_actual.DayOfWeek != DayOfWeek.Monday)
            {
                for (int i = 0; i < 6; i++)
                {
                    fecha_actual = fecha_actual.AddDays(-1);
                    if (fecha_actual.DayOfWeek == DayOfWeek.Monday)
                        i = 7;

                }
            }

            avalibleRooms = service.GetListAvailableRoomsPerWeek(fecha_actual);

            dataForDataGrid = new List<string[]>();
            generateGrid(fecha_actual);

            InitializeComponent();

            label2.Text = fecha_actual.ToString("dd/MM/yyyy") +" - "+ fecha_actual.AddDays(6).ToString("dd/MM/yyyy");

            insertInDataGrid();

            




        }
      
        private void generateGrid(DateTime lunes)
        {

           

            int dayAct = -1;
            int col = 0;
            int row = 0;

            foreach (KeyValuePair<DateTime, int> hour in avalibleRooms)
            {
                if (hour.Key.Day != dayAct)
                {
                    if (dayAct != -1)                                             
                         break;                   
                   
                     dayAct = hour.Key.Day;
                                   
                }

                String aux = hour.Key.Hour.ToString();
                aux = aux.Length == 1 ? "0" + aux : aux;
                string hour1 = aux + ":";

                aux = hour.Key.Minute.ToString();
                aux = aux.Length == 1 ? "0" + aux : aux;
                hour1 += aux;

                aux = hour.Key.AddMinutes(45).Hour.ToString();
                aux = aux.Length == 1 ? "0" + aux : aux;
                string hour2 = aux + ":";

                aux = hour.Key.AddMinutes(45).Minute.ToString();
                aux = aux.Length == 1 ? "0" + aux : aux;
                hour2 += aux;

                string [] rowInicialiceAndEnterHourData = new string[8];
                rowInicialiceAndEnterHourData[0] = hour1 + "-" + hour2;

                dataForDataGrid.Add(rowInicialiceAndEnterHourData);

            }
            dayAct = -1;
            foreach (KeyValuePair<DateTime, int> hour in avalibleRooms)
            {
                if (hour.Key.Day != dayAct)
                {                  
                        

                    dayAct = hour.Key.Day;
                    row = 0;
                    col++;
                }

                //insertValue(row, col, hour.Value);
                dataForDataGrid[row][col] = hour.Value.ToString();
                row++;

            }

        }

        private void createRowHours(List<string> hoursGym)
        {
            foreach(string hourRange in hoursGym)
            {
             
            }
        }

        private void insertInDataGrid()
        {
            foreach(string [] row in dataForDataGrid)
            {               

                dataGridView1.Rows.Add(row);
                dataGridView1.Rows.Insert(1, row);
            }           
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Test date an get available rooms
            lunes = dateTimePicker1.Value;

            if (lunes.DayOfWeek != DayOfWeek.Monday)
            {
                errorFecha.Visible = true;
            }
            else
            {
                avalibleRooms = service.GetListAvailableRoomsPerWeek(lunes);

                dataForDataGrid = new List<string[]>();
                generateGrid(lunes);
                dataGridView1.Rows.Clear();
                insertInDataGrid();
                label2.Text = lunes.ToString("dd/MM/yyyy") + " - " + lunes.AddDays(6).ToString("dd/MM/yyyy");

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (errorFecha.Visible)
            {
                DateTime fecha = dateTimePicker1.Value;

                if (fecha.DayOfWeek == DayOfWeek.Monday)
                {
                    errorFecha.Visible = false;
                }
            }
        }

        private void GetListAvalibleRoomsPerWeekForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
