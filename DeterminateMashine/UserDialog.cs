using DeterminateMashine.UserInputController;

static class UserDialog
{
    private static string fileName;
    private static string[] operation;
    private static string userInput;
    private static Dictionary<string, string> operationsDict = new Dictionary<string, string>();
    

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            while (true)
            {
                bool flag = false;

                Console.WriteLine("Введите название файла");

                fileName = Console.ReadLine();

                try
                {
                    Interpret interpret = new Interpret();

                    operation = File.ReadAllLines(fileName);

                    for (int i = 0; i < operation.Length; i++)
                    {
                        string ans = interpret.Task(operation[i]);
                        if (ans.Contains("Error"))
                        {
                            Console.WriteLine(ans + " " + (i+1).ToString());
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                        continue;
                                         
                    FillOperation();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Error: Проблема с открытием файла {0}", fileName);
                }
            }
            while (true)
            {
                string op = "q0";
                string nextOp;

                Console.WriteLine("Введите строку состояний. Exit - возврат к выбору файла");

                userInput = Console.ReadLine();

                if (userInput.Contains("Exit"))
                {
                    break;
                }

                for (int i = 0; i < userInput.Length; i++)
                {
                    if (operationsDict.TryGetValue(op + "," + userInput[i], out nextOp))
                    {
                        Console.WriteLine("Операция {0} прочла состояние {1}. Переход на операцию {2}", op, userInput[i], nextOp);
                        if (nextOp.Contains("f"))
                        {
                            if (userInput.Length - 1 > i)
                            {
                                Console.WriteLine("Error: Строка имеет лишние состояния.\n");
                            }
                            else
                                Console.WriteLine("Success: Автомат в конечном состоянии. {0}", nextOp);
                            break;
                        }
                        else if ((i + 1) >= userInput.Length)
                        {
                            Console.WriteLine("Error: Автомат не нашел точку выхода.\n");
                        }
                        op = nextOp;

                    }
                    else
                    {
                        Console.WriteLine("Error: Автомат не нашел следующеe состояние.\n");
                        break;
                    }
                }
            }
        }
    }

    static void FillOperation()
    {
        for (int i = 0; i < operation.Length; i++)
        {
            string op = operation[i].Substring(0, operation[i].IndexOf(","));
            string state;
            string nextOp;
            string key;
                       

            state = operation[i].Substring(operation[i].IndexOf(","), operation[i].LastIndexOf("=") - operation[i].IndexOf(","));
            key = op + state;
            nextOp = operation[i].Substring(operation[i].LastIndexOf("=") + 1, operation[i].Length - 1 - operation[i].LastIndexOf("=")); 
          
            operationsDict.Add(key, nextOp);
            Console.WriteLine(key + " " + nextOp);
        }
    }
}