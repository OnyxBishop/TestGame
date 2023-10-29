using TMPro;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private Canvas _userInterface;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Canvas _finishMenu;
    [SerializeField] private TMP_Text _text;

    private const string Victory = nameof(Victory) + " !!!";
    private const string Lose = nameof(Lose) + " :(";

    private Hero _hero;

    public void Initialise(Hero hero)
    {
        _hero = hero;
        _enemySpawner.AllEnemyDied += OnAllEnemyDied;
        _hero.Health.Died += OnHeroDied;
    }

    private void OnDisable()
    {
        _enemySpawner.AllEnemyDied -= OnAllEnemyDied;
        _hero.Health.Died += OnHeroDied;
    }

    private void OnAllEnemyDied()
    {
        ShowEndGameMenu(Victory);
    }

    private void OnHeroDied()
    {
        ShowEndGameMenu(Lose);
    }

    private void ShowEndGameMenu(string endGameText)
    {
        _userInterface.enabled = false;
        _text.text = endGameText;
        _finishMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
