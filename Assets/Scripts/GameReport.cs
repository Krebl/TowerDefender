
public static class GameReport
{
    public enum GameState
    {
        PreStart,
        Playing,
        GameOver
    }

    private static GameState _currentState = GameState.PreStart;

    public static GameState CurrentState
    {
        get => _currentState;
        set => _currentState = value;
    }

    public static bool IsPlaying => CurrentState == GameState.Playing;

}
