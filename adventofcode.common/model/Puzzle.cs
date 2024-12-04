namespace adventofcode.common.model;

public readonly record struct Puzzle(
	string? Name,
	int Year,
	int Day,
	Type PuzzleType
);
