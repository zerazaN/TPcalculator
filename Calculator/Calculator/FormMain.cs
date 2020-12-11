using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FormMain : Form
    {
        private NumberFormatInfo format = new NumberFormatInfo();
        private Double workNumber = 0; //число в TextBox
        private List<Double> numberList = new List<Double>() {5, -3, 20.1, -1.3};
        private List<State> states = new List<State>();
        private String lastAction = "";

        public FormMain()
        {
            InitializeComponent();
        }

        private void LoadState(State state)
        {
            stateNum.Text = state.stateNum + "/" + State.states.ToString();
            workNumBox.Text = state.getWorkNum().ToString();
            labelResult.Text = "";
            foreach (Double num in state.getNumbersList())
            {
                labelResult.Text = labelResult.Text += num.ToString() + "\n";
            }
            workNumBox.Select();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            format.NumberDecimalSeparator = ".";
            workNumBox.Select();
            labelResult.Text = "";
            foreach (Double num in numberList)
            {
                labelResult.Text = labelResult.Text += num.ToString() + "\n";
            }////////////////////////////////////TODO: rework
        }

        private void UpdateState()
        {
            State state = new State(numberList, workNumber, lastAction);
            states.Add(state);
            statesList.Items.Add(state.stateNum + ")  " + state.getWhichwork() + " " + state.getWorkNum().ToString());
            stateNum.Text =state.stateNum + "/" + State.states.ToString();
            labelResult.Text = "";
            foreach (Double num in numberList)
            {
                labelResult.Text = labelResult.Text += num.ToString() + "\n";
            }
            workNumBox.Select();
        }

        private void workNumBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (((sender as TextBox).Text.IndexOf('.') > -1) || 
                (sender as TextBox).Text.Trim() == "" || (sender as TextBox).Text.Trim() == "-"))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.Trim() != ""))
            {
                e.Handled = true;
            }

        }

        private void workNumBox_TextChanged(object sender, EventArgs e)
        {
            if (workNumBox.Text.Trim() == "" || workNumBox.Text == "-")
                workNumber = 0;
            else
            {   
                if(workNumBox.Text[workNumBox.TextLength - 1] == '.')
                    workNumber = Convert.ToDouble(workNumBox.Text.Substring(0, workNumBox.TextLength - 1));
                else
                workNumber = Convert.ToDouble(workNumBox.Text, format);
            }
            if(workNumber == 0) dividedButton.Enabled = false;
            else dividedButton.Enabled = true;
        }

        //Buttons////////////////////////////////////////////

        private void plusButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < numberList.Capacity; i++)
            {
                numberList[i] += workNumber;
            }
            lastAction = "+";
            UpdateState();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numberList.Capacity; i++)
            {
                numberList[i] -= workNumber;
            }
            lastAction = "-";
            UpdateState();
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numberList.Capacity; i++)
            {
                numberList[i] *= workNumber;
            }
            lastAction = "*";
            UpdateState();
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numberList.Capacity; i++)
            {
                numberList[i] /= workNumber;
            }
            lastAction = "/";
            UpdateState();
        }

        private void statesList_DoubleClick(object sender, EventArgs e)
        {
            LoadState(states[statesList.SelectedIndex]);
        }
    }
}
