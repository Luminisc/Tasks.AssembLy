// ########################## ASM Interpreter ########################## //
// >> mov a, 5                                            | Registers: | //
//    inc a                                               | next = 0   | //
//    call function                                       | a    = 0   | //
//    msg '(5+1)/2 = ', a    ; output message             | b    = 0   | //
//    end                                                 |            | //
//                                                                       //
//    function:                                                          //
//    mov a,1                                                            //
//    ret                                                                //
//                                                                       //
// ##########################$$$$$$$$$$$$$$$$$########################## //

namespace Tasks.AssembLy.Console
{
    internal class ConsolePrinter // : IPrinter
    {
        public int Width;
        public int Height;
        public void Initialize()
        {
            Width = 100;
            Height = Math.Min(System.Console.LargestWindowHeight, 50);

            System.Console.CursorVisible = false;
            ResizeConsole();
            DrawScene();
        }

        public void Draw(Intepreter.Intepreter intepreter)
        {
            PrintCommands(intepreter);
            PrintRegister(intepreter);
        }

        private void PrintCommands(Intepreter.Intepreter intepreter)
        {
            var currentStep = intepreter.State.CurrentCommand;
            ClearRectangle(2, 2, intepreter.Commands.Max(x => x.ToString().Length) + 8, intepreter.Commands.Count);
            for (int i = 0; i < intepreter.Commands.Count; i++)
            {
                var command = intepreter.Commands[i];
                var commandLine = $"{(i == currentStep ? " >> " : string.Empty),6} {command}";
                WriteText(2, 2 + i, commandLine);
            }
        }

        private void PrintRegister(Intepreter.Intepreter intepreter)
        {
            var registers = intepreter.State.GetRegisters();
            var maxLength = registers.Count > 0
                ? registers.Max(x => x.Key.Length)
                : 0;
            var lines = registers.OrderBy(x => x.Key)
                .Select(x => $"{x.Key.PadLeft(maxLength + 1)}: {x.Value}")
                .ToList();
            maxLength = lines.Count > 0
                ? lines.Max(x => x.Length)
                : 0;
            var width = Math.Max("| Registers: |".Length, maxLength + 4);

            ClearRectangle(Width - 1 - width, 1, width, lines.Count + 1);
            WriteText(Width - 1 - width, 1, $"{"| Registers:".PadRight(width - 4)} |");
            for (int i = 0; i < lines.Count; i++)
            {
                WriteText(Width - 1 - width, 2 + i, $"| {lines[i]} |");
            }
        }

        public void Wait()
        {
            System.Console.SetCursorPosition(1, Height - 2);
            System.Console.ReadLine();
        }

        private static void ClearRectangle(int x, int y, int width, int height)
        {
            var clearRow = new string(' ', width);
            for (var i = 0; i < height; i++)
            {
                WriteText(x, y + i, clearRow);
            }
        }

        private void ResizeConsole()
        {
            if (OperatingSystem.IsWindows())
            {
                System.Console.BufferWidth = System.Console.WindowWidth = Width;
                System.Console.BufferHeight = System.Console.WindowHeight = Height;
            }
        }

        private void DrawScene()
        {
            var border = new string('#', Width);
            WriteText(0, 0, border);
            WriteText(0, Height - 1, border);
            var sideBorderChars = new char[Width + 1];
            for (var i = 1; i < sideBorderChars.Length - 2; i++) sideBorderChars[i] = ' ';
            sideBorderChars[0] = sideBorderChars[Width - 1] = '#';
            var sideBorder = new string(sideBorderChars);
            for (int i = 1; i < Height - 1; i++)
            {
                WriteText(0, i, sideBorder);
            }

            var title = " ASM Intepreter ";
            WriteText(Width / 2 - title.Length / 2, 0, title);
        }

        private static void WriteText(int x, int y, string text)
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(text);
        }
    }
}
