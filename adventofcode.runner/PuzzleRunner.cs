using System.Reflection;
using adventofcode.common.attributes;
using adventofcode.common.model;

namespace adventofcode.runner;

public class PuzzleRunner
{
    private readonly IReadOnlyList<Puzzle> puzzles;

    public PuzzleRunner()
    {
        puzzles = GetAllPuzzles();
    }

    public IReadOnlyCollection<Puzzle> Puzzles => puzzles;

    private static List<Puzzle> GetAllPuzzles()
    {
        var assembly = Assembly.GetAssembly(typeof(puzzles._2024.Day1))!;

        var c = assembly.GetTypes()
            .Select(t => new {Type = t, PuzzleAttribute = t.GetCustomAttribute<PuzzleAttribute>()})
            .Where(x => x.PuzzleAttribute != null);

        return c
            .Select(x => new Puzzle(
                x.PuzzleAttribute.Name,
                x.PuzzleAttribute.Year,
                x.PuzzleAttribute.Day,
                x.Type))
            .ToList();
    }
}