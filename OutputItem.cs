namespace AutomatonExamples
{
    public struct OutputItem
    {
        public char Symbol { get; private set; }

        public OutputItem (char symbol)
        {
            Symbol = symbol;
        }
    }
}
