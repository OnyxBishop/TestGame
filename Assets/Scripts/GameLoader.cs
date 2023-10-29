using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private SpawnBootstrap _spawnBootstrap;
    [SerializeField] private UIBootstrap _ui;
    [SerializeField] private FinishGame _finishGame;

    private Hero _hero;

    private void Awake()
    {
        _spawnBootstrap.Initialise();
        _hero = Spawn.HeroInstance;
        _ui.Initialise(_hero);
        _finishGame.Initialise(_hero);
    }
}
