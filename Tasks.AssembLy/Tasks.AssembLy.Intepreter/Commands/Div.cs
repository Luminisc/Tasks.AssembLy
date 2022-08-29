using Tasks.AssembLy.Intepreter.Extensions;
using Tasks.AssembLy.Intepreter.Parsing.Exceptions;

namespace Tasks.AssembLy.Intepreter.Commands
{
    internal class Div : Command
    {
        public const string Code = "div";
        public override string CommandCode => Code;
        private readonly Action<RegistersState> action;

        public Div(string sourceCodeLine) : base(sourceCodeLine)
        {
            var lexems = sourceCodeLine.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (lexems.Length != 3)
                throw ParsingException.WrongNumberOfArguments(sourceCodeLine, 3);
            var (_, target, (source, _)) = lexems;
            if (int.TryParse(source, out var number))
                action = (state) => state[target] /= number;
            else
                action = (state) => state[target] /= state[source];
        }

        public override void Execute(RegistersState state)
        {
            action(state);
        }
    }
}
