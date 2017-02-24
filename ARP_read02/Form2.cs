using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARP_read02
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Form1.max_ip + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Read the contents of testDialog's TextBox.
            Form1.max_ip = Convert.ToInt32(this.TextBox1.Text);
            this.Dispose();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            TextBox1.Text = Form1.max_ip + "";
        }
    }
}
