namespace AutomatonExamples.Moore_Machine
{
    public class MooreMachine
    {
        private List<Transition> _transitions;
        private MooreOutput _outputs;

        public State InitialState { get; private set; }
        public State CurrentState { get; private set; }

        public MooreMachine(List<Transition> transitions, MooreOutput outputs, State initialState)
        {
            _transitions = transitions;
            _outputs = outputs;
            InitialState = initialState;
            Init();
        }

        public char OperateInput(InputItem input)
        {
            foreach (Transition transition in _transitions)
            {
                if (transition.CurrentState.Equals(CurrentState) && transition.Input.Equals(input))
                {
                    SetState(transition.NextState);
                    return _outputs.GetOutput(CurrentState).Symbol;
                }
            }

            return _outputs.GetOutput(CurrentState).Symbol;
        }

        public char GetCurrentOutputSymbol()
        {
            return _outputs.GetOutput(CurrentState).Symbol;
        }

        private void Init()
        {
            Console.WriteLine($"Moore machine activated.");
            SetState(InitialState);
        }

        private void SetState(State state)
        {
            CurrentState = state;
            WriteStateData();
        }

        private void WriteStateData()
        {
            Console.WriteLine($"State changed to {CurrentState.Name} " +
                        $"with output: {_outputs.GetOutput(CurrentState).Symbol}");
        }
    }
}