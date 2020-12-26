using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class State
    {
        public static int states = 0;

        public int stateNum;

        private List<Double> numbers = new List<double>();

        private Double workNum;

        private Button lastButton;

        public State(List<Double> numbers, double workNum, Button button)
        {
            stateNum = ++states;
            this.workNum = workNum;
            this.lastButton = button;
            foreach(Double num in numbers)
            {
                this.numbers.Add(num);
            }
        }

        public Button getLastButton()
        {
            return lastButton;
        }

        public Double getWorkNum()
        {
            return workNum;
        }

        public List<Double> getNumbersList()
        {
            return numbers;
        }
    }
}
