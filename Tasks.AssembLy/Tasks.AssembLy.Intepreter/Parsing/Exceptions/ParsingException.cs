namespace Tasks.AssembLy.Intepreter.Parsing.Exceptions
{
    internal class ParsingException : Exception
    {
        public ParsingException(string messsage) : base(messsage) { }

        public static ParsingException WrongNumberOfArguments(string sourceCodeLine, int expected)
        {
            return new ParsingException($"Wrong number of arguments in operation!\nExpected: {expected}.\nLine: \"{sourceCodeLine}\"");
        }
    }
}
