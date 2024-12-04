using Spectre.Console;

var console = AnsiConsole.Create(new AnsiConsoleSettings());

var font = FigletFont.Load("doom.flf");
var f = new FigletText(font, "Advent of Code")
{
    Color = ConsoleColor.Green,
};

console.Write(f);
