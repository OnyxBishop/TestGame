using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _sliderSpeed;

    private Hero _hero;

    private void OnDisable()
    {
        _hero.Stamina.ValueChanged -= OnValueChanged;
    }

    public void Initialise(Hero hero)
    {
        _hero = hero;
        _hero.Stamina.ValueChanged += OnValueChanged;
        _slider.value = _hero.Stamina.CurrentValue;
    }

    private void OnValueChanged(float value)
    {
        _slider.value = value;
    }
}
