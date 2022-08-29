using Tasks.AssembLy.Intepreter.Commands;

namespace Tasks.AssembLy.Intepreter.Parsing
{
    internal class Parser
    {
        private readonly static char[] Eol = new[] { '\n' };
        public static List<Command> ParseSourceCode(string sourceCode)
        {
            var lines = sourceCode.Split(Eol)
                .Select(x => TryParseCommand(x))
                .Where(x => x != null);
            return lines.ToList()!;
        }

        private static Command? TryParseCommand(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;
            if (line.IndexOf(';') >= 0)
                line = line[..line.IndexOf(';')]; // remove comment
            var firstWord = line.TrimStart()
                .Split()
                .FirstOrDefault()
                ?.ToLower();
            if (firstWord == null || firstWord == ";")
                return new CommentLine(line ?? string.Empty);

            return TryParseCommand(firstWord, line);
        }

        private static Command? TryParseCommand(string firstWord, string line)
        {
            return firstWord switch
            {
                Mov.Code => new Mov(line),
                Inc.Code => new Inc(line),
                Dec.Code => new Dec(line),
                Add.Code => new Add(line),
                Sub.Code => new Sub(line),
                Mul.Code => new Mul(line),
                Div.Code => new Div(line),
                _ => new CommentLine(line),
            };
        }
    }
}
