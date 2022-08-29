namespace Tasks.AssembLy.Intepreter.Commands
{
    internal class CommentLine : Command
    {
        public const string Code = ";";
        public override string CommandCode => Code;

        public CommentLine(string sourceCodeLine) : base(sourceCodeLine)
        {
        }

        public override void Execute(RegistersState state)
        {
        }
    }
}
