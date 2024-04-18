namespace AutomatonExamples
{
    public struct State
    {
        public string Name { get; private set; }

        public State(string name)
        {
            Name = name;
        }

        public bool Equals (State other)
        {
            if (other.Name == this.Name)
                return true;

            else
                return false;
        }
    }
}