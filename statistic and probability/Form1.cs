using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Statistics;

namespace statistic_and_probability
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {

           

            //validate the text box
            if (txtmean.Text == "")
            {
                MessageBox.Show("Enter the data set");

                return;
            }

            //accept only numbers
            if (!Regex.Match(txtmean.Text, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").Success)
            {
                MessageBox.Show("Data set should be a number or delete the whitespace");

                return;
            }

            //check if the calculator type is empty
            if (cmbCalcType.Text == "")
            {
                MessageBox.Show("Choose calculator type");

                return;
            }

          

            //get the values in the combobox
            string calcType = cmbCalcType.Text;

            //check the value selected in the combobox and call the necessary function
            if (calcType == "Mean")
            {
                CalcMean();
            }
            else if (calcType == "Median")
            {
                CalcMedian();
            }
            else if (calcType == "Mode")
            {
                CalcMode();
            }
            else if (calcType == "Variance")
            {
                CalcVariance();
            }
            else if (calcType == "Standard Deviation")
            {
                CalcStandardDeviation();
            }
            else if (calcType == "Skewness")
            {
                CalcSkewness();
            }
            else if (calcType =="Kurtosis")
            {
                CalcKurtosis();
            }
            else if (calcType == "Percentile")
            {
                Percentile();
            }
            else if (calcType == "Quartile")
            {
                CalcQuartile();
            }
            


        }

        //calc mean
        private void CalcMean()
        {
            //get the textbox value as array and split it by the whitespace
            double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse) ;
            
            //get the array values and find the mean
           double mean = values.Mean();

            //set the result
            lblsolution.Text = "Mean:  " + mean.ToString();
        }

        //calcmedian
        private void CalcMedian()
        {
            // get the textbox value as array and split it by the whitespace
            double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
            //get the array values and find the median
            double median = values.Median();
            //set the result
            lblsolution.Text = "Median:  " + median.ToString();
        }

        //calc mode
        private void CalcMode()
        {
            // get the textbox value as array and split it by the whitespace
            double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);

            //group the values 
            var mode = values.GroupBy(numbers => numbers)

            //arrange the values in descending order and count the length
            .OrderByDescending(g => g.Count())

            //select the first number after sorted
            .Select(g => g.Key).FirstOrDefault();

            //set the value to the label
            lblsolution.Text = "Mode:  " +  mode.ToString();
        }

        private void CalcVariance()
        {
            if (rdSample.Checked)
            {
                // get the textbox value as array and split it by the whitespace
                double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
                //get the array values and find the median
                double variance = values.Variance();
                //set the result
                lblsolution.Text = "Variance:  " + variance.ToString();
            }
            else if (rdPopulation.Checked)
            {
                // get the textbox value as array and split it by the whitespace
                double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
                //get the array values and find the median
                double variance = values.PopulationVariance();
                //set the result
                lblsolution.Text = "Variance:  " + variance.ToString();
            }
           
        }

        //calc standa
        private void CalcStandardDeviation()
        {

            if (rdSample.Checked)
            {

                // get the textbox value as array and split it by the whitespace
                double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
                //get the array values and find the standard deviation
                double standDeviation = values.StandardDeviation();
                //set the result
                lblsolution.Text = "Standard Deviation:  " + standDeviation.ToString();

            } else if(rdPopulation.Checked)
            {
                // get the textbox value as array and split it by the whitespace
                double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
                //get the array values and find the standard deviation
                double standDeviation = values.PopulationStandardDeviation();
                //set the result
                lblsolution.Text = "Standard Deviation:  " + standDeviation.ToString();
            }
        }

        //skewness
        private void CalcSkewness()
        {
            if (rdSample.Checked)
            {
                //get the values from the textbox as an array
                double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
                //invoke the method on the values
                double skewness = values.Skewness();
                //set the result to the label
                lblsolution.Text = "Skewness:  " + skewness.ToString();
            }
            else if (rdPopulation.Checked)
            {
                //get the values from the textbox as an array
                double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
                //invoke the method on the values
                double skewness = values.PopulationSkewness();
                //set the result to the label
                lblsolution.Text = "Skewness:  " + skewness.ToString();
            }
            
        }

        //kurtosis
        private void CalcKurtosis()
        {
            if (rdSample.Checked)
            {
                //get the values from the textbox as an array
                double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
                //invoke the method on the values
                double kurtosis = values.Kurtosis();
                //set the result to the label
                lblsolution.Text = "Kurtosis:  " + kurtosis.ToString();
            }
            else if (rdPopulation.Checked)
            {
                //get the values from the textbox as an array
                double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
                //invoke the method on the values
                double kurtosis = values.PopulationKurtosis();
                //set the result to the label
                lblsolution.Text = "Kurtosis:  " + kurtosis.ToString();
            }
           
        }


        //kurtosis
        private void CalcQuartile()
        {
            //get the values from the textbox as an array
            double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);

            //arrange the values in ascending order
            Array.Sort(values);

            //get the length
            int length = values.Length;

            //calculate the 1st quarter
            double firstQuart = 0.25*(length + 1);
            lblQ1.Text = "Q1:  " + firstQuart;

            //calc the 3rd quarter
            double thirdQuart = 0.75 * (length + 1);
            lblQ3.Text = "Q3:  " + thirdQuart;

            //calculate the 2nd quarter
            double secondQuart = thirdQuart - firstQuart;
            lblQ2.Text = "Q2:  " + secondQuart;

            
            


        }

        //calc percentile
        public void Percentile()
        {

            //check if user select percentile
            if (txtPercentile.Text == "")
            {
                MessageBox.Show("Enter the percentage");

                return;
            }


            //get the values from the textbox as an array
            double[] values = Array.ConvertAll(txtmean.Text.Trim().Split(' '), double.Parse);
            //get the percentile
            double percentage = Convert.ToDouble(txtPercentile.Text.Trim());

            //arrange the values in ascending order 
            Array.Sort(values);

            //get the length of the array
            int length = values.Length;

            //calculate the percentile i = (p/100)(n-1) + 1, where p = 40 and n = 7
            double percentile = (percentage/100) * length;

            //set the result
            lblsolution.Text = "Percentile:  " + percentile;
            
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtmean.Text = "";
        }

        //accept only numbers
        private void txtmean_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char ch = e.KeyChar;
            //if (!(char.IsLetter(e.KeyChar) && (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.'))
            //{
            //    e.Handled = true;
            //}

        }

        private void txtPercentile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtmean.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        //close forms
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();


        //hide or unhide radio button
        private void cmbCalcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCalcType.Text == "Median" || cmbCalcType.Text == "Mean" || cmbCalcType.Text == "Mode" || cmbCalcType.Text == "Percentile")
            {
                rdPopulation.Visible = false;
                rdSample.Visible = false;
            } else
            {
                rdPopulation.Visible = true;
                rdSample.Visible = true;
            }
        }
    }
}
