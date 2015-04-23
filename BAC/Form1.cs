using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        public void calc(object sender, System.EventArgs e)
        {
            //Widmark Formula %BAC = (A x 5.14/W x r) - .015 x H
            double A = Convert.ToDouble(valDrinks.Text);
            double W = Convert.ToDouble(valWeight.Text);
            double H = Convert.ToDouble(valHours.Text);
            double rFem = 0.66;
            double rmale = 0.73;
            double BAC;



            if (radFemale.Checked)
            {
                BAC = (A * 5.14) / (W * rFem) - .015 * H;
            }
            else
            {
                BAC = (A * 5.14) / (W * rmale) - .015 * H;
            }
            if (BAC < 0)
            {
                BAC = 0.00;
            }

            lblBAC.Text = (BAC.ToString("0.#####"));

            if (BAC >= 0.00 && BAC < 0.02)
            {
                lblAnalysis.Text = "Sober State";
                lblAnalysis2.Text = "";
                lblAnalysis3.Text = "";
            }

            if (BAC >= 0.02 && BAC < 0.05)
            {
                lblAnalysis.Text = "Loss of Judgment";
                lblAnalysis2.Text = "Trouble doing two tasks at the same time";
                lblAnalysis3.Text = "";
                lblBAC.ForeColor = Color.Black;
            }
            else if (BAC >= 0.05 && BAC < 0.08)
            {
                lblAnalysis.Text = "Reduced coordination and ability to track moving objects";
                lblAnalysis2.Text = "Difficulty steering";
                lblAnalysis3.Text = "";
                lblBAC.ForeColor = Color.Black;
            }
            else if (BAC >= 0.08 && BAC < 0.10)
            {
                lblAnalysis.Text = "Trouble controlling speed";
                lblAnalysis2.Text = "Difficulty processing information and reasoning";
                lblAnalysis3.Text = "0.08% and over is legally impaired in all states";
                lblBAC.ForeColor = Color.Red;
            }
            else if (BAC >= 0.10 && BAC < 0.15)
            {
                lblAnalysis.Text = "Markedly slowed reaction time";
                lblAnalysis2.Text = "Difficulty staying in lane and braking when needed";
                lblAnalysis3.Text = "0.08% and over is legally impaired in all states";
                lblBAC.ForeColor = Color.Red;
            }
            else if (BAC >= 0.15)
            {
                lblAnalysis.Text = "Serious difficulty controlling the car and focusing on driving";
                lblAnalysis2.Text = "0.08% and over is legally impaired in all states";
                lblAnalysis3.Text = "";
                lblBAC.ForeColor = Color.Red;
            }
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            lblAnalysis.Text = String.Empty;
            lblAnalysis2.Text = String.Empty;
            lblAnalysis3.Text = String.Empty;
            lblBAC.Text = String.Empty;
            RecursiveClearTextBoxes(this.Controls);
            var cntls = GetAll(this, typeof(RadioButton));
            foreach (Control cntrl in cntls)
            {
                RadioButton _rb = (RadioButton)cntrl;
                if (_rb.Checked)
                {
                    _rb.Checked = false;

                }
            }

        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrls => GetAll(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
        }
        
        private void RecursiveClearTextBoxes(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                TextBox tb = ctrl as TextBox;
                if (tb != null)
                    tb.Clear();
                else
                    RecursiveClearTextBoxes(ctrl.Controls);
            }
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.softpedia.com/get/Others/Finances-Business/Bartender-Express.shtml");
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.softpedia.com/get/Others/Finances-Business/Pub-Grub.shtml");
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lolliesoft Blood Alcohol Calculator Version 2.0\nCopyright © 2013 LollieSoft Inc.\nwww.lolliesoft.com", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitter.com/lolliesoft");
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.facebook.com/BartenderExpress");
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + "\\BAChelp.chm");
        }
    }
}
