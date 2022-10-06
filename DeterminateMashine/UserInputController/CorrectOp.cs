using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminateMashine.UserInputController
{
    internal class CorrectOp: ITask
    {
        public string Task(string input)
        {
            string checkStart;
            string checkEnd;

            try
            {  
                checkStart = input.Substring(0, input.IndexOf(","));
                if (checkStart.Contains("q"))
                {
                    if (!int.TryParse(checkStart.Substring(1, checkStart.Length - 1), out _))
                    {
                        input = "Error operation1";
                        return input;
                    }
                }
                else
                {
                    input = "Error operation2";
                    return input;
                }
                
                checkEnd = input.Substring(input.LastIndexOf("=") + 1, input.Length - 1 - input.LastIndexOf("="));
                if (checkEnd.Contains("q") || checkEnd.Contains("f"))
                {
                    if (!int.TryParse(checkEnd.Substring(1, checkEnd.Length - 1), out _))
                    {
                        input = "Error operation3";
                        return input;
                    }
                }
                else
                {
                    input = "Error operation4";
                    return input;
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                input = "Error operation5";
            }

            return input;
        }
    }
}
