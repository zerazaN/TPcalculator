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
        private Button lastButton;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lastButton = EmptyButton;
            format.NumberDecimalSeparator = ".";
            workNumBox.Select();
            labelResult.Text = "";
            foreach (Double num in numberList)
            {
                labelResult.Text = labelResult.Text += num.ToString() + "\n";
            }
            SaveState();
            divideButton.Enabled = false;
            undo.Enabled = false;
            repeat.Enabled = false;

            ////////////////////////////////////TODO: rework
        }

        /////////////////////////////TEXTCHANGE///////////////////////////////

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
                if (workNumBox.Text[workNumBox.TextLength - 1] == '.')
                    workNumber = Convert.ToDouble(workNumBox.Text.Substring(0, workNumBox.TextLength - 1));
                else
                    workNumber = Convert.ToDouble(workNumBox.Text, format);
            }
            if (workNumber == 0) divideButton.Enabled = false;
            else divideButton.Enabled = true;
        }


        /////////////////////////////STATE/////////////////////////
        private void LoadState(State state)
        {
            stateNum.Text = state.stateNum + "/" + State.states.ToString();
            workNumBox.Text = state.getWorkNum().ToString();
            numberList.Clear();
            foreach(Double num in state.getNumbersList())
            {
                numberList.Add(num);
            }
            

            labelResult.Text = "";
            foreach (Double num in numberList)
            {
                labelResult.Text = labelResult.Text += num.ToString() + "\n";
            }
            if (state.stateNum == 1)
                undo.Enabled = false;
            else undo.Enabled = true;
            statesList.SelectedIndex = getCurrentState() - 1;
            workNumBox.Select();
        }


        private void SaveState()
        {
            if (getCurrentState() < State.states)
                updateStateList();
            State state = new State(numberList, workNumber, lastButton);
            states.Add(state);
            statesList.Items.Add(state.stateNum + ")  " + lastButton.Text + " " + state.getWorkNum().ToString());
            stateNum.Text = state.stateNum + "/" + State.states.ToString();
            
        }

        private void UpdateState()
        {
            repeat.Enabled = true;
            labelResult.Text = "";
            foreach (Double num in numberList)
            {
                labelResult.Text = labelResult.Text += num.ToString() + "\n";
            }
            undo.Enabled = true;
            statesList.SelectedIndex = getCurrentState() - 1;
            workNumBox.Select();
        }

        ///////////////////////////////////STATELIST/////////////////////////////////////

        private void statesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadState(states[statesList.SelectedIndex]);
        }

        private void updateStateList()
        {
            states.RemoveRange(getCurrentState(), State.states - getCurrentState());
            State.states = getCurrentState();
            statesList.Items.Clear();
            foreach(State state in states)
            {
                statesList.Items.Add(state.stateNum + ")  " + state.getLastButton().Text + " " + state.getWorkNum().ToString());
            }
        }

        private int getCurrentState()
        {
            String stateNumText = stateNum.Text.Substring(0, stateNum.Text.IndexOf("/"));
            int stateNumInt = Convert.ToInt32(stateNumText);
            return stateNumInt;
        }
        ///////////////////////////////////////////BUTTONS////////////////////////////////////////////

        private void plusButton_Click(object sender, EventArgs e)
        {
            lastButton = plusButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] += workNumber;
            }
            SaveState();
            UpdateState();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            lastButton = minusButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] -= workNumber;
            }
            SaveState();
            UpdateState();
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            lastButton = multiplyButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] *= workNumber;
            }
            SaveState();
            UpdateState();
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            lastButton = divideButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] /= workNumber;
            }
            SaveState();
            UpdateState();
        }
        
        

        private void undo_Click(object sender, EventArgs e)
        {
            LoadState(states[getCurrentState() - 2]);
        }

        private void repeat_Click(object sender, EventArgs e)
        {
            if(getCurrentState() < State.states)
            LoadState(states[getCurrentState()]);
            else
            {
                workNumBox.Text = states[getCurrentState() - 1].getWorkNum().ToString();
                states[getCurrentState() - 1].getLastButton().PerformClick();
                statesList.SelectedIndex = getCurrentState() - 1;
            }
        }
    }
}
