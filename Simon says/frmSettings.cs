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

            // Default buttons
            this.AcceptButton = this.btnAccept;
            this.CancelButton = this.btnCancel;

            // Populate the GridView
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Ask for overriding confirmation
            DialogResult result;
            using (new CenterWinDialog(this))
            {
                result = MessageBox.Show(this, "You are about to override the actual settings\n" +
                                                "with the default values.\n\n" +
                                                "Are you sure you want to continue?",
                                                "Override settings",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }

            // If "Yes", then reset values to default
            if (result == DialogResult.Yes)
            {
                //ApplySettings(_defaultSettings);
                //_settings["SplitterDistance"] = "0.5";
            }
        }

        private void btnFontFamily_Click(object sender, EventArgs e)
        {
            FontDialog frmFont = new FontDialog()
            {
                FontMustExist = true,
                Font = this.DemoBoard.Font,
                ShowApply = false,
                ShowColor = false,
                ShowEffects = false,
                ShowHelp = false
            };

            using (new CenterWinDialog(this))
            {
                if (frmFont.ShowDialog() == DialogResult.OK)
                {
                    this.DemoBoard.Font = new Font(frmFont.Font.FontFamily, this.DemoBoard.Font.SizeInPoints);
                    this.lblFontFamily.Text = "Font: " + frmFont.Font.FontFamily.Name;
                }
            }
            // https://stackoverflow.com/questions/2207709/convert-font-to-string-and-back-again
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


    }
}
