using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _sliderSpeed;

    private Hero _hero;

    private void OnDisable()
    {
        _hero.Health.Changed -= OnValueChanged;
    }

    public void Initialise(Hero hero)
    {
        _hero = hero;

        _hero.Health.Changed += OnValueChanged;

        _slider.value = _hero.Health.CurrentValue;
    }

    private void OnValueChanged(int value)
    {
        _slider.value = value;
    }
}
