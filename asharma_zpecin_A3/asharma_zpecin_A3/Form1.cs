using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asharma_zpecin_A3
{
    public partial class Form1 : Form
    {
        string[] lines;
        string[] products;

        DAL myDal = new DAL();
        public Form1()
        {
            InitializeComponent();

        }

        private void LinescheckBox_CheckedChanged(object sender, EventArgs e)
        {
            myDal.getAllLines();
        }
    }
}
