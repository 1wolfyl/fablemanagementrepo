using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }
    public static event System.Action<GameState> OnGameStateChanged;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void UpdateGameState(GameState NewState)
    {
        CurrentState = NewState;
        switch (NewState)
        {
            case GameState.MainMenu:
                break;
            case GameState.ArenaOpen:
                break;
            case GameState.Event:
                break;
            case GameState.ArenaClose:
                break;
            case GameState.Winning:
                break;
            case GameState.Losing:
                break;
                default:
                throw new System.ArgumentOutOfRangeException(nameof(NewState), NewState, null);
        }
        OnGameStateChanged?.Invoke(NewState);
    }
    public enum GameState
{
    MainMenu,
    ArenaOpen,
    Event,
    ArenaClose,
    Winning,
    Losing
}
}