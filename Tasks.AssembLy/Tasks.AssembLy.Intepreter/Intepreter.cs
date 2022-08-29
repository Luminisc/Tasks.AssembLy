using Tasks.AssembLy.Intepreter.Parsing;

namespace Tasks.AssembLy.Intepreter
{
    public class Intepreter
    {
        public bool Finished { get; private set; } = false;
        public readonly List<Command> Commands = new();
        public RegistersState State { get; private set; }

        private Intepreter(List<Command> commands)
        {
            this.Commands = commands;
        }

        public void Initialize(RegistersState? state = null)
        {
            if (state == null)
                state = new RegistersState();
            this.State = state;
        }

        public void MakeStep()
        {
            var stepIndex = State.CurrentCommand;
            if (stepIndex < 0)
                throw new ApplicationException($"Exited with code: {stepIndex}");
            if (stepIndex >= Commands.Count)
            {
                Finished = true;
                return;
            }

            State.CurrentCommand++;
            Commands[stepIndex].Execute(State);
        }

        public static Intepreter FromSourceCode(string testProgram)
        {
            var commands = Parser.ParseSourceCode(testProgram);
            return new Intepreter(commands);
        }
    }
}