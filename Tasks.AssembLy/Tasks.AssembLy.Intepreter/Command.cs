using System.Diagnostics;

namespace Tasks.AssembLy.Intepreter
{
    [DebuggerDisplay("{this.GetType()}: {ToString()}")]
    public abstract class Command
    {
        public abstract string CommandCode { get; }
        public string SourceCodeLine { get; }

        public Command(string sourceCodeLine)
        {
            SourceCodeLine = sourceCodeLine;
        }

        public abstract void Execute(RegistersState state);

        public override string ToString()
        {
            return SourceCodeLine;
        }
    }
}