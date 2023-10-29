using UnityEngine;

public class UIBootstrap : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private StaminaBar _staminaBar;
    [SerializeField] private AbilityButtons _abilityButtons;

    public void Initialise(Hero hero)
    {
        _healthBar.Initialise(hero);
        _staminaBar.Initialise(hero);
        _abilityButtons.Initialise(hero);
    }
}
