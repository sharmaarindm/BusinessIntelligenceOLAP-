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
