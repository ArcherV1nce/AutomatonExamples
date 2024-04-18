namespace AutomatonExamples.Moore_Machine
{
    public class MooreOutput
    {
        private Dictionary<State, OutputItem> _outputs;

        public MooreOutput (Dictionary<State,OutputItem> outputs)
        {
            _outputs = outputs;
        }

        public OutputItem GetOutput(State currentState)
        {
            return _outputs[currentState];
        }
    }
}