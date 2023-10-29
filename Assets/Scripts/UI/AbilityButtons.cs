using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButtons : MonoBehaviour
{
    [SerializeField] private Button _multishot;
    [SerializeField] private Button _powershot;

    private Hero _hero;
    private WaitForSeconds _sleep = new WaitForSeconds(2f);

    public void Initialise(Hero hero)
    {
        _hero = hero;
    }

    public void OnMultishotButtonClicked()
    {
        _hero.UseMultishot();
        StartCoroutine(Sleep(_multishot));
    }

    public void OnPowershotButtonClicked()
    {   
        _hero.UsePowershot();
        StartCoroutine(Sleep(_powershot));
    }

    private IEnumerator Sleep(Button button)
    {
        button.interactable = false;
        yield return _sleep;
        button.interactable = true;
    }
}
