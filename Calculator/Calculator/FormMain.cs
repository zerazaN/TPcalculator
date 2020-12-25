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
            undoButton.Enabled = false;
            repeatButton.Enabled = false;
        }
        /////////////////////////////TEXTINPUT//////////////////////////////////////////////////////////////

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

        /////////////////////////////STATE/////////////////////////////////////////////////////////////////

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
                undoButton.Enabled = false;
            else undoButton.Enabled = true;
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
            repeatButton.Enabled = true;
            UpdateResult();
            undoButton.Enabled = true;
            statesList.SelectedIndex = GetCurrentState() - 1;
            workNumBox.Select();
        }

        private void UpdateState_input()
        {
            if (numberList.Count == 0)
                DisableButtons();
            else EnableButtons();
            UpdateResult();
            addNumber.Select();
        }

        ///////////////////////////////////STATELIST///////////////////////////////////////////////////////

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

        ///////////////////////////////////////////MATHBUTTONS////////////////////////////////////////////

        private void DisableButtons()
        {
            repeatButton.Enabled = false;
            plusButton.Enabled = false;
            minusButton.Enabled = false;
            multiplyButton.Enabled = false;
            divideButton.Enabled = false;
            squareButton.Enabled = false;
            powerNButton.Enabled = false;
            rootButton.Enabled = false;
            rootButton.Enabled = false;
            logNButton.Enabled = false;
            factButton.Enabled = false;
            medianaButton.Enabled = false;
            standartDeviationButton.Enabled = false;
        }

        private void EnableButtons()
        {
            repeatButton.Enabled = false;
            plusButton.Enabled = true;
            minusButton.Enabled = true;
            multiplyButton.Enabled = true;
            if(workNumber != 0)
            divideButton.Enabled = true;
            squareButton.Enabled = true;
            powerNButton.Enabled = true;
            rootButton.Enabled = true;
            rootNButton.Enabled = true;
            logNButton.Enabled = true;
            factButton.Enabled = true;
            medianaButton.Enabled = true;
            standartDeviationButton.Enabled = true;
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

        private void squareButton_Click(object sender, EventArgs e)
        {
            lastButton = squareButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] = Math.Pow(numberList[i], 2);
            }
            SaveState();
            UpdateState();
        }

        private void powerNButton_Click(object sender, EventArgs e)
        {
            lastButton = powerNButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] = Math.Pow(numberList[i], workNumber);
            }
            SaveState();
            UpdateState();
        }

        private void rootNButton_Click(object sender, EventArgs e)
        {
            lastButton = rootButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] = Math.Pow(numberList[i], 1/workNumber);
            }
            SaveState();
            UpdateState();
        }

        private void rootButton_Click(object sender, EventArgs e)
        {
            lastButton = rootNButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] = Math.Pow(numberList[i], 0.5);
            }
            SaveState();
            UpdateState();
        }

        private void logNButton_Click(object sender, EventArgs e)
        {
            lastButton = logNButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] = Math.Log(numberList[i], workNumber);
            }
            SaveState();
            UpdateState();
        }

        private void factButton_Click(object sender, EventArgs e)
        {
            lastButton = factButton;
            for (int i = 0; i < numberList.Count; i++)
            {
                if (Math.Truncate(numberList[i]).Equals(numberList[i]) && numberList[i] >= 0)
                    numberList[i] = Factorial(numberList[i]);
            }
            SaveState();
            UpdateState();
        }

        private void medianaButton_Click(object sender, EventArgs e)
        {
            lastButton = medianaButton;
            numberList.Sort();
            double result;
            if (numberList.Count % 2 == 0)
            {
                result = (numberList[numberList.Count / 2] +
                    numberList[numberList.Count / 2 - 1]) / 2;
            }
            else
            {
                result = numberList[Convert.ToInt32(Math.Truncate((double)(numberList.Count / 2)))];
            }
            numberList.Clear();
            numberList.Add(result);
            SaveState();
            UpdateState();
        }

        private void standartDeviationButton_Click(object sender, EventArgs e)
        {
            lastButton = standartDeviationButton;
            double result = 0;
            double average = numberList.Average();
            for (int i = 0; i < numberList.Count; i++)
            {
                numberList[i] -= average;
                numberList[i] = Math.Pow(numberList[i], 2);
                result += numberList[i];
            }
            result /= numberList.Count - 1;
            result = Math.Pow(result, 0.5);
            numberList.Clear();
            numberList.Add(result);
            SaveState();
            UpdateState();
        }

        ///////////////////////////////////////////STATEBUTTONS////////////////////////////////////////////

        private void undoButton_Click(object sender, EventArgs e)
        {
            LoadState(states[GetCurrentState() - 2]);
        }

        private void repeatButton_Click(object sender, EventArgs e)
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

        ///////////////////////////////////////////NUMBERSLIST////////////////////////////////////////////

        private void UpdateResult()
        {
            numbersListBox.Items.Clear();
            foreach (Double num in numberList)
            {
                numbersListBox.Items.Add(num);
            }
            numbersListBox.SelectedIndex = numberList.Count - 1;
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

        private double Factorial(double num)
        {
            if (num == 1 || num == 0)
                return 1;
            else
                return num * Factorial(num - 1);
        }

    }
}
