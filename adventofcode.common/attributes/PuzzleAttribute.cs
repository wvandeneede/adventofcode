namespace adventofcode.common.attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class PuzzleAttribute(int year, int day, string? name = null) : Attribute
{
	public string? Name { get; } = name;
	public int Year { get; } = year;
	public int Day { get; } = day;
}
