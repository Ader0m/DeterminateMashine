using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminateMashine.UserInputController
{
    internal class Interpret : ITask
    {
        private List<ITask> _tasks;

        public Interpret()
        {
            _tasks = new List<ITask>();
            _tasks.Add(new CorrectFormat());
            _tasks.Add(new CorrectOp());
            _tasks.Add(new CorrectState());           
        }

        public string Task(string input)
        { 
            foreach(var task in _tasks)
            {
                input = task.Task(input);
                if (input.Contains("Error"))
                {
                    return input;
                }
            }

            return input;
        }
    }
}
