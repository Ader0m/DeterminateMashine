using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminateMashine.UserInputController
{
    internal class CorrectFormat : ITask
    {
        public string Task(string input)
        {

            if (!input.Contains(",") || !input.Contains("="))
            {
                input = "Error format";
            }

            return input;
        }
    }
}
