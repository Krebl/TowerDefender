using Configs;
using Model;
using UnityEngine;

public class GameRoot : Singleton<GameRoot>
{
    [SerializeField] private GameConfig _gameConfig;
    
    public GameLogic GameLogic { get; private set; }

    private void Awake()
    {
        StartGame();
    }

    private void StartGame()
    {
        GameLogic = new GameLogic(_gameConfig);
    }
}
