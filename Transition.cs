namespace AutomatonExamples
{
    public struct Transition
    {
        public State CurrentState { get; private set; }
        public State NextState { get; private set; }
        public InputItem Input { get; private set; }

        public Transition (State currentState, InputItem input, State nextState)
        {
            CurrentState = currentState;
            NextState = nextState;
            Input = input;
        }
    }
}