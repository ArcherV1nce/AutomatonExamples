namespace AutomatonExamples
{
    public struct InputItem
    {
        public char Symbol { get; private set; }

        public InputItem (char symbol)
        {
            Symbol = symbol;
        }
    }
}