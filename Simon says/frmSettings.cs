using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            List<(int Value, float Frequency, string Color)> lista = new List<(int Value, float Frequency, string Color)>();
            lista.Add((0, 460, "0000FF"));
            lista.Add((1, 460, "FF00FF"));
            lista.Add((2, 460, "00FF00"));
            lista.Add((3, 460, "FF0000"));
            
            List<string> lista2 = new List<string>();
            lista2.Add("algo");
            lista2.Add("para");
            lista2.Add("probar");

            /*
            gridButtons.DataSource = lista.Select(i => new
            {
                i.Value,
                i.Frequency,
                i.Color
            });
            */
            var bindingList = new BindingList<(int Value, float Frequency, string Color)>(lista);
            var source = new BindingSource(bindingList, null);
            gridButtons.DataSource = source;
            //gridButtons.DataSource = lista2;

            //var item = new Tuple<string, string>($"Row : {i}, Col: One", $"Row: {i}, Col: Two");

            DataTable table= new DataTable();
            table.Columns.Add("Value", typeof(Int32));
            table.Columns.Add("Frequency", typeof(float));
            table.Columns.Add("Color", typeof(string));

            var algo = lista.Select(i => new object[]
            {
                i.Value,
                i.Frequency,
                i.Color
            });

            foreach ((int Value, float Frequency, string Color) row in lista)
            {
                table.Rows.Add(new object[]{row.Value, row.Frequency, row.Color});
            }
            /*
            table.Rows.Add(lista.Select(i => new
            {
                i.Value,
                i.Frequency,
                i.Color
            }));*/
            gridButtons.DataSource = table;
        }

        private void numButtons_ValueChanged(object sender, EventArgs e)
        {
            DemoBoard.NumberOfButtons = (Int32)numButtons.Value;
            trackButtons.Value = (Int32)numButtons.Value;
        }

        private void numButtonDistance_ValueChanged(object sender, EventArgs e)
        {
            DemoBoard.CenterButtonRatio = (float)numButtonDistance.Value;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
