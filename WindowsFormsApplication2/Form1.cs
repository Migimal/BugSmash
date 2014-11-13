using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class AdjustSettings : Form
    {
        public AdjustSettings()
        {
            InitializeComponent();
        }

        private void TextBoxEnemy_Click(object sender, System.EventArgs e)
        {
            Stream myStream = null;
            DialogResult result = openFileDialogEnemy.ShowDialog();
            if(result == DialogResult.OK)
            {

            }
            Console.WriteLine(result);
        }
    }
}
