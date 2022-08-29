using Tasks.AssembLy.Console;
using Tasks.AssembLy.Intepreter;

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

var TestProgram =
    "; My first program\n" +
    "mov  a, 5\n" +
    "inc  a\n" +
    "call function\n" +
    "msg  '(5+1)/2 = ', a    ; output message\n" +
    "end\n" +
    "\n" +
    "function:\n" +
    "mov a, 1\n" +
    "ret";
var interpreter = Intepreter.FromSourceCode(TestProgram);
interpreter.Initialize();
var printer = new ConsolePrinter();
printer.Initialize();

do
{
    printer.Draw(interpreter);
    printer.Wait();
    interpreter.MakeStep();
} while (!interpreter.Finished);

printer.Draw(interpreter);
printer.Wait();