using System;

namespace ConsoleMaze.Frontend;

internal sealed class ConsoleInputProvider : IInputProvider
{
    public (int dx, int dy) GetInput()
    {
        int dx = 0, dy = 0;
        string? inp = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inp))
            return (0, 0);

        string first = inp.Trim().Split()[0];
        if (first == "W" || first == "w") dy = -1;
        if (first == "A" || first == "a") dx = -1;
        if (first == "S" || first == "s") dy = 1;
        if (first == "D" || first == "d") dx = 1;
        return (dx, dy);
    }
}
