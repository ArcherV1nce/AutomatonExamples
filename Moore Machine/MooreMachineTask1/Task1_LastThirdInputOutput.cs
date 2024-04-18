namespace AutomatonExamples.Moore_Machine
{
    public class Task1_LastThirdInputOutput
    {
        const char InputA = 'a';
        const char InputB = 'b';
        const char FalseInput = '#';
        const string Quit = "quit";

        private MooreMachine _automaton;
        private State _initialState;
        private List<State> _states;
        private List<InputItem> _inputAlphabet;
        private List<OutputItem> _outputAlphabet;
        private List<Transition> _transitions;
        private MooreOutput _outputs;

        public Task1_LastThirdInputOutput()
        {
            SetMooreMachineData();
        }

        public void OperateInputs()
        {
            WriteMessage($"Алфавіт вводу: {{{InputA}, {InputB}}}.\n" +
                $"Для завершення роботи введіть \"{Quit}\".\n");

            bool isWorking = true;
            string input = "";
            char inputSymbol = '#';
            string fullInput = "";
            string finalOutput = "" + _automaton.GetCurrentOutputSymbol();

            do
            {
                input = Console.ReadLine();

                if (CheckInputData(input, out inputSymbol))
                {
                    switch (inputSymbol)
                    {
                        case InputA:
                            fullInput += inputSymbol;
                            finalOutput += _automaton.OperateInput(new InputItem(InputA));
                            break;

                        case InputB:
                            fullInput += inputSymbol;
                            finalOutput += _automaton.OperateInput(new InputItem(InputB));
                            break;

                        default:
                            WriteMessage($"Введене значення {input} не вірне. Введіть символ, що належить алфавіту.");
                            continue;
                    }
                }

                else if (input.ToLower() == Quit)
                {
                    isWorking = false;
                }
            }

            while (isWorking);

            WriteMessage($"Відображення вхідної послідовності {{{fullInput}}} буде {{{finalOutput}}}.");
        }

        private void SetMooreMachineData()
        {
            InputItem inputA = new InputItem('a');
            InputItem inputB = new InputItem('b');
            _inputAlphabet = new List<InputItem>() { inputA, inputB};

            OutputItem outputA = new OutputItem('a');
            OutputItem outputB = new OutputItem('b');
            _outputAlphabet = new List<OutputItem>() { outputA, outputB};

            State aa = new State("aa");
            State ab = new State("ab");
            State ba = new State("ba");
            State bb = new State("bb");

            _initialState = aa;
            _states = new List<State>() { aa, ab, ba, bb};

            //Вписувати стани як елементи множини станів не буду для наглядності
            //Окрім стану aa = _states[0]

            Transition aaToaa = new Transition(_states[0], _inputAlphabet[0], _states[0]); //_inputAlphabet[0] = inputA
            Transition aaToab = new Transition(aa, _inputAlphabet[1], ab); //_inputAlphabet[1] = inputB
            Transition abToba = new Transition(ab, inputA, ba);
            Transition abTobb = new Transition(ab, inputB, bb);
            Transition baToaa = new Transition(ba, inputA, aa);
            Transition baToab = new Transition(ba, inputB, ab);
            Transition bbToba = new Transition(bb, inputA, ba);
            Transition bbTobb = new Transition(bb, inputB, bb);
            
            _transitions = new List<Transition>()
            {
                aaToaa, aaToab, abToba, abTobb, baToaa, baToab,
                bbToba, bbTobb
            };

            Dictionary<State, OutputItem> outputs = new Dictionary<State, OutputItem>();
            outputs.Add(aa, _outputAlphabet[0]); //_outputAlphabet[0] = outputA
            outputs.Add(ab, outputA);
            outputs.Add(ba, _outputAlphabet[1]); //_outputAlphabet[1] = outputB
            outputs.Add(bb, outputB);

            _outputs = new MooreOutput(outputs);

            _automaton = new MooreMachine(_transitions, _outputs, _initialState);
        }

        private bool CheckInputData(string input, out char inputSymbol)
        {
            char[] inputArray = input.ToCharArray();

            if (inputArray.Length == 1)
            {
                inputSymbol = inputArray[0];
                return true;
            }

            else
            {
                inputSymbol = FalseInput;
                return false;
            }
        }

        private void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}