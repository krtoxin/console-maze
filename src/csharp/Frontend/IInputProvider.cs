namespace ConsoleMaze.Frontend;

internal interface IInputProvider
{
    (int dx, int dy) GetInput();
}
