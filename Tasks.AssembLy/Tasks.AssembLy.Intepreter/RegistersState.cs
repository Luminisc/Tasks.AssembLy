namespace Tasks.AssembLy.Intepreter
{
    public class RegistersState
    {
        public int CurrentCommand { get; internal set; } = 0;
        private readonly Dictionary<string, int> state;
        
        public RegistersState(Dictionary<string, int>? state = null)
        {
            this.state = state ?? new Dictionary<string, int>();
        }

        public IReadOnlyDictionary<string, int> GetRegisters() => state;

        internal void Set(string registerId, int number) => this[registerId] = number;
        internal void Set(string targetRegisterId, string sourceRegisterId) => this[targetRegisterId] = this[sourceRegisterId];
        internal int this[string registerId]
        {
            get => state.ContainsKey(registerId)
                ? state[registerId]
                : throw new Exception();
            set => state[registerId] = value;
        }
    }
}
