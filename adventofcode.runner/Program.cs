using adventofcode.common.model;
using adventofcode.runner;
using Spectre.Console;

var runner = new PuzzleRunner();
var console = AnsiConsole.Create(new AnsiConsoleSettings());

var font = FigletFont.Load("doom.flf");
var f = new FigletText(font, "Advent of Code")
{
    Color = ConsoleColor.Green,
};

console.Write(f);

var puzzles = runner.Puzzles;
if(puzzles.Count == 0) 
{
    console.Markup("[red]Could not find any puzzles. Exiting.[/]");
    return 0;
}

var years = puzzles.Select(x => x.Year).Distinct().Order().ToList();

(var year, puzzles) = PickYear(puzzles, years);

console.MarkupLineInterpolated($"Running year [red]{year}[/].");

puzzles = PickPuzzles(puzzles, year);

console.MarkupLineInterpolated($"Running puzzle(s) [red]{string.Join(", ", puzzles.Select(x => x.Day))}[/].");

(int, IReadOnlyCollection<Puzzle>) PickYear(IReadOnlyCollection<Puzzle> puzzles, IReadOnlyList<int> years)
{
    var year = years[^1];

    if (years.Count > 1)
    {
        year = console.Prompt(
            new SelectionPrompt<int>()
                .Title("Which [green]year[/] do you want to execute?")
                .PageSize(20)
                .AddChoices(years));
    }

    return (year, puzzles.Where(x => x.Year == year).ToList());
}

IReadOnlyCollection<Puzzle> PickPuzzles(IReadOnlyCollection<Puzzle> puzzles, int year)
{
    var selectedDays = console.Prompt(
        new MultiSelectionPrompt<int>()
            .Title("Which [green]year[/] do you want to execute?")
            .PageSize(20)
            .MoreChoicesText("[grey](Move up and down to reveal more days)[/]")
            .InstructionsText(
                "[grey](Press [blue]<space>[/] to toggle a day, " +
                "[green]<enter>[/] to accept)[/]")
            .AddChoiceGroup(
                year,
                puzzles.Select(x => x.Day).Distinct().Order()));

    return puzzles
        .Where(p => selectedDays.Contains(p.Day))
        .OrderBy(p => p.Day)
        .ToList();
}

return 0;

