using Tasks.AssembLy.Intepreter.Parsing.Exceptions;

namespace Tasks.AssembLy.Intepreter.Commands
{
    internal class Dec : Command
    {
        public const string Code = "dec";
        public override string CommandCode => Code;
        private readonly string RegisterId = string.Empty;

        public Dec(string sourceCodeLine) : base(sourceCodeLine)
        {
            var lexems = sourceCodeLine.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (lexems.Length != 2)
                throw ParsingException.WrongNumberOfArguments(sourceCodeLine, 2);
            RegisterId = lexems[1];
        }

        public override void Execute(RegistersState state)
        {
            state[RegisterId]--;
        }
    }
}
