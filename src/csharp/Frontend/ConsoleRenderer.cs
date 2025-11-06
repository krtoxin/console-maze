using System;
using ConsoleMaze.Engine;

namespace ConsoleMaze.Frontend;

internal sealed class ConsoleRenderer : IRenderer
{
    public void Draw(GameState state)
    {
        for (int i = 0; i < state.Height; i++)
        {
            for (int j = 0; j < state.Width; j++)
            {
                char symbol = (i == state.DogY && j == state.DogX) ? state.DogSymbol : state.Field[i][j];
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }
}
