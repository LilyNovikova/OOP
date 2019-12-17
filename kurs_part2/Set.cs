using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_part2
{
    public class Set :IEnumerable
    {
        public string name { get; private set; }
        private int[] parameters;

        public Set(string SetName, int[] SetOfParameters)
        {
            name = SetName;
            parameters = new int[SetOfParameters.Length];
            for(int i = 0; i < SetOfParameters.Length; i++)
            {
                parameters[i] = SetOfParameters[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return parameters.GetEnumerator();
        }

        /*
         * checkes if this is less than Set @set
         */
        public bool Less(Set set)
        {
            int[] ParametersToCompare = set.parameters; 
            if(ParametersToCompare.Length != parameters.Length)
            {
                throw new ArgumentException("Number of parameters is different");
            }
            int NumberOfEquals = 0;
            //поэлементное сравнение наборов
            for (int i = 0; i < parameters.Length; i++)
            {
                //если хоть один из параметров больше, данный набор не меньше
                //или наборы несравнимы
                if(parameters[i] > ParametersToCompare[i])
                {
                    return false;
                }
                //если встретились равные параметры
                if(parameters[i] == ParametersToCompare[i])
                {
                    NumberOfEquals++;
                }
            }
            //если нет больших параметров и не все равные, значит, данный набор меньше
            return NumberOfEquals < parameters.Length;            
        }

        public override string ToString()
        {
            if (this == null)
                throw new NullReferenceException();
            string str = name + ":";
            foreach(int param in parameters)
            {
                str += " "+ param + ",";
            }
            return str.TrimEnd(',');
        }
    }
}
