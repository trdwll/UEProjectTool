using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UEProjectTool
{
    public partial class frmIgnores : Form
    {
        public frmIgnores()
        {
            InitializeComponent();
        }

        private void frmIgnores_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void frmIgnores_FormClosing(object sender, FormClosingEventArgs e)
        {
           try
           {
                Properties.Settings.Default.Ignores.Clear();
                foreach (ListViewItem item in listView1.Items)
                {
                    Properties.Settings.Default.Ignores.Add(item.Text);
                }

                Properties.Settings.Default.Save();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }

        void LoadSettings()
        {
            try
            {
                foreach (var item in Properties.Settings.Default.Ignores)
                {
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CurDir = Application.StartupPath;
            ListViewItem item = listView1.Items.Add($"{CurDir}/Directory/or/File");
            item.BeginEdit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].Remove();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);

            if (item != null)
            {
                item.BeginEdit();
            }
        }
    }
}
