using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FormMain : Form
    {
        private NumberFormatInfo format = new NumberFormatInfo();
        private Double workNumber = 0; //число в TextBox
        private Double newNumber = 0; //число над List
        private List<Double> numberList = new List<Double>();
        private List<State> states = new List<State>();
        private Button lastButton;
        private Boolean freeze = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            format.NumberDecimalSeparator = ".";
            Start();
        }

        private void Start()
        {
            statesList.Items.Clear();
            lastButton = EmptyButton;
            workNumBox.Select();
            UpdateState_input();
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
            if (freeze)
                return;
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
            if (freeze)
                return;
            if (e.KeyData == Keys.Return)
            {
                addButton.PerformClick();
                e.Handled = true;
            }
        }

        private void addNumber_TextChanged(object sender, EventArgs e)
        {
            if (freeze)
                return;
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
            undoButton.Enabled = false;
            repeatButton.Enabled = false;
            plusButton.Enabled = false;
            minusButton.Enabled = false;
            multiplyButton.Enabled = false;
            divideButton.Enabled = false;
            squareButton.Enabled = false;
            powerNButton.Enabled = false;
            rootButton.Enabled = false;
            rootNButton.Enabled = false;
            logNButton.Enabled = false;
            factButton.Enabled = false;
            medianaButton.Enabled = false;
            standartDeviationButton.Enabled = false;
            menu_Save.Enabled = false;
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
            menu_Save.Enabled = true;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            lastButton = plusButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            lastButton = minusButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            lastButton = multiplyButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            lastButton = divideButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            lastButton = squareButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void powerNButton_Click(object sender, EventArgs e)
        {
            lastButton = powerNButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void rootNButton_Click(object sender, EventArgs e)
        {
            lastButton = rootButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void rootButton_Click(object sender, EventArgs e)
        {
            lastButton = rootNButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void logNButton_Click(object sender, EventArgs e)
        {
            lastButton = logNButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void factButton_Click(object sender, EventArgs e)
        {
            lastButton = factButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void medianaButton_Click(object sender, EventArgs e)
        {
            lastButton = medianaButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private void standartDeviationButton_Click(object sender, EventArgs e)
        {
            lastButton = standartDeviationButton;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            backgroundWorker.RunWorkerAsync();
        }

        private double Factorial(double num)
        {
            if (num == 1 || num == 0)
                return 1;
            else
                return num * Factorial(num - 1);
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

        private void DisableListButtons()
        {
            statesList.Enabled = false;
            addButton.Enabled = false;
            deleteAllButton.Enabled = false;
            deleteLastButton.Enabled = false;
            menu_Load.Enabled = false;
        }

        private void EnableListButtons()
        {
            statesList.Enabled = true;
            addButton.Enabled = true;
            deleteAllButton.Enabled = true;
            deleteLastButton.Enabled = true;
            menu_Load.Enabled = true;
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
            progressBar.Style = ProgressBarStyle.Marquee;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            freeze = true;
            DisableButtons();
            DisableListButtons();
            loadBackgroundWorker.RunWorkerAsync();
            
        }

        //////////////////////////////////////BGWORK////////////////////////////////////////////////////
            

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
             switch (lastButton.Name)
            {
                case "plusButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] += workNumber;
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "minusButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] -= workNumber;
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "multiplyButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] *= workNumber;
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "divideButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] /= workNumber;
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "squareButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] = Math.Pow(numberList[i], 2);
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "powerNButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] = Math.Pow(numberList[i], workNumber);
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "rootNButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] = Math.Pow(numberList[i], 1 / workNumber);
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "rootButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] = Math.Pow(numberList[i], 0.5);
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "logNButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] = Math.Log(numberList[i], workNumber);
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "factButton":
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        if (Math.Truncate(numberList[i]).Equals(numberList[i]) && numberList[i] >= 0)
                            numberList[i] = Factorial(numberList[i]);
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    break;
                case "medianaButton":
                    numberList.Sort();
                    double result;
                    backgroundWorker.ReportProgress(50);
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
                    break;
                case "standartDeviationButton":
                    double resultD = 0;
                    double average = numberList.Average();
                    for (int i = 0; i < numberList.Count; i++)
                    {
                        Thread.Sleep(1);
                        numberList[i] -= average;
                        numberList[i] = Math.Pow(numberList[i], 2);
                        resultD += numberList[i];
                        backgroundWorker.ReportProgress(Convert.ToInt32(((double)i / numberList.Count) * 100));
                    }
                    resultD /= numberList.Count - 1;
                    resultD = Math.Pow(resultD, 0.5);
                    numberList.Clear();
                    numberList.Add(resultD);
                    break;
            }
        }
        
        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            EnableButtons();
            EnableListButtons();
            freeze = false;
            SaveState();
            UpdateState();
            progressBar.Value = 100;
            progressTextLabel.Text = "";
            //
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
            //
            //
            if (addNumber.Text.Trim() == "" || addNumber.Text == "-")
                newNumber = 0;
            else
            {
                if (addNumber.Text[addNumber.TextLength - 1] == '.')
                    newNumber = Convert.ToDouble(addNumber.Text.Substring(0, addNumber.TextLength - 1));
                else
                    newNumber = Convert.ToDouble(addNumber.Text, format);
            }
            //
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            progressTextLabel.Text = e.ProgressPercentage + "%";
        }

        ///////////////////////////////////BGLOAD///////////////////////////////////////////////////////

        private void loadBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string filename = openFileDialog.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            numberList.Clear();
            int i = 0;
            if (fileText != "")
                foreach (string num in fileText.Split('|'))
                {
                    numberList.Add(Convert.ToDouble(num));
                    Thread.Sleep(1);
                    loadBackgroundWorker.ReportProgress(i, num);
                    i = i == 100 ? 0 : i + 1;
                }
        }

        private void loadBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressTextLabel.Text = "Added : " + e.UserState;
        }

        private void loadBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 100;
            progressTextLabel.Text = "";
            EnableButtons();
            EnableListButtons();
            freeze = false;
            lastButton = EmptyButton;
            workNumber = 0;
            SaveState();
            UpdateState_input();
            progressBar.Style = ProgressBarStyle.Blocks;
        }
    }
}
