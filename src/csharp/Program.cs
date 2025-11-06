using ConsoleMaze.Engine;
using ConsoleMaze.Frontend;

internal static class Program
{
    static void Main()
    {
        var rng = System.Random.Shared;
        var state = new GameState(width: 10, height: 12, blockFreq: 28, dogSymbol: '@');
        IInputProvider input = new ConsoleInputProvider();
        IRenderer renderer = new ConsoleRenderer();
        var engine = new GameEngine(state, renderer, input, rng);
        engine.Run();
    }
}
