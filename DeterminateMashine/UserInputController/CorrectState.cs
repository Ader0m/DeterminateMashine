using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminateMashine.UserInputController
{
    internal class CorrectState : ITask
    {
        public string Task(string input)
        {
            string state;


            state = input.Substring(input.IndexOf(',') + 1, input.LastIndexOf("=") - 1 - input.IndexOf(","));
            
            if (state.Length == 1)
            {
                return input;
            }
            else
            {
                input = "Error State";
                return input;
            }
        }
    }
}
