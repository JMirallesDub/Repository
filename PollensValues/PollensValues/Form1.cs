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

namespace PollensValues
{
    public partial class Form1 : Form
    {
        public string route;
        public ReadCsvFile fichero = new ReadCsvFile();
        public Form1()
        {
            InitializeComponent();

            

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            fichero.ReadCsvFileData(openFileDialog1.FileName, dataGridView1);

            //dataGridView1.DataSource=         
                
                }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    }
}
