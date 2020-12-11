using System;
using System.Collections.Generic;
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
        private String whichWork;

        public State(List<Double> numbers, double workNum, String whichWork)
        {
            stateNum = ++states;
            this.workNum = workNum;
            this.whichWork = whichWork;
            foreach(Double num in numbers)
            {
                this.numbers.Add(num);
            }
        }

        public String getWhichwork()
        {
            return whichWork;
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
