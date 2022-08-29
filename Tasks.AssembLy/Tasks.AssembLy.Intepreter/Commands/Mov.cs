using Tasks.AssembLy.Intepreter.Parsing.Exceptions;
using Tasks.AssembLy.Intepreter.Extensions;

namespace Tasks.AssembLy.Intepreter.Commands
{
    internal class Mov : Command
    {
        public const string Code = "mov";
        public override string CommandCode => Code;
        private readonly Action<RegistersState> action;

        public Mov(string sourceCodeLine) : base(sourceCodeLine)
        {
            var lexems = sourceCodeLine.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (lexems.Length != 3) // mov a b = 3 words
                throw ParsingException.WrongNumberOfArguments(sourceCodeLine, 3);
            var (_, target, (source, _)) = lexems;
            if (int.TryParse(source, out var number))
                action = (state) => state[target] = number;
            else
                action = (state) => state[target] = state[source];
        }

        public override void Execute(RegistersState state)
        {
            action(state);
        }
    }
}