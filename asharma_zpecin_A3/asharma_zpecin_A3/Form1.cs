

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace asharma_zpecin_A3
{
    public partial class Form1 : Form
    {
        string[] productList = { "Original Sleeper","Black Beauty","Firecracker","Lemon Ring","Midnight Blue","Screaming Orange","Gold Glitter","White Lighteneni"};
        string[] lineList = {"Line0", "Line1","Line2", "Line3", "Line4", "Line5" };
        double[] amountArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        double sumPrevFreq = 0;
        double frequencySum = 0;

        Dictionary<string, double> sortedDIc = new Dictionary<string,double>();

        DataTable dt = new DataTable();
        DAL myDal = new DAL();
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < productList.Length; i++)
            {
                ProductsCombo.Items.Add(productList[i]);
            }
            for (int i = 0; i < lineList.Length; i++)
            {
                LinesCombo.Items.Add(lineList[i]);
            }

        }

        void populateSortedDic()
        {
            sortedDIc.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string value;
                double key;

                Double.TryParse(row["dataCount"].ToString(), out key);
                value = row["reason"].ToString();

                sortedDIc.Add(value, key);
            }
        }
        private void LinescheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(LinescheckBox.Checked)
            {
                LinesCombo.Enabled = false;
            }
            else
            {
                LinesCombo.Enabled = true;
            }
        }

        void checkstatus()
        {
            DataTable dataT = new DataTable();
            if (ProductscheckBox.Checked)
            {
                if(LinescheckBox.Checked) //if both are checked
                {
                    dataT = myDal.getAllLines("Line", "Description");
                }
                else //if just products are checked
                {
                    dataT = myDal.getAllLines(LinesCombo.Text.ToString(), "Description");
                }
            }
            else
            {
                if (LinescheckBox.Checked) //if just lines is checked
                {
                    dataT = myDal.getAllLines("Line", ProductsCombo.Text.ToString());
                }
                else //if none of them is checked
                {
                    dataT = myDal.getAllLines(LinesCombo.Text.ToString(), ProductsCombo.Text.ToString());
                }
            }
            // update the table:
            dt = dataT;
            readIntoAmountArray();
            updatePareto();

        }

        private void ProductscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ProductscheckBox.Checked)
            {
                ProductsCombo.Enabled = false;
            }
            else
            {
                ProductsCombo.Enabled = true;
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            checkstatus();
        }

        /*
       * FUNCTION : updatePareto
       *
       * DESCRIPTION : displays values into pareto graph
       * RETURNS : nothing
       */
        void updatePareto()
        {
            populateSortedDic();
            string dmp;
            //calculate the total of frequency
            calcFreq();
            //clear the chart series
            this.chart1.Series.Clear();

            //create new series
            Series series = this.chart1.Series.Add("Defects in the YoYos");
            Series series2 = this.chart1.Series.Add("%age of defect");
            //set specific chart types for specific series
            this.chart1.Series["Defects in the YoYos"].ChartType = SeriesChartType.Column;
            this.chart1.Series["%age of defect"].ChartType = SeriesChartType.Line;
            // add a Y2 axis 
            chart1.ChartAreas[0].AxisX.Title = "defect reason";
            chart1.ChartAreas[0].AxisY.Title = "Defect amount";
            chart1.ChartAreas[0].AxisY2.Title = "Cumulative %age of defects";
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

            //set the axis to specific series.
            chart1.Series[0].YAxisType = AxisType.Primary;
            chart1.Series[1].YAxisType = AxisType.Secondary;

            //set the chart area properties
            chart1.ChartAreas[0].AxisY2.LineColor = Color.Red;
            chart1.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisY2.IsStartedFromZero = chart1.ChartAreas[0].AxisY.IsStartedFromZero;

            //chart1.ChartAreas[0].AxisY2.Maximum = 100;
            //chart1.ChartAreas[0].AxisY2.Maximum = 0;


            double temp;

            //sort the array in descending order
            Array.Sort(amountArray);
            Array.Reverse(amountArray);



            // Add series.
            //for (int i = 0; i < seriesArray.Length; i++)
            //{
            int i = 0;
            foreach (var item in sortedDIc.OrderByDescending(r => r.Value).Take(9))
            {
                series.Points.Add(item.Value);

                this.chart1.Series["Defects in the YoYos"].Points[i].AxisLabel = item.Key;

                temp = calcCumFreqPercentage(item.Value);
                series2.Points.Add(temp);
                series2.Points[i].MarkerColor = Color.Blue;
                series2.Points[i].MarkerStyle = MarkerStyle.Circle;
                series2.Points[i].MarkerSize = 10;
                i++;
            }
                


            sumPrevFreq = 0;
        }


        /*  -- METHOD Header Comment
        Name	:   calcFreq
        Purpose :   this method calculates the frequencysum i.e. sum of 
                    all the frequencies in the frequency array
        PARAMETERS	: NOTHING
        Returns	:	NOTHING
        */
        void calcFreq()
        {
            double retVal = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                retVal += amountArray[i];
            }
            frequencySum = retVal;
        }

        /*  -- METHOD Header Comment
       Name	:   calcCumFreqPercentage
       Purpose :   this method calculates the cumulative frequency for 
                   the frequencies in the frequency array.
       PARAMETERS	: double currFreq - frequency that needs the cumulative frequency.
       Returns	:	NOTHING
       */
        double calcCumFreqPercentage(double currFreq)
        {
            double retVal = 0;
            sumPrevFreq += currFreq;
            retVal = (sumPrevFreq / frequencySum) * 100;
            return retVal;
        }

        void readIntoAmountArray()
        {
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {

                Double.TryParse(row["dataCount"].ToString(),out amountArray[i]);
                i++;
            }

        }

    }
}
