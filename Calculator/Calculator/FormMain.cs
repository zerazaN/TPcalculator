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
        private Double newNumber = 0;
        private List<Double> numberList = new List<Double>() {5, -3, 20.1, -1.3};
        private List<State> states = new List<State>();
        private Button lastButton;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            format.NumberDecimalSeparator = ".";
            Start();
            ////////////////////////////////////TODO: rework
        }

        private void Start()
        {
            State.states = 0;
            states.Clear();
            statesList.Items.Clear();
            lastButton = EmptyButton;
            workNumBox.Select();
            UpdateResult();
            SaveState();
            divideButton.Enabled = false;
            undo.Enabled = false;
            repeat.Enabled = false;
        }
        /////////////////////////////TEXTINPUT///////////////////////////////

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

        private void addNumber_KeyPress(object sender, KeyPressEventArgs e)
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
        private void addNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                addButton.PerformClick();
                e.Handled = true;
            }
        }

        private void addNumber_TextChanged(object sender, EventArgs e)
        {
            if (addNumber.Text.Trim() == "" || addNumber.Text == "-")
                newNumber = 0;
            else
            {
                if (addNumber.Text[addNumber.TextLength - 1] == '.')
                    newNumber = Convert.ToDouble(addNumber.Text.Substring(0, addNumber.TextLength - 1));
                else
                    newNumber = Convert.ToDouble(addNumber.Text, format);
            }
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
            
            UpdateResult();
            if (state.stateNum == 1)
                undo.Enabled = false;
            else undo.Enabled = true;
            statesList.SelectedIndex = GetCurrentState() - 1;
            workNumBox.Select();
        }


        private void SaveState()
        {
            if (GetCurrentState() < State.states)
                UpdateStateList();
            State state = new State(numberList, workNumber, lastButton);
            states.Add(state);
            statesList.Items.Add(state.stateNum + ")  " + lastButton.Text + " " + state.getWorkNum().ToString());
            stateNum.Text = state.stateNum + "/" + State.states.ToString();
            
        }

        private void UpdateState()
        {
            repeat.Enabled = true;
            UpdateResult();
            undo.Enabled = true;
            statesList.SelectedIndex = GetCurrentState() - 1;
            workNumBox.Select();
        }

        private void UpdateState_input()
        {
            if (numberList.Count == 0)
                DisableButtons();
            else EnableButtons();
            UpdateResult();
        }

        ///////////////////////////////////STATELIST/////////////////////////////////////

        private void statesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(statesList.SelectedIndex >= 0)
            LoadState(states[statesList.SelectedIndex]);
        }

        private void UpdateStateList()
        {
            states.RemoveRange(GetCurrentState(), State.states - GetCurrentState());
            State.states = GetCurrentState();
            statesList.Items.Clear();
            foreach(State state in states)
            {
                statesList.Items.Add(state.stateNum + ")  " + state.getLastButton().Text + " " + state.getWorkNum().ToString());
            }
        }

        private int GetCurrentState()
        {
            String stateNumText = stateNum.Text.Substring(0, stateNum.Text.IndexOf("/"));
            int stateNumInt = Convert.ToInt32(stateNumText);
            return stateNumInt;
        }

        ///////////////////////////////////////////NUMBERSLIST/////////////////////////////////////////
        private void UpdateResult()
        {
            numbersListBox.Items.Clear();
            foreach (Double num in numberList)
            {
                numbersListBox.Items.Add(num);
            }
            numbersListBox.SelectedIndex = numberList.Count - 1;
        }
        ///////////////////////////////////////////MATHBUTTONS////////////////////////////////////////////
        private void DisableButtons()
        {
            plusButton.Enabled = false;
            minusButton.Enabled = false;
            multiplyButton.Enabled = false;
            divideButton.Enabled = false;
        }

        private void EnableButtons()
        {
            plusButton.Enabled = true;
            minusButton.Enabled = true;
            multiplyButton.Enabled = true;
            if(workNumber != 0)
            divideButton.Enabled = false;
        }

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

        ///////////////////////////////////////////STATEBUTTONS////////////////////////////////////////////

        private void undo_Click(object sender, EventArgs e)
        {
            LoadState(states[GetCurrentState() - 2]);
        }

        private void repeat_Click(object sender, EventArgs e)
        {
            if(GetCurrentState() < State.states)
            LoadState(states[GetCurrentState()]);
            else
            {
                workNumBox.Text = states[GetCurrentState() - 1].getWorkNum().ToString();
                states[GetCurrentState() - 1].getLastButton().PerformClick();
                statesList.SelectedIndex = GetCurrentState() - 1;
            }
        }

        ///////////////////////////////////////////LISTBUTTONS////////////////////////////////////////////
        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            numberList.Clear();
            UpdateState_input();
        }

        private void deleteLastButton_Click(object sender, EventArgs e)
        {
            if(numberList.Count != 0)
            numberList.RemoveAt(numberList.Count - 1);
            UpdateState_input();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            numberList.Add(newNumber);
            UpdateState_input();
            addNumber.Select();
        }



        ////////////////////////////////////////////MENUFILES/////////////////////////////////////////////
        private void menu_Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;
            string output = "";
            foreach(Double num in numberList)
            {
                output += num + "|";
            }
            output = output.Substring(0, output.Length - 1);
            System.IO.File.WriteAllText(filename, output);
        }

        private void menu_Load_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            numberList.Clear();
            if(fileText != "")
            foreach(string num in fileText.Split('|'))
            {
                numberList.Add(Convert.ToDouble(num));
            }
            UpdateState_input();
            Start();
        }
    }
}
