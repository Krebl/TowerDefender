using Configs;
using Game;
using Model;
using UnityEngine;
using View;

public class GameRoot : Singleton<GameRoot>
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private GameController _gameController;
    
    public GameLogic GameLogic { get; private set; }

    private void Awake()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        GameLogic = new GameLogic(_gameConfig);
        
        _gameController.CreateLevel(GameLogic);
        NavigationView.Instance.PushView<GameView>();
    }
}
