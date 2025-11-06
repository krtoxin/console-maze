using System;
using ConsoleMaze.Frontend;

namespace ConsoleMaze.Engine;

internal sealed class GameEngine
{
    private readonly GameState _state;
    private readonly IRenderer _renderer;
    private readonly IInputProvider _input;
    private readonly Random _rng;

    public GameEngine(GameState state, IRenderer renderer, IInputProvider input, Random rng)
    {
        _state = state;
        _renderer = renderer;
        _input = input;
        _rng = rng;
    }

    public void Run()
    {
        _state.Generate(_rng);
        _renderer.Draw(_state);

        while (!IsEndGame())
        {
            var (dx, dy) = _input.GetInput();
            Logic(dx, dy);
            _renderer.Draw(_state);
        }

        Console.WriteLine("УИИИИИИИИИ");
    }

    private bool IsEndGame() => _state.ReachedFinish;

    private void Logic(int dx, int dy)
    {
        _state.TryGoTo(_state.DogX + dx, _state.DogY + dy);
        _state.CheckFinish();
    }
}
