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

namespace Sercurity_Panel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txt_Code.Text += btn.Text;
            txt_Code.Focus();
            txt_Code.SelectionStart = txt_Code.Text.Length;
        }

        private void btn_Sharp_Click(object sender, EventArgs e)
        {
            string code = txt_Code.Text;
            string str = "";
            switch (code)
            {
                case "1645":
                case "1689":
                    str = "Technicians";
                    break;
                case "8345":
                    str = "Custodians";
                    break;
                case "9998":
                case "1006":
                case "1008":
                    str = "Scientist";
                    break;
                default:
                    str = "Restricted Access";
                    break;
            }
            list_Access.Items.Add(DateTime.Now.ToString("dd:MM:yyyy hh:mm:ss") + "       " + str);
            txt_Code.Text = "";
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            txt_Code.Text = "";
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string path = "Save.txt";//Luu file trong bin\Debug\Save.txt
            StreamWriter file;

            if (MessageBox.Show("Bạn có chắc muốn lưu?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!File.Exists(path))
                {
                    file = new StreamWriter(path);
                    foreach (string item in list_Access.Items)
                    {
                        file.WriteLine(item);
                    }
                    file.Close();
                }
                else
                {
                    file = File.AppendText(path);
                    foreach (string item in list_Access.Items)
                    {
                        file.WriteLine(item);
                    }
                    file.Close();
                }
                MessageBox.Show("Lưu thành công!!");
            }
        }
    }
}
