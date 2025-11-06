using System.Collections.Generic;

namespace ConsoleMaze.Engine;

internal sealed class GameState
{
    public int Width { get; }
    public int Height { get; }
    public int BlockFreq { get; }
    public char DogSymbol { get; }

    public List<List<char>> Field { get; } = new();

    public int DogX { get; private set; }
    public int DogY { get; private set; }

    public int FinishX { get; private set; }
    public int FinishY { get; private set; }
    public bool ReachedFinish { get; private set; }

    public GameState(int width, int height, int blockFreq, char dogSymbol)
    {
        Width = width;
        Height = height;
        BlockFreq = blockFreq;
        DogSymbol = dogSymbol;
    }

    public void GenerateField(System.Random rng)
    {
        Field.Clear();
        for (int i = 0; i < Height; i++)
        {
            Field.Add(new List<char>());
            for (int j = 0; j < Width; j++)
            {
                int rand = rng.Next(0, 101);
                char symbol = rand < BlockFreq ? '#' : '.';
                Field[i].Add(symbol);
            }
        }
        FinishX = rng.Next(0, Width);
        FinishY = rng.Next(0, Height);
        Field[FinishY][FinishX] = 'Д';
        ReachedFinish = false;
    }

    public void PlaceDog(System.Random rng)
    {
        DogX = rng.Next(0, Width);
        DogY = rng.Next(0, Height);
    }

    public void Generate(System.Random rng)
    {
        GenerateField(rng);
        PlaceDog(rng);
    }

    public bool IsWalkable(int x, int y) => Field[y][x] != '#';

    public bool CanGoTo(int newX, int newY)
    {
        if (newX < 0 || newY < 0 || newX >= Width || newY >= Height)
            return false;
        if (!IsWalkable(newX, newY))
            return false;
        return true;
    }

    public void GoTo(int newX, int newY)
    {
        DogX = newX;
        DogY = newY;
    }

    public void TryGoTo(int newX, int newY)
    {
        if (CanGoTo(newX, newY))
            GoTo(newX, newY);
    }

    public void CheckFinish()
    {
        if (DogX == FinishX && DogY == FinishY)
            ReachedFinish = true;
    }
}
