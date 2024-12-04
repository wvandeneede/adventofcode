namespace adventofcode.common.model;

public readonly record struct PuzzleModel(
	string? Name,
	int Year,
	int Day,
	Type PuzzleType
);
